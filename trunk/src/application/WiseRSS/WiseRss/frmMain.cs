using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Facebook;
using Business;
using Rss;
using System.Threading.Tasks;
using System.IO;

using LinqToTwitter;
using System.Dynamic;

namespace WiseRss
{
  public partial class frmMain : Form
  {
    public PinAuthorizer twitterAuth = new PinAuthorizer
    {
      Credentials = new InMemoryCredentials
      {
        ConsumerKey = "JvAth300s1jAyGkmgEQwQ",
        ConsumerSecret = "6Pl9JfnbJPrwR4uacVKWp8MSgTYi5aZAcFaTsnSiw",
      },
      UseCompression = true,
      GoToTwitterAuthorization = pageLink => Process.Start(pageLink),
      GetPin = () =>
      {
        TwitterPin tp = new TwitterPin();
        tp.ShowDialog();
        return tp.pin;
      }
    };

    private RssObject wRssObject = new RssObject();
    private List<string> lstNewFeeds = new List<string>();
    private DataFormats.Format bmpFormat = DataFormats.GetFormat(DataFormats.Bitmap);
    private Bitmap[] bitmaps = new Bitmap[] {
      Properties.Resources.mail_icon,
      Properties.Resources.bookmarks_icon,
      Properties.Resources.disable_bookmarks_icon,
      Properties.Resources.facebook_icon,
      Properties.Resources.twitter_icon
    };

    private frmEmail frmMail = new frmEmail();
    private FacebookClient fb;
    private RssItem selItem = null;

    public frmMain()
    {
      InitializeComponent();
      LoadTreeView();

      // The Top Posts widgets and the PostRank APIs is disabled.
      // More http://blog.postrank.com/2012/01/the-top-posts-widget-and-google-reader-extension-to-be-retired-on-april-1st/
    }

    public RssObject WRssObject
    {
      get { return wRssObject; }
    }

    public List<string> ListNewFeeds
    {
      get { return lstNewFeeds; }
    }

    private void LoadTreeView()
    {
      if (treeView1.Nodes.IndexOfKey("NodeSubscriptions") < 0)
      {
        return;
      }

      if (treeView1.Nodes.IndexOfKey("NodeTags") < 0)
      {
        return;
      }

      if (treeView1.Nodes.IndexOfKey("NodeBookmarks") < 0)
      {
        return;
      }
      
      TreeNodeCollection bookmarks = treeView1.Nodes["NodeBookmarks"].Nodes;
      TreeNodeCollection nodes = treeView1.Nodes["NodeTags"].Nodes;

      foreach (RssCategory category in WRssObject.Categories)
      {
        nodes.Add(category.Name);
      }

      ImageList imgList = new ImageList();

      Bitmap bmp = new Bitmap(Properties.Resources.rss_icon);

      using (Graphics g = Graphics.FromImage(bmp))
      {
        g.DrawRectangle(new Pen(new SolidBrush(Color.White)), 0, 0, bmp.Width, bmp.Height);
        g.DrawImage(bmp, 0, 0);
      }

      imgList.Images.Add(bmp);

      bmp = new Bitmap(Properties.Resources.tag_icon);
      imgList.Images.Add(bmp);

      bmp = new Bitmap(Properties.Resources.bookmarks_icon);
      imgList.Images.Add(bmp);

      treeView1.ImageList = imgList;
      nodes = treeView1.Nodes["NodeSubscriptions"].Nodes;
      TreeNode node = null;

      Parallel.ForEach(WRssObject.Channels, channel =>
      {
        node = new TreeNode(channel.Title.Substring(0,
          System.Math.Min(channel.Title.Length, 99)));

        node.ToolTipText = channel.Description.Substring(0,
          System.Math.Min(channel.Description.Length, 99));

        TreeNode childNode = null;

        foreach (RssItem item in channel.Items)
        {
          childNode = new TreeNode(item.Title.Substring(0,
          System.Math.Min(item.Title.Length, 99)));

          childNode.ToolTipText = item.Description.Substring(0,
            System.Math.Min(item.Description.Length, 99)) + "...";
          node.Nodes.Add(childNode);

          // TODO: if not added
          if (item.Favorite)
          {
            bookmarks.Add(node.Text);
          }
        }

        nodes.Add(node);
      });
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      ListNewFeeds.Clear();
    }

    private void LoadRichTextBoxIcons()
    {
      foreach (Bitmap bmp in bitmaps)
      {
        this.Invoke((MethodInvoker)delegate()
        {
          PasteBitmap(bmp);
        });
      }
    }

