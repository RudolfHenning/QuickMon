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
                        "defaultNotifier=\"In Memory\" runCorrectiveScripts=\"True\" " +
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
                        "<notifierHosts />\r\n" +
                       "</monitorPack>";
                m.LoadXml(mconfig);

                MessageBox.Show(string.Format("Initial: {0}", m.CollectorHosts[0].CollectorAgents[0].InitialConfiguration), "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(string.Format("Active: {0}", m.CollectorHosts[0].CollectorAgents[0].ActiveConfiguration), "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show(string.Format("Ping status: {0}",  m.CollectorHosts[0].CollectorAgents[0].GetState().State), "Ping me", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
