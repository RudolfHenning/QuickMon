using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Registry Query Collector"), Category("General")]
    public class RegistryQueryCollector : CollectorAgentBase
    {
        public RegistryQueryCollector()
        {
            AgentConfig = new RegistryQueryCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();            
            string lastAction = "";
            int errors = 0;
            int success = 0;
            int warnings = 0;
            double totalValue = 0;
            try
            {
                RegistryQueryCollectorConfig currentConfig = (RegistryQueryCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Running {0} registry query(s)", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Running {0} registry query(s)</b>", currentConfig.Entries.Count);

                foreach (RegistryQueryCollectorConfigEntry queryInstance in currentConfig.Entries)
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
                        returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = queryInstance.Name,
                                   State = CollectorState.Error,
                                   CurrentValue = value,
                                   RawDetails = string.Format("'{0}' - value '{1}' - Error (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.ErrorValue),
                                   HtmlDetails = string.Format("'{0}' - value '{1}' - <b>Error</b> (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.ErrorValue),
                               });
                    }
                    else if (instanceState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = queryInstance.Name,
                                   State = CollectorState.Warning,
                                   CurrentValue = value,
                                   RawDetails = string.Format("'{0}' - value '{1}' - Warning (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.WarningValue),
                                   HtmlDetails = string.Format("'{0}' - value '{1}' - <b>Warning</b> (trigger {2})", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]"), queryInstance.WarningValue),
                               });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = queryInstance.Name,
                                   State = CollectorState.Good,
                                   CurrentValue = value,
                                   RawDetails = string.Format("'{0}' - value '{1}'", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]")),
                                   HtmlDetails = string.Format("'{0}' - value '{1}'", queryInstance.Name, FormatUtils.FormatArrayToString(value, "[null]")),
                               });

                        
                    }
                }
                if (errors > 0 && warnings == 0)
                    returnState.State = CollectorState.Error;
                else if (warnings > 0)
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
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
    }
}
