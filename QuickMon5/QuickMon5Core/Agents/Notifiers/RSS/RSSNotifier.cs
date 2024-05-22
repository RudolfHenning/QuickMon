using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    [Description("RSS Notifier")]
    public class RSSNotifier : NotifierAgentBase
    {
        public RSSNotifier()
        {
            AgentConfig = new RSSNotifierConfig();
        }

        private InMemoryRSSDocument rssDocument = null;
        private static string lockObject = "";

        public override void RecordMessage(AlertRaised alertRaised)
        {
            RSSNotifierConfig currentConfig = (RSSNotifierConfig)AgentConfig;
            string lastStep = "";
            try
            {
                lock (lockObject)
                {
                    if (rssDocument == null)
                    {
                        LoadRSSDocument(currentConfig);
                    }
                }
                string guid = Guid.NewGuid().ToString();
                string alertLevel = alertRaised.Level.ToString();
                string previousState = alertRaised.RaisedFor == null || alertRaised.RaisedFor.PreviousState == null ? "" :  alertRaised.RaisedFor.PreviousState.State.ToString();
                string currentState = alertRaised.RaisedFor == null || alertRaised.RaisedFor.PreviousState == null ? "" : alertRaised.RaisedFor.CurrentState.State.ToString();
                string collectorName = alertRaised.RaisedFor == null ? "" : alertRaised.RaisedFor.NameFormatted;
                string lineTitle = currentConfig.LineTitle
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", alertLevel)
                    .Replace("%PreviousState%", previousState)
                    .Replace("%CurrentState%", currentState)
                    .Replace("%CollectorName%", collectorName);
                string lineCategory = currentConfig.LineCategory
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", alertLevel)
                    .Replace("%PreviousState%", previousState)
                    .Replace("%CurrentState%", currentState)
                    .Replace("%CollectorName%", collectorName);
                string lineDetails = currentConfig.LineDescription
                    .Replace("%Details%", alertRaised.MessageHTML)
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", alertLevel)
                    .Replace("%PreviousState%", previousState)
                    .Replace("%CurrentState%", currentState)
                    .Replace("%CollectorName%", collectorName);
                string lineLink = currentConfig.LineLink
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", alertLevel)
                    .Replace("%PreviousState%", previousState)
                    .Replace("%CurrentState%", currentState)
                    .Replace("%CollectorName%", collectorName)
                    .Replace("%LineGuid%", guid);

                rssDocument.Lines.Add(
                    new InMemoryRSSDocumentLine()
                    {
                        Title = lineTitle,
                        PubDate = DateTime.Now,
                        GUID = guid,
                        Category = lineCategory,
                        Description = lineDetails,
                        LineLink = lineLink
                    }
                    );
                rssDocument.SaveRssDocument();
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in RSS file notifier '{0}'\r\nLast step: " + lastStep, ex);
            }
        }

        public override AttendedOption AttendedRunOption
        {
            get { return AttendedOption.AttendedAndUnAttended; }
        }

        private void LoadRSSDocument(RSSNotifierConfig currentConfig)
        {
            try
            {
                rssDocument = new InMemoryRSSDocument();
                rssDocument.RSSFilePath = currentConfig.RSSFilePath;
                rssDocument.KeepEntriesDays = currentConfig.KeepEntriesDays;
                rssDocument.Title = currentConfig.Title;
                rssDocument.Link = currentConfig.Link;
                rssDocument.Description = currentConfig.Description;
                rssDocument.Language = currentConfig.Language;
                rssDocument.Generator = currentConfig.Generator;
                rssDocument.PublicationDate = DateTime.Now;

                //lock (lockObject)
                {
                    if (System.IO.File.Exists(currentConfig.RSSFilePath))
                    {
                        try
                        {
                            rssDocument.LoadExistingLines(currentConfig.RSSFilePath);
                        }
                        catch
                        {
                            rssDocument.Lines = new List<InMemoryRSSDocumentLine>();
                        }
                    }
                    else
                    {
                        rssDocument.Lines = new List<InMemoryRSSDocumentLine>();
                    }
                }
            }
            catch (System.IO.IOException ioex)
            {
                rssDocument = null;
                throw new Exception(string.Format("Could not create rss file {0}", currentConfig.RSSFilePath), ioex);
            }
        }
    }
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
        public string LineLink { get; set; }

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
            LineLink = rssConfigNode.ReadXmlElementAttr("lineLink", "");
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode root = config.SelectSingleNode("config/rss");
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
            root.SetAttributeValue("lineLink", LineLink);
            return config.OuterXml;
        }

        public string GetDefaultOrEmptyXml()
        {
            return "<config><rss rssFilePath=\"%LOCALAPPDATA%\\Hen IT\\QuickMon 5\\QuickMon.rss\" title=\"QuickMon RSS alerts\" link=\"\" description=\"\" " +
                "keepEntriesDays=\"10\" language=\"en-us\" generator=\"QuickMon RSS notifier\" " +
                "lineTitle=\"%CollectorName% - %AlertLevel%\" lineCategory=\"%CurrentState%, %CollectorName%\" lineLink=\"\" lineDescription=\"&lt;b&gt;Date Time:&lt;/b&gt; %DateTime%&lt;br/&gt;\r\n" +
                "&lt;b&gt;Current state:&lt;/b&gt; %CurrentState%&lt;br/&gt;\r\n" +
                "&lt;b&gt;Collector:&lt;/b&gt; %CollectorName%&lt;br/&gt;\r\n" +
                "&lt;b&gt;Details&lt;/b&gt;&lt;br/&gt;\r\n" +
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
