using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class EventLogCollectorConfig : ICollectorConfig
    {
        public EventLogCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement logNode in root.SelectNodes("eventlogs/log"))
            {
                EventLogCollectorEntry eventLogEntry = new EventLogCollectorEntry();
                eventLogEntry.Computer = logNode.ReadXmlElementAttr("computer", "");
                eventLogEntry.EventLog = logNode.ReadXmlElementAttr("eventLog", "");
                eventLogEntry.TypeInfo = bool.Parse(logNode.ReadXmlElementAttr("typeInfo", "False"));
                eventLogEntry.TypeWarn = bool.Parse(logNode.ReadXmlElementAttr("typeWarn", "True"));
                eventLogEntry.TypeErr = bool.Parse(logNode.ReadXmlElementAttr("typeErr", "True"));
                eventLogEntry.ContainsText = bool.Parse(logNode.ReadXmlElementAttr("containsText", "False"));
                eventLogEntry.UseRegEx = logNode.ReadXmlElementAttr("useRegEx", false);
                eventLogEntry.TextFilter = logNode.ReadXmlElementAttr("textFilter", "");
                eventLogEntry.WithInLastXEntries = int.Parse(logNode.ReadXmlElementAttr("withInLastXEntries", "100"));
                eventLogEntry.WithInLastXMinutes = int.Parse(logNode.ReadXmlElementAttr("withInLastXMinutes", "60"));
                eventLogEntry.WarningValue = int.Parse(logNode.ReadXmlElementAttr("warningValue", "1"));
                eventLogEntry.ErrorValue = int.Parse(logNode.ReadXmlElementAttr("errorValue", "10"));
                eventLogEntry.Sources = new List<string>();

                foreach (XmlElement sourceNode in logNode.SelectNodes("sources/source"))
                {
                    eventLogEntry.Sources.Add(sourceNode.InnerText);
                }
                foreach (XmlElement eventIdNode in logNode.SelectNodes("eventIds/eventId"))
                {
                    if (eventIdNode.InnerText.IsInteger())
                        eventLogEntry.EventIds.Add(int.Parse(eventIdNode.InnerText));
                }

                Entries.Add(eventLogEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode eventLogsNode = root.SelectSingleNode("eventlogs");
            eventLogsNode.InnerXml = "";

            foreach (EventLogCollectorEntry eventLogEntry in Entries)
            {
                XmlElement logNode = config.CreateElement("log");
                logNode.SetAttributeValue("computer", eventLogEntry.Computer);
                logNode.SetAttributeValue("eventLog", eventLogEntry.EventLog);
                logNode.SetAttributeValue("typeInfo", eventLogEntry.TypeInfo);
                logNode.SetAttributeValue("typeWarn", eventLogEntry.TypeWarn);
                logNode.SetAttributeValue("typeErr", eventLogEntry.TypeErr);
                logNode.SetAttributeValue("containsText", eventLogEntry.ContainsText);
                logNode.SetAttributeValue("useRegEx", eventLogEntry.UseRegEx);
                logNode.SetAttributeValue("textFilter", eventLogEntry.TextFilter);
                logNode.SetAttributeValue("withInLastXEntries", eventLogEntry.WithInLastXEntries);
                logNode.SetAttributeValue("withInLastXMinutes", eventLogEntry.WithInLastXMinutes);
                logNode.SetAttributeValue("warningValue", eventLogEntry.WarningValue);
                logNode.SetAttributeValue("errorValue", eventLogEntry.ErrorValue);

                XmlElement sourcesNode = config.CreateElement("sources");
                foreach (string source in eventLogEntry.Sources)
                {
                    sourcesNode.AppendElementWithText("source", source);
                }
                logNode.AppendChild(sourcesNode);

                XmlElement eventIdsNode = config.CreateElement("eventIds");
                foreach (int eventId in eventLogEntry.EventIds)
                {
                    eventIdsNode.AppendElementWithText("eventId", eventId.ToString());
                }
                logNode.AppendChild(eventIdsNode);

                eventLogsNode.AppendChild(logNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><eventlogs></eventlogs></config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }
}
