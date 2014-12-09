using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace QuickMon
{
    [TestClass]
    public class RemoteCollectorHostTests
    {
        [TestMethod]
        public void CollectorHostToRemoteCollectorHostConversionTest()
        {
            string configXml = "<collectorHosts>\r\n" +
                        "<collectorHost uniqueId=\"1234\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
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
                RemoteCollectorHost rch = new RemoteCollectorHost();
                rch.FromCollectorHost(chList[0]);
                Assert.AreEqual(1, rch.Agents.Count, "Expected 1 Agent - " + rch.ToCollectorHostXml());
                Assert.AreNotEqual("", rch.ToCollectorHostXml(), "RemoteCollectorHost.FromCollectorHost is empty");
                if (rch.Agents.Count == 1)
                {
                    Assert.AreEqual("PingCollector", rch.Agents[0].TypeName, "Type should be PingCollector");
                    Assert.AreNotEqual(0, rch.Agents[0].ConfigString.Length, "Agent config must not be blank");
                }
                
            }
        }

        [TestMethod]
        public void CallCollectorHostThroughRemoteHost()
        {
            string configXml = "<collectorHosts>\r\n" +
                        "<collectorHost uniqueId=\"1234\" name=\"Ping test\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                           "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "repeatAlertInXMin=\"0\" alertOnceInXMin=\"0\" delayErrWarnAlertForXSec=\"0\" " +
                           "repeatAlertInXPolls=\"0\" alertOnceInXPolls=\"0\" delayErrWarnAlertForXPolls=\"0\" " +
                           "correctiveScriptDisabled=\"False\" correctiveScriptOnWarningPath=\"\" correctiveScriptOnErrorPath=\"\" " +
                           "restorationScriptPath=\"\" correctiveScriptsOnlyOnStateChange=\"True\" enableRemoteExecute=\"True\" " +
                           "forceRemoteExcuteOnChildCollectors=\"True\" remoteAgentHostAddress=\"localhost\" remoteAgentHostPort=\"48181\" " +
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
                Assert.AreEqual(true, chList[0].EnableRemoteExecute, "Remote execute not enabled");
                Assert.AreEqual(false, chList[0].RunLocalOnRemoteHostConnectionFailure, "RunLocalOnRemoteHostConnectionFailure should not be set");
                MonitorState ms = chList[0].RefreshCurrentState();
                Assert.AreEqual(CollectorState.Good, ms.State, "Could not ping localhost");
                Assert.AreEqual("", ms.ReadAllRawDetails(), "Raw Details");
                Assert.AreEqual("localhost", ms.ExecutedOnHostComputer, "Should run on localhost");
            }
        }
    }
}
