using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class TestRun1 : Form
    {
        public TestRun1()
        {
            InitializeComponent();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtAlerts.Text = "";
        }

        private void cmdRunTest_Click(object sender, EventArgs e)
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
                        "agentCheckSequence=\"" + (opt1stSuccess.Checked ? "FirstSuccess" : opt1stError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
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

                    if (chkServices.Checked)
                    {
                        configXml += "<collectorHost uniqueId=\"Services" + hostname.EscapeXml() + "\" name=\"Services " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
                           "agentCheckSequence=\"" + (opt1stSuccess.Checked ? "FirstSuccess" : opt1stError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
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
                    }

                    if (chkPerfCounters.Checked)
                    {
                        configXml += "<collectorHost uniqueId=\"Perf" + hostname.EscapeXml() + "\" name=\"Perfs " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
                           "agentCheckSequence=\"" + (opt1stSuccess.Checked ? "FirstSuccess" : opt1stError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
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
                    }

                    if (chkFileFolder.Checked)
                    {
                        configXml += "<collectorHost uniqueId=\"Folder" + hostname.EscapeXml() + "\" name=\"C drive " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
                           "agentCheckSequence=\"" + (opt1stSuccess.Checked ? "FirstSuccess" : opt1stError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                              "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
                              "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
                              "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                              "<collectorAgents>\r\n" +
                                "<collectorAgent name=\"Does C drive exist\" type=\"FileSystemCollector\" enabled=\"True\">\r\n" +
                                    "<config>\r\n" +
                                        "<directoryList>\r\n" +
                                            "<directory directoryPathFilter=\"\\\\" + hostname.EscapeXml() + "\\c$\\Test\\Test.txt\" testDirectoryExistOnly=\"False\" testFilesExistOnly=\"False\" " +
                                            "errorOnFilesExist=\"True\" warningFileCountMax=\"2\" errorFileCountMax=\"3\" warningFileSizeMaxKB=\"0\" errorFileSizeMaxKB=\"0\" " +
                                            "fileMinAgeMin=\"0\" fileMaxAgeMin=\"86400\" fileMinSizeKB=\"0\" fileMaxSizeKB=\"0\" />\r\n" +
                                        "</directoryList>\r\n" +
                                    "</config>\r\n" +
                                "</collectorAgent>\r\n" +
                              "</collectorAgents>\r\n" +
                            "</collectorHost>\r\n";
                    }

                    if (chkEventLog.Checked)
                    {
                        configXml += "<collectorHost uniqueId=\"EventLog" + hostname.EscapeXml() + "\" name=\"Application Eventlog " + hostname.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"Ping" + hostname.EscapeXml() + "\" " +
                           "agentCheckSequence=\"" + (opt1stSuccess.Checked ? "FirstSuccess" : opt1stError.Checked ? "FirstError" : "All") + "\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                              "enableRemoteExecute=\"" + (chkRemoteHost.Checked ? "True" : "False") + "\" " +
                              "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"" + txtRemoteHost.Text.EscapeXml() + "\" remoteAgentHostPort=\"48181\" " +
                              "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                              "<collectorAgents>\r\n" +
                                "<collectorAgent name=\"Errors in Evewntlog\" type=\"EventLogCollector\" enabled=\"True\">\r\n" +
                                    "<config>\r\n" +
                                        "<eventlogs>\r\n" +
                                            "<log computer=\"" + hostname.EscapeXml() + "\" eventLog=\"Application\" typeInfo=\"False\" typeWarn=\"True\" typeErr=\"True\" containsText=\"False\" textFilter=\"\" " +
                                                "withInLastXEntries=\"100\" withInLastXMinutes=\"1440\" warningValue=\"1\" errorValue=\"50\">\r\n" +
                                                "<sources />\r\n" +
                                                "<eventIds />\r\n" +
                                             "</log>\r\n" +
                                        "</eventlogs>\r\n" +
                                    "</config>\r\n" +
                                "</collectorAgent>\r\n" +
                              "</collectorAgents>\r\n" +
                            "</collectorHost>\r\n";
                    }
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
                m.ConcurrencyLevel = (int)nudConcurency.Value;
                m.LoadXml(configXml);
                m.RefreshStates();
                txtAlerts.Text = "";
                foreach (CollectorHost ch in m.CollectorHosts)
                {
                    MonitorState ms = ch.CurrentState;
                    txtAlerts.Text += string.Format("Collector host: {0}\r\n", ch.Name);
                    txtAlerts.Text += string.Format("Time: {0}\r\n", ms.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    txtAlerts.Text += string.Format("Duration: {0}ms\r\n", ms.CallDurationMS);
                    txtAlerts.Text += string.Format("Run on host: {0}\r\n", ms.ExecutedOnHostComputer);
                    txtAlerts.Text += string.Format("State: {0}\r\n{1}\r\n", ms.State, XmlFormattingUtils.NormalizeXML(ms.ReadAllRawDetails('\t')));
                }
            }
        }
    }
}
