using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Rss;
using Business;

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

      RssChannelCollection channels = new RssService().GetChannels();

      foreach (Rss.RssChannel channel in channels)
      {
        System.Diagnostics.Debug.WriteLine(channel.ToString());
        if (channel.Title.Trim().Length > 0)
        {
          node = new TreeNode(channel.Title);
          node.ToolTipText = channel.Description.Trim();

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

    private void simpleButton1_Click(object sender, EventArgs e)
    {
        new RssService().InsertNewItems();
    }



  }
}
