namespace Translator
{
  /// <summary>
  /// Google translator.
  /// </summary>
  public class Google
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="languageCode"></param>
    /// <returns></returns>
    public static string TranslateText(string input, string languageCode)
    {
      string result = string.Empty;
      System.Net.WebResponse response = null;

      try
      {
        string url = "http://translate.google.com/";

        System.Net.HttpWebRequest request =
          (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";

        using (System.IO.Stream stream = request.GetRequestStream())
        {
          byte[] arrBytes =
            System.Text.Encoding.UTF8.GetBytes(
            System.String.Format("sl=auto&ie=UTF-8&tl={0}&text={1}", languageCode, input));
          stream.Write(arrBytes, 0, arrBytes.Length);
        }

        response = request.GetResponse();

        string encoding = response.ContentType.Substring(response.ContentType.LastIndexOf('=') + 1);
        
        using (System.IO.Stream stream = response.GetResponseStream())
        using (System.IO.StreamReader rdr =
          new System.IO.StreamReader(stream, System.Text.Encoding.GetEncoding(encoding)))
        {
          result = rdr.ReadToEnd();
        }

        string begin = "<span id=result_box class=\"long_text\">";
        int indexBegin = result.IndexOf(begin) + begin.Length;
        
        string end = "</span></span></div>";
        int indexEnd = result.IndexOf(end);
        result = result.Substring(indexBegin, System.Math.Max(indexEnd - indexBegin, 0));
        result = result.Replace("</span>", string.Empty);
        result = result.Replace("&quot;", string.Empty);
        result = result.Replace("<br>", System.Environment.NewLine);
        
        string spanTitle = "<span title=\"";
        string endTag = "\">";
        int spanTitleIndex = spanTitleIndex = result.IndexOf(spanTitle);
        int endTagIndex = 0;
        
        do
        {
          if (spanTitleIndex == -1) { break; }

          endTagIndex = result.IndexOf(endTag);

          if (endTagIndex == -1) { break; }

          result = result.Replace(
            result.Substring(
              spanTitleIndex,
              System.Math.Max(endTagIndex - spanTitleIndex + endTag.Length, 0)),
            string.Empty);

          spanTitleIndex = result.IndexOf(spanTitle);
        } while (spanTitleIndex > -1);
      }
      catch (System.Exception) { }
      return result.Trim();
    }
  }
}