using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors.BizTalkSuspendedCount
{
    public class BizTalkSuspendedCountCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "BizTalkSuspendedCountCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new BizTalkSuspendedCountCollectorEditEntry(); } }
    }
}
