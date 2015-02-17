using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class BizTalkPortAndOrchsCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "BizTalkPortAndOrchsCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new BizTalkPortAndOrchsCollectorEditEntry(); } }
    }
}
