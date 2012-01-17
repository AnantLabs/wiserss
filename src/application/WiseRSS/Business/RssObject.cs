using DataAccess;
using Rss;
using System;

namespace Business
{
  public class RssObject
  {
    private DataReader reader = null;
    private System.Collections.Generic.Dictionary<string, RssChannel> dictChannels = null;
    private System.Collections.Generic.Dictionary<string, RssItem> dictItems = null;
    private System.Collections.Generic.Dictionary<string, System.Windows.Forms.TreeNode> dictCategories = null;
    private RssChannelCollection channels = null;
    private RssCategoryCollection categories = null;
    private RssLanguageCollection languages = null;

    /// <summary>
    /// Constructor
    /// </summary>
    public RssObject()
    {
      reader = new DataReader();
      channels = new RssChannelCollection();
      categories = reader.GetCategories();
      languages = reader.GetLanguages();
      dictChannels = new System.Collections.Generic.Dictionary<string, RssChannel>();
      dictItems = new System.Collections.Generic.Dictionary<string, RssItem>();
      dictCategories = new System.Collections.Generic.Dictionary<string, System.Windows.Forms.TreeNode>();

      // add references to dictionary
      foreach (RssChannel channel in reader.GetRssChannels())
      {
        AddChannel(channel);
      }
    }

    public DataReader Reader
    {
      get { return reader; }
    }

    public RssChannelCollection Channels
    {
      get { return channels; }
    }

    public RssChannel GetChannel(string channelUrl)
    {
      if (dictChannels.ContainsKey(channelUrl))
      {
        return dictChannels[channelUrl];
      }
      return null;
    }

    public bool AddCategoryNode(System.Windows.Forms.TreeNode node)
    {
      if (!dictCategories.ContainsKey(node.Text))
      {
        dictCategories.Add(node.Text, node);
        return true;
      }
      return false;
    }

    private bool AddChannel(RssChannel channel)
    {
      if (!dictChannels.ContainsKey(channel.Link.OriginalString))
      {
        dictChannels.Add(channel.Link.OriginalString, channel);
        channels.Add(channel);

        foreach (RssItem item in channel.Items)
        {
          if (!dictItems.ContainsKey(item.Link.OriginalString))
          {
            dictItems.Add(item.Link.OriginalString, item);
          }
        }
        return true;
      }
      return false;
    }

    public System.Windows.Forms.TreeNode GetCategoryNode(string name)
    {
      if (dictCategories.ContainsKey(name))
      {
        return dictCategories[name];
      }
      return null;
    }

    public RssItem GetItem(string url)
    {
      if (dictItems.ContainsKey(url))
      {
        return dictItems[url];
      }
      return null;
    }

    public RssCategoryCollection Categories
    {
      get { return categories; }
    }

    public RssLanguageCollection Languages
    {
      get { return languages; }
    }

    public RssChannel GetChannel(int id)
    {
      return Reader.GetRssChannel(id);
    }

    public RssChannelCollection GetChannels()
    {
      return Reader.GetRssChannels();
    }

    public RssItem GetItem(int id)
    {
      return Reader.GetRssItem(id);
    }

    public RssItemCollection GetItems(int channel_id)
    {
      return Reader.GetRssChannelItems(channel_id);
    }

    public RssCategory GetCategory(int id)
    {
      return Reader.GetCategory(id);
    }

    public RssCategoryCollection GetCategories()
    {
      return Reader.GetCategories();
    }

    public RssLanguage GetLanguage(int id)
    {
      return Reader.GetLanguage(id);
    }

    public RssLanguageCollection GetLanguages()
    {
      return Reader.GetLanguages();
    }

    public void InsertFeed(RssFeed feed)
    {
      foreach (RssChannel channel in feed.Channels)
      {
        Reader.InsertRssChannel(channel, feed.Url);
      }
    }

    public void InsertNewChannel(RssChannel channel, string feedUrl)
    {
      bool res = AddChannel(channel);

      if (res && (channel.Status != RssStatus.Unchanged))
      {
        Reader.InsertRssChannel(channel, feedUrl);
      }
    }

    //public void InsertNewChannels()
    //{
    //  foreach (RssChannel channel in Channels)
    //  {
    //    if (channel.Status != RssStatus.Unchanged)
    //    {
    //      Reader.InsertRssChannel(channel);
    //    }
    //  }
    //}

    public void SaveChanges()
    {
      foreach (RssChannel channel in Channels)
      {
        if (channel.Status != RssStatus.Unchanged)
        {
          Reader.UpdateRssChannel(channel);
          foreach (RssItem item in channel.Items)
          {
            if (item.Status != RssStatus.Unchanged)
            {
              Reader.UpdateRssItem(item);
            }
          }
        }
      }
    }

    public void InsertNewItems()
    {
      foreach (RssChannel channel in Channels)
      {
        RssFeed feed = null;

        try
        {
          feed = RssFeed.Read(channel.Link.OriginalString);

          foreach (RssChannel channel1 in feed.Channels)
          {
            if (channel.Status != RssStatus.Unchanged)
            {
              channel.Status = RssStatus.Update;
              channel.Image.Status = RssStatus.Update;
              Reader.UpdateRssChannel(channel1);

              foreach (RssItem item in channel1.Items)
              {
                if (item.Status != RssStatus.Unchanged)
                {
                  item.ChannelID = channel.ID;
                  item.Status = RssStatus.Update;
                  Reader.InsertRssItem(item);
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
#if DEBUG
          new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
          return;
        }

      }
    }
  }
}
