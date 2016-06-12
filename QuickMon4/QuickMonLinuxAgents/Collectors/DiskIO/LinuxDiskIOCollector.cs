using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Disk IO Collector"), Category("SSH")]
    public class LinuxDiskIOCollector : CollectorAgentBase
    {
        public LinuxDiskIOCollector()
        {
            AgentConfig = new LinuxDiskIOCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            long highestVal = 0;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxDiskIOCollectorConfig currentConfig = (LinuxDiskIOCollectorConfig)AgentConfig;
                foreach (LinuxDiskIOEntry entry in currentConfig.Entries)
                {
                    MonitorState entryState = new MonitorState()
                    {
                        ForAgent = entry.SSHConnection.ComputerName
                    };

                    List<DiskIOState> diss = entry.GetStates();
                    foreach (DiskIOState dis in diss)
                    {
                        if (dis.State == CollectorState.Error)
                        {
                            errors++;
                        }
                        else if (dis.State == CollectorState.Warning)
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
                                    ForAgent = dis.DiskInfo.Name,
                                    State = dis.State,
                                    CurrentValue = dis.DiskInfo.BytesReadWritePerSec,
                                    CurrentValueUnit = "Bytes/Sec"
                                }
                            );
                        if (highestVal < dis.DiskInfo.BytesReadWritePerSec)
                            highestVal = dis.DiskInfo.BytesReadWritePerSec;
                    }
                    returnState.ChildStates.Add(entryState);
                }
                returnState.CurrentValue = highestVal;
                returnState.CurrentValueUnit = "Bytes/Sec (highest)";

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
                dt.Columns.Add(new System.Data.DataColumn("Bytes/Sec", typeof(double)));

                LinuxDiskIOCollectorConfig currentConfig = (LinuxDiskIOCollectorConfig)AgentConfig;
                foreach (LinuxDiskIOEntry entry in currentConfig.Entries)
                {
                    foreach (DiskIOState diInfo in entry.GetDiskInfos())
                    {
                        dt.Rows.Add(entry.SSHConnection.ComputerName, diInfo.DiskInfo.Name, diInfo.DiskInfo.BytesReadWritePerSec);
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
    }

    public class LinuxDiskIOCollectorConfig : ICollectorConfig
    {

        public LinuxDiskIOCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        public void FromXml(string configurationString)
        {
            if (configurationString == null || configurationString.Length == 0)
                return;
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement pcNode in root.SelectNodes("linux/diskIO"))
            {
                LinuxDiskIOEntry entry = new LinuxDiskIOEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(pcNode);

                //entry.SSHConnection.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                //entry.SSHConnection.ComputerName = pcNode.ReadXmlElementAttr("machine", ".");
                //entry.SSHConnection.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);                
                //entry.SSHConnection.UserName = pcNode.ReadXmlElementAttr("userName", "");
                //entry.SSHConnection.Password = pcNode.ReadXmlElementAttr("password", "");
                //entry.SSHConnection.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                //entry.SSHConnection.PassPhrase = pcNode.ReadXmlElementAttr("passPhrase", "");

                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement fileSystemNode in pcNode.SelectNodes("disk"))
                {
                    LinuxDiskIOSubEntry fse = new LinuxDiskIOSubEntry();
                    fse.Disk = fileSystemNode.ReadXmlElementAttr("name", "");
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
            foreach (LinuxDiskIOEntry entry in Entries)
            {
                XmlElement diskSpaceNode = config.CreateElement("diskIO");
                entry.SSHConnection.SaveToXmlElementAttr(diskSpaceNode);

                //diskSpaceNode.SetAttributeValue("machine", entry.SSHConnection.ComputerName);
                //diskSpaceNode.SetAttributeValue("sshPort", entry.SSHConnection.SSHPort);
                //diskSpaceNode.SetAttributeValue("sshSecOpt", entry.SSHConnection.SSHSecurityOption.ToString());
                //diskSpaceNode.SetAttributeValue("userName", entry.SSHConnection.UserName);
                //diskSpaceNode.SetAttributeValue("password", entry.SSHConnection.Password);
                //diskSpaceNode.SetAttributeValue("privateKeyFile", entry.SSHConnection.PrivateKeyFile);
                //diskSpaceNode.SetAttributeValue("passPhrase", entry.SSHConnection.PassPhrase);

                foreach (LinuxDiskIOSubEntry fse in entry.SubItems)
                {
                    XmlElement fileSystemNode = config.CreateElement("disk");
                    fileSystemNode.SetAttributeValue("name", fse.Disk);
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
    }
    public class LinuxDiskIOEntry : LinuxBaseEntry
    {
        public List<DiskIOState> GetDiskInfos()
        {
            List<DiskIOState> diskIOEntries = new List<DiskIOState>();
            Renci.SshNet.SshClient sshClient = SSHConnection.GetConnection();

            //First see if ANY subentry is for all
            bool addAll = (from LinuxDiskIOSubEntry d in SubItems
                           where d.Disk == "*"
                           select d).Count() > 0;
            if (addAll)
            {
                LinuxDiskIOSubEntry alertDef = (from LinuxDiskIOSubEntry d in SubItems
                                                where d.Disk == "*"
                                                select d).FirstOrDefault();
                foreach (Linux.DiskIOInfo di in DiskIOInfo.GetCurrentDiskStats(sshClient, 250))
                {
                    DiskIOState dis = new DiskIOState() { DiskInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                    diskIOEntries.Add(dis);
                }
            }
            else
            {
                foreach (Linux.DiskIOInfo di in DiskIOInfo.GetCurrentDiskStats(sshClient, 250))
                {
                    LinuxDiskIOSubEntry alertDef = (from LinuxDiskIOSubEntry d in SubItems
                                                    where d.Disk.ToLower() == di.Name.ToLower()
                                                    select d).FirstOrDefault();

                    if (alertDef != null)
                    {
                        if (!diskIOEntries.Any(f => f.DiskInfo.Name.ToLower() == di.Name.ToLower()))
                        {
                            DiskIOState dis = new DiskIOState() { DiskInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                            diskIOEntries.Add(dis);
                        }
                    }
                }                
            }
            SSHConnection.CloseConnection();
            return diskIOEntries;

        }
        public List<DiskIOState> GetStates()
        {
            List<DiskIOState> states = new List<DiskIOState>();

            foreach (DiskIOState dis in GetDiskInfos())
            {
                dis.State = CollectorState.Good;
                if (dis.DiskInfo.BytesReadWritePerSec >= dis.AlertDefinition.ErrorValue)
                {
                    dis.State = CollectorState.Error;
                }
                else if (dis.DiskInfo.BytesReadWritePerSec >= dis.AlertDefinition.WarningValue)
                {
                    dis.State = CollectorState.Warning;
                }
                states.Add(dis);

            }
            return states;
        }

        public override string TriggerSummary
        {
            get { return string.Format("{0} Disk(s)", SubItems.Count); }
        }
    }
    public class LinuxDiskIOSubEntry : ICollectorConfigSubEntry
    {
        public LinuxDiskIOSubEntry()
        {
            WarningValue = 10;
            ErrorValue = 5;
        }

        public string Disk { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        #region ICollectorConfigSubEntry Members
        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", Disk, WarningValue, ErrorValue); }
        }
        #endregion
    }

    public class DiskIOState
    {
        public Linux.DiskIOInfo DiskInfo { get; set; }
        public LinuxDiskIOSubEntry AlertDefinition { get; set; }
        public CollectorState State { get; set; }
    }
}
