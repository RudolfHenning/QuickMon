using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMon
{
    [TestClass]
    public class MonitorUnitTests
    {
        [TestMethod, TestCategory("MonitorPack-IOTest")]
        public void CreateBlankMonitorPack()
        {
            try
            {             
                MonitorPack m = new MonitorPack();
                Assert.IsNotNull(m, "Success");
            }
            catch(Exception ex)
            {
                Assert.Fail("Could not create monitorpack:" + ex.ToString());
            }
        }
        [TestMethod, TestCategory("MonitorPack-IOTest")]
        public void LoadBlankMonitorPack()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " + 
                "defaultNotifier=\"In Memory\" runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                "<configVars />" +
                "<collectorHosts />" +
                "<notifierHosts />" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                Assert.AreEqual("Test",m.Name,  "Name is not set");
                Assert.AreEqual("4.0.0", m.Version, "Version is not set");
                Assert.AreEqual("TestType",m.TypeName,  "Type is not set");
                Assert.AreEqual("true",m.Enabled.ToString().ToLower(),  "Enabled is not set");
                Assert.AreEqual("true",m.RunCorrectiveScripts.ToString().ToLower(),  "runCorrectiveScripts is not set");
                Assert.AreEqual(100, m.CollectorStateHistorySize, string.Format("CollectorStateHistorySize is not set: {0}", m.CollectorStateHistorySize));
                Assert.AreEqual(12, m.PollingFrequencyOverrideSec, string.Format("PollingFrequencyOverrideSec is not set: {0}", m.PollingFrequencyOverrideSec));
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
            string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "defaultNotifier=\"In Memory\" runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"101\" pollingFreqSecOverride=\"12\">\r\n" +
                "<configVars />" +
                "<collectorHosts />" +
                "<notifierHosts />" +
                "</monitorPack>";
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                string outputFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon4SaveTest.qmp");
                if (System.IO.File.Exists(outputFileName))
                    System.IO.File.Delete(outputFileName);
                m.Save(outputFileName);
                Assert.AreEqual("Test", m.Name, "Name is not set");
                Assert.AreEqual(true, System.IO.File.Exists(outputFileName));
                Assert.AreEqual("4.0.0", m.Version, "Version is not set");
                Assert.AreEqual("TestType", m.TypeName, "Type is not set");
                Assert.AreEqual(true, m.Enabled, "Enabled is not set");
                Assert.AreEqual(true, m.RunCorrectiveScripts, "runCorrectiveScripts is not set");
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
                    Assert.AreEqual(0, m.NotifierHosts.Count, "NotifierHosts count should be 0");

                m.Name = "Deliberately change name";
                m.Load(outputFileName);
                Assert.AreEqual("Test", m.Name, "Name is not set (2nd test)");
                Assert.AreEqual(true, System.IO.File.Exists(outputFileName));
                //Assert.AreEqual("4.0.0.0", m.Version, "Version is not set (2nd test)");
                Assert.AreEqual("TestType", m.TypeName, "Type is not set (2nd test)");
                Assert.AreEqual(true, m.Enabled, "Enabled is not set (2nd test)");
                Assert.AreEqual(true, m.RunCorrectiveScripts, "runCorrectiveScripts is not set (2nd test)");
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
                    Assert.AreEqual(0, m.NotifierHosts.Count, "NotifierHosts count should be 0 (2nd test)");
            }
        }
        [TestMethod, TestCategory("MonitorPack-IOTest")]
        public void ConfigVarsLoadTest()
        {
            MonitorPack m = new MonitorPack();
            string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                "defaultNotifier=\"In Memory\" runCorrectiveScripts=\"True\" " +
                "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
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
        public void LoadBlankCollectorHost()
        {
            string mconfig = "<monitorPack version=\"4.0.0\" name=\"Test\" typeName=\"TestType\" enabled=\"True\" " +
                    "defaultNotifier=\"In Memory\" runCorrectiveScripts=\"True\" " +
                    "stateHistorySize=\"100\" pollingFreqSecOverride=\"12\">\r\n" +
                    "<configVars />\r\n" +
                    "<collectorHosts>\r\n" +
                        "<collectorHost uniqueId=\"123\" name=\"Test name\" enabled=\"True\" expandOnStart=\"Auto\" dependOnParentId=\"\" " +
                           "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "repeatAlertInXMin=\"1\" alertOnceInXMin=\"1\" delayErrWarnAlertForXSec=\"1\" " +
                           "repeatAlertInXPolls=\"1\" alertOnceInXPolls=\"1\" delayErrWarnAlertForXPolls=\"1\" " +
                           "correctiveScriptDisabled=\"True\" correctiveScriptOnWarningPath=\"test\" correctiveScriptOnErrorPath=\"test\" " +
                           "restorationScriptPath=\"test\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"True\" " +
                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"test\" remoteAgentHostPort=\"48182\" " +
                           "blockParentRemoteAgentHostSettings=\"True\" runLocalOnRemoteHostConnectionFailure=\"True\" " +
                           "enabledPollingOverride=\"True\" onlyAllowUpdateOncePerXSec=\"2\" enablePollFrequencySliding=\"True\" " +
                           "pollSlideFrequencyAfterFirstRepeatSec=\"3\" pollSlideFrequencyAfterSecondRepeatSec=\"6\" " +
                           "pollSlideFrequencyAfterThirdRepeatSec=\"31\">\r\n" +
                        "</collectorHost>\r\n" +
                    "</collectorHosts>\r\n" +
                    "<notifierHosts />\r\n" +
                   "</monitorPack>";

            MonitorPack m = new MonitorPack();
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector host is expected");
                if (m.CollectorHosts.Count == 1)
                {
                    Assert.AreEqual("Test name", m.CollectorHosts[0].Name, "Collector host name not set");
                    Assert.AreEqual("123", m.CollectorHosts[0].UniqueId, "Collector host UniqueId not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].Enabled, "Collector host Enabled property not set");
                    Assert.AreEqual(ExpandOnStartOption.Auto, m.CollectorHosts[0].ExpandOnStartOption, "Collector host ExpandOnStart property not set");
                    Assert.AreEqual("", m.CollectorHosts[0].ParentCollectorId, "Collector host ParentCollectorId property not set");
                    Assert.AreEqual(AgentCheckSequence.All, m.CollectorHosts[0].AgentCheckSequence, "Collector host AgentCheckSequence property not set");
                    Assert.AreEqual(ChildCheckBehaviour.OnlyRunOnSuccess, m.CollectorHosts[0].ChildCheckBehaviour, "Collector host ChildCheckBehaviour property not set");
                    Assert.AreEqual(1, m.CollectorHosts[0].RepeatAlertInXMin, "Collector host RepeatAlertInXMin property not set");
                    Assert.AreEqual(1, m.CollectorHosts[0].AlertOnceInXMin, "Collector host AlertOnceInXMin property not set");
                    Assert.AreEqual(1, m.CollectorHosts[0].DelayErrWarnAlertForXSec, "Collector host DelayErrWarnAlertForXSec property not set");
                    Assert.AreEqual(1, m.CollectorHosts[0].RepeatAlertInXPolls, "Collector host RepeatAlertInXPolls property not set");
                    Assert.AreEqual(1, m.CollectorHosts[0].AlertOnceInXPolls, "Collector host AlertOnceInXPolls property not set");
                    Assert.AreEqual(1, m.CollectorHosts[0].DelayErrWarnAlertForXPolls, "Collector host DelayErrWarnAlertForXPolls property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].CorrectiveScriptDisabled, "Collector host CorrectiveScriptDisabled property not set");
                    Assert.AreEqual("test", m.CollectorHosts[0].CorrectiveScriptOnWarningPath, "Collector host CorrectiveScriptOnWarningPath property not set");
                    Assert.AreEqual("test", m.CollectorHosts[0].CorrectiveScriptOnErrorPath, "Collector host CorrectiveScriptOnErrorPath property not set");
                    Assert.AreEqual("test", m.CollectorHosts[0].RestorationScriptPath, "Collector host RestorationScriptPath property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].CorrectiveScriptsOnlyOnStateChange, "Collector host CorrectiveScriptsOnlyOnStateChange property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].EnableRemoteExecute, "Collector host EnableRemoteExecute property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].ForceRemoteExcuteOnChildCollectors, "Collector host ForceRemoteExcuteOnChildCollectors property not set");
                    Assert.AreEqual("test", m.CollectorHosts[0].RemoteAgentHostAddress, "Collector host RemoteAgentHostAddress property not set");
                    Assert.AreEqual(48182, m.CollectorHosts[0].RemoteAgentHostPort, "Collector host RemoteAgentHostPort property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].BlockParentOverrideRemoteAgentHostSettings, "Collector host BlockParentOverrideRemoteAgentHostSettings property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].RunLocalOnRemoteHostConnectionFailure, "Collector host RunLocalOnRemoteHostConnectionFailure property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].EnabledPollingOverride, "Collector host EnabledPollingOverride property not set");
                    Assert.AreEqual(2, m.CollectorHosts[0].OnlyAllowUpdateOncePerXSec, "Collector host OnlyAllowUpdateOncePerXSec property not set");
                    Assert.AreEqual(true, m.CollectorHosts[0].EnablePollFrequencySliding, "Collector host EnablePollFrequencySliding property not set");
                    Assert.AreEqual(3, m.CollectorHosts[0].PollSlideFrequencyAfterFirstRepeatSec, "Collector host PollSlideFrequencyAfterFirstRepeatSec property not set");
                    Assert.AreEqual(6, m.CollectorHosts[0].PollSlideFrequencyAfterSecondRepeatSec, "Collector host PollSlideFrequencyAfterSecondRepeatSec property not set");
                    Assert.AreEqual(31, m.CollectorHosts[0].PollSlideFrequencyAfterThirdRepeatSec, "Collector host PollSlideFrequencyAfterThirdRepeatSec property not set");

                    string outputFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon4SaveTest.qmp");
                    if (System.IO.File.Exists(outputFileName))
                        System.IO.File.Delete(outputFileName);
                    m.Save(outputFileName);
                    Assert.AreEqual(true, System.IO.File.Exists(outputFileName));

                    m.Load(outputFileName);
                    Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector host is expected (2nd test)");
                    if (m.CollectorHosts.Count == 1)
                    {
                        Assert.AreEqual("Test name", m.CollectorHosts[0].Name, "Collector host name not set (2nd test)");
                        Assert.AreEqual("123", m.CollectorHosts[0].UniqueId, "Collector host UniqueId not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].Enabled, "Collector host Enabled property not set (2nd test)");
                        Assert.AreEqual(ExpandOnStartOption.Auto, m.CollectorHosts[0].ExpandOnStartOption, "Collector host ExpandOnStart property not set (2nd test)");
                        Assert.AreEqual("", m.CollectorHosts[0].ParentCollectorId, "Collector host ParentCollectorId property not set (2nd test)");
                        Assert.AreEqual(AgentCheckSequence.All, m.CollectorHosts[0].AgentCheckSequence, "Collector host AgentCheckSequence property not set (2nd test)");
                        Assert.AreEqual(ChildCheckBehaviour.OnlyRunOnSuccess, m.CollectorHosts[0].ChildCheckBehaviour, "Collector host ChildCheckBehaviour property not set (2nd test)");
                        Assert.AreEqual(1, m.CollectorHosts[0].RepeatAlertInXMin, "Collector host RepeatAlertInXMin property not set (2nd test)");
                        Assert.AreEqual(1, m.CollectorHosts[0].AlertOnceInXMin, "Collector host AlertOnceInXMin property not set (2nd test)");
                        Assert.AreEqual(1, m.CollectorHosts[0].DelayErrWarnAlertForXSec, "Collector host DelayErrWarnAlertForXSec property not set (2nd test)");
                        Assert.AreEqual(1, m.CollectorHosts[0].RepeatAlertInXPolls, "Collector host RepeatAlertInXPolls property not set (2nd test)");
                        Assert.AreEqual(1, m.CollectorHosts[0].AlertOnceInXPolls, "Collector host AlertOnceInXPolls property not set (2nd test)");
                        Assert.AreEqual(1, m.CollectorHosts[0].DelayErrWarnAlertForXPolls, "Collector host DelayErrWarnAlertForXPolls property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].CorrectiveScriptDisabled, "Collector host CorrectiveScriptDisabled property not set (2nd test)");
                        Assert.AreEqual("test", m.CollectorHosts[0].CorrectiveScriptOnWarningPath, "Collector host CorrectiveScriptOnWarningPath property not set (2nd test)");
                        Assert.AreEqual("test", m.CollectorHosts[0].CorrectiveScriptOnErrorPath, "Collector host CorrectiveScriptOnErrorPath property not set (2nd test)");
                        Assert.AreEqual("test", m.CollectorHosts[0].RestorationScriptPath, "Collector host RestorationScriptPath property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].CorrectiveScriptsOnlyOnStateChange, "Collector host CorrectiveScriptsOnlyOnStateChange property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].EnableRemoteExecute, "Collector host EnableRemoteExecute property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].ForceRemoteExcuteOnChildCollectors, "Collector host ForceRemoteExcuteOnChildCollectors property not set (2nd test)");
                        Assert.AreEqual("test", m.CollectorHosts[0].RemoteAgentHostAddress, "Collector host RemoteAgentHostAddress property not set (2nd test)");
                        Assert.AreEqual(48182, m.CollectorHosts[0].RemoteAgentHostPort, "Collector host RemoteAgentHostPort property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].BlockParentOverrideRemoteAgentHostSettings, "Collector host BlockParentOverrideRemoteAgentHostSettings property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].RunLocalOnRemoteHostConnectionFailure, "Collector host RunLocalOnRemoteHostConnectionFailure property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].EnabledPollingOverride, "Collector host EnabledPollingOverride property not set (2nd test)");
                        Assert.AreEqual(2, m.CollectorHosts[0].OnlyAllowUpdateOncePerXSec, "Collector host OnlyAllowUpdateOncePerXSec property not set (2nd test)");
                        Assert.AreEqual(true, m.CollectorHosts[0].EnablePollFrequencySliding, "Collector host EnablePollFrequencySliding property not set (2nd test)");
                        Assert.AreEqual(3, m.CollectorHosts[0].PollSlideFrequencyAfterFirstRepeatSec, "Collector host PollSlideFrequencyAfterFirstRepeatSec property not set (2nd test)");
                        Assert.AreEqual(6, m.CollectorHosts[0].PollSlideFrequencyAfterSecondRepeatSec, "Collector host PollSlideFrequencyAfterSecondRepeatSec property not set (2nd test)");
                        Assert.AreEqual(31, m.CollectorHosts[0].PollSlideFrequencyAfterThirdRepeatSec, "Collector host PollSlideFrequencyAfterThirdRepeatSec property not set (2nd test)");
                    }
                }
            }
        }

        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void LoadAgentTypes()
        {
            Assert.IsNotNull(RegisteredAgentCache.Agents, "Agents not loaded");
            Assert.AreNotEqual(0, RegisteredAgentCache.Agents.Count, "No agents found!");
        }

        [TestMethod, TestCategory("MonitorPack-Agents")]
        public void LoadPingCollectorTest()
        {
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
                                            "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
                                        "</entries>\r\n" +
                                    "</config>\r\n" +
                               "</collectorAgent>\r\n" +
                           "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n" +
                    "</collectorHosts>\r\n" +
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
            MonitorPack m = new MonitorPack();
            m.LoadXml(mconfig);
            Assert.IsNotNull(m, "Monitor pack is null");
            if (m != null)
            {
                string outputFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon4SaveTest.qmp");
                if (System.IO.File.Exists(outputFileName))
                    System.IO.File.Delete(outputFileName);
                m.Save(outputFileName);
                m.Load(outputFileName);

                Assert.AreEqual(1, m.CollectorHosts.Count, "1 Collector host is expected");
                if (m.CollectorHosts.Count == 1)
                {
                    Assert.AreEqual(1, m.CollectorHosts[0].CollectorAgents.Count, "1 Collector agent is expected");
                    Assert.AreEqual(m.CollectorHosts[0].CollectorAgents[0].InitialConfiguration, m.CollectorHosts[0].CollectorAgents[0].ActiveConfiguration, "Initial and active config should match");
                }
            }
        }

    }

}
