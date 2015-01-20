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
            //StringBuilder plainTextDetails = new StringBuilder();
            //StringBuilder htmlTextTextDetails = new StringBuilder();
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


                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        returnState.RawDetails = string.Format("{0} (Error)", ssd.MachineName);
                        returnState.HtmlDetails = string.Format("{0} <b>Error</b>", ssd.MachineName);
                        //plainTextDetails.AppendLine(string.Format("Error: {0}", ssd.MachineName));
                        //htmlTextTextDetails.AppendLine(string.Format("<b>Error</b>: {0}", ssd.MachineName));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.RawDetails = string.Format("{0} (Warning)", ssd.MachineName);
                        returnState.HtmlDetails = string.Format("{0} <b>Warning</b>", ssd.MachineName);
                        //plainTextDetails.AppendLine(string.Format("Warning: {0}", ssd.MachineName));
                        //htmlTextTextDetails.AppendLine(string.Format("<i>Warning</i>: {0}", ssd.MachineName));
                    }
                    else
                    {
                        success++;
                        returnState.RawDetails = string.Format("{0} (Success)", ssd.MachineName);
                        returnState.HtmlDetails = string.Format("{0} <b>Success</b>", ssd.MachineName);
                        //plainTextDetails.AppendLine(string.Format("Success: {0}", ssd.MachineName));
                        //htmlTextTextDetails.AppendLine(string.Format("Success: {0}", ssd.MachineName));
                    }
                    foreach (ServiceStateInfo serviceEntry in serviceStates)
                    {
                        returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.None,
                                    RawDetails = string.Format("{0} ({1})", serviceEntry.DisplayName, serviceEntry.Status),
                                    HtmlDetails = string.Format("{0} ({1})", serviceEntry.DisplayName, serviceEntry.Status)
                                });

                        //plainTextDetails.AppendLine(string.Format("\t{0}: {1}", serviceEntry.DisplayName, serviceEntry.Status));
                        //htmlTextTextDetails.AppendLine("<ul>");
                        //if (serviceEntry.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                        //{
                        //    htmlTextTextDetails.AppendLine(string.Format("<li>{0}: <b>{1}</b></li>", serviceEntry.DisplayName, serviceEntry.Status));
                        //}
                        //else
                        //{
                        //    htmlTextTextDetails.AppendLine(string.Format("<li>{0}: {1}</li>", serviceEntry.DisplayName, serviceEntry.Status));
                        //}
                        //htmlTextTextDetails.AppendLine("</ul>");
                    }

                }
                //returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                //returnState.HtmlDetails = htmlTextTextDetails.ToString();

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
    }
}
