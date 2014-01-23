using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class SoapWebServicePingCollectorConfig : ICollectorConfig
    {
        public SoapWebServicePingCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }
        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        //public List<SoapWebServicePingConfigEntry> Entries = new List<SoapWebServicePingConfigEntry>();        

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement addressNode in root.SelectNodes("webServices/webService"))
            {
                SoapWebServicePingConfigEntry webServicePingEntry = new SoapWebServicePingConfigEntry();
                webServicePingEntry.ServiceBaseURL = addressNode.ReadXmlElementAttr("url", "");
                webServicePingEntry.ServiceName = addressNode.ReadXmlElementAttr("name", "");
                webServicePingEntry.MethodName = addressNode.ReadXmlElementAttr("method");
                string parameterStr = addressNode.ReadXmlElementAttr("paramatersCSV");
                webServicePingEntry.Parameters = new List<string>();
                if (parameterStr.Trim().Length > 0)
                    webServicePingEntry.Parameters.AddRange(parameterStr.Split(','));

                if (addressNode.ReadXmlElementAttr("checkType") == "0")
                    webServicePingEntry.CheckType = SoapWebServicePingCheckType.Success;
                else
                    webServicePingEntry.CheckType = SoapWebServicePingCheckType.Failure;

                int tmpResultType = 0;
                if (int.TryParse(addressNode.ReadXmlElementAttr("resultType"), out tmpResultType))
                {
                    webServicePingEntry.ResultType = (SoapWebServicePingResult)tmpResultType;
                }
                else
                {
                    webServicePingEntry.ResultType = SoapWebServicePingResult.CheckAvailabilityOnly;
                }
                webServicePingEntry.CustomValue1 = addressNode.ReadXmlElementAttr("checkValue1");
                webServicePingEntry.CustomValue2 = addressNode.ReadXmlElementAttr("checkValue2");
                Entries.Add(webServicePingEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.SoapWebServicePingCollectorDefaultConfig);
            XmlElement root = config.DocumentElement;
            XmlNode addressesNode = root.SelectSingleNode("webServices");
            addressesNode.InnerXml = "";

            foreach (SoapWebServicePingConfigEntry webServicePingEntry in Entries)
            {
                XmlElement webServicePingNode = config.CreateElement("webService");
                webServicePingNode.SetAttributeValue("url", webServicePingEntry.ServiceBaseURL);
                webServicePingNode.SetAttributeValue("name", webServicePingEntry.ServiceName);
                webServicePingNode.SetAttributeValue("method", webServicePingEntry.MethodName);
                webServicePingNode.SetAttributeValue("paramatersCSV", webServicePingEntry.ToStringFromParameters());
                webServicePingNode.SetAttributeValue("checkType", (int)webServicePingEntry.CheckType);
                webServicePingNode.SetAttributeValue("resultType", (int)webServicePingEntry.ResultType);
                webServicePingNode.SetAttributeValue("checkValue1", webServicePingEntry.CustomValue1);
                webServicePingNode.SetAttributeValue("checkValue2", webServicePingEntry.CustomValue2);
                addressesNode.AppendChild(webServicePingNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}
