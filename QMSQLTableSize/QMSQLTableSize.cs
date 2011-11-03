using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class SQLTableSize : CollectorBase
    {
        private TableSizeConfig tableSizeConfig = new TableSizeConfig();
        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Querying table sizes";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int warnings = 0;
            try
            {
                plainTextDetails.AppendLine(string.Format("Querying {0} databases", tableSizeConfig.DatabaseEntries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<b>Querying {0} databases</b>", tableSizeConfig.DatabaseEntries.Count));

                htmlTextTextDetails.AppendLine("<blockquote>");
                foreach (DatabaseEntry databaseSizeEntry in tableSizeConfig.DatabaseEntries)
                {
                    try
                    {
                        plainTextDetails.AppendLine(string.Format("\tServer\\Database: {0}\\{1}", databaseSizeEntry.SqlServer, databaseSizeEntry.Name));
                        htmlTextTextDetails.AppendLine(string.Format("<b>Server\\Database: {0}\\{1}</b>", databaseSizeEntry.SqlServer, databaseSizeEntry.Name));
                        List<TableSizeInfo> tableSizes = databaseSizeEntry.GetTableRowCount();

                        htmlTextTextDetails.AppendLine("<ul>");
                        foreach (TableSizeEntry tableEntry in databaseSizeEntry.TableSizeEntries)
                        {
                            plainTextDetails.Append(string.Format("\t\t{0} - ", tableEntry.TableName));
                            htmlTextTextDetails.Append(string.Format("<li>{0} - ", tableEntry.TableName));

                            TableSizeInfo tableSizeInfo = (from ti in tableSizes
                                                           where ti.Name == tableEntry.TableName
                                                           select ti).FirstOrDefault();
                            if (tableSizeInfo == null)
                            {
                                errors++;
                                plainTextDetails.Append("Table not found!");
                                htmlTextTextDetails.Append("Table not found!");
                            }
                            else if (tableSizeInfo.Rows >= tableEntry.ErrorValue)
                            {
                                errors++;
                                plainTextDetails.Append(string.Format("{0} - Error (trigger {1})", tableSizeInfo.Rows, tableEntry.ErrorValue));
                                htmlTextTextDetails.Append(string.Format("{0} - <b>Error</b> (trigger {1})", tableSizeInfo.Rows, tableEntry.ErrorValue));
                            }
                            else if (tableSizeInfo.Rows >= tableEntry.WarningValue)
                            {
                                warnings++;
                                plainTextDetails.Append(string.Format("{0} - Warning (trigger {1})", tableSizeInfo.Rows, tableEntry.WarningValue));
                                htmlTextTextDetails.Append(string.Format("{0} - <b>Warning</b> (trigger {1})", tableSizeInfo.Rows, tableEntry.WarningValue));
                            }
                            else
                            {
                                plainTextDetails.Append(string.Format("{0}", tableSizeInfo.Rows));
                                htmlTextTextDetails.Append(string.Format("{0}", tableSizeInfo.Rows));
                            }

                            plainTextDetails.AppendLine();
                            htmlTextTextDetails.AppendLine("</li>");
                        }
                    }
                    catch (Exception innerEx)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format(" - {0}", innerEx.Message));
                        htmlTextTextDetails.AppendLine(string.Format(" - {0}", innerEx.Message));
                    }

                    htmlTextTextDetails.AppendLine("</ul>");
                }
                htmlTextTextDetails.AppendLine("</blockquote>");

                if (errors > 0 && warnings == 0) //Are all errors
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
            showDetails.TableSizeConfig = tableSizeConfig;
            showDetails.Text = "Show details - " + collectorName;
            showDetails.Show();
        }

        public override string ConfigureAgent(string config)
        {
            XmlDocument configDoc = new XmlDocument ();
            if (config.Length > 0)
                configDoc.LoadXml(config);
            else
                configDoc.LoadXml(GetDefaultOrEmptyConfigString());
            ReadConfiguration(configDoc);

            EditConfig editConfig = new EditConfig();
            editConfig.TableSizeConfig = tableSizeConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.TableSizeConfig.ToConfig();
            }
            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SqlTableSizeEmptyConfig;
        }

        public override void ReadConfiguration(XmlDocument configDoc)
        {
            tableSizeConfig.ReadConfiguration(configDoc);
        }
    }
}
