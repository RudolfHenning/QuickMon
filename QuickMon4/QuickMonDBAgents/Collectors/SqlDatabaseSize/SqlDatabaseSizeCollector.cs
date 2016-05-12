using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("SQL Database Size Collector"), Category("Database")]
    public class SqlDatabaseSizeCollector : CollectorAgentBase
    {
        public SqlDatabaseSizeCollector()
        {
            AgentConfig = new SqlDatabaseSizeCollectorConfig();
        }
        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            double totalValue = 0;
            try
            {
                SqlDatabaseSizeCollectorConfig currentConfig = (SqlDatabaseSizeCollectorConfig)AgentConfig;

                returnState.RawDetails = string.Format("Running {0} queries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Running {0} queries</b>", currentConfig.Entries.Count);
                returnState.CurrentValue = 0;
                foreach (SqlDatabaseSizeCollectorEntry entry in currentConfig.Entries)
                {
                    long size = entry.GetDBSize();
                    CollectorState currentState = entry.GetState(size);
                    totalValue += size;

                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Error,
                                ForAgent = entry.Database,
                                CurrentValue = string.Format("{0} MB", size),
                                RawDetails = string.Format("(Trigger '{0} MB')", entry.ErrorSizeMB)
                            });
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Warning,
                                ForAgent = entry.Database,
                                CurrentValue = string.Format("{0} MB", size),
                                RawDetails = string.Format("(Trigger '{0} MB')", entry.WarningSizeMB)
                            });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Good,
                                ForAgent = entry.Database,
                                CurrentValue = string.Format("{0} MB", size)
                            });
                    }
                }
                returnState.CurrentValue = totalValue;

                if (errors > 0 && warnings == 0 && success == 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> list = new List<System.Data.DataTable>();
            SqlDatabaseSizeCollectorConfig currentConfig = (SqlDatabaseSizeCollectorConfig)AgentConfig;

            System.Data.DataTable dt = new System.Data.DataTable("Database Sizes");
            dt.Columns.Add(new System.Data.DataColumn("Database", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Size (MB)", typeof(int)));
            foreach (SqlDatabaseSizeCollectorEntry entry in currentConfig.Entries)
            {
                dt.Rows.Add(entry.Database, entry.GetDBSize());
            }
            list.Add(dt);
            return list;
        }
    }
}
