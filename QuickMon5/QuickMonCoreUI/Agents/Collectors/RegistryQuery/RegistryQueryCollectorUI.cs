using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.UI
{
    public class RegistryQueryCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "QuickMon.Collectors.SSHCommandCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new SSHCommandCollectorEditEntry(); } }
    }
}
