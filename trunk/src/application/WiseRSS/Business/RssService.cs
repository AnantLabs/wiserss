using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess;
using Rss;

namespace Business
{
  public class RssService
  {
    public RssChannel GetChannel(int id)
    {
      return new DataReader().GetChannel(id);
    }

    public RssChannelCollection GetChannels()
    {
      return new DataReader().GetChannels();
    }

    public RssItem GetItem(int id)
    {
      return new DataReader().GetItem(id);
    }

    public RssItemCollection GetItems(int channel_id)
    {
      return new DataReader().GetRssItems(channel_id);
    }

    public RssCategory GetCategory(int id)
    {
      return new DataReader().GetCategory(id);
    }

    public RssCategoryCollection GetCategories()
    {
      return new DataReader().GetCategories();
    }

    public RssLanguage GetLanguage(int id)
    {
      return new DataReader().GetLanguage(id);
    }

    public RssLanguageCollection GetLanguagess()
    {
      return new DataReader().GetLanguages();
    }

    public bool InsertNewItems()
    {
        
        string[] feeds = new DataReader().GetFeeds();
        foreach (string feedUrl in feeds)
        {
            int feedId = new DataReader().GetFeedId(feedUrl);
            RssFeed feed = Rss.RssFeed.Read(feedUrl); 

            foreach (Rss.RssChannel channel in feed.Channels)
            {
                
                int channelID = new DataReader().InsertRssChannel(channel, feedId);
                foreach (Rss.RssItem item in channel.Items)
                {
                    new DataReader().InsertRssItem(item, channelID);
                }
            } 
        }

        return true;
    
    }
  
  }
}
