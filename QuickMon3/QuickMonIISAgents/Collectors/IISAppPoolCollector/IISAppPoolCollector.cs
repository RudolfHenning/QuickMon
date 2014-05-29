using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.Collectors
{
    [Description("IIS Application Pool Collector"), Category("IIS")]
    public class IISAppPoolCollector : CollectorBase
    {
        public IISAppPoolCollector()
        {
            AgentConfig = new IISAppPoolCollectorConfig();
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
                IISAppPoolCollectorConfig currentConfig = (IISAppPoolCollectorConfig)AgentConfig;
                foreach (IISAppPoolMachine machineEntry in currentConfig.Entries)
                {
                    lastAction = "Checking application pools on " + machineEntry.MachineName;
                    var appPollStates = machineEntry.GetIISAppPoolStates();
                    lastAction = "Checking application pool states of " + machineEntry.MachineName;
                    CollectorState currentState = machineEntry.GetState(appPollStates);

                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("Error: {0}", machineEntry.MachineName));
                        htmlTextTextDetails.AppendLine(string.Format("<b>Error</b>: {0}", machineEntry.MachineName));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("Warning: {0}", machineEntry.MachineName));
                        htmlTextTextDetails.AppendLine(string.Format("<i>Warning</i>: {0}", machineEntry.MachineName));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("Success: {0}", machineEntry.MachineName));
                        htmlTextTextDetails.AppendLine(string.Format("Success: {0}", machineEntry.MachineName));
                    }
                    foreach (IISAppPoolStateInfo appPollEntry in appPollStates)
                    {
                        plainTextDetails.AppendLine(string.Format("\t{0}: {1}", appPollEntry.DisplayName, appPollEntry.Status));
                        htmlTextTextDetails.AppendLine("<ul>");
                        if (appPollEntry.Status != AppPoolStatus.Started)
                        {
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0}: <b>{1}</b></li>", appPollEntry.DisplayName, appPollEntry.Status));
                        }
                        else
                        {
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0}: {1}</li>", appPollEntry.DisplayName, appPollEntry.Status));
                        }
                        htmlTextTextDetails.AppendLine("</ul>");
                    }
                }
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();

                if (errors > 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (warnings > 0) //any warnings
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
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.IISAppPoolCollectorDefaultConfig;
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new IISAppPoolCollectorDetailView();
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new IISAppPoolCollectorEditEntry();
        }
        public override List<AgentPresetConfig> GetPresets()
        {
            return new List<AgentPresetConfig>();
        }
    }
}
