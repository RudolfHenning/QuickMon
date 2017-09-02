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
    [Description("NIX Memory Collector"), Category("SSH")]
    public class NIXMemoryCollector : CollectorAgentBase
    {
        public NIXMemoryCollector()
        {
            AgentConfig = new NixMemoryCollectorConfig();
        }
    }
    public class NixMemoryCollectorConfig : ICollectorConfig
    {
        public NixMemoryCollectorConfig()
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
            foreach (XmlElement pcNode in root.SelectNodes("nixMems/nixMem"))
            {
                NixMemoryEntry entry = new NixMemoryEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(pcNode);
                entry.MemoryType = NuxMemoryTypeTypeConverter.FromString(pcNode.ReadXmlElementAttr("memoryType", "MemAvailable"));
                entry.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "20"));
                entry.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "10"));
                
                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode nixMemsNode = root.SelectSingleNode("nixMems");
            nixMemsNode.InnerXml = "";
            foreach (NixMemoryEntry entry in Entries)
            {
                XmlElement nixMemNode = config.CreateElement("nixMem");
                entry.SSHConnection.SaveToXmlElementAttr(nixMemNode);
                nixMemNode.SetAttributeValue("memoryType", entry.MemoryType.ToString());
                nixMemNode.SetAttributeValue("warningValue", entry.WarningValue);
                nixMemNode.SetAttributeValue("errorValue", entry.ErrorValue);
                
                nixMemsNode.AppendChild(nixMemNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><nixMems /></config>";
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
    public class NixMemoryEntry : SSHBaseConfigEntry
    {
        public NixMemoryEntry()
        {
            MemoryType = Collectors.LinuxMemoryType.MemAvailable;
            WarningValue = 20;
            ErrorValue = 10;
        }

        public LinuxMemoryType MemoryType { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        public override string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}%, Err: {1}%", WarningValue, ErrorValue);
            }
        }

        public override MonitorState GetCurrentState()
        {
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description,
                State = CollectorState.NotAvailable,
                CurrentValueUnit = "%"
            };
            try
            {
                MemInfo mi = new MemInfo();
                Renci.SshNet.SshClient sshClient = SSHConnection.GetConnection();
                mi = MemInfo.FromCatProcMeminfo(sshClient);
                SSHConnection.CloseConnection();
                double outputValue = 0;
                if (MemoryType == LinuxMemoryType.MemAvailable)
                {
                    outputValue = mi.AvailablePerc;
                    if (outputValue == 0 && mi.TotalKB > 0)
                    {
                        outputValue = (mi.FreeKB + mi.Buffers + mi.Cached) / mi.TotalKB;
                    }
                }
                else if (MemoryType == LinuxMemoryType.MemFree)
                {
                    outputValue = mi.FreePerc;
                }
                else
                {
                    outputValue = mi.SwapFreePerc;
                }
                currentState.CurrentValue = outputValue.ToString("0.0");
                if (ErrorValue >= outputValue)
                    currentState.State = CollectorState.Error;
                else if (WarningValue >= outputValue)
                    currentState.State = CollectorState.Warning;
                else
                    currentState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                currentState.State = CollectorState.Error;
                currentState.RawDetails = ex.Message;
            }
            return currentState;
        }
    }

    public enum LinuxMemoryType
    {
        MemAvailable,
        MemFree,
        SwapFree
    }

    public static class NuxMemoryTypeTypeConverter
    {
        public static LinuxMemoryType FromString(string value)
        {
            if (value.ToLower() == "memavailable")
                return LinuxMemoryType.MemAvailable;
            else if (value.ToLower() == "memfree")
                return LinuxMemoryType.MemFree;
            else
                return LinuxMemoryType.SwapFree;
        }
    }
}
