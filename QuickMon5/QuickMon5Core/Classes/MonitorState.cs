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
            ScriptsRan = new List<string>();
            AlertHeader = "";
            AlertFooter = "";
            AdditionalAlertText = "";
            RawDetails = "";
            HtmlDetails = "";
            ForAgent = "";
            ForAgentType = "";
            RepeatCount = 0;
            PrimaryUIValue = false;
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
        [DataMember(Name = "CurrentValueUnit")]
        public string CurrentValueUnit { get; set; }

        [DataMember(Name = "ForAgent")]
        public string ForAgent { get; set; }
        [DataMember(Name = "ForAgentType")]
        public string ForAgentType { get; set; }
        [DataMember(Name = "ForAgentId")]
        public int ForAgentId { get; set; }


        [DataMember(Name = "AlertHeader")]
        public string AlertHeader { get; set; }
        [DataMember(Name = "AlertFooter")]
        public string AlertFooter { get; set; }
        [DataMember(Name = "AdditionalAlertText")]
        public string AdditionalAlertText { get; set; }

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
        public List<string> ScriptsRan { get; set; }
        [DataMember(Name = "RanAs")]
        public string RanAs { get; set; }
        /// <summary>
        /// When Polling overrides are enabled new MonitorStates are suppressed
        /// RepeatCount = 0 means it ran once
        /// </summary>
        [DataMember(Name = "RepeatCount")]
        public int RepeatCount { get; set; }
        [DataMember(Name = "PrimaryUIValue")]
        public bool PrimaryUIValue { get; set; }

        public MonitorState Clone()
        {
            List<string> cloneAlerts = new List<string>();
            if (AlertsRaised != null)
                cloneAlerts.AddRange(AlertsRaised.ToArray());
            List<string> cloneScripts = new List<string>();
            if (ScriptsRan != null)
                cloneScripts.AddRange(ScriptsRan.ToArray());
            return new MonitorState()
            {
                State = this.State,
                CurrentValue = this.CurrentValue,
                CurrentValueUnit = this.CurrentValueUnit,
                ForAgent = this.ForAgent,
                ForAgentType = this.ForAgentType,
                RawDetails = this.RawDetails,
                HtmlDetails = this.HtmlDetails,
                Timestamp = this.Timestamp,
                StateChangedTime = this.StateChangedTime,
                CallDurationMS = this.CallDurationMS,
                ExecutedOnHostComputer = this.ExecutedOnHostComputer,
                AlertsRaised = cloneAlerts,
                ScriptsRan = cloneScripts,
                AdditionalAlertText = this.AdditionalAlertText,
                AlertHeader = this.AlertHeader,
                AlertFooter = this.AlertFooter,
                RanAs = this.RanAs,
                RepeatCount = this.RepeatCount,
                PrimaryUIValue = this.PrimaryUIValue
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
            root.SetAttributeValue("forAgentType", ForAgentType);
            root.SetAttributeValue("forAgentId", ForAgentId);
            root.SetAttributeValue("timeStamp", Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
            root.SetAttributeValue("callDurationMS", CallDurationMS.ToString());
            root.SetAttributeValue("repeatCount", RepeatCount);
            
            if (CurrentValue != null)
                root.SetAttributeValue("currentValue", CurrentValue.ToString());
            else
                root.SetAttributeValue("currentValue", "");
            root.SetAttributeValue("primaryUIValue", PrimaryUIValue);
            root.SetAttributeValue("executedOnHostComputer", ExecutedOnHostComputer);
            root.SetAttributeValue("ranAs", RanAs);

            XmlElement alertHeaderNode = xdoc.CreateElement("alertHeader");
            alertHeaderNode.InnerText = AlertHeader;
            root.AppendChild(alertHeaderNode);
            XmlElement alertFooterNode = xdoc.CreateElement("alertFooter");
            alertFooterNode.InnerText = AlertFooter;
            root.AppendChild(alertFooterNode);
            XmlElement additionalAlertTextNode = xdoc.CreateElement("additionalAlertText");
            additionalAlertTextNode.InnerText = AdditionalAlertText;
            root.AppendChild(additionalAlertTextNode);

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

            XmlElement scriptsRanElement = xdoc.CreateElement("scriptsRan");
            foreach (string scriptName in ScriptsRan)
            {
                XmlElement scriptNode = xdoc.CreateElement("script");
                scriptNode.InnerText = scriptName;
                scriptsRanElement.AppendChild(scriptNode);
            }
            root.AppendChild(scriptsRanElement);
            

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
            ForAgentType = root.ReadXmlElementAttr("forAgentType", "");
            ForAgentId = root.ReadXmlElementAttr("forAgentId", -1);
            CurrentValue = root.ReadXmlElementAttr("currentValue", "");
            PrimaryUIValue = root.ReadXmlElementAttr("primaryUIValue", false);
            ExecutedOnHostComputer = root.ReadXmlElementAttr("executedOnHostComputer", "");
            RanAs = root.ReadXmlElementAttr("ranAs", "");
            RepeatCount = root.ReadXmlElementAttr("repeatCount", 0);
            try
            {
                AlertHeader = root.SelectSingleNode("alertHeader").InnerText;
            }
            catch { }
            try
            {
                AlertFooter = root.SelectSingleNode("alertFooter").InnerText;
            }
            catch { }
            try
            {
                AdditionalAlertText = root.SelectSingleNode("additionalAlertText").InnerText;
            }
            catch { }

            RawDetails = root.SelectSingleNode("rawDetails").InnerText;
            HtmlDetails = root.SelectSingleNode("htmlDetails").InnerText;
            XmlNodeList alertNodes = root.SelectNodes("alerts");
            AlertsRaised = new List<string>();
            foreach (XmlNode alertNode in alertNodes)
            {
                if (alertNode.InnerText.Trim().Length > 0)
                    AlertsRaised.Add(alertNode.InnerText);
            }

            XmlNodeList scriptsRanNodes = root.SelectNodes("scriptsRan");
            ScriptsRan = new List<string>();
            foreach (XmlNode scriptNode in scriptsRanNodes)
            {
                if (scriptNode.InnerText.Trim().Length > 0)
                    ScriptsRan.Add(scriptNode.InnerText);
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

            if (AlertHeader != null && AlertHeader.Trim().Length > 0)
            {
                sb.AppendLine(new string(linePaddingChar, linePaddingRepeat) + AlertHeader);
            }
            if (AdditionalAlertText != null && AdditionalAlertText.Trim().Length > 0)
            {
                sb.AppendLine(new string(linePaddingChar, linePaddingRepeat) + AdditionalAlertText);
            }
            if (ForAgent != null && ForAgent.Length > 0)
            {
                prePadding += string.Format("{0}: ", ForAgent);
                if (State == CollectorState.Good || State == CollectorState.Warning || State == CollectorState.Error || State == CollectorState.Disabled || State == CollectorState.ConfigurationError)
                {
                    if (CurrentValue != null)
                    {
                        prePadding += string.Format("{0} ", CurrentValue);
                        if (CurrentValue.ToString().Length > 0 && CurrentValueUnit != null && CurrentValueUnit.Length > 0)
                        {
                            prePadding += string.Format("{0} ", CurrentValueUnit);
                        }
                    }
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

            if (ScriptsRan != null && ScriptsRan.Count > 0)
            {
                sb.AppendLine((new string(linePaddingChar, linePaddingRepeat)) + "Scripts ran:");
                foreach (string scriptName in ScriptsRan)
                {
                    sb.AppendLine((new string(linePaddingChar, linePaddingRepeat + 1)) + scriptName);
                }
            }

            if (ChildStates != null)
            {
                foreach (MonitorState ms in ChildStates)
                {
                    sb.AppendLine(ms.ReadAllRawDetails(linePaddingChar, linePaddingRepeat));
                }
            }    
            if (AlertFooter != null && AlertFooter.Trim().Length > 0)
            {
                sb.AppendLine(new string(linePaddingChar, linePaddingRepeat) + AlertFooter);
            }
            return sb.ToString().TrimEnd();
        }
        public string ReadAllHtmlDetails()
        {
            StringBuilder sb = new StringBuilder();

            if (AlertHeader != null && AlertHeader.Trim().Length > 0)
            {
                sb.Append("<p><b>" + AlertHeader + "</b></p>");
            }
            if (AdditionalAlertText != null && AdditionalAlertText.Trim().Length > 0)
            {
                sb.Append("<p>" + AdditionalAlertText + "</p>");
            }
            if ((ForAgent != null && ForAgent.Length > 0) || (HtmlDetails != null && HtmlDetails.Length > 0) || (RawDetails != null && RawDetails.Length > 0))
            {
                sb.Append("<p>");
                if (ForAgent != null && ForAgent.Length > 0)
                {
                    sb.Append(string.Format("{0}: ", ForAgent));
                    if (State == CollectorState.Good || State == CollectorState.Warning || State == CollectorState.Error || State == CollectorState.Disabled || State == CollectorState.ConfigurationError)
                    {
                        if (CurrentValue != null)
                        {
                            sb.Append(string.Format("{0} ", CurrentValue));
                            if (CurrentValueUnit != null && CurrentValueUnit.Length > 0)
                            {
                                sb.Append(string.Format("{0} ", CurrentValueUnit));
                            }
                        }
                        if (State == CollectorState.Error || State == CollectorState.ConfigurationError || State == CollectorState.Warning)
                            sb.Append(string.Format("(<b>{0}</b>) ", State));
                        else
                            sb.Append(string.Format("({0}) ", State));
                    }
                }
                if (HtmlDetails != null && HtmlDetails.Length > 0)
                    sb.AppendLine(HtmlDetails + "</p>");
                else if (RawDetails != null && RawDetails.Length > 0)
                    sb.AppendLine(RawDetails + "</p>");
                else
                    sb.AppendLine("</p>");
                
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
            if (AlertFooter != null && AlertFooter.Trim().Length > 0)
            {
                sb.AppendLine("<p>" + AlertFooter + "</p>");
            }
            return sb.ToString();
        }

        public string FormatValue()
        {
            StringBuilder sb = new StringBuilder();
            if (CurrentValue != null)
            {
                sb.Append(CurrentValue.ToString());
                if (CurrentValueUnit != null && CurrentValueUnit.Length > 0)
                {
                    sb.Append(" " + CurrentValueUnit);
                }             
            }
            return sb.ToString();
        }
        public string ReadPrimaryOrFirstUIValue(bool includeUnit = true)
        {
            string output = ReadPrimaryUIValue(includeUnit);
            if (output == null || output.Trim().Length == 0)
                output = ReadFirstValue(includeUnit);
            return output;
        }
        public string ReadPrimaryUIValue(bool includeUnit = true)
        {
            StringBuilder sb = new StringBuilder();
            if (CurrentValue != null && PrimaryUIValue)
            {
                string[] lines = CurrentValue.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length > 0)
                {
                    sb.Append(lines[0]); // CurrentValue.ToString());
                    if (includeUnit && CurrentValueUnit != null && CurrentValueUnit.Length > 0)
                    {
                        sb.Append(" " + CurrentValueUnit);
                    }
                }
            }
            else
            {
                foreach (MonitorState cs in ChildStates)
                {
                    string scValue = cs.ReadPrimaryUIValue(includeUnit);
                    if (scValue.Length > 0)
                    {
                        sb.Append(scValue);
                        break;
                    }
                }
            }
            return sb.ToString();
        }
        public string ReadFirstValue(bool includeUnit = true)
        {
            StringBuilder sb = new StringBuilder();
            if (CurrentValue != null)
            {
                string[] lines = CurrentValue.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length > 0)
                {
                    sb.Append(lines[0]); // CurrentValue.ToString());
                    if (includeUnit && CurrentValueUnit != null && CurrentValueUnit.Length > 0)
                    {
                        sb.Append(" " + CurrentValueUnit);
                    }
                }               
            }
            else if (ChildStates.Count > 0)
            {
                foreach (MonitorState cs in ChildStates)
                {
                    string scValue = cs.ReadFirstValue(includeUnit);
                    if (scValue.Length > 0)
                    {
                        sb.Append(scValue);
                        break;
                    }
                }
            }
            return sb.ToString();
        }
        public string ReadFirstValueUnit()
        {
            StringBuilder sb = new StringBuilder();
            if (CurrentValue != null)
            {
                if (CurrentValueUnit != null)
                    sb.Append(CurrentValueUnit);
                else
                    sb.Append("");
            }
            else if (ChildStates.Count > 0)
            {
                foreach (MonitorState cs in ChildStates)
                {
                    string scValue = cs.ReadFirstValueUnit();
                    if (scValue.Length > 0)
                    {
                        sb.Append(scValue);
                        break;
                    }
                }
            }
            return sb.ToString();
        }
        public string ReadValues(bool trimCrLf = true)
        {
            StringBuilder sb = new StringBuilder();
            if (CurrentValue != null)
            {
                sb.Append(CurrentValue.ToString());
                if (CurrentValueUnit != null && CurrentValueUnit.Length > 0)
                {
                    sb.Append(" " + CurrentValueUnit);
                }
                sb.AppendLine();
            }
            foreach(MonitorState cs in ChildStates)
            {
                string scValue = cs.ReadValues(false);
                if (scValue.Length > 0)
                    sb.AppendLine(scValue);
            }
            if (trimCrLf)
                return sb.ToString().Trim('\r','\n');
            else
            return sb.ToString();
        }
        public string ReadAgentValues(bool trimCrLf = true)
        {
            StringBuilder sb = new StringBuilder();
            if (CurrentValue != null)
            {
                sb.Append(ForAgent + " : " + CurrentValue.ToString());
                if (CurrentValueUnit != null && CurrentValueUnit.Length > 0)
                {
                    sb.Append(" " + CurrentValueUnit);
                }
                sb.AppendLine();
            }
            foreach (MonitorState cs in ChildStates)
            {
                string scValue = cs.ReadAgentValues(true);
                if (scValue.Length > 0)
                    sb.AppendLine(scValue);
            }
            if (trimCrLf)
                return sb.ToString().Trim('\r', '\n');
            else
                return sb.ToString();
        }
    }
}
