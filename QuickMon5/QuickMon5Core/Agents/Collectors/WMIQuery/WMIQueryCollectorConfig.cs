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
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

         #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            foreach (XmlElement wmiQueryNode in root.SelectNodes("wmiQueries/wmiQuery"))
            {
                WMIQueryCollectorConfigEntry entry = new WMIQueryCollectorConfigEntry();
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
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode wmiNode = root.SelectSingleNode("wmiQueries");
            wmiNode.InnerXml = "";
            foreach (WMIQueryCollectorConfigEntry entry in Entries)
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
        public string GetDefaultOrEmptyXml()
        {
            return "<config><wmiQueries><wmiQuery name=\"Example\" namespace=\"root\\CIMV2\" machineName=\".\">\r\n" +
                "<stateQuery syntax=\"SELECT FreeSpace FROM Win32_LogicalDisk where Caption = 'C:'\" returnValueIsInt=\"True\" returnValueInverted=\"True\" warningValue=\"1048576000\" errorValue=\"524288000\" successValue=\"[any]\" useRowCountAsValue=\"False\" />\r\n" +
                "<detailQuery syntax=\"SELECT Caption, Size, FreeSpace, Description FROM Win32_LogicalDisk where Caption = 'C:'\" columnNames=\"Caption, Size, FreeSpace, Description\" keyColumn=\"0\" />\r\n" +
                "</wmiQuery></wmiQueries></config>";
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
