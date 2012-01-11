namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssLanguage"/> objects</summary>
  [System.Serializable()]
  public class RssLanguageCollection : System.Collections.ObjectModel.Collection<RssLanguage>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssLanguage"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssLanguage"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssLanguage language in this)
      {
        str.AppendLine(language.ToString());
      }

      return str.ToString();
    }
  }
}
