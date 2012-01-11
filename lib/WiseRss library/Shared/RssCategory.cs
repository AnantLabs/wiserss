using System;

namespace Rss
{
  /// <summary>
  /// Provide information regarding the location of the subject matter of the channel in a taxonomy.
  /// </summary>
  [Serializable()]
  public class RssCategory : RssElement
  {
    private long id = RssDefault.Long;
    private string name = RssDefault.String;

    /// <summary>
    /// Initialize a new instance of the RssCategory class.
    /// </summary>
    public RssCategory() { }

    /// <summary>
    /// ID of the category.
    /// </summary>
    public long ID
    {
      get { return id; }
      set { id = RssDefault.Check(value); }
    }

    /// <summary>
    /// Actual categorization given for this item/channel.
    /// </summary>
    public string Name
    {
      get { return name; }
      set { name = RssDefault.Check(value); }
    }

    /// <summary>Returns a System.String that represents the current RssCategory.</summary>
    /// <returns>A System.String that represents the current RssCategory</returns>
    public override string ToString()
    {
      return ID + name;
    }
  }
}
