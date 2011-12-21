using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Rss;

namespace DataAccess
{
  public class DataReader
  {
    private DBConnect connect = null;
    private MySqlConnection connection = null;

    public DataReader()
    {
      connect = new DBConnect();
      connection = connect.Connection;
    }

    private RssCategory GetCategory(System.Data.DataRow dr)
    {
      RssCategory category = new RssCategory();
      category.Name = Convert.ToString(dr["name"]);
      return category;
    }

    public RssCategory GetCategory(int id)
    {
      RssCategory category = new RssCategory();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetCategory", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("id", id));
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            category = GetCategory(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return category;
    }

    public RssCategoryCollection GetCategories()
    {
      RssCategoryCollection categories = new RssCategoryCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetCategories", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            categories.Add(GetCategory(dr));
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return categories;
    }

    public RssCategoryCollection GetCategoriesForChannel(int id)
    {
      RssCategoryCollection categories = new RssCategoryCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetCategoriesForChannel", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("id", id));
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            categories.Add(GetCategory(dr));
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return categories;
    }

    public RssLanguage GetLanguage(System.Data.DataRow dr)
    {
      RssLanguage language = new RssLanguage();
      language.Identifier = Convert.ToString(dr["identifier"]);
      language.Language = Convert.ToString(dr["language"]);
      return language;
    }

    public RssLanguage GetLanguage(int id)
    {
      RssLanguage language = new RssLanguage();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetLanguage", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("id", id));
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            language = GetLanguage(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }
      return language;
    }

    public RssLanguageCollection GetLanguages()
    {
      RssLanguageCollection languages = new RssLanguageCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetLanguages", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            languages.Add(GetLanguage(dr));
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return languages;
    }

    private RssChannel GetChannel(System.Data.DataRow dr)
    {
      RssChannel channel = new RssChannel();
      channel.Categories = GetCategoriesForChannel(Convert.ToInt32(dr["id"]));
      channel.Cloud.Domain = Convert.ToString(dr["cloud_domain"]);
      channel.Cloud.Path = Convert.ToString(dr["cloud_path"]);
      channel.Cloud.Port = Convert.ToInt32(dr["cloud_port"]);
      channel.Cloud.Protocol = RssCloudProtocol.Empty + (Convert.ToInt16(dr["cloud_protocol"]) & ((1 << 4) - 1)); // <== (2^4)-1
      channel.Cloud.RegisterProcedure = Convert.ToString(dr["cloud_register_procedure"]);
      channel.Copyright = Convert.ToString(dr["copyright"]);
      channel.Description = Convert.ToString(dr["description"]);
      channel.Docs = Convert.ToString(dr["docs"]);
      channel.Generator = Convert.ToString(dr["generator"]);
      channel.Language = Convert.ToString(dr["language"]);
      channel.LastBuildDate = Convert.ToDateTime(dr["last_build_date"]);
      channel.Link = new Uri(Convert.ToString(dr["link"]));
      channel.ManagingEditor = Convert.ToString(dr["managing_editor"]);
      channel.PubDate = Convert.ToDateTime(dr["publication_date"]);
      channel.Rating = Convert.ToString(dr["rating"]);
      channel.TextInput.Description = Convert.ToString(dr["text_input_description"]);
      channel.TextInput.Link = new Uri(Convert.ToString(dr["text_input_link"]));
      channel.TextInput.Name = Convert.ToString(dr["text_input_name"]);
      channel.TextInput.Title = Convert.ToString(dr["text_input_title"]);
      channel.Title = Convert.ToString(dr["title"]);
      channel.TimeToLive = Convert.ToInt32(dr["ttl"]);
      channel.WebMaster = Convert.ToString(dr["webmaster"]);
      channel.Favorite = Convert.ToBoolean(dr["favorite"]);
      channel.Count = Convert.ToInt16(dr["count"]);
      return channel;
    }

    public RssChannel GetChannel(int id)
    {
      RssChannel channel = new RssChannel();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetChannel", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("id", id));
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            channel = GetChannel(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }
      return channel;
    }

    public RssChannelCollection GetChannels()
    {
      RssChannelCollection channels = new RssChannelCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetChannels", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            channels.Add(GetChannel(dr));
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }
      return channels;
    }

