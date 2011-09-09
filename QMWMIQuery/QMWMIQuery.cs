using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Management;

namespace QuickMon
{
    public class WMIQuery : CollectorBase
    {
        private WMIConfig wmiIConfig = new WMIConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Running WMI query";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            try
			{
                plainTextDetails.AppendLine(string.Format("Running the WMI query: '{0}'", wmiIConfig.StateQuery));
                htmlTextTextDetails.AppendLine(string.Format("<i>Running the WMI query: '{0}'</i>", wmiIConfig.StateQuery));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (string machineName in wmiIConfig.Machines)
                {
                    bool errorCondition = false;
                    bool warningCondition = false;
                    object value = null;
                    LastDetailMsg.PlainText = string.Format("Running WMI query for '{0}' - '{1}'", machineName, wmiIConfig.StateQuery);

                    if (!wmiIConfig.ReturnValueIsInt)
                    {
                        value = wmiIConfig.RunQueryWithSingleResult(machineName);                        
                    }
                    else //(wmiIConfig.ReturnValueIsInt)
                    {
                        if (wmiIConfig.UseRowCountAsValue)
                        {
                            value = wmiIConfig.RunQueryWithCountResult(machineName);
                        }
                        else
                        {
                            value = wmiIConfig.RunQueryWithSingleResult(machineName);
                        }
                    }
                    if (value == null)
                    {
                        if (wmiIConfig.ErrorValue == "[null]")
                            errorCondition = true;
                        else if (wmiIConfig.WarningValue == "[null]")
                            warningCondition = true;
                    }
                    else //non null value
                    {
                        if (!wmiIConfig.ReturnValueIsInt)
                        {
                            if (value.ToString() == wmiIConfig.ErrorValue)
                                errorCondition = true;
                            else if (value.ToString() == wmiIConfig.WarningValue)
                                warningCondition = true;
                            else if (value.ToString() == wmiIConfig.SuccessValue || wmiIConfig.SuccessValue == "[any]")
                                warningCondition = false; //just to flag condition
                            else if (wmiIConfig.WarningValue == "[any]")
                                warningCondition = true;
                            else if (wmiIConfig.ErrorValue == "[any]")
                                errorCondition = true;
                        }
                        else //now we know the value is not null and must be in a range
                        {
                            if (!value.IsIntegerTypeNumber()) //value must be a number!
                            {
                                errorCondition = true;
                            }
                            else if (wmiIConfig.ErrorValue != "[any]" && wmiIConfig.ErrorValue != "[null]" &&
                                    (
                                     (!wmiIConfig.ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(wmiIConfig.ErrorValue)) ||
                                     (wmiIConfig.ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(wmiIConfig.ErrorValue))
                                    )
                                )
                            {
                                errorCondition = true;
                            }
                            else if (wmiIConfig.WarningValue != "[any]" && wmiIConfig.WarningValue != "[null]" &&
                                   (
                                    (!wmiIConfig.ReturnValueInverted && decimal.Parse(value.ToString()) >= decimal.Parse(wmiIConfig.WarningValue)) ||
                                    (wmiIConfig.ReturnValueInverted && decimal.Parse(value.ToString()) <= decimal.Parse(wmiIConfig.WarningValue))
                                   )
                                )
                            {
                                warningCondition = true;
                            }
                        }
                    }

                    if (errorCondition)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}' - Error (trigger {2})", machineName, FormatUtils.N(value, "[null]"), wmiIConfig.ErrorValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})</li>", machineName, FormatUtils.N(value, "[null]"), wmiIConfig.ErrorValue));
                    }
                    else if (warningCondition)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}' - Warning (trigger {2})", machineName, FormatUtils.N(value, "[null]"), wmiIConfig.WarningValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Warning</b> (trigger {2})</li>", machineName, FormatUtils.N(value, "[null]"), wmiIConfig.WarningValue));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}'", machineName, value));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}'</li>", machineName, value));
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                if (errors > 0 && warnings == 0)
                    returnState = MonitorStates.Error;
                else if (warnings > 0)
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

        public override void ShowStatusDetails()
        {
            //XmlDocument configDoc = new XmlDocument();
            //configDoc.LoadXml(config);
            //ReadConfiguration(configDoc);
            ShowDetails showDetails = new ShowDetails();
            showDetails.WmiIConfig = wmiIConfig;
            showDetails.Show();
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
            editConfig.WmiIConfig = wmiIConfig;
            if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.WmiIConfig.ToConfig();
            }
            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.WMIQueryEmptyConfig;
        }

        public override void ReadConfiguration(XmlDocument configDoc)
        {
            wmiIConfig.ReadConfig(configDoc);
        }
    }
}
