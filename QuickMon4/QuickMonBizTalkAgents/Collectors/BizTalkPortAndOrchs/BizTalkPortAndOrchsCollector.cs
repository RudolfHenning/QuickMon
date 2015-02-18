using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("BizTalk Port and Orchestration Collector"), Category("BizTalk")]
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
            try
            {
                BizTalkPortAndOrchsCollectorConfig currentConfig = (BizTalkPortAndOrchsCollectorConfig)AgentConfig;

                if (currentConfig.Entries.Count == 1)
                {
                    BizTalkPortAndOrchsCollectorConfigEntry entry = (BizTalkPortAndOrchsCollectorConfigEntry)currentConfig.Entries[0];

                    returnState.RawDetails = string.Format("BizTalk Managament DB: {0}", entry.Description);
                    returnState.HtmlDetails = string.Format("<b>BizTalk Managament DB: {0}</b>", entry.Description);
                    returnState.CurrentValue = "All ok";

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
                            returnState.CurrentValue = (sendPortStoppedCount > 0 ? string.Format("SP: {0},", sendPortStoppedCount) : "");
                            returnState.CurrentValue += (orchestrationStoppedCount > 0 ? string.Format("ORCH: {0},", orchestrationStoppedCount) : "");
                            returnState.CurrentValue += returnState.CurrentValue.ToString().Trim(',');
                        }
                        else if (receiveLocationsDisabled > 0 || sendPortStoppedCount > 0 || orchestrationStoppedCount > 0)
                        {
                            returnState.State = CollectorState.Warning;
                            returnState.CurrentValue = (sendPortStoppedCount > 0 ? string.Format("SP: {0},", sendPortStoppedCount) : "");
                            returnState.CurrentValue += (orchestrationStoppedCount > 0 ? string.Format("ORCH: {0},", orchestrationStoppedCount) : "");
                            returnState.CurrentValue += returnState.CurrentValue.ToString().Trim(',');
                        }
                        else
                            returnState.State = CollectorState.Good;

                        if (receiveLocationsDisabled > 0)
                        {
                            MonitorState disabledRL = new MonitorState()
                                {
                                    RawDetails = "Disabled receive locations",
                                    HtmlDetails = "<b>Disabled receive locations</b>"
                                };
                            foreach (string rl in entry.GetDisabledReceiveLocationNames())
                            {
                                disabledRL.ChildStates.Add(
                                    new MonitorState()
                                {
                                    CurrentValue = "Disabled RL: " + rl,
                                    RawDetails = rl
                                });
                            }
                            returnState.ChildStates.Add(disabledRL);
                        }
                        if (sendPortStoppedCount > 0)
                        {
                            MonitorState stoppedSP = new MonitorState()
                            {
                                RawDetails = "Stopped send ports",
                                HtmlDetails = "<b>Stopped send ports</b>"
                            };
                            foreach (string sp in entry.GetStoppedSendPortNames())
                            {
                                stoppedSP.ChildStates.Add(
                                    new MonitorState()
                                    {
                                        CurrentValue = "Stopped SP: " + sp,
                                        RawDetails = sp
                                    });
                            }
                            returnState.ChildStates.Add(stoppedSP);                            
                        }
                        if (orchestrationStoppedCount > 0)
                        {
                            MonitorState stoppedOrchs = new MonitorState()
                            {
                                RawDetails = "Stopped orchestrations",
                                HtmlDetails = "<b>Stopped orchestrations</b>"
                            };
                            foreach (string orch in entry.GetStoppedOrchestrationNames())
                            {
                                stoppedOrchs.ChildStates.Add(
                                    new MonitorState()
                                    {
                                        CurrentValue = "Stopped Orch: " + orch,
                                        RawDetails = orch
                                    });
                            }
                            returnState.ChildStates.Add(stoppedOrchs);                            
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
            List<System.Data.DataTable> list = new List<System.Data.DataTable>();
            BizTalkPortAndOrchsCollectorConfig currentConfig = (BizTalkPortAndOrchsCollectorConfig)AgentConfig;
            if (currentConfig.Entries.Count == 1)
            {
                BizTalkPortAndOrchsCollectorConfigEntry entry = (BizTalkPortAndOrchsCollectorConfigEntry)currentConfig.Entries[0];
                System.Data.DataTable receiveLocationsTable = new System.Data.DataTable(entry.SqlServer + " - Receive locations");
                receiveLocationsTable.Columns.Add(new System.Data.DataColumn("Port", typeof(string)));
                receiveLocationsTable.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
                receiveLocationsTable.Columns.Add(new System.Data.DataColumn("State", typeof(string)));

                System.Data.DataTable sendPortsTable = new System.Data.DataTable(entry.SqlServer + " - Send ports");
                sendPortsTable.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
                sendPortsTable.Columns.Add(new System.Data.DataColumn("State", typeof(string)));

                System.Data.DataTable orchestrationsTable = new System.Data.DataTable(entry.SqlServer + " - Orchestrations");
                orchestrationsTable.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
                orchestrationsTable.Columns.Add(new System.Data.DataColumn("State", typeof(string)));

                foreach (ReceiveLocationInfo rl in entry.GetReceiveLocationList())
                {
                    receiveLocationsTable.Rows.Add(rl.ReceivePortName, rl.ReceiveLocationName, rl.Disabled ? "Disabled" : "Enabled");
                }
                foreach (SendPortInfo sp in entry.GetSendPortList())
                {
                    sendPortsTable.Rows.Add(sp.Name, sp.State);
                }
                foreach (SendPortInfo orch in entry.GetOrchestrationList())
                {
                    orchestrationsTable.Rows.Add(orch.Name, orch.State);
                }
                list.Add(receiveLocationsTable);
                list.Add(sendPortsTable);
                list.Add(orchestrationsTable);
            }
            else
            {
                System.Data.DataTable dt = new System.Data.DataTable(Name);
                dt.Columns.Add(new System.Data.DataColumn("Error", typeof(string)));
                dt.Rows.Add("Configuration error.");
                list.Add(dt);
            }

            return list;
        }
    }
}
