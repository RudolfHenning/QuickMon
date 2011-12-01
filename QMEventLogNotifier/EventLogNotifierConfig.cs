using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class EventLogNotifierConfig
    {
        public EventLogNotifierConfig()
        {
            MachineName = ".";
            EventSource = "QuickMon";
        }
        public string MachineName { get; set; }
        public string EventSource { get; set; }

        public void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;

            XmlNode eventLogNode = root.SelectSingleNode("eventLog");
            MachineName = eventLogNode.ReadXmlElementAttr("computer", ".");
            EventSource = eventLogNode.ReadXmlElementAttr("eventSource", "QuickMon");            
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.QMEventLogNotifierDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode eventLogNode = root.SelectSingleNode("eventLog");
            eventLogNode.SetAttributeValue("computer", MachineName);
            eventLogNode.SetAttributeValue("eventSource", EventSource);
            
            return config.OuterXml;
        }
    }
}
