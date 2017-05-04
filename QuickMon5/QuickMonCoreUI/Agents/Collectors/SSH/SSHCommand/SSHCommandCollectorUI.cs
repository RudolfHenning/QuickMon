using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.UI
{
    public class SSHCommandCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "QuickMon.Collectors.RegistryQueryCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new RegistryQueryCollectorEditEntry(); } }
    }
}
