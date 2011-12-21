using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WiseRss
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      FillTreeView();
    }

    private void FillTreeView()
    {
      #region Add Categories

      if (treeView1.Nodes.IndexOfKey("NodeCategories") < 0)
      {
        return;
      }
      TreeNodeCollection nodes = treeView1.Nodes["NodeCategories"].Nodes;

      Rss.RssCategoryCollection categories = new Business.RssService().GetCategories();
      foreach (Rss.RssCategory category in categories)
      {
        if (category.Name.Trim().Length > 0)
        {
          nodes.Add(category.Name);
        }
      }
      #endregion

      #region Add Channels

      if (treeView1.Nodes.IndexOfKey("NodeChannels") < 0)
      {
        return;
      }
      nodes = treeView1.Nodes["NodeChannels"].Nodes;
      TreeNode node = null;
      Rss.RssChannelCollection channels = new Rss.RssChannelCollection();

      string url = "http://feeds.bbci.co.uk/news/rss.xml";
      Rss.RssFeed feed = Rss.RssFeed.Read(url);

      foreach (Rss.RssChannel channel in feed.Channels)
      {
        channels.Add(channel);
      }

      url = "http://rss.cnn.com/rss/edition.rss";
      feed = Rss.RssFeed.Read(url);

      foreach (Rss.RssChannel channel in feed.Channels)
      {
        channels.Add(channel);
      }

      foreach (Rss.RssChannel channel in channels)
      {
        System.Diagnostics.Debug.WriteLine(channel.ToString());
        if (channel.Title.Trim().Length > 0)
        {
          node = new TreeNode(channel.Title);
          node.ToolTipText = channel.Description.Trim();

          new Business.RssService().InsertChannel(0, channel.Copyright, channel.Description, channel.Docs, channel.Generator, 0, channel.LastBuildDate, channel.Link.ToString(), channel.ManagingEditor, channel.PubDate, channel.Rating, channel.SkipDays.Code, channel.SkipHours.Code, 0, channel.Title, channel.TimeToLive, channel.WebMaster, channel.Favorite, channel.Count);

          TreeNode childNode = null;

          foreach (Rss.RssItem item in channel.Items)
          {
            childNode = new TreeNode(item.Title);
            childNode.ToolTipText = item.Description;
            node.Nodes.Add(childNode);
          }

          nodes.Add(node);
        }
      }

      #endregion
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      // TODO: form closing event
    }
  }
}
