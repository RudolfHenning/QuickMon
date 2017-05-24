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
    [Description("NIX Disk Free Space Collector"), Category("SSH")]
    public class NIXDiskSpaceCollector : CollectorAgentBase
    {
        public NIXDiskSpaceCollector()
        {
            AgentConfig = new NIXDiskSpaceCollectorConfig();
        }
        public override List<DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
    }
    public class NIXDiskSpaceCollectorConfig : ICollectorConfig
    {
        public NIXDiskSpaceCollectorConfig()
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

            foreach (XmlElement pcNode in root.SelectNodes("nixDiskSpaces"))
            {
                NIXDiskSpaceEntry entry = new NIXDiskSpaceEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(pcNode);
                entry.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement fileSystemNode in pcNode.SelectNodes("fileSystem"))
                {
                    NIXDiskSpaceSubEntry fse = new NIXDiskSpaceSubEntry();
                    fse.FileSystemName = fileSystemNode.ReadXmlElementAttr("name", "");
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
            foreach (NIXDiskSpaceEntry entry in Entries)
            {
                XmlElement nixDiskSpacesNode = config.CreateElement("nixDiskSpaces");
                entry.SSHConnection.SaveToXmlElementAttr(nixDiskSpacesNode);
                foreach (NIXDiskSpaceSubEntry fse in entry.SubItems)
                {
                    XmlElement fileSystemNode = config.CreateElement("fileSystem");
                    fileSystemNode.SetAttributeValue("name", fse.FileSystemName);
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
    public class NIXDiskSpaceEntry : SSHBaseConfigEntry
    {
        public NIXDiskSpaceEntry()
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
            List<DiskInfoState> fileSystemEntries = new List<DiskInfoState>();
            //First see if ANY subentry is for all
            bool addAll = (from NIXDiskSpaceSubEntry d in SubItems
                           where d.FileSystemName == "*"
                           select d).Count() > 0;
            
            if (addAll)
            {
                NIXDiskSpaceSubEntry alertDef = (from NIXDiskSpaceSubEntry d in SubItems
                                                   where d.FileSystemName == "*"
                                                   select d).FirstOrDefault();
                alertDef.PrimaryUIValue = false;
                foreach (DiskInfo di in DiskInfo.FromDfTk(sshClient))
                {

                    DiskInfoState dis = new DiskInfoState() { FileSystemInfo = di, State = CollectorState.NotAvailable, AlertDefinition = alertDef };
                    fileSystemEntries.Add(dis);
                }
            }
            else
            {
                foreach (DiskInfo di in DiskInfo.FromDfTk(sshClient))
                {
                    NIXDiskSpaceSubEntry alertDef = (from NIXDiskSpaceSubEntry d in SubItems
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
            #endregion

            int errors = 0;
            int warnings = 0;
            int success = 0;
            double average = 0;
            foreach (DiskInfoState dis in fileSystemEntries)
            {
                average += dis.FileSystemInfo.FreeSpacePerc;
                if (dis.FileSystemInfo.FreeSpacePerc <= dis.AlertDefinition.ErrorValue)
                {
                    dis.State = CollectorState.Error;
                    errors++;
                }
                else if (dis.FileSystemInfo.FreeSpacePerc <= dis.AlertDefinition.WarningValue)
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
                    currentState.CurrentValue = dis.FileSystemInfo.FreeSpacePerc.ToString("0.0");
                    currentState.CurrentValueUnit = "%";
                }

                MonitorState fileSystemState = new MonitorState()
                {
                    ForAgent = dis.FileSystemInfo.Name,
                    State = dis.State,
                    CurrentValue = dis.FileSystemInfo.FreeSpacePerc.ToString("0.0"),
                    CurrentValueUnit = "%"
                };
                currentState.ChildStates.Add(fileSystemState);
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
                currentState.CurrentValueUnit = "% (avg)";
            }

            return currentState;
        }
        
    }
    public class NIXDiskSpaceSubEntry : ICollectorConfigSubEntry
    {
        public NIXDiskSpaceSubEntry()
        {
            WarningValue = 10;
            ErrorValue = 5;
        }
        public string FileSystemName { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }
        public bool PrimaryUIValue { get; set; }

        #region ICollectorConfigSubEntry Members
        public string Description
        {
            get { return string.Format("{0} Warn:{1} Err:{2}", FileSystemName, WarningValue, ErrorValue); }
        }
        #endregion
    }
    internal class DiskInfoState
    {
        public DiskInfo FileSystemInfo { get; set; }
        public NIXDiskSpaceSubEntry AlertDefinition { get; set; }
        public CollectorState State { get; set; }
    }
}
