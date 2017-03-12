using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public class WSCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "QuickMon.Collectors.WSCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new WSCollectorEditEntry(); } }
    }
}
