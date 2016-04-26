using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors.NIC
{
    public class LinuxNICCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "LinuxNICCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new LinuxNICCollectorEditEntry(); } }
    }
}
