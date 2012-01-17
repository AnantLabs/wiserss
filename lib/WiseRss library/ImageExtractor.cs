using de.l3s.boilerpipe;

namespace Rss
{
#pragma warning disable 1591
  [System.CLSCompliant(false)]
  public class ImageExtractor
  {
    public static ImageExtractor INSTANCE = new ImageExtractor();

    public System.Collections.Generic.List<System.String> getEnclosedImages(
      de.l3s.boilerpipe.document.TextDocument doc,
      System.String origHTML)
    {
      return getEnclosedImages(doc, new org.xml.sax.InputSource(
        new java.io.StringReader(origHTML)));
    }

    public System.Collections.Generic.List<System.String> getEnclosedImages(
      de.l3s.boilerpipe.document.TextDocument doc,
      org.xml.sax.InputSource inputSource)
    {
      Implementation implementation = new Implementation();
      implementation.process(doc, inputSource);
      return implementation.linksHighlight;
    }

    public System.Collections.Generic.List<System.String> getEnclosedImages(
      java.net.URL url, BoilerpipeExtractor extractor)
    {
      de.l3s.boilerpipe.sax.HTMLDocument htmlDoc =
        de.l3s.boilerpipe.sax.HTMLFetcher.fetch(url);

      de.l3s.boilerpipe.document.TextDocument doc =
        new de.l3s.boilerpipe.sax.BoilerpipeSAXInput(
          htmlDoc.toInputSource()).getTextDocument();

      extractor.process(doc);
      org.xml.sax.InputSource inputSource = htmlDoc.toInputSource();
      return getEnclosedImages(doc, inputSource);
    }

    public class Implementation : org.apache.xerces.parsers.AbstractSAXParser,
      org.xml.sax.ContentHandler
    {
      public System.Collections.Generic.List<System.String> linksHighlight =
        new System.Collections.Generic.List<System.String>();

      private System.Collections.Generic.List<System.String> linksBuffer =
        new System.Collections.Generic.List<System.String>();

      public int inIgnorableElement = 0;
      private int characterElementIdx = 0;
      private java.util.BitSet contentBitSet = new java.util.BitSet();

      private bool inHighlight = false;

      public Implementation()
        : base(new org.cyberneko.html.HTMLConfiguration())
      {
        setContentHandler(this);
      }

      public void process(de.l3s.boilerpipe.document.TextDocument doc,
        org.xml.sax.InputSource inputSource)
      {
        for (int i = 0; i < doc.getTextBlocks().size(); ++i)
        {
          de.l3s.boilerpipe.document.TextBlock block =
            doc.getTextBlocks().get(i) as de.l3s.boilerpipe.document.TextBlock;

          if (block.isContent())
          {
            java.util.BitSet bs = block.getContainedTextElements();
            if (bs != null)
            {
              contentBitSet.or(bs);
            }
          }
        }

        try
        {
          parse(inputSource);
        }
        catch (org.xml.sax.SAXException e)
        {
          throw new BoilerpipeProcessingException(e);
        }
        catch (java.io.IOException e)
        {
          throw new BoilerpipeProcessingException(e);
        }
      }

      public void endDocument() { }
      public void endPrefixMapping(System.String prefix) { }
      public void ignorableWhitespace(char[] ch, int start, int length) { }
      public void processingInstruction(System.String target, System.String data) { }
      public void setDocumentLocator(org.xml.sax.Locator locator) { }
      public void skippedEntity(System.String name) { }
      public void startDocument() { }

      public void startElement(System.String uri, System.String localName,
        System.String qName, org.xml.sax.Attributes atts)
      {
        if (!TAG_ACTIONS.ContainsKey(localName)) { return; }

        TagAction ta = TAG_ACTIONS[localName];
        if (ta != null)
        {
          ta.beforeStart(this, localName);
        }

        try
        {
          if (inIgnorableElement == 0)
          {
            if (inHighlight && "IMG".Equals(localName.ToUpper()))
            {
              System.String src = atts.getValue("src");
              if (src != null && src.Length > 0)
              {
                linksBuffer.Add(src);
              }
            }
          }
        }
        finally
        {
          if (ta != null)
          {
            ta.afterStart(this, localName);
          }
        }
      }

      public void endElement(System.String uri, System.String localName,
        System.String qName)
      {
        if (!TAG_ACTIONS.ContainsKey(localName)) { return; }

        TagAction ta = TAG_ACTIONS[localName];
        if (ta != null)
        {
          ta.beforeEnd(this, localName);
        }

        try
        {
          if (inIgnorableElement == 0)
          {
            //
          }
        }
        finally
        {
          if (ta != null)
          {
            ta.afterEnd(this, localName);
          }
        }
      }

      public void characters(char[] ch, int start, int length)
      {
        characterElementIdx++;
        if (inIgnorableElement == 0)
        {
          bool highlight = contentBitSet.get(characterElementIdx);
          if (!highlight)
          {
            if (length == 0)
            {
              return;
            }
            bool justWhitespace = true;
            for (int i = start; i < start + length; i++)
            {
              if (!char.IsWhiteSpace(ch[i]))
              {
                justWhitespace = false;
                break;
              }
            }
            if (justWhitespace)
            {
              return;
            }
          }

          inHighlight = highlight;
          if (inHighlight)
          {
            linksHighlight.AddRange(linksBuffer);
            linksBuffer.Clear();
          }
        }
      }

      public void startPrefixMapping(System.String prefix, System.String uri) { }
    }

    public static TagAction TA_IGNORABLE_ELEMENT = new TagAction();

    public class TagAction : TagActionAbstract
    {
      public override void beforeStart(Implementation instance, System.String localName)
      {
        instance.inIgnorableElement++;
      }

      public override void afterEnd(Implementation instance, System.String localName)
      {
        instance.inIgnorableElement--;
      }
    }

    public static System.Collections.Generic.IDictionary<System.String, TagAction> TAG_ACTIONS =
      new System.Collections.Generic.Dictionary<System.String, TagAction>()
      {
        {"STYLE", TA_IGNORABLE_ELEMENT},
        {"SCRIPT", TA_IGNORABLE_ELEMENT},
        {"OPTION", TA_IGNORABLE_ELEMENT},
        {"NOSCRIPT", TA_IGNORABLE_ELEMENT},
        {"OBJECT", TA_IGNORABLE_ELEMENT},
        {"EMBED", TA_IGNORABLE_ELEMENT},
        {"APPLET", TA_IGNORABLE_ELEMENT},
        {"LINK", TA_IGNORABLE_ELEMENT},
        {"HEAD", TA_IGNORABLE_ELEMENT}
      };

    public abstract class TagActionAbstract
    {
      public virtual void beforeStart(Implementation instance, System.String localName) { }
      public virtual void afterStart(Implementation instance, System.String localName) { }
      public virtual void beforeEnd(Implementation instance, System.String localName) { }
      public virtual void afterEnd(Implementation instance, System.String localName) { }
    }
  }
#pragma warning restore 1591
}