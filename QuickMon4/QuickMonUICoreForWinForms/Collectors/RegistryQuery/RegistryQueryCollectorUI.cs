using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class RegistryQueryCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "RegistryQueryCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new RegistryQueryCollectorEditEntry(); } }
        //public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
