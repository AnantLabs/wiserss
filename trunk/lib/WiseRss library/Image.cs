using System;

namespace Rss
{
  /// <summary>
  /// 
  /// </summary>
  public class Image : IComparable<Image>
  {
    private String src;
    private String width;
    private String height;
    private String alt;
    private int area;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="src"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="alt"></param>
    public Image(String src, String width, String height, String alt)
    {
      this.src = src;
      if (src == null)
      {
        throw new ArgumentNullException("src attribute must not be null");
      }
      this.width = nullTrim(width);
      this.height = nullTrim(height);
      this.alt = nullTrim(alt);

      if (width != null && height != null)
      {
        int a;
        try
        {
          a = int.Parse(width) * int.Parse(height);
        }
        catch (FormatException)
        {
          a = -1;
        }
        this.area = a;
      }
      else
      {
        this.area = -1;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public String getSrc()
    {
      return src;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public String getWidth()
    {
      return width;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public String getHeight()
    {
      return height;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public String getAlt()
    {
      return alt;
    }

    private static String nullTrim(String s)
    {
      if (s == null)
      {
        return null;
      }
      s = s.Trim();
      if (s.Length == 0)
      {
        return null;
      }
      return s;
    }

    /// <summary>
    /// Returns the image's area (specified by width * height),
    /// or -1 if width/height weren't both specified or could not be parsed.
    /// </summary>
    /// <returns></returns>
    public int getArea()
    {
      return area;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return src + "\twidth=" + width + "\theight=" + height + "\talt=" + alt + "\tarea=" + area;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public int CompareTo(Image o)
    {
      if (o == this)
      {
        return 0;
      }
      if (area > o.area)
      {
        return -1;
      }
      else if (area == o.area)
      {
        return src.CompareTo(o.src);
      }
      else
      {
        return 1;
      }
    }
  }
}