    private void PasteBitmap(Bitmap image)
    {
      Clipboard.SetDataObject(image);

      if (rchTxtContent.CanPaste(bmpFormat))
      {
        rchTxtContent.Paste(bmpFormat);
      }
    }

    private void AddNewFeeds()
    {
      TreeNodeCollection nodeFeed = treeView1.Nodes["NodeSubscriptions"].Nodes;

      foreach (string url in lstNewFeeds)
      {
        RssFeed feed = null;

        try
        {
          feed = RssFeed.Read(url);
        }
        catch (Exception ex)
        {
#if DEBUG
          new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
          return;
        }

        if (feed == null)
        {
          return;
        }

        foreach (RssChannel channel in feed.Channels)
        {
          byte[] channelPlainTextBytes = Encoding.UTF8.GetBytes(channel.Link.OriginalString);
          string channelPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) +
            "\\img\\" +
            Util.String.WindowsPath(Convert.ToBase64String(channelPlainTextBytes));

          try
          {
            // create img folder for this channel
            if (!System.IO.Directory.Exists(channelPath))
            {
              Directory.CreateDirectory(channelPath);
            }
          }
          catch (Exception) { }

          TreeNodeCollection nodeCategories = treeView1.Nodes["NodeTags"].Nodes;

          foreach (RssCategory category in channel.Categories)
          {
            if (-1 == TreeNodeCollectionContains(nodeCategories, category.Name))
            {
              if (!nodeCategories.ContainsKey(category.Name))
              {
                this.Invoke((MethodInvoker)delegate() { nodeCategories.Add(category.Name); });
              }
            }
          }

          TreeNode node = null;
          bool newFeed = false;
          int index = TreeNodeCollectionContains(nodeFeed, channel.Title);

          if (index > -1)
          {
            node = nodeFeed[index];
          }
          else
          {
            newFeed = true;
            node = new TreeNode(channel.Title.Substring(0,
              System.Math.Min(channel.Title.Length, 99)));

            node.ToolTipText = channel.Description.Substring(0,
              System.Math.Min(channel.Description.Length, 99));
          }

          TreeNode childNode = null;

          foreach (RssItem item in channel.Items)
          {
            index = TreeNodeCollectionContains(node.Nodes, item.Title);

            if (index > -1)
            {
              childNode = node.Nodes[index];
              childNode.ToolTipText = item.Description.Substring(0,
                System.Math.Min(item.Description.Length, 99));
            }
            else
            {
              childNode = new TreeNode(item.Title.Substring(0,
                System.Math.Min(item.Title.Length, 99)));
              childNode.ToolTipText = item.Description.Substring(0,
                System.Math.Min(item.Description.Length, 99));

              this.Invoke((MethodInvoker)delegate() { node.Nodes.Add(childNode); });
            }
            item.Status = RssStatus.Update;
          }
          channel.Status = RssStatus.Update;
          channel.Image.Status = RssStatus.Update;

          if (newFeed)
          {
            this.Invoke((MethodInvoker)delegate() { nodeFeed.Add(node); });
          }

          // insert new channel
          WRssObject.InsertNewChannel(channel, feed.Url);
        }
      }
      lstNewFeeds.Clear();
    }

    private int TreeNodeCollectionContains(TreeNodeCollection collection, string name)
    {
      int i = 0;
      foreach (TreeNode node in collection)
      {
        if (name.Equals(node.Text))
        {
          return i;
        }
        ++i;
      }
      return -1;
    }

    private void newFeedToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (frmAddNewFeeds frmFeed = new frmAddNewFeeds(this))
      {
        frmFeed.ShowDialog(this);
      }

      MethodInvoker addNewFeedsDelegate = new MethodInvoker(AddNewFeeds);

