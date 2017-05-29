using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.UI
{
    public class NIXNICCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "QuickMon.Collectors.NIXNICCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new NIXNICCollectorEditEntry(); } }
    }
}
