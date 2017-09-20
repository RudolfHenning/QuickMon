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
   [Description("NIX Disk IO Collector"), Category("SSH")]
   public  class NIXDiskIOCollector : CollectorAgentBase
    {
        public NIXDiskIOCollector()
        {
            AgentConfig = new NIXDiskIOCollectorConfig();
        }
    }
    public class NIXDiskIOCollectorConfig : ICollectorConfig
    {
        public NIXDiskIOCollectorConfig()
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

            foreach (XmlElement pcNode in root.SelectNodes("nixDiskIOs"))
            {
                NIXDiskIOEntry entry = new NIXDiskIOEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(pcNode);
                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement fileSystemNode in pcNode.SelectNodes("disk"))
                {
                    NIXDiskIOSubEntry fse = new NIXDiskIOSubEntry();
                    fse.DiskName = fileSystemNode.ReadXmlElementAttr("name", "");
                    if (fileSystemNode.HasAttribute("warningValueKB"))
                        fse.WarningValueKB = fileSystemNode.ReadXmlElementAttr("warningValueKB", 100.0d);
                    else
                        fse.WarningValueKB = fileSystemNode.ReadXmlElementAttr("warningValue", 100.0d);
                    if (fileSystemNode.HasAttribute("errorValueKB"))
                        fse.ErrorValueKB = fileSystemNode.ReadXmlElementAttr("errorValueKB", 512.0d);
                    else
                        fse.ErrorValueKB = fileSystemNode.ReadXmlElementAttr("errorValue", 512.0d);
                    fse.PrimaryUIValue = fileSystemNode.ReadXmlElementAttr("primaryUIValue", false);
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
            foreach (NIXDiskIOEntry entry in Entries)
            {
                XmlElement nixDiskSpacesNode = config.CreateElement("nixDiskIOs");
                entry.SSHConnection.SaveToXmlElementAttr(nixDiskSpacesNode);
                foreach (NIXDiskIOSubEntry fse in entry.SubItems)
                {
                    XmlElement fileSystemNode = config.CreateElement("disk");
                    fileSystemNode.SetAttributeValue("name", fse.DiskName);
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
    public class NIXDiskIOEntry : SSHBaseConfigEntry
    {
        public NIXDiskIOEntry()
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
            List<DiskIOInfoState> diskEntries = new List<DiskIOInfoState>();
            //First see if ANY subentry is for all
            bool addAll = (from NIXDiskIOSubEntry d in SubItems
                           where d.DiskName == "*"
                           select d).Count() > 0;

            if (addAll)
            {
                NIXDiskIOSubEntry alertDef = (from NIXDiskIOSubEntry d in SubItems
                                                 where d.DiskName == "*"
                                                 select d).FirstOrDefault();
                alertDef.PrimaryUIValue = false;
                foreach (DiskIOInfo di in DiskIOInfo.GetCurrentDiskStats(sshClient, 250))
                {

                    DiskIOInfoState dis = new DiskIOInfoState() { DiskInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                    diskEntries.Add(dis);
                }
            }
            else
            {
                foreach (DiskIOInfo di in DiskIOInfo.GetCurrentDiskStats(sshClient, 250))
                {
                    NIXDiskIOSubEntry alertDef = (from NIXDiskIOSubEntry d in SubItems
                                                     where d.DiskName.ToLower() == di.Name.ToLower()
                                                     select d).FirstOrDefault();

                    if (alertDef != null)
                    {
                        if (!diskEntries.Any(f => f.DiskInfo.Name.ToLower() == di.Name.ToLower()))
                        {
                            DiskIOInfoState dis = new DiskIOInfoState() { DiskInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                            diskEntries.Add(dis);
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
            foreach (DiskIOInfoState dis in diskEntries)
            {
                average += dis.DiskInfo.BytesReadWritePerSec;
                if (dis.DiskInfo.BytesReadWritePerSec >= (dis.AlertDefinition.ErrorValueKB * 1024))
                {
                    dis.State = CollectorState.Error;
                    errors++;
                }
                else if (dis.DiskInfo.BytesReadWritePerSec >= (dis.AlertDefinition.WarningValueKB * 1024))
                {
                    dis.State = CollectorState.Warning;
                    warnings++;
                }
                else
                {
                    dis.State = CollectorState.Good;
                    success++;
                }
                string formatValue = FormatUtils.FormatFileSizePerSec(dis.DiskInfo.BytesReadWritePerSec);
                if (dis.AlertDefinition.PrimaryUIValue)
                {
                    currentState.CurrentValue = formatValue.Split(' ')[0];
                    currentState.CurrentValueUnit = formatValue.Split(' ')[1];
                }

                MonitorState diskIOState = new MonitorState()
                {
                    ForAgent = dis.DiskInfo.Name,
                    State = dis.State,
                    CurrentValue = formatValue.Split(' ')[0],
                    CurrentValueUnit = formatValue.Split(' ')[1],
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
                string formatValue = FormatUtils.FormatFileSizePerSec((long)((average / currentState.ChildStates.Count)));
                currentState.CurrentValue = formatValue.Split(' ')[0];
                currentState.CurrentValueUnit = formatValue.Split(' ')[1];
            }

            return currentState;
        }
    }

    public class NIXDiskIOSubEntry : ICollectorConfigSubEntry
    {
        public NIXDiskIOSubEntry()
        {
            WarningValueKB = 10;
            ErrorValueKB = 5;
        }

        public string DiskName { get; set; }
        public double WarningValueKB { get; set; }
        public double ErrorValueKB { get; set; }
        public bool PrimaryUIValue { get; set; }

        #region ICollectorConfigSubEntry Members
        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", DiskName, WarningValueKB, ErrorValueKB); }
        }
        #endregion
    }

    public class DiskIOInfoState
    {
        public DiskIOInfo DiskInfo { get; set; }
        public NIXDiskIOSubEntry AlertDefinition { get; set; }
        public CollectorState State { get; set; }
    }
}
