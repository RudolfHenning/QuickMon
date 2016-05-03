using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxSSHCommandCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "LinuxSSHCommandCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new LinuxSSHCommandCollectorEditEntry(); } }
    }
}
