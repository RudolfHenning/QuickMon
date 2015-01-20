using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("WMI Query Collector"), Category("General")]
    public class WMIQueryCollector : CollectorAgentBase
    {
        public WMIQueryCollector()
        {
            AgentConfig = new WMIQueryCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            double totalValue = 0;
            try
            {
                WMIQueryCollectorConfig currentConfig = (WMIQueryCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Running {0} WMI queries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Running {0} WMI queries</b>", currentConfig.Entries.Count);

                foreach (WMIQueryCollectorConfigEntry wmiConfigEntry in currentConfig.Entries)
                {
                    lastAction = string.Format("Running WMI query for {0} - ", wmiConfigEntry.Name);

                    object val = wmiConfigEntry.RunQuery();
                    CollectorState currentState = wmiConfigEntry.GetState(val);
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = wmiConfigEntry.Name,
                                   State = CollectorState.Error,
                                   CurrentValue = val,
                                   RawDetails = string.Format("Machine '{0}' - value '{1}' - Error (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.ErrorValue),
                                   HtmlDetails = string.Format("Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.ErrorValue)
                               });                        
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = wmiConfigEntry.Name,
                                   State = CollectorState.Warning,
                                   CurrentValue = val,
                                   RawDetails = string.Format("Machine '{0}' - value '{1}' - Warning (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.WarningValue),
                                   HtmlDetails = string.Format("Machine '{0}' - Value '{1}' - <b>Warning</b> (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.WarningValue)
                               });                        
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                               new MonitorState()
                               {
                                   ForAgent = wmiConfigEntry.Name,
                                   State = CollectorState.Good,
                                   CurrentValue = val,
                                   RawDetails = string.Format("Machine '{0}' - value '{1}'", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]")),
                                   HtmlDetails = string.Format("Machine '{0}' - Value '{1}'", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"))
                               });
                    }
                    if (val != null && val.IsNumber())
                        totalValue += double.Parse(val.ToString());
                }
                returnState.CurrentValue = totalValue;
                if (errors > 0 && warnings == 0)
                    returnState.State = CollectorState.Error;
                else if (warnings > 0)
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
