using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxMemoryCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "LinuxMemoryCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new LinuxMemoryCollectorEditEntry(); } }
    }
}
