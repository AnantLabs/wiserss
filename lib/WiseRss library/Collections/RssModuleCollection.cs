namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssModule"/> objects</summary>
  [System.Serializable()]
  public class RssModuleCollection : System.Collections.ObjectModel.Collection<RssModule>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssModule"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssModule"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();
      
      foreach (RssModule module in this)
      {
        str.AppendLine(module.ToString());
      }

      return str.ToString();
    }
  }
}
