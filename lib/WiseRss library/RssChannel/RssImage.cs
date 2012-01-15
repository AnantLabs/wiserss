using System;

namespace Rss
{
  /// <summary>A link and description for a graphic that represent a channel</summary>
  [Serializable()]
  public class RssImage : RssElement
  {
    private long id = RssDefault.Long;
    private string title = RssDefault.String;
    private string description = RssDefault.String;
    private Uri uri = RssDefault.Uri;
    private Uri link = RssDefault.Uri;
    private int width = RssDefault.Int;
    private int height = RssDefault.Int;
    private System.IO.MemoryStream image = new System.IO.MemoryStream();
    private long rssChannelId = RssDefault.Long;
    private string path = RssDefault.String;
    private RssStatus status = RssStatus.Unchanged;
    private bool canSave = RssDefault.Bool;

    /// <summary>
    /// 
    /// </summary>
    public delegate void ImageDownloadCompletedHandler();

    /// <summary>
    /// 
    /// </summary>
    public event ImageDownloadCompletedHandler ImageDownloadCompleted;

    /// <summary>Initialize a new instance of the RssImage class.</summary>
    public RssImage() { }

    /// <summary>
    /// Creates a new <see cref="RssImage"/> instance.
    /// </summary>
    /// <param name="title">Title.</param>
    /// <param name="uri">URI.</param>
    /// <param name="link">Link.</param>
    public RssImage(string title, Uri uri, Uri link)
    {
      this.title = title;
      this.uri = uri;
      this.link = link;
      Status = RssStatus.Changed;
    }

    /// <summary>The image that represents the channel.</summary>
    public Uri Url
    {
      get { return uri; }
      set
      {
        uri = RssDefault.Check(value);

        if (Status == RssStatus.Update)
        {
          // get image asynchronously
          Async.MakeRequest(uri, callbackState =>
          {
            if (callbackState.RequestTimedOut)
            {
#if DEBUG
              Console.WriteLine("Timed out!");
#endif
            }
            else if (callbackState.Exception != null)
            {
#if DEBUG
              Console.WriteLine(callbackState.Exception);
#endif
            }
            else
            {
              Image = new System.IO.MemoryStream(
                Async.ReadFully(callbackState.ResponseStream,
                8192));

              try
              {
                WriteImage();
              }
              catch (Exception) { }
            }
          }, true, 10000);
        }
        Status = RssStatus.Changed;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    protected void OnImageDownloadCompleted()
    {
      if (null != ImageDownloadCompleted)
      {
        ImageDownloadCompleted();
      }
    }

    /// <summary>Describes the image, it's used in the ALT attribute of the HTML img tag when the channel is rendered in HTML.</summary>
    /// <remarks>Maximum length is 100 (For RSS 0.91).</remarks>
    public string Title
    {
      get { return title; }
      set { title = RssDefault.Check(value); Status = RssStatus.Changed; }
    }
    /// <summary>The URL of the site, when the channel is rendered, the image is a link to the site.</summary>
    public Uri Link
    {
      get { return link; }
      set { link = RssDefault.Check(value); Status = RssStatus.Changed; }
    }
    /// <summary>Contains text that is included in the TITLE attribute of the link formed around the image in the HTML rendering.</summary>
    public string Description
    {
      get { return description; }
      set { description = RssDefault.Check(value).Trim(); Status = RssStatus.Changed; }
    }
    /// <summary>Width of image in pixels</summary>
    public int Width
    {
      get { return width; }
      set { width = RssDefault.Check(value); Status = RssStatus.Changed; }
    }
    /// <summary>Height of image in pixels</summary>
    public int Height
    {
      get { return height; }
      set { height = RssDefault.Check(value); Status = RssStatus.Changed; }
    }

    /// <summary>
    /// ID of the image.
    /// </summary>
    public long ID
    {
      get { return id; }
      set { id = value; Status = RssStatus.Changed; }
    }

    /// <summary>
    /// Rss channel ID of the image.
    /// </summary>
    public long RssChannelID
    {
      get { return rssChannelId; }
      set { rssChannelId = value; Status = RssStatus.Changed; }
    }

    /// <summary>
    /// Reference to the image in RAM.
    /// </summary>
    public System.IO.MemoryStream Image
    {
      get { return image; }
      set { image = value; Status = RssStatus.Changed; }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Path
    {
      get { return path; }
      set { path = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public RssStatus Status
    {
      get { return status; }
      set { status = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool CanSave
    {
      get { return canSave; }
    }

    /// <summary>
    /// Return true when object is usable,
    /// otherwise return false.
    /// </summary>
    public bool IsUsable
    {
      get
      {
        return !(title == null || title.Length == 0 ||
                 uri == null || link == null ||
                 uri.Equals(RssDefault.Uri));
      }
    }

    private void WriteImage()
    {
      byte[] channelPlainTextBytes = System.Text.Encoding.UTF8.GetBytes(Link.OriginalString);
      Path = System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetAssembly(typeof(RssImage)).CodeBase) +
        "\\img\\" + Util.String.WindowsPath(Convert.ToBase64String(channelPlainTextBytes));
      
      if (Path.StartsWith("file:\\"))
      {
        Path = Path.Substring(6);
      }

      if (System.IO.Directory.Exists(Path))
      {
        byte[] imagePlainTextBytes = System.Text.Encoding.UTF8.GetBytes(Link.OriginalString);
        Path += "\\" + Util.String.WindowsPath(Convert.ToBase64String(imagePlainTextBytes));

        System.IO.FileStream fs = new System.IO.FileStream(Path,
          System.IO.FileMode.Create,
          System.IO.FileAccess.Write,
          System.IO.FileShare.ReadWrite);
        {
          fs.BeginWrite(Image.ToArray(),
            0,
            (int)Image.Length,
            new AsyncCallback(delegate(IAsyncResult ar)
          {
            using (System.IO.FileStream s = (System.IO.FileStream)ar.AsyncState)
            {
              s.EndWrite(ar);
              canSave = true;
              s.Close();
              OnImageDownloadCompleted();
            }
          }),
            fs);
        }
      }
    }
  }
}
