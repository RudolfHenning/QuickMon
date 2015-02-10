using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class SqlQueryCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "SqlQueryCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new SqlQueryCollectorEditEntry(); } }
    }
}
