namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssFeed"/> objects</summary>
  [System.Serializable()]
  public class RssFeedCollection : System.Collections.ObjectModel.Collection<RssFeed>
  {
    /// <summary>Gets or sets the feed with the given name.<para>In C#, this property is the indexer for the class.</para></summary>
    /// <param name="url">The url of the feed to access.</param>
    /// <value>A feed at each valid url. If the feed does not exist, null.</value>
    /// <remarks>This method is an indexer that can be used to access the collection.</remarks>
    public RssFeed this[string url]
    {
      get
      {
        foreach (RssFeed feed in this)
        {
          if (feed.Url == url)
          {
            return feed;
          }
        }
        return null;
      }
    }

    /// <summary>Returns a System.String that represents the collection of <see cref="RssFeed"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssFeed"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssFeed feed in this)
      {
        str.AppendLine(feed.ToString());
      }

      return str.ToString();
    }
  }
}
