namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssCategory"/> objects</summary>
  [System.Serializable()]
  public class RssCategoryCollection : System.Collections.ObjectModel.Collection<RssCategory>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssCategory"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssCategory"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();
      
      foreach (RssCategory category in this)
      {
        str.AppendLine(category.ToString());
      }

      return str.ToString();
    }
  }
}
