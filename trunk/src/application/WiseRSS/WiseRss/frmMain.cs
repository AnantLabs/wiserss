using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Business;
using Rss;

namespace WiseRss
{
  public partial class frmMain : Form
  {
    private RssObject wRssObject = new RssObject();
    private List<string> lstNewFeeds = new List<string>();

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
        }
        else
        {
          rchTxtContent.AppendText(channel.Description);
        }
      }
    }
  }
}