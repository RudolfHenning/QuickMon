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
    public partial class TestCollectorHostEdit : Form
    {
        public TestCollectorHostEdit()
        {
            InitializeComponent();
        }

        private void TestCollectorHostEdit_Load(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine( System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "qm4editTest.qmp");
            if (System.IO.File.Exists(fileName))
                txtConfig.Text = System.IO.File.ReadAllText(fileName);
            else
                cmdRestore_Click(null,null);
        }

        #region Manual config edit context menu events
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.Paste();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.SelectAll();
        }
        #endregion

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConfig.Text = XmlFormattingUtils.NormalizeXML(txtConfig.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditCollectorHost editCollectorHost = new EditCollectorHost();
            editCollectorHost.SelectedConfig = txtConfig.Text;
            if (editCollectorHost.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtConfig.Text =  XmlFormattingUtils.NormalizeXML(editCollectorHost.SelectedConfig);
            }
        }

        private void cmdRestore_Click(object sender, EventArgs e)
        {
            txtConfig.Text = "<collectorHost uniqueId=\"Ping\" name=\"Ping Test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"C:\\Test\\FixWarning.cmd\" correctiveScriptOnErrorPath=\"C:\\Test\\FixError.cmd\" restorationScriptPath=\"C:\\Test\\GoodRestored.cmd\" correctiveScriptsOnlyOnStateChange=\"False\" enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"localhost\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" alertsPaused=\"False\">\r\n" +
                    "    <!-- CollectorAgents -->\r\n" +
                    "    <collectorAgents>\r\n" +
                    "        <collectorAgent name=\"Ping test 2\" type=\"PingCollector\" enabled=\"True\">\r\n" +
                    "            <config>\r\n" +
                    "                <entries>\r\n" +
                    "                    <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
                    "                    <entry pingMethod=\"Ping\" address=\"localhost2\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
                    "                </entries>\r\n" +
                    "            </config>\r\n" +
                    "        </collectorAgent>\r\n" +
                    "        <collectorAgent name=\"Ping test 3\" type=\"PingCollector\" enabled=\"True\">\r\n" +
                    "            <config>\r\n" +
                    "                <entries>\r\n" +
                    "                    <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
                    "                </entries>\r\n" +
                    "            </config>\r\n" +
                    "        </collectorAgent>\r\n" +
                    "        <collectorAgent name=\"Ping test\" type=\"PingCollector\" enabled=\"True\">\r\n" +
                    "            <config>\r\n" +
                    "                <entries>\r\n" +
                    "                    <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
                    "                </entries>\r\n" +
                    "            </config>\r\n" +
                    "        </collectorAgent>\r\n" +
                    "        <collectorAgent name=\"QuickMon 3 service\" type=\"WindowsServiceStateCollector\" enabled=\"True\">\r\n" +
                    "            <config>\r\n" +
                    "                <machine name=\"localhost\">\r\n" +
                    "                    <service name=\"QuickMon 3 Service\" />\r\n" +
                    "                </machine>\r\n" +
                    "            </config>\r\n" +
                    "        </collectorAgent>\r\n" +
                    "        <collectorAgent name=\"CPU load\" type=\"PerfCounterCollector\" enabled=\"True\">\r\n" +
                    "            <config>\r\n" +
                    "                    <performanceCounters>\r\n" +
                    "                        <performanceCounter computer=\"localhost\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" returnValueInverted=\"False\" warningValue=\"90\" errorValue=\"99\" />\r\n" +
                    "                    </performanceCounters>\r\n" +
                    "            </config>\r\n" +
                    "        </collectorAgent>\r\n" +
                    "        <collectorAgent name=\"Does C drive exist\" type=\"FileSystemCollector\" enabled=\"True\">\r\n" +
                    "            <config>\r\n" +
                    "                    <directoryList>\r\n" +
                    "                        <directory directoryPathFilter=\"\\\\localhost\\c$\\Test\\Test.txt\" testDirectoryExistOnly=\"False\" testFilesExistOnly=\"False\" " +
                    "                        errorOnFilesExist=\"True\" warningFileCountMax=\"2\" errorFileCountMax=\"3\" warningFileSizeMaxKB=\"0\" errorFileSizeMaxKB=\"0\" " +
                    "                        fileMinAgeMin=\"0\" fileMaxAgeMin=\"86400\" fileMinSizeKB=\"0\" fileMaxSizeKB=\"0\" />\r\n" +
                    "                    </directoryList>\r\n" +
                    "            </config>\r\n" +
                    "        </collectorAgent>\r\n" +
                    "    </collectorAgents>\r\n" +
                    "    <!-- ServiceWindows -->\r\n" +
                    "    <serviceWindows>\r\n" +
                    "    </serviceWindows>\r\n" +
                    "    <!-- Config variables -->\r\n" +
                    "    <configVars>\r\n" +
                    "        <configVar find=\"findme\" replace=\"you\" />\r\n" +
                    "        <configVar find=\"more\" replace=\"there\" />\r\n" +
                    "    </configVars>\r\n" +
                    "</collectorHost>";
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine( System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "qm4editTest.qmp");
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
            System.IO.File.WriteAllText(fileName, txtConfig.Text);
        }
    }
}
