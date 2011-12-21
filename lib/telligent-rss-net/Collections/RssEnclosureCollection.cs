namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssEnclosure"/> objects</summary>
  [System.Serializable()]
  public class RssEnclosureCollection : System.Collections.ObjectModel.Collection<RssEnclosure>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssEnclosure"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssEnclosure"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssEnclosure enclosure in this)
      {
        str.AppendLine(enclosure.ToString());
      }

      return str.ToString();
    }
  }
}
