using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMon
{
    [TestClass]
    public class MonitorStateTests
    {
        [TestMethod, TestCategory("MonitorState")]
        public void MonitorStateSerialization()
        {
            MonitorState ms = new MonitorState();
            ms.ExecutedOnHostComputer = "localhost";
            ms.RawDetails = "This is a test";
            ms.HtmlDetails = "<p>This is a test</p>";
            ms.State = CollectorState.NotAvailable;
            ms.Timestamp = DateTime.Now;
            ms.StateChangedTime = DateTime.Now;
            ms.CallDurationMS = 1001;
            ms.AlertsRaised.Add("Test alert");
            ms.ChildStates.Add(new MonitorState() { State = CollectorState.Good, RawDetails = "Child test" });

            Assert.IsNotNull(ms.ToXml(), "MonitorState ToXml is null");
            Assert.AreNotEqual("", ms.ToXml(), "MonitorState ToXml is empty");
            string msSerialized = ms.ToXml();
            ms.FromXml(ms.ToXml());
            Assert.AreEqual(msSerialized, ms.ToXml(), "Serialized/Deserialized failed");
        }
    }
}
