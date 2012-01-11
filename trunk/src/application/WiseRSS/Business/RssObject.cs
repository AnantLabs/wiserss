using DataAccess;
using Rss;

namespace Business
{
  public class RssObject
  {
    private DataReader reader = null;
    private RssChannelCollection channels = null;
    private RssCategoryCollection categories = null;
    private RssLanguageCollection languages = null;

    /// <summary>
    /// Constructor
    /// </summary>
    public RssObject()
    {
      reader = new DataReader();
      channels = reader.GetRssChannels();
      categories = reader.GetCategories();
      languages = reader.GetLanguages();
    }

    public DataReader Reader
    {
      get { return reader; }
    }

    public RssChannelCollection Channels
    {
      get { return channels; }
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
        Reader.InsertRssChannel(channel);
      }
    }

    public void InsertNewChannels()
    {
      foreach (RssChannel channel in Channels)
      {
        if (channel.ID == 0)
        {
          Reader.InsertRssChannel(channel);
        }
      }
    }

    public void InsertNewItems()
    {
      foreach (RssChannel channel in Channels)
      {
        foreach (RssItem item in channel.Items)
        {
          if (item.ID == 0)
          {
            item.ChannelID = channel.ID;
            Reader.InsertRssItem(item);
          }
        }
      }
    }
  }
}
