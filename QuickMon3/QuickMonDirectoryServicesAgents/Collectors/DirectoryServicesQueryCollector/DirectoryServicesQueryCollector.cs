using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Directory Services Query Collector"), Category("Directory Services")]
    public class DirectoryServicesQueryCollector : CollectorBase
    {
        public DirectoryServicesQueryCollector()
        {
            AgentConfig = new DirectoryServicesQueryCollectorConfig();
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
                DirectoryServicesQueryCollectorConfig dsQueryConfig = (DirectoryServicesQueryCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Running {0} Directory Services queries", dsQueryConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<i>Running {0} Directory Services queries'</i>", dsQueryConfig.Entries.Count));
                htmlTextTextDetails.AppendLine("<ul>");
                StringBuilder sbTotalResults = new StringBuilder();
                foreach (DirectoryServicesQueryCollectorConfigEntry dsQueryEntry in dsQueryConfig.Entries)
                {
                    lastAction = string.Format("Running Directory Services query for {0} - ", dsQueryEntry.Name);
                    sbTotalResults.AppendLine(dsQueryEntry.Name);
                    plainTextDetails.Append(string.Format("\t{0} - ", dsQueryEntry.Name));
                    htmlTextTextDetails.Append(string.Format("<li>{0} - ", dsQueryEntry.Name));

                    object queryResult = dsQueryEntry.RunQuery();
                    CollectorState currentState = dsQueryEntry.GetState(queryResult);
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t\tQuery '{0}' - Error\r\n\t\t Result: '{1}'", dsQueryEntry.Name, FormatUtils.N(queryResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Query '{0}' - <b>Error</b><br>Result: <blockquote>{1}</blockquote></li>", dsQueryEntry.Name, FormatUtils.N(queryResult, "[null]")));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t\tQuery '{0}' - Warning\r\n\t\t Result: '{1}'", dsQueryEntry.Name, FormatUtils.N(queryResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Query '{0}' - <b>Warning</b><br>Result: <blockquote>{1}</blockquote></li>", dsQueryEntry.Name, FormatUtils.N(queryResult, "[null]")));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t\tQuery '{0}'\r\n\t\t Result: '{1}'", dsQueryEntry.Name, FormatUtils.N(queryResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Query '{0}'<br>Result: <blockquote>{1}</blockquote></li>", dsQueryEntry.Name, FormatUtils.N(queryResult, "[null]")));
                    }
                    if (queryResult != null)
                        sbTotalResults.AppendLine(queryResult.ToString());
                    else
                        sbTotalResults.AppendLine("[null]");
                }

                htmlTextTextDetails.AppendLine("</ul>");
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = sbTotalResults.ToString();
                if (errors > 0 && warnings == 0 && success == 0)
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0)
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
            return new DirectoryServicesQueryCollectorShowDetails();
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new DirectoryServicesQueryEditEntry();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.DirectoryServicesQueryDefaultConfig;
        }
    }
}
