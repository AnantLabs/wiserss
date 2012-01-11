namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssModuleItemCollection"/> objects</summary>
  public class RssModuleItemCollectionCollection : System.Collections.ObjectModel.Collection<RssModuleItemCollection>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssModuleItemCollection"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssModuleItemCollection"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssModuleItemCollection item in this)
      {
        str.AppendLine(item.ToString());
      }

      return str.ToString();
    }
  }
}
