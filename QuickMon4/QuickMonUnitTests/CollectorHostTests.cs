using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMon
{
    [TestClass]
    public class CollectorHostTests
    {
        [TestMethod]
        public void CreateCollectorHostTest()
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
            Assert.IsNotNull(chList, "CollectorHost list is null");
            if (chList != null)
            {                
                Assert.IsNotNull(chList[0].ToXml(), "CollectorHost[0].ToXml is null");
                string chXml = chList[0].ToXml();
                Assert.AreNotEqual("", chXml, "CollectorHost[0].ToXml is empty");
                StringBuilder rebuildXml = new StringBuilder();
                rebuildXml.AppendLine("<collectorHosts>");
                foreach (CollectorHost ch in chList)
                {
                    rebuildXml.AppendLine(ch.ToXml());
                }
                rebuildXml.AppendLine("</collectorHosts>");

                chList = CollectorHost.GetCollectorHostsFromString(configXml);
                Assert.IsNotNull(chList, "CollectorHost list is null (test 2)");
            }            
        }
        [TestMethod]
        public void AgentCheckSequenceTest()
        {
            string configXml = "<collectorHosts>\r\n" +
                        "<collectorHost uniqueId=\"123\" name=\"Ping test\" enabled=\"True\" " +
                           "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" >\r\n" +
                           "<collectorAgents>\r\n" +
                               "<collectorAgent type=\"PingCollector\">\r\n" +
                                    "<config>\r\n" +
                                        "<entries>\r\n" +
                                            "<entry pingMethod=\"Ping\" address=\"localhost\" />\r\n" +
                                        "</entries>\r\n" +
                                    "</config>\r\n" +
                               "</collectorAgent>\r\n" +
                               "<collectorAgent type=\"PingCollector\">\r\n" +
                                    "<config>\r\n" +
                                        "<entries>\r\n" +
                                            "<entry pingMethod=\"Ping\" address=\"localhostInvalid\" />\r\n" +
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
                    "</collectorHosts>";
            List<CollectorHost> chList = CollectorHost.GetCollectorHostsFromString(configXml);
            Assert.IsNotNull(chList, "CollectorHost list is null");
            if (chList != null && chList.Count == 1)
            {
                MonitorState ms = chList[0].RefreshCurrentState();
                Assert.AreEqual(3, ms.ChildStates.Count, "All agents expected to execute");
                chList[0].AgentCheckSequence = AgentCheckSequence.FirstSuccess;
                ms = chList[0].RefreshCurrentState();
                Assert.AreEqual(1, ms.ChildStates.Count, "Only first agent expected to execute");

                chList[0].AgentCheckSequence = AgentCheckSequence.FirstError;
                ms = chList[0].RefreshCurrentState();
                Assert.AreEqual(2, ms.ChildStates.Count, "Second agent expected to execute");
            }
        }
    }
}
