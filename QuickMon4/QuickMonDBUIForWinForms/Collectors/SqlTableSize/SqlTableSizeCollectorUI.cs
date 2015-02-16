using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickMon.UI;

namespace QuickMon.Collectors
{
    public class SqlTableSizeCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "SqlTableSizeCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new SqlTableSizeCollectorEditEntry(); } }
    }
}
