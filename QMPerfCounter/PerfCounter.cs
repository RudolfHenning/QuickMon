using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class PerfCounter : CollectorBase
    {
        PerfCounterConfig perfCounterConfig = new PerfCounterConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Querying performance counters";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            string outputFormat = "F3";
            try
            {
                plainTextDetails.AppendLine(string.Format("Querying {0} performance counters", perfCounterConfig.QMPerfCounters.Count));
                htmlTextTextDetails.AppendLine(string.Format("<i>Querying {0} performance counters</i>", perfCounterConfig.QMPerfCounters.Count));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (QMPerfCounterInstance perfCounter in perfCounterConfig.QMPerfCounters)
                {
                    bool errorCondition = false;
                    bool warningCondition = false;
                    float value = 0;
                    outputFormat = "F3";
                    try
                    {
                        value = perfCounter.GetNextValue();
                        if (value > 9999)
                            outputFormat = "F1";
                        if (!perfCounter.ReturnValueInverted)
                        {
                            if (perfCounter.ErrorValue <= value)
                                errorCondition = true;
                            else if (perfCounter.WarningValue <= value)
                                warningCondition = true;
                        }
                        else
                        {
                            if (perfCounter.ErrorValue >= value)
                                errorCondition = true;
                            else if (perfCounter.WarningValue >= value)
                                warningCondition = true;
                        }                                               
                    }
                    catch(Exception ex)
                    {
                        LastDetailMsg.PlainText = ex.Message;
                        errorCondition = true;
                    }

                    if (errorCondition)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t{0} - value '{1}' - Error (trigger '{2}') {3}", perfCounter.ToString(), value.ToString(outputFormat), perfCounter.ErrorValue.ToString(outputFormat), LastDetailMsg.PlainText));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - value '{1}' - <b>Error</b> (trigger '{2}') {3} </li>", perfCounter.ToString(), value.ToString(outputFormat), perfCounter.ErrorValue.ToString(outputFormat), LastDetailMsg.PlainText));
                    }
                    else if (warningCondition)
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
            return returnState;
        }

        public override void ShowStatusDetails(string collectorName)
        {
            ShowDetails showDetails = new ShowDetails();
            showDetails.PFConfig = perfCounterConfig;
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
            editConfig.PFConfig = perfCounterConfig; 
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
            perfCounterConfig.ReadConfig(configDoc);
        }
    }
}
