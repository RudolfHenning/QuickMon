using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class DynamicWSCollectorConfig : ICollectorConfig
    {
        public DynamicWSCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement addressNode in root.SelectNodes("webServices/webService"))
            {
                DynamicWSCollectorConfigEntry webServicePingEntry = new DynamicWSCollectorConfigEntry();
                webServicePingEntry.ServiceBaseURL = addressNode.ReadXmlElementAttr("url", "");
                webServicePingEntry.ServiceBindingName = addressNode.ReadXmlElementAttr("serviceBindingName", "");
                webServicePingEntry.MethodName = addressNode.ReadXmlElementAttr("method");
                string parameterStr = addressNode.ReadXmlElementAttr("paramatersCSV");
                webServicePingEntry.Parameters = new List<string>();
                if (parameterStr.Trim().Length > 0)
                    webServicePingEntry.Parameters.AddRange(parameterStr.Split(','));
                webServicePingEntry.ResultIsSuccess = addressNode.ReadXmlElementAttr("resultIsSuccess", true);
                webServicePingEntry.ValueExpectedReturnType = WebServiceValueExpectedReturnTypeConverter.FromString(addressNode.ReadXmlElementAttr("valueExpectedReturnType", ""));
                webServicePingEntry.MacroFormatType = WebServiceMacroFormatTypeConverter.FromString(addressNode.ReadXmlElementAttr("macroFormatType", ""));
                webServicePingEntry.CheckValueArrayIndex = addressNode.ReadXmlElementAttr("arrayIndex", 0);
                webServicePingEntry.CheckValueColumnIndex = addressNode.ReadXmlElementAttr("columnIndex", 0);
                webServicePingEntry.CheckValueOrMacro = addressNode.ReadXmlElementAttr("valueOrMacro", "");
                webServicePingEntry.UseRegEx = addressNode.ReadXmlElementAttr("useRegEx", false);
                Entries.Add(webServicePingEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.DynamicWSCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode addressesNode = root.SelectSingleNode("webServices");
            addressesNode.InnerXml = "";
            foreach (DynamicWSCollectorConfigEntry webServicePingEntry in Entries)
            {
                XmlElement webServicePingNode = config.CreateElement("webService");
                webServicePingNode.SetAttributeValue("url", webServicePingEntry.ServiceBaseURL);
                webServicePingNode.SetAttributeValue("serviceBindingName", webServicePingEntry.ServiceBindingName);
                webServicePingNode.SetAttributeValue("method", webServicePingEntry.MethodName);
                webServicePingNode.SetAttributeValue("paramatersCSV", webServicePingEntry.ToStringFromParameters());
                webServicePingNode.SetAttributeValue("resultIsSuccess", webServicePingEntry.ResultIsSuccess);
                webServicePingNode.SetAttributeValue("valueExpectedReturnType", webServicePingEntry.ValueExpectedReturnType.ToString());
                webServicePingNode.SetAttributeValue("macroFormatType", webServicePingEntry.MacroFormatType.ToString());
                webServicePingNode.SetAttributeValue("arrayIndex", webServicePingEntry.CheckValueArrayIndex);
                webServicePingNode.SetAttributeValue("columnIndex", webServicePingEntry.CheckValueColumnIndex);
                webServicePingNode.SetAttributeValue("valueOrMacro", webServicePingEntry.CheckValueOrMacro);
                webServicePingNode.SetAttributeValue("useRegEx", webServicePingEntry.UseRegEx);
                addressesNode.AppendChild(webServicePingNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}
