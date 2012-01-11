namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssTextInput"/> objects</summary>
  [System.Serializable()]
  public class RssTextInputCollection : System.Collections.ObjectModel.Collection<RssTextInput>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssTextInput"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssTextInput"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();
      
      foreach (RssTextInput textInput in this)
      {
        str.AppendLine(textInput.ToString());
      }

      return str.ToString();
    }
  }
}
