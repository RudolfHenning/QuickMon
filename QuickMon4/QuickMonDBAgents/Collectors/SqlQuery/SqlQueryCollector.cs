using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Sql Query Collector"), Category("Database")]
    public class SqlQueryCollector : CollectorAgentBase
    {
        public SqlQueryCollector()
        {
            AgentConfig = new SqlQueryCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            throw new NotImplementedException();
        }

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
    }
}
