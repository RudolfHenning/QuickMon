using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    class LinuxDiskIOCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "LinuxDiskIOCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new LinuxDiskIOCollectorEditEntry(); } }
    }
}
