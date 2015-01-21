using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class PingCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "PingCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new PingCollectorEditHostAddress(); } }
        public override IAgentDetailWindow DetailViewWindow { get { return null; } }
    }
}
