using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Registry Query Collector"), Category("General")]
    public class RegistryQueryCollector : CollectorBase
    {
        public RegistryQueryCollector()
        {
            AgentConfig = new RegistryQueryCollectorConfig();
        }

        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            int errors = 0;
            int success = 0;
            int warnings = 0;
            double totalValue = 0;
            try
            {
                RegistryQueryCollectorConfig config = (RegistryQueryCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Running {0} registry query(s)", config.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<b>Running {0} registry query(s)</b>", config.Entries.Count));
                htmlTextTextDetails.AppendLine("<ul>");

                foreach (RegistryQueryInstance queryInstance in config.Entries)
                {
                    object value = null;
                    if (queryInstance.UseRemoteServer)
                        lastAction = string.Format("Running Registry query '{0}' on '{1}'", queryInstance.Name, queryInstance.Server);
                    else
                        lastAction = string.Format("Running Registry query '{0}'", queryInstance.Name);

                    value = queryInstance.GetValue();
                    if (!queryInstance.ReturnValueIsNumber && value.IsNumber())
                        totalValue += double.Parse(value.ToString());

                    CollectorState instanceState = queryInstance.EvaluateValue(value);

                    if (instanceState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}' - Error (trigger {2})", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})</li>", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                    }
                    else if (instanceState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}' - Warning (trigger {2})", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.WarningValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Warning</b> (trigger {2})</li>", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.WarningValue));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}'", queryInstance.Name, value));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}'</li>", queryInstance.Name, value));
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                if (errors > 0 && warnings == 0)
                    returnState.State = CollectorState.Error;
                else if (warnings > 0)
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = totalValue;
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
            return new RegistryQueryCollectorShowDetails();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.RegistryQueryCollectorDefaultConfig;
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new RegistryQueryCollectorEditInstance();
        }
    }
}
