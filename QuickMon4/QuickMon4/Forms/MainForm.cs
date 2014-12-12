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
                               "pollSlideFrequencyAfterThirdRepeatSec=\"30\" alertsPaused=\"False\">\r\n" +
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

        private void AppendOutput(string message)
        {
            lock (txtAlerts)
            {
                txtAlerts.Text += string.Format("\r\n{0}", message);
                txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
                txtAlerts.ScrollToCaret();
            }
        }

        void m_CollectorHost_AlertRaised_Error(CollectorHost collectorHost)
        {
            AppendOutput(string.Format("Error:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
        }

        void m_CollectorHost_AlertRaised_Warning(CollectorHost collectorHost)
        {
            AppendOutput(string.Format("Warning:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
        }

        private void m_CollectorHost_AlertRaised_NoStateChanged(CollectorHost collectorHost)
        {
            //AppendOutput(string.Format("No State changed:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
        }

        private void m_CollectorHost_AlertRaised_Good(CollectorHost collectorHost)
        {
            //AppendOutput(string.Format("Good:\r\nFor: {0}\r\nDetails: {1}", collectorHost.Name, collectorHost.CurrentState.ReadAllRawDetails()));
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
                                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
                                        "<config><logFile path=\"c:\\Temp\\QuickMon4Test.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
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


        private MonitorPack persistentTest = new MonitorPack();
        private void button6_Click(object sender, EventArgs e)
        {            
            try
            {
                txtAlerts.Text = "";
                //string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                //        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                //        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                //        "<configVars />\r\n" +
                //        "<collectorHosts>\r\n" +
                //            "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                //               "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                //               "repeatAlertInXMin=\"1\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                //               "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                //               "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                //               "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                //               "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                //               "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
                //               "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                //               "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                //               "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                //               "<collectorAgents>\r\n" +
                //                   "<collectorAgent type=\"PingCollector\">\r\n" +
                //                        "<config>\r\n" +
                //                            "<entries>\r\n" +
                //                                "<entry pingMethod=\"Ping\" address=\"" + txtHostName.Text + "\" />\r\n" +
                //                            "</entries>\r\n" +
                //                        "</config>\r\n" +
                //                   "</collectorAgent>\r\n" +
                //               "</collectorAgents>\r\n" +
                //            "</collectorHost>\r\n" +
                //        "</collectorHosts>\r\n" +
                //        "<notifierHosts>\r\n" +
                //            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                //                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                //                "<notifierAgents>\r\n" +
                //                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
                //                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
                //                    "</notifierAgent>\r\n" +
                //                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
                //                        "<config><logFile path=\"c:\\Temp\\QuickMon4Test.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
                //                    "</notifierAgent>\r\n" +
                //                "</notifierAgents>\r\n" +
                //            "</notifierHost>\r\n" +
                //            "<notifierHost name=\"Non-Default notifiers\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" " +
                //                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                //                "<notifierAgents>\r\n" +
                //                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
                //                        "<config><logFile path=\"c:\\Temp\\QuickMon4ErrorTest.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
                //                    "</notifierAgent>\r\n" +
                //                    "<notifierAgent type=\"EventLogNotifier\">\r\n" +
                //                        "<config><eventLog computer=\".\" eventSource=\"QuickMon4\" successEventID=\"0\" warningEventID=\"1\" errorEventID=\"2\" /></config>\r\n" +
                //                    "</notifierAgent>\r\n" +
                //                "</notifierAgents>\r\n" +
                //            "</notifierHost>\r\n" +
                //        "</notifierHosts>\r\n" +
                //       "</monitorPack>";

                 string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars />\r\n" +
                        "<collectorHosts>\r\n";
                 if (txtHostName.Text.Trim().Length > 0)
                 {
                     string[] hostnames = txtHostName.Text.Split(',', ' ');
                     foreach (string hostname in hostnames)
                     {
                         mconfig += "<collectorHost uniqueId=\"123\" name=\"Ping " + hostname.EscapeXml().Trim() + "\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                                "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                                "repeatAlertInXMin=\"1\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                                "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                                "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                                "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                                "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                                "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" " +
                                "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                                "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                                "pollSlideFrequencyAfterThirdRepeatSec=\"30\" alertsPaused=\"" + (chkPauseAlerts.Checked ? "True" : "False") + "\">\r\n" +
                                "<collectorAgents>\r\n" +
                                    "<collectorAgent type=\"PingCollector\">\r\n" +
                                         "<config>\r\n" +
                                             "<entries>\r\n" +
                                                 "<entry pingMethod=\"Ping\" address=\"" + hostname.EscapeXml().Trim() + "\" />\r\n" +
                                             "</entries>\r\n" +
                                         "</config>\r\n" +
                                    "</collectorAgent>\r\n" +
                                "</collectorAgents>\r\n" +
                             "</collectorHost>\r\n";
                     }
                 }
                 mconfig += "</collectorHosts>\r\n" +
                        "<notifierHosts>\r\n" +
                            "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                                "<notifierAgents>\r\n" +
                                    "<notifierAgent type=\"InMemoryNotifier\">\r\n" +
                                        "<config><inMemory maxEntryCount=\"99999\" /></config>\r\n" +
                                    "</notifierAgent>\r\n" +
                                    //"<notifierAgent type=\"LogFileNotifier\">\r\n" +
                                    //    "<config><logFile path=\"c:\\Temp\\QuickMon4Test.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
                                    //"</notifierAgent>\r\n" +
                                "</notifierAgents>\r\n" +
                            "</notifierHost>\r\n" +
                            "<notifierHost name=\"Non-Default notifiers\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" " +
                                "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                                "<notifierAgents>\r\n" +
                                    "<notifierAgent type=\"LogFileNotifier\">\r\n" +
                                        "<config><logFile path=\"c:\\Temp\\QuickMon4ErrorTest.log\" createNewFileSizeKB=\"0\" /></config>\r\n" +
                                    "</notifierAgent>\r\n" +
                                    "<notifierAgent type=\"EventLogNotifier\">\r\n" +
                                        "<config><eventLog computer=\".\" eventSource=\"QuickMon4\" successEventID=\"0\" warningEventID=\"1\" errorEventID=\"2\" /></config>\r\n" +
                                    "</notifierAgent>\r\n" +
                                "</notifierAgents>\r\n" +
                            "</notifierHost>\r\n" +
                        "</notifierHosts>\r\n" +
                       "</monitorPack>";


                persistentTest = new MonitorPack();
                persistentTest.ConcurrencyLevel = (int)nudConcurency.Value;
                persistentTest.LoadXml(mconfig);
                persistentTest.CollectorHost_AlertRaised_Good += m_CollectorHost_AlertRaised_Good;
                persistentTest.CollectorHost_AlertRaised_NoStateChanged += m_CollectorHost_AlertRaised_NoStateChanged;
                persistentTest.CollectorHost_AlertRaised_Warning += m_CollectorHost_AlertRaised_Warning;
                persistentTest.CollectorHost_AlertRaised_Error += m_CollectorHost_AlertRaised_Error;
                Application.DoEvents();

                persistentTest.RefreshStates(true);

                Application.DoEvents();
                StringBuilder alertSummary = new StringBuilder();
                foreach (CollectorHost ch in persistentTest.CollectorHosts)
                {
                    alertSummary.AppendLine(string.Format("\r\n\tCollector host: {0}\r\n\tState: {1}", ch.Name, ch.CurrentState.State));
                    List<string> alertsRaised = ch.CurrentState.AlertsRaised;
                    if (alertsRaised.Count > 0)
                    {
                        alertSummary.AppendLine("\tNotifiers:");
                        alertsRaised.ForEach(a => alertSummary.AppendLine("\t\t" + a));
                    }
                }
                AppendOutput(string.Format("{0}\r\nDuration: {1}ms\r\nResulting state: {2}\r\nAlert Info: {3}",
                        (new string('-', 80)),
                        persistentTest.LastRefreshDurationMS,
                        persistentTest.CurrentState,
                        alertSummary.ToString()));


                //MonitorState ms = persistentTest.CollectorHosts[0].CurrentState;

                //Application.DoEvents();
                //List<string> alertsRaised = ms.AlertsRaised;
                //StringBuilder alertSummary = new StringBuilder();
                //alertsRaised.ForEach(a => alertSummary.AppendLine(a));
                ////if (alertSummary.ToString().Length > 0)
                ////{
                ////    txtAlerts.Text += string.Format("\r\nAlerts raised\r\n{0}", alertSummary);
                ////    txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
                ////    txtAlerts.ScrollToCaret();

                ////    //MessageBox.Show("Alerts raised\r\n" + alertSummary.ToString(), "Alerts raised", MessageBoxButtons.OK, (ms.State == CollectorState.Error) ? MessageBoxIcon.Error : (ms.State == CollectorState.Warning) ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                ////}
                //AppendOutput(string.Format("Duration: {0}ms\r\nResulting state: {1}\r\nPrevious state: {2}\r\nAlert Info: {3}",
                //        ms.CallDurationMS,
                //        ms.State,
                //        persistentTest.CollectorHosts[0].PreviousState.State,
                //        alertSummary.ToString()));

                //txtAlerts.Text += string.Format("\r\nDuration: {0}ms\r\nResulting state: {1}\r\nPrevious state: {2}\r\nAlert Info: {3}",
                //        ms.CallDurationMS,
                //        ms.State,
                //        persistentTest.CollectorHosts[0].PreviousState.State,
                //        alertSummary.ToString());

                //if (persistentTest.CollectorHosts[0].StateHistory.Count > 0)
                //{
                //    txtAlerts.Text += string.Format("\r\nPrevious state: {0}", persistentTest.CollectorHosts[0].StateHistory.Last().State);
                //    txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
                //    txtAlerts.ScrollToCaret();
                //    //MessageBox.Show(string.Format("Previous state: {0}\r\nWait here for repeatAlertInXMin test", persistentTest.CollectorHosts[0].StateHistory.Last().State), "Previous", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                ////seconds time
                //ms = persistentTest.CollectorHosts[0].RefreshCurrentState();

                //Application.DoEvents();
                //alertsRaised = ms.AlertsRaised;
                //alertSummary = new StringBuilder();
                //alertsRaised.ForEach(a => alertSummary.AppendLine(a));
                //if (alertSummary.ToString().Length > 0)
                //    MessageBox.Show("Alerts raised\r\n" + alertSummary.ToString(), "Alerts raised", MessageBoxButtons.OK, (ms.State == CollectorState.Error) ? MessageBoxIcon.Error : (ms.State == CollectorState.Warning) ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                //if (persistentTest.CollectorHosts[0].StateHistory.Count > 0)
                //{
                //    MessageBox.Show(string.Format("Previous state: {0}", persistentTest.CollectorHosts[0].StateHistory.Last().State), "Previous", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (persistentTest.CollectorHosts.Count > 0)
            {
                
                //string newConfig = "<config>\r\n" +
                //                            "<entries>\r\n" +
                //                            "</entries>\r\n" +
                //                        "</config>";

                //if (txtHostName.Text.Trim().Length > 0)
                //{
                    
                //    string[] hostnames = txtHostName.Text.Split(',', ' ');
                //    foreach (string hostname in hostnames)
                //    {
                //        if (hostname.Trim().Length > 0)
                //            newConfig = newConfig.Replace("</entries>", "<entry pingMethod=\"Ping\" address=\"" + hostname.Trim() + "\" />\r\n</entries>");
                //    }
                //}

                txtAlerts.Text += "\r\n" + (new string('*', 80));
                persistentTest.ConcurrencyLevel = (int)nudConcurency.Value;

                foreach (CollectorHost ch in persistentTest.CollectorHosts)
                {
                    ch.AlertsPaused = chkPauseAlerts.Checked;
                }

                //persistentTest.CollectorHosts[0].CollectorAgents[0].AgentConfig.FromXml(newConfig);
                persistentTest.RefreshStates();
                Application.DoEvents();

                //MonitorState ms = persistentTest.CurrentState;

                StringBuilder alertSummary = new StringBuilder();
                foreach (CollectorHost ch in persistentTest.CollectorHosts)
                {
                    alertSummary.AppendLine(string.Format("\r\n\tCollector host: {0}\r\n\tState: {1}", ch.Name, ch.CurrentState.State));
                    List<string> alertsRaised = ch.CurrentState.AlertsRaised;
                    if (alertsRaised.Count > 0)
                    {
                        alertSummary.AppendLine("\tNotifiers:");
                        alertsRaised.ForEach(a => alertSummary.AppendLine("\t\t" + a));
                    }
                }
                AppendOutput(string.Format("{0}\r\nDuration: {1}ms\r\nResulting state: {2}\r\nAlert Info: {3}",
                        (new string('-', 80)),
                        persistentTest.LastRefreshDurationMS,
                        persistentTest.CurrentState,
                        alertSummary.ToString()));

                //txtAlerts.Text += string.Format("\r\n{0}\r\nDuration: {1}ms\r\nResulting state: {2}\r\nAlert Info: {3}",
                //        (new string('-', 80)),
                //        persistentTest.LastRefreshDurationMS,
                //        persistentTest.CurrentState,
                //        alertSummary.ToString());
                //txtAlerts.SelectionStart = txtAlerts.Text.Length - 1;
                //txtAlerts.ScrollToCaret();

                //MessageBox.Show(string.Format("Resulting state: {0}\r\nPrevious state: {1}\r\nAlert Info: {2}",
//                        ms.State,
                        //persistentTest.CollectorHosts[0].PreviousState.State,
//                        alertSummary.ToString()), "Result", MessageBoxButtons.OK,
                        //(ms.State == CollectorState.Error) ? MessageBoxIcon.Error : (ms.State == CollectorState.Warning) ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtAlerts.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!chkRemoteHost.Checked || txtHostName.Text.Trim().Length > 0)
            {

                string configXml = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars />\r\n" +
                        "<collectorHosts>\r\n";
                string[] hostnames = txtHostName.Text.Split(',', ' ');
                foreach (string hostname in hostnames)
                {
                    configXml += "<collectorHost uniqueId=\"Ping" + hostname.EscapeXml() + "\" name=\"Ping " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                        "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
                           "forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                           "<collectorAgents>\r\n" +
                                "<collectorAgent type=\"PingCollector\">\r\n" +
                                    "<config>\r\n" +
                                        "<entries>\r\n" +
                                            "<entry pingMethod=\"Ping\" address=\"" + hostname.EscapeXml() + "\" />\r\n" +
                                            "</entries>\r\n" +
                                    "</config>\r\n" +
                                "</collectorAgent>\r\n" +
                            "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n";

                    configXml += "<collectorHost uniqueId=\"Services" + hostname.EscapeXml() + "\" name=\"Services " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
                       "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                          "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
                          "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
                          "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                          "<collectorAgents>\r\n" +
                            "<collectorAgent type=\"WindowsServiceStateCollector\">\r\n" +
                                "<config>\r\n" +
                                    "<machine name=\"" + hostname.EscapeXml() + "\">\r\n" +
                                        "<service name=\"QuickMon 3 Service\" />\r\n" +
                                    "</machine>\r\n" +
                                "</config>\r\n" +
                            "</collectorAgent>\r\n" +
                          "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n";


                    configXml += "<collectorHost uniqueId=\"Perf" + hostname.EscapeXml() + "\" name=\"Perfs " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
                       "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                          "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
                          "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
                          "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                          "<collectorAgents>\r\n" +
                            "<collectorAgent name=\"CPU\" type=\"PerfCounterCollector\" enabled=\"True\">\r\n" +
                                "<config>\r\n" +
                                    "<performanceCounters>\r\n" +
                                        "<performanceCounter computer=\"" + hostname.EscapeXml() + "\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" returnValueInverted=\"False\" warningValue=\"90\" errorValue=\"99\" />\r\n" +
                                    "</performanceCounters>\r\n" +
                                "</config>\r\n" +
                            "</collectorAgent>\r\n" +
                            "<collectorAgent name=\"Memory\" type=\"PerfCounterCollector\" enabled=\"False\">\r\n" +
                                "<config>\r\n" +
                                    "<performanceCounters>\r\n" +
                                        "<performanceCounter computer=\"" + hostname.EscapeXml() + "\" category=\"Memory\" counter=\"% Committed Bytes In Use\" instance=\"\" returnValueInverted=\"False\" warningValue=\"80\" errorValue=\"90\" />\r\n" +
                                    "</performanceCounters>\r\n" +
                                "</config>\r\n" +
                            "</collectorAgent>\r\n" +
                          "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n";


                    configXml += "<collectorHost uniqueId=\"Folder" + hostname.EscapeXml() + "\" name=\"C drive " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
                       "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                          "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
                          "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
                          "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                          "<collectorAgents>\r\n" +
                            "<collectorAgent name=\"Does C drive exist\" type=\"FileSystemCollector\" enabled=\"True\">\r\n" +
                                "<config>\r\n" +
                                    "<directoryList>\r\n" +
                                        "<directory directoryPathFilter=\"\\\\" + hostname.EscapeXml() + "\\c$\\*.*\" testDirectoryExistOnly=\"True\" testFilesExistOnly=\"False\" " +
                                        "errorOnFilesExist=\"False\" warningFileCountMax=\"0\" errorFileCountMax=\"0\" warningFileSizeMaxKB=\"0\" errorFileSizeMaxKB=\"0\" " +
                                        "fileMinAgeSec=\"0\" fileMaxAgeSec=\"0\" fileMinSizeKB=\"0\" fileMaxSizeKB=\"0\" />\r\n" +
                                    "</directoryList>\r\n" +
                                "</config>\r\n" +
                            "</collectorAgent>\r\n" +
                          "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n";
                }
                configXml += "</collectorHosts>" +
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

                MonitorPack m = new MonitorPack();
                m.ConcurrencyLevel = 1;
                m.LoadXml(configXml);
                m.RefreshStates();
                txtAlerts.Text = "";
                foreach (CollectorHost ch in m.CollectorHosts)
                {
                    MonitorState ms = ch.CurrentState;
                    txtAlerts.Text += string.Format("Collector host: {0}\r\n", ch.Name);
                    txtAlerts.Text += string.Format("Run on host: {0}\r\n", ms.ExecutedOnHostComputer);
                    txtAlerts.Text += string.Format("State: {0}\r\n{1}\r\n", ms.State, XmlFormattingUtils.NormalizeXML(ms.ReadAllRawDetails('\t')));
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string configXml = "<collectorHosts>\r\n" +
                        "<collectorHost uniqueId=\"1234\" name=\"Services test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                        "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                           "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                           "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                           "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"rhenning\" remoteAgentHostPort=\"48181\" " +
                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" " +
                           "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                           "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                           "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                           "<collectorAgents>\r\n";
            if (txtHostName.Text.Trim().Length > 0)
            {
                string[] hostnames = txtHostName.Text.Split(',', ' ');
                foreach (string hostname in hostnames)
                {
                    configXml +=
                        "<collectorAgent type=\"WindowsServiceStateCollector\">\r\n" +
                            "<config>\r\n" +
                                "<machine name=\"" + hostname.EscapeXml() + "\">\r\n" +
                                    "<service name=\"QuickMon 3 Service\" />\r\n" +
                                "</machine>\r\n" +
                            "</config>\r\n" +
                        "</collectorAgent>\r\n";
                }
            }

            configXml +=
                           "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n" +
                    "</collectorHosts>";
            List<CollectorHost> chList = CollectorHost.GetCollectorHostsFromString(configXml);
            if (chList != null)
            {
                MonitorState ms = chList[0].RefreshCurrentState();
                MessageBox.Show(XmlFormattingUtils.NormalizeXML(ms.ToXml()), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string configXml = "<collectorHosts>\r\n" +
                        "<collectorHost uniqueId=\"1234\" name=\"PerfCounterCollector test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                        "agentCheckSequence=\"" + (chkFirstSuccess.Checked ? "FirstSuccess" : chkFirstError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                           "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                           "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                           "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"False\" " +
                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"rhenning-vm\" remoteAgentHostPort=\"48181\" " +
                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" " +
                           "enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" " +
                           "pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" " +
                           "pollSlideFrequencyAfterThirdRepeatSec=\"30\">\r\n" +
                           "<collectorAgents>\r\n";
            if (txtHostName.Text.Trim().Length > 0)
            {
                string[] hostnames = txtHostName.Text.Split(',', ' ');
                foreach (string hostname in hostnames)
                {
                    configXml +=
                        "<collectorAgent type=\"PerfCounterCollector\">\r\n" +
                            "<config>\r\n" +
                                "<performanceCounters>\r\n" +
                                    "<performanceCounter computer=\"" + hostname.EscapeXml() + "\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" returnValueInverted=\"False\" warningValue=\"90\" errorValue=\"99\" />\r\n" +
                                "</performanceCounters>\r\n" +
                            "</config>\r\n" +
                        "</collectorAgent>\r\n";
                }
            }

            configXml +=
                           "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n" +
                    "</collectorHosts>";
            List<CollectorHost> chList = CollectorHost.GetCollectorHostsFromString(configXml);
            if (chList != null)
            {
                MonitorState ms = chList[0].RefreshCurrentState();
                MessageBox.Show(string.Format("State: {0}\r\n{1}", ms.State, XmlFormattingUtils.NormalizeXML(ms.ReadAllRawDetails())), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
