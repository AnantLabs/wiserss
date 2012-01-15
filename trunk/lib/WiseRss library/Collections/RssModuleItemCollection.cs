namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssModuleItem"/> objects</summary>
  [System.Serializable()]
  public class RssModuleItemCollection : System.Collections.ObjectModel.Collection<RssModuleItem>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssModuleItem"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssModuleItem"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssModuleItem item in this)
      {
        str.AppendLine(item.ToString());
      }

      return str.ToString();
    }
  }
}
