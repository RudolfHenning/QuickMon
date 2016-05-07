using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Network IOs Collector"), Category("Linux")]
    public class LinuxNICCollector : CollectorAgentBase
    {
        public LinuxNICCollector()
        {
            AgentConfig = new LinuxNICCollectorConfig();
        }

        #region ICollector Members
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
                LinuxNICCollectorConfig currentConfig = (LinuxNICCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Querying {0} entries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Querying {0} entries</b>", currentConfig.Entries.Count);
                foreach (LinuxNICEntry entry in currentConfig.Entries)
                {
                    List<NICState> diss = entry.GetStates();
                    foreach (NICState dis in diss)
                    {
                        if (dis.State == CollectorState.Error)
                        {
                            errors++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.SSHConnection.ComputerName + "->" + dis.NICInfo.Name,
                                    State = CollectorState.Error,
                                    CurrentValue = dis.NICInfo.RTxBytes,
                                    RawDetails = string.Format("'{0}'-> {1} : {2}bytes/sec (Error)", entry.SSHConnection.ComputerName, dis.NICInfo.Name, dis.NICInfo.RTxBytes),
                                    HtmlDetails = string.Format("'{0}'-&gt; {1} : {2}bytes/sec (<b>Error</b>)", entry.SSHConnection.ComputerName, dis.NICInfo.Name, dis.NICInfo.RTxBytes)
                                });
                        }
                        else if (dis.State == CollectorState.Warning)
                        {
                            warnings++;
                            returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = entry.SSHConnection.ComputerName + "->" + dis.NICInfo.Name,
                                   State = CollectorState.Warning,
                                   CurrentValue = dis.NICInfo.RTxBytes,
                                   RawDetails = string.Format("'{0}'-> {1} : {2}bytes/sec (Warning)", entry.SSHConnection.ComputerName, dis.NICInfo.Name, dis.NICInfo.RTxBytes),
                                   HtmlDetails = string.Format("'{0}'-&gt; {1} : {2}bytes/sec (<b>Warning</b>)", entry.SSHConnection.ComputerName, dis.NICInfo.Name, dis.NICInfo.RTxBytes)
                               });
                        }
                        else
                        {
                            success++;
                            returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = entry.SSHConnection.ComputerName + "->" + dis.NICInfo.Name,
                                   State = CollectorState.Good,
                                   CurrentValue = dis.NICInfo.RTxBytes,
                                   RawDetails = string.Format("'{0}'-> {1} : {2}bytes/sec", entry.SSHConnection.ComputerName, dis.NICInfo.Name, dis.NICInfo.RTxBytes),
                                   HtmlDetails = string.Format("'{0}'-&gt; {1} : {2}bytes/sec", entry.SSHConnection.ComputerName, dis.NICInfo.Name, dis.NICInfo.RTxBytes)
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

                LinuxNICCollectorConfig currentConfig = (LinuxNICCollectorConfig)AgentConfig;
                foreach (LinuxNICEntry entry in currentConfig.Entries)
                {
                    foreach (NICState diInfo in entry.GetNICInfos())
                    {
                        dt.Rows.Add(entry.SSHConnection.ComputerName, diInfo.NICInfo.Name, diInfo.NICInfo.RTxBytes);
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

    public class LinuxNICCollectorConfig : ICollectorConfig
    {
        public LinuxNICCollectorConfig()
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
            foreach (XmlElement pcNode in root.SelectNodes("linux/nics"))
            {
                LinuxNICEntry entry = new LinuxNICEntry();
                entry.SSHConnection.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(pcNode.ReadXmlElementAttr("sshSecOpt", "password"));
                entry.SSHConnection.ComputerName = pcNode.ReadXmlElementAttr("machine", ".");
                entry.SSHConnection.SSHPort = pcNode.ReadXmlElementAttr("sshPort", 22);                
                entry.SSHConnection.UserName = pcNode.ReadXmlElementAttr("userName", "");
                entry.SSHConnection.Password = pcNode.ReadXmlElementAttr("password", "");
                entry.SSHConnection.PrivateKeyFile = pcNode.ReadXmlElementAttr("privateKeyFile", "");
                entry.SSHConnection.PassPhrase = pcNode.ReadXmlElementAttr("passPhrase", "");

                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement fileSystemNode in pcNode.SelectNodes("nic"))
                {
                    LinuxNICSubEntry fse = new LinuxNICSubEntry();
                    fse.NICName = fileSystemNode.ReadXmlElementAttr("name", "");
                    fse.WarningValueKB = fileSystemNode.ReadXmlElementAttr("warningValueKB", 1024);
                    fse.ErrorValueKB = fileSystemNode.ReadXmlElementAttr("errorValueKB", 5120);
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
            foreach (LinuxNICEntry entry in Entries)
            {
                XmlElement diskSpaceNode = config.CreateElement("nics");
                diskSpaceNode.SetAttributeValue("sshSecOpt", entry.SSHConnection.SSHSecurityOption.ToString());
                diskSpaceNode.SetAttributeValue("machine", entry.SSHConnection.ComputerName);
                diskSpaceNode.SetAttributeValue("sshPort", entry.SSHConnection.SSHPort);                
                diskSpaceNode.SetAttributeValue("userName", entry.SSHConnection.UserName);
                diskSpaceNode.SetAttributeValue("password", entry.SSHConnection.Password);
                diskSpaceNode.SetAttributeValue("privateKeyFile", entry.SSHConnection.PrivateKeyFile);
                diskSpaceNode.SetAttributeValue("passPhrase", entry.SSHConnection.PassPhrase);

                foreach (LinuxNICSubEntry fse in entry.SubItems)
                {
                    XmlElement fileSystemNode = config.CreateElement("nic");
                    fileSystemNode.SetAttributeValue("name", fse.NICName);
                    fileSystemNode.SetAttributeValue("warningValueKB", fse.WarningValueKB);
                    fileSystemNode.SetAttributeValue("errorValueKB", fse.ErrorValueKB);
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

    public class LinuxNICEntry : LinuxBaseEntry
    {
        public List<NICState> GetNICInfos()
        {
            List<NICState> nicEntries = new List<NICState>();
            using (Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHConnection))
            {

                if (sshClient.IsConnected)
                {
                    //First see if ANY subentry is for all
                    bool addAll = (from LinuxNICSubEntry d in SubItems
                                   where d.NICName == "*"
                                   select d).Count() > 0;
                    if (addAll)
                    {
                        LinuxNICSubEntry alertDef = (from LinuxNICSubEntry d in SubItems
                                                     where d.NICName == "*"
                                                     select d).FirstOrDefault();
                        foreach (Linux.NicInfo ni in NicInfo.GetCurrentNicStats(sshClient, 250))
                        {
                            NICState nis = new NICState() { NICInfo = ni, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                            nicEntries.Add(nis);
                        }
                    }
                    else
                    {
                        foreach (Linux.NicInfo di in NicInfo.GetCurrentNicStats(sshClient, 250))
                        {
                            LinuxNICSubEntry alertDef = (from LinuxNICSubEntry d in SubItems
                                                         where d.NICName.ToLower() == di.Name.ToLower()
                                                         select d).FirstOrDefault();

                            if (alertDef != null)
                            {
                                if (!nicEntries.Any(f => f.NICInfo.Name.ToLower() == di.Name.ToLower()))
                                {
                                    NICState dis = new NICState() { NICInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                                    nicEntries.Add(dis);
                                }
                            }
                        }
                    }
                }
                sshClient.Disconnect();
            }
            return nicEntries;
        }
        public List<NICState> GetStates()
        {
            List<NICState> states = new List<NICState>();

            foreach (NICState dis in GetNICInfos())
            {
                dis.State = CollectorState.Good;
                if (dis.NICInfo.RTxBytesPerSec >= (dis.AlertDefinition.ErrorValueKB * 1024))
                {
                    dis.State = CollectorState.Error;
                }
                else if (dis.NICInfo.RTxBytesPerSec >= (dis.AlertDefinition.WarningValueKB * 1024))
                {
                    dis.State = CollectorState.Warning;
                }
                states.Add(dis);

            }
            return states;
        }
        public override string TriggerSummary
        {
            get { return string.Format("{0} Network interface(s)", SubItems.Count); }
        }
    }

    public class LinuxNICSubEntry : ICollectorConfigSubEntry
    {
        public LinuxNICSubEntry()
        {
            WarningValueKB = 1024;
            ErrorValueKB = 5120;
        }
        public string NICName { get; set; }
        public long WarningValueKB { get; set; }
        public long ErrorValueKB { get; set; }

        #region ICollectorConfigSubEntry Members
        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", NICName, WarningValueKB, ErrorValueKB); }
        }
        #endregion
    }

    public class NICState
    {
        public Linux.NicInfo NICInfo { get; set; }
        public LinuxNICSubEntry AlertDefinition { get; set; }
        public CollectorState State { get; set; }
    }
}
