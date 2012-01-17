using System.Linq;
using System.Xml.Serialization;

namespace Translator
{
  /// <summary>
  /// Microsoft Translator V2 class.
  /// Go to http://msdn.microsoft.com/en-us/library/ff512386.aspx to obtain AppId
  /// </summary>
  public class Microsoft
  {

    private static string ProcessWebException(
      System.Net.WebException e,
      string message)
    {
#if DEBUG
      new Util.Debug(
        string.Format("{0}: {1}", message, e.ToString())).Print();
#endif

      // Obtain detailed error information
      string strResponse = string.Empty;
      using (System.Net.HttpWebResponse response =
        (System.Net.HttpWebResponse)e.Response)
      {
        using (System.IO.Stream responseStream =
          response.GetResponseStream())
        {
          using (System.IO.StreamReader sr =
            new System.IO.StreamReader(responseStream,
              System.Text.Encoding.ASCII))
          {
            strResponse = sr.ReadToEnd();
          }
        }
      }
      strResponse = string.Format(
        "Http status code={0}, error message={1}",
        e.Status, strResponse);

#if DEBUG
      new Util.Debug(new System.Diagnostics.StackTrace(true),
        strResponse).Print();
#endif

      return strResponse;
    }

    /// <summary>
    /// Use the Detect Method to identify
    /// the language of a selected piece of text.
    /// </summary>
    /// <param name="appId">
    /// A string containing the Bing AppID.
    /// </param>
    /// <param name="text">
    /// A string containing some text whose language is to be identified.
    /// </param>
    /// <returns>
    /// A string containing a two-character Language code for the given text.
    /// </returns>
    public static string Detect(string appId, string text)
    {
      string locale = string.Empty;
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/Detect?appId="
        + appId
        + "&text=" + System.Uri.EscapeDataString(text);

      System.Net.HttpWebRequest httpWebRequest =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);

      System.Net.WebResponse response = null;

      try
      {
        response = httpWebRequest.GetResponse();
        using (System.IO.Stream stream = response.GetResponseStream())
        {
          System.Runtime.Serialization.DataContractSerializer dcs =
            new System.Runtime.Serialization.DataContractSerializer(
              System.Type.GetType("System.String"));

          locale = (string)dcs.ReadObject(stream);

#if DEBUG
          new Util.Debug("The detected language is: '" +
            locale + "'.").Print();
#endif
        }
      }
      catch (System.Net.WebException e)
      {
        locale = string.Empty;

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e, "Failed to detect language")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return locale;
    }

    /// <summary>
    /// Use the DetectArray Method to identify
    /// the language of an array of string at once.
    /// Performs independent detection
    /// of each individual array element
    /// and returns a result for each row of the array.
    /// </summary>
    /// <param name="appId">A string containing the Bing AppID.</param>
    /// <param name="textArray">
    /// A string array representing the text from an unknown language.
    /// </param>
    /// <returns>
    /// A string containing a two-character Language codes
    /// for each row of the input array.
    /// </returns>
    public static string DetectArray(string appId, string[] textArray)
    {
      System.Text.StringBuilder sbDetect = new System.Text.StringBuilder();
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/DetectArray?appId="
        + appId;

      // create the request
      // The request body is a xml string generated according
      // to the schema specified at http://api.microsofttranslator.com/v2/Http.svc/help.
      System.IO.StringWriter swriter = new System.IO.StringWriter();
      System.Xml.XmlTextWriter xwriter = new System.Xml.XmlTextWriter(swriter);

      xwriter.WriteStartElement("ArrayOfstring");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.microsoft.com/2003/10/Serialization/Arrays");

      foreach (string text in textArray)
      {
        xwriter.WriteStartElement("string");
        xwriter.WriteString(text);
        xwriter.WriteEndElement();
      }
      xwriter.WriteEndElement();

      xwriter.Close();
      swriter.Close();
      System.Net.HttpWebRequest request =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
      request.ContentType = "text/xml";
      request.Method = "POST";
      using (System.IO.Stream stream = request.GetRequestStream())
      {
        byte[] arrBytes =
          System.Text.Encoding.UTF8.GetBytes(swriter.ToString());
        stream.Write(arrBytes, 0, arrBytes.Length);
      }

      // get the response
      System.Net.WebResponse response = null;
      try
      {
        response = request.GetResponse();
        using (System.IO.Stream stream = response.GetResponseStream())
        {

          System.Runtime.Serialization.DataContractSerializer dcs =
            new System.Runtime.Serialization.DataContractSerializer(
              System.Type.GetType("System.String[]"));

          string[] detectArray = (string[])dcs.ReadObject(stream);

          sbDetect.Append(string.Join(",",
            detectArray.Select(x => x.ToString()).ToArray()));

#if DEBUG
          new Util.Debug("The detected language are: '" + sbDetect + "'.").Print();
#endif
        }
      }
      catch (System.Net.WebException e)
      {
        sbDetect.Clear();

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e, "Failed to detect languages")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return sbDetect.ToString();
    }

