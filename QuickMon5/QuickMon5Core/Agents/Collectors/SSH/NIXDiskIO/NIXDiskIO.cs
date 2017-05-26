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
        public override List<DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
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
                    fse.WarningValue = fileSystemNode.ReadXmlElementAttr("warningValue", 10.0d);
                    fse.ErrorValue = fileSystemNode.ReadXmlElementAttr("errorValue", 5.0d);
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
                    fileSystemNode.SetAttributeValue("warningValue", fse.WarningValue);
                    fileSystemNode.SetAttributeValue("errorValue", fse.ErrorValue);
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
                if (dis.DiskInfo.BytesReadWritePerSec >= dis.AlertDefinition.ErrorValue)
                {
                    dis.State = CollectorState.Error;
                }
                else if (dis.DiskInfo.BytesReadWritePerSec >= dis.AlertDefinition.WarningValue)
                {
                    dis.State = CollectorState.Warning;
                }
                else
                {
                    dis.State = CollectorState.Good;
                    success++;
                }
                if (dis.AlertDefinition.PrimaryUIValue)
                {
                    currentState.CurrentValue = dis.DiskInfo.BytesReadWritePerSec.ToString("0.0");
                    currentState.CurrentValueUnit = "Bytes/Sec";
                }

                MonitorState diskIOState = new MonitorState()
                {
                    ForAgent = dis.DiskInfo.Name,
                    State = dis.State,
                    CurrentValue = dis.DiskInfo.BytesReadWritePerSec.ToString("0.0"),
                    CurrentValueUnit = "Bytes/Sec",
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
                currentState.CurrentValue = (average / currentState.ChildStates.Count).ToString("0.0");
                currentState.CurrentValueUnit = "Bytes/Sec (avg)";
            }

            return currentState;
        }

    }

    public class NIXDiskIOSubEntry : ICollectorConfigSubEntry
    {
        public NIXDiskIOSubEntry()
        {
            WarningValue = 10;
            ErrorValue = 5;
        }

        public string DiskName { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }
        public bool PrimaryUIValue { get; set; }

        #region ICollectorConfigSubEntry Members
        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", DiskName, WarningValue, ErrorValue); }
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
