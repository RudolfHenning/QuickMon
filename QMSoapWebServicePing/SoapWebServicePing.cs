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
            LastDetailMsg.PlainText = "Querying table sizes";
            LastDetailMsg.HtmlText = "";
            int errors = 0;
            int success = 0;
            try
            {
                plainTextDetails.AppendLine(string.Format("Pinging {0} addresses", soapWebServicePingConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<b>Pinging {0} addresses</b>", soapWebServicePingConfig.Entries.Count));

                htmlTextTextDetails.AppendLine("<ul>");
                foreach (SoapWebServicePingConfigEntry soapWebServicePingConfigEntry in soapWebServicePingConfig.Entries)
                {
                    try
                    {
                        plainTextDetails.Append(string.Format("\t\t{0} - ", soapWebServicePingConfigEntry.ServiceBaseURL));
                        htmlTextTextDetails.Append(string.Format("<li>{0} - ", soapWebServicePingConfigEntry.ServiceBaseURL));

                        object val = soapWebServicePingConfigEntry.ExecuteMethod();

                        if ((int)SoapWebServicePingResultEnum.CheckAvailabilityOnly == soapWebServicePingConfigEntry.OnErrorType)
                        {
                            success++;
                            plainTextDetails.Append("Success - Available");
                            htmlTextTextDetails.Append("<b>Success</b> - Available");
                        }
                        else if ((int)SoapWebServicePingResultEnum.FailOnNoValue == soapWebServicePingConfigEntry.OnErrorType
                            && (val == null || val.ToString() == ""))
                        {
                            errors++;
                            plainTextDetails.Append("Error - No value returned");
                            htmlTextTextDetails.Append("<b>Error</b> - No value returned");
                        }
                        else if ((int)SoapWebServicePingResultEnum.FailOnSpecifiedValue == soapWebServicePingConfigEntry.OnErrorType
                            && val.ToString() == soapWebServicePingConfigEntry.ErrorCustomValue)
                        {
                            errors++;
                            plainTextDetails.Append(string.Format("Error - Value:{0}", val));
                            htmlTextTextDetails.Append(string.Format("<b>Error</b> - Value:{0}", val));
                        }                        
                        else
                        {
                            success++;
                            plainTextDetails.Append("Success - Available");
                            htmlTextTextDetails.Append("<b>Success</b> - Available");
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
            throw new NotImplementedException();
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
