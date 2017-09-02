using QuickMon.NIX;
using QuickMon.SSH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("NIX NIC Collector"), Category("SSH")]
    public class NIXNICCollector : CollectorAgentBase
    {
        public NIXNICCollector()
        {
            AgentConfig = new NIXNICCollectorConfig();
        }
    }
    public class NIXNICCollectorConfig : ICollectorConfig
    {
        public NIXNICCollectorConfig()
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

            foreach (XmlElement pcNode in root.SelectNodes("nixNICs"))
            {
                NIXNICEntry entry = new NIXNICEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(pcNode);
                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement nicNode in pcNode.SelectNodes("nic"))
                {
                    NIXNICSubEntry fse = new NIXNICSubEntry();
                    fse.NICName = nicNode.ReadXmlElementAttr("name", "");
                    fse.WarningValueKB = nicNode.ReadXmlElementAttr("warningValueKB", 1024);
                    fse.ErrorValueKB = nicNode.ReadXmlElementAttr("errorValueKB", 5120);
                    fse.PrimaryUIValue = nicNode.ReadXmlElementAttr("primaryUIValue", false);
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
            root.InnerXml = "";
            foreach (NIXNICEntry entry in Entries)
            {
                XmlElement nixDiskSpacesNode = config.CreateElement("nixNICs");
                entry.SSHConnection.SaveToXmlElementAttr(nixDiskSpacesNode);
                foreach (NIXNICSubEntry fse in entry.SubItems)
                {
                    XmlElement fileSystemNode = config.CreateElement("nic");
                    fileSystemNode.SetAttributeValue("name", fse.NICName);
                    fileSystemNode.SetAttributeValue("warningValueKB", fse.WarningValueKB);
                    fileSystemNode.SetAttributeValue("errorValueKB", fse.ErrorValueKB);
                    fileSystemNode.SetAttributeValue("primaryUIValue", fse.PrimaryUIValue);
                    nixDiskSpacesNode.AppendChild(fileSystemNode);
                }
                root.AppendChild(nixDiskSpacesNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config></config>";
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
    public class NIXNICEntry : SSHBaseConfigEntry
    {
        public NIXNICEntry()
        {
            SubItems = new List<ICollectorConfigSubEntry>();
        }
        public override string TriggerSummary
        {
            get { return string.Format("{0} File system(s)", SubItems.Count); }
        }

        public override MonitorState GetCurrentState()
        {
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description,
                State = CollectorState.None,
                CurrentValue = ""
            };

            Renci.SshNet.SshClient sshClient = SSHConnection.GetConnection();

            #region Get Disk infos and states
            List<NICInfoState> nicEntries = new List<NICInfoState>();
            //First see if ANY subentry is for all
            bool addAll = (from NIXNICSubEntry d in SubItems
                           where d.NICName == "*"
                           select d).Count() > 0;

            if (addAll)
            {
                NIXNICSubEntry alertDef = (from NIXNICSubEntry d in SubItems
                                              where d.NICName == "*"
                                              select d).FirstOrDefault();
                alertDef.PrimaryUIValue = false;
                foreach (NicInfo di in NicInfo.GetCurrentNicStats(sshClient, 250))
                {

                    NICInfoState dis = new NICInfoState() { NICInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                    nicEntries.Add(dis);
                }
            }
            else
            {
                foreach (NicInfo di in NicInfo.GetCurrentNicStats(sshClient, 250))
                {
                    NIXNICSubEntry alertDef = (from NIXNICSubEntry d in SubItems
                                                  where d.NICName.ToLower() == di.Name.ToLower()
                                                  select d).FirstOrDefault();

                    if (alertDef != null)
                    {
                        if (!nicEntries.Any(f => f.NICInfo.Name.ToLower() == di.Name.ToLower()))
                        {
                            NICInfoState dis = new NICInfoState() { NICInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                            nicEntries.Add(dis);
                        }
                    }
                }
            }
            #endregion

            SSHConnection.CloseConnection();

            int errors = 0;
            int warnings = 0;
            int success = 0;
            double average = 0;
            foreach (NICInfoState dis in nicEntries)
            {
                average += dis.NICInfo.RTxBytesPerSec;
                if (dis.NICInfo.RTxBytesPerSec >= dis.AlertDefinition.ErrorValueKB * 1024)
                {
                    dis.State = CollectorState.Error;
                    errors++;
                }
                else if (dis.NICInfo.RTxBytesPerSec >= dis.AlertDefinition.WarningValueKB * 1024)
                {
                    dis.State = CollectorState.Warning;
                    warnings++;
                }
                else
                {
                    dis.State = CollectorState.Good;
                    success++;
                }
                if (dis.AlertDefinition.PrimaryUIValue)
                {
                    currentState.CurrentValue = (dis.NICInfo.RTxBytesPerSec/1024).ToString("0.00");
                    currentState.CurrentValueUnit = "KB/Sec";
                }

                MonitorState diskIOState = new MonitorState()
                {
                    ForAgent = dis.NICInfo.Name,
                    State = dis.State,
                    CurrentValue = (dis.NICInfo.RTxBytesPerSec / 1024).ToString("0.00"),
                    CurrentValueUnit = "KB/Sec",
                    PrimaryUIValue = dis.AlertDefinition.PrimaryUIValue
                };
                currentState.ChildStates.Add(diskIOState);
            }
            if (errors > 0 && warnings == 0 && success == 0) // any errors
                currentState.State = CollectorState.Error;
            else if (errors > 0 || warnings > 0) //any warnings
                currentState.State = CollectorState.Warning;
            else
                currentState.State = CollectorState.Good;

            if (currentState.CurrentValue.ToString() == "" && currentState.ChildStates.Count > 0)
            {
                currentState.CurrentValue = ((average/1024 )/ currentState.ChildStates.Count).ToString("0.00");
                currentState.CurrentValueUnit = "KB/Sec (avg)";
            }

            return currentState;
        }

    }
    public class NIXNICSubEntry : ICollectorConfigSubEntry
    {
        public NIXNICSubEntry()
        {
            WarningValueKB = 1024;
            ErrorValueKB = 5120;
        }
        public string NICName { get; set; }
        public long WarningValueKB { get; set; }
        public long ErrorValueKB { get; set; }
        public bool PrimaryUIValue { get; set; }

        #region ICollectorConfigSubEntry Members
        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", NICName, WarningValueKB, ErrorValueKB); }
        }
        #endregion
    }
    public class NICInfoState
    {
        public NicInfo NICInfo { get; set; }
        public NIXNICSubEntry AlertDefinition { get; set; }
        public CollectorState State { get; set; }
    }
}
