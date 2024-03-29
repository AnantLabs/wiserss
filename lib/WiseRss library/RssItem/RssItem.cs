/* RssItem.cs
 * ==========
 * 
 * RSS.NET (http://rss-net.sf.net/)
 * Copyright � 2002 - 2005 George Tsiokos & Dave Purrington. All Rights Reserved.
 * 
 * RSS 2.0 (http://blogs.law.harvard.edu/tech/rss)
 * RSS 2.0 is offered by the Berkman Center for Internet & Society at 
 * Harvard Law School under the terms of the Attribution/Share Alike 
 * Creative Commons license.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the 
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 * THE SOFTWARE.
*/
using System;

namespace Rss
{

  /// <summary>A channel may contain any number of items, each of which links to more information about the item, with an optional description</summary>
  [Serializable()]
  public class RssItem : RssElement
  {

    #region Private Members

    private long id = RssDefault.Long;
    private long categoryId = RssDefault.Long;
    private long channelId = RssDefault.Long;
    private string title = RssDefault.String;
    private Uri link = RssDefault.Uri;
    private string description = RssDefault.String;
    private string author = RssDefault.String;
    private RssCategoryCollection categories = new RssCategoryCollection();
    private string comments = RssDefault.String;
    private RssEnclosureCollection enclosures = new RssEnclosureCollection();
    private RssGuid guid = new RssGuid();
    private DateTime pubDate = RssDefault.DateTime;
    private RssSource source = new RssSource();
    private string creator = RssDefault.String;
    private int commentCount = RssDefault.Int;
    private string commentRss = RssDefault.String;
    private string commentApiUrl = RssDefault.String;
    private bool favorite = RssDefault.Bool;
    private RssStatus status = RssStatus.Unchanged;
    private bool canSave = RssDefault.Bool;
    private string shortTitle = RssDefault.String;
    private string shortDescription = RssDefault.String;

    /// <summary>
    /// 
    /// </summary>
    public delegate void ItemDownloadCompletedHandler();

    /// <summary>
    /// 
    /// </summary>
    public event ItemDownloadCompletedHandler ItemDownloadCompleted;
    

    #endregion

    #region Constructor(s)

    /// <summary>Initialize a new instance of the RssItem class</summary>
    public RssItem() { }

    #endregion

    #region Overrides

