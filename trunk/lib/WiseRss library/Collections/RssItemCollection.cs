namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssItem"/> objects</summary>
  [System.Serializable()]
  public class RssItemCollection : System.Collections.ObjectModel.Collection<RssItem>
  {
    private System.DateTime latestPubDate = RssDefault.DateTime;
    private System.DateTime oldestPubDate = RssDefault.DateTime;
    private bool pubDateChanged = true;

    /// <summary>Gets or sets the item at a specified index.<para>In C#, this property is the indexer for the class.</para></summary>
    /// <param name="index">The index of the collection to access.</param>
    /// <value>An item at each valid index.</value>
    /// <remarks>This method is an indexer that can be used to access the collection.</remarks>
    public new RssItem this[int index]
    {
      get { return base[index]; }
      set
      {
        pubDateChanged = true;
        base[index] = value;
      }
    }

    /// <summary>Adds a specified item to this collection.</summary>
    /// <param name="item">The item to add.</param>
    /// <returns>The zero-based index of the added item.</returns>
    public new int Add(RssItem item)
    {
      pubDateChanged = true;
      base.Add(item);
      return base.IndexOf(item);
    }
    
    /// <summary>Inserts an item into this collection at a specified index.</summary>
    /// <param name="index">The zero-based index of the collection at which to insert the item.</param>
    /// <param name="item">The item to insert into this collection.</param>
    public new void Insert(int index, RssItem item)
    {
      pubDateChanged = true;
      base.Insert(index, item);
    }

    /// <summary>Removes a specified item from this collection.</summary>
    /// <param name="item">The item to remove.</param>
    public new void Remove(RssItem item)
    {
      pubDateChanged = true;
      base.Remove(item);
    }

    /// <summary>The latest pubDate in the items collection</summary>
    /// <value>The latest pubDate -or- RssDefault.DateTime if all item pubDates are not defined</value>
    public System.DateTime LatestPubDate()
    {
      CalculatePubDates();
      return latestPubDate;
    }

    /// <summary>The oldest pubDate in the items collection</summary>
    /// <value>The oldest pubDate -or- RssDefault.DateTime if all item pubDates are not defined</value>
    public System.DateTime OldestPubDate()
    {
      CalculatePubDates();
      return oldestPubDate;
    }

    /// <summary>Calculates the oldest and latest pubdates</summary>
    private void CalculatePubDates()
    {
      if (pubDateChanged)
      {
        pubDateChanged = false;
        latestPubDate = System.DateTime.MinValue;
        oldestPubDate = System.DateTime.MaxValue;

        foreach (RssItem item in this)
          if ((item.PubDate != RssDefault.DateTime) & (item.PubDate > latestPubDate))
            latestPubDate = item.PubDate;
        if (latestPubDate == System.DateTime.MinValue)
          latestPubDate = RssDefault.DateTime;

        foreach (RssItem item in this)
          if ((item.PubDate != RssDefault.DateTime) & (item.PubDate < oldestPubDate))
            oldestPubDate = item.PubDate;
        if (oldestPubDate == System.DateTime.MaxValue)
          oldestPubDate = RssDefault.DateTime;
      }
    }

    /// <summary>Returns a System.String that represents the collection of <see cref="RssItem"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssItem"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssItem item in this)
      {
        str.AppendLine(item.ToString());
      }

      return str.ToString();
    }
  }
}
