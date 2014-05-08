using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class SocketPingConfig
    {
        public SocketPingConfig()
        {
            Entries = new List<SocketPingEntry>();
        }

        public List<SocketPingEntry> Entries { get; set; }

        public void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement addressNode in root.SelectNodes("hosts/host"))
            {
                SocketPingEntry socketPingEntry = new SocketPingEntry();
                socketPingEntry.HostName = addressNode.ReadXmlElementAttr("name", "");
                socketPingEntry.PortNumber = int.Parse( addressNode.ReadXmlElementAttr("port", "23"));
                socketPingEntry.ReceiveTimeoutMS = int.Parse(addressNode.ReadXmlElementAttr("receiveTimeoutMS", "30000"));
                socketPingEntry.SendTimeoutMS = int.Parse(addressNode.ReadXmlElementAttr("sendTimeoutMS", "30000"));
                socketPingEntry.UseTelnetLogin = bool.Parse(addressNode.ReadXmlElementAttr("useTelnetLogin", "false"));
                socketPingEntry.UserName = addressNode.ReadXmlElementAttr("userName", "");
                socketPingEntry.Password = addressNode.ReadXmlElementAttr("password", "");
                socketPingEntry.PingTimeOutMS = int.Parse(addressNode.ReadXmlElementAttr("pingTimeOutMS", "5000"));
                Entries.Add(socketPingEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.SocketPingEmptyConfig_xml);
            XmlElement root = config.DocumentElement;
            XmlNode hostsNode = root.SelectSingleNode("hosts");
            hostsNode.InnerXml = "";

            foreach (SocketPingEntry socketPingEntry in Entries)
            {
                XmlElement hostNode = config.CreateElement("host");
                hostNode.SetAttributeValue("name", socketPingEntry.HostName);
                hostNode.SetAttributeValue("port", socketPingEntry.PortNumber);
                hostNode.SetAttributeValue("receiveTimeoutMS", socketPingEntry.ReceiveTimeoutMS);
                hostNode.SetAttributeValue("sendTimeoutMS", socketPingEntry.SendTimeoutMS);
                hostNode.SetAttributeValue("useTelnetLogin", socketPingEntry.UseTelnetLogin);
                hostNode.SetAttributeValue("userName", socketPingEntry.UserName);
                hostNode.SetAttributeValue("password", socketPingEntry.Password);
                hostNode.SetAttributeValue("pingTimeOutMS", socketPingEntry.PingTimeOutMS);
                hostsNode.AppendChild(hostNode);
            }
            return config.OuterXml;
        }
    }
}
