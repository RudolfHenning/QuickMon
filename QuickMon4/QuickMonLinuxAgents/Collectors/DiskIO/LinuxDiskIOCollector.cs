using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Disk IO Collector"), Category("Linux")]
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
            double highestVal = 0;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxDiskIOCollectorConfig currentConfig = (LinuxDiskIOCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Querying {0} entries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Querying {0} entries</b>", currentConfig.Entries.Count);
                foreach (LinuxDiskIOEntry entry in currentConfig.Entries)
                {
                    List<DiskIOState> diss = entry.GetStates();
                    foreach (DiskIOState dis in diss)
                    {
                        if (dis.State == CollectorState.Error)
                        {
                            errors++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.MachineName + "->" + dis.DiskInfo.Name,
                                    State = CollectorState.Error,
                                    CurrentValue = dis.DiskInfo.BytesReadWritePerSec,
                                    RawDetails = string.Format("'{0}'-> {1} : {2} Bytes/Sec (Error)", entry.MachineName, dis.DiskInfo.Name, dis.DiskInfo.BytesReadWritePerSec),
                                    HtmlDetails = string.Format("'{0}'-&gt; {1} : {2} Bytes/Sec (<b>Error</b>)", entry.MachineName, dis.DiskInfo.Name, dis.DiskInfo.BytesReadWritePerSec)
                                });
                        }
                        else if (dis.State == CollectorState.Warning)
                        {
                            warnings++;
                            returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = entry.MachineName + "->" + dis.DiskInfo.Name,
                                   State = CollectorState.Warning,
                                   CurrentValue = dis.DiskInfo.BytesReadWritePerSec,
                                   RawDetails = string.Format("'{0}'-> {1} : {2} Bytes/Sec (Warning)", entry.MachineName, dis.DiskInfo.Name, dis.DiskInfo.BytesReadWritePerSec),
                                   HtmlDetails = string.Format("'{0}'-&gt; {1} : {2} Bytes/Sec (<b>Warning</b>)", entry.MachineName, dis.DiskInfo.Name, dis.DiskInfo.BytesReadWritePerSec)
                               });
                        }
                        else
                        {
                            success++;
                            returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = entry.MachineName + "->" + dis.DiskInfo.Name,
                                   State = CollectorState.Good,
                                   CurrentValue = dis.DiskInfo.BytesReadWritePerSec,
                                   RawDetails = string.Format("'{0}'-> {1} : {2} Bytes/Sec", entry.MachineName, dis.DiskInfo.Name, dis.DiskInfo.BytesReadWritePerSec),
                                   HtmlDetails = string.Format("'{0}'-&gt; {1} : {2} Bytes/Sec", entry.MachineName, dis.DiskInfo.Name, dis.DiskInfo.BytesReadWritePerSec)
                               });
                        }
                    }
                }
                returnState.CurrentValue = highestVal;

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
                        dt.Rows.Add(entry.MachineName, diInfo.DiskInfo.Name, diInfo.DiskInfo.BytesReadWritePerSec);
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
                entry.MachineName = pcNode.ReadXmlElementAttr("machine", ".");
                entry.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);
                entry.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                entry.UserName = pcNode.ReadXmlElementAttr("userName", "");
                entry.Password = pcNode.ReadXmlElementAttr("password", "");
                entry.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                entry.PassPhrase = pcNode.ReadXmlElementAttr("passPhrase", "");

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
                diskSpaceNode.SetAttributeValue("machine", entry.MachineName);
                diskSpaceNode.SetAttributeValue("sshPort", entry.SSHPort);
                diskSpaceNode.SetAttributeValue("sshSecOpt", entry.SSHSecurityOption.ToString());
                diskSpaceNode.SetAttributeValue("userName", entry.UserName);
                diskSpaceNode.SetAttributeValue("password", entry.Password);
                diskSpaceNode.SetAttributeValue("privateKeyFile", entry.PrivateKeyFile);
                diskSpaceNode.SetAttributeValue("passPhrase", entry.PassPhrase);

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
            Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHSecurityOption, MachineName, SSHPort, UserName, Password, PrivateKeyFile, PassPhrase);

            if (sshClient.IsConnected)
            {

                //First see if ANY subentry is for all
                bool addAll = (from LinuxDiskIOSubEntry d in SubItems
                               where d.Disk == "*"
                               select d).Count() > 0;
                if (addAll)
                {
                    LinuxDiskIOSubEntry alertDef = (from LinuxDiskIOSubEntry d in SubItems
                                                       where d.Disk == "*"
                                                       select d).FirstOrDefault();
                    foreach (Linux.DiskIOInfo di in DiskIOInfo.GetCurrentDiskStats(sshClient, 500))
                    {
                        DiskIOState dis = new DiskIOState() { DiskInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                        diskIOEntries.Add(dis);
                    }
                }
                else
                {
                    foreach (Linux.DiskIOInfo di in DiskIOInfo.GetCurrentDiskStats(sshClient, 500))
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
            }
            sshClient.Disconnect();

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