    /// <summary>Returns a string representation of the current Object.</summary>
    /// <returns>The item's title, description, or "RssItem" if the title and description are blank.</returns>
    public override string ToString()
    {
      if (title != RssDefault.String)
        return title;
      else
        if (description != RssDefault.String)
          return description;
        else
          return "RssItem";
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// ID of the item.
    /// </summary>
    public long ID
    {
      get { return id; }
      set { id = RssDefault.Check(value); Status = RssStatus.Changed; }
    }

    /// <summary>
    /// The ID of the category.
    /// </summary>
    public long CategoryID
    {
      get { return categoryId; }
      set { categoryId = RssDefault.Check(value); Status = RssStatus.Changed; }
    }

    /// <summary>
    /// The ID of the channel.
    /// </summary>
    public long ChannelID
    {
      get { return channelId; }
      set { channelId = RssDefault.Check(value); Status = RssStatus.Changed; }
    }

    /// <summary>Title of the item</summary>
    /// <remarks>Maximum length is 100 (For RSS 0.91)</remarks>
    public string Title
    {
      get { return title; }
      set
      {
        if (null != value && value.Length > 0)
        {
          title = RssDefault.Check(value).Trim(); Status = RssStatus.Changed;
          shortTitle = title.Substring(0, System.Math.Min(title.Length, 128));
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string ShortTitle
    {
      get { return shortTitle; }
    }

    /// <summary>URL of the item</summary>
    /// <remarks>Maximum length is 500 (For RSS 0.91)</remarks>
    public Uri Link
    {
      get { return link; }
      set
      {
        link = RssDefault.Check(value);

        if (link != null &&
            link.OriginalString != null &&
           !link.OriginalString.Equals(string.Empty) &&
            Status == RssStatus.Update)
        {
          String desc = String.Empty;

          Util.MethodInvoker boilerpipeDelegate = new Util.MethodInvoker(delegate()
          {
            desc = Boilerpipe.Oneliner(link.OriginalString);
          });

          boilerpipeDelegate.BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar)
          {
            boilerpipeDelegate.EndInvoke(ar);
            description = desc;
            canSave = true;
            OnItemDownloadCompleted();
          }),
            boilerpipeDelegate);
        }
        Status = RssStatus.Changed;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    protected void OnItemDownloadCompleted()
    {
      if (null != ItemDownloadCompleted)
      {
        ItemDownloadCompleted();
      }
    }

    /// <summary>Item synopsis</summary>
    /// <remarks>Maximum length is 500 (For RSS 0.91)</remarks>
    public string Description
    {
      get { return description; }
      set
      {
        description = RssDefault.Check(value).Trim();
        shortDescription = description.Substring(0,
          System.Math.Min(description.Length, 128)) + "...";
        Status = RssStatus.Changed;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string ShortDescription
    {
      get { return shortDescription; }
    }

    /// <summary>Email address of the author of the item</summary>
    public string Author
    {
      get { return author; }
      set { author = RssDefault.Check(value).Trim(); Status = RssStatus.Changed; }
    }
    /// <summary>Provide information regarding the location of the subject matter of the channel in a taxonomy</summary>
    public RssCategoryCollection Categories
    {
      get { return categories; }
      set { categories = value; Status = RssStatus.Changed; }
    }
    /// <summary>URL of a page for comments relating to the item</summary>
    public string Comments
    {
      get { return comments; }
      set { comments = RssDefault.Check(value).Trim(); Status = RssStatus.Changed; }
    }
    /// <summary>Describes an items source</summary>
    public RssSource Source
    {
      get { return source; }
      set { source = value; Status = RssStatus.Changed; }
    }
    /// <summary>A reference to an attachments to the item</summary>
    public RssEnclosureCollection Enclosures
    {
      get { return enclosures; }
      set { enclosures = value; Status = RssStatus.Changed; }
    }
    /// <summary>A string that uniquely identifies the item</summary>
    public RssGuid Guid
    {
      get { return guid; }
      set { guid = value; Status = RssStatus.Changed; }
    }
    /// <summary>Indicates when the item was published</summary>
    public DateTime PubDate
    {
      get { return pubDate; }
      set { pubDate = value; Status = RssStatus.Changed; }
    }

    /// <summary>Identifies the person or entity who wrote an item</summary>
    public string Creator
    {
      get { return creator; }
      set { creator = value.Trim(); Status = RssStatus.Changed; }
    }

    /// <summary>Identifies the number of comments received in response to the item</summary>
    public int CommentCount
    {
      get { return commentCount; }
      set { commentCount = value; Status = RssStatus.Changed; }
    }

    /// <summary>Identifies the URL of a web page that contains comments received in response to the item</summary>
    public string CommentRss
    {
      get { return commentRss; }
      set { commentRss = value.Trim(); Status = RssStatus.Changed; }
    }

    /// <summary>Identifies the API URL of a web page that contains comments received in response to the item</summary>
    public string CommentApiUrl
    {
      get { return commentApiUrl; }
      set { commentApiUrl = value.Trim(); Status = RssStatus.Changed; }
    }

    /// <summary>Indicate if item is marked as favorite (true=favorite)</summary>
    public bool Favorite
    {
      get { return favorite; }
      set { favorite = RssDefault.Check(value); Status = RssStatus.Changed; }
    }

    /// <summary>
    /// Indicate if item is modified.
    /// </summary>
    public RssStatus Status
    {
      get { return status; }
      set
      {
        if (status != RssStatus.Update)
        {
          status = value;
        }
      }
    }

    /// <summary>
    /// Indicate if item can be saved.
    /// </summary>
    public bool CanSave
    {
      get { return canSave; }
    }

    #endregion

  }
}
