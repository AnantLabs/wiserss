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
      try
      {
        category.ID = Convert.ToInt64(dr["id"]);
        category.Name = Convert.ToString(dr["name"]);
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      return category;
    }

    public RssCategory GetCategory(long id)
    {
      RssCategory category = new RssCategory();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetCategory", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            category = GetCategory(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return category;
    }

    public bool DeleteCategory(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteCategory", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public long InsertCategory(RssCategory category)
    {
      long res = RssDefault.Long;

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("InsertCategory", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_name = new MySqlParameter("p_name", MySqlDbType.VarChar, 255);
          p_name.Value = category.Name;
          cmd.Parameters.Add(p_name);
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          cmd.Parameters.Add(p_id);
          cmd.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
          cmd.Connection.Open();
          cmd.ExecuteNonQuery();
          cmd.Connection.Close();

          res = category.ID = Convert.ToInt64(cmd.Parameters["p_id"].Value);
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return res;
    }

    public bool UpdateCategory(RssCategory category)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("UpdateCategory", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = category.ID;
          cmd.Parameters.Add(p_id);
          MySqlParameter p_name = new MySqlParameter("p_name", MySqlDbType.VarChar, 255);
          p_name.Value = category.Name;
          cmd.Parameters.Add(p_name);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
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
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return categories;
    }

    public RssCategoryCollection GetRssChannelCategories(long id)
    {
      RssCategoryCollection categories = new RssCategoryCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannelCategories", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            categories.Add(GetCategory(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
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
      try
      {
        language.ID = Convert.ToInt64(dr["id"]);
        language.Identifier = Convert.ToString(dr["identifier"]);
        language.Language = Convert.ToString(dr["language"]);
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      return language;
    }

    public RssLanguage GetLanguage(long id)
    {
      RssLanguage language = new RssLanguage();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetLanguage", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            language = GetLanguage(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return language;
    }

    public long GetLanguageID(string identifier)
    {
      long res = RssDefault.Long;
      RssLanguage language = new RssLanguage();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetLanguageID", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_identifier = new MySqlParameter("p_identifier", MySqlDbType.UInt32);
          p_identifier.Value = identifier;
          dataAdapter.SelectCommand.Parameters.Add(p_identifier);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            res = Convert.ToInt64(dataTable.Rows[0]["id"]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public bool DeleteLanguage(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteLanguage", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public long InsertLanguage(RssLanguage language)
    {
      long res = RssDefault.Long;

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("InsertLanguage", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_identifier = new MySqlParameter("p_identifier", MySqlDbType.VarChar, 5);
          p_identifier.Value = language.Identifier;
          cmd.Parameters.Add(p_identifier);
          MySqlParameter p_language = new MySqlParameter("p_language", MySqlDbType.VarChar, 64);
          p_language.Value = language.Language;
          cmd.Parameters.Add(p_language);
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Direction = System.Data.ParameterDirection.Output;
          cmd.Parameters.Add(p_id);

          cmd.Connection.Open();
          cmd.ExecuteNonQuery();
          cmd.Connection.Close();

          res = language.ID = Convert.ToInt64(cmd.Parameters["p_id"].Value);
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return 0;
    }

    public bool UpdateLanguage(RssLanguage language)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("UpdateLanguage", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = language.ID;
          cmd.Parameters.Add(p_id);
          MySqlParameter p_identifier = new MySqlParameter("p_identifier", MySqlDbType.VarChar, 5);
          p_identifier.Value = language.Identifier;
          cmd.Parameters.Add(p_identifier);
          MySqlParameter p_language = new MySqlParameter("p_language", MySqlDbType.VarChar, 64);
          p_language.Value = language.Language;
          cmd.Parameters.Add(p_language);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
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
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return languages;
    }

    public RssCloud GetCloud(System.Data.DataRow dr)
    {
      RssCloud cloud = new RssCloud();
      try
      {
        cloud.ID = Convert.ToInt32(dr["id"]);
        cloud.Domain = Convert.ToString(dr["domain"]);
        cloud.Port = Convert.ToInt32(dr["port"]) & ((1<<16) - 1); // & 65535
        cloud.Path = Convert.ToString(dr["path"]);
        cloud.Protocol = RssCloudProtocol.Empty + (Convert.ToInt16(dr["protocol"]) & ((1<<3) - 1));
        cloud.RegisterProcedure = Convert.ToString(dr["register_procedure"]);
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      return cloud;
    }

    public RssCloud GetCloud(long id)
    {
      RssCloud cloud = new RssCloud();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetCloud", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            cloud = GetCloud(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return cloud;
    }

    public RssCloudCollection GetClouds()
    {
      RssCloudCollection clouds = new RssCloudCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetClouds", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            clouds.Add(GetCloud(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return clouds;
    }

    public RssCloud GetCloudForChannel(long id)
    {
      RssCloud cloud = new RssCloud();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetCloudForChannel", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            cloud = GetCloud(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return cloud;
    }

    public long InsertCloud(RssCloud cloud)
    {
      long res = RssDefault.Long;

      if (!cloud.IsUsable)
      {
        return res;
      }

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("InsertCloud", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_domain",             MySqlDbType.Text,   cloud.Domain, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_port",               MySqlDbType.UInt16, (short)cloud.Port,       0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_path",               MySqlDbType.Text,   cloud.Path,   0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_register_procedure", MySqlDbType.Text,   cloud.RegisterProcedure, 0)); 
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_protocol",           MySqlDbType.Bit,    cloud.Protocol, 4));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id",                 MySqlDbType.UInt32, 0, 0));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
          cmd.Connection.Open();
          cmd.ExecuteNonQuery();
          cmd.Connection.Close();

          res = cloud.ID = Convert.ToInt64(cmd.Parameters["p_id"].Value);
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return res;
    }

    public bool UpdateCloud(RssCloud cloud)
    {
      bool res = false;

      if (!cloud.IsUsable)
      {
        return res;
      }

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("UpdateCloud", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id", MySqlDbType.Text, cloud.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_domain", MySqlDbType.Text, cloud.Domain, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_port", MySqlDbType.UInt16, (short)cloud.Port, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_path", MySqlDbType.Text, cloud.Path, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_register_procedure", MySqlDbType.Text, cloud.RegisterProcedure, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_protocol", MySqlDbType.Bit, cloud.Protocol, 4));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Connection.Open();
          cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public bool DeleteCloud(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteCloud", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }
    
    public RssTextInput GetTextInput(System.Data.DataRow dr)
    {
      RssTextInput textInput = null;

      try
      {
        int id = Convert.ToInt32(dr["id"]);
        string description = Convert.ToString(dr["description"]);
        string name = Convert.ToString(dr["name"]);
        Uri link = new Uri(Convert.ToString(dr["link"]));
        string title = Convert.ToString(dr["title"]);
        textInput = new RssTextInput(id, title, name, description, link);
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      return textInput;
    }

    public RssTextInput GetTextInput(long id)
    {
      RssTextInput textInput = null;

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetTextInput", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            textInput = GetTextInput(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return textInput;
    }

    public RssTextInputCollection GetTextInputs()
    {
      RssTextInputCollection clouds = new RssTextInputCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetTextInputs", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            clouds.Add(GetTextInput(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return clouds;
    }
    
    public RssTextInput GetRssChannelTextInput(long id)
    {
      RssTextInput textInput = new RssTextInput();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannelTextInput", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            textInput = GetTextInput(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return textInput;
    }

    public long InsertTextInput(RssTextInput textInput)
    {
      long res = RssDefault.Long;

      if (!textInput.IsUsable)
      {
        return res;
      }

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("InsertTextInput", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_description", MySqlDbType.VarChar, textInput.Description, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_name",        MySqlDbType.VarChar, textInput.Name,        255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link",        MySqlDbType.VarChar, textInput.Link,        255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title",       MySqlDbType.VarChar, textInput.Title,       255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id",          MySqlDbType.UInt32,  0,           0));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
          cmd.Connection.Open();
          cmd.ExecuteNonQuery();
          cmd.Connection.Close();

          res = textInput.ID = Convert.ToInt64(cmd.Parameters["p_id"].Value);
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return res;
    }

    public bool UpdateTextInput(RssTextInput textInput)
    {
      bool res = false;

      if (!textInput.IsUsable)
      {
        return res;
      }

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("UpdateTextInput", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();
          
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id", MySqlDbType.UInt32, 0, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_description", MySqlDbType.VarChar, textInput.Description, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_name", MySqlDbType.VarChar, textInput.Name, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link", MySqlDbType.VarChar, textInput.Link, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title", MySqlDbType.VarChar, textInput.Title, 255));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public bool DeleteTextInput(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteTextInput", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }
    
    public RssEnclosure GetEnclosure(System.Data.DataRow dr)
    {
      RssEnclosure enclosure = new RssEnclosure();
      try
      {
        enclosure.ID = Convert.ToInt64(dr["id"]);
        enclosure.Length = Convert.ToInt32(dr["length"]);
        enclosure.Type = Convert.ToString(dr["type"]);
        enclosure.Url = new Uri(Convert.ToString(dr["url"]));
        enclosure.File = new System.IO.MemoryStream((byte[])dr["file"]);
        enclosure.RssItemID = Convert.ToInt64(dr["rss_item_id"]);

        using (System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])dr["file"]))
        {
          System.Runtime.Serialization.Formatters.Binary.BinaryFormatter oBFormatter =
            new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

          if (enclosure.Type.Contains("jpeg"))
          {
            System.Drawing.Image img = (System.Drawing.Image)oBFormatter.Deserialize(ms);
            img.Save(enclosure.Url + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      return enclosure;
    }

    public RssEnclosureCollection GetEnclosures()
    {
      RssEnclosureCollection enclosures = new RssEnclosureCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetEnclosures", connection))
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
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return enclosures;
    }

    public RssEnclosure GetEnclosure(long id)
    {
      RssEnclosure enclosure = new RssEnclosure();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetEnclosure", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            enclosure = GetEnclosure(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return enclosure;
    }

    public long InsertEnclosure(RssEnclosure enclosure)
    {
      long res = RssDefault.Long;

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("InsertEnclosure", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_rss_item_id", MySqlDbType.UInt32,  enclosure.RssItemID,          0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_length",      MySqlDbType.UInt32,  enclosure.Length,             0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_type",        MySqlDbType.VarChar, enclosure.Type,               255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_url",         MySqlDbType.Text,    enclosure.Url.OriginalString, 0));
          //parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_file",        MySqlDbType.Blob,    enclosure.File.ToArray(),     0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id",          MySqlDbType.UInt32,  enclosure.ID,                 0));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
          cmd.Connection.Open();
          cmd.ExecuteNonQuery();

          res = enclosure.ID = Convert.ToInt64(cmd.Parameters["p_id"].Value);
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return res;
    }

    public bool UpdateEnclosure(RssEnclosure enclosure)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("UpdateEnclosure", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id",          MySqlDbType.UInt32,  enclosure.ID,        0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_rss_item_id", MySqlDbType.UInt32,  enclosure.RssItemID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_length",      MySqlDbType.UInt32,  enclosure.Length,    0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_type",        MySqlDbType.VarChar, enclosure.Type,      255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_url",         MySqlDbType.Text,    enclosure.Url,       0));
          //parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_file",        MySqlDbType.Blob,    enclosure.File.ToArray(),      0));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public bool DeleteEnclosure(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteEnclosure", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    private RssChannel GetRssChannel(System.Data.DataRow dr)
    {
      RssChannel channel = new RssChannel();
      channel.ID = Convert.ToInt32(dr["id"]);
      channel.Categories = GetRssChannelCategories(channel.ID);
      channel.Cloud = GetCloudForChannel(channel.ID);
      channel.Copyright = Convert.ToString(dr["copyright"]);
      channel.Description = Convert.ToString(dr["description"]);
      channel.Docs = Convert.ToString(dr["docs"]);
      channel.Generator = Convert.ToString(dr["generator"]);
      channel.Language = GetLanguage(channel.ID).Identifier;
      channel.LastBuildDate = Convert.ToDateTime(dr["last_build_date"]);
      channel.Link = new Uri(Convert.ToString(dr["link"]));
      channel.ManagingEditor = Convert.ToString(dr["managing_editor"]);
      channel.PubDate = Convert.ToDateTime(dr["publication_date"]);
      channel.Rating = Convert.ToString(dr["rating"]);
      channel.TextInput = GetRssChannelTextInput(channel.ID);
      channel.Title = Convert.ToString(dr["title"]);
      channel.TimeToLive = Convert.ToInt32(dr["ttl"]);
      channel.WebMaster = Convert.ToString(dr["webmaster"]);
      channel.Status = RssStatus.Unchanged;

      RssItemCollection items = GetRssChannelItems(channel.ID);
      foreach (RssItem item in items)
      {
        channel.Items.Add(item);
      }

      channel.Image.RssChannelID = channel.ID;
      channel.Image = GetRssChannelImage(channel.ID);

      return channel;
    }

    public RssChannel GetRssChannel(long id)
    {
      RssChannel channel = new RssChannel();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannel", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            channel = GetRssChannel(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return channel;
    }

    public RssChannelCollection GetRssChannels()
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
            channels.Add(GetRssChannel(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return channels;
    }

    public RssItemCollection GetRssChannelItems(long id)
    {
      RssItemCollection items = new RssItemCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannelItems", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_channel_id = new MySqlParameter("p_channel_id", MySqlDbType.UInt32);
          p_channel_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_channel_id);
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            items.Add(GetRssItem(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return items;
    }

    public List<string> GetRssChannelUrls()
    {
      List<string> urls = new List<string>();
      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannelUrls", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          urls.Capacity = dataTable.Rows.Count;
          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            urls.Add(dr["link"].ToString());
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return urls;
    }

    public long GetRssChannelID(string url)
    {
      long res = RssDefault.Long;

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannelID", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_link = new MySqlParameter("p_link", MySqlDbType.Text);
          p_link.Value = url;
          dataAdapter.SelectCommand.Parameters.Add(p_link);
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Direction = System.Data.ParameterDirection.Output;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            res = Int32.Parse(dataTable.Rows[0]["p_id"].ToString());
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return res;
    }

    public long InsertRssChannel(RssChannel channel, string feedUrl)
    {
      long res = RssDefault.Long;

      if (!channel.IsUsable)
      {
        return res;
      }

      RssStatus status = channel.Status;

      try
      {
        // insert cloud
        InsertCloud(channel.Cloud);

        // insert text input
        InsertTextInput(channel.TextInput);

        // insert category
        foreach (RssCategory category in channel.Categories)
        {
          InsertCategory(category);
        }

        // insert language
        RssLanguage language = new RssLanguage();
        language.Identifier = channel.Language;
        channel.LanguageID = InsertLanguage(language);

        using (MySqlCommand command = new MySqlCommand("InsertRssChannel", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_cloud_id", MySqlDbType.UInt32, channel.Cloud.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_copyright", MySqlDbType.Text, channel.Copyright, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_description", MySqlDbType.MediumText, channel.Description, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_docs", MySqlDbType.VarChar, channel.Docs, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_generator", MySqlDbType.VarChar, channel.Generator, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_language_id", MySqlDbType.UInt32, channel.LanguageID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_last_build_date", MySqlDbType.DateTime, channel.LastBuildDate, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link", MySqlDbType.Text, feedUrl, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_managing_editor", MySqlDbType.Text, channel.ManagingEditor, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_publication_date", MySqlDbType.DateTime, channel.PubDate, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_rating", MySqlDbType.VarChar, channel.Rating, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_skip_days", MySqlDbType.UInt32, channel.SkipDays.Code, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_skip_hours", MySqlDbType.UInt32, channel.SkipHours.Code, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_text_input_id", MySqlDbType.UInt32, channel.TextInput.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title", MySqlDbType.Text, channel.Title, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_ttl", MySqlDbType.UInt32, channel.TimeToLive, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_webmaster", MySqlDbType.Text, channel.WebMaster, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id", MySqlDbType.UInt32, 0, 0));

          command.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            command.Parameters.Add(parameter.Item1, parameter.Item2);
            command.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              command.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          command.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
          command.Connection.Open();
          command.ExecuteNonQuery();

          res = channel.ID = Convert.ToInt64(command.Parameters["p_id"].Value);
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      foreach (RssItem item in channel.Items)
      {
        item.ChannelID = res;
        item.Status = status;
        InsertRssItemSafe(item);
      }

      // insert rss channel image
      channel.Image.RssChannelID = channel.ID;
      channel.Image.Status = status;
      InsertRssChannelImageSafe(channel.Image);

      return res;
    }

    public bool UpdateRssChannel(RssChannel channel)
    {
      bool res = false;

      if (!channel.IsUsable)
      {
        return res;
      }

      try
      {
        RssStatus status = channel.Status;
        RssStatus imgStatus = channel.Image.Status;

        // update channel cloud ID
        channel.Cloud.ID = InsertCloud(channel.Cloud);

        // update text input ID
        channel.TextInput.ID = InsertTextInput(channel.TextInput);

        // update category
        foreach (RssCategory category in channel.Categories)
        {
          //category.ID =InsertChannelCategory(category);
        }

        // update channel language ID
        RssLanguage language = new RssLanguage();
        language.Identifier = channel.Language;
        channel.LanguageID = InsertLanguage(language);

        // update rss channel image
        channel.Image.RssChannelID = channel.ID;
        channel.Image.Status = RssStatus.Update;
        InsertRssChannelImageSafe(channel.Image);

        channel.Status = status;
        channel.Image.Status = imgStatus;

        using (MySqlCommand command = new MySqlCommand("UpdateRssChannel", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id", MySqlDbType.UInt32, channel.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_cloud_id", MySqlDbType.UInt32, channel.Cloud.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_copyright", MySqlDbType.Text, channel.Copyright, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_description", MySqlDbType.MediumText, channel.Description, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_docs", MySqlDbType.VarChar, channel.Docs, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_generator", MySqlDbType.VarChar, channel.Generator, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_language_id", MySqlDbType.UInt32, channel.LanguageID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_last_build_date", MySqlDbType.DateTime, channel.LastBuildDate, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link", MySqlDbType.Text, channel.Link.OriginalString, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_managing_editor", MySqlDbType.Text, channel.ManagingEditor, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_publication_date", MySqlDbType.DateTime, channel.PubDate, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_rating", MySqlDbType.VarChar, channel.Rating, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_skip_days", MySqlDbType.UInt32, channel.SkipDays.Code, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_skip_hours", MySqlDbType.UInt32, channel.SkipHours.Code, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_text_input_id", MySqlDbType.UInt32, channel.TextInput.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title", MySqlDbType.Text, channel.Title, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_ttl", MySqlDbType.UInt32, channel.TimeToLive, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_webmaster", MySqlDbType.Text, channel.WebMaster, 0));

          command.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            command.Parameters.Add(parameter.Item1, parameter.Item2);
            command.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              command.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          command.Connection.Open();
          res = 1 == command.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      foreach (RssItem item in channel.Items)
      {
        item.ChannelID = channel.ID;
        InsertRssItemSafe(item);
      }

      return res;
    }

    public bool DeleteRssChannel(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteRssChannel", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    private RssImage GetRssChannelImage(System.Data.DataRow dr)
    {
      RssImage image = new RssImage();
      try
      {
        image.ID = Convert.ToInt64(dr["id"]);
        image.RssChannelID = Convert.ToInt64(dr["rss_channel_id"]);
        image.Status = RssStatus.Unchanged;
        image.Url = new Uri(Convert.ToString(dr["url"]));
        image.Title = Convert.ToString(dr["title"]);
        image.Link = new Uri(Convert.ToString(dr["link"]));
        image.Path = Convert.ToString(dr["image_path"]);
        using (System.IO.FileStream fs = new System.IO.FileStream(image.Path, System.IO.FileMode.Open))
        {
          image.Image = new System.IO.MemoryStream(new System.IO.BinaryReader(fs).ReadBytes((int)fs.Length));
          fs.Close();
        }
        image.Status = RssStatus.Unchanged;
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      return image;
    }

    public RssImage GetRssChannelImage(long id)
    {
      RssImage image = new RssImage();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannelImage", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            image = GetRssChannelImage(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return image;
    }

    public bool DeleteRssChannelImage(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteRssChannelImage", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public void InsertRssChannelImageSafe(RssImage image)
    {
      image.ImageDownloadCompleted += new RssImage.ImageDownloadCompletedHandler(delegate()
      {
        lock (connection)
        {
          image.ID = InsertRssChannelImage(image);
        }
      });
    }

    public long InsertRssChannelImage(RssImage image)
    {
      long res = RssDefault.Long;

      if (!image.IsUsable)
      {
        return res;
      }

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("InsertRssChannelImage", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_rss_channel_id", MySqlDbType.UInt32, image.RssChannelID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_url", MySqlDbType.Text, image.Url.OriginalString, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title", MySqlDbType.VarChar, image.Title, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link", MySqlDbType.Text, image.Link.OriginalString, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_image_path", MySqlDbType.Text, image.Path, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id", MySqlDbType.UInt32, 0, 0));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
          cmd.Connection.Open();
          cmd.ExecuteNonQuery();

          res = image.ID = Convert.ToInt64(cmd.Parameters["p_id"].Value);
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return res;
    }

    public bool UpdateRssChannelImage(RssImage image)
    {
      bool res = false;

      if (!image.IsUsable)
      {
        return res;
      }

      try
      {
        using (MySqlCommand cmd = new MySqlCommand("UpdateRssChannelImage", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id", MySqlDbType.UInt32, image.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_rss_channel_id", MySqlDbType.UInt32, image.RssChannelID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_url", MySqlDbType.Text, image.Url.OriginalString, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title", MySqlDbType.VarChar, image.Title, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link", MySqlDbType.Text, image.Link.OriginalString, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_image_path", MySqlDbType.Blob, image.Path, 0));

          cmd.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            cmd.Parameters.Add(parameter.Item1, parameter.Item2);
            cmd.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              cmd.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

    public RssImageCollection GetRssChannelImages()
    {
      RssImageCollection images = new RssImageCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssChannelImages", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            images.Add(GetRssChannelImage(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return images;
    }
    
    private RssItem GetRssItem(System.Data.DataRow dr)
    {
      RssItem item = new RssItem();

      try
      {
        item.ID = Convert.ToInt64(dr["id"]);
        item.CategoryID = Convert.ToInt64(dr["category_id"]);
        item.ChannelID = Convert.ToInt64(dr["channel_id"]);
        item.Author = Convert.ToString(dr["author"]);
        item.Categories = GetRssItemCategories(item.ID);
        item.Comments = Convert.ToString(dr["comments"]);
        item.Description = Convert.ToString(dr["description"]);
        item.Enclosures = GetRssItemEnclosures(item.ID);
        item.Guid.Name = Convert.ToString(dr["guid"]);
        item.Status = RssStatus.Unchanged;
        item.Link = new Uri(Convert.ToString(dr["link"]));
        item.Source.Url = new Uri(Convert.ToString(dr["source"]));
        item.PubDate = Convert.ToDateTime(dr["publication_date"]);
        item.Title = Convert.ToString(dr["title"]);
        item.Favorite = Convert.ToBoolean(dr["favorite"]);
        item.Status = RssStatus.Unchanged;
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }

      return item;
    }

    public RssItem GetRssItem(long id)
    {
      RssItem item = new RssItem();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssItem", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.Int64);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          if (dataTable.Rows.Count == 1)
          {
            item = GetRssItem(dataTable.Rows[0]);
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return item;
    }

    public RssItemCollection GetRssItems(long id)
    {
      RssItemCollection items = new RssItemCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssItems", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            items.Add(GetRssItem(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return items;
    }

    public RssEnclosureCollection GetRssItemEnclosures(long id)
    {
      RssEnclosureCollection enclosures = new RssEnclosureCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssItemEnclosures", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            enclosures.Add(GetEnclosure(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return enclosures;
    }

    public RssCategoryCollection GetRssItemCategories(long id)
    {
      RssCategoryCollection categories = new RssCategoryCollection();

      try
      {
        using (System.Data.DataTable dataTable = new System.Data.DataTable())
        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("GetRssItemCategories", connection))
        {
          dataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt32);
          p_id.Value = id;
          dataAdapter.SelectCommand.Parameters.Add(p_id);
          dataAdapter.Fill(dataTable);

          foreach (System.Data.DataRow dr in dataTable.Rows)
          {
            categories.Add(GetCategory(dr));
          }
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      return categories;
    }

    public void InsertRssItemSafe(RssItem item)
    {
      item.ItemDownloadCompleted += new RssItem.ItemDownloadCompletedHandler(delegate()
      {
        lock (connection)
        {
          item.ID = InsertRssItem(item);
        }
      });
    }

    public long InsertRssItem(RssItem item)
    {
      long res = RssDefault.Long;

      try
      {
        using (MySqlCommand command = new MySqlCommand("InsertRssItem", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string,MySqlDbType,object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_channel_id",       MySqlDbType.UInt32,     item.ChannelID,   0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_author",           MySqlDbType.VarChar,    item.Author,      255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_category_id",      MySqlDbType.UInt32,     item.CategoryID,  0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_comments",         MySqlDbType.Text,       item.Comments,    0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_description",      MySqlDbType.MediumText, item.Description, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_guid",             MySqlDbType.Text,       item.Guid,        0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link",             MySqlDbType.Text,       item.Link,        0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_source",           MySqlDbType.Text,       item.Source.Url,  0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_publication_date", MySqlDbType.DateTime,   item.PubDate,     0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title",            MySqlDbType.Text,       item.Title,       0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_favorite",         MySqlDbType.Bit,        item.Favorite ? 1 : 0, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id",               MySqlDbType.UInt64,     0,                0));
          
          command.CommandType = System.Data.CommandType.StoredProcedure;

          foreach(Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            command.Parameters.Add(parameter.Item1, parameter.Item2);
            command.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              command.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          command.Parameters["p_id"].Direction = System.Data.ParameterDirection.Output;
          if (command.Connection.State != System.Data.ConnectionState.Open)
          {
            command.Connection.Open();
          }
          command.ExecuteNonQuery();

          res = Convert.ToInt64(command.Parameters["p_id"].Value); 
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      foreach (RssEnclosure enclosure in item.Enclosures)
      {
        enclosure.ID = InsertEnclosure(enclosure);
      }

      return res;
    }

    public bool UpdateRssItem(RssItem item)
    {
      bool res = false;

      try
      {
        using (MySqlCommand command = new MySqlCommand("UpdateRssItem", connection))
        {
          List<Tuple<string, MySqlDbType, object, int>> parameters = new List<Tuple<string, MySqlDbType, object, int>>();

          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_id", MySqlDbType.UInt64, item.ID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_channel_id", MySqlDbType.UInt32, item.ChannelID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_author", MySqlDbType.VarChar, item.Author, 255));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_category_id", MySqlDbType.UInt32, item.CategoryID, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_comments", MySqlDbType.Text, item.Comments, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_description", MySqlDbType.MediumText, item.Description, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_guid", MySqlDbType.Text, item.Guid, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_link", MySqlDbType.Text, item.Link, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_source", MySqlDbType.Text, item.Source.Url, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_publication_date", MySqlDbType.DateTime, item.PubDate, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_title", MySqlDbType.Text, item.Title, 0));
          parameters.Add(new Tuple<string, MySqlDbType, object, int>("p_favorite", MySqlDbType.Bit, item.Favorite ? 1 : 0, 0));

          command.CommandType = System.Data.CommandType.StoredProcedure;

          foreach (Tuple<string, MySqlDbType, object, int> parameter in parameters)
          {
            command.Parameters.Add(parameter.Item1, parameter.Item2);
            command.Parameters[parameter.Item1].Value = parameter.Item3;
            if (parameter.Item4 > 0)
            {
              command.Parameters[parameter.Item1].Size = parameter.Item4;
            }
          }
          parameters.Clear();
          command.Connection.Open();
          res = 1 == command.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }

      foreach (RssEnclosure enclosure in item.Enclosures)
      {
        UpdateEnclosure(enclosure);
      }

      return res;
    }

    public bool DeleteRssItem(long id)
    {
      bool res = false;
      try
      {
        using (MySqlCommand cmd = new MySqlCommand("DeleteRssItem", connection))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          MySqlParameter p_id = new MySqlParameter("p_id", MySqlDbType.UInt64);
          p_id.Value = id;
          cmd.Parameters.Add(p_id);
          cmd.Connection.Open();
          res = 1 == cmd.ExecuteNonQuery();
          cmd.Connection.Close();
        }
      }
      catch (Exception ex)
      {
#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true), ex.ToString()).Print();
#endif
      }
      finally
      {
        connection.Dispose();
      }
      return res;
    }

  }
}