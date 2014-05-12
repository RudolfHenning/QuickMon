using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.Collectors
{
    [Description("PowerShell Script Runner Collector"), Category("PowerShell")]
    public class PowerShellScriptRunnerCollector : CollectorBase
    {
        public PowerShellScriptRunnerCollector()
        {
            AgentConfig = new PowerShellScriptRunnerCollectorConfig();
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
                PowerShellScriptRunnerCollectorConfig psScriptConfig = (PowerShellScriptRunnerCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Running {0} PowerShell scripts", psScriptConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<i>Running {0} PowerShell scripts'</i>", psScriptConfig.Entries.Count));
                htmlTextTextDetails.AppendLine("<ul>");
                StringBuilder sbTotalResults = new StringBuilder();

                foreach (PowerShellScriptRunnerEntry pssrEntry in psScriptConfig.Entries)
                {
                    lastAction = string.Format("Running PowerShell script for {0} - ", pssrEntry.Name);
                    sbTotalResults.AppendLine(pssrEntry.Name);
                    plainTextDetails.Append(string.Format("\t{0} - ", pssrEntry.Name));
                    htmlTextTextDetails.Append(string.Format("<li>{0} - ", pssrEntry.Name));

                    string scriptResult = pssrEntry.RunScript();
                    CollectorState currentState = pssrEntry.GetState(scriptResult);
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t\tScript '{0}' - Error\r\n\t\t Result: '{1}'", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Script '{0}' - <b>Error</b><br>Result: <blockquote>{1}</blockquote></li>", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t\tScript '{0}' - Warning\r\n\t\t Result: '{1}'", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Script '{0}' - <b>Warning</b><br>Result: <blockquote>{1}</blockquote></li>", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t\tScript '{0}'\r\n\t\t Result: '{1}'", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Script '{0}'<br>Result: <blockquote>{1}</blockquote></li>", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                    }
                    if (scriptResult != null)
                        sbTotalResults.AppendLine(scriptResult);
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
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.PowerShellScriptRunnerDefaultConfig;
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new PowerShellScriptRunnerEditEntry();
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new PowerShellScriptRunnerShowDetails();
        }
    }
}
