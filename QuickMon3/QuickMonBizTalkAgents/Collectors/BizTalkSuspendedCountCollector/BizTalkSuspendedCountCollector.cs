using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("BizTalk Suspended Counts Collector"), Category("BizTalk")]
    public class BizTalkSuspendedCountCollector : CollectorBase
    {
        public BizTalkSuspendedCountCollector()
        {
            AgentConfig = new BizTalkSuspendedCountCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "Getting Suspended counts";
            int instancesSuspended = 0;
            try
            {
                BizTalkSuspendedCountCollectorConfigEntry currentConfig = (BizTalkSuspendedCountCollectorConfigEntry)((ICollectorConfig)AgentConfig).Entries[0];
                lastAction = string.Format("Getting BizTalk Ports and Orchestration Details for {0}.{1}", currentConfig.SqlServer, currentConfig.MgmtDBName);
                instancesSuspended = currentConfig.GetSuspendedMsgsCount();

                if (instancesSuspended < currentConfig.InstancesWarning)
                {
                    returnState.State = CollectorState.Good;
                }
                else if (instancesSuspended >= currentConfig.InstancesError)
                {
                    returnState.State = CollectorState.Error;
                }
                else
                {
                    returnState.State = CollectorState.Warning;
                }

                if (instancesSuspended > 0)
                {
                    plainTextDetails.AppendLine(string.Format("Total suspended count: {0}\r\n", instancesSuspended));
                    htmlTextTextDetails.AppendLine(string.Format("<b>Total suspended count:</b> {0}<hr />\r\n", instancesSuspended));

                    if (returnState.State != CollectorState.Good && currentConfig.ShowLastXDetails > 0)
                    {
                        AgentMultiFormatInfoMsg info = currentConfig.GetLastXDetails();
                        plainTextDetails.AppendLine(info.RawText);
                        htmlTextTextDetails.AppendLine(info.HTMLText);
                    }
                }
                else
                {
                    plainTextDetails.AppendLine( "No suspended instances");
                    htmlTextTextDetails.AppendLine("No suspended instances");
                }
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = instancesSuspended;

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
            return new BizTalkSuspendedCountCollectorShowDetails();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new BizTalkSuspendedCountCollectorEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.BizTalkSuspendedCountCollectorDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new BizTalkSuspendedCountCollectorEditConfig();
        }
    }
}
