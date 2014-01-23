using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class LoopbackCollectorConfig : ICollectorConfig
    {
        public LoopbackCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
            Entries.Add(new LoopbackCollectorConfigEntry());
        }
        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Single; } }
        public bool CanEdit { get { return true; } }
        #endregion

        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            if (configurationString == null || configurationString.Length == 0)
            {
                config.LoadXml(Properties.Resources.LoopbackCollectorDefaultConfig);
            }
            else
            {
                config.LoadXml(configurationString);
            }
            XmlElement root = config.DocumentElement;
            XmlNode loopbackNode = root.SelectSingleNode("loopback");
            ((LoopbackCollectorConfigEntry)Entries[0]).ReturnState = CollectorStateConverter.GetCollectorStateFromText(loopbackNode.Attributes.GetNamedItem("returnState").Value);
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.LoopbackCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode loopbackNode = root.SelectSingleNode("loopback");
            loopbackNode.SetAttributeValue("returnState", ((LoopbackCollectorConfigEntry)Entries[0]).ReturnState.ToString());            
            return config.OuterXml;
        }        
    }

    public class LoopbackCollectorConfigEntry : ICollectorConfigEntry
    {
        #region Properties
        public CollectorState ReturnState { get; set; }
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get 
            {
                return "Returns: " + ReturnState.ToString();
            }
        }
        public string TriggerSummary
        {
            get
            {
                return "Returns: " + ReturnState.ToString();
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion
    }
}
