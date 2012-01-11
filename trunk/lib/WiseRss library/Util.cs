namespace Util
{
  /// <summary>
  /// Debug class which prints stack trace
  /// </summary>
  public class Debug
  {
    private System.Diagnostics.StackTrace stackTrace = null;
    private string message = string.Empty;
    private System.Text.StringBuilder sb = new System.Text.StringBuilder(256);

    /// <summary>
    /// 
    /// </summary>
    public Debug() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    public Debug(string text)
    {
      sb.AppendLine(text);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stackTrace"></param>
    public Debug(System.Diagnostics.StackTrace stackTrace)
    {
      this.stackTrace = stackTrace;

      sb.AppendLine("Error: " + message);
      System.Diagnostics.StackFrame stackFrame = null;
      string parameters = string.Empty;

      try
      {
        for (int i = 1, j = stackTrace.FrameCount; i < j; i++)
        {
          stackFrame = stackTrace.GetFrame(i);
          for (int k = 1; k < i; k++) { sb.Append(" "); }

          System.Reflection.MethodBase method = stackFrame.GetMethod();
          System.Reflection.ParameterInfo[] paramInfo = method.GetParameters();
          for (int k = 0; k < paramInfo.Length; k++)
          {
            parameters = parameters + paramInfo[k].ParameterType.Name + ", ";
          }

          if (parameters.Length > 0)
          {
            parameters = parameters.Substring(0, parameters.Length - 2);
          }

          sb.AppendFormat("at {0}.{1}({2}) {3}({4})\n",
                          method.DeclaringType,
                          method.Name,
                          parameters,
                          stackFrame.GetFileName(),
                          stackFrame.GetFileLineNumber());
        }
      }
      catch (System.Exception ex)
      {
        if (IsCriticalException(ex))
        {
          throw;
        }
        sb.AppendLine(ex.ToString());
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stackTrace"></param>
    /// <param name="message"></param>
    public Debug(System.Diagnostics.StackTrace stackTrace, string message) : this(stackTrace)
    {
      this.message = message;
      sb.Insert(7, message);
    }

    /// <summary>
    /// Print stack trace of the given stack
    /// </summary>
    [System.Diagnostics.Conditional("DEBUG")]
    public void Print()
    {
      System.Diagnostics.Trace.WriteLine(sb.ToString());
      System.Diagnostics.Trace.Flush();
    }

    private bool IsCriticalException(System.Exception ex)
    {
      return ex is System.StackOverflowException ||
             ex is System.OutOfMemoryException   ||
             ex is System.Threading.ThreadAbortException;
    }

    /// <summary>
    /// ToString method redefined
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return sb.ToString();
    }
  }
}