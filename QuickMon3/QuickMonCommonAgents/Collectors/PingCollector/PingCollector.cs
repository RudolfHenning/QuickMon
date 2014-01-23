using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Ping Collector")]
    public class PingCollector : CollectorBase
    {
        public PingCollector()
        {
            AgentConfig = new PingCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            long pingTotalTime = 0;
            int errors = 0;
            int warnings = 0;
            int success = 0;            
            
            try
			{
                PingCollectorConfig currentConfig = (PingCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Pinging {0} entries", currentConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<b>Pinging {0} entries</b>", currentConfig.Entries.Count));
                htmlTextTextDetails.AppendLine("<ul>");
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
                            plainTextDetails.AppendLine(string.Format("\t{0} (Error) - {1} ", host.Address, pingResult.ResponseDetails));
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Error</b>) - {1}</li>", host.Address, pingResult.ResponseDetails));
                        }
                        else if (currentState == CollectorState.Warning)
                        {
                            warnings++;
                            plainTextDetails.AppendLine(string.Format("\t{0} (Warning) - {1}ms - {2}", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Warning</b>) - {1}ms - {2}</li>", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                        }
                        else
                        {
                            success++;
                            plainTextDetails.AppendLine(string.Format("\t{0} (Success) - {1}ms - {2}", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Success</b>) - {1}ms - {2}</li>", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                        }
                    }
                    else
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t{0} (Error)- {1}", host.Address, pingResult.ResponseDetails));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Error</b>) - {1}</li>", host.Address, pingResult.ResponseDetails));
                    }  
                }
                htmlTextTextDetails.AppendLine("</ul>");
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
				returnState.CurrentValue = pingTotalTime;

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

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new PingCollectorShowDetails();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new PingCollectorEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.PingCollectorDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new PingCollectorEditHostAddress();
        }
    }
}
