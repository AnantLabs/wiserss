using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using org.xml.sax;
using de.l3s.boilerpipe;
using de.l3s.boilerpipe.document;
using de.l3s.boilerpipe.extractors;
using de.l3s.boilerpipe.sax;

namespace Rss
{
  /// <summary>
  /// 
  /// </summary>
  public class Boilerpipe
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="p_url"></param>
    /// <returns></returns>
    public static string UsingSAX(string p_url)
    {
      java.net.URL url = new java.net.URL(p_url);

      InputSource inputSource = HTMLFetcher.fetch(url).toInputSource();

      BoilerpipeSAXInput saxInput = new BoilerpipeSAXInput(inputSource);
      TextDocument doc = saxInput.getTextDocument();

      // You have the choice between different Extractors

      //Console.WriteLine(DefaultExtractor.INSTANCE.getText(doc))
      return ArticleExtractor.INSTANCE.getText(doc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p_url"></param>
    /// <returns></returns>
    public static string Oneliner(string p_url)
    {
      java.net.URL url = new java.net.URL(p_url);
      string text = string.Empty;

      try
      {
        // This can also be done in one line:
        text = ArticleExtractor.INSTANCE.getText(url);
      }
      catch (System.Exception) { }
      // Also try other extractors!
      //Console.WriteLine(DefaultExtractor.INSTANCE.getText(url));
      //Console.WriteLine(CommonExtractors.CANOLA_EXTRACTOR.getText(url));

      return text;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p_url"></param>
    public static void ImageExtractor(string p_url)
    {
      java.net.URL url = new java.net.URL(p_url);
      
      // choose from a set of useful BoilerpipeExtractors...
      BoilerpipeExtractor extractor = CommonExtractors.ARTICLE_EXTRACTOR;
      //BoilerpipeExtractor extractor = CommonExtractors.DEFAULT_EXTRACTOR;
      //BoilerpipeExtractor extractor = CommonExtractors.CANOLA_EXTRACTOR;
      //BoilerpipeExtractor extractor = CommonExtractors.LARGEST_CONTENT_EXTRACTOR;
      
      ImageExtractor ie = Rss.ImageExtractor.INSTANCE;

      List<string> imgUrls = ie.getEnclosedImages(url, extractor); // ie.process(url, extractor);

      // automatically sorts them by decreasing area, i.e. most probable true positives come first
      //java.util.Collections.sort(imgUrls);

      foreach (string img in imgUrls)
      {
        Console.WriteLine("* " + img);
      }
    }

    private static void HTMLHighlight(string p_url)
    {
      java.net.URL url = new java.net.URL(p_url);
      //  "http://research.microsoft.com/en-us/um/people/ryenw/hcir2010/challenge.html"
      // "http://boilerpipe-web.appspot.com/"

      // choose from a set of useful BoilerpipeExtractors...
      BoilerpipeExtractor extractor = CommonExtractors.ARTICLE_EXTRACTOR;
      //BoilerpipeExtractor extractor = CommonExtractors.DEFAULT_EXTRACTOR;
      //BoilerpipeExtractor extractor = CommonExtractors.CANOLA_EXTRACTOR;
      //BoilerpipeExtractor extractor = CommonExtractors.LARGEST_CONTENT_EXTRACTOR;

      // choose the operation mode (i.e., highlighting or extraction)
      HTMLHighlighter hh = HTMLHighlighter.newHighlightingInstance();
      //HTMLHighlighter hh = HTMLHighlighter.newExtractingInstance();

      java.io.PrintWriter @out = new java.io.PrintWriter("highlighted.html", "UTF-8");
      @out.println("<base href=\"" + url + "\" >");
      @out.println("<meta http-equiv=\"Content-Type\" content=\"text-html; charset=utf-8\" />");
      @out.println(hh.process(url, extractor));
      @out.close();

      Console.WriteLine("Now open highlighted.html in your web browser");
    }
  }
}
