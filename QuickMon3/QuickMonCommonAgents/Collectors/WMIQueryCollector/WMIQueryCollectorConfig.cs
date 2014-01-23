using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class WMIQueryCollectorConfig : ICollectorConfig
    {
        public WMIQueryCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }
        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        //public List<WMIQueryEntry> Entries = new List<WMIQueryEntry>();

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            foreach (XmlElement wmiQueryNode in root.SelectNodes("wmiQueries/wmiQuery"))
            {
                WMIQueryEntry entry = new WMIQueryEntry();
                entry.Namespace = wmiQueryNode.ReadXmlElementAttr("namespace", "root\\CIMV2");
                entry.Machinename = wmiQueryNode.ReadXmlElementAttr("machineName", ".");
                entry.Name = wmiQueryNode.ReadXmlElementAttr("name", entry.Machinename);
                XmlNode stateQueryNode = wmiQueryNode.SelectSingleNode("stateQuery");
                entry.StateQuery = stateQueryNode.ReadXmlElementAttr("syntax", "");
                entry.ReturnValueIsInt = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueIsInt", "True"));
                entry.ReturnValueInverted = bool.Parse(stateQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                entry.WarningValue = stateQueryNode.ReadXmlElementAttr("warningValue", "0");
                entry.ErrorValue = stateQueryNode.ReadXmlElementAttr("errorValue", "0");
                entry.SuccessValue = stateQueryNode.ReadXmlElementAttr("successValue", "[any]");
                entry.UseRowCountAsValue = bool.Parse(stateQueryNode.ReadXmlElementAttr("useRowCountAsValue", "True"));
                XmlNode detailQueryNode = wmiQueryNode.SelectSingleNode("detailQuery");
                entry.DetailQuery = detailQueryNode.ReadXmlElementAttr("syntax", "");
                string columns = detailQueryNode.ReadXmlElementAttr("columnNames", "");
                entry.ColumnNames = new List<string>();
                if (columns.Length > 0 && columns.IndexOf(',') > -1)
                    entry.ColumnNames = columns.ToListFromCSVString();
                else if (columns.Length > 0)
                    entry.ColumnNames.Add(columns);
                Entries.Add(entry);
            }
        }

        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.WMIQueryCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode wmiNode = root.SelectSingleNode("wmiQueries");
            wmiNode.InnerXml = "";
            foreach (WMIQueryEntry entry in Entries)
            {
                XmlElement entryNode = config.CreateElement("wmiQuery");
                entryNode.SetAttributeValue("name", entry.Name);
                entryNode.SetAttributeValue("namespace", entry.Namespace);
                entryNode.SetAttributeValue("machineName", entry.Machinename);
                XmlElement stateQueryNode = config.CreateElement("stateQuery");
                stateQueryNode.SetAttributeValue("syntax", entry.StateQuery);
                stateQueryNode.SetAttributeValue("returnValueIsInt", entry.ReturnValueIsInt);
                stateQueryNode.SetAttributeValue("returnValueInverted", entry.ReturnValueInverted);
                stateQueryNode.SetAttributeValue("warningValue", entry.WarningValue);
                stateQueryNode.SetAttributeValue("errorValue", entry.ErrorValue);
                stateQueryNode.SetAttributeValue("successValue", entry.SuccessValue);
                stateQueryNode.SetAttributeValue("useRowCountAsValue", entry.UseRowCountAsValue);
                entryNode.AppendChild(stateQueryNode);

                XmlElement detailQueryNode = config.CreateElement("detailQuery");
                detailQueryNode.SetAttributeValue("syntax", entry.DetailQuery);
                detailQueryNode.SetAttributeValue("columnNames", entry.ColumnNames.ToCSVString());
                entryNode.AppendChild(detailQueryNode);
                wmiNode.AppendChild(entryNode);
            }
            return config.OuterXml;
        }

        #endregion
    }
}
