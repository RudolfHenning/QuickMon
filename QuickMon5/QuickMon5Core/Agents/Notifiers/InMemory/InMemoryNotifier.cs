using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
    [Description("'In memory' Notifier")]
    public class InMemoryNotifier : NotifierAgentBase
    {
        public List<AlertRaised> Alerts = new List<AlertRaised>();
        public InMemoryNotifier()
        {
            AgentConfig = new InMemoryNotifierConfig();
        }

        public override void RecordMessage(AlertRaised alertRaised)
        {
            Alerts.Add(alertRaised);
            //Cleanup
            InMemoryNotifierConfig config = (InMemoryNotifierConfig)AgentConfig;
            if (config.MaxEntryCount > 0)
            {
                while (Alerts.Count > config.MaxEntryCount)
                {
                    Alerts.RemoveAt(0);
                }
            }
        }
        public override AttendedOption AttendedRunOption { get { return AttendedOption.OnlyAttended; } }
    }
    public class InMemoryNotifierConfig : INotifierConfig
    {
        public int MaxEntryCount { get; set; }

        #region INotifierConfig Members
        public string ConfigSummary
        {
            get
            {
                string summary = "Max entry count: " + MaxEntryCount.ToString();
                return summary;
            }
        }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            if (configurationString == null || configurationString.Length == 0)
            {
                config.LoadXml(GetDefaultOrEmptyXml());
            }
            else
            {
                config.LoadXml(configurationString);
            }
            XmlElement root = config.DocumentElement;
            XmlNode inMemoryNode = root.SelectSingleNode("inMemory");
            MaxEntryCount = int.Parse(inMemoryNode.Attributes.GetNamedItem("maxEntryCount").Value);
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode inMemoryNode = root.SelectSingleNode("inMemory");
            inMemoryNode.SetAttributeValue("maxEntryCount", MaxEntryCount.ToString());
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<inMemory maxEntryCount=\"99999\" />\r\n</config>";
        }
        #endregion
    }
}
