using System;

namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssChannel"/> objects</summary>
  [Serializable()]
  public class RssChannelCollection : System.Collections.ObjectModel.Collection<RssChannel>
  {
    /// <summary>Returns a System.String that represents the collection of <see cref="RssChannel"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssChannel"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssChannel channel in this)
      {
        str.AppendLine(channel.ToString());
      }

      return str.ToString();
    }
  }
}
