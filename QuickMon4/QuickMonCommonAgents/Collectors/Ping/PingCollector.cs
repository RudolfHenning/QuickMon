using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("Ping Collector"), Category("General")]
    public class PingCollector : CollectorAgentBase
    {
        public PingCollector()
        {
            AgentConfig = new PingCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            //StringBuilder plainTextDetails = new StringBuilder();
            //StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            long pingTotalTime = 0;
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                PingCollectorConfig currentConfig = (PingCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Pinging {0} entries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Pinging {0} entries</b>", currentConfig.Entries.Count);
                foreach (PingCollectorHostEntry host in currentConfig.Entries)
                {
                    PingCollectorResult pingResult = host.Ping();
                    CollectorState currentState = host.GetState(pingResult);
                    if (pingResult.Success)
                    {
                        pingTotalTime += pingResult.PingTime;
                        if (currentState == CollectorState.Error)
                        {
                            errors++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Error,
                                    CurrentValue = pingResult.PingTime,
                                    RawDetails = string.Format("{0} {1} (Error)", host.Address, pingResult.ResponseDetails),
                                    HtmlDetails = string.Format("{0} {1} (<b>Error</b>)", host.Address, pingResult.ResponseDetails)
                                });

                            //plainTextDetails.AppendLine(string.Format("\t{0} (Error) - {1} ", host.Address, pingResult.ResponseDetails));
                            //htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Error</b>) - {1}</li>", host.Address, pingResult.ResponseDetails));
                        }
                        else if (currentState == CollectorState.Warning)
                        {
                            warnings++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Error,
                                    CurrentValue = pingResult.PingTime,
                                    RawDetails = string.Format("{0} {1} {2}ms (Warning)", host.Address, pingResult.ResponseDetails, pingResult.PingTime),
                                    HtmlDetails = string.Format("{0} {1} {2}ms (<b>Warning</b>)", host.Address, pingResult.ResponseDetails, pingResult.PingTime)
                                });

                            //plainTextDetails.AppendLine(string.Format("\t{0} (Warning) - {1}ms - {2}", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                            //htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Warning</b>) - {1}ms - {2}</li>", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                        }
                        else
                        {
                            success++;
                            returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Error,
                                    CurrentValue = pingResult.PingTime,
                                    RawDetails = string.Format("{0} {1} {2}ms (Success)", host.Address, pingResult.ResponseDetails, pingResult.PingTime),
                                    HtmlDetails = string.Format("{0} {1} {2}ms (<b>Success</b>)", host.Address, pingResult.ResponseDetails, pingResult.PingTime)
                                });

                            //plainTextDetails.AppendLine(string.Format("\t{0} (Success) - {1}ms - {2}", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                            //htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Success</b>) - {1}ms - {2}</li>", host.Address, pingResult.PingTime, pingResult.ResponseDetails));
                        }
                    }
                    else
                    {
                        errors++;
                        returnState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = CollectorState.Error,
                                    CurrentValue = "",
                                    RawDetails = string.Format("{0} {1} (Error)", host.Address, pingResult.ResponseDetails),
                                    HtmlDetails = string.Format("{0} {1} (<b>Error</b>)", host.Address, pingResult.ResponseDetails)
                                });

                        //plainTextDetails.AppendLine(string.Format("\t{0} (Error) - {1}", host.Address, pingResult.ResponseDetails));
                        //htmlTextTextDetails.AppendLine(string.Format("<li>{0} (<b>Error</b>) - {1}</li>", host.Address, pingResult.ResponseDetails));
                    }
                }
                //htmlTextTextDetails.AppendLine("</ul>");
                //returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                //returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = pingTotalTime;

                if (errors > 0 && warnings == 0 && success == 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }
        
    }
}
