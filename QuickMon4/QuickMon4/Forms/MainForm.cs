using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisteredAgentCache.LoadAgentsOverride();
            try
            {
                MonitorPack m = new MonitorPack();
                string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars>\r\n" +
                            "<configVar find=\"localhost\" replace=\"%LocalHost%\" />\r\n" +
                        "</configVars>\r\n" +
                        "<collectorHosts>\r\n" +
                            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                               "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
                               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                               "<collectorAgents>\r\n" +
                                   "<collectorAgent type=\"PingCollector\">\r\n" +
                                        "<config>\r\n" +
                                            "<entries>\r\n" +
                                                "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
                                            "</entries>\r\n" +
                                        "</config>\r\n" +
                                   "</collectorAgent>\r\n" +
                               "</collectorAgents>\r\n" +
                            "</collectorHost>\r\n" +
                        "</collectorHosts>\r\n" +
                        "<notifierHosts>\r\n" +
                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                                "<notifierAgents>\r\n" +
                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
                                    "</notifierAgent>\r\n" +
                                "</notifierAgents>\r\n" +
                            "</notifierHost>\r\n" +
                        "</notifierHosts>\r\n" +
                       "</monitorPack>";
                m.LoadXml(mconfig);
                m.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
                m.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
                m.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
                m.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;

                MessageBox.Show(string.Format("Initial: {0}", m.CollectorHosts[0].CollectorAgents[0].InitialConfiguration), "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(string.Format("Active: {0}", m.CollectorHosts[0].CollectorAgents[0].ActiveConfiguration), "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //MessageBox.Show(string.Format("Calling Agent directly\r\nPing status: {0}",  m.CollectorHosts[0].CollectorAgents[0].GetState().State), "Ping me", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MonitorState ms = m.CollectorHosts[0].RefreshCurrentState();
                MessageBox.Show(string.Format("Calling via CollectorHost\r\nPing status: " + ms.State), "Ping me", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void m_CollectorHost_AlertRaised_Error(CollectorHost collectorHost)
        {
            MessageBox.Show(string.Format("Error alert raised for {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()), "Error alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void m_CollectorHost_AlertRaised_Warning(CollectorHost collectorHost)
        {
            MessageBox.Show(string.Format("Warning alert raised for {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()), "Warning alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void m_CollectorHost_AlertRaised_NoStateChanged(CollectorHost collectorHost)
        {
            MessageBox.Show(string.Format("No alert raised for {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()), "No alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void m_CollectorHost_AlertRaised_Good(CollectorHost collectorHost)
        {
            
            MessageBox.Show(string.Format("Good alert raised for {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()), "Good alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string configXml = "<collectorHosts>\r\n" +
                        "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                           "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                           "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                           "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                           "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
                           "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                           "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                           "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                           "<collectorAgents>\r\n" +
                               "<collectorAgent type=\"PingCollector\">\r\n" +
                                    "<config>\r\n" +
                                        "<entries>\r\n" +
                                            "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
                                        "</entries>\r\n" +
                                    "</config>\r\n" +
                               "</collectorAgent>\r\n" +
                           "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n" +
                    "</collectorHosts>";
            List<CollectorHost> chList = CollectorHost.GetCollectorHostsFromString(configXml);
            if (chList != null)
            {
                StringBuilder rebuildXml = new StringBuilder();
                rebuildXml.AppendLine("<collectorHosts>");
                foreach (CollectorHost ch in chList)
                {
                    rebuildXml.AppendLine(ch.ToXml());
                }
                rebuildXml.AppendLine("</collectorHosts>");

                chList = CollectorHost.GetCollectorHostsFromString(configXml);

                rebuildXml = new StringBuilder();
                rebuildXml.AppendLine("<collectorHosts>");
                foreach (CollectorHost ch in chList)
                {
                    rebuildXml.Append(ch.ToXml());
                }
                rebuildXml.AppendLine("</collectorHosts>");
                MessageBox.Show(rebuildXml.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MonitorState ms = new MonitorState();
                ms.ExecutedOnHostComputer = "localhost";
                ms.CurrentValue = 1;
                ms.RawDetails = "This is a test";
                ms.HtmlDetails = "<p>This is a test</p>";
                ms.State = CollectorState.NotAvailable;
                ms.Timestamp = DateTime.Now;
                ms.StateChangedTime = DateTime.Now;
                ms.CallDurationMS = 1001;
                ms.AlertsRaised.Add("Test alert");
                ms.ChildStates.Add(new MonitorState() { State = CollectorState.Good, RawDetails = "Child test" });
                ms.ChildStates.Add(new MonitorState() { State = CollectorState.Good, RawDetails = "Child test2" });

                string msSerialized = ms.ToXml();
                Clipboard.SetText(msSerialized);
                MessageBox.Show(msSerialized);
                ms.FromXml(ms.ToXml());
                Clipboard.SetText(ms.ToXml());
                MessageBox.Show("Reserialized:\r\n" + ms.ToXml());
                if (msSerialized.Equals(ms.ToXml()))
                    MessageBox.Show("Serialization/Deserialization success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Serialization/Deserialization failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MonitorPack m = new MonitorPack();
                string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars />\r\n" +
                        "<collectorHosts>\r\n" +
                            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                               "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
                               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                               "<collectorAgents>\r\n" +
                                   "<collectorAgent type=\"PingCollector\">\r\n" +
                                        "<config>\r\n" +
                                            "<entries>\r\n" +
                                                "<entry pingMethod=\"Ping\" address=\"NoPlaceLikeHome\" />\r\n" +
                                            "</entries>\r\n" +
                                        "</config>\r\n" +
                                   "</collectorAgent>\r\n" +
                               "</collectorAgents>\r\n" +
                            "</collectorHost>\r\n" +
                        "</collectorHosts>\r\n" +
                        "<notifierHosts>\r\n" +
                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                                "<notifierAgents>\r\n" +
                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
                                    "</notifierAgent>\r\n" +
                                "</notifierAgents>\r\n" +
                            "</notifierHost>\r\n" +
                        "</notifierHosts>\r\n" +
                       "</monitorPack>";
                m.LoadXml(mconfig);
                m.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
                m.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
                m.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
                m.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;

                MonitorState ms = m.CollectorHosts[0].RefreshCurrentState();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MonitorPack m = new MonitorPack();
                string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars />\r\n" +
                        "<collectorHosts>\r\n" +
                            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                               "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
                               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                               "<collectorAgents>\r\n" +
                                   "<collectorAgent type=\"PingCollector\">\r\n" +
                                        "<config>\r\n" +
                                            "<entries>\r\n" +
                                                "<entry pingMethod=\"Ping\" address=\"NoPlaceLikeHome\" />\r\n" +
                                                "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
                                            "</entries>\r\n" +
                                        "</config>\r\n" +
                                   "</collectorAgent>\r\n" +
                                   "<collectorAgent type=\"PingCollector\">\r\n" +
                                        "<config>\r\n" +
                                            "<entries>\r\n" +
                                                "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
                                            "</entries>\r\n" +
                                        "</config>\r\n" +
                                   "</collectorAgent>\r\n" +
                               "</collectorAgents>\r\n" +
                            "</collectorHost>\r\n" +
                        "</collectorHosts>\r\n" +
                        "<notifierHosts>\r\n" +
                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                                "<notifierAgents>\r\n" +
                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
                                    "</notifierAgent>\r\n" +
                                "</notifierAgents>\r\n" +
                            "</notifierHost>\r\n" +
                        "</notifierHosts>\r\n" +
                       "</monitorPack>";
                m.LoadXml(mconfig);
                m.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
                m.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
                m.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
                m.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;

                MonitorState ms = m.CollectorHosts[0].RefreshCurrentState();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                MonitorPack m = new MonitorPack();
                string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars />\r\n" +
                        "<collectorHosts>\r\n" +
                            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                               "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
                               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                               "<collectorAgents>\r\n" +
                                   "<collectorAgent type=\"PingCollector\">\r\n" +
                                        "<config>\r\n" +
                                            "<entries>\r\n" +
                                                "<entry pingMethod=\"Ping\" address=\"" + txtHostName.Text + "\" />\r\n" +
                                            "</entries>\r\n" +
                                        "</config>\r\n" +
                                   "</collectorAgent>\r\n" +
                               "</collectorAgents>\r\n" +
                            "</collectorHost>\r\n" +
                        "</collectorHosts>\r\n" +
                        "<notifierHosts>\r\n" +
                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                                "<notifierAgents>\r\n" +
                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
                                    "</notifierAgent>\r\n" +
                                "</notifierAgents>\r\n" +
                            "</notifierHost>\r\n" +
                        "</notifierHosts>\r\n" +
                       "</monitorPack>";
                m.LoadXml(mconfig);
                m.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
                m.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
                m.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
                m.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;

                MonitorState ms = m.CollectorHosts[0].RefreshCurrentState();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
