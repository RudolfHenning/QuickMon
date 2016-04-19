using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class LinuxCPUCollectorConfig : ICollectorConfig
    {
        public LinuxCPUCollectorConfig()
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
            if (configurationString == null || configurationString.Length == 0)
                return;
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement pcNode in root.SelectNodes("linux/cpu"))
            {
                LinuxCPUEntry entry = new LinuxCPUEntry();
                entry.MachineName = pcNode.ReadXmlElementAttr("machine", ".");
                entry.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);
                entry.UseOnlyTotalCPUvalue = pcNode.ReadXmlElementAttr("totalCPU", true);
                entry.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                entry.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "80"));
                entry.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "99"));
                entry.UserName = pcNode.ReadXmlElementAttr("userName", "");
                entry.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                entry.PassCodeOrPhrase = pcNode.ReadXmlElementAttr("passCodeOrPhrase", "");
                Entries.Add(entry);
            }
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode linuxCPUNode = root.SelectSingleNode("linux");
            linuxCPUNode.InnerXml = "";
            foreach (LinuxCPUEntry entry in Entries)
            {
                XmlElement cpuNode = config.CreateElement("cpu");
                cpuNode.SetAttributeValue("machine", entry.MachineName);
                cpuNode.SetAttributeValue("sshPort", entry.SSHPort);
                cpuNode.SetAttributeValue("totalCPU", entry.UseOnlyTotalCPUvalue);
                cpuNode.SetAttributeValue("sshSecOpt", entry.SSHSecurityOption.ToString());
                cpuNode.SetAttributeValue("warningValue", entry.WarningValue);
                cpuNode.SetAttributeValue("errorValue", entry.ErrorValue);
                cpuNode.SetAttributeValue("userName", entry.UserName);
                cpuNode.SetAttributeValue("privateKeyFile", entry.PrivateKeyFile);
                cpuNode.SetAttributeValue("passCodeOrPhrase", entry.PassCodeOrPhrase);
                linuxCPUNode.AppendChild(cpuNode);
            }
            return config.OuterXml;
        }

        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<linux>\r\n</linux>\r\n</config>";
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
