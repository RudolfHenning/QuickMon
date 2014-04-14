using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Soap Web Service Query Collector"), Category("General")]
    public class SoapWebServicePingCollector : CollectorBase
    {
        public SoapWebServicePingCollector()
        {
            AgentConfig = new SoapWebServicePingCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            int errors = 0;
            int success = 0;

            try
            {
                SoapWebServicePingCollectorConfig config = (SoapWebServicePingCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Calling {0} web service(s)", config.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<b>Calling {0} web service(s)</b>", config.Entries.Count));

                htmlTextTextDetails.AppendLine("<ul>");
                foreach (SoapWebServicePingConfigEntry soapWebServicePingConfigEntry in config.Entries)
                {
                    plainTextDetails.Append(string.Format("\t\t{0} - ", soapWebServicePingConfigEntry.ServiceBaseURL));
                    htmlTextTextDetails.Append(string.Format("<li>{0} - ", soapWebServicePingConfigEntry.ServiceBaseURL));

                    object val = soapWebServicePingConfigEntry.ExecuteMethod();
                    string formattedVal = "";
                    bool checkResultMatch = soapWebServicePingConfigEntry.CheckResultMatch(val, soapWebServicePingConfigEntry.ResultType, soapWebServicePingConfigEntry.CustomValue1, soapWebServicePingConfigEntry.CustomValue2, out formattedVal);
                    //LastDetailMsg.LastValue = formattedVal;
                    if (checkResultMatch)
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
                        case SoapWebServicePingResult.CheckAvailabilityOnly:
                            plainTextDetails.Append("Available");
                            htmlTextTextDetails.Append("Available");
                            break;
                        case SoapWebServicePingResult.NoValueOnly:
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
                htmlTextTextDetails.AppendLine("</ul>");

                if (errors > 0 && success == 0) //are all errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 && success > 0) //mixture
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
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
            return new SoapWebServicePingCollectorShowDetails();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new SoapWebServicePingCollectorEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SoapWebServicePingCollectorDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new SoapWebServicePingCollectorEditEntry();
        }
    }
}
