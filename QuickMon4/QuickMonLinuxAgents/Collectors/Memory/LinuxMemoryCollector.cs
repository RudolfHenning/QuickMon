using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Memory Collector"), Category("Linux")]
    public class LinuxMemoryCollector : CollectorAgentBase
    {
        public LinuxMemoryCollector()
        {
            AgentConfig = new LinuxMemoryCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            double highestVal = 0;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                LinuxMemoryCollectorConfig currentConfig = (LinuxMemoryCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Querying {0} entries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Querying {0} entries</b>", currentConfig.Entries.Count);
                foreach (LinuxMemoryEntry entry in currentConfig.Entries)
                {
                    Linux.MemInfo memInfo = entry.GetMemoryInfo();
                    double percVal = memInfo.AvailablePerc;
                    if (percVal == 0)
                        percVal = memInfo.FreePerc;

                    CollectorState currentState = entry.GetState(percVal);                    

                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.MachineName,
                                State = CollectorState.Error,
                                CurrentValue = percVal,
                                RawDetails = string.Format("'{0}': {1} (Error)", entry.MachineName, percVal),
                                HtmlDetails = string.Format("'{0}': {1} (<b>Error</b>)", entry.MachineName, percVal)
                            });
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.MachineName,
                                State = CollectorState.Warning,
                                CurrentValue = percVal,
                                RawDetails = string.Format("'{0}': {1} (Warning)", entry.MachineName, percVal),
                                HtmlDetails = string.Format("'{0}': {1} (<b>Warning</b>)", entry.MachineName, percVal)
                            });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.MachineName,
                                State = CollectorState.Good,
                                CurrentValue = percVal,
                                RawDetails = string.Format("'{0}': {1}", entry.MachineName, percVal),
                                HtmlDetails = string.Format("'{0}': {1}", entry.MachineName, percVal)
                            });
                    }
                }
                returnState.CurrentValue = highestVal;

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
                dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Percentage Usage", typeof(double)));

                LinuxMemoryCollectorConfig currentConfig = (LinuxMemoryCollectorConfig)AgentConfig;
                foreach (LinuxMemoryEntry entry in currentConfig.Entries)
                {
                    Linux.MemInfo memInfo = entry.GetMemoryInfo();
                    double percVal = memInfo.AvailablePerc;
                    if (percVal == 0)
                        percVal = memInfo.FreePerc;
                    dt.Rows.Add(entry.MachineName, percVal);                    
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
