using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickMon.UI;

namespace QuickMon.UI
{
    public class SqlDatabaseSizeCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "QuickMon.Collectors.SqlDatabaseSizeCollector"; } }
        public override ICollectorConfigEntryEditWindow DetailEditor { get { return new SqlDatabaseSizeCollectorEditEntry(); } }
    }
}
