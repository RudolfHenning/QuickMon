﻿using System;
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
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                SqlQueryCollectorConfig currentConfig = (SqlQueryCollectorConfig)AgentConfig;

                returnState.RawDetails = string.Format("Running {0} queries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Running {0} queries</b>", currentConfig.Entries.Count);
                returnState.CurrentValue = 0;
                foreach (SqlQueryCollectorEntry entry in currentConfig.Entries)
                {
                    object value = entry.GetStateQueryValue();
                    CollectorState currentState = CollectorAgentReturnValueCompareEngine.GetState(entry.ValueReturnCheckSequence, entry.SuccessMatchType, entry.SuccessValueOrMacro,
                        entry.WarningMatchType, entry.WarningValueOrMacro, entry.ErrorMatchType, entry.ErrorValueOrMacro, value);
                    if (value.IsNumber())
                    {
                        returnState.CurrentValue = Double.Parse(returnState.CurrentValue.ToString()) + Double.Parse(value.ToString());
                    }
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Error,
                                ForAgent = entry.Name,
                                CurrentValue = value//,
                                //RawDetails = string.Format("(Trigger '{0}')", entry.TriggerSummary)
                            });
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Warning,
                                ForAgent = entry.Name,
                                CurrentValue = value//,
                                //RawDetails = string.Format("(Trigger '{0}')", entry.TriggerSummary)
                            });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                State = CollectorState.Good,
                                ForAgent = entry.Name,
                                CurrentValue = value
                            });
                    }                    
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
            SqlQueryCollectorConfig currentConfig = (SqlQueryCollectorConfig)AgentConfig;
            int tableNo = 1;
            foreach (SqlQueryCollectorEntry entry in currentConfig.Entries)
            {
                System.Data.DataTable dt = entry.GetDetailQueryDataTable();
                if (entry.Name.Length > 0)
                    dt.TableName = entry.Name;
                else
                    dt.TableName = "Table " + tableNo.ToString();
                while ( (from t in tables
                         where t.TableName == dt.TableName
                         select t).Count() > 0)
                {
                    dt.TableName = "Table " + tableNo.ToString();
                    tableNo++;
                }
                tables.Add(dt);
                tableNo++;
            }            
            return tables;
        }
    }
}