    /// <summary>
    /// Retrieves friendly names for the languages
    /// passed in as the parameter languageCodes,
    /// and localized using the passed locale language.
    /// </summary>
    /// <param name="appId">
    /// A string containing the Bing AppID.
    /// </param>
    /// <param name="locale">
    /// A string representing a combination of an ISO 639
    /// two-letter lowercase culture code associated with a language and
    /// an ISO 3166 two-letter uppercase subculture code to localize
    /// the language names or a ISO 639 lowercase culture code by itself.
    /// </param>
    /// <param name="languageCodes">
    /// A string array representing
    /// the ISO 639-1 language codes to retrieve the friendly name for.
    /// </param>
    /// <returns>
    /// A string containing languages names supported by the Translator Service,
    /// localized into the requested language.
    /// </returns>
    public static string GetLanguageNames(
      string appId,
      string locale,
      string[] languageCodes)
    {
      if (null == languageCodes ||
          string.IsNullOrWhiteSpace(string.Join(string.Empty, languageCodes)))
      {
        return string.Empty;
      }
      System.Text.StringBuilder sbLanguages = new System.Text.StringBuilder();
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/GetLanguageNames?appId="
        + appId
        + "&locale=" + locale;

      // create the request
      System.Net.HttpWebRequest req =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);

      req.ContentType = "text/xml";
      req.Method = "POST";
      System.Runtime.Serialization.DataContractSerializer dcs =
        new System.Runtime.Serialization.DataContractSerializer(
          System.Type.GetType("System.String[]"));
      using (System.IO.Stream stream = req.GetRequestStream())
      {
        dcs.WriteObject(stream, languageCodes);
      }

