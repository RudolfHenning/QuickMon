using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class SQLQuery : CollectorBase
    {
        private SQLQueryConfig sqlQueryConfig = new SQLQueryConfig();

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
            try
            {
                plainTextDetails.AppendLine(string.Format("SQL Queries"));
                htmlTextTextDetails.AppendLine(string.Format("SQL Queries"));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (QueryInstance queryInstance in sqlQueryConfig.Queries)
                {
                    bool errorCondition = false;
                    bool warningCondition = false;
                    object value = null;
                    LastDetailMsg.PlainText = string.Format("Running SQL query '{0}' on '{1}\\{2}'", queryInstance.Name, queryInstance.SqlServer, queryInstance.Database);

                    if (!queryInstance.ReturnValueIsNumber)
                    {
                        value = queryInstance.RunQueryWithSingleResult();
                    }
                    else
                    {
                        if (queryInstance.UseRowCountAsValue)
                        {
                            value = queryInstance.RunQueryWithCountResult();
                        }
                        else
                        {
                            value = queryInstance.RunQueryWithSingleResult();
                        }
                    }
                    if (value == DBNull.Value)
                    {
                        if (queryInstance.ErrorValue == "[null]")
                            errorCondition = true;
                        else if (queryInstance.WarningValue == "[null]")
                            warningCondition = true;
                    }
                    else //non null value
                    {
                        if (!queryInstance.ReturnValueIsNumber)
                        {
                            if (value.ToString() == queryInstance.ErrorValue)
                                errorCondition = true;
                            else if (value.ToString() == queryInstance.WarningValue)
                                warningCondition = true;
                            else if (value.ToString() == queryInstance.SuccessValue || queryInstance.SuccessValue == "[any]")
                                warningCondition = false; //just to flag condition
                            else if (queryInstance.WarningValue == "[any]")
                                warningCondition = true;
                            else if (queryInstance.ErrorValue == "[any]")
                                errorCondition = true;
                        }
                        else //now we know the value is not null and must be in a range
                        {
                            if (!value.IsNumber()) //value must be a number!
                            {
                                errorCondition = true;
                            }
                            else if (queryInstance.ErrorValue != "[any]" && queryInstance.ErrorValue != "[null]" &&
                                    (
                                     (!queryInstance.ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(queryInstance.ErrorValue)) ||
                                     (queryInstance.ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(queryInstance.ErrorValue))
                                    )
                                )
                            {
                                errorCondition = true;
                            }
                            else if (queryInstance.WarningValue != "[any]" && queryInstance.WarningValue != "[null]" &&
                                   (
                                    (!queryInstance.ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(queryInstance.WarningValue)) ||
                                    (queryInstance.ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(queryInstance.WarningValue))
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
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}' - Error (trigger {2})", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})</li>", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                    }
                    else if (warningCondition)
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
            ShowDetails showDetails = new ShowDetails();
            showDetails.SQLQueryConfig = sqlQueryConfig;
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
            editConfig.SqlQueryConfig = sqlQueryConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.SqlQueryConfig.ToConfig();
            }
            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SqlQueryEmptyConfig;
        }

        public override void ReadConfiguration(XmlDocument configDoc)
        {
            sqlQueryConfig.ReadConfiguration(configDoc);
        }
    }
}
