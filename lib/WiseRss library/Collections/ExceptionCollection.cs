using System;

namespace Rss
{
  /// <summary>A strongly typed collection of <see cref="Exception"/> objects</summary>
  [Serializable()]
  public class ExceptionCollection : System.Collections.ObjectModel.Collection<Exception>
  {
    private Exception lastException = null;
    
    /// <summary>Adds a specified exception to this collection.</summary>
    /// <param name="exception">The exception to add.</param>
    /// <returns>The zero-based index of the added exception -or- -1 if the exception already exists.</returns>
    public new int Add(Exception exception)
    {
      foreach (Exception e in this)
        if (e.Message == exception.Message)
          return -1;
      lastException = exception;
      base.Add(exception);
      return base.IndexOf(exception);
    }
    
    /// <summary>Returns the last exception added through the Add method.</summary>
    /// <value>The last exception -or- null if no exceptions exist</value>
    public Exception LastException
    {
      get { return lastException; }
    }

    /// <summary>Returns a System.String that represents the collection of <see cref="Exception"/> objects.</summary>
    /// <returns>A System.String that represents the collection of <see cref="Exception"/> objects</returns>
    public override string ToString()
    {
      System.Text.StringBuilder str = new System.Text.StringBuilder();

      foreach (Exception exception in this)
      {
        str.AppendLine(exception.ToString());
      }

      return str.ToString();
    }
  }
}
