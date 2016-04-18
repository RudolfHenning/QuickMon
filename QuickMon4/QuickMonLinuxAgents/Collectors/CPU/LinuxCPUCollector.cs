using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("CPU Collector"), Category("Linux")]
    public class LinuxCPUCollector : CollectorAgentBase
    {
        public LinuxCPUCollector()
        {
            AgentConfig = new LinuxCPUCollectorConfig();
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
}
