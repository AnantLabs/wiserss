using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rss
{
  /// <summary>
  /// 
  /// </summary>
  public class Async
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="responseCallback"></param>
    /// <param name="timeOut"></param>
    /// <param name="TimeoutLength"></param>
    public static void MakeRequest(Uri uri, Action<RequestCallbackState> responseCallback, bool timeOut = true, int TimeoutLength = 4000)
    {
      System.Net.WebRequest request = System.Net.WebRequest.Create(uri);
      request.Proxy = null;

      System.Threading.Tasks.Task<System.Net.WebResponse> asyncTask =
        System.Threading.Tasks.Task.Factory.FromAsync<System.Net.WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

      if (timeOut)
      {
        System.Threading.ThreadPool.RegisterWaitForSingleObject(
          (asyncTask as IAsyncResult).AsyncWaitHandle,
          new System.Threading.WaitOrTimerCallback(TimeoutCallback), request, TimeoutLength, true);
      }

      asyncTask.ContinueWith(task =>
      {
        System.Net.WebResponse response = task.Result;
        System.IO.Stream responseStream = response.GetResponseStream();
        responseCallback(new RequestCallbackState(response.GetResponseStream()));
        responseStream.Close();
        response.Close();
      }, System.Threading.Tasks.TaskContinuationOptions.NotOnFaulted);

      // Handle errors
      asyncTask.ContinueWith(task =>
      {
        var exception = task.Exception;
        var webException = exception.InnerException;

        // Track whether you cancelled or not... up to you...
        responseCallback(new RequestCallbackState(exception.InnerException,
          webException.Message.Contains("The request was canceled.")));
      }, System.Threading.Tasks.TaskContinuationOptions.OnlyOnFaulted);
    }

    private static void TimeoutCallback(object state, bool timedOut)
    {
      Console.WriteLine("Timeout: " + timedOut);
      if (timedOut)
      {
        Console.WriteLine("Timeout");
        System.Net.WebRequest request = (System.Net.WebRequest)state;
        if (state != null)
        {
          request.Abort();
        }
      }
    }

    /// <summary>
    /// Reads data from a stream until the end is reached. The
    /// data is returned as a byte array. An IOException is
    /// thrown if any of the underlying IO calls fail.
    /// </summary>
    /// <param name="stream">The stream to read data from</param>
    /// <param name="initialLength">The initial buffer length</param>
    public static byte[] ReadFully(System.IO.Stream stream, int initialLength)
    {
      // If we've been passed an unhelpful initial length, just
      // use 32K.
      if (initialLength < 1)
      {
        initialLength = 32768;
      }

      byte[] buffer = new byte[initialLength];
      int read = 0;

      int chunk;
      while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
      {
        read += chunk;

        // If we've reached the end of our buffer, check to see if there's
        // any more information
        if (read == buffer.Length)
        {
          int nextByte = stream.ReadByte();

          // End of stream? If so, we're done
          if (nextByte == -1)
          {
            return buffer;
          }

          // Nope. Resize the buffer, put in the byte we've just
          // read, and continue
          byte[] newBuffer = new byte[buffer.Length * 2];
          Array.Copy(buffer, newBuffer, buffer.Length);
          newBuffer[read] = (byte)nextByte;
          buffer = newBuffer;
          read++;
        }
      }
      // Buffer is now too big. Shrink it.
      byte[] ret = new byte[read];
      Array.Copy(buffer, ret, read);
      return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    public class RequestCallbackState
    {
      /// <summary>
      /// 
      /// </summary>
      public System.IO.Stream ResponseStream { get; private set; }

      /// <summary>
      /// 
      /// </summary>
      public Exception Exception { get; private set; }

      /// <summary>
      /// 
      /// </summary>
      public bool RequestTimedOut { get; private set; }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="responseStream"></param>
      public RequestCallbackState(System.IO.Stream responseStream)
      {
        ResponseStream = responseStream;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="exception"></param>
      /// <param name="timedOut"></param>
      public RequestCallbackState(Exception exception, bool timedOut = false)
      {
        Exception = exception;
        RequestTimedOut = timedOut;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RequestState
    {
      /// <summary>
      /// 
      /// </summary>
      public byte[] RequestBytes { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public System.Net.WebRequest Request { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public Action<RequestCallbackState> ResponseCallback { get; set; }
    }
  }
}
