using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using CsharpTwitt;
using Business;
using Rss;
using System.Net;

using System.Xml;
using LinqToTwitter;
using System.Dynamic;
using System.Net.Mail;

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
    private FacebookClient fb;

    private frmEmail frmMail = new frmEmail();

    private RssItem selItem = null;

    public frmMain()
    {
      InitializeComponent();

      LoadTreeView();
    }

    public RssObject WRssObject
    {
      get { return wRssObject; }
    }

    public List<string> LstNewFeeds
    {
      get { return lstNewFeeds; }
    }

    private void LoadTreeView()
    {
      if (treeView1.Nodes.IndexOfKey("NodeTags") < 0)
      {
        return;
      }

      TreeNodeCollection nodes = treeView1.Nodes["NodeTags"].Nodes;
      foreach (RssCategory category in WRssObject.Categories)
      {
        if (category.Name.Trim().Length > 0)
        {
          nodes.Add(category.Name);
        }
      }

      if (treeView1.Nodes.IndexOfKey("NodeSubscriptions") < 0)
      {
        return;
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

      foreach (RssChannel channel in WRssObject.Channels)
      {
        System.Diagnostics.Debug.WriteLine(channel.ToString());
        if (channel.Title.Trim().Length > 0)
        {
          node = new TreeNode(channel.Title);
          node.ToolTipText = channel.Description.Trim();

          TreeNode childNode = null;

          foreach (RssItem item in channel.Items)
          {
            childNode = new TreeNode(item.Title);
            childNode.ToolTipText = item.Description;
            node.Nodes.Add(childNode);
          }

          nodes.Add(node);
        }
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      LstNewFeeds.Clear();
      WRssObject.InsertNewChannels();
      WRssObject.InsertNewItems();
    }

    private void LoadRichTextBoxIcons()
    {
      Bitmap[] bitmaps = new Bitmap[] {
          Properties.Resources.mail_icon,
          Properties.Resources.bookmarks_icon,
          Properties.Resources.facebook_icon,
          Properties.Resources.twitter_icon };

      DataFormats.Format bmpFormat = DataFormats.GetFormat(DataFormats.Bitmap);

      foreach (Bitmap bmp in bitmaps)
      {
        Clipboard.SetDataObject(bmp);

        if (rchTxtContent.CanPaste(bmpFormat))
        {
          rchTxtContent.Paste(bmpFormat);
        }
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
        }

        if (feed == null)
        {
          return;
        }

        foreach (RssChannel channel in feed.Channels)
        {
          wRssObject.Channels.Add(channel);

          TreeNodeCollection nodeCategories = treeView1.Nodes["NodeTags"].Nodes;

          foreach (RssCategory category in channel.Categories)
          {
            if (category.Name.Trim().Length > 0 &&
                TreeNodeCollectionContains(nodeCategories, category.Name) == 0)
            {
              nodeCategories.Add(category.Name);
            }
          }

          if (channel.Title.Trim().Length > 0)
          {
            TreeNode node = null;
            bool newFeed = false;
            int index = TreeNodeCollectionContains(nodeFeed, channel.Title);

            if (index > 0)
            {
              node = nodeFeed[index];
            }
            else
            {
              newFeed = true;
              node = new TreeNode(channel.Title);
              node.ToolTipText = channel.Description.Trim();
            }

            TreeNode childNode = null;

            foreach (RssItem item in channel.Items)
            {
              index = TreeNodeCollectionContains(node.Nodes, item.Title);

              if (index > 0)
              {
                childNode = node.Nodes[index];
                childNode.ToolTipText = item.Description;
              }
              else
              {
                childNode = new TreeNode(item.Title);
                childNode.ToolTipText = item.Description;
                node.Nodes.Add(childNode);
              }
            }

            if (newFeed)
            {
              nodeFeed.Add(node);
            }
          }

          // insert new channel
          WRssObject.Channels.Add(channel);
          WRssObject.InsertNewChannels();
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
      return 0;
    }

    private void newFeedToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (frmAddNewFeeds frmFeed = new frmAddNewFeeds(this))
      {
        frmFeed.ShowDialog(this);
      }

      AddNewFeeds();

      return;
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
      TreeNode node = e.Node;

      if (node == null)
      {
        return;
      }

      TreeNode parent = node.Parent;

      if (parent == null)
      {
        return;
      }

      rchTxtContent.Clear();
      RssChannel channel = null;
      RssItem item = null;

      foreach (RssChannel rc in WRssObject.Channels)
      {
        if (rc.Title.Equals(node.Text) &&
            rc.Description.Equals(node.ToolTipText))
        {
          channel = rc;
          break;
        }
      }

      if (channel == null)
      {
        foreach (RssChannel rc in WRssObject.Channels)
        {
          if (rc.Title.Equals(parent.Text) && rc.Description.Equals(parent.ToolTipText))
          {
            foreach (RssItem ri in rc.Items)
            {
              if (ri.Title.Equals(node.Text) &&
                  ri.Description.Equals(node.ToolTipText))
              {
                channel = rc;
                item = ri;
                break;
              }
            }
          }
        }
      }

      if (channel != null)
      {
        if (item != null)
        {
          LoadRichTextBoxIcons();
          rchTxtContent.AppendText(System.Environment.NewLine);
        }

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
          rchTxtContent.AppendText(channel.Description);
        }
      }
    }

    

    private void btnMail_Click(object sender, EventArgs e)
    {
        frmMail.setParams(selItem.Title, selItem.Link.AbsoluteUri);
        frmMail.ShowDialog();
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
        if (fb != null)
        {
            dynamic parameters = new ExpandoObject();
            parameters.message = "twstdfsgsdfg"; // selItem.Title;
           // parameters.link = selItem.Link.AbsoluteUri;

            fb.PostAsync("me/feed", parameters);
           
        }
        else
        {
            // for some reason we failed to get the access token.
            // most likely the user clicked don't allow.
            MessageBox.Show(fbLoginDlg.FacebookOAuthResult.ErrorDescription);
        }

    }


  }
}