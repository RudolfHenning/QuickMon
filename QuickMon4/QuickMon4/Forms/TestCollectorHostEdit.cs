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
"        <collectorAgent name=\"Ping test\" type=\"PingCollector\" enabled=\"True\">\r\n" +
"            <config>\r\n" +
"                <entries>\r\n" +
"                    <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1500\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
"                </entries>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"System health\" type=\"PerfCounterCollector\" enabled=\"True\">\r\n" +
"            <config>\r\n" +
"                <performanceCounters>\r\n" +
"                    <performanceCounter computer=\"localhost\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" warningValue=\"90\" errorValue=\"99\" />\r\n" +
"                    <performanceCounter computer=\"localhost\" category=\"Memory\" counter=\"% Committed Bytes In Use\" instance=\"\" warningValue=\"90\" errorValue=\"99\" />\r\n" +
"                    <performanceCounter computer=\"localhost\" category=\"LogicalDisk\" counter=\"% Free Space\" instance=\"C:\" warningValue=\"10\" errorValue=\"5\" />\r\n" +
"                    <performanceCounter computer=\"localhost\" category=\"Paging File\" counter=\"% Usage\" instance=\"_Total\" warningValue=\"50\" errorValue=\"80\" />\r\n" +
"                    <performanceCounter computer=\"localhost\" category=\"LogicalDisk\" counter=\"Current Disk Queue Length\" instance=\"_Total\" warningValue=\"50\" errorValue=\"80\" />\r\n" +
"                </performanceCounters>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"File Tests\" type=\"FileSystemCollector\" enabled=\"True\">\r\n" +
"            <config>\r\n" +
"                <directoryList>\r\n" +
"                    <directory directoryPathFilter=\"\\\\localhost\\c$\\Test\\Test*.txt\" testDirectoryExistOnly=\"False\" testFilesExistOnly=\"False\" errorOnFilesExist=\"False\" containsText=\"\" useRegEx=\"False\" warningFileCountMax=\"1\" errorFileCountMax=\"0\" fileSizeIndicatorUnit=\"KB\" warningFileSizeMax=\"0\" errorFileSizeMax=\"0\" fileAgeUnit=\"Day\" fileMinAge=\"0\" fileMaxAge=\"10\" fileSizeUnit=\"KB\" fileMinSize=\"0\" fileMaxSize=\"0\" showFilenamesInDetails=\"True\" />\r\n" +
"                </directoryList>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"QuickMon 3 service\" type=\"WindowsServiceStateCollector\" enabled=\"True\">\r\n" +
"            <config>\r\n" +
"                <machine name=\"localhost\">\r\n" +
"                    <service name=\"Event Reaper - Piet Pompies\" />\r\n" +
"                    <service name=\"QuickMon 3 Service\" />\r\n" +
"                </machine>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"Errors in Eventlog\" type=\"EventLogCollector\" enabled=\"True\">\r\n" +
"            <config>\r\n" +
"                <eventlogs>\r\n" +
"                    <log computer=\"localhost\" eventLog=\"Application\" typeInfo=\"False\" typeWarn=\"True\" typeErr=\"True\" containsText=\"False\" useRegEx=\"False\" textFilter=\"\" withInLastXEntries=\"100\" withInLastXMinutes=\"1440\" warningValue=\"10\" errorValue=\"50\">\r\n" +
"                        <sources />\r\n" +
"                        <eventIds />\r\n" +
"                    </log>\r\n" +
"                </eventlogs>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"WMI Test\" type=\"WMIQueryCollector\" enabled=\"True\">\r\n" +
"            <config>\r\n" +
"                <wmiQueries>\r\n" +
"                    <wmiQuery name=\"Check C drive space\" namespace=\"root\\CIMV2\" machineName=\".\">\r\n" +
"                        <stateQuery syntax=\"SELECT FreeSpace FROM Win32_LogicalDisk where Caption = 'C:'\" returnValueIsInt=\"True\" returnValueInverted=\"True\" warningValue=\"1048576000\" errorValue=\"524288000\" successValue=\"[any]\" useRowCountAsValue=\"False\" />\r\n" +
"                        <detailQuery syntax=\"SELECT Caption, Size, FreeSpace, Description FROM Win32_LogicalDisk where Caption = 'C:'\" columnNames=\"Caption, Size, FreeSpace, Description\" />\r\n" +
"                    </wmiQuery>\r\n" +
"                    <wmiQuery name=\"Memory test\" namespace=\"root\\cimv2\" machineName=\".\">\r\n" +
"                        <stateQuery syntax=\"select TotalPhysicalMemory from Win32_ComputerSystem\" returnValueIsInt=\"True\" returnValueInverted=\"True\" warningValue=\"8000000000\" errorValue=\"4000000000\" successValue=\"[any]\" useRowCountAsValue=\"False\" />\r\n" +
"                        <detailQuery syntax=\"select TotalPhysicalMemory from Win32_ComputerSystem\" columnNames=\"TotalPhysicalMemory\" />\r\n" +
"                    </wmiQuery>\r\n" +
"                </wmiQueries>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"Registry Test\" type=\"RegistryQueryCollector\" enabled=\"True\">\r\n" +
"            <config>\r\n" +
"                <queries>\r\n" +
"                    <query name=\"Reg me\" useRemoteServer=\"False\" server=\"\" registryHive=\"LocalMachine\" path=\"SOFTWARE\\7-Zip\" keyName=\"Path\" expandEnvironmentNames=\"False\" returnValueIsNumber=\"False\" successValue=\"C:\\Program Files\\7-Zip\\\" warningValue=\"[any]\" errorValue=\"[null]\" returnValueInARange=\"False\" returnValueInverted=\"False\" />\r\n" +
"                </queries>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"Ping test 2\" type=\"PingCollector\" enabled=\"False\">\r\n" +
"            <config>\r\n" +
"                <entries>\r\n" +
"                    <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
"                    <entry pingMethod=\"Ping\" address=\"localhost2\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
"                </entries>\r\n" +
"            </config>\r\n" +
"        </collectorAgent>\r\n" +
"        <collectorAgent name=\"Ping test 3\" type=\"PingCollector\" enabled=\"False\">\r\n" +
"            <config>\r\n" +
"                <entries>\r\n" +
"                    <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />\r\n" +
"                </entries>\r\n" +
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

        private void cmdTest_Click(object sender, EventArgs e)
        {
            string configXml = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                        "defaultNotifier=\"Default notifiers\" runCorrectiveScripts=\"True\" " +
                        "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                        "<configVars />\r\n" +
                        "<collectorHosts>\r\n";
            configXml += txtConfig.Text;
            configXml += "</collectorHosts>" +
                         "<notifierHosts>\r\n" +

                         "<notifierHost name=\"AudioNotifier\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" " +
                               "attendedOptionOverride=\"OnlyAttended\">\r\n" +
                               "<notifierAgents>\r\n" +
                                   "<notifierAgent type=\"AudioNotifier\">\r\n" +
                                        "<config>\r\n" +
                                          "<audioConfig>\r\n" +
                                            "<goodState enabled=\"false\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"1\" soundRepeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                                            "<warningState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"3\" soundRepeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                                            "<errorState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"2\" soundRepeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                                          "</audioConfig>\r\n" +
                                        "</config>\r\n" +
                                   "</notifierAgent>\r\n" +
                               "</notifierAgents>\r\n" +
                           "</notifierHost>\r\n" +

                         "</notifierHosts>\r\n" +
                         "</monitorPack>";

            MonitorPack m = new MonitorPack();
            m.LoadXml(configXml);
            m.RefreshStates();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Global state: {0}", m.CurrentState));
            sb.AppendLine(new string('*', 30));
            foreach (CollectorHost ch in m.CollectorHosts)
            {
                MonitorState ms = ch.CurrentState;
                sb.AppendLine(string.Format("Collector host: {0}", ch.Name));
                sb.AppendLine(string.Format("Time: {0}", ms.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")));
                sb.AppendLine(string.Format("Duration: {0}ms", ms.CallDurationMS));
                sb.AppendLine(string.Format("Run on host: {0}", ms.ExecutedOnHostComputer));
                sb.AppendLine(string.Format("State: {0}", ms.State));
                sb.AppendLine("DETAILS (agents)");
                sb.AppendLine(string.Format("{0}",XmlFormattingUtils.NormalizeXML(ms.ReadAllRawDetails())));
                //sb.AppendLine(string.Format("\t\tState: {0}\r\n{1}", ms.State, XmlFormattingUtils.NormalizeXML(ms.ReadAllRawDetails('\t', 3))));
                sb.AppendLine(new string('*', 30));

            }
            MessageBox.Show(sb.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
