using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Dynamic Web Service Collector"), Category("Web Service")]
    public class DynamicWSCollector : CollectorBase
    {
        public DynamicWSCollector()
        {
            AgentConfig = new DynamicWSCollectorConfig();
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
                DynamicWSCollectorConfig currentConfig = (DynamicWSCollectorConfig)AgentConfig;
                foreach (DynamicWSCollectorConfigEntry entry in currentConfig.Entries)
                {
                    CollectorState currentState = CollectorState.NotAvailable;
                    try
                    {
                        lastAction = "Running Web Service " + entry.Description;
                        var wsData = entry.RunMethod();
                        lastAction = "Checking states of " + entry.Description;
                        currentState = entry.GetState(wsData);
                        lastAction = entry.LastFormattedValue;
                    }
                    catch (Exception wsException)
                    {
                        currentState = CollectorState.Error;
                        lastAction = wsException.Message;
                    }
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.Append(string.Format("Error: {0} - ", entry.Description));
                        htmlTextTextDetails.Append(string.Format("<b>Error</b>: {0} - ", entry.Description));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.Append(string.Format("Warning: {0} - ", entry.Description));
                        htmlTextTextDetails.Append(string.Format("<i>Warning</i>: {0} - ", entry.Description));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.Append(string.Format("Success: {0} - ", entry.Description));
                        htmlTextTextDetails.Append(string.Format("Success: {0} - ", entry.Description));
                    }
                    plainTextDetails.AppendLine(lastAction);
                    htmlTextTextDetails.AppendLine(lastAction);
                }

                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();

                if (errors > 0 && success == 0) // all errors
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
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new DynamicWSCollectorEditEntry();
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new DynamicWSCollectorShowDetails();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.DynamicWSCollectorDefaultConfig;
        }
    }
}
