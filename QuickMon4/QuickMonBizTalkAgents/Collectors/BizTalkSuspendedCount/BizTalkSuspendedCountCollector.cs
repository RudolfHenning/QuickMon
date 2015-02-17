using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("BizTalk Suspended Counts Collector"), Category("BizTalk")]
    public class BizTalkSuspendedCountCollector : CollectorAgentBase
    {
        public BizTalkSuspendedCountCollector()
        {
            AgentConfig = new BizTalkSuspendedCountCollectorConfig();
        }
        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int instancesSuspended = 0;
            try
            {
                BizTalkSuspendedCountCollectorConfig currentConfig = (BizTalkSuspendedCountCollectorConfig)AgentConfig;

                if (currentConfig.Entries.Count == 1)
                {
                    BizTalkSuspendedCountCollectorConfigEntry entry = (BizTalkSuspendedCountCollectorConfigEntry)currentConfig.Entries[0];

                    returnState.RawDetails = string.Format("BizTalk Managament DB: {0}", entry.Description);
                    returnState.HtmlDetails = string.Format("<b>BizTalk Managament DB: {0}</b>", entry.Description);
                    returnState.CurrentValue = "None";

                    instancesSuspended = entry.GetSuspendedMsgsCount();
                    if (instancesSuspended < entry.InstancesWarning)
                    {
                        returnState.State = CollectorState.Good;
                    }
                    else if (instancesSuspended >= entry.InstancesError)
                    {
                        returnState.State = CollectorState.Error;
                    }
                    else
                    {
                        returnState.State = CollectorState.Warning;
                    }
                    if (instancesSuspended > 0)
                    {
                        returnState.ForAgent = entry.Description;
                        returnState.CurrentValue = instancesSuspended;
                        MonitorState suspendedIstancesState = new MonitorState()
                        {
                            RawDetails = "Suspended instances",
                            HtmlDetails = "<b>Suspended instances</b>"
                        };
                        foreach(SuspendedInstance si in entry.GetTopXSuspendedInstanced())
                        {
                            suspendedIstancesState.ChildStates.Add(
                                new MonitorState()
                                {
                                    RawDetails = si.ToString(),
                                    HtmlDetails = si.ToString(true)
                                });
                        }
                        returnState.ChildStates.Add(suspendedIstancesState);
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
            BizTalkSuspendedCountCollectorConfig currentConfig = (BizTalkSuspendedCountCollectorConfig)AgentConfig;

            System.Data.DataTable suspendedTable = new System.Data.DataTable(Name);
            suspendedTable.Columns.Add(new System.Data.DataColumn("Host", typeof(string)));
            suspendedTable.Columns.Add(new System.Data.DataColumn("Application", typeof(string)));
            suspendedTable.Columns.Add(new System.Data.DataColumn("Message type", typeof(string)));
            suspendedTable.Columns.Add(new System.Data.DataColumn("Server", typeof(string)));
            suspendedTable.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
            suspendedTable.Columns.Add(new System.Data.DataColumn("URI", typeof(string)));
            suspendedTable.Columns.Add(new System.Data.DataColumn("Adapter", typeof(string)));
            suspendedTable.Columns.Add(new System.Data.DataColumn("Info", typeof(string)));
            if (currentConfig.Entries.Count == 1)
            {
                BizTalkSuspendedCountCollectorConfigEntry entry = (BizTalkSuspendedCountCollectorConfigEntry)currentConfig.Entries[0];
                foreach(SuspendedInstance si in  entry.GetTopXSuspendedInstanced(100))
                {
                    suspendedTable.Rows.Add(si.Host, si.Application, si.MessageType, si.PublishingServer, si.SuspendTime.ToString("yyyy-MM-dd HH:mm:ss"), si.Uri, si.Adapter, si.AdditionalInfo);
                }
            }
            list.Add(suspendedTable);
            return list;
        }
    }
}
