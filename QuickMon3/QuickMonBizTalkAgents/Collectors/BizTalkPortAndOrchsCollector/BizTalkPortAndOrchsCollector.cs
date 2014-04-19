using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMon.Collectors;

namespace QuickMon
{
    [Description("BizTalk Port & Orchestration Collector"), Category("BizTalk")]
    public class BizTalkPortAndOrchsCollector : CollectorBase
    {
        public BizTalkPortAndOrchsCollector()
        {

            AgentConfig = new BizTalkPortAndOrchsCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "Getting Ports and Orchestration states and counts";
            long totalCount = 0;
            try
            {
                BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)((ICollectorConfig)AgentConfig).Entries[0];

                plainTextDetails.AppendLine(string.Format("BizTalk Ports and Orchestration Details for {0}.{1}", currentConfig.SqlServer, currentConfig.MgmtDBName));
                htmlTextTextDetails.AppendLine(string.Format("BizTalk Ports and Orchestration Details for {0}.{1}<hr/>", currentConfig.SqlServer, currentConfig.MgmtDBName));
                lastAction = "Getting Receive Location count";
                int receiveLocationCount = currentConfig.AllReceiveLocations ? currentConfig.GetTotalReceiveLocationCount() : currentConfig.ReceiveLocations.Count;
                lastAction = "Getting Disabled Receive Location count";
                int receiveLocationsDisabled = currentConfig.AllReceiveLocations ? currentConfig.GetDisabledReceiveLocationCount(new List<string>()) : currentConfig.GetDisabledReceiveLocationCount(currentConfig.ReceiveLocations);
                //Now check send ports
                lastAction = "Getting Send Port count";
                int sendPortCount = currentConfig.AllSendPorts ? currentConfig.GetTotalSendPortCount() : currentConfig.SendPorts.Count;
                lastAction = "Getting Stopped Send Port count";
                int sendPortStoppedCount = currentConfig.AllSendPorts ? currentConfig.GetStoppedSendPortCount(new List<string>()) : currentConfig.GetStoppedSendPortCount(currentConfig.SendPorts);
                //Now check orchestrations
                lastAction = "Getting Orchestration count";
                int orchestrationCount = currentConfig.AllOrchestrations ? currentConfig.GetTotalOrchestrationCount() : currentConfig.Orchestrations.Count;
                lastAction = "Getting Stopped Orchestration count";
                int orchestrationStoppedCount = currentConfig.AllOrchestrations ? currentConfig.GetStoppedOrchestrationCount(new List<string>()) : currentConfig.GetStoppedOrchestrationCount(currentConfig.Orchestrations);

                if (receiveLocationsDisabled == -1 || sendPortStoppedCount == -1 || orchestrationStoppedCount == -1)
                {
                    returnState.State = CollectorState.Error;
                    plainTextDetails.AppendLine( "An error occured trying to query the BizTalk Management database!");
                    htmlTextTextDetails.AppendLine("<blockquote>An error occured trying to query the BizTalk Management database!</blockquote>");
                }
                else
                {
                    htmlTextTextDetails.AppendLine("<blockquote>");
                    if ((receiveLocationsDisabled >= receiveLocationCount && (receiveLocationCount > 0)) ||
                        (sendPortStoppedCount >= sendPortCount && (sendPortCount > 0)) ||
                        (orchestrationStoppedCount >= orchestrationCount && (orchestrationCount > 0)))
                    {
                        returnState.State = CollectorState.Error;
                    }
                    else if (receiveLocationsDisabled > 0 || sendPortStoppedCount > 0 || orchestrationStoppedCount > 0)
                    {
                        returnState.State = CollectorState.Warning;
                    }
                    else
                        returnState.State = CollectorState.Good;
                    lastAction = "Getting summary of current states";
                    int count = 0;
                    plainTextDetails.AppendLine("Disabled Receive Locations");
                    htmlTextTextDetails.AppendLine("<b>Disabled Receive Locations</b>\r\n<ul>");
                    foreach (string rl in currentConfig.GetDisabledReceiveLocationNames())
                    {
                        plainTextDetails.AppendLine(string.Format("\t{0}", rl));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", rl));
                        count++;
                    }
                    totalCount += count;
                    if (count == 0)
                    {
                        plainTextDetails.AppendLine("\tNone");
                        htmlTextTextDetails.AppendLine("<li>None</li>");
                    }
                    htmlTextTextDetails.AppendLine("</ul>");

                    count = 0;
                    plainTextDetails.AppendLine("Stopped Send Ports");
                    htmlTextTextDetails.AppendLine("<b>Stopped Send Ports</b>\r\n<ul>");
                    foreach (string s in currentConfig.GetStoppedSendPortNames())
                    {
                        plainTextDetails.AppendLine(string.Format("\t{0}", s));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", s));
                        count++;
                    }
                    totalCount += count;
                    if (count == 0)
                    {
                        plainTextDetails.AppendLine("\tNone");
                        htmlTextTextDetails.AppendLine("<li>None</li>");
                    }
                    htmlTextTextDetails.AppendLine("</ul>");

                    count = 0;
                    plainTextDetails.AppendLine("Stopped Orchestrations");
                    htmlTextTextDetails.AppendLine("<b>Stopped Orchestrations</b>\r\n<ul>");
                    foreach (string s in currentConfig.GetStoppedOrchestrationNames())
                    {
                        plainTextDetails.AppendLine(string.Format("\t{0}", s));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", s));
                        count++;
                    }
                    totalCount += count;
                    if (count == 0)
                    {
                        plainTextDetails.AppendLine("\tNone");
                        htmlTextTextDetails.AppendLine("<li>None</li>");
                    }
                    htmlTextTextDetails.AppendLine("</ul>");
                    htmlTextTextDetails.AppendLine("</blockquote>");
                }               
                
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = totalCount;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = string.Format("Last step: '{0}\r\n{1}", lastAction, ex.Message);
                returnState.HtmlDetails = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new BizTalkPortAndOrchsCollectorShowDetails();
        }
        //public override IEditConfigWindow GetEditConfigWindow()
        //{
        //    return new BizTalkPortsAndOrchsEditConfig();
        //}
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.BizTalkGroupPortsAndOrchsDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new BizTalkPortsAndOrchsEditConfig();
        }
    }
}