      addNewFeedsDelegate.BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar)
      {
        this.Invoke((MethodInvoker)delegate()
        {
          addNewFeedsDelegate.EndInvoke(ar);
        });
      }),
        null);
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
      TreeNode node = e.Node;
      if (node == null) { return; }

      TreeNode parent = node.Parent;
      if (parent == null) { return; }

      TreeNode parentParent = node.Parent.Parent;

      rchTxtContent.Clear();
      RssChannel channel = null;
      RssItem item = null;

      // Node Subscriptions
      if (parent.Text.Equals(treeView1.Nodes[0].Text) ||
          (parentParent != null && parentParent.Text.Equals(treeView1.Nodes[0].Text)))
      {
        if (parentParent == null)
        {
          channel = WRssObject.GetChannel(node.Text);
          btnBookmark.Image = bitmaps[2];
        }
        else
        {
          channel = WRssObject.GetChannel(parent.Text);
          item = WRssObject.GetItem(parent.Text + node.Text);
          btnBookmark.Image = item.Favorite ? bitmaps[1] : bitmaps[2];
        }
      }

      // Node Bookmarks
      if (parent.Text.Equals(treeView1.Nodes[2].Text))
      {
        //channel = WRssObject.GetChannel(parent.Text);
        item = WRssObject.GetBookmark(node.Text);
      }

      if (channel == null) { return; }

      rchTxtContent.AppendText(channel.Title);
      rchTxtContent.AppendText(System.Environment.NewLine);
      rchTxtContent.AppendText(channel.LastBuildDate.ToString());
      rchTxtContent.AppendText(System.Environment.NewLine);

      if (item != null)
      {
        rchTxtContent.AppendText(item.Description);
        selItem = item;
      }
      else
      {
        if (channel.Image.Image != null && channel.Image.Image.Length > 0)
        {
          PasteBitmap(new Bitmap(channel.Image.Image));
        }
        rchTxtContent.AppendText(channel.Description);
      }
    }

    private void btnMail_Click(object sender, EventArgs e)
    {
      if (selItem != null)
      {
        try
        {
          frmMail.setParams(selItem.Title, selItem.Link.AbsoluteUri);
          frmMail.ShowDialog();
        }
        catch (Exception) { }
      }
    }

    private void btnTwitt_Click(object sender, EventArgs e)
    {
      try
      {
        if (!twitterAuth.IsAuthorized)
        {
          twitterAuth.Authorize();
        }
        if (twitterAuth.IsAuthorized)
        {
          using (var twitterCtx = new TwitterContext(twitterAuth, "https://api.twitter.com/1/", "https://search.twitter.com/"))
          {
            twitterCtx.UpdateStatus(selItem.Link.AbsoluteUri);
          }
        }
        else
        {
          MessageBox.Show("Avtorizacija ni uspela.");
        }
      }
      catch (Exception)
      {

      }
    }

    private void btnFacebook_Click(object sender, EventArgs e)
    {
      FacebookLoginDialog fbLoginDlg = new FacebookLoginDialog("345930678768307", "user_about_me,publish_stream,offline_access");
      if (fb == null)
      {
        fbLoginDlg.ShowDialog();
        if (fbLoginDlg.FacebookOAuthResult == null)
        {
          // the user closed the FacebookLoginDialog, so do nothing.
          MessageBox.Show("Cancelled!");
          return;
        }
        if (fbLoginDlg.FacebookOAuthResult.IsSuccess)
        {
          fb = new FacebookClient(fbLoginDlg.FacebookOAuthResult.AccessToken);
        }
      }
      // Even though facebookOAuthResult is not null, it could had been an 
      // OAuth 2.0 error, so make sure to check IsSuccess property always.
      if (fb != null && selItem != null)
      {
        dynamic parameters = new ExpandoObject();
        parameters.message = selItem.Title;
        parameters.link = selItem.Link.AbsoluteUri;

        fb.PostAsync("me/feed", parameters);
      }
      else
      {
        // for some reason we failed to get the access token.
        // most likely the user clicked don't allow.
        MessageBox.Show(fbLoginDlg.FacebookOAuthResult.ErrorDescription);
      }
    }

    private void btnBookmark_Click(object sender, EventArgs e)
    {
      if (treeView1.SelectedNode != null &&
          treeView1.SelectedNode.Parent != null &&
          treeView1.SelectedNode.Parent.Parent != null &&
          treeView1.SelectedNode.Parent.Parent.Text.Equals("Subscriptions"))
      {
        RssItem item = WRssObject.GetItem(treeView1.SelectedNode.Parent.Text + treeView1.SelectedNode.Text);

        Debug.Assert(item != null);

        item.Favorite = !item.Favorite;
        TreeNodeCollection bookmarks = treeView1.Nodes["NodeBookmarks"].Nodes;

        if (item.Favorite)
        {
          btnBookmark.Image = bitmaps[1];
          bookmarks.Add(item.Title);
        }
        else
        {
          btnBookmark.Image = bitmaps[2];

          int index = TreeNodeCollectionContains(bookmarks, item.Title);

          if (index > -1)
          {
            bookmarks.RemoveAt(index);
          }
        }
      }
    }
      
    private void btnTag_Click(object sender, EventArgs e)
    {
        new RssObject().InsertNewItems();
    }

    private void btnTranslate_Click(object sender, EventArgs e)
    {

    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
          rchTxtContent.SaveFile(saveFileDialog1.FileName);
        }
      }
      catch (Exception)
      {

      }
    }

    private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}