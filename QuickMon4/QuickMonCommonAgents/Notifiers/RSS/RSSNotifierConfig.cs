using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    public class RSSNotifierConfig : INotifierConfig
    {
        public string RSSFilePath { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Generator { get; set; }
        public int KeepEntriesDays { get; set; }
        public string LineTitle { get; set; }
        public string LineCategory { get; set; }
        public string LineDescription { get; set; }

        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            XmlNode rssConfigNode = root.SelectSingleNode("rss");
            RSSFilePath = rssConfigNode.ReadXmlElementAttr("rssFilePath", "rss.xml");
            Title = rssConfigNode.ReadXmlElementAttr("title", "QuickMon RSS alerts");
            Link = rssConfigNode.ReadXmlElementAttr("link", "");
            Description = rssConfigNode.ReadXmlElementAttr("description", "");
            Language = rssConfigNode.ReadXmlElementAttr("language", "en-us");
            Generator = rssConfigNode.ReadXmlElementAttr("generator", "QuickMon RSS notifier");
            KeepEntriesDays = int.Parse(rssConfigNode.ReadXmlElementAttr("keepEntriesDays", "10"));
            LineTitle = rssConfigNode.ReadXmlElementAttr("lineTitle", "%CollectorName% - %AlertLevel%");
            LineCategory = rssConfigNode.ReadXmlElementAttr("lineCategory", "%CurrentState%, %CollectorType%");            
            LineDescription = rssConfigNode.ReadXmlElementAttr("lineDescription", "<b>Date Time:</b> %DateTime%\r\n" +
                                                                         "<b>Current state:</b> %CurrentState%\r\n" +
                                                                         "<b>Collector:</b> %CollectorType%\r\n" +
                                                                         "<b>Details</b>\r\n" +
                                                                         "%Details%"); 
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode root = config.SelectSingleNode("config/logFile");
            root.Attributes["rssFilePath"].Value = RSSFilePath;
            root.Attributes["title"].Value = Title;
            root.Attributes["link"].Value = Link;
            root.Attributes["description"].Value = Description;
            root.Attributes["language"].Value = Language;
            root.Attributes["generator"].Value = Generator;
            root.SetAttributeValue("keepEntriesDays", KeepEntriesDays);
            root.Attributes["lineTitle"].Value = LineTitle;
            root.Attributes["lineCategory"].Value = LineCategory;
            root.Attributes["lineDescription"].Value = LineDescription;
            return config.OuterXml;
        }

        public string GetDefaultOrEmptyXml()
        {
            return "<config><rss rssFilePath=\"%LOCALAPPDATA%\\Hen IT\\QuickMon 4\\QuickMon.rss\" title=\"QuickMon RSS alerts\" link=\"\" description=\"\" " +
                "keepEntriesDays=\"10\" language=\"en-us\" generator=\"QuickMon RSS notifier\" " +
                "lineTitle=\"%CollectorName% - %AlertLevel%\" lineCategory=\"%CurrentState%, %CollectorType%\" lineDescription=\"&lt;b&gt;Date Time:&lt;/b&gt; %DateTime%\r\n" +
                                                                         "&lt;b&gt;Current state:&lt;/b&gt; %CurrentState%\r\n" +
                                                                         "&lt;b&gt;Collector:&lt;/b&gt; %CollectorType%\r\n" +
                                                                         "&lt;b&gt;Details&lt;/b&gt;\r\n" +
                                                                         "%Details%\" /></config>";
        }

        public string ConfigSummary
        {
            get
            {
                string summary = "RSS File: '" + RSSFilePath;
                summary += "', Title: " + Title;
                return summary;
            } 
        }
    }
}
