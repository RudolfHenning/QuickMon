using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class WindowsServiceStateCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "WindowsServiceStateCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new ServiceStateCollectorEditEntry(); } }
        //public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
