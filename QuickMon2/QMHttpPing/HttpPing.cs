using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon 
{
    public class HttpPing : CollectorBase
    {
        internal HttpPingConfig HttpPingConfig = new HttpPingConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Querying table sizes";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int warnings = 0;
            long pingTotalTime = 0;
            try
            {
                plainTextDetails.AppendLine(string.Format("Pinging {0} addresses", HttpPingConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<b>Pinging {0} addresses</b>", HttpPingConfig.Entries.Count));

                htmlTextTextDetails.AppendLine("<ul>");
                foreach (HttpPingEntry httpPingEntry in HttpPingConfig.Entries)
                {
                    try
                    {
                        plainTextDetails.Append(string.Format("\t\t{0} - ", httpPingEntry.Url));
                        htmlTextTextDetails.Append(string.Format("<li>{0} - ", httpPingEntry.Url));

                        int pingTime = httpPingEntry.Ping();
                        pingTotalTime += pingTime;
                        if (pingTime == int.MaxValue)
                        {
                            errors++;
                            plainTextDetails.Append(string.Format("Error - {0}", httpPingEntry.LastError));
                            htmlTextTextDetails.Append(string.Format("<b>Error</b> - {0}", httpPingEntry.LastError));
                        }
                        else if (pingTime >= httpPingEntry.TimeOut)
                        {
                            errors++;
                            plainTextDetails.Append(string.Format("{0}ms - Error (Time-Out {1}ms)", pingTime, httpPingEntry.TimeOut));
                            htmlTextTextDetails.Append(string.Format("{0}ms - <b>Error</b> (Time-Out {1}ms)", pingTime, httpPingEntry.TimeOut));
                        }
                        else if (pingTime >= httpPingEntry.MaxTime)
                        {
                            warnings++;
                            plainTextDetails.Append(string.Format("{0}ms - Warning (Max allowed {1}ms)", pingTime, httpPingEntry.MaxTime));
                            htmlTextTextDetails.Append(string.Format("{0}ms - <b>Warning</b> (Max allowed {1}ms)", pingTime, httpPingEntry.MaxTime));
                        }
                        else
                        {
                            plainTextDetails.Append(string.Format("{0}ms", pingTime));
                            htmlTextTextDetails.Append(string.Format("{0}ms", pingTime));
                        }

                        plainTextDetails.AppendLine();
                        htmlTextTextDetails.AppendLine("</li>");

                    }
                    catch (Exception innerEx)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("{0}", innerEx.Message));
                        htmlTextTextDetails.AppendLine(string.Format("{0}", innerEx.Message));
                    }                    
                }
                htmlTextTextDetails.AppendLine("</ul>");

                if (errors > 0 && warnings == 0) //are all errors
                    returnState = MonitorStates.Error;
                else if (errors > 0 || warnings > 0) //any errors or warnings
                    returnState = MonitorStates.Warning;
                LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
                LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
                LastDetailMsg.LastValue = pingTotalTime;
                
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
            showDetails.HttpPingConfig = HttpPingConfig;
            showDetails.Text = "Show details - " + collectorName;
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
            editConfig.SelectedHttpPingConfig = HttpPingConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.SelectedHttpPingConfig.ToConfig();
            }

            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.HttpPingEmptyConfig;
        }

        public override void ReadConfiguration(XmlDocument configDoc)
        {
            HttpPingConfig.ReadConfiguration(configDoc);
        }

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return (ICollectorDetailView)(new ShowDetails());
        }
    }
}
