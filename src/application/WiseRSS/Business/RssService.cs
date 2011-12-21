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

    public RssItemCollection GetItems()
    {
      return new DataReader().GetItems();
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

    public int InsertChannel(
      int p_cloud_id,
      string p_copyright,
      string p_description,
      string p_docs,
      string p_generator,
      int p_language_id,
      DateTime p_last_build_date,
      string p_link,
      string p_managing_editor,
      DateTime p_publication_date,
      string p_rating,
      int p_skip_days,
      int p_skip_hours,
      int p_text_input_id,
      string p_title,
      int p_ttl,
      string p_webmaster,
      bool p_favorite,
      int p_count
      )
    {
      return new DataReader().InsertChannel(
       p_cloud_id,
       p_copyright,
       p_description,
       p_docs,
       p_generator,
       p_language_id,
       p_last_build_date,
       p_link,
       p_managing_editor,
       p_publication_date,
       p_rating,
       p_skip_days,
       p_skip_hours,
       p_text_input_id,
       p_title,
       p_ttl,
       p_webmaster,
       p_favorite,
       p_count
      );
    }
  }
}
