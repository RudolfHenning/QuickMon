using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
     [Description("Performance Counter Collector")]
    public class PerfCounterCollector : CollectorBase
    {
         public PerfCounterCollector()
         {
             AgentConfig = new PerfCounterCollectorConfig();
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
            string outputFormat = "F3";
            string lastErrMsg = "";
            try
            {
                PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Querying {0} performance counters", currentConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<i>Querying {0} performance counters</i>", currentConfig.Entries.Count));
                htmlTextTextDetails.AppendLine("<ul>");
                
                foreach (PerfCounterCollectorEntry entry in currentConfig.Entries)
                {
                    CollectorState currentState = CollectorState.Good;
                    float value = 0;
                    outputFormat = "F3";
                    try
                    {
                        value = entry.GetNextValue();
                        if (value > 9999)
                            outputFormat = "F1";
                        currentState = entry.GetState(value);
                        lastErrMsg = "";
                    }
                    catch (Exception ex)
                    {
                        lastErrMsg = ex.Message;
                        currentState = CollectorState.Error;
                    }

                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t{0} - value '{1}' - Error (trigger '{2}') {3}", entry.ToString(), value.ToString(outputFormat), entry.ErrorValue.ToString(outputFormat), lastErrMsg));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - value '{1}' - <b>Error</b> (trigger '{2}') {3} </li>", entry.ToString(), value.ToString(outputFormat), entry.ErrorValue.ToString(outputFormat), lastErrMsg));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t{0} - value '{1}' - Warning (trigger '{2}')", entry.ToString(), value.ToString(outputFormat), entry.WarningValue.ToString(outputFormat)));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - value '{1}' - <b>Warning</b> (trigger '{2}')</li>", entry.ToString(), value.ToString(outputFormat), entry.WarningValue.ToString(outputFormat)));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t{0} - value '{1}'", entry.ToString(), value.ToString(outputFormat)));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - value '{1}'</li>", entry.ToString(), value.ToString(outputFormat)));
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();

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
            return new PerfCounterShowDetails();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new PerfCounterEditConfig();
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.PerfCounterCollectorDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new PerfCounterEditAlert();
        }
    }
}
