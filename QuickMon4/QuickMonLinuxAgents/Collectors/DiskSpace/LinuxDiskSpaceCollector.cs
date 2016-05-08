using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Disk Space Free % Collector"), Category("Linux")]
    public class LinuxDiskSpaceCollector : CollectorAgentBase
    {
        public LinuxDiskSpaceCollector()
        {
            AgentConfig = new LinuxDiskSpaceCollectorConfig();
        }

        #region ICollector Members
        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            float lowestVal = 100;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxDiskSpaceCollectorConfig currentConfig = (LinuxDiskSpaceCollectorConfig)AgentConfig;
                foreach (LinuxDiskSpaceEntry entry in currentConfig.Entries)
                {
                    MonitorState entryState = new MonitorState()
                    {
                        ForAgent = entry.SSHConnection.ComputerName
                    };

                    List<DiskInfoState> diss = entry.GetStates();
                    foreach (DiskInfoState dis in diss)
                    {
                        if (dis.State == CollectorState.Error)
                        {
                            errors++;
                        }
                        if (dis.State == CollectorState.Warning)
                        {
                            warnings++;
                        }
                        else
                        {
                            success++;
                        }
                        entryState.ChildStates.Add(
                             new MonitorState()
                             {
                                 ForAgent = dis.FileSystemInfo.Name,
                                 State = dis.State,
                                 CurrentValue = dis.FileSystemInfo.FreeSpacePerc,
                                 CurrentValueUnit = "%"
                             }
                            );
                        if (lowestVal > dis.FileSystemInfo.FreeSpacePerc)
                            lowestVal = dis.FileSystemInfo.FreeSpacePerc;

                    }
                    returnState.ChildStates.Add(entryState);
                }
                returnState.CurrentValue = lowestVal;

                if (errors > 0 && warnings == 0 && success == 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }
        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("File System", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Percentage Free", typeof(double)));

                LinuxDiskSpaceCollectorConfig currentConfig = (LinuxDiskSpaceCollectorConfig)AgentConfig;
                foreach (LinuxDiskSpaceEntry entry in currentConfig.Entries)
                {
                    foreach (DiskInfoState diInfo in entry.GetDiskInfos())
                    {
                        dt.Rows.Add(entry.SSHConnection.ComputerName, diInfo.FileSystemInfo.Name, diInfo.FileSystemInfo.FreeSpacePerc);
                    }
                }
            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            tables.Add(dt);
            return tables;
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
                entry.SSHConnection.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                entry.SSHConnection.ComputerName = pcNode.ReadXmlElementAttr("machine", ".");
                entry.SSHConnection.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);                
                entry.SSHConnection.UserName = pcNode.ReadXmlElementAttr("userName", "");
                entry.SSHConnection.Password = pcNode.ReadXmlElementAttr("password", "");
                entry.SSHConnection.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                entry.SSHConnection.PassPhrase = pcNode.ReadXmlElementAttr("passPhrase", "");

                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement fileSystemNode in pcNode.SelectNodes("fileSystem"))
                {
                    LinuxDiskSpaceSubEntry fse = new LinuxDiskSpaceSubEntry();
                    fse.FileSystemName = fileSystemNode.ReadXmlElementAttr("name", "");
                    fse.WarningValue = fileSystemNode.ReadXmlElementAttr("warningValue", 10.0d);
                    fse.ErrorValue = fileSystemNode.ReadXmlElementAttr("errorValue", 5.0d);
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
                diskSpaceNode.SetAttributeValue("machine", entry.SSHConnection.ComputerName);
                diskSpaceNode.SetAttributeValue("sshPort", entry.SSHConnection.SSHPort);
                diskSpaceNode.SetAttributeValue("sshSecOpt", entry.SSHConnection.SSHSecurityOption.ToString());
                diskSpaceNode.SetAttributeValue("userName", entry.SSHConnection.UserName);
                diskSpaceNode.SetAttributeValue("password", entry.SSHConnection.Password);
                diskSpaceNode.SetAttributeValue("privateKeyFile", entry.SSHConnection.PrivateKeyFile);
                diskSpaceNode.SetAttributeValue("passPhrase", entry.SSHConnection.PassPhrase);

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
        public List<DiskInfoState> GetDiskInfos()
        {
            List<DiskInfoState> fileSystemEntries = new List<DiskInfoState>();
            using (Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHConnection))
            {

                if (sshClient.IsConnected)
                {

                    //First see if ANY subentry is for all
                    bool addAll = (from LinuxDiskSpaceSubEntry d in SubItems
                                   where d.FileSystemName == "*"
                                   select d).Count() > 0;
                    if (addAll)
                    {
                        LinuxDiskSpaceSubEntry alertDef = (from LinuxDiskSpaceSubEntry d in SubItems
                                                           where d.FileSystemName == "*"
                                                           select d).FirstOrDefault();
                        foreach (Linux.DiskInfo di in DiskInfo.FromDfTk(sshClient))
                        {
                            DiskInfoState dis = new DiskInfoState() { FileSystemInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                            fileSystemEntries.Add(dis);
                        }
                    }
                    else
                    {
                        foreach (Linux.DiskInfo di in DiskInfo.FromDfTk(sshClient))
                        {
                            LinuxDiskSpaceSubEntry alertDef = (from LinuxDiskSpaceSubEntry d in SubItems
                                                               where d.FileSystemName.ToLower() == di.Name.ToLower()
                                                               select d).FirstOrDefault();

                            if (alertDef != null)
                            {
                                if (!fileSystemEntries.Any(f => f.FileSystemInfo.Name.ToLower() == di.Name.ToLower()))
                                {
                                    DiskInfoState dis = new DiskInfoState() { FileSystemInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                                    fileSystemEntries.Add(dis);
                                }
                            }
                        }
                    }
                }
                sshClient.Disconnect();
            }
            return fileSystemEntries;
        }
        public List<DiskInfoState> GetStates()
        {
            List<DiskInfoState> states = new List<DiskInfoState>();

            foreach (DiskInfoState dis in GetDiskInfos())
            {
                dis.State = CollectorState.Good;
                if (dis.FileSystemInfo.FreeSpacePerc <= dis.AlertDefinition.ErrorValue)
                {
                    dis.State = CollectorState.Error;
                }
                else if (dis.FileSystemInfo.FreeSpacePerc <= dis.AlertDefinition.WarningValue)
                {
                    dis.State = CollectorState.Warning;
                }
                states.Add(dis);

            }    
            return states;
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

        #region ICollectorConfigSubEntry Members
        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", FileSystemName, WarningValue, ErrorValue); }
        }
        #endregion
    }

    public class DiskInfoState
    {
        public Linux.DiskInfo FileSystemInfo { get; set; }
        public LinuxDiskSpaceSubEntry AlertDefinition { get; set; }
        public CollectorState State { get; set; }
    }
}
