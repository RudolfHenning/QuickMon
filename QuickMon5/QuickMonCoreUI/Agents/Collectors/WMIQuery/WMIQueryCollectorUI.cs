using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public class WMIQueryCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "QuickMon.Collectors.WMIQueryCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new WMIQueryCollectorEditEntry(); } }
    }
}
