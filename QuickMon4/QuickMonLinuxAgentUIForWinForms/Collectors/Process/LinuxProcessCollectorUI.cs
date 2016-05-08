using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxProcessCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "LinuxProcessCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new LinuxProcessCollectorEditEntry(); } }
    }
}
