using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Sql Table Size Collector"), Category("Database")]
    public class SqlTableSizeCollector : CollectorAgentBase
    {
        public SqlTableSizeCollector()
        {
            AgentConfig = new SqlTableSizeCollectorConfig();
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
                SqlTableSizeCollectorConfig currentConfig = (SqlTableSizeCollectorConfig)AgentConfig;

                returnState.RawDetails = string.Format("Querying {0} database(s)", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Querying {0} database(s)</b>", currentConfig.Entries.Count);
                returnState.CurrentValue = 0;
                foreach (SqlTableSizeCollectorEntry entry in currentConfig.Entries)
                {
                    entry.RefreshRowCounts();
                    List<Tuple<TableSizeEntry, CollectorState>> states = entry.GetStates();

                    MonitorState entryState = new MonitorState() { ForAgent = entry.Description };

                    foreach (var tableEntryState in states)
                    {
                        if (tableEntryState.Item1.RowCount > 0)
                            totalValue += tableEntryState.Item1.RowCount;
                        if (tableEntryState.Item2 == CollectorState.Error)
                        {
                            errors++;                            
                            entryState.ChildStates.Add(
                                    new MonitorState()
                                    {
                                        State = CollectorState.Error,
                                        ForAgent = tableEntryState.Item1.TableName,
                                        CurrentValue = string.Format("{0} row(s)", tableEntryState.Item1.RowCount),
                                        RawDetails = string.Format("'{0}' - {1} (Error, {2})", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, (tableEntryState.Item1.RowCount > 0 ? "Trigger " + tableEntryState.Item1.ErrorValue.ToString() : tableEntryState.Item1.ErrorStr)),
                                        HtmlDetails = string.Format("'{0}' - {1} (<b>Error, {2}</b>)", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, (tableEntryState.Item1.RowCount > 0 ? "Trigger " + tableEntryState.Item1.ErrorValue.ToString() : tableEntryState.Item1.ErrorStr))
                                    });
                        }
                        else if (tableEntryState.Item2 == CollectorState.Warning)
                        {
                            warnings++;
                            entryState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Warning,
                                    ForAgent = tableEntryState.Item1.TableName,
                                    CurrentValue = string.Format("{0} row(s)", tableEntryState.Item1.RowCount),
                                    RawDetails = string.Format("'{0}' - {1} (Warning, Trigger {2})", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount),
                                    HtmlDetails = string.Format("'{0}' - {1} (<b>Warning, Trigger {2}</b>)", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount)
                                });
                        }
                        else
                        {
                            success++;
                            entryState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Good,
                                    ForAgent = tableEntryState.Item1.TableName,
                                    CurrentValue = string.Format("{0} row(s)", tableEntryState.Item1.RowCount),
                                    RawDetails = string.Format("'{0}' - {1}", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount),
                                    HtmlDetails = string.Format("'{0}' - {1}", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount)
                                });
                        }
                    }
                    entryState.CurrentValue = totalValue;
                    returnState.ChildStates.Add(entryState);                    
                }

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
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            SqlTableSizeCollectorConfig currentConfig = (SqlTableSizeCollectorConfig)AgentConfig;
            foreach (SqlTableSizeCollectorEntry entry in currentConfig.Entries)
            {
                entry.RefreshRowCounts();
                tables.Add(entry.GetDetailDataTable());
            }

            return tables;
        }
    }
}