    public RssEnclosure GetEnclosure(System.Data.DataRow dr)
    {
      RssEnclosure enclosure = new RssEnclosure();
      enclosure.Length = Convert.ToInt32(dr["length"]);
      enclosure.Type = Convert.ToString(dr["type"]);
      enclosure.Url = new Uri(Convert.ToString(dr["url"]));
      //enclosure.File = Convert.ToInt32(dr["file"]);
      using (System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])dr["file"]))
      {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter oBFormatter =
          new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        System.Drawing.Image img = (System.Drawing.Image)oBFormatter.Deserialize(ms);
        img.Save(enclosure.Url + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
      }
      return enclosure;
    }

    public RssEnclosureCollection GetEclosuresForItem(int id)
    {
      RssEnclosureCollection enclosures = new RssEnclosureCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetEclosuresForItem", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            enclosures.Add(GetEnclosure(dr));
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return enclosures;
    }

    public RssCategoryCollection GetCategoriesForItem(int id)
    {
      RssCategoryCollection categories = new RssCategoryCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetCategoriesForItem", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("id", id));
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            categories.Add(GetCategory(dr));
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return categories;
    }

    private RssItem GetItem(System.Data.DataRow dr)
    {
      RssItem item = new RssItem();
      
      item.Author = Convert.ToString(dr["author"]);
      item.Categories = GetCategoriesForItem(Convert.ToInt32(dr["id"]));
      item.Comments = Convert.ToString(dr["comments"]);
      item.Description = Convert.ToString(dr["description"]);
      item.Enclosures = GetEclosuresForItem(Convert.ToInt32(dr["id"]));
      item.Guid.Name = Convert.ToString(dr["guid"]);
      item.Link = new Uri(Convert.ToString(dr["link"]));
      item.Source.Url = new Uri(Convert.ToString(dr["source"]));
      item.PubDate = Convert.ToDateTime(dr["publication_date"]);
      item.Title = Convert.ToString(dr["title"]);

      return item;
    }

    public RssItem GetItem(int id)
    {
      RssItem item = new RssItem();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetItem", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("id", id));
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            item = GetItem(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return item;
    }

    public RssItemCollection GetItems()
    {
      RssItemCollection items = new RssItemCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetItems", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            items.Add(GetItem(dr));
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }

      return items;
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
      int nRow = 0;

      try
      {
        using (MySqlCommand command = new MySqlCommand("InsertChannel", connection))
        {
          command.CommandType = System.Data.CommandType.StoredProcedure;
          command.Parameters.Add(new MySqlParameter("p_cloud_id", p_cloud_id));
          command.Parameters.Add(new MySqlParameter("p_copyright", p_copyright));
          command.Parameters.Add(new MySqlParameter("p_description", p_description));
          command.Parameters.Add(new MySqlParameter("p_docs", p_docs));
          command.Parameters.Add(new MySqlParameter("p_generator", p_generator));
          command.Parameters.Add(new MySqlParameter("p_language_id", p_language_id));
          command.Parameters.Add(new MySqlParameter("p_last_build_date", p_last_build_date));
          command.Parameters.Add(new MySqlParameter("p_link", p_link));
          command.Parameters.Add(new MySqlParameter("p_managing_editor", p_managing_editor));
          command.Parameters.Add(new MySqlParameter("p_publication_date", p_publication_date));
          command.Parameters.Add(new MySqlParameter("p_rating", p_rating));
          command.Parameters.Add(new MySqlParameter("p_skip_days", p_skip_days));
          command.Parameters.Add(new MySqlParameter("p_skip_hours", p_skip_hours));
          command.Parameters.Add(new MySqlParameter("p_text_input_id", p_text_input_id));
          command.Parameters.Add(new MySqlParameter("p_title", p_title));
          command.Parameters.Add(new MySqlParameter("p_ttl", p_ttl));
          command.Parameters.Add(new MySqlParameter("p_webmaster", p_webmaster));
          command.Parameters.Add(new MySqlParameter("p_favorite", p_favorite));
          command.Parameters.Add(new MySqlParameter("p_count", p_count));

          command.Connection.Open();
          nRow = command.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      finally
      {
        connection.Dispose();
      }
      return nRow;
    }
  }
}