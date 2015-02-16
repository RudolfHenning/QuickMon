using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickMon.UI;

namespace QuickMon.Collectors
{
    public class SqlDatabaseSizeCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "SqlDatabaseSizeCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new SqlDatabaseSizeCollectorEditEntry(); } }
    }
}
