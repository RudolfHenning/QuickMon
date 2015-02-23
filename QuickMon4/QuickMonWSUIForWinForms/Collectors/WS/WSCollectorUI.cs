using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors.WS
{
    public class WSCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "WSCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new WSCollectorEditEntry(); } }
    }
}
