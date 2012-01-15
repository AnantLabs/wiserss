namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssImage"/> objects</summary>
  [System.Serializable()]
  public class RssImageCollection : System.Collections.ObjectModel.Collection<RssImage>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssImage"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssImage"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssImage image in this)
      {
        str.AppendLine(image.ToString());
      }

      return str.ToString();
    }
  }
}

