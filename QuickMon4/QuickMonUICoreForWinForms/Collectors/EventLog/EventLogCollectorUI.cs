using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public  class EventLogCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "EventLogCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new EventLogCollectorEditEntry(); } }
        //public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
