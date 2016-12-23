using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    internal class InMemoryRSSDocument
    {
        public string RSSFilePath { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Generator { get; set; }
        public DateTime PublicationDate { get; set; }
        public int KeepEntriesDays { get; set; }

        public List<InMemoryRSSDocumentLine> Lines = new List<InMemoryRSSDocumentLine>();

        public void LoadExistingLines(string rssFilePath)
        {
            XmlDocument rsFeed = new XmlDocument();
            rsFeed.Load(rssFilePath);
            Lines = new List<InMemoryRSSDocumentLine>();

            XmlNodeList existingitems = rsFeed.SelectNodes("rss/channel/item");
            foreach (XmlElement lineItem in existingitems)
            {
                string pubDateStr = lineItem.SelectSingleNode("pubDate").InnerText;
                DateTime pubDate = DateTime.Parse(pubDateStr);
                string categories = "";
                foreach (XmlElement catNote in lineItem.SelectNodes("category"))
                {
                    categories += catNote.InnerText + ",";
                }
                categories = categories.Trim(',');
                Lines.Add(
                    new InMemoryRSSDocumentLine()
                    {
                        Title = lineItem.SelectSingleNode("title").InnerText,
                        PubDate = pubDate,
                        GUID = lineItem.SelectSingleNode("guid").InnerText,
                        Category = categories,
                        //Comments = lineItem.SelectSingleNode("comments").InnerText,
                        Description = lineItem.SelectSingleNode("description").InnerText
                    }
                    );
            }
        }

        public void SaveRssDocument()
        {
            XmlTextWriter rssFeed = new XmlTextWriter(RSSFilePath, Encoding.UTF8);
            rssFeed.Formatting = Formatting.Indented;
            rssFeed.WriteStartDocument();
            rssFeed.WriteStartElement("rss");
            rssFeed.WriteAttributeString("version", "2.0");
            rssFeed.WriteStartElement("channel");
            rssFeed.WriteElementString("title", Title);
            rssFeed.WriteElementString("link", Link);
            rssFeed.WriteElementString("description", Description);
            rssFeed.WriteElementString("language", Language);
            rssFeed.WriteElementString("pubDate", PublicationDate.ToUniversalTime().ToString("r"));
            rssFeed.WriteElementString("Generator", Generator);
            rssFeed.WriteElementString("ttl", "1");

            foreach (InMemoryRSSDocumentLine line in (from l in Lines
                                                      where l.PubDate.AddDays(KeepEntriesDays) > DateTime.Now
                                                      orderby l.PubDate descending
                                                      select l))
            {
                rssFeed.WriteStartElement("item");
                rssFeed.WriteElementString("title", line.Title);
                rssFeed.WriteElementString("link", line.LineLink);                
                rssFeed.WriteElementString("guid", line.GUID);
                rssFeed.WriteElementString("pubDate", line.PubDate.ToUniversalTime().ToString("r")); //ToString("yyyy MMM dd HH:mm:ss"));
                if (line.Category != null && line.Category.Length > 0)
                    foreach (string category in line.Category.Split(','))
                    {
                        rssFeed.WriteElementString("category", category.Trim());
                    }
                //rssFeed.WriteElementString("comments", line.Comments);
                rssFeed.WriteStartElement("description");
                rssFeed.WriteCData(line.Description);
                rssFeed.WriteEndElement();
                rssFeed.WriteEndElement();
            }

            rssFeed.WriteEndElement();
            rssFeed.WriteEndElement();
            rssFeed.WriteEndDocument();
            rssFeed.Flush();
            rssFeed.Close();
        }
    }
    internal class InMemoryRSSDocumentLine
    {
        public string Title { get; set; }
        public DateTime PubDate { get; set; }
        public string GUID { get; set; }
        public string Category { get; set; }
        //public string Comments { get; set; }
        public string Description { get; set; }
        public string LineLink { get; set; }
    }
}
