using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMon
{
    [TestClass]
    public class MonitorPackUnitTests
    {
        [TestMethod, TestCategory("MonitorPack-IOTest")]
        public void CreateBlankMonitorPack()
        {
            try
            {
                MonitorPack m = new MonitorPack();
                Assert.IsNotNull(m, "Success");
            }
            catch (Exception ex)
            {
                Assert.Fail("Could not create monitorpack:" + ex.ToString());
            }
        }
        [TestMethod, TestCategory("MonitorPack-IOTest")]
        public void LoadBlankMonitorPack()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"Test\" enabled=\"True\" pollingFreqSecOverride=\"60\" >" +
                "<configVars />" +
                "<collectorHosts />" +
                "<notifierHosts />" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                Assert.AreEqual("Test", m.Name, "Name is not set");
                Assert.AreEqual("5.0.0", m.Version, "Version is not set");
                Assert.AreEqual("Test", m.TypeName, "Type is not set");
                Assert.AreEqual("true", m.Enabled.ToString().ToLower(), "Enabled is not set");
                Assert.AreEqual("true", m.CorrectiveScriptsEnabled.ToString().ToLower(), "CorrectiveScriptsEnabled is not set");
                Assert.AreEqual(100, m.CollectorStateHistorySize, string.Format("CollectorStateHistorySize is not set: {0}", m.CollectorStateHistorySize));
                Assert.AreEqual(60, m.PollingFrequencyOverrideSec, string.Format("PollingFrequencyOverrideSec is not set: {0}", m.PollingFrequencyOverrideSec));
                Assert.IsNotNull(m.ConfigVariables, "ConfigVariables is null");
                if (m.ConfigVariables != null)
                    Assert.AreEqual(0, m.ConfigVariables.Count, "ConfigVariables count should be 0");
                Assert.IsNotNull(m.CollectorHosts, "CollectorHosts is null");
                if (m.CollectorHosts != null)
                    Assert.AreEqual(0, m.CollectorHosts.Count, "CollectorHosts count should be 0");
                Assert.IsNotNull(m.NotifierHosts, "NotifierHosts is null");
                if (m.NotifierHosts != null)
                    Assert.AreEqual(0, m.NotifierHosts.Count, "NotifierHosts count should be 0");
            }
        }
        [TestMethod, TestCategory("MonitorPack-IOTest")]
        public void SaveAndLoadBlankMonitorPack()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"101\" pollingFreqSecOverride=\"12\">\r\n" +
                "<configVars />" +
                "<collectorHosts />" +
                "<notifierHosts>\r\n" +
                        "<notifierHost name=\"Default notifiers\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" " +
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
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                string outputFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon5SaveTest.qmp");
                if (System.IO.File.Exists(outputFileName))
                    System.IO.File.Delete(outputFileName);
                m.Save(outputFileName);
                Assert.AreEqual("Test", m.Name, "Name is not set");
                Assert.AreEqual(true, System.IO.File.Exists(outputFileName));
                Assert.AreEqual("5.0.0", m.Version, "Version is not set");
                Assert.AreEqual("TestType", m.TypeName, "Type is not set");
                Assert.AreEqual(true, m.Enabled, "Enabled is not set");
                Assert.AreEqual(true, m.CorrectiveScriptsEnabled, "CorrectiveScriptsEnabled is not set");
                Assert.AreEqual(101, m.CollectorStateHistorySize, string.Format("CollectorStateHistorySize is not set: {0}", m.CollectorStateHistorySize));
                Assert.AreEqual(12, m.PollingFrequencyOverrideSec, string.Format("PollingFrequencyOverrideSec is not set: {0}", m.PollingFrequencyOverrideSec));
                Assert.IsNotNull(m.ConfigVariables, "ConfigVariables is null");
                if (m.ConfigVariables != null)
                    Assert.AreEqual(0, m.ConfigVariables.Count, "ConfigVariables count should be 0");
                Assert.IsNotNull(m.CollectorHosts, "CollectorHosts is null");
                if (m.CollectorHosts != null)
                    Assert.AreEqual(0, m.CollectorHosts.Count, "CollectorHosts count should be 0");
                Assert.IsNotNull(m.NotifierHosts, "NotifierHosts is null");
                if (m.NotifierHosts != null)
                    Assert.AreEqual(1, m.NotifierHosts.Count, "NotifierHosts count should be 1");

                m.Name = "Deliberately change name";
                m.Load(outputFileName);
                Assert.AreEqual("Test", m.Name, "Name is not set (2nd test)");
                Assert.AreEqual(true, System.IO.File.Exists(outputFileName));
                Assert.AreEqual("TestType", m.TypeName, "Type is not set (2nd test)");
                Assert.AreEqual(true, m.Enabled, "Enabled is not set (2nd test)");
                Assert.AreEqual(true, m.CorrectiveScriptsEnabled, "CorrectiveScriptsEnabled is not set (2nd test)");
                Assert.AreEqual(101, m.CollectorStateHistorySize, string.Format("CollectorStateHistorySize is not set: {0} (2nd test)", m.CollectorStateHistorySize));
                Assert.AreEqual(12, m.PollingFrequencyOverrideSec, string.Format("PollingFrequencyOverrideSec is not set: {0} (2nd test)", m.PollingFrequencyOverrideSec));
                Assert.IsNotNull(m.ConfigVariables, "ConfigVariables is null (2nd test)");
                if (m.ConfigVariables != null)
                    Assert.AreEqual(0, m.ConfigVariables.Count, "ConfigVariables count should be 0 (2nd test)");
                Assert.IsNotNull(m.CollectorHosts, "CollectorHosts is null (2nd test)");
                if (m.CollectorHosts != null)
                    Assert.AreEqual(0, m.CollectorHosts.Count, "CollectorHosts count should be 0 (2nd test)");
                Assert.IsNotNull(m.NotifierHosts, "NotifierHosts is null (2nd test)");
                if (m.NotifierHosts != null)
                    Assert.AreEqual(1, m.NotifierHosts.Count, "NotifierHosts count should be 1 (2nd test)");
            }
        }
        [TestMethod, TestCategory("MonitorPack-IOTest")]
        public void ConfigVarsLoadTest()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"60\">\r\n" +
                "<configVars>" +
                    "<configVar find=\"One value\" replace=\"Another value\" />" +
                 "</configVars>" +
                "<collectorHosts />" +
                "<notifierHosts />" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                Assert.IsNotNull(m.ConfigVariables, "ConfigVariables is null");
                if (m.ConfigVariables != null)
                {
                    Assert.AreEqual(1, m.ConfigVariables.Count, "ConfigVariables count should be 1");
                    if (m.ConfigVariables.Count == 1)
                    {
                        Assert.AreEqual("One value", m.ConfigVariables[0].FindValue, "ConfigVariable name not set");
                        Assert.AreEqual("Another value", m.ConfigVariables[0].ReplaceValue, "ConfigVariable value not set");
                    }
                }
            }
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void PingCollectorTest()
        {
            string mconfig = "<monitorPack><configVars></configVars>" +
                "<collectorHosts>" +
                "   <collectorHost uniqueId=\"123\" dependOnParentId=\"\" name=\"Ping\" enabled=\"True\" expandOnStart=\"Auto\" " +
                " childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                "     <collectorAgents agentCheckSequence=\"All\">" +
                "         <collectorAgent name=\"Ping localhost\" type=\"QuickMon.Collectors.PingCollector\" enabled=\"True\">" +
                "                <config>" +
                "                    <entries>" +
                "                        <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                "                    </entries>" +
                "                </config>" +
                "         </collectorAgent>" +
                "     </collectorAgents>" +
                "   </collectorHost>" +
                "</collectorHosts>" +
                "<notifierHosts></notifierHosts>" +
                "<logging><collectorCategories/></logging></monitorPack>";
            MonitorPack m = new MonitorPack();
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector host is expected");
                if (m.CollectorHosts.Count == 1)
                {
                    Assert.AreEqual("Ping", m.CollectorHosts[0].Name, "Collector host name not set");
                    Assert.AreEqual("123", m.CollectorHosts[0].UniqueId, "Collector host UniqueId not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].Enabled, "Collector host Enabled property not set");
                    Assert.AreEqual(ExpandOnStartOption.Auto, m.CollectorHosts[0].ExpandOnStartOption, "Collector host ExpandOnStart property not set");
                    Assert.AreEqual("", m.CollectorHosts[0].ParentCollectorId, "Collector host ParentCollectorId property not set");
                    Assert.AreEqual(AgentCheckSequence.All, m.CollectorHosts[0].AgentCheckSequence, "Collector host AgentCheckSequence property not set");
                    Assert.AreEqual(ChildCheckBehaviour.OnlyRunOnSuccess, m.CollectorHosts[0].ChildCheckBehaviour, "Collector host ChildCheckBehaviour property not set");

                    CollectorState cs = m.RefreshStates();

                    Assert.AreEqual(CollectorState.Good, cs, "Ping failed");

                    string outputFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon4SaveTest.qmp5");
                    if (System.IO.File.Exists(outputFileName))
                        System.IO.File.Delete(outputFileName);
                    m.Save(outputFileName);
                    m.Load(outputFileName);
                    Assert.AreEqual(CollectorState.Good, cs, "Ping failed");

                    //Assert.AreEqual(1, m.CollectorHosts[0].RepeatAlertInXMin, "Collector host RepeatAlertInXMin property not set");
                    //Assert.AreEqual(1, m.CollectorHosts[0].AlertOnceInXMin, "Collector host AlertOnceInXMin property not set");
                    //Assert.AreEqual(1, m.CollectorHosts[0].DelayErrWarnAlertForXSec, "Collector host DelayErrWarnAlertForXSec property not set");
                    //Assert.AreEqual(1, m.CollectorHosts[0].RepeatAlertInXPolls, "Collector host RepeatAlertInXPolls property not set");
                    //Assert.AreEqual(1, m.CollectorHosts[0].AlertOnceInXPolls, "Collector host AlertOnceInXPolls property not set");
                    //Assert.AreEqual(1, m.CollectorHosts[0].DelayErrWarnAlertForXPolls, "Collector host DelayErrWarnAlertForXPolls property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].CorrectiveScriptDisabled, "Collector host CorrectiveScriptDisabled property not set");
                    //Assert.AreEqual("test", m.CollectorHosts[0].CorrectiveScriptOnWarningPath, "Collector host CorrectiveScriptOnWarningPath property not set");
                    //Assert.AreEqual("test", m.CollectorHosts[0].CorrectiveScriptOnErrorPath, "Collector host CorrectiveScriptOnErrorPath property not set");
                    //Assert.AreEqual("test", m.CollectorHosts[0].RestorationScriptPath, "Collector host RestorationScriptPath property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].CorrectiveScriptsOnlyOnStateChange, "Collector host CorrectiveScriptsOnlyOnStateChange property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].EnableRemoteExecute, "Collector host EnableRemoteExecute property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].ForceRemoteExcuteOnChildCollectors, "Collector host ForceRemoteExcuteOnChildCollectors property not set");
                    //Assert.AreEqual("test", m.CollectorHosts[0].RemoteAgentHostAddress, "Collector host RemoteAgentHostAddress property not set");
                    //Assert.AreEqual(48182, m.CollectorHosts[0].RemoteAgentHostPort, "Collector host RemoteAgentHostPort property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].BlockParentOverrideRemoteAgentHostSettings, "Collector host BlockParentOverrideRemoteAgentHostSettings property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].RunLocalOnRemoteHostConnectionFailure, "Collector host RunLocalOnRemoteHostConnectionFailure property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].EnabledPollingOverride, "Collector host EnabledPollingOverride property not set");
                    //Assert.AreEqual(2, m.CollectorHosts[0].OnlyAllowUpdateOncePerXSec, "Collector host OnlyAllowUpdateOncePerXSec property not set");
                    //Assert.AreEqual(true, m.CollectorHosts[0].EnablePollFrequencySliding, "Collector host EnablePollFrequencySliding property not set");
                    //Assert.AreEqual(3, m.CollectorHosts[0].PollSlideFrequencyAfterFirstRepeatSec, "Collector host PollSlideFrequencyAfterFirstRepeatSec property not set");
                    //Assert.AreEqual(6, m.CollectorHosts[0].PollSlideFrequencyAfterSecondRepeatSec, "Collector host PollSlideFrequencyAfterSecondRepeatSec property not set");
                    //Assert.AreEqual(31, m.CollectorHosts[0].PollSlideFrequencyAfterThirdRepeatSec, "Collector host PollSlideFrequencyAfterThirdRepeatSec property not set");
                }
            }
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void PerformanceCounterCollectorTest()
        {
            string mconfig = "<monitorPack><configVars></configVars>" +
                "<collectorHosts>" +
                "   <collectorHost uniqueId=\"123\" dependOnParentId=\"\" name=\"PerfCounters\" enabled=\"True\" expandOnStart=\"Auto\" " +
                " childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                "     <collectorAgents agentCheckSequence=\"All\">" +
                "         <collectorAgent name=\"Ping localhost\" type=\"QuickMon.Collectors.PerfCounterCollector\" enabled=\"True\">" +
                "                <config>" +
                "                     <performanceCounters>" +
                "                           <performanceCounter computer=\".\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" warningValue=\"90\" errorValue=\"95\" numberOfSamples=\"3\" multiSampleWaitMS=\"100\" />" +
                "                     </performanceCounters>" +
                "                </config>" +
                "         </collectorAgent>" +
                "     </collectorAgents>" +
                "   </collectorHost>" +
                "</collectorHosts>" +
                "<notifierHosts></notifierHosts>" +
                "<logging><collectorCategories/></logging></monitorPack>";
            MonitorPack m = new MonitorPack();
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector host is expected");
                if (m.CollectorHosts.Count == 1)
                {
                    Assert.AreEqual("PerfCounters", m.CollectorHosts[0].Name, "Collector host name not set");
                    Assert.AreEqual("123", m.CollectorHosts[0].UniqueId, "Collector host UniqueId not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].Enabled, "Collector host Enabled property not set");
                    
                    CollectorState cs = m.RefreshStates();

                    Assert.AreNotEqual(CollectorState.ConfigurationChanged, cs, "Configuration wrong!");                    
                }
            }
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void PowerShellCollectorTest()
        {
            if (!System.IO.Directory.Exists("C:\\Test"))
            {
                System.IO.Directory.CreateDirectory("C:\\Test");
            }
            string mconfig = "<monitorPack lastChanged=\"2017-1-1\">" +
                "<configVars><configVar find=\"%Name%\" replace=\"Test Name\" /></configVars>" +
                "<collectorHosts>" +
                "   <collectorHost uniqueId=\"123\" dependOnParentId=\"\" name=\"PowerShell\" enabled=\"True\" expandOnStart=\"Auto\" " +
                "     childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                "     <collectorAgents agentCheckSequence=\"All\">" +
                "         <collectorAgent name=\"PowerShell\" type=\"PowerShellScriptRunnerCollector\" enabled=\"True\">" +


                //"                <config><carvcesEntries><carvceEntry name=\"Win Dir\"><dataSource>(Get-Item -Path C:\\Windows).Exists</dataSource><testConditions testSequence=\"GWE\"><success testType=\"Contains\">True</success><warning testType=\"Contains\">[null]</warning><error testType=\"Contains\">False</error></testConditions></carvceEntry><carvceEntry name=\"Win Dir\"><dataSource>(Get-Item -Path C:\\Windows).Exists</dataSource><testConditions testSequence=\"GWE\"><success testType=\"Contains\">True</success><warning testType=\"Contains\">[null]</warning><error testType=\"Contains\">False</error></testConditions></carvceEntry></carvcesEntries></config>" +

                
                "                <config>" +
                "                    <powerShellScripts>" +
                "                         <powerShellScriptRunner name = \"Win Dir %Name%\" returnCheckSequence=\"GWE\" >" +
                "                                <testScript>(Get-Item -Path C:\\Windows\\System32).Exists</testScript>" +
                "                                <goodScript resultMatchType=\"Contains\">True</goodScript>" +
                "                                <warningScript resultMatchType=\"Contains\">[null]</warningScript>" +
                "                                <errorScript resultMatchType=\"Contains\">False</errorScript>" +
                "                         </powerShellScriptRunner>" +
                "                    </powerShellScripts>" +

                "                    <carvcesEntries>" +
                "                         <carvceEntry name = \"Win Dir\">" +
                "                                <dataSource>(Get-Item -Path C:\\Windows).Exists</dataSource>" +
                "                                <testConditions testSequence=\"GWE\" >" +
                "                                   <success testType=\"Contains\">True</success>" +
                "                                   <warning testType=\"Contains\">[null]</warning>" +
                "                                   <error testType=\"Contains\">False</error>" +
                "                                </testConditions>" +
                "                         </carvceEntry>" +
                "                    </carvcesEntries>" +

                "                </config>" +
                

                "         </collectorAgent>" +
                "     </collectorAgents>" +
                "   </collectorHost>" +
                "</collectorHosts>" +
                "<notifierHosts></notifierHosts>" +
                "<logging><collectorCategories/></logging></monitorPack>";
            MonitorPack m = new MonitorPack();
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            Assert.AreEqual("", m.LastMPLoadError, "There are load errors");
            if (m != null)
            {
                Assert.AreEqual(new DateTime(2017,1,1), m.LastChangeDate, "Last changed date wrong!");
                Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector host is expected");
                if (m.CollectorHosts.Count == 1)
                {
                    Assert.AreEqual("PowerShell", m.CollectorHosts[0].Name, "Collector host name not set");
                    Assert.AreEqual("123", m.CollectorHosts[0].UniqueId, "Collector host UniqueId not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].Enabled, "Collector host Enabled property not set");
                    Assert.AreEqual(ExpandOnStartOption.Auto, m.CollectorHosts[0].ExpandOnStartOption, "Collector host ExpandOnStart property not set");
                    Assert.AreEqual("", m.CollectorHosts[0].ParentCollectorId, "Collector host ParentCollectorId property not set");
                    Assert.AreEqual(AgentCheckSequence.All, m.CollectorHosts[0].AgentCheckSequence, "Collector host AgentCheckSequence property not set");
                    Assert.AreEqual(ChildCheckBehaviour.OnlyRunOnSuccess, m.CollectorHosts[0].ChildCheckBehaviour, "Collector host ChildCheckBehaviour property not set");

                    CollectorState cs = m.RefreshStates();

                    Assert.AreEqual(CollectorState.Good, cs, "Test failed");

                    //m.CollectorHosts[0].CollectorAgents[0].InitialConfiguration = m.CollectorHosts[0].CollectorAgents[0].AgentConfig.ToXml();

                    m.Save("C:\\Test\\PSTest.qmp");
                    m.Load("C:\\Test\\PSTest.qmp");
                    Assert.AreEqual(CollectorState.Good, cs, "Test failed: second test");
                    m.Save("C:\\Test\\PSTest.qmp");

                }
            }
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void WebServiceCollectorTest()
        {
            string mconfig = "<monitorPack><configVars></configVars>" +
                "<collectorHosts>" +
                "   <collectorHost uniqueId=\"123\" dependOnParentId=\"\" name=\"QuickMon 4 Web service\" enabled=\"True\" expandOnStart=\"Auto\" " +
                "     childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                "     <collectorAgents agentCheckSequence=\"All\">" +
                "    <collectorAgent name=\"Web Service\" type=\"WSCollector\" enabled=\"True\">" +
                "            <config>" +
                "                <webServices>" +
                "                    <webService url=\"http://localhost:48181/QuickMonRemoteHost\" serviceBindingName=\"BasicHttpBinding_IRemoteCollectorHostService\" method=\"GetQuickMonCoreVersion\" paramatersCSV=\"\" resultIsSuccess=\"True\" valueExpectedReturnType=\"CheckAvailabilityOnly\" macroFormatType=\"None\" arrayIndex=\"0\" columnIndex=\"0\" valueOrMacro=\"\" useRegEx=\"False\" />" +
                "                </webServices>" +
                "            </config>" +
                "        </collectorAgent>" +
                "     </collectorAgents>" +
                "   </collectorHost>" +
                "</collectorHosts>" +
                "<notifierHosts></notifierHosts>" +
                "<logging><collectorCategories/></logging></monitorPack>";
            MonitorPack m = new MonitorPack();
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector host is expected");
                if (m.CollectorHosts.Count == 1)
                {
                    Assert.AreEqual("QuickMon 4 Web service", m.CollectorHosts[0].Name, "Collector host name not set");
                    Assert.AreEqual("123", m.CollectorHosts[0].UniqueId, "Collector host UniqueId not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].Enabled, "Collector host Enabled property not set");

                    CollectorState cs = m.RefreshStates();

                    Assert.AreNotEqual(CollectorState.ConfigurationChanged, cs, "Configuration wrong!");
                }
            }
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void AllCollectorTest()
        {
            if (!System.IO.Directory.Exists("C:\\Test"))
            {
                System.IO.Directory.CreateDirectory("C:\\Test");
            }
            string testFileName = "C:\\Test\\Test.txt";
            if (!System.IO.File.Exists(testFileName))
            {
                System.IO.File.WriteAllText(testFileName, "0");
            }

            string mconfig = Properties.Resources.AllCollectorsTest;
            MonitorPack m = new MonitorPack();
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            Assert.AreEqual("", m.LastMPLoadError, "There are load errors");
            if (m != null)
            {
                Assert.AreNotEqual(0, m.CollectorHosts.Count, "No Collector hosts loaded!");
                Assert.AreNotEqual(0, m.NotifierHosts.Count, "No Notifier hosts loaded!");
                Assert.AreEqual(true, m.LoggingEnabled, "Logging not enabled!");

                System.IO.File.WriteAllText(testFileName, "0");
                Assert.AreEqual(CollectorState.Good, m.RefreshStates(), "Good state expected");
                Assert.AreEqual(CollectorState.Good, m.CollectorHosts[0].CurrentState.State, "Cannot ping self??");
                Assert.AreEqual(1, m.ActionScripts.Count, "No Action scripts found for Monitor Pack");
                Assert.AreEqual(1, m.CollectorHosts[0].ActionScripts.Count, "No Action scripts found for Collector");

                System.IO.File.WriteAllText(testFileName, "1");
                Assert.AreEqual(CollectorState.Warning, m.RefreshStates(), "Warning state expected");
                System.IO.File.WriteAllText(testFileName, "2");
                Assert.AreEqual(CollectorState.Warning, m.RefreshStates(), "Error state expected");
                m.Save("c:\\Test\\Test.qmp");
                m = new MonitorPack();
                m.Load("c:\\Test\\Test.qmp");
                Assert.AreNotEqual(0, m.CollectorHosts.Count, "After reload: No Collector hosts loaded!");
                Assert.AreNotEqual(0, m.NotifierHosts.Count, "After reload: No Notifier hosts loaded!");
                Assert.AreEqual(1, m.CollectorHosts[0].ActionScripts.Count, "After reload: No Action scripts found for Collector");
                System.IO.File.WriteAllText("c:\\Test\\ActionScript.txt", m.CollectorHosts[0].ActionScripts[0].Run());
            }
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void CollectorHostConfigVarsTests()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"60\">\r\n" +
                "<configVars>" +
                    "<configVar find=\"%ComputerName%\" replace=\"localhost\" />" +
                    "<configVar find=\"%TestValue%\" replace=\"123\" />" +
                 "</configVars>" +
                "<collectorHosts>" +
                //Parent Collector Host
                    "<collectorHost uniqueId=\"ParentPing\" dependOnParentId=\"\" name=\"Parent Ping\" enabled=\"True\" expandOnStart=\"Auto\" childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                    "  <alerting><suppression repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" alertsPaused=\"False\" /><texts><header /><footer /><error /><warning /><good /></texts></alerting>" +
                    "  <collectorAgents agentCheckSequence=\"All\">" +
                    "    <collectorAgent name=\"Ping\" type=\"PingCollector\" enabled=\"True\">" +
                    "      <config>" +
                    "        <entries>" +
                    "          <entry pingMethod=\"Ping\" address=\"%ComputerName%\" description=\"\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "        </entries>" +
                    "      </config>" +
                    "    </collectorAgent>" +
                    "  </collectorAgents>" +
                    "  <polling enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" />" +
                    "  <remoteAgent enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" />" +
                    "  <correctiveScripts enabled=\"False\" onlyOnStateChange=\"False\"><warning /><error /><restoration /></correctiveScripts>" +
                    "  <collectorActionScripts />" +
                    "  <serviceWindows />			" +
                    "  <configVars>" +
                    "      <configVar find=\"%TestValue%\" replace=\"ABC\" />" +
                    "  </configVars>" +
                    "  <categories />" +
                    "  <notes />" +
                    "</collectorHost>" +
                    //Child Collector Host
                    "<collectorHost uniqueId=\"ChildPing\" dependOnParentId=\"ParentPing\" name=\"Child Ping\" enabled=\"True\" expandOnStart=\"Auto\" childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                    "  <alerting><suppression repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" alertsPaused=\"False\" /><texts><header /><footer /><error /><warning /><good /></texts></alerting>" +
                    "  <collectorAgents agentCheckSequence=\"All\">" +
                    "    <collectorAgent name=\"Ping\" type=\"PingCollector\" enabled=\"True\">" +
                    "      <config>" +
                    "        <entries>" +
                    "          <entry pingMethod=\"Ping\" address=\"%ComputerName%\" description=\"%TestValue%\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "        </entries>" +
                    "      </config>" +
                    "    </collectorAgent>" +
                    "  </collectorAgents>" +
                    "  <polling enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" />" +
                    "  <remoteAgent enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" />" +
                    "  <correctiveScripts enabled=\"False\" onlyOnStateChange=\"False\"><warning /><error /><restoration /></correctiveScripts>" +
                    "  <collectorActionScripts />" +
                    "  <serviceWindows />			" +
                    "  <configVars>" +
                    "      <configVar find=\"%ComputerName%\" replace=\"LOCALHOST\" />" +
                    "  </configVars>" +
                    "  <categories />" +
                    "  <notes />" +
                    "</collectorHost>" +
                    //Grand Child Collector Host
                    "<collectorHost uniqueId=\"GrandChildPing\" dependOnParentId=\"ChildPing\" name=\"Grand Child Ping\" enabled=\"True\" expandOnStart=\"Auto\" childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                    "  <alerting><suppression repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" alertsPaused=\"False\" /><texts><header /><footer /><error /><warning /><good /></texts></alerting>" +
                    "  <collectorAgents agentCheckSequence=\"All\">" +
                    "    <collectorAgent name=\"Ping\" type=\"PingCollector\" enabled=\"True\">" +
                    "      <config>" +
                    "        <entries>" +
                    "          <entry pingMethod=\"Ping\" address=\"%ComputerName%\" description=\"Ping %ComputerName% - %TestValue%\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "        </entries>" +
                    "      </config>" +
                    "    </collectorAgent>" +
                    "  </collectorAgents>" +
                    "  <polling enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" />" +
                    "  <remoteAgent enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" />" +
                    "  <correctiveScripts enabled=\"False\" onlyOnStateChange=\"False\"><warning /><error /><restoration /></correctiveScripts>" +
                    "  <collectorActionScripts />" +
                    "  <serviceWindows />			" +
                    "  <configVars />" +
                    "  <categories />" +
                    "  <notes />" +
                    "</collectorHost>" +
                "</collectorHosts>" +
                "<notifierHosts />" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            Assert.AreEqual("", m.LastMPLoadError, "There are load errors");
            Assert.AreNotEqual(0, m.ConfigVariables.Count, "No Monitor pack Config variables loaded!");
            Assert.AreEqual(3, m.CollectorHosts.Count, "3 Collector hosts expected!");
            Assert.AreNotEqual(0, m.CollectorHosts[0].ConfigVariables.Count, "No Collector host Config variables loaded!");
            Assert.AreNotEqual(0, m.CollectorHosts[0].CollectorAgents.Count, "No Collector host agents loaded!");
            m.RefreshStates();

            Assert.AreEqual(true, m.CollectorHosts[0].CollectorAgents[0].ActiveConfiguration.Contains("localhost"), "Config variable for child Collector host not set!");
            Assert.AreEqual(true, m.CollectorHosts[1].CollectorAgents[0].ActiveConfiguration.Contains("LOCALHOST"), "Config variable for child Collector host not set!");
            Assert.AreEqual(true, m.CollectorHosts[1].CollectorAgents[0].ActiveConfiguration.Contains("ABC"), "Config variable for child Collector host not set!");
            Assert.AreEqual(true, m.CollectorHosts[2].CollectorAgents[0].ActiveConfiguration.Contains("LOCALHOST - ABC"), "Config variable for grand child Collector host not set!");
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void TestLogFileNotifier()
        {
            string logNotifierOutFile = "C:\\Test\\LogFileNotifierTest.log";
            if (!System.IO.Directory.Exists("C:\\Test"))
            {
                System.IO.Directory.CreateDirectory("C:\\Test");
            }
            else if (System.IO.File.Exists(logNotifierOutFile))
            {
                System.IO.File.Delete(logNotifierOutFile);
            }

            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"60\">\r\n" +
                "<configVars>" +
                    "<configVar find=\"%ComputerName%\" replace=\"invalidhost\" />" +
                    "<configVar find=\"%TestValue%\" replace=\"123\" />" +
                 "</configVars>" +
                "<collectorHosts>" +
                    //Parent Collector Host
                    "<collectorHost uniqueId=\"ParentPing\" dependOnParentId=\"\" name=\"Parent Ping\" enabled=\"True\" expandOnStart=\"Auto\" childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                    "  <alerting><suppression repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" alertsPaused=\"False\" /><texts><header /><footer /><error /><warning /><good /></texts></alerting>" +
                    "  <collectorAgents agentCheckSequence=\"All\">" +
                    "    <collectorAgent name=\"Ping\" type=\"PingCollector\" enabled=\"True\">" +
                    "      <config>" +
                    "        <entries>" +
                    "          <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "          <entry pingMethod=\"HTTP\" address=\"http://www.google.com\" description=\"\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "          <entry pingMethod=\"Ping\" address=\"%ComputerName%\" description=\"\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "        </entries>" +
                    "      </config>" +
                    "    </collectorAgent>" +
                    "  </collectorAgents>" +
                    "  <polling enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" />" +
                    "  <remoteAgent enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" />" +
                    "  <correctiveScripts enabled=\"False\" onlyOnStateChange=\"False\"><warning /><error /><restoration /></correctiveScripts>" +
                    "  <collectorActionScripts />" +
                    "  <serviceWindows />			" +
                    "  <configVars>" +
                    "      <configVar find=\"%TestValue%\" replace=\"ABC\" />" +
                    "  </configVars>" +
                    "  <categories />" +
                    "  <notes />" +
                    "</collectorHost>" +
                    
                "</collectorHosts>" +
                "<notifierHosts>" +
                "<notifierHost name=\"Log file\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" attendedOptionOverride=\"AttendedAndUnAttended\">" +
                    "<notifierAgents>" +
                    "<notifierAgent name=\"Log file agent\" type=\"LogFileNotifier\" enabled=\"True\" >" +     
                     "<config><logFile path=\"" + logNotifierOutFile + "\" createNewFileSizeKB=\"0\" /></config>" +
                    "</notifierAgent>" +
                    "</notifierAgents>" +
                    "</notifierHost>" +
                  "</notifierHosts>" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            Assert.AreEqual("", m.LastMPLoadError, "There are load errors");
            Assert.AreNotEqual(0, m.ConfigVariables.Count, "No Monitor pack Config variables loaded!");
            Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts.Count, "1 Notifier hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts[0].NotifierAgents.Count, "1 Notifier agent expected!");
            Assert.AreEqual(CollectorState.Warning, m.RefreshStates(), "Impossible host found!");

            Assert.AreEqual(true, System.IO.File.Exists(logNotifierOutFile), "Log file Notifier file not created!");
            string[] logLings = System.IO.File.ReadAllLines(logNotifierOutFile);
            if (logLings.Length > 2)
            {
                Assert.AreEqual(true, logLings[logLings.Length-2].Contains("invalidhost"), "Alert not found in log file!");
            }
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void TestAudioNotifier()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"60\">\r\n" +
                "<configVars>" +
                    "<configVar find=\"%ComputerName%\" replace=\"invalidhost\" />" +
                    "<configVar find=\"%TestValue%\" replace=\"123\" />" +
                 "</configVars>" +
                "<collectorHosts>" +
                    //Parent Collector Host
                    "<collectorHost uniqueId=\"ParentPing\" dependOnParentId=\"\" name=\"Parent Ping\" enabled=\"True\" expandOnStart=\"Auto\" childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                    "  <alerting><suppression repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" alertsPaused=\"False\" /><texts><header /><footer /><error /><warning /><good /></texts></alerting>" +
                    "  <collectorAgents agentCheckSequence=\"All\">" +
                    "    <collectorAgent name=\"Ping\" type=\"PingCollector\" enabled=\"True\">" +
                    "      <config>" +
                    "        <entries>" +
                    "          <entry pingMethod=\"Ping\" address=\"%ComputerName%\" description=\"\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "        </entries>" +
                    "      </config>" +
                    "    </collectorAgent>" +
                    "  </collectorAgents>" +
                    "  <polling enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" />" +
                    "  <remoteAgent enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" />" +
                    "  <correctiveScripts enabled=\"False\" onlyOnStateChange=\"False\"><warning /><error /><restoration /></correctiveScripts>" +
                    "  <collectorActionScripts />" +
                    "  <serviceWindows />			" +
                    "  <configVars>" +
                    "      <configVar find=\"%TestValue%\" replace=\"ABC\" />" +
                    "  </configVars>" +
                    "  <categories />" +
                    "  <notes />" +
                    "</collectorHost>" +

                "</collectorHosts>" +
                "<notifierHosts>" +
                "<notifierHost name=\"Audio\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" attendedOptionOverride=\"AttendedAndUnAttended\">" +
                    "<notifierAgents>" +
                    "<notifierAgent name=\"Audio agent\" type=\"QuickMon.Notifiers.AudioNotifier\" enabled=\"True\" >" +
                        "<config>\r\n" +
                          "<audioConfig>\r\n" +
                            "<goodState enabled=\"false\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"1\" repeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                            "<warningState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"3\" repeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                            "<errorState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"2\" repeatCount=\"2\" soundVolumePerc=\"-1\" />\r\n" +
                          "</audioConfig>\r\n" +
                        "</config>" +
                    "</notifierAgent>" +
                    "</notifierAgents>" +
                    "</notifierHost>" +
                  "</notifierHosts>" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            Assert.AreEqual("", m.LastMPLoadError, "There are load errors");
            Assert.AreNotEqual(0, m.ConfigVariables.Count, "No Monitor pack Config variables loaded!");
            Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts.Count, "1 Notifier hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts[0].NotifierAgents.Count, "1 Notifier agent expected!");
            Assert.AreEqual(CollectorState.Error, m.RefreshStates(), "Impossible host found!");
            
        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void TestSMTPNotifier()
        {
            Assert.AreEqual(true, System.IO.File.Exists("c:\\Test\\G.txt"), "G.txt not found!");
            string pwd = System.IO.File.ReadAllText("c:\\Test\\G.txt"); //manually created
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"60\">\r\n" +
                "<configVars>" +
                    "<configVar find=\"%ComputerName%\" replace=\"invalidhost\" />" +
                    "<configVar find=\"%TestValue%\" replace=\"123\" />" +
                 "</configVars>" +
                "<collectorHosts>" +
                    //Parent Collector Host
                    "<collectorHost uniqueId=\"ParentPing\" dependOnParentId=\"\" name=\"Parent Ping\" enabled=\"True\" expandOnStart=\"Auto\" childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                    "  <alerting><suppression repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" alertsPaused=\"False\" /><texts><header /><footer /><error /><warning /><good /></texts></alerting>" +
                    "  <collectorAgents agentCheckSequence=\"All\">" +
                    "    <collectorAgent name=\"Ping\" type=\"PingCollector\" enabled=\"True\">" +
                    "      <config>" +
                    "        <entries>" +
                    "          <entry pingMethod=\"Ping\" address=\"%ComputerName%\" description=\"\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "        </entries>" +
                    "      </config>" +
                    "    </collectorAgent>" +
                    "  </collectorAgents>" +
                    "  <polling enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" />" +
                    "  <remoteAgent enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" />" +
                    "  <correctiveScripts enabled=\"False\" onlyOnStateChange=\"False\"><warning /><error /><restoration /></correctiveScripts>" +
                    "  <collectorActionScripts />" +
                    "  <serviceWindows />			" +
                    "  <configVars>" +
                    "      <configVar find=\"%TestValue%\" replace=\"ABC\" />" +
                    "  </configVars>" +
                    "  <categories />" +
                    "  <notes />" +
                    "</collectorHost>" +

                "</collectorHosts>" +
                "<notifierHosts>" +
                "<notifierHost name=\"Audio\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" attendedOptionOverride=\"AttendedAndUnAttended\">" +
                    "<notifierAgents>" +
                    "        <notifierAgent name=\"SMTP Notifier\" type=\"SMTPNotifier\" enabled=\"True\">" +
                    "            <config>" +
                    "                <smtp hostServer=\"smtp.gmail.com\" useDefaultCredentials=\"False\" domain=\"\" userName=\"rudolf.henning@gmail.com\" password=\"" + pwd + "\" fromAddress=\"rudolf.henning@gmail.com\" toAddress=\"rudolf.henning@gmail.com\" senderAddress=\"rudolf.henning@gmail.com\" replyToAddress=\"rudolf.henning@gmail.com\" mailPriority=\"0\" useTLS=\"True\" isBodyHtml=\"True\" port=\"587\" subject=\"%AlertLevel% - %CollectorName%\" body=\"QuickMon alert raised for &lt;b&gt;'%CollectorName%'&lt;/b&gt;&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Date Time:&lt;/b&gt; %DateTime%&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Current state:&lt;/b&gt; %CurrentState%&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Agents:&lt;/b&gt; %CollectorAgents%&lt;br /&gt;&#xD;&#xA;&lt;b&gt;Details&lt;/b&gt;&lt;blockquote&gt;%Details%&lt;/blockquote&gt;\" />" +
                    "            </config>" +
                    "       </notifierAgent>" +
                    "</notifierAgents>" +
                    "</notifierHost>" +
                  "</notifierHosts>" +
                "</monitorPack>";
            if (System.IO.File.Exists("c:\\Test\\QuickMonSMTPTest.qmp"))
            {
                m.Load("c:\\Test\\QuickMonSMTPTest.qmp");
            }
            else
            {
                m.LoadXml(mconfig);
                m.Save("c:\\Test\\QuickMonSMTPTest.qmp");
            }
            Assert.IsNotNull(m, "Monitor pack is null");            
            Assert.AreEqual("", m.LastMPLoadError, "There are load errors");
            Assert.AreNotEqual(0, m.ConfigVariables.Count, "No Monitor pack Config variables loaded!");
            Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts.Count, "1 Notifier hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts[0].NotifierAgents.Count, "1 Notifier agent expected!");
            Assert.AreEqual(CollectorState.Error, m.RefreshStates(), "Impossible host found!");

        }
        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void TestRSSNotifier()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"5.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"60\">\r\n" +
                "<configVars>" +
                    "<configVar find=\"%ComputerName%\" replace=\"invalidhost\" />" +
                    "<configVar find=\"%TestValue%\" replace=\"123\" />" +
                 "</configVars>" +
                "<collectorHosts>" +
                    //Parent Collector Host
                    "<collectorHost uniqueId=\"ParentPing\" dependOnParentId=\"\" name=\"Parent Ping\" enabled=\"True\" expandOnStart=\"Auto\" childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                    "  <alerting><suppression repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" alertsPaused=\"False\" /><texts><header /><footer /><error /><warning /><good /></texts></alerting>" +
                    "  <collectorAgents agentCheckSequence=\"All\">" +
                    "    <collectorAgent name=\"Ping\" type=\"PingCollector\" enabled=\"True\">" +
                    "      <config>" +
                    "        <entries>" +
                    "          <entry pingMethod=\"Ping\" address=\"%ComputerName%\" description=\"\" maxTimeMS=\"3000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                    "        </entries>" +
                    "      </config>" +
                    "    </collectorAgent>" +
                    "  </collectorAgents>" +
                    "  <polling enabledPollingOverride=\"False\" onlyAllowUpdateOncePerXSec=\"1\" enablePollFrequencySliding=\"False\" pollSlideFrequencyAfterFirstRepeatSec=\"2\" pollSlideFrequencyAfterSecondRepeatSec=\"5\" pollSlideFrequencyAfterThirdRepeatSec=\"30\" />" +
                    "  <remoteAgent enableRemoteExecute=\"False\" forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"\" remoteAgentHostPort=\"48181\" blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"False\" />" +
                    "  <correctiveScripts enabled=\"False\" onlyOnStateChange=\"False\"><warning /><error /><restoration /></correctiveScripts>" +
                    "  <collectorActionScripts />" +
                    "  <serviceWindows />			" +
                    "  <configVars>" +
                    "      <configVar find=\"%TestValue%\" replace=\"ABC\" />" +
                    "  </configVars>" +
                    "  <categories />" +
                    "  <notes />" +
                    "</collectorHost>" +

                "</collectorHosts>" +
                "<notifierHosts>" +
                "<notifierHost name=\"Audio\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" attendedOptionOverride=\"AttendedAndUnAttended\">" +
                    "<notifierAgents>" +
                    "        <notifierAgent name=\"RSS Notifier\" type=\"RSSNotifier\" enabled=\"True\">" +
                    "            <config>" +
                    "                <rss rssFilePath=\"C:\\Test\\QuickMon.rss.xml\" title=\"QuickMon RSS alerts\" link=\"http://localhost/QuickMon.rss.xml\" description=\"\" keepEntriesDays=\"10\" language=\"en-us\" generator=\"QuickMon RSS notifier\" lineTitle=\"%CollectorName% - %AlertLevel%\" lineCategory=\"%CurrentState%, %CollectorName%\" lineLink=\"\" lineDescription=\"&lt;b&gt;Date Time:&lt;/b&gt; %DateTime%&lt;br/&gt;&#xD;&#xA;&lt;b&gt;Current state:&lt;/b&gt; %CurrentState%&lt;br/&gt;&#xD;&#xA;&lt;b&gt;Collector:&lt;/b&gt; %CollectorName%&lt;br/&gt;&#xD;&#xA;&lt;b&gt;Details&lt;/b&gt;&lt;br/&gt;&#xD;&#xA;%Details%\" />" +
                    "            </config>" +
                    "        </notifierAgent>" +
                    "</notifierAgents>" +
                    "</notifierHost>" +
                  "</notifierHosts>" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            Assert.AreEqual("", m.LastMPLoadError, "There are load errors");
            Assert.AreNotEqual(0, m.ConfigVariables.Count, "No Monitor pack Config variables loaded!");
            Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts.Count, "1 Notifier hosts expected!");
            Assert.AreEqual(1, m.NotifierHosts[0].NotifierAgents.Count, "1 Notifier agent expected!");
            Assert.AreEqual(CollectorState.Error, m.RefreshStates(), "Impossible host found!");

        }
    }
}
