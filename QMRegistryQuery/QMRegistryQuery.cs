using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class RegistryQuery : CollectorBase
    {
        private RegistryQueryConfig registryQueryConfig = new RegistryQueryConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Running SQL queries";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            double totalValue = 0;
            try
            {
                plainTextDetails.AppendLine(string.Format("Registry Queries"));
                htmlTextTextDetails.AppendLine(string.Format("Registry Queries"));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (RegistryQueryInstance queryInstance in registryQueryConfig.Queries)
                {
                    object value = null;
                    if (queryInstance.UseRemoteServer)
                        LastDetailMsg.PlainText = string.Format("Running Registry query '{0}' on '{1}'", queryInstance.Name, queryInstance.Server);
                    else
                        LastDetailMsg.PlainText = string.Format("Running Registry query '{0}'", queryInstance.Name);
                    
                    value = queryInstance.GetValue();
                    if (!queryInstance.ReturnValueIsNumber && value.IsNumber())
                        totalValue += double.Parse(value.ToString());

                    MonitorStates instanceState = queryInstance.EvaluateValue(value);

                    if (instanceState == MonitorStates.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}' - Error (trigger {2})", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})</li>", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                    }
                    else if (instanceState == MonitorStates.Warning)
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
                    returnState = MonitorStates.Error;
                else if (warnings > 0)
                    returnState = MonitorStates.Warning;
                LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
                LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
                LastDetailMsg.LastValue = totalValue;
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
            if (registryQueryConfig != null)
            {
                ShowDetails showDetails = new ShowDetails();
                showDetails.Text = "Details for collector - '" + collectorName + "'";
                showDetails.SelectedRegistryQueryConfig = registryQueryConfig;
                showDetails.Show();
            }
        }

        public override string ConfigureAgent(string config)
        {
            XmlDocument configDoc = new XmlDocument();
            if (config.Length > 0)
                configDoc.LoadXml(config);
            else
                configDoc.LoadXml(GetDefaultOrEmptyConfigString());
            ReadConfiguration(configDoc);

            EditConfig editConfig = new EditConfig();
            editConfig.SelectedRegistryQueryConfig = registryQueryConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.SelectedRegistryQueryConfig.ToConfig();
            }
            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.RegistryQueryEmptyConfig;
        }

        public override void ReadConfiguration(System.Xml.XmlDocument configDoc)
        {
            registryQueryConfig.ReadConfiguration(configDoc);
        }
    }
}
