using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Windows Service State Collector"), Category("General")]
    public class ServiceStateCollector : CollectorBase
    {
        public ServiceStateCollector()
        {
            AgentConfig = new ServiceStateCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
           
            try
            {
                ServiceStateCollectorConfig currentConfig = (ServiceStateCollectorConfig)AgentConfig;
                foreach (ServiceStateDefinition ssd in currentConfig.Entries)
                {
                    lastAction = "Checking services on " + ssd.MachineName;
                    var serviceStates = ssd.GetServiceStates();
                    lastAction = "Checking service states of " + ssd.MachineName;
                    CollectorState currentState = ssd.GetState(serviceStates);


                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("Error: {0}", ssd.MachineName));
                        htmlTextTextDetails.AppendLine(string.Format("<b>Error</b>: {0}", ssd.MachineName));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("Warning: {0}", ssd.MachineName));
                        htmlTextTextDetails.AppendLine(string.Format("<i>Warning</i>: {0}", ssd.MachineName));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("Success: {0}", ssd.MachineName));
                        htmlTextTextDetails.AppendLine(string.Format("Success: {0}", ssd.MachineName));
                    }
                    foreach (ServiceStateInfo serviceEntry in serviceStates)
                    {
                        plainTextDetails.AppendLine(string.Format("\t{0}: {1}", serviceEntry.DisplayName, serviceEntry.Status));
                        htmlTextTextDetails.AppendLine("<ul>");
                        if (serviceEntry.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                        {                            
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0}: <b>{1}</b></li>", serviceEntry.DisplayName, serviceEntry.Status));
                        }
                        else
                        {
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0}: {1}</li>", serviceEntry.DisplayName, serviceEntry.Status));
                        }
                        htmlTextTextDetails.AppendLine("</ul>");
                    } 
                    
                }
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();

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
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new ServiceStateCollectorDetailView();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.ServiceStateCollectorDefaultConfig;
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new ServiceStateCollectorEditEntry();
        }
        //public override List<AgentPresetConfig> GetPresets()
        //{
        //    List<AgentPresetConfig> list = new List<AgentPresetConfig>();
        //    list.Add(new AgentPresetConfig()
        //    {
        //        AgentClassName = this.GetType().Name,
        //        AgentDefaultName = "QuickMon Service running",
        //        Description = "Is QuickMon Service running",
        //        Config = "<config><machine name=\".\"><service name=\"QuickMon 3 Service\" /></machine></config>"

        //    });
        //    return list;
        //}
    }
}
