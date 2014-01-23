using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("SQL Table Size Collector")]
    public class SqlTableSizeCollector : CollectorBase
    {
        public SqlTableSizeCollector()
        {
            AgentConfig = new SqlTableSizeCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState() { State = CollectorState.Good };
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            double totalValue = 0;
            try
            {
                SqlTableSizeCollectorConfig sqlTableSizeConfig = (SqlTableSizeCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Database table size(s)"));
                htmlTextTextDetails.AppendLine(string.Format("Database table size(s)"));
                
                foreach (SqlTableSizeCollectorEntry sqlTableSizeEntry in sqlTableSizeConfig.Entries)
                {
                    lastAction = string.Format("Getting table sizes for '{0}\\{1}'", sqlTableSizeEntry.SqlServer, sqlTableSizeEntry.Database);

                    sqlTableSizeEntry.RefreshRowCounts();
                    List<Tuple<TableSizeEntry, CollectorState>> states = sqlTableSizeEntry.GetStates();
                    plainTextDetails.AppendLine(string.Format("\tDatabase {0}", sqlTableSizeEntry));
                    htmlTextTextDetails.AppendLine(string.Format("<b>Database {0}</b>", sqlTableSizeEntry));
                    htmlTextTextDetails.AppendLine("<ul>");
                    foreach (var tableEntryState in states)
                    {
                        if (tableEntryState.Item1.RowCount > 0)
                            totalValue += tableEntryState.Item1.RowCount;
                        if (tableEntryState.Item2 == CollectorState.Error)
                        {
                            errors++;
                            if (tableEntryState.Item1.RowCount > 0)
                            {
                                plainTextDetails.AppendLine(string.Format("\t\t{0} - value '{1}' - Error (trigger {2})", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.ErrorValue));
                                htmlTextTextDetails.AppendLine(string.Format("<li>{0} - Value '{1}' - <b>Error</b> (trigger {2})</li>", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.ErrorValue));
                            }
                            else
                            {
                                plainTextDetails.AppendLine(string.Format("\t\t{0} - value '{1}' - Error ({2})", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.ErrorStr));
                                htmlTextTextDetails.AppendLine(string.Format("<li>{0} - Value '{1}' - <b>Error</b> ({2})</li>", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.ErrorStr));
                            }
                        }
                        else if (tableEntryState.Item2 == CollectorState.Warning)
                        {
                            warnings++;
                            plainTextDetails.AppendLine(string.Format("\t\t{0} - value '{1}' - Warning (trigger {2})", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.WarningValue));
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0} - Value '{1}' - <b>Warning</b> (trigger {2})</li>", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount, tableEntryState.Item1.WarningValue));
                        }
                        else
                        {
                            plainTextDetails.AppendLine(string.Format("\t\t{0} - value '{1}'", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount));
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0} - Value '{1}'</li>", tableEntryState.Item1.TableName, tableEntryState.Item1.RowCount));
                            success++;
                        }
                    }
                    htmlTextTextDetails.AppendLine("</ul>");
                }
                
                if (errors > 0 && warnings == 0)
                    returnState.State = CollectorState.Error;
                else if (warnings > 0)
                    returnState.State = CollectorState.Warning;
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = totalValue;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = string.Format("Last step: '{0}\r\n{1}", lastAction, ex.Message);
                returnState.HtmlDetails = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new SqlTableSizeCollectorViewDetails();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new SqlTableSizeCollectorEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SqlTableSizeCollectorDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new SqlTableSizeCollectorEditEntry();
        }
    }
}
