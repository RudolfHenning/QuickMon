using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("BizTalk Port & Orchestration Collector"), Category("BizTalk")]
    public class BizTalkPortAndOrchsCollector : CollectorAgentBase
    {
        public BizTalkPortAndOrchsCollector()
        {
            AgentConfig = new BizTalkPortAndOrchsCollectorConfig();
        }
        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                BizTalkPortAndOrchsCollectorConfig currentConfig = (BizTalkPortAndOrchsCollectorConfig)AgentConfig;

                if (currentConfig.Entries.Count == 1)
                {
                    BizTalkPortAndOrchsCollectorConfigEntry entry = (BizTalkPortAndOrchsCollectorConfigEntry)currentConfig.Entries[0];

                    returnState.RawDetails = string.Format("BizTalk Managament DB: {0}", entry.Description);
                    returnState.HtmlDetails = string.Format("<b>BizTalk Managament DB: {0}</b>", entry.Description);
                    returnState.CurrentValue = 0;

                    lastAction = "Getting Receive Location count";
                    int receiveLocationCount = entry.AllReceiveLocations ? entry.GetTotalReceiveLocationCount() : entry.ReceiveLocations.Count;
                    lastAction = "Getting Disabled Receive Location count";
                    int receiveLocationsDisabled = entry.AllReceiveLocations ? entry.GetDisabledReceiveLocationCount(new List<string>()) : entry.GetDisabledReceiveLocationCount(entry.ReceiveLocations);

                    //Now check send ports
                    lastAction = "Getting Send Port count";
                    int sendPortCount = entry.AllSendPorts ? entry.GetTotalSendPortCount() : entry.SendPorts.Count;
                    lastAction = "Getting Stopped Send Port count";
                    int sendPortStoppedCount = entry.AllSendPorts ? entry.GetStoppedSendPortCount(new List<string>()) : entry.GetStoppedSendPortCount(entry.SendPorts);
                    //Now check orchestrations
                    lastAction = "Getting Orchestration count";
                    int orchestrationCount = entry.AllOrchestrations ? entry.GetTotalOrchestrationCount() : entry.Orchestrations.Count;
                    lastAction = "Getting Stopped Orchestration count";
                    int orchestrationStoppedCount = entry.AllOrchestrations ? entry.GetStoppedOrchestrationCount(new List<string>()) : entry.GetStoppedOrchestrationCount(entry.Orchestrations);

                    if (receiveLocationsDisabled == -1 || sendPortStoppedCount == -1 || orchestrationStoppedCount == -1)
                    {
                        returnState.State = CollectorState.Error;
                        returnState.ForAgent = entry.Description;
                        returnState.CurrentValue = "BizTalk Management database error";
                        returnState.RawDetails = "An error occured trying to query the BizTalk Management database!";
                        returnState.HtmlDetails = "An error occured trying to query the BizTalk Management database!";
                    }
                    else
                    {
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

                        if (receiveLocationsDisabled >0)
                        {
                            StringBuilder sbReceiveLocationsDisabled = new StringBuilder();
                            foreach (string rl in entry.GetDisabledReceiveLocationNames())
                            {
                                sbReceiveLocationsDisabled.AppendLine(rl);
                            }
                            returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = "Disabled receive locations: " + entry.Description,
                                RawDetails = sbReceiveLocationsDisabled.ToString(),
                                HtmlDetails = sbReceiveLocationsDisabled.ToString()
                            }
                            );
                        }
                        if (sendPortStoppedCount > 0)
                        {
                            StringBuilder sbSendPortStopped = new StringBuilder();
                            foreach (string rl in entry.GetStoppedSendPortNames())
                            {
                                sbSendPortStopped.AppendLine(rl);
                            }
                            returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = "Stopped send ports: " + entry.Description,
                                RawDetails = sbSendPortStopped.ToString(),
                                HtmlDetails = sbSendPortStopped.ToString()
                            }
                            );
                        }
                        if (orchestrationStoppedCount > 0)
                        {
                            StringBuilder sbOrchestrationStopped = new StringBuilder();
                            foreach (string rl in entry.GetStoppedOrchestrationNames())
                            {
                                sbOrchestrationStopped.AppendLine(rl);
                            }
                            returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = "Stopped orchestrations: " + entry.Description,
                                RawDetails = sbOrchestrationStopped.ToString(),
                                HtmlDetails = sbOrchestrationStopped.ToString()
                            }
                            );
                        }   
                        
                    }
                }
                else
                {
                    returnState.State = CollectorState.Error;
                    returnState.RawDetails = "Configuration not set";
                    returnState.HtmlDetails = "Configuration not set";
                }
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }
        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
    }
}
