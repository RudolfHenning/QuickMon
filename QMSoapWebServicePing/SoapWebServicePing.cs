using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class SoapWebServicePing : CollectorBase
    {
        private SoapWebServicePingConfig soapWebServicePingConfig = new SoapWebServicePingConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Querying web service";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int success = 0;
            try
            {
                plainTextDetails.AppendLine(string.Format("Calling {0} web service(s)", soapWebServicePingConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<b>Calling {0} web service(s)</b>", soapWebServicePingConfig.Entries.Count));

                htmlTextTextDetails.AppendLine("<ul>");
                foreach (SoapWebServicePingConfigEntry soapWebServicePingConfigEntry in soapWebServicePingConfig.Entries)
                {
                    try
                    {
                        plainTextDetails.Append(string.Format("\t\t{0} - ", soapWebServicePingConfigEntry.ServiceBaseURL));
                        htmlTextTextDetails.Append(string.Format("<li>{0} - ", soapWebServicePingConfigEntry.ServiceBaseURL));

                        object val = soapWebServicePingConfigEntry.ExecuteMethod();
                        string formattedVal = "";                        
                        bool checkResultMatch = soapWebServicePingConfigEntry.CheckResultMatch(val, soapWebServicePingConfigEntry.ResultType, soapWebServicePingConfigEntry.CustomValue1, soapWebServicePingConfigEntry.CustomValue2, out formattedVal);
                        LastDetailMsg.LastValue = formattedVal;
                        if (checkResultMatch)
                            //(checkResultMatch && soapWebServicePingConfigEntry.CheckType == SoapWebServicePingCheckType.Success)
                            //||
                            //(!checkResultMatch && soapWebServicePingConfigEntry.CheckType == SoapWebServicePingCheckType.Failure)
                            //)
                        {
                            success++;
                            plainTextDetails.Append("Success - ");
                            htmlTextTextDetails.Append("<b>Success</b> - ");                           
                        }
                        else
                        {
                            errors++;
                            plainTextDetails.Append("Failure - ");
                            htmlTextTextDetails.Append("<b>Failure</b> - ");
                        }
                        switch (soapWebServicePingConfigEntry.ResultType)
                        {
                            case SoapWebServicePingResultEnum.CheckAvailabilityOnly:
                                plainTextDetails.Append("Available");
                                htmlTextTextDetails.Append("Available");
                                break;
                            case SoapWebServicePingResultEnum.NoValueOnly:
                                plainTextDetails.Append("No value returned");
                                htmlTextTextDetails.Append("No value returned");
                                break;
                            default:
                                plainTextDetails.Append(string.Format("Value:{0}", formattedVal));
                                htmlTextTextDetails.Append(string.Format("Value:{0}", formattedVal));
                                break;
                        }

                        plainTextDetails.AppendLine();
                        htmlTextTextDetails.AppendLine("</li>");
                    }
                    catch (Exception innerEx)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("{0}\r\n{1}", soapWebServicePingConfigEntry.LastError, innerEx.Message));
                        htmlTextTextDetails.AppendLine(string.Format("{0}\r\n{1}", soapWebServicePingConfigEntry.LastError, innerEx.Message));
                    }                    
                }
                htmlTextTextDetails.AppendLine("</ul>");

                if (errors > 0 && success == 0) //are all errors
                    returnState = MonitorStates.Error;
                else if (errors > 0 && success > 0) //mixture
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
            showDetails.SoapWebServicePingConfig = soapWebServicePingConfig;
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
            editConfig.SelectedSoapWebServicePingConfig = soapWebServicePingConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.SelectedSoapWebServicePingConfig.ToConfig();
            }

            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SoapWebServiceConfig;
        }

        public override void ReadConfiguration(System.Xml.XmlDocument configDoc)
        {
            soapWebServicePingConfig.ReadConfiguration(configDoc);
        }
    }
}
