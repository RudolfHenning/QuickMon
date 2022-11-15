using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMon
{
    /// <summary>
    /// Summary description for CollectorAgentTests
    /// </summary>
    [TestClass]
    public class CollectorAgentTests
    {
        public CollectorAgentTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod,TestCategory("Agent Tests")]
        public void CollectorAgentTestPing()
        {
            string mconfig = "<collectorHost uniqueId=\"123\" dependOnParentId=\"\" name=\"Ping\" enabled=\"True\" expandOnStart=\"Auto\" " +
                " childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                "     <collectorAgents agentCheckSequence=\"All\">" +
                "         <collectorAgent name=\"Ping localhost\" type=\"QuickMon.Collectors.PingCollector\" enabled=\"True\">" +
                "                <config>" +
                "                    <entries>" +
                "                        <entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                "                        <entry pingMethod=\"HTTP\" address=\"http://localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                "                        <entry pingMethod=\"SOCKET\" address=\"127.0.0.1\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpHeaderUser=\"\" httpHeaderPwd=\"\" httpProxyServer=\"\" httpProxyUser=\"\" httpProxyPwd=\"\" socketPort=\"80\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" ignoreInvalidHTTPSCerts=\"False\" />" +
                "                    </entries>" +
                "                </config>" +
                "         </collectorAgent>" +
                "     </collectorAgents>" +
                "   </collectorHost>";
            CollectorHost ch = CollectorHost.FromXml(mconfig);
            Assert.IsNotNull(ch, "Collector is null");
            Assert.AreEqual("Ping", ch.Name, "Collector host name not set");
            Assert.AreEqual("123", ch.UniqueId, "Collector host UniqueId not set");
            Assert.AreEqual(true, ch.Enabled, "Collector host Enabled property not set");
            Assert.AreEqual(false, ch.RunAsEnabled, "Run As enabled!");
            Assert.AreEqual("", ch.RunAs, "Run As set up incorrectly!");
            Assert.AreEqual("", ch.ParentCollectorId, "Collector host ParentCollectorId property not set");
            Assert.AreEqual(AgentCheckSequence.All, ch.AgentCheckSequence, "Collector host AgentCheckSequence property not set");
            Assert.AreEqual(ChildCheckBehaviour.OnlyRunOnSuccess, ch.ChildCheckBehaviour, "Collector host ChildCheckBehaviour property not set");
            Assert.AreEqual(1, ch.CollectorAgents.Count, "1 Collector agent expected");
            Assert.AreEqual(0, ch.ConfigVariables.Count, "No config variables expected");
            Assert.AreEqual(0, ch.RefreshCount, "No refreshes expected yet");
            
            MonitorState testState = ch.RefreshCurrentState();
            Assert.AreEqual(1, ch.RefreshCount, "1 refresh expected");
            Assert.AreEqual(CollectorState.Good, testState.State, "Cannot ping self");

        }

        [TestMethod, TestCategory("Agent Tests")]
        public void FileVersionCollectorTest()
        {
            string mconfig = "<collectorHost uniqueId=\"123\" dependOnParentId=\"\" name=\"Application Version\" enabled=\"True\" expandOnStart=\"Auto\" " +
                " childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
                "     <collectorAgents agentCheckSequence=\"All\">" +
                "         <collectorAgent name=\"Notepad version\" type=\"QuickMon.Collectors.AppVersionCollector\" enabled=\"True\">" +
                "                <config>" +
                "                    <applications>" +
                "                       <application name=\"Notepad\" expectedVersion=\"10.0.19041*\" useFileVersion=\"True\" useFirstValidPath=\"True\" primaryUIValue=\"False\">" +
                "                           <paths><path>C:\\Windows\\notepad.exe</path></paths>" +
                "                       </application>" +
                "                    </applications>" +
                "                </config>" +
                "         </collectorAgent>" +
                "     </collectorAgents>" +
                "   </collectorHost>";

            CollectorHost ch = CollectorHost.FromXml(mconfig);
            Assert.IsNotNull(ch, "Collector is null");
            Assert.AreEqual("Application Version", ch.Name, "Collector host name not set");
            Assert.IsNotNull(ch.CollectorAgents, "No agents!");
            if (ch.CollectorAgents.Count > 0)
            {
                Assert.AreEqual("Notepad version", ch.CollectorAgents[0].Name, "collectorAgent name");
                Assert.AreEqual("QuickMon.Collectors.AppVersionCollector", ch.CollectorAgents[0].GetType().ToString(), "collectorAgent type");
                QuickMon.Collectors.AppVersionCollector appVersionCollector = (QuickMon.Collectors.AppVersionCollector)ch.CollectorAgents[0];
                Assert.AreEqual(true, ((ICollectorConfig)appVersionCollector.AgentConfig).Entries.Count > 0, "No Application version entries");
                Collectors.AppVersionEntry appVersionEntry = (Collectors.AppVersionEntry)((ICollectorConfig)appVersionCollector.AgentConfig).Entries[0];
                Assert.AreEqual("Notepad", appVersionEntry.ApplicationName, "Application name");

                MonitorState testState = ch.RefreshCurrentState();
                Assert.AreEqual(1, ch.RefreshCount, "1 refresh expected");
                Assert.AreEqual(CollectorState.Good, testState.State, "Version different");
            }
        }
    }
}
