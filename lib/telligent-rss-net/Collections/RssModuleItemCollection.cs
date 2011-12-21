namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="RssModuleItem"/> objects</summary>
  [System.Serializable()]
  public class RssModuleItemCollection : System.Collections.ObjectModel.Collection<RssModuleItem>
  {
    private System.Collections.ArrayList _alBindTo = new System.Collections.ArrayList();

    /// <summary>Bind a particular item to this module</summary>
    /// <param name="itemHashCode">Hash code of the item</param>
    public void BindTo(int itemHashCode)
    {
      this._alBindTo.Add(itemHashCode);
    }

    /// <summary>Check if a particular item is bound to this module</summary>
    /// <param name="itemHashCode">Hash code of the item</param>
    /// <returns>true if this item is bound to this module, otherwise false</returns>
    public bool IsBoundTo(int itemHashCode)
    {
      return (this._alBindTo.BinarySearch(0, this._alBindTo.Count, itemHashCode, null) >= 0);
    }

    /// <summary>Returns a System.String that represents the collection of <see cref="RssModuleItem"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="RssModuleItem"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (RssModuleItem item in this)
      {
        str.AppendLine(item.ToString());
      }

      return str.ToString();
    }
  }
}
