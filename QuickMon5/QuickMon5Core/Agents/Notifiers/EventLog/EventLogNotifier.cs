using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    [Description("Event Log Notifier")]
    public class EventLogNotifier : NotifierAgentBase
    {
        public EventLogNotifier()
        {
            AgentConfig = new EventLogNotifierConfig();
        }

        public override void RecordMessage(AlertRaised alertRaised)
        {
            string lastStep = "";
            try
            {
                EventLogNotifierConfig currentConfig = (EventLogNotifierConfig)AgentConfig;
                if (currentConfig.MachineName.Length == 0)
                {
                    throw new Exception("Computer name not specified!");
                }
                if (currentConfig.EventSource.Length == 0)
                {
                    throw new Exception("Event source not specified!");
                }
                string currentEventSource = currentConfig.EventSource;
                string collectorName = "QuickMon Global Alert";
                string collectorAgents = "None";
                string oldState = "N/A";
                string newState = "N/A";
                string detailMessage = alertRaised.MessageRaw;
                string viaHost = "N/A";
                if (alertRaised.RaisedFor != null)
                {
                    collectorName = alertRaised.RaisedFor.Name;
                    collectorAgents = string.Format("{0} agent(s)", alertRaised.RaisedFor.CollectorAgents.Count);
                    if (alertRaised.RaisedFor.CollectorAgents.Count > 0)
                    {
                        collectorAgents += " {";
                        alertRaised.RaisedFor.CollectorAgents.ForEach(ca => collectorAgents += ca.AgentClassDisplayName + ",");
                        collectorAgents = collectorAgents.TrimEnd(',') + "}";
                    }
                    oldState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.PreviousState.State);
                    newState = Enum.GetName(typeof(CollectorState), alertRaised.RaisedFor.CurrentState.State);
                    if (alertRaised.RaisedFor.OverrideRemoteAgentHost)
                        viaHost = string.Format("{0}:{1}", alertRaised.RaisedFor.OverrideRemoteAgentHostAddress, alertRaised.RaisedFor.OverrideRemoteAgentHostPort);
                    else if (alertRaised.RaisedFor.EnableRemoteExecute)
                        viaHost = string.Format("{0}:{1}", alertRaised.RaisedFor.RemoteAgentHostAddress, alertRaised.RaisedFor.RemoteAgentHostPort);
                }
                currentEventSource = currentConfig.EventSource
                    .Replace("%CollectorName%", collectorName);

                lastStep = "Test if source exists";
                string logName = currentConfig.EventLogName;
                if (!EventLog.SourceExists(currentEventSource, currentConfig.MachineName))
                {
                    lastStep = "Attempt to create event source " + currentEventSource;
                    EventSourceCreationData escd = new EventSourceCreationData(currentEventSource, logName);
                    escd.MachineName = currentConfig.MachineName;
                    EventLog.CreateEventSource(escd);
                }
                try
                {
                    //in case some admin created the source in a different event log
                    logName = EventLog.LogNameFromSourceName(currentEventSource, currentConfig.MachineName);
                }
                catch { }
                lastStep = "Opening event log on " + currentConfig.MachineName;
                EventLog outputLog = new EventLog(logName, currentConfig.MachineName, currentEventSource);
                EventLogEntryType eventLogEntryType = (alertRaised.Level == AlertLevel.Info || alertRaised.Level == AlertLevel.Debug) ? EventLogEntryType.Information :
                    alertRaised.Level == AlertLevel.Warning ? EventLogEntryType.Warning : EventLogEntryType.Error;
                int eventID = (alertRaised.Level == AlertLevel.Info || alertRaised.Level == AlertLevel.Debug) ? currentConfig.SuccessEventID :
                    alertRaised.Level == AlertLevel.Warning ? currentConfig.WarningEventID : currentConfig.ErrorEventID;

                lastStep = "Generate output stream";

                string outputStr = string.Format("Time: {0}\r\nAlert level: {1}\r\nCollector: {2}\r\nAgents: {3}\r\nOld state: {4}\r\nCurrent state: {5}\r\nVia host: {6}\r\nDetails: {7}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Enum.GetName(typeof(AlertLevel), alertRaised.Level),
                        collectorName,
                        collectorAgents,
                        oldState,
                        newState,
                        viaHost,
                        detailMessage);

                lastStep = "Write the event log entry";
                outputLog.WriteEntry(outputStr, eventLogEntryType, eventID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in Event log notifier\r\nLast step: " + lastStep, ex);
            }
            finally
            {
                //eventLogWriteMutex.ReleaseMutex();
            }
        }
        public override AttendedOption AttendedRunOption { get { return AttendedOption.AttendedAndUnAttended; } }
    }
    public class EventLogNotifierConfig : INotifierConfig
    {
        public EventLogNotifierConfig()
        {
            MachineName = ".";
            EventLogName = "Application";
            EventSource = "QuickMon";
            SuccessEventID = 0;
            WarningEventID = 1;
            ErrorEventID = 2;
        }

        public string MachineName { get; set; }
        public string EventLogName { get; set; }
        public string EventSource { get; set; }
        public int SuccessEventID { get; set; }
        public int WarningEventID { get; set; }
        public int ErrorEventID { get; set; }

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            XmlNode eventLogNode = root.SelectSingleNode("eventLog");
            MachineName = eventLogNode.ReadXmlElementAttr("computer", ".");
            EventLogName = eventLogNode.ReadXmlElementAttr("eventLog", "Application");
            EventSource = eventLogNode.ReadXmlElementAttr("eventSource", "QuickMon");
            SuccessEventID = int.Parse(eventLogNode.ReadXmlElementAttr("successEventID", "0"));
            WarningEventID = int.Parse(eventLogNode.ReadXmlElementAttr("warningEventID", "0"));
            ErrorEventID = int.Parse(eventLogNode.ReadXmlElementAttr("errorEventID", "0"));
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode eventLogNode = root.SelectSingleNode("eventLog");
            eventLogNode.SetAttributeValue("computer", MachineName);
            eventLogNode.SetAttributeValue("eventLog", EventLogName);
            eventLogNode.SetAttributeValue("eventSource", EventSource);
            eventLogNode.SetAttributeValue("successEventID", SuccessEventID);
            eventLogNode.SetAttributeValue("warningEventID", WarningEventID);
            eventLogNode.SetAttributeValue("errorEventID", ErrorEventID);
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><eventLog computer=\".\" eventLog=\"Application\" eventSource=\"QuickMon\" successEventID=\"0\" warningEventID=\"1\" errorEventID=\"2\" /></config>";
        }
        public string ConfigSummary
        {
            get
            {
                string summary = string.Format("Machine: {0}, Log: {1}, Source: {2}, Success: {3}, Warning: {4}, Error: {5}",
                    MachineName, EventLogName, EventSource, SuccessEventID, WarningEventID, ErrorEventID);
                return summary;
            }
        }
        #endregion
    }
}
