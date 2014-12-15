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
    public partial class TestRun2Notifiers : Form
    {
        public TestRun2Notifiers()
        {
            InitializeComponent();
        }

        private void cmdRunTest_Click(object sender, EventArgs e)
        {
            string configXml = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars />\r\n" +
                        "<collectorHosts>\r\n";

            configXml += "<collectorHost uniqueId=\"PingNowhere\" name=\"Ping Nowhere\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                        "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "enableRemoteExecute=\"False\" " +
                           "forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" " +
                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                           "<collectorAgents>\r\n" +
                                "<collectorAgent type=\"PingCollector\">\r\n" +
                                    "<config>\r\n" +
                                        "<entries>\r\n" +
                                            "<entry pingMethod=\"Ping\" address=\"NowhereSpecific\" />\r\n" +
                                            "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
                                        "</entries>\r\n" +
                                    "</config>\r\n" +
                                "</collectorAgent>\r\n" +
                            "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n";

            configXml += "</collectorHosts>" +
                            "<notifierHosts>\r\n";

            if (chkEventLog.Checked)
            {
                configXml += "<notifierHost name=\"EventLogNotifier\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" " +
                               "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                               "<notifierAgents>\r\n" +
                                   "<notifierAgent type=\"EventLogNotifier\">\r\n" +
                                        "<config><eventLog computer=\".\" eventSource=\"QuickMon4\" successEventID=\"0\" warningEventID=\"1\" errorEventID=\"2\" /></config>\r\n" +
                                   "</notifierAgent>\r\n" +
                               "</notifierAgents>\r\n" +
                           "</notifierHost>\r\n";
            }
            if (chkLogFile.Checked)
            {
                configXml += "<notifierHost name=\"Log file\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                    "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                    "<notifierAgents>\r\n" +
                        "<notifierAgent type=\"LogFileNotifier\">\r\n" +
                            "<config><logFile path=\"" + txtLogFile.Text + "\" createNewFileSizeKB=\"0\" /></config>\r\n" +
                        "</notifierAgent>\r\n" +
                    "</notifierAgents>\r\n" +
                "</notifierHost>\r\n";
            }
            if (chkSMTP.Checked)
            {
                configXml += "<notifierHost name=\"Email\" enabled=\"True\" alertLevel=\"Info\" detailLevel=\"Detail\" " +
                    "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                    "<notifierAgents>\r\n" +
                        "<notifierAgent name=\"Email\" type=\"SMTPNotifier\">\r\n" +
                                        "<config>\r\n" +
                                            "<smtp hostServer=\"" + txtSMTPServer.Text + "\" useDefaultCredentials=\"True\" domain=\"\" userName=\"\" password=\"\" " +
                                            "fromAddress=\"" + txtEmailAddress.Text + "\" toAddress=\"" + txtEmailAddress.Text + "\" senderAddress=\"" + txtEmailAddress.Text + "\" replyToAddress=\"" + txtEmailAddress.Text + "\" mailPriority=\"0\" useTLS=\"False\" isBodyHtml=\"True\" port=\"25\" subject=\"QuickMon %AlertLevel% - %CollectorName%\" body=\"QuickMon alert raised for &lt;b&gt;'%CollectorName%'&lt;/b&gt;&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Date Time:&lt;/b&gt; %DateTime%&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Current state:&lt;/b&gt; %CurrentState%&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Agents:&lt;/b&gt; %CollectorAgents%&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Details&lt;/b&gt;&lt;blockquote&gt;%Details%&lt;/blockquote&gt;\" />\r\n" +
                                        "</config>\r\n" +
                                    "</notifierAgent>\r\n" +
                    "</notifierAgents>\r\n" +
                "</notifierHost>\r\n";
            }
            configXml += "</notifierHosts>\r\n" +
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
                txtAlerts.Text += "Alerts\r\n";
                foreach (string alert in ms.AlertsRaised)
                {
                    txtAlerts.Text += "\t" + alert;
                }
            }

        }
    }
}