      System.Net.WebResponse response = null;
      try
      {
        response = req.GetResponse();

        using (System.IO.Stream stream = response.GetResponseStream())
        {
          string[] glnArray = (string[])dcs.ReadObject(stream);
          sbLanguages.Append(string.Join(",", glnArray.Select(x => x.Trim().ToString()).ToArray()));

#if false
          new Util.Debug("The language names are: '" + sbLanguages + "'.").Print();
#endif
        }
      }
      catch (System.Net.WebException e)
      {
        sbLanguages.Clear();

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e, "Failed to get language names")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return sbLanguages.ToString();
    }

    /// <summary>
    /// Obtain a list of language codes representing languages
    /// that are supported by the Translation Service.
    /// Translate() and TranslateArray() can translate
    /// between any two of these languages.
    /// </summary>
    /// <param name="appId">
    /// A string containing the Bing AppID.
    /// </param>
    /// <returns>
    /// A string containing the language codes
    /// supported by the Translator Services.
    /// </returns>
    public static string GetLanguagesForTranslate(string appId)
    {
      System.Text.StringBuilder sbLanguages = new System.Text.StringBuilder();
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/GetLanguagesForTranslate?appId="
        + appId;

      System.Net.HttpWebRequest httpWebRequest =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);

      System.Net.WebResponse response = null;
      try
      {
        response = httpWebRequest.GetResponse();
        using (System.IO.Stream stream = response.GetResponseStream())
        {
          System.Runtime.Serialization.DataContractSerializer dcs =
            new System.Runtime.Serialization.DataContractSerializer(
              typeof(System.Collections.Generic.List<System.String>));

          System.Collections.Generic.List<System.String> results =
            (System.Collections.Generic.List<System.String>)dcs.ReadObject(stream);

          foreach (string language in results)
          {
            if (language.Trim().Length > 0)
            {
              sbLanguages.Append(language.Trim() + ",");
            }
          }

          if (sbLanguages.Length > 1)
          {
            sbLanguages.Remove(sbLanguages.Length - 1, 1);
          }

#if false
          new Util.Debug("Languages for Translate: " + sbLanguages).Print();
#endif
        }
      }
      catch (System.Net.WebException e)
      {
        sbLanguages.Clear();

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e,
            "Failed to get languages for translate")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return sbLanguages.ToString();
    }

    /// <summary>
    /// Translates a text string from one language to another.
    /// </summary>
    /// <param name="appId">
    /// A string containing the Bing AppID.
    /// </param>
    /// <param name="text">
    /// A string representing the text to translate.
    /// </param>
    /// <param name="from">
    /// A string representing the language code of the translation text.
    /// </param>
    /// <param name="to">
    /// A string representing the language code to translate the text into.
    /// </param>
    /// <returns>A string representing the translated text</returns>
    public static string Translate(
      string appId,
      string text,
      string from,
      string to)
    {
      System.Text.StringBuilder translatedText = new System.Text.StringBuilder();
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?appId="
        + appId
        + "&text=" + System.Uri.UnescapeDataString(text)
        + "&from=" + from
        + "&to=" + to;

      System.Net.HttpWebRequest httpWebRequest =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);

      System.Net.WebResponse response = null;
      try
      {
        response = httpWebRequest.GetResponse();
        using (System.IO.Stream stream = response.GetResponseStream())
        {
          System.Runtime.Serialization.DataContractSerializer dcs =
            new System.Runtime.Serialization.DataContractSerializer(
              System.Type.GetType("System.String"));
          translatedText.Append(dcs.ReadObject(stream));
#if DEBUG
          new Util.Debug("The translated text is: '" +
            translatedText + "'.").Print();
#endif
        }
      }
      catch (System.Net.WebException e)
      {
        translatedText.Clear();

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e, "Failed to translate")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return translatedText.ToString();
    }

    /// <summary>
    /// Use the TranslateArray method to retrieve translations
    /// for multiple source texts.
    /// </summary>
    /// <param name="appId">
    /// A string containing the Bing AppID. 
    /// </param>
    /// <param name="textArray">
    /// An array containing the texts for translation.
    /// All strings should be of the same language. 
    /// </param>
    /// <param name="from">
    /// A string representing the language code to translate the text from.
    /// If left empty the response will include
    /// the result of language auto-detection.
    /// </param>
    /// <param name="to">
    /// A string representing the language code to translate the text to.
    /// </param>
    public static string TranslateArray(
      string appId,
      string[] textArray,
      string from,
      string to)
    {
      System.Text.StringBuilder translatedText = new System.Text.StringBuilder();
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/TranslateArray";
      //The request body is a xml string generated according to
      // the schema specified at http://api.microsofttranslator.com/v2/Http.svc/help.

      System.IO.StringWriter swriter = new System.IO.StringWriter();
      System.Xml.XmlTextWriter xwriter = new System.Xml.XmlTextWriter(swriter);

      xwriter.WriteStartElement("TranslateArrayRequest");

      xwriter.WriteStartElement("AppId");
      xwriter.WriteString(appId);
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("From");
      xwriter.WriteString(from);
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("Options");

      xwriter.WriteStartElement("Category");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("ContentType");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteString("text/plain");
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("ReservedFlags");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("State");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("Uri");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("User");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      xwriter.WriteEndElement();

      xwriter.WriteStartElement("Texts");
      foreach (string text in textArray)
      {
        xwriter.WriteStartElement("string");
        xwriter.WriteAttributeString("xmlns",
          "http://schemas.microsoft.com/2003/10/Serialization/Arrays");
        xwriter.WriteString(text);
        xwriter.WriteEndElement();
      }
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("To");
      xwriter.WriteString(to);
      xwriter.WriteEndElement();

      xwriter.WriteEndElement();

      xwriter.Close();
      swriter.Close();


      // create the request
      System.Net.HttpWebRequest request =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
      request.ContentType = "text/xml";
      request.Method = "POST";
      //request.Proxy = new WebProxy(""); define your proxy here if needed
      using (System.IO.Stream stream = request.GetRequestStream())
      {
        byte[] arrBytes =
          System.Text.Encoding.UTF8.GetBytes(swriter.ToString());
        stream.Write(arrBytes, 0, arrBytes.Length);
      }

      // Get the response
      System.Net.WebResponse response = null;
      try
      {
        response = request.GetResponse();
        using (System.IO.Stream stream = response.GetResponseStream())
        using (System.IO.StreamReader rdr =
          new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
        {
          // Deserialize the response
          string strResponse = rdr.ReadToEnd();
          ArrayOfTranslateArrayResponse translateResponseArray =
            TranslationDeserializer<ArrayOfTranslateArrayResponse>.Deserialize(
              new ArrayOfTranslateArrayResponse(), strResponse);

          // Print the response
          foreach (TranslateArrayResponse translateResponse in
            translateResponseArray.TranslateArrayResponse)
          {
            translatedText.Append(translateResponse.TranslatedText);
#if DEBUG
            new Util.Debug("Error = " + translateResponse.Error).Print();
            new Util.Debug("Translated text = " +
              translateResponse.TranslatedText).Print();

            int oi = 0;
            int ti = 0;
            if ((translateResponse.OriginalTextSentenceLengths != null) &&
                (translateResponse.TranslatedTextSentenceLengths != null))
            {
              int[] originalTextSentenceLengths =
                translateResponse.OriginalTextSentenceLengths.@int;
              
              int[] translatedTextSentenceLengths =
                translateResponse.TranslatedTextSentenceLengths.@int;

              for (int i = 0; i < originalTextSentenceLengths.Length; ++i)
              {
                new Util.Debug(string.Format("{0}-{1} -> {2}-{3} '{4}' ",
                  oi, originalTextSentenceLengths[i],
                  ti, translatedTextSentenceLengths[i],
                  translateResponse.TranslatedText.Substring(
                    ti, translatedTextSentenceLengths[i]))).Print();

                oi += originalTextSentenceLengths[i];
                ti += translatedTextSentenceLengths[i];
              }
            }
#endif
          }
        }
      }
      catch (System.Net.WebException e)
      {
        translatedText.Clear();

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e, "Failed to translate array")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return translatedText.ToString();
    }

    /// <summary>
    /// Retrieves an array of translations for a given language pair from the store and the MT engine.
    /// GetTranslations differs from Translate as it returns all available translations
    /// </summary>
    /// <param name="appId">
    /// A string containing the Bing AppID.
    /// </param>
    /// <param name="text">
    /// A string representing the text to translate.
    /// </param>
    /// <param name="from">
    /// A string representing the language code of the translation text.
    /// </param>
    /// <param name="to">
    /// A string representing the language code to translate the text into.
    /// </param>
    /// <param name="maxTranslations">
    /// An int representing the maximum number of translations to return.
    /// </param>
    /// <returns>
    /// Returns a GetTranslationsResponse array.
    /// Each GetTranslationsResponse has the following elements:
    /// <list type="bullet">
    /// <item>
    /// Translations: An array of matches found, stored in <see cref="TranslationMatch"/> objects.
    /// The translations may include slight variants of the original text (fuzzy matching).
    /// The translations will be sorted: 100% matches first, fuzzy matches below.
    /// </item>
    /// <item>
    /// From: If the method did not specify a From language,
    /// this will be the result of auto language detection
    /// Otherwise it will be the given From language.
    /// </item>
    /// <item>
    /// State: User state to help correlate request and response.
    /// Contains the same value as given in the TranslateOptions parameter.
    /// </item>
    /// </list>
    /// </returns>
    public static string GetTranslations(
      string appId,
      string text,
      string from,
      string to,
      int maxTranslations)
    {
      System.Text.StringBuilder translatedText = new System.Text.StringBuilder();
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/GetTranslations?appId="
        + appId
        + "&text=" + System.Uri.EscapeDataString(text)
        + "&from=" + from
        + "&to=" + to
        + "&maxTranslations=" + maxTranslations;

      System.Net.HttpWebRequest request =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
      request.ContentType = "text/xml";
      request.Method = "POST";
      //req.Proxy = new WebProxy(); define the name of your proxy here if needed
      using (System.IO.Stream stream = request.GetRequestStream()) { }

      System.Net.WebResponse response = null;
      try
      {
        response = request.GetResponse();
        using (System.IO.Stream respStream = response.GetResponseStream())
        {
          System.IO.StreamReader rdr =
            new System.IO.StreamReader(respStream, System.Text.Encoding.ASCII);
          string strResponse = rdr.ReadToEnd();

          GetTranslationsResponse getTranslationsResponse =
            TranslationDeserializer<GetTranslationsResponse>.Deserialize(
            new GetTranslationsResponse(), strResponse);

#if DEBUG
          new Util.Debug(string.Format(
            "Source Language: {0} State: {1}\n",
            getTranslationsResponse.From,
            getTranslationsResponse.State)).Print();
#endif

          foreach (TranslationMatch res in
            getTranslationsResponse.Translations)
          {
            if (res.Error != null)
            {
#if DEBUG
              new Util.Debug(string.Format("Error: {0}", res.Error)).Print();
#endif
            }
            else
            {
              translatedText.Append(res.TranslatedText);
              //translatedText.AppendLine(res.TranslatedText);

#if DEBUG
              new Util.Debug(string.Format(
                @"Source: {0} Match Degree: {1}
Translated: {2} Rating: {3} Count: {4}",
                res.MatchedOriginalText,
                res.MatchDegree,
                res.TranslatedText,
                res.Rating,
                res.Count)).Print();
#endif
            }
          }
        }
      }
      catch (System.Net.WebException e)
      {
        translatedText.Clear();

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e, "Failed to get translations")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return translatedText.ToString();
    }

    /// <summary>
    /// Use the GetTranslationsArray method to retrieve multiple translation candidates for multiple source texts.
    /// </summary>
    /// <param name="appId">
    /// A string containing the Bing AppID.
    /// </param>
    /// <param name="texts">
    /// An array containing the texts for translation. All strings should be of the same language.
    /// </param>
    /// <param name="from">
    /// A string representing the language code of the translation text.
    /// </param>
    /// <param name="to">
    /// A string representing the language code to translate the text into.
    /// </param>
    /// <param name="maxTranslations">
    /// An int representing the maximum number of translations to return.
    /// </param>
    /// <returns>
    /// Returns a GetTranslationsResponse array. Each GetTranslationsResponse has the following elements:
    /// <list type="bullet">
    /// <item>
    /// Translations: An array of matches found, stored in <see cref="TranslationMatch"/> (see below) objects.
    /// The translations may include slight variants of the original text (fuzzy matching).
    /// The translations will be sorted: 100% matches first, fuzzy matches below.
    /// </item>
    /// <item>
    /// From: If the method did not specify a From language,
    /// this will be the result of auto language detection
    /// Otherwise it will be the given From language.
    /// </item>
    /// <item>
    /// State: User state to help correlate request and response.
    /// Contains the same value as given in the TranslateOptions parameter.
    /// </item>
    /// </list>
    /// </returns>
    public static string GetTranslationsArray(
      string appId,
      string[] texts,
      string from,
      string to,
      int maxTranslations)
    {
      System.Text.StringBuilder translatedText = new System.Text.StringBuilder();
      string uri = "http://api.microsofttranslator.com/v2/Http.svc/GetTranslationsArray";

      System.IO.StringWriter swriter = new System.IO.StringWriter();
      System.Xml.XmlTextWriter xwriter = new System.Xml.XmlTextWriter(swriter);

      xwriter.WriteStartElement("GetTranslationsArrayRequest");

      xwriter.WriteStartElement("AppId");
      xwriter.WriteString(appId);
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("From");
      xwriter.WriteString(from);
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("Options");

      // Category: The only supported, and the default, option is "general"
      xwriter.WriteStartElement("Category");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      // ContentType: The only supported, and the default, option is "text/plain"
      xwriter.WriteStartElement("ContentType");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteString("text/plain");
      xwriter.WriteEndElement();

      // State: User state to help correlate request and response. The same contents will be returned in the response.
      xwriter.WriteStartElement("State");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      // Uri: Filter results by this URI. If no value is set, the default is all
      xwriter.WriteStartElement("Uri");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      // User: Filter results by this user. If no value is set, the default is all.
      xwriter.WriteStartElement("User");
      xwriter.WriteAttributeString("xmlns",
        "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2");
      xwriter.WriteEndElement();

      xwriter.WriteEndElement();

      xwriter.WriteStartElement("Texts");
      foreach (string text in texts)
      {
        xwriter.WriteStartElement("string");
        xwriter.WriteAttributeString("xmlns",
          "http://schemas.microsoft.com/2003/10/Serialization/Arrays");
        xwriter.WriteString(text);
        xwriter.WriteEndElement();
      }
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("To");
      xwriter.WriteString(to);
      xwriter.WriteEndElement();

      xwriter.WriteStartElement("MaxTranslations");
      xwriter.WriteString(maxTranslations.ToString());
      xwriter.WriteEndElement();

      xwriter.WriteEndElement();

      xwriter.Close();
      swriter.Close();

      System.Net.HttpWebRequest req =
        (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
      req.ContentType = "text/xml";
      req.Method = "POST";
      using (System.IO.Stream stream = req.GetRequestStream())
      {
        //The request body is a xml string generated according to the schema
        // specified at http://api.microsofttranslator.com/v2/Http.svc/help.
        byte[] arrBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(swriter.ToString());
        stream.Write(arrBytes, 0, arrBytes.Length);
      }

      System.Net.WebResponse response = null;
      try
      {
        response = req.GetResponse();
        using (System.IO.Stream stream = response.GetResponseStream())
        {
          System.IO.StreamReader rdr = new System.IO.StreamReader(
            stream, System.Text.Encoding.UTF8);
          string strResponse = rdr.ReadToEnd();

          ArrayOfGetTranslationsResponse getTranslationsResponseArray =
            TranslationDeserializer<ArrayOfGetTranslationsResponse>.Deserialize(
            new ArrayOfGetTranslationsResponse(), strResponse);

          foreach (GetTranslationsResponse res in
            getTranslationsResponseArray.GetTranslationsResponse)
          {
#if false
            new Util.Debug(string.Format(
              "Source Language: {0} State: {1}\n",
              res.From,
              res.State)).Print();
#endif

            foreach (TranslationMatch match in res.Translations)
            {
              if (match.Error != null)
              {
#if DEBUG
                new Util.Debug("Error: " + match.Error).Print();
#endif
              }
              else
              {
                translatedText.Append(match.TranslatedText + ".");

#if false
                new Util.Debug(string.Format(
                  @"Source: {0} Match Degree: {1}
Translated: {2} Rating: {3} Count: {4}",
                  match.MatchedOriginalText,
                  match.MatchDegree,
                  match.TranslatedText,
                  match.Rating,
                  match.Count)).Print();
#endif
              }
            }
          }
        }
      }
      catch (System.Net.WebException e)
      {
        translatedText.Clear();

#if DEBUG
        new Util.Debug(new System.Diagnostics.StackTrace(true),
          ProcessWebException(e, "Failed to get translations")).Print();
#endif
      }
      finally
      {
        if (response != null)
        {
          response.Close();
          response = null;
        }
      }
      return translatedText.ToString();
    }

    /// <summary>
    /// Utility class used for deserializing responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class TranslationDeserializer<T>
    {
      /// <summary>
      /// Deserilizes the specified response type
      /// </summary>
      /// <param name="responseType">Type of the response.</param>
      /// <param name="restResponse">The rest response.</param>
      /// <returns></returns>
      public static T Deserialize(T responseType, string restResponse)
      {
        restResponse = @"" + restResponse;

        System.Xml.Serialization.XmlSerializer serializer =
          new System.Xml.Serialization.XmlSerializer(typeof(T));

        using (System.IO.StringReader read = new System.IO.StringReader(restResponse))
        using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(read))
          responseType = (T)serializer.Deserialize(reader);

        // BindingFailure is XmlSearializer feature.
        // https://connect.microsoft.com/VisualStudio/feedback/details/88566/bindingfailure-an-assembly-failed-to-load-while-using-xmlserialization

        return responseType;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2", IsNullable = true)]
    public partial class ArrayOfTranslateArrayResponse
    {
      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute("TranslateArrayResponse", IsNullable = true)]
      public TranslateArrayResponse[] TranslateArrayResponse { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2", IsNullable = true)]
    public partial class TranslateArrayResponse
    {
      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string Error { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string From { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public ArrayOfint OriginalTextSentenceLengths { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string State { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string TranslatedText { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public ArrayOfint TranslatedTextSentenceLengths { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace =
      "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace =
      "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = true)]
    public partial class ArrayOfint
    {
      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElement("int")]
      public int[] @int { get; set; }
    }

    /// <summary>
    /// Classes for GetTranslations method deserialization
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2", IsNullable = true)]
    public partial class GetTranslationsResponse
    {
      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string From { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string State { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
      public TranslationMatch[] Translations { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2", IsNullable = true)]
    public partial class ArrayOfTranslationMatch
    {
      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute("TranslationMatch", IsNullable = true)]
      public TranslationMatch[] TranslationMatch { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2", IsNullable = true)]
    public partial class TranslationMatch
    {
      /// <summary>
      /// The number of times this translation with this rating
      /// has been selected by the users.
      /// The value will be 0 for the automatically translated response.
      /// </summary>
      public int Count { get; set; }

      /// <summary>
      /// If an error has occurred for a specific input string,
      /// the error code is stored. Otherwise the field is empty.
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string Error { get; set; }

      /// <summary>
      /// The system matches input sentences against the store,
      /// including inexact matches.
      /// MatchDegree indicates how closely the input text matches
      /// the original text found in the store.
      /// The value returned ranges from 0 to 100,
      /// where 0 is no similarity and 100 is an exact case sensitive match.
      /// </summary>
      public int MatchDegree { get; set; }

      /// <summary>
      /// Original text that was matched for this result.
      /// Only returned if the matched original text was different than the input text.
      /// Used to return the source text of a fuzzy match.
      /// Not returned for Microsoft Translator results.
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string MatchedOriginalText { get; set; }

      /// <summary>
      /// Indicates the authority of the person making the quality decision.
      /// Machine Translation results will have a rating of 5.
      /// End user submitted translations will generally have
      /// a rating of 1 to 4, whilst approved custom translations
      /// will generally have a rating of 6 to 10.
      /// </summary>
      public int Rating { get; set; }

      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
      public string TranslatedText { get; set; }
    }

    /// <summary>
    /// Class for GetTranslationsArray
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace =
      "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2", IsNullable = true)]
    public partial class ArrayOfGetTranslationsResponse
    {
      /// <summary>
      /// 
      /// </summary>
      [System.Xml.Serialization.XmlElementAttribute("GetTranslationsResponse", IsNullable = true)]
      public GetTranslationsResponse[] GetTranslationsResponse { get; set; }
    }
  }
}