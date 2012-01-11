using System;

namespace Rss
{
  /// <summary>Provide information regarding the location of the subject matter of the channel in a taxonomy</summary>
  [Serializable()]
  public class RssLanguage : RssElement
  {
    private string language = RssDefault.String;
    private string identifier = RssDefault.String;
    private long id = RssDefault.Long;

    /// <summary>Initialize a new instance of the RssLanguage class</summary>
    public RssLanguage() { }

    /// <summary>Actual language given for this item, within the chosen taxonomy</summary>
    public string Language
    {
      get { return language; }
      set { language = RssDefault.Check(value); }
    }
    /// <summary>Identifier of external taxonomy</summary>
    public string Identifier
    {
      get { return identifier; }
      set { identifier = RssDefault.Check(value); }
    }
    /// <summary>ID for this language</summary>
    public long ID
    {
      get { return id; }
      set { id = RssDefault.Check(value); }
    }
  }
}
