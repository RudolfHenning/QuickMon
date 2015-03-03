using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace QuickMon
{
    [DataContract]
    public class MonitorState
    {
        public MonitorState()
        {
            UniqueId = Guid.NewGuid().ToString();
            Timestamp = DateTime.Now;
            AlertsRaised = new List<string>();
            ChildStates = new List<MonitorState>();
        }
        public string UniqueId { get; private set; }
        private CollectorState state = CollectorState.NotAvailable;
        [DataMember(Name = "State")]
        public CollectorState State
        {
            get { return state; }
            set { state = value; StateChangedTime = DateTime.Now; }
        }
        [DataMember(Name = "CurrentValue")]
        public object CurrentValue { get; set; }

        [DataMember(Name = "ForAgent")]
        public string ForAgent { get; set; }
        [DataMember(Name = "ForAgentId")]
        public int ForAgentId { get; set; }        

        [DataMember(Name = "RawDetails")]
        public string RawDetails { get; set; }
        [DataMember(Name = "HtmlDetails")]
        public string HtmlDetails { get; set; }
        [DataMember(Name = "Timestamp")]
        public DateTime Timestamp { get; set; }
        [DataMember(Name = "StateChangedTime")]
        public DateTime StateChangedTime { get; set; }
        [DataMember(Name = "CallDurationMS")]
        public int CallDurationMS { get; set; }
        [DataMember(Name = "ExecutedOnHostComputer")]
        public string ExecutedOnHostComputer { get; set; }
        [DataMember(Name = "AlertsRaised")]
        public List<string> AlertsRaised { get; set; }

        public MonitorState Clone()
        {
            List<string> cloneAlerts = new List<string>();
            cloneAlerts.AddRange(AlertsRaised.ToArray());
            return new MonitorState()
            {
                State = this.State,
                CurrentValue = this.CurrentValue,
                ForAgent = this.ForAgent,
                RawDetails = this.RawDetails,
                HtmlDetails = this.HtmlDetails,
                Timestamp = this.Timestamp,
                StateChangedTime = this.StateChangedTime,
                CallDurationMS = this.CallDurationMS,
                ExecutedOnHostComputer = this.ExecutedOnHostComputer,
                AlertsRaised = cloneAlerts
            };
        }

        public override string ToString()
        {
            return State.ToString();
        }
        public string ToXml()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<monitorState uniqueId=\"\" state=\"NotAvailable\" currentValue=\"\" lastStateChangeTime=\"\" forAgent=\"\" />");
            XmlElement root = xdoc.DocumentElement;
            root.SetAttributeValue("uniqueId", UniqueId);
            root.SetAttributeValue("state", State.ToString());
            root.SetAttributeValue("stateChangedTime", StateChangedTime.ToString("yyyy-MM-dd HH:mm:ss"));
            root.SetAttributeValue("forAgent", ForAgent);
            root.SetAttributeValue("forAgentId", ForAgentId);
            root.SetAttributeValue("timeStamp", Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
            root.SetAttributeValue("callDurationMS", CallDurationMS.ToString());
            if (CurrentValue != null)
                root.SetAttributeValue("currentValue", CurrentValue.ToString());
            else
                root.SetAttributeValue("currentValue", "");
            root.SetAttributeValue("executedOnHostComputer", ExecutedOnHostComputer);

            XmlElement rawDetailsNode = xdoc.CreateElement("rawDetails");
            rawDetailsNode.InnerText = RawDetails;
            root.AppendChild(rawDetailsNode);
            XmlElement htmlDetailsNode = xdoc.CreateElement("htmlDetails");
            htmlDetailsNode.InnerText = HtmlDetails;
            root.AppendChild(htmlDetailsNode);
            XmlElement alerts = xdoc.CreateElement("alerts");
            foreach (string alert in AlertsRaised)
            {
                XmlElement alertNode = xdoc.CreateElement("alert");
                alertNode.InnerText = alert;
                alerts.AppendChild(alertNode);
            }
            root.AppendChild(alerts);
            StringBuilder childStates = new StringBuilder();
            if (ChildStates != null && ChildStates.Count > 0)
            {
                childStates.AppendLine("<childStates>");
                foreach (MonitorState childState in ChildStates)
                {
                    childStates.AppendLine(childState.ToXml());
                }
                childStates.AppendLine("</childStates>");
            }
            return xdoc.OuterXml.Replace("</monitorState>", childStates.ToString() + "</monitorState>");
        }
        public void FromXml(string content)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(content);
            XmlElement root = xdoc.DocumentElement;
            UniqueId = root.ReadXmlElementAttr("uniqueId", Guid.NewGuid().ToString());
            State = CollectorStateConverter.GetCollectorStateFromText(root.ReadXmlElementAttr("state", "NotAvailable"));
            try
            {
                StateChangedTime = DateTime.Parse(root.ReadXmlElementAttr("stateChangedTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            catch { }
            try
            {
                Timestamp = DateTime.Parse(root.ReadXmlElementAttr("timeStamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            catch { }
            try
            {
                CallDurationMS = root.ReadXmlElementAttr("callDurationMS", 0);
            }
            catch { }
            ForAgent = root.ReadXmlElementAttr("forAgent", "");
            ForAgentId = root.ReadXmlElementAttr("forAgentId", -1);
            CurrentValue = root.ReadXmlElementAttr("currentValue", "");
            ExecutedOnHostComputer = root.ReadXmlElementAttr("executedOnHostComputer", "");
            RawDetails = root.SelectSingleNode("rawDetails").InnerText;
            HtmlDetails = root.SelectSingleNode("htmlDetails").InnerText;
            XmlNodeList alertNodes = root.SelectNodes("alerts");
            AlertsRaised = new List<string>();
            foreach (XmlNode alertNode in alertNodes)
            {
                if (alertNode.InnerText.Trim().Length > 0)
                    AlertsRaised.Add(alertNode.InnerText);
            }
            ChildStates = new List<MonitorState>();
            XmlNodeList childStates = root.SelectNodes("childStates/monitorState");
            foreach (XmlNode childStateNode in childStates)
            {
                MonitorState childState = new MonitorState();
                childState.FromXml(childStateNode.OuterXml);
                ChildStates.Add(childState);
            }
        }

        [DataMember(Name = "ChildStates")]
        public List<MonitorState> ChildStates { get; set; }

        public string ReadAllRawDetails(char linePaddingChar = ' ', int linePaddingRepeat = 0)
        {
            StringBuilder sb = new StringBuilder();
            string prePadding = new string(linePaddingChar, linePaddingRepeat);
            if (ForAgent != null && ForAgent.Length > 0)
            {
                prePadding += string.Format("{0}: ", ForAgent);
                if (State == CollectorState.Good || State == CollectorState.Warning || State == CollectorState.Error || State == CollectorState.Disabled || State == CollectorState.ConfigurationError)
                {
                    prePadding += string.Format("({0}) ", State);
                }
            }
            if (RawDetails != null && RawDetails.Length > 0)
                prePadding += RawDetails.TrimEnd('\r', '\n').Replace("\r\n", "\r\n" + linePaddingChar);

            if (prePadding.Trim(linePaddingChar).Length > 0)
            {
                sb.AppendLine(prePadding);                
                linePaddingRepeat++;
            }            

            if (ChildStates != null)
            {
                foreach (MonitorState ms in ChildStates)
                {
                    sb.Append(ms.ReadAllRawDetails(linePaddingChar, linePaddingRepeat));
                }
            }
            return sb.ToString();
        }
        public string ReadAllHtmlDetails()
        {
            StringBuilder sb = new StringBuilder();
            if (HtmlDetails != null && HtmlDetails.Length > 0)
            {
                sb.Append("<p>");
                if (ForAgent != null && ForAgent.Length > 0)
                    sb.Append(string.Format("{0}: ", ForAgent));
                sb.AppendLine(HtmlDetails + "</p>");
            }
            else if (RawDetails != null && RawDetails.Length > 0)
            {
                sb.Append("<p>");
                if (ForAgent != null && ForAgent.Length > 0)
                    sb.Append(string.Format("{0}: ", ForAgent));
                sb.AppendLine(RawDetails + "</p>");
            }
            if (ChildStates != null && ChildStates.Count > 0)
            {
                sb.AppendLine("<ul>");
                if (ChildStates != null)
                {
                    foreach (MonitorState ms in ChildStates)
                    {
                        sb.Append("<li>" + ms.ReadAllHtmlDetails() + "</li>");
                    }
                }
                sb.AppendLine("</ul>");
            }
            return sb.ToString();
        }
    }
}
