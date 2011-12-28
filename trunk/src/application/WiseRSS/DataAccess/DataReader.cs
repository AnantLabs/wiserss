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
            //channel.Cloud.Domain = Convert.ToString(dr["cloud_domain"]);
            //channel.Cloud.Path = Convert.ToString(dr["cloud_path"]);
            //channel.Cloud.Port = Convert.ToInt32(dr["cloud_port"]);
            //channel.Cloud.Protocol = RssCloudProtocol.Empty + (Convert.ToInt16(dr["cloud_protocol"]) & ((1 << 4) - 1)); // <== (2^4)-1
            //channel.Cloud.RegisterProcedure = Convert.ToString(dr["cloud_register_procedure"]);
            channel.Copyright = Convert.ToString(dr["copyright"]);
            channel.Description = Convert.ToString(dr["description"]);
            channel.Docs = Convert.ToString(dr["docs"]);
            channel.Generator = Convert.ToString(dr["generator"]);
            //channel.Language = Convert.ToString(dr["language"]);
            channel.LastBuildDate = Convert.ToDateTime(dr["last_build_date"]);
            channel.Link = new Uri(Convert.ToString(dr["link"]));
            channel.ManagingEditor = Convert.ToString(dr["managing_editor"]);
            channel.PubDate = Convert.ToDateTime(dr["publication_date"]);
            channel.Rating = Convert.ToString(dr["rating"]);
            //channel.TextInput.Description = Convert.ToString(dr["text_input_description"]);
            //channel.TextInput.Link = new Uri(Convert.ToString(dr["text_input_link"]));
            //channel.TextInput.Name = Convert.ToString(dr["text_input_name"]);
            //channel.TextInput.Title = Convert.ToString(dr["text_input_title"]);
            channel.Title = Convert.ToString(dr["title"]);
            channel.TimeToLive = Convert.ToInt32(dr["ttl"]);
            channel.WebMaster = Convert.ToString(dr["webmaster"]);
            channel.Favorite = Convert.ToBoolean(dr["favorite"]);
            channel.Count = Convert.ToInt16(dr["count"]);
            
            RssItemCollection itmcol = GetRssItems(Convert.ToInt32(dr["id"]));
            foreach (RssItem item in itmcol)
            {
                channel.Items.Add(item);
            }
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
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannels", connection))
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
            //item.Categories = GetCategoriesForItem(Convert.ToInt32(dr["id"]));
            item.Comments = Convert.ToString(dr["comments"]);
            item.Description = Convert.ToString(dr["description"]);
            //item.Enclosures = GetEclosuresForItem(Convert.ToInt32(dr["id"]));
            item.Guid.Name = Convert.ToString(dr["guid"]);
            item.Link = new Uri(Convert.ToString(dr["link"]));
          //  item.Source.Url = new Uri(Convert.ToString(dr["source"]));
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

        public RssItemCollection GetRssItems(int channel_id)
        {
            RssItemCollection items = new RssItemCollection();

            try
            {
                using (System.Data.DataTable dataTable = new System.Data.DataTable())
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssItems", connection))
                {
                    dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("p_channel_id", channel_id));
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

        public int InsertRssChannel(RssChannel channel, int feedID)
        {
            int nRow = 0;

            try
            {
                using (MySqlCommand command = new MySqlCommand("InsertChannel", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new MySqlParameter("p_feed_id", feedID));
                    command.Parameters.Add(new MySqlParameter("p_cloud_id", ""));
                    command.Parameters.Add(new MySqlParameter("p_copyright", channel.Copyright));
                    command.Parameters.Add(new MySqlParameter("p_description", channel.Description));
                    command.Parameters.Add(new MySqlParameter("p_docs", channel.Docs));
                    command.Parameters.Add(new MySqlParameter("p_generator", channel.Generator));
                    command.Parameters.Add(new MySqlParameter("p_language_id", channel.Language));
                    command.Parameters.Add(new MySqlParameter("p_last_build_date", channel.LastBuildDate));
                    command.Parameters.Add(new MySqlParameter("p_link", channel.Link));
                    command.Parameters.Add(new MySqlParameter("p_managing_editor", channel.ManagingEditor));
                    command.Parameters.Add(new MySqlParameter("p_publication_date", channel.PubDate));
                    command.Parameters.Add(new MySqlParameter("p_rating", channel.Rating));
                    command.Parameters.Add(new MySqlParameter("p_skip_days", channel.SkipDays));
                    command.Parameters.Add(new MySqlParameter("p_skip_hours", channel.SkipHours));
                    command.Parameters.Add(new MySqlParameter("p_text_input_id", ""));
                    command.Parameters.Add(new MySqlParameter("p_title", channel.Title));
                    command.Parameters.Add(new MySqlParameter("p_ttl", channel.TimeToLive));
                    command.Parameters.Add(new MySqlParameter("p_webmaster", channel.WebMaster));
                    command.Parameters.Add(new MySqlParameter("p_favorite", channel.Favorite));
                    command.Parameters.Add(new MySqlParameter("p_count", channel.Count));
                    command.Parameters.Add("p_id", MySqlDbType.Int32);
                    command.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
                    command.Connection.Open();
                    nRow = command.ExecuteNonQuery();

                    int outputParameter = (int)command.Parameters["p_id"].Value;

                    return outputParameter;
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
            return -1;
        }

        public int InsertRssItem(RssItem item, int channelID)
        {
            int nRow = 0;

            try
            {
                using (MySqlCommand command = new MySqlCommand("InsertRssItem", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.Add(new MySqlParameter("id", p_cloud_id));
                    command.Parameters.Add(new MySqlParameter("p_channel_id", channelID));
                    command.Parameters.Add(new MySqlParameter("p_category_id", 0));
                    command.Parameters.Add(new MySqlParameter("p_comments", item.Comments));
                    command.Parameters.Add(new MySqlParameter("p_description", item.Description));
                    command.Parameters.Add(new MySqlParameter("p_enclosure_id", 0));
                    command.Parameters.Add(new MySqlParameter("p_guid", item.Guid));
                    command.Parameters.Add(new MySqlParameter("p_link", item.Link));
                    command.Parameters.Add(new MySqlParameter("p_source", item.Source));
                    command.Parameters.Add(new MySqlParameter("p_publication_date", item.PubDate));
                    command.Parameters.Add(new MySqlParameter("p_title", item.Title));
                    command.Parameters.Add(new MySqlParameter("p_author", item.Author));
                    

                    command.Connection.Open();
                    nRow = command.ExecuteNonQuery();
                    //int outputParameter = (int)command.Parameters["p_id"].Value;
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

        public int InsertRssFed(RssFeed feed)
        {
            int nRow = 0;

            try
            {
                using (MySqlCommand command = new MySqlCommand("InsertIRssFeed", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new MySqlParameter("url", feed.Url));

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

        public string[] GetFeeds()
        {
            string[] res = null;
            try
            {
                using (System.Data.DataTable dataTable = new System.Data.DataTable())
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetFeeds", connection))
                {
                    dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    dataAdapter.Fill(dataTable);

                    res = new string[dataTable.Rows.Count];
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        System.Data.DataRow dr = dataTable.Rows[i];
                        res[i] = dr["url"].ToString();
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

            return res;
        }

        public int GetFeedId(string url)
        {
            int res = -1;
            try
            {
                using (System.Data.DataTable dataTable = new System.Data.DataTable())
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetFeedId", connection))
                {
                    dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("p_url", url));
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 1)
                    {
                        res = Int32.Parse(dataTable.Rows[0]["feed_id"].ToString());
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

            return res;
        }
    }
}