using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class HttpPingConfig
    {
        public HttpPingConfig()
        {
            Entries = new List<HttpPingEntry>();
        }

        public List<HttpPingEntry> Entries { get; set; }

        public void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement addressNode in root.SelectNodes("addresses/address"))
            {
                HttpPingEntry httpPingEntry = new HttpPingEntry();
                httpPingEntry.Url = addressNode.ReadXmlElementAttr("url", "");
                httpPingEntry.ProxyServer = addressNode.ReadXmlElementAttr("proxyServer", "");
                httpPingEntry.TimeOut = int.Parse(addressNode.ReadXmlElementAttr("timeOutMS", "5000"));
                httpPingEntry.MaxTime = int.Parse(addressNode.ReadXmlElementAttr("maxTimeMS", "1000"));
                Entries.Add(httpPingEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.HttpPingEmptyConfig);
            XmlElement root = config.DocumentElement;
            XmlNode addressesNode = root.SelectSingleNode("addresses");
            addressesNode.InnerXml = "";

            foreach (HttpPingEntry httpPingEntry in Entries)
            {
                XmlElement addressNode = config.CreateElement("address");
                addressNode.SetAttributeValue("url", httpPingEntry.Url);
                addressNode.SetAttributeValue("proxyServer", httpPingEntry.ProxyServer);
                addressNode.SetAttributeValue("timeOutMS", httpPingEntry.TimeOut);
                addressNode.SetAttributeValue("maxTimeMS", httpPingEntry.MaxTime);                                
                addressesNode.AppendChild(addressNode);
            }
            return config.OuterXml;
        }
    }
}
