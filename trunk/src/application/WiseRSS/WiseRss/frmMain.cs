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

    private string microsoftTranslateAPIKeyFile = "MicrosoftTranslateAPIKey.ini";
    private string microsoftTranslateAPIKey = string.Empty;
    private Dictionary<string, string> microsoftTranslatorLangueges = new Dictionary<string, string>();
    private bool isGoogleTranslator = true;

    private RssObject wRssObject = new RssObject();
    private List<string> lstNewFeeds = new List<string>();
    private DataFormats.Format bmpFormat = DataFormats.GetFormat(DataFormats.Bitmap);
    private Bitmap[] bitmaps = new Bitmap[] {
      Properties.Resources.mail_icon,
      Properties.Resources.bookmarks_icon,
      Properties.Resources.disable_bookmarks_icon,
      Properties.Resources.facebook_icon,
      Properties.Resources.twitter_icon,
      Properties.Resources.tag_icon,
      Properties.Resources.rss_icon
    };

    private frmEmail frmMail = new frmEmail();
    private FacebookClient fb;
    private RssItem selItem = null;

    public frmMain()
    {
      InitializeComponent();
      LoadTreeView();
      ReadMicrosoftTranslateAPIKey();
      // The Top Posts widgets and the PostRank APIs is disabled.
      // More http://blog.postrank.com/2012/01/the-top-posts-widget-and-google-reader-extension-to-be-retired-on-april-1st/

      //Boilerpipe.ImageExtractor("http://edition.cnn.com/2012/01/16/world/europe/italy-cruise-main/index.html?eref=edition");
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

      Bitmap bmp = bitmaps[6];

      using (Graphics g = Graphics.FromImage(bmp))
      {
        g.DrawRectangle(new Pen(new SolidBrush(Color.White)), 0, 0, bmp.Width, bmp.Height);
        g.DrawImage(bmp, 0, 0);
      }

      imgList.Images.Add(bmp);
      imgList.Images.Add(bitmaps[5]);
      imgList.Images.Add(bitmaps[1]);

      treeView1.ImageList = imgList;
      nodes = treeView1.Nodes["NodeSubscriptions"].Nodes;
      TreeNode node = null;

      Parallel.ForEach(WRssObject.Channels, channel =>
      {
        node = new TreeNode(channel.ShortTitle);
        node.ToolTipText = channel.ShortDescription;
        node.Tag = channel.Link.OriginalString;
        nodes.Add(node);

        TreeNode childNode = null;

        foreach (RssItem item in channel.Items)
        {
          childNode = new TreeNode(item.ShortTitle);
          childNode.ToolTipText = item.ShortDescription;
          childNode.Tag = item.Link.OriginalString;
          node.Nodes.Add(childNode);

          if (item.Favorite)
          {
            bookmarks.Add(childNode.Clone() as TreeNode);
          }
        }
      });
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      ListNewFeeds.Clear();
      WRssObject.SaveChanges();
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

        if (feed == null) { return; }

        foreach (RssChannel channel in feed.Channels)
        {
          byte[] channelPlainTextBytes = Encoding.UTF8.GetBytes(channel.OriginalLink);
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
            TreeNode categoryNode = new TreeNode(category.Name);

            if (WRssObject.AddCategoryNode(categoryNode))
            {
              this.Invoke((MethodInvoker)delegate() { nodeCategories.Add(categoryNode); });
            }
          }

          TreeNode node = null;
          bool newFeed = false;
          int index = TreeNodeCollectionContains(nodeFeed, channel.Link.OriginalString);

          if (index > -1)
          {
            node = nodeFeed[index];
          }
          else
          {
            newFeed = true;
            node = new TreeNode();
            node.Tag = channel.Link.OriginalString;
          }

          Invoke((MethodInvoker)delegate()
          {
            node.Text = channel.ShortTitle;
            node.ToolTipText = channel.ShortDescription;
          });

          TreeNode childNode = null;

          foreach (RssItem item in channel.Items)
          {
            index = TreeNodeCollectionContains(node.Nodes, item.Link.OriginalString);

            if (index > -1)
            {
              childNode = node.Nodes[index];
            }
            else
            {
              childNode = new TreeNode();
              childNode.Tag = item.Link.OriginalString;
            }

            Invoke((MethodInvoker)delegate()
            {
              childNode.Text = item.ShortTitle;
              childNode.ToolTipText = item.ShortDescription;
            });

            if (index == -1)
            {
              this.Invoke((MethodInvoker)delegate()
              {
                node.Nodes.Add(childNode);
              });
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

    private int TreeNodeCollectionContains(TreeNodeCollection collection, string url)
    {
      int i = 0;
      foreach (TreeNode node in collection)
      {
        if (url.Equals(node.Tag))
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
      if (node == null) { btnBookmark.Image = bitmaps[2]; return; }

      TreeNode parent = node.Parent;
      if (parent == null) { btnBookmark.Image = bitmaps[2]; return; }

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
          channel = WRssObject.GetChannel(node.Tag.ToString());
          btnBookmark.Image = bitmaps[2];
        }
        else
        {
          channel = WRssObject.GetChannel(parent.Tag.ToString());
          item = WRssObject.GetItem(node.Tag.ToString());
          btnBookmark.Image = item.Favorite ? bitmaps[1] : bitmaps[2];
        }
      }
      // Node Bookmarks
      else if (parent.Text.Equals(treeView1.Nodes[2].Text))
      {
        item = WRssObject.GetItem(node.Tag.ToString());
        btnBookmark.Image = item.Favorite ? bitmaps[1] : bitmaps[2];
      }
      else
      {
        btnBookmark.Image = bitmaps[2];
      }

      if (channel != null)
      {
        rchTxtContent.AppendText(channel.Title);
        rchTxtContent.AppendText(System.Environment.NewLine);
        rchTxtContent.AppendText(channel.LastBuildDate.ToString());
        rchTxtContent.AppendText(System.Environment.NewLine);
      }

      if (item != null)
      {
        rchTxtContent.AppendText(item.Description);
        selItem = item;
      }

      if (item == null && channel != null)
      {
        if (channel.Image != null &&
            channel.Image.Image != null &&
            channel.Image.Image.Length > 0)
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
          ((treeView1.SelectedNode.Parent.Parent != null &&
            treeView1.SelectedNode.Parent.Parent.Text.Equals("Subscriptions")) ||
           (treeView1.SelectedNode.Parent.Text.Equals("Bookmarks"))))
      {
        RssItem item = WRssObject.GetItem(treeView1.SelectedNode.Tag.ToString());

        item.Favorite = !item.Favorite;
        TreeNodeCollection bookmarks = treeView1.Nodes["NodeBookmarks"].Nodes;

        if (item.Favorite)
        {
          TreeNode node = new TreeNode(item.ShortTitle);
          node.ToolTipText = item.ShortDescription;
          node.Tag = item.Link.OriginalString;
          btnBookmark.Image = bitmaps[1];
          bookmarks.Add(node);
        }
        else
        {
          btnBookmark.Image = bitmaps[2];
          int index = TreeNodeCollectionContains(bookmarks, item.Link.OriginalString);
          bookmarks.RemoveAt(index);
        }
      }
    }
      
    private void btnTag_Click(object sender, EventArgs e)
    {
      
    }

    private void btnTranslate_Click(object sender, EventArgs e)
    {
      if (cbxTranslate.SelectedItem != null &&
          !microsoftTranslateAPIKey.Equals(string.Empty) &&
          selItem != null)
      {
        string translatedText = string.Empty;

        MethodInvoker translateTextDelegate = new MethodInvoker(delegate()
          {
            Invoke((MethodInvoker)delegate()
            {
              if (!isGoogleTranslator)
              {
                translatedText = Translator.Microsoft.GetTranslationsArray(
                  microsoftTranslateAPIKey,
                  selItem.Description.Split('.'),
                  string.Empty,
                  microsoftTranslatorLangueges[cbxTranslate.SelectedItem.ToString()],
                  1);
              }
              else
              {
                translatedText = Translator.Google.TranslateText(
                  selItem.Description,
                  microsoftTranslatorLangueges[cbxTranslate.SelectedItem.ToString()]);
              }
            });
          });

        translateTextDelegate.BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar)
        {
          translateTextDelegate.EndInvoke(ar);

          if (!translatedText.Equals(string.Empty))
          {
            Invoke((MethodInvoker)delegate()
            {
              rchTxtContent.Clear();
              rchTxtContent.AppendText(translatedText);
            });
          }
        }),
          null);
      }
    }

    private void ReadMicrosoftTranslateAPIKey()
    {
      string file = Application.ExecutablePath.Substring(0,
        Application.ExecutablePath.LastIndexOf('\\') + 1) +
        microsoftTranslateAPIKeyFile;

      if (File.Exists(file))
      {
        MethodInvoker readFileDelegate = new MethodInvoker(delegate()
        {
          try
          {
            microsoftTranslateAPIKey = File.ReadAllText(file);
            string[] languageCodes = Translator.Microsoft.GetLanguagesForTranslate(
              microsoftTranslateAPIKey).Split(',');

            string[] languageNames = Translator.Microsoft.GetLanguageNames(
              microsoftTranslateAPIKey, "en", languageCodes).Split(',');

            if (languageCodes.Length == languageNames.Length)
            {
              for (int i = 0; i < languageNames.Length; ++i)
              {
                if (!microsoftTranslatorLangueges.ContainsKey(languageNames[i]))
                {
                  microsoftTranslatorLangueges.Add(languageNames[i], languageCodes[i]);
                }
              }

              cbxTranslate.Invoke((MethodInvoker)delegate()
              {
                cbxTranslate.Items.AddRange(languageNames);
              });
            }
          }
          catch { }
        });

        readFileDelegate.BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar)
        {
          readFileDelegate.EndInvoke(ar);
        }),
          null);
      }
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
      catch (Exception) { }
    }

    private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void treeVewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      treeView1.Visible = !treeView1.Visible;
      treeVewToolStripMenuItem.CheckState = treeView1.Visible ?
                                            System.Windows.Forms.CheckState.Checked :
                                            System.Windows.Forms.CheckState.Unchecked;
      splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
    }

    private void googleTranslatorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!isGoogleTranslator)
      {
        isGoogleTranslator = true;
        googleTranslatorToolStripMenuItem.Checked = true;
        microsoftTranslatorToolStripMenuItem.Checked = false;
      }
    }

    private void microsoftTranslatorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (isGoogleTranslator)
      {
        isGoogleTranslator = false;
        googleTranslatorToolStripMenuItem.Checked = false;
        microsoftTranslatorToolStripMenuItem.Checked = true;
      }
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rchTxtContent.Copy();
    }

    private void cutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rchTxtContent.Cut();
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rchTxtContent.Paste();
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rchTxtContent.SelectedText = string.Empty;
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rchTxtContent.SelectAll();
    }
  }
}