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

        public override MonitorState RefreshState()
        {
            throw new NotImplementedException();
        }

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
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
            throw new NotImplementedException();
        }
        public string ToXml()
        {
            throw new NotImplementedException();
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

        public override string TriggerSummary
        {
            get { throw new NotImplementedException(); }
        }
    }
}
