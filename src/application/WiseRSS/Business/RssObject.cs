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
      InsertNewItems();
      categories = reader.GetCategories();
      languages = reader.GetLanguages();
      dictChannels = new System.Collections.Generic.Dictionary<string, RssChannel>();
      dictItems = new System.Collections.Generic.Dictionary<string, RssItem>();

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

    public RssChannel GetChannel(string channelName)
    {
      if (dictChannels.ContainsKey(channelName))
      {
        return dictChannels[channelName];
      }
      return null;
    }

    private bool AddChannel(RssChannel channel)
    {
      string shortTitle = channel.Title.Substring(0,
          System.Math.Min(channel.Title.Length, 99));

      if (!dictChannels.ContainsKey(shortTitle))
      {
        dictChannels.Add(shortTitle, channel);
        channels.Add(channel);

        foreach (RssItem item in channel.Items)
        {
            try
            {
                string itemName = shortTitle + item.Title.Substring(0, System.Math.Min(item.Title.Length, 99));
                if (!dictItems.ContainsKey(itemName))
                {
                    dictItems.Add(itemName, item);
                }
            }
            catch (System.Exception)
            {
                
            }

        }
        return true;
      }
      return false;
    }

    public RssItem GetItem(string itemName)
    {
      if (dictItems.ContainsKey(itemName))
      {
        return dictItems[itemName];
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

    public RssLanguageCollection GetLanguagess()
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

    //public void InsertNewItems()
    //{
    //  foreach (RssChannel channel in Channels)
    //  {
    //    if (channel.Status != RssStatus.Unchanged)
    //    {
    //      Reader.UpdateRssChannel(channel);
    //      foreach (RssItem item in channel.Items)
    //      {
    //        if (item.Status != RssStatus.Unchanged)
    //        {
    //          item.ChannelID = channel.ID;
    //          Reader.InsertRssItem(item);
    //        }
    //      }
    //    }
    //  }
    //}

    public void InsertNewItems()
    {
        foreach (RssChannel channel in GetChannels())
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
                        Reader.UpdateRssChannel(channel);
                        foreach (RssItem item in channel1.Items)
                        {
                            if (item.Status != RssStatus.Unchanged)
                            {
                                item.Status = RssStatus.Update;
                                item.ChannelID = channel.ID;
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
