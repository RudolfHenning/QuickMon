using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class DirectoryServicesQueryCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "DirectoryServicesQueryCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new DirectoryServicesQueryCollectorEditEntry(); } }
    }
}
