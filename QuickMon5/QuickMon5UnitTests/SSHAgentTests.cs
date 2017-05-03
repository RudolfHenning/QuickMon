using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon
{
    [TestClass]
    public class SSHAgentTests
    {
        [TestMethod, TestCategory("Config test")]
        public void SSHConfigTest()
        {

            string mconfig = "<collectorHost uniqueId=\"SSHTest\" dependOnParentId=\"\" name=\"SSH Test\" enabled=\"True\" expandOnStart=\"Auto\" " +
            " childCheckBehaviour=\"OnlyRunOnSuccess\" runAsEnabled=\"False\" runAs=\"\">" +
            "     <collectorAgents agentCheckSequence=\"All\">" +
            "         <collectorAgent name=\"SSH Test\" type=\"QuickMon.Collectors.SSHCommandCollector\" enabled=\"True\">" +
              "<config>" +
               "<carvcesEntries>" +
               "<carvceEntry>" +
                 "<dataSource name=\"SSH Test\" sshSecOpt=\"password\" machine=\"hostName\" sshPort=\"22\" userName=\"user\" password=\"pwd\" privateKeyFile=\"\" passPhrase=\"\" persistent=\"False\">" +
                 "<stateQuery>grep ^Version= /usr/lib/firefox/application.ini</stateQuery>" +
               "</dataSource>" +
               "<testConditions testSequence=\"GWE\">" +
               "<success testType=\"contains\">Version=53.0</success>" +
               "<warning testType=\"match\">[any]</warning>" +
               "<error testType=\"match\">[null]</error>" +
               "</testConditions>" +
               "</carvceEntry>" +
               "</carvcesEntries>" +
               "</config>" +
            "         </collectorAgent>" +
            "     </collectorAgents>" +
            "   </collectorHost>";

            CollectorHost ch = CollectorHost.FromXml(mconfig);
            Assert.AreEqual("SSH Test", ch.Name, "Collector host name not set");
            Assert.AreEqual(1, ch.CollectorAgents.Count, "1 Collector agent expected");
            Assert.AreEqual("SSH Test", ch.CollectorAgents[0].Name, "Agent name not set");
            Assert.IsInstanceOfType(ch.CollectorAgents[0], typeof(Collectors.SSHCommandCollector));

            Collectors.SSHCommandCollector sshCollector = (Collectors.SSHCommandCollector)ch.CollectorAgents[0];
            Assert.AreEqual(1, ((Collectors.SSHCommandCollectorConfig)sshCollector.AgentConfig).Entries.Count, "1 SSH Command expected");

            Collectors.SSHCommandCollectorConfigEntry sshEntry = (Collectors.SSHCommandCollectorConfigEntry)(((Collectors.SSHCommandCollectorConfig)sshCollector.AgentConfig).Entries[0]);
            Assert.AreEqual("hostName", sshEntry.SSHConnection.ComputerName, "SSH server name not found!");
            Assert.AreEqual("Version=53.0", sshEntry.GoodValue, "Good value does not match");

            string savedConfig = ch.ToXml();
            ch = CollectorHost.FromXml(savedConfig);
            Assert.AreEqual("SSH Test", ch.Name, "Collector host name not set (reload)");
            Assert.AreEqual(1, ch.CollectorAgents.Count, "1 Collector agent expected (reload)");
            Assert.AreEqual("SSH Test", ch.CollectorAgents[0].Name, "Agent name not set (reload)");

            //string testValue = sshEntry.ExecuteCommand();
            //MonitorState testState = ch.RefreshCurrentState();
        }
    }
}
