using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxCPUCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "LinuxCPUCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new LinuxCPUCollectorEditEntry(); } }
    }
}
