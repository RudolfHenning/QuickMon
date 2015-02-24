using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class PowerShellScriptRunnerCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "PowerShellScriptRunnerCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new PowerShellScriptRunnerCollectorEditEntry(); } }
    }
}
