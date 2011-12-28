using MySql.Data.MySqlClient;

namespace DataAccess
{
  partial class DBConnect
  {
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    /// <summary>
    /// Constructor
    /// </summary>
    public DBConnect()
    {
      Initialize();
    }

    /// <summary>
    /// Initialize values
    /// </summary>
    private void Initialize()
    {
      server   = "localhost";
      database = "wiserss";
      uid      = "wiserss";
      password = "wiserss";
      string connectionString;
      connectionString = "SERVER=" + server + ";" + "DATABASE=" + database +
                         ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

      connection = new MySqlConnection(connectionString);
    }

    public MySqlConnection Connection
    {
      get { return connection; }
      set { connection = value; }
    }

    // Open connection to database
    private bool OpenConnection()
    {
      try
      {
        connection.Open();
        return true;
      }
      catch (MySqlException ex)
      {
        switch (ex.Number)
        {
          case 0:
            System.Diagnostics.Debug.Write("Cannot connect to server. " +
                                           " Contact administrator");
            break;

          case 1045:
            System.Diagnostics.Debug.Write("Invalid username/password, " +
                                           "please try again");
            break;
        }
        return false;
      }
    }

    // Close connection
    public bool CloseConnection()
    {
      try
      {
        connection.Close();
        return true;
      }
      catch (MySqlException)
      {
        return false;
      }
    }
  }
}
