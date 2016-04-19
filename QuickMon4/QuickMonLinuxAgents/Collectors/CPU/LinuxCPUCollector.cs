using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("CPU Collector"), Category("Linux")]
    public class LinuxCPUCollector : CollectorAgentBase
    {
        public LinuxCPUCollector()
        {
            AgentConfig = new LinuxCPUCollectorConfig();
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
                LinuxCPUCollectorConfig currentConfig = (LinuxCPUCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Querying {0} entries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Querying {0} entries</b>", currentConfig.Entries.Count);
                foreach (LinuxCPUEntry entry in currentConfig.Entries)
                {
                    foreach(Linux.CPUInfo cpuInfo in  entry.GetCPUInfos())
                    {
                        if (highestVal < cpuInfo.CPUPerc)
                            highestVal = cpuInfo.CPUPerc;
                        CollectorState currentState = entry.GetState(cpuInfo.CPUPerc);
                        if (currentState == CollectorState.Error)
                        {
                            errors++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.MachineName + "(" + cpuInfo.Name + ")",
                                    State = CollectorState.Error,
                                    CurrentValue = cpuInfo.CPUPerc,
                                    RawDetails = string.Format("'{0}': {1} (Error)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc),
                                    HtmlDetails = string.Format("'{0}': {1} (<b>Error</b>)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc)
                                });
                        }
                        else if (currentState == CollectorState.Warning)
                        {
                            warnings++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.MachineName + "(" + cpuInfo.Name + ")",
                                    State = CollectorState.Warning,
                                    CurrentValue = cpuInfo.CPUPerc,
                                    RawDetails = string.Format("'{0}': {1} (Warning)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc),
                                    HtmlDetails = string.Format("'{0}': {1} (<b>Warning</b>)", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc)
                                });
                        }
                        else
                        {
                            success++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    ForAgent = entry.MachineName + "(" + cpuInfo.Name + ")",
                                    State = CollectorState.Good,
                                    CurrentValue = cpuInfo.CPUPerc,
                                    RawDetails = string.Format("'{0}': {1}", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc),
                                    HtmlDetails = string.Format("'{0}': {1}", entry.MachineName + "(" + cpuInfo.Name + ")", cpuInfo.CPUPerc)
                                });
                        }
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
                dt.Columns.Add(new System.Data.DataColumn("CPU", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Percentage Usage", typeof(double)));

                LinuxCPUCollectorConfig currentConfig = (LinuxCPUCollectorConfig)AgentConfig;
                foreach (LinuxCPUEntry entry in currentConfig.Entries)
                {
                    foreach (Linux.CPUInfo cpuInfo in entry.GetCPUInfos())
                    {
                        dt.Rows.Add(entry.MachineName, cpuInfo.Name, cpuInfo.CPUPerc);
                    }                    
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
