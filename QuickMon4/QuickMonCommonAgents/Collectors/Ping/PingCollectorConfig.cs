using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class PingCollectorConfig : ICollectorConfig
    {
        public PingCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion

        #region IAgentConfig Members
        public void FromConfig(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;

            foreach (XmlElement host in root.SelectNodes("entries/entry"))
            {
                PingCollectorHostEntry hostEntry = new PingCollectorHostEntry();
                hostEntry.PingType = PingCollectorTypeHelper.FromText(host.ReadXmlElementAttr("pingMethod", "Ping"));
                hostEntry.Address = host.ReadXmlElementAttr("address");
                hostEntry.DescriptionLocal = host.ReadXmlElementAttr("description");
                int tmp = 0;
                if (int.TryParse(host.ReadXmlElementAttr("maxTimeMS", "1000"), out tmp))
                    hostEntry.MaxTimeMS = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("timeOutMS", "5000"), out tmp))
                    hostEntry.TimeOutMS = tmp;
                hostEntry.HttpProxyServer = host.ReadXmlElementAttr("httpProxyServer");
                if (int.TryParse(host.ReadXmlElementAttr("socketPort", "23"), out tmp))
                    hostEntry.SocketPort = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("receiveTimeoutMS", "30000"), out tmp))
                    hostEntry.ReceiveTimeOutMS = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("sendTimeoutMS", "30000"), out tmp))
                    hostEntry.SendTimeOutMS = tmp;
                bool btmp;
                if (bool.TryParse(host.ReadXmlElementAttr("useTelnetLogin", "false"), out btmp))
                    hostEntry.UseTelnetLogin = btmp;
                hostEntry.TelnetUserName = host.ReadXmlElementAttr("userName");
                hostEntry.TelnetPassword = host.ReadXmlElementAttr("password");
                hostEntry.IgnoreInvalidHTTPSCerts = host.ReadXmlElementAttr("ignoreInvalidHTTPSCerts", false);

                Entries.Add(hostEntry);
            }            
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyConfig());
            XmlNode hostsListNode = config.SelectSingleNode("config/entries");
            foreach (PingCollectorHostEntry hostEntry in Entries)
            {
                XmlNode hostXmlNode = config.CreateElement("entry");
                hostXmlNode.SetAttributeValue("pingMethod", PingCollectorTypeHelper.ToString(hostEntry.PingType));
                hostXmlNode.SetAttributeValue("address", hostEntry.Address);
                hostXmlNode.SetAttributeValue("description", hostEntry.DescriptionLocal);
                hostXmlNode.SetAttributeValue("maxTimeMS", hostEntry.MaxTimeMS);
                hostXmlNode.SetAttributeValue("timeOutMS", hostEntry.TimeOutMS);
                hostXmlNode.SetAttributeValue("httpProxyServer", hostEntry.HttpProxyServer);
                hostXmlNode.SetAttributeValue("socketPort", hostEntry.SocketPort);
                hostXmlNode.SetAttributeValue("receiveTimeoutMS", hostEntry.ReceiveTimeOutMS);
                hostXmlNode.SetAttributeValue("sendTimeoutMS", hostEntry.SendTimeOutMS);
                hostXmlNode.SetAttributeValue("useTelnetLogin", hostEntry.UseTelnetLogin);
                hostXmlNode.SetAttributeValue("userName", hostEntry.TelnetUserName);
                hostXmlNode.SetAttributeValue("password", hostEntry.TelnetPassword);
                hostXmlNode.SetAttributeValue("ignoreInvalidHTTPSCerts", hostEntry.IgnoreInvalidHTTPSCerts);
                hostsListNode.AppendChild(hostXmlNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyConfig()
        {
            return "<config><entries></entries></config>";
        }
        #endregion
    }
}
