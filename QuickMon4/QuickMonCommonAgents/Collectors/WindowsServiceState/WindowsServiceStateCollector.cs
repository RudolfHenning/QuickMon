using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Windows Service State Collector"), Category("General")]
    public class WindowsServiceStateCollector : CollectorAgentBase
    {
        public WindowsServiceStateCollector()
        {
            AgentConfig = new WindowsServiceStateCollectorConfig();
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
                WindowsServiceStateCollectorConfig currentConfig = (WindowsServiceStateCollectorConfig)AgentConfig;
                foreach (WindowsServiceStateHostEntry ssd in currentConfig.Entries)
                {
                    lastAction = "Checking services on " + ssd.MachineName;
                    var serviceStates = ssd.GetServiceStates();
                    lastAction = "Checking service states of " + ssd.MachineName;
                    CollectorState currentState = ssd.GetState(serviceStates);
                    string machineName = ssd.MachineName;
                    if (machineName == "." || machineName.ToLower() == "localhost")
                        machineName = System.Net.Dns.GetHostName();

                    MonitorState machineState = new MonitorState()
                                {
                                    State = currentState,
                                    ForAgent = machineName
                                };

                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        //returnState.RawDetails = string.Format("{0} (Error)", ssd.MachineName);
                        //returnState.HtmlDetails = string.Format("{0} <b>Error</b>", ssd.MachineName);
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        //returnState.RawDetails = string.Format("{0} (Warning)", ssd.MachineName);
                        //returnState.HtmlDetails = string.Format("{0} <b>Warning</b>", ssd.MachineName);
                    }
                    else
                    {
                        success++;
                        //returnState.RawDetails = string.Format("{0} (Success)", ssd.MachineName);
                        //returnState.HtmlDetails = string.Format("{0} <b>Success</b>", ssd.MachineName);
                    }
                    foreach (ServiceStateInfo serviceEntry in serviceStates)
                    {
                        machineState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = (serviceEntry.Status == System.ServiceProcess.ServiceControllerStatus.Stopped ? CollectorState.Error : serviceEntry.Status == System.ServiceProcess.ServiceControllerStatus.Running ? CollectorState.Good: CollectorState.Warning) ,
                                    ForAgent = string.Format("{0}", serviceEntry.DisplayName),
                                    CurrentValue = serviceEntry.Status.ToString()
                                    //,
                                    //RawDetails = string.Format("{0} ({1})", serviceEntry.DisplayName, serviceEntry.Status),
                                    //HtmlDetails = string.Format("{0} ({1})", serviceEntry.DisplayName, serviceEntry.Status)
                                });
                    }

                    returnState.ChildStates.Add(machineState);
                }

                if (errors > 0 && warnings == 0 && success == 0) // all errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any error or warnings
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
                dt.Columns[0].ExtendedProperties.Add("groupby", "true");
                dt.Columns.Add(new System.Data.DataColumn("Service", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("State", typeof(string)));

                WindowsServiceStateCollectorConfig currentConfig = (WindowsServiceStateCollectorConfig)AgentConfig;
                foreach (WindowsServiceStateHostEntry host in currentConfig.Entries)
                {
                    try
                    {
                        List<ServiceStateInfo> services = host.GetServiceStates();
                        foreach(ServiceStateInfo service in services.OrderBy(s=>s.DisplayName))
                        {
                            dt.Rows.Add(host.MachineName, service.DisplayName, service.Status.ToString());
                        }
                    }
                    catch(Exception ex)
                    {
                        dt.Rows.Add(host.MachineName, "Error", ex.Message);
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
