using QuickMon.SSH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QuickMon.NIX;

namespace QuickMon.Collectors
{
    [Description("NIX CPU Collector"), Category("SSH")]
    public class NixCPUCollector : CollectorAgentBase
    {
        public NixCPUCollector()
        {
            AgentConfig = new NixCPUCollectorConfig();
        }
        public override List<DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
    }
    public class NixCPUCollectorConfig : IAgentConfig
    {
        public NixCPUCollectorConfig()
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
            foreach (XmlElement pcNode in root.SelectNodes("nixCpu"))
            {
                NixCPUEntry entry = new NixCPUEntry();
                entry.SSHConnection = SSHConnectionDetails.FromXmlElement(pcNode);
                entry.MSSampleDelay = pcNode.ReadXmlElementAttr("msSampleDelay", 200);
                entry.UseOnlyTotalCPUvalue = pcNode.ReadXmlElementAttr("totalCPU", true);
                entry.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "80"));
                entry.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "99"));

                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();

            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><nixCpu /></config>";
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

    public class NixCPUEntry : SSHBaseConfigEntry
    {
        public NixCPUEntry()
        {
            UseOnlyTotalCPUvalue = true;
            WarningValue = 80;
            ErrorValue = 99;
            MSSampleDelay = 200;
        }
        public bool UseOnlyTotalCPUvalue { get; set; }
        public int MSSampleDelay { get; set; }
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
                ForAgent = Description
            };

            try
            {
                foreach (CPUInfo cpuInfo in CPUInfo.GetCurrentCPUPerc(SSHConnection.GetConnection(), MSSampleDelay))
                {
                    MonitorState cpuState = new MonitorState()
                    {
                        ForAgent = cpuInfo.Name,
                        State = GetState(cpuInfo.CPUPerc),
                        CurrentValue = cpuInfo.CPUPerc,
                        CurrentValueUnit = "%"
                    };
                    currentState.ChildStates.Add(cpuState);
                }

            }
            catch (Exception wsException)
            {
                currentState.State = CollectorState.Error;
                currentState.RawDetails = wsException.Message;
            }            

            return currentState;
        }

        public CollectorState GetState(double value)
        {
            CollectorState state = CollectorState.Good;
            if (WarningValue < ErrorValue)
            {
                if (ErrorValue <= value)
                    state = CollectorState.Error;
                else if (WarningValue <= value)
                    state = CollectorState.Warning;
            }
            else
            {
                if (ErrorValue >= value)
                    state = CollectorState.Error;
                else if (WarningValue >= value)
                    state = CollectorState.Warning;
            }
            return state;
        }
    }
}
