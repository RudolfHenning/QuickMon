using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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
                string collectorName = alertRaised.RaisedFor == null ? "" : alertRaised.RaisedFor.Name;
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
}
