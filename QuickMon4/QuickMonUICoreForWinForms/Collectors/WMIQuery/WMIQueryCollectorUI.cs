using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class WMIQueryCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "WMIQueryCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new WMIQueryCollectorEditEntry(); } }
        //public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
