using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;

namespace QuickMon
{
    public class PerfCounter : CollectorBase
    {
        internal PerfCounterConfig PerfCounterConfig = new PerfCounterConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastErrMsg = "";
            LastDetailMsg.PlainText = "Querying performance counters";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            string outputFormat = "F3";
            try
            {
                
                plainTextDetails.AppendLine(string.Format("Querying {0} performance counters", PerfCounterConfig.QMPerfCounters.Count));
                htmlTextTextDetails.AppendLine(string.Format("<i>Querying {0} performance counters</i>", PerfCounterConfig.QMPerfCounters.Count));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (QMPerfCounterInstance perfCounter in PerfCounterConfig.QMPerfCounters)
                {
                    MonitorStates currentState = MonitorStates.Good;
                    float value = 0;
                    outputFormat = "F3";
                    try
                    {
                        value = perfCounter.GetNextValue();
                        if (value > 9999)
                            outputFormat = "F1";
                        currentState = perfCounter.GetState(value);
                        lastErrMsg = "";
                    }
                    catch (Exception ex)
                    {
                        lastErrMsg = ex.Message;
                        currentState = MonitorStates.Error;
                    }

                    if (currentState == MonitorStates.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t{0} - value '{1}' - Error (trigger '{2}') {3}", perfCounter.ToString(), value.ToString(outputFormat), perfCounter.ErrorValue.ToString(outputFormat), lastErrMsg));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - value '{1}' - <b>Error</b> (trigger '{2}') {3} </li>", perfCounter.ToString(), value.ToString(outputFormat), perfCounter.ErrorValue.ToString(outputFormat), lastErrMsg));
                    }
                    else if (currentState == MonitorStates.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t{0} - value '{1}' - Warning (trigger '{2}')", perfCounter.ToString(), value.ToString(outputFormat), perfCounter.WarningValue.ToString(outputFormat)));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - value '{1}' - <b>Warning</b> (trigger '{2}')</li>", perfCounter.ToString(), value.ToString(outputFormat), perfCounter.WarningValue.ToString(outputFormat)));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t{0} - value '{1}'", perfCounter.ToString(), value.ToString(outputFormat)));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - value '{1}'</li>", perfCounter.ToString(), value.ToString(outputFormat)));
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                if (errors > 0 && warnings == 0) //are all errors
                    returnState = MonitorStates.Error;
                else if (errors > 0 || warnings > 0) //any errors or warnings
                    returnState = MonitorStates.Warning;
                LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
                LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
            }
            catch (Exception ex)
            {
                LastError = 1;
                LastErrorMsg = ex.Message;
                LastDetailMsg.PlainText = string.Format("Last step: '{0}\r\n{1}", LastDetailMsg.PlainText, ex.Message);
                LastDetailMsg.HtmlText = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", LastDetailMsg.PlainText, ex.Message);
                returnState = MonitorStates.Error;
            }
            finally
            {
                
            }
            return returnState;
        }

        public override void ShowStatusDetails(string collectorName)
        {
            ShowDetails showDetails = new ShowDetails();
            showDetails.PFConfig = PerfCounterConfig;
            showDetails.Text = "Show details - " + collectorName;
            showDetails.Show();
        }

        public override string ConfigureAgent(string config)
        {
            XmlDocument configDoc = new XmlDocument();
            if (config.Length > 0)
                configDoc.LoadXml(config);
            else
                configDoc.LoadXml(Properties.Resources.PerfCounterEmptyConfig);
            ReadConfiguration(configDoc);

            EditConfig editConfig = new EditConfig();
            editConfig.PFConfig = PerfCounterConfig; 
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.PFConfig.ToConfig();
            }

            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.PerfCounterEmptyConfig;
        }

        public override void ReadConfiguration(XmlDocument configDoc)
        {
            PerfCounterConfig.ReadConfig(configDoc);
        }

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return (ICollectorDetailView)(new ShowDetails());
        }
    }
}
