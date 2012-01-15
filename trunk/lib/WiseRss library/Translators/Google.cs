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
    /// <param name="languagePair"></param>
    /// <returns></returns>
    public static string TranslateText(string input, string languagePair)
    {
      string result = string.Empty;
      try
      {
        string url = System.String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
        System.Net.WebClient webClient = new System.Net.WebClient();
        webClient.Encoding = System.Text.Encoding.UTF8;
        result = webClient.DownloadString(url);
        result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
        result = result.Substring(result.IndexOf(">") + 1);
        result = result.Substring(0, result.IndexOf("</span>"));
      }
      catch (System.Exception) { }
      return result.Trim();
    }
  }
}