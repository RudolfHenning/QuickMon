using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxDiskSpaceCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "LinuxDiskSpaceCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new LinuxDiskSpaceCollectorEditEntry(); } }
    }
}
