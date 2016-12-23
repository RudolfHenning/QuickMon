using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
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
