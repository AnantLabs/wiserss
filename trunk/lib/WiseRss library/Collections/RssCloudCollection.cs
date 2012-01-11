namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssCloud"/> objects</summary>
  /// [System.Serializable()]
  public class RssCloudCollection : System.Collections.ObjectModel.Collection<RssCloud>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssCloud"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssCloud"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssCloud cloud in this)
      {
        str.AppendLine(cloud.ToString());
      }

      return str.ToString();
    }
  }
}
