using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Ping Collector"), Category("General")]
    public class PingCollector : CollectorAgentBase
    {
        public PingCollector()
        {
            AgentConfig = new PingCollectorConfig();
        }
        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            long pingTotalTime = 0;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                PingCollectorConfig currentConfig = (PingCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Pinging {0} entries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Pinging {0} entries</b>", currentConfig.Entries.Count);
                foreach (PingCollectorHostEntry host in currentConfig.Entries)
                {
                    PingCollectorResult pingResult = host.Ping();
                    CollectorState currentState = host.GetState(pingResult);
                    if (pingResult.Success)
                    {
                        pingTotalTime += pingResult.PingTime;
                        if (currentState == CollectorState.Error)
                        {
                            errors++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = host.Address,
                                    State = CollectorState.Error,
                                    CurrentValue = pingResult.PingTime,
                                    RawDetails = string.Format("Response details : '{0}'", pingResult.ResponseDetails)
                                });
                        }
                        else if (currentState == CollectorState.Warning)
                        {
                            warnings++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = host.Address,
                                    State = CollectorState.Warning,
                                    CurrentValue = pingResult.PingTime,
                                    RawDetails = string.Format("Response details : '{0}'", pingResult.ResponseDetails)                                    
                                });
                        }
                        else
                        {
                            success++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = host.Address,
                                    State = CollectorState.Good,
                                    CurrentValue = pingResult.PingTime,
                                    RawDetails = string.Format("Response details : '{0}'", pingResult.ResponseDetails)                                    
                                });
                        }
                    }
                    else
                    {
                        errors++;
                        returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = host.Address,
                                    State = CollectorState.Error,
                                    CurrentValue = "",
                                    RawDetails = string.Format("Response details : '{0}'", pingResult.ResponseDetails)                                    
                                });
                    }
                }
                returnState.CurrentValue = pingTotalTime;

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
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Host name", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Success", typeof(bool)));
                dt.Columns.Add(new System.Data.DataColumn("Ping time", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Response", typeof(string)));                

                PingCollectorConfig currentConfig = (PingCollectorConfig)AgentConfig;
                foreach (PingCollectorHostEntry host in currentConfig.Entries) //.OrderBy(h => ((PingCollectorHostEntry)h).Address))
                {
                    PingCollectorResult pingResult = host.Ping();
                    dt.Rows.Add(host.Address, pingResult.Success, pingResult.PingTime, pingResult.ResponseDetails);
                }
            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            tables.Add(dt);
            return tables;
        }
    }
}
