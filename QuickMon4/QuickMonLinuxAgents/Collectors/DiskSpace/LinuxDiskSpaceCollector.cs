using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors.DiskSpace
{
    [Description("Disk Space Collector"), Category("Linux")]
    public class LinuxDiskSpaceCollector : CollectorAgentBase
    {
        public LinuxDiskSpaceCollector()
        {
            AgentConfig = new LinuxDiskSpaceCollectorConfig();
        }

        #region ICollector Members
        public override MonitorState RefreshState()
        {
            throw new NotImplementedException();
        }
        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public class LinuxDiskSpaceCollectorConfig : ICollectorConfig
    {
        public LinuxDiskSpaceCollectorConfig()
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
            foreach (XmlElement pcNode in root.SelectNodes("linux/diskSpace"))
            {
                LinuxDiskSpaceEntry entry = new LinuxDiskSpaceEntry();
                entry.MachineName = pcNode.ReadXmlElementAttr("machine", ".");
                entry.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);
                entry.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                entry.UserName = pcNode.ReadXmlElementAttr("userName", "");
                entry.Password = pcNode.ReadXmlElementAttr("password", "");
                entry.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                entry.PassPhrase = pcNode.ReadXmlElementAttr("passPhrase", "");

                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement fileSystemNode in pcNode.SelectNodes("fileSystem"))
                {
                    LinuxDiskSpaceSubEntry fse = new LinuxDiskSpaceSubEntry();
                    fse.FileSystemName = fileSystemNode.ReadXmlElementAttr("name", "");
                    fse.FileSystemName = fileSystemNode.ReadXmlElementAttr("warningValue", "10");
                    fse.FileSystemName = fileSystemNode.ReadXmlElementAttr("errorValue", "5");
                    entry.SubItems.Add(fse);
                }
                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode linuxDiskSpaceNode = root.SelectSingleNode("linux");
            linuxDiskSpaceNode.InnerXml = "";
            foreach (LinuxDiskSpaceEntry entry in Entries)
            {
                XmlElement diskSpaceNode = config.CreateElement("diskSpace");
                diskSpaceNode.SetAttributeValue("machine", entry.MachineName);
                diskSpaceNode.SetAttributeValue("sshPort", entry.SSHPort);
                diskSpaceNode.SetAttributeValue("sshSecOpt", entry.SSHSecurityOption.ToString());
                diskSpaceNode.SetAttributeValue("userName", entry.UserName);
                diskSpaceNode.SetAttributeValue("password", entry.Password);
                diskSpaceNode.SetAttributeValue("privateKeyFile", entry.PrivateKeyFile);
                diskSpaceNode.SetAttributeValue("passPhrase", entry.PassPhrase);

                foreach (LinuxDiskSpaceSubEntry fse in entry.SubItems)
                {
                    XmlElement fileSystemNode = config.CreateElement("fileSystem");
                    fileSystemNode.SetAttributeValue("name", fse.FileSystemName);
                    fileSystemNode.SetAttributeValue("warningValue", fse.WarningValue);
                    fileSystemNode.SetAttributeValue("errorValue", fse.ErrorValue);
                    diskSpaceNode.AppendChild(fileSystemNode);
                }

                linuxDiskSpaceNode.AppendChild(diskSpaceNode);
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

    public class LinuxDiskSpaceEntry : LinuxBaseEntry
    {
        public List<Linux.DiskInfo> GetDiskInfos()
        {
            List<Linux.DiskInfo> fileSystemEntries = new List<Linux.DiskInfo>();
            Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHSecurityOption, MachineName, SSHPort, UserName, Password, PrivateKeyFile, PassPhrase);
            
            if (sshClient.IsConnected)
            {
                foreach (Linux.DiskInfo di in fileSystemEntries = DiskInfo.FromDfTk(sshClient))
                {
                    if ((from LinuxDiskSpaceSubEntry d in SubItems
                         where d.FileSystemName.ToLower() == di.Name.ToLower()
                         select d).Count() == 1)
                    {
                        fileSystemEntries.Add(di);
                    }                 
                }
            }
            sshClient.Disconnect();

            return fileSystemEntries;
        }

        public override string TriggerSummary
        {
            get { return string.Format("{0} File system(s)", SubItems.Count); }
        }
    }

    public class LinuxDiskSpaceSubEntry : ICollectorConfigSubEntry
    {
        public LinuxDiskSpaceSubEntry()
        {
            WarningValue = 10;
            ErrorValue = 5;
        }
        public string FileSystemName { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", FileSystemName, WarningValue, ErrorValue); }
        }
    }
}
