using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class PerfCounterCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "PerfCounterCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new PerfCounterCollectorEditEntry(); } }
        public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
