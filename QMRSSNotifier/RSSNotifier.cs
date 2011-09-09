using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;

///http://www.petefreitag.com/item/465.cfm
///http://www.codeproject.com/KB/XML/reading_writing_RSS_feeds.aspx
///http://www.rss-specifications.com/

namespace QuickMon
{
    public class RSSNotifier : NotifierBase
    {
        private RSSNotifierConfig rssConfig = new RSSNotifierConfig();
        private Mutex rssWriteMutex = new Mutex();
        private InMemoryRSSDocument rssDocument = null;

        public override void RecordMessage(AlertLevel alertLevel, string collectorType, string category, MonitorStates oldState, MonitorStates newState, CollectorMessage collectorMessage)
        {
            string lastStep = "";
            try
            {
                rssWriteMutex.WaitOne();
                if (rssDocument == null)
                {
                    LoadRSSDocument();
                }
                string lineTitle = rssConfig.LineTitle
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", alertLevel.ToString())
                    .Replace("%PreviousState%", oldState.ToString())
                    .Replace("%CurrentState%", newState.ToString())
                    .Replace("%CollectorName%", category)
                    .Replace("%CollectorType%", collectorType);
                string lineCategory = rssConfig.LineCategory
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", alertLevel.ToString())
                    .Replace("%PreviousState%", oldState.ToString())
                    .Replace("%CurrentState%", newState.ToString())
                    .Replace("%CollectorName%", category)
                    .Replace("%CollectorType%", collectorType);
                string lineDetails = rssConfig.LineDescription
                    .Replace("%Details%", collectorMessage.HtmlText)
                    .Replace("%DateTime%", DateTime.Now.ToString("F"))
                    .Replace("%AlertLevel%", alertLevel.ToString())
                    .Replace("%PreviousState%", oldState.ToString())
                    .Replace("%CurrentState%", newState.ToString())
                    .Replace("%CollectorName%", category)
                    .Replace("%CollectorType%", collectorType);

                rssDocument.Lines.Add(
                    new InMemoryRSSDocumentLine()
                    {
                        Title = lineTitle,
                        PubDate = DateTime.Now,
                        //GUID = Guid.NewGuid().ToString(),
                        Category = lineCategory,
                        Description = lineDetails //.Replace("\r\n", "<br/>")
                    }
                    );
                rssDocument.SaveRssDocument();
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in rss notifier\r\nLast step: " + lastStep, ex);
            }
            finally
            {
                rssWriteMutex.ReleaseMutex();
            }
        }

        private void LoadRSSDocument()
        {
            try
            {
                rssDocument = new InMemoryRSSDocument();
                rssDocument.RSSFilePath = rssConfig.RSSFilePath;
                rssDocument.KeepEntriesDays = rssConfig.KeepEntriesDays;
                rssDocument.Title = rssConfig.Title;
                rssDocument.Link = rssConfig.Link;
                rssDocument.Description = rssConfig.Description;
                rssDocument.Language = rssConfig.Language;
                rssDocument.Generator = rssConfig.Generator;
                rssDocument.PublicationDate = DateTime.Now;

                if (System.IO.File.Exists(rssConfig.RSSFilePath))
                {                    
                    rssDocument.LoadExistingLines(rssConfig.RSSFilePath);
                }
                else
                {                       
                    rssDocument.Lines = new List<InMemoryRSSDocumentLine>();
                }
            }
            catch (System.IO.IOException ioex)
            {
                rssDocument = null;
                throw new Exception(string.Format("Could not create rss file {0}", rssConfig.RSSFilePath), ioex);
            }
        }

        public override void OpenViewer()
        {
            throw new NotImplementedException();
        }
        public override bool HasViewer
        {
            get { return false; }
        }
        public override string ConfigureAgent(string config)
        {
            XmlDocument configXml = new XmlDocument();
            if (config.Length > 0)
                configXml.LoadXml(config);
            else
            {
                configXml.LoadXml(Properties.Resources.RSSFeedConfigTemplate_xml);
            }
            ReadConfiguration(configXml);
            EditConfig editConfig = new EditConfig();
            editConfig.RSSConfig = rssConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rssConfig = editConfig.RSSConfig;
                configXml = new XmlDocument();
                configXml.LoadXml(Properties.Resources.RSSFeedConfigTemplate_xml);
                XmlElement root = configXml.DocumentElement;
                XmlNode rssConfigNode = root.SelectSingleNode("rssConfig");
                rssConfigNode.SetAttributeValue("rssFilePath", rssConfig.RSSFilePath);
                rssConfigNode.SetAttributeValue("title", rssConfig.Title);
                rssConfigNode.SetAttributeValue("link", rssConfig.Link);
                rssConfigNode.SetAttributeValue("description", rssConfig.Description);
                rssConfigNode.SetAttributeValue("language", rssConfig.Language);
                rssConfigNode.SetAttributeValue("generator", rssConfig.Generator);
                rssConfigNode.SetAttributeValue("keepEntriesDays", rssConfig.KeepEntriesDays.ToString());
                rssConfigNode.SetAttributeValue("lineTitle", rssConfig.LineTitle);
                rssConfigNode.SetAttributeValue("lineCategory", rssConfig.LineCategory);
                //rssConfigNode.SetAttributeValue("lineComments", rssConfig.LineComments);
                rssConfigNode.SetAttributeValue("lineDescription", rssConfig.LineDescription);
                config = configXml.OuterXml;
            }
            return config;
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.RSSFeedConfigTemplate_xml;
        }
        public override void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            XmlNode rssConfigNode = root.SelectSingleNode("rssConfig");
            rssConfig.RSSFilePath = rssConfigNode.ReadXmlElementAttr("rssFilePath", "rss.xml");
            rssConfig.Title = rssConfigNode.ReadXmlElementAttr("title", "QuickMon RSS alerts");
            rssConfig.Link = rssConfigNode.ReadXmlElementAttr("link", "");
            rssConfig.Description = rssConfigNode.ReadXmlElementAttr("description", "");
            rssConfig.Language = rssConfigNode.ReadXmlElementAttr("language", "en-us");
            rssConfig.Generator = rssConfigNode.ReadXmlElementAttr("generator", "QuickMon RSS notifier");
            rssConfig.KeepEntriesDays = int.Parse(rssConfigNode.ReadXmlElementAttr("keepEntriesDays", "10"));
            rssConfig.LineTitle = rssConfigNode.ReadXmlElementAttr("lineTitle", "%CollectorName% - %AlertLevel%");
            rssConfig.LineCategory = rssConfigNode.ReadXmlElementAttr("lineCategory", "%CurrentState%, %CollectorType%");
            //rssConfig.LineComments = rssConfigNode.ReadXmlElementAttr("lineComments", "%CollectorType%");
            rssConfig.LineDescription = rssConfigNode.ReadXmlElementAttr("lineDescription", "<b>Date Time:</b> %DateTime%\r\n" +
                                                                         "<b>Current state:</b> %CurrentState%\r\n" +
                                                                         "<b>Collector:</b> %CollectorType%\r\n" +
                                                                         "<b>Details</b>\r\n" +
                                                                         "%Details%");    
        }
    }
}
