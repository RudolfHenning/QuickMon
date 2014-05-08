using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class BizTalkPortAndOrchs : CollectorBase
    {
        internal BizTalkGroup BizTalkGroup = new BizTalkGroup();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            CollectorMessage details = new CollectorMessage();            

            LastDetailMsg.HtmlText = "";
            LastDetailMsg.PlainText = "Getting Ports and Orchestration states and counts";
			LastError = 0;
			LastErrorMsg = "";		
			try
			{
                LastDetailMsg.PlainText = "Getting Receive Location count";
                int receiveLocationCount = BizTalkGroup.AllReceiveLocations ? BizTalkGroup.GetTotalReceiveLocationCount() : BizTalkGroup.ReceiveLocations.Count;
                LastDetailMsg.PlainText = "Getting Disabled Receive Location count";
                int receiveLocationsDisabled = BizTalkGroup.AllReceiveLocations ? BizTalkGroup.GetDisabledReceiveLocationCount(new List<string>()) : BizTalkGroup.GetDisabledReceiveLocationCount(BizTalkGroup.ReceiveLocations);
                //Now check send ports
                LastDetailMsg.PlainText = "Getting Send Port count";
                int sendPortCount = BizTalkGroup.AllSendPorts ? BizTalkGroup.GetTotalSendPortCount() : BizTalkGroup.SendPorts.Count;
                LastDetailMsg.PlainText = "Getting Stopped Send Port count";
                int sendPortStoppedCount = BizTalkGroup.AllSendPorts ? BizTalkGroup.GetStoppedSendPortCount(new List<string>()) : BizTalkGroup.GetStoppedSendPortCount(BizTalkGroup.SendPorts);
                //Now check orchestrations
                LastDetailMsg.PlainText = "Getting Orchestration count";
                int orchestrationCount = BizTalkGroup.AllOrchestrations ? BizTalkGroup.GetTotalOrchestrationCount() : BizTalkGroup.Orchestrations.Count;
                LastDetailMsg.PlainText = "Getting Stopped Orchestration count";
                int orchestrationStoppedCount = BizTalkGroup.AllOrchestrations ? BizTalkGroup.GetStoppedOrchestrationCount(new List<string>()) : BizTalkGroup.GetStoppedOrchestrationCount(BizTalkGroup.Orchestrations);

                if (receiveLocationsDisabled == -1 || sendPortStoppedCount == -1 || orchestrationStoppedCount == -1)
                {
                    returnState = MonitorStates.Error;
                    details.PlainText = "An error occured trying to query the BizTalk Management database!";
                    details.HtmlText = "<blockquote>An error occured trying to query the BizTalk Management database!</blockquote>";
                }
                else
                {
                    if ((receiveLocationsDisabled >= receiveLocationCount && (receiveLocationCount > 0)) ||
                        (sendPortStoppedCount >= sendPortCount && (sendPortCount > 0)) || 
                        (orchestrationStoppedCount >= orchestrationCount && (orchestrationCount > 0)))
                    {
                        returnState = MonitorStates.Error;

                    }
                    else if (receiveLocationsDisabled > 0 || sendPortStoppedCount > 0 || orchestrationStoppedCount > 0)
                    {
                        returnState = MonitorStates.Warning;
                    }
                    details.PlainText = "Getting summary of current states";
                    details = GetSummaryOfDisabledOrStopped();
                }
                LastDetailMsg = details;
            }
            catch (Exception ex)
            {
                LastError = 1;
                LastErrorMsg = ex.Message;
                LastDetailMsg.PlainText = string.Format("Last step: {0}\r\n{1}", LastDetailMsg.PlainText, ex.Message);
                LastDetailMsg.HtmlText = string.Format("<blockquote>Last step: {0}<br />{1}</blockquote>", LastDetailMsg.PlainText, ex.Message);

                returnState = MonitorStates.Error;
            }
            return returnState;
        }

        private CollectorMessage GetSummaryOfDisabledOrStopped()
        {
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            int count = 0;
            plainTextDetails.AppendLine("Disabled Receive Locations");
            htmlTextTextDetails.AppendLine("<b>Disabled Receive Locations</b>\r\n<ul>");
            foreach (string rl in BizTalkGroup.GetDisabledReceiveLocationNames())
            {
                plainTextDetails.AppendLine(string.Format("\t{0}", rl));
                htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", rl));
                count++;
            }
            if (count == 0)
            {
                plainTextDetails.AppendLine("\tNone");
                htmlTextTextDetails.AppendLine("<li>None</li>");
            }
            htmlTextTextDetails.AppendLine("</ul>");

            count = 0;
            plainTextDetails.AppendLine("Stopped Send Ports");
            htmlTextTextDetails.AppendLine("<b>Stopped Send Ports</b>\r\n<ul>");
            foreach (string s in BizTalkGroup.GetStoppedSendPortNames())
            {
                plainTextDetails.AppendLine(string.Format("\t{0}", s));
                htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", s));
                count++;
            }
            if (count == 0)
            {
                plainTextDetails.AppendLine("\tNone");
                htmlTextTextDetails.AppendLine("<li>None</li>");
            }
            htmlTextTextDetails.AppendLine("</ul>");

            count = 0;
            plainTextDetails.AppendLine("Stopped Orchestrations");
            htmlTextTextDetails.AppendLine("<b>Stopped Orchestrations</b>\r\n<ul>");
            foreach (string s in BizTalkGroup.GetStoppedOrchestrationNames())
            {
                plainTextDetails.AppendLine(string.Format("\t{0}", s));
                htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", s));
                count++;
            }
            if (count == 0)
            {
                plainTextDetails.AppendLine("\tNone");
                htmlTextTextDetails.AppendLine("<li>None</li>");
            }
            htmlTextTextDetails.AppendLine("</ul>");

            return new CollectorMessage() { PlainText = plainTextDetails.ToString(), HtmlText = htmlTextTextDetails.ToString() };
        }

        public override void ShowStatusDetails(string collectorName)
        {
            ShowDetails showDetails = new ShowDetails();
            showDetails.BizTalkGroup = BizTalkGroup;
            showDetails.Text = "Show details - " + collectorName;
            showDetails.Show();
        }

        public override string ConfigureAgent(string config)
        {
            XmlDocument configXml = new XmlDocument();
            if (config.Length > 0)
                configXml.LoadXml(config);
            else
                configXml.LoadXml(GetDefaultOrEmptyConfigString());
            ReadConfiguration(configXml);
            EditConfig editConfig = new EditConfig();
            editConfig.BizTalkGroup = BizTalkGroup;
            if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
            {
                XmlNode root = configXml.DocumentElement.SelectSingleNode("bizTalkGroup");
                root.SetAttributeValue("sqlServer", editConfig.BizTalkGroup.SqlServer);
                root.SetAttributeValue("mgmtDb", editConfig.BizTalkGroup.MgmtDBName);
                root.SetAttributeValue("allReceiveLocations", editConfig.BizTalkGroup.AllReceiveLocations.ToString());
                root.SetAttributeValue("allSendPorts", editConfig.BizTalkGroup.AllSendPorts.ToString());
                root.SetAttributeValue("allOrchestrations", editConfig.BizTalkGroup.AllOrchestrations.ToString());

                //Receive locations
                XmlNode receiveLocationsNode = root.SelectSingleNode("receiveLocations");
                receiveLocationsNode.InnerXml = "";
                foreach (string rl in editConfig.BizTalkGroup.ReceiveLocations)
                {
                    XmlElement receiveLocationNode = configXml.CreateElement("receiveLocation");
                    receiveLocationNode.SetAttributeValue("name", rl);
                    receiveLocationsNode.AppendChild(receiveLocationNode);
                }

                //Send ports
                XmlNode sendPortsNode = root.SelectSingleNode("sendPorts");
                sendPortsNode.InnerXml = "";
                foreach (string s in editConfig.BizTalkGroup.SendPorts)
                {
                    XmlElement sendPortNode = configXml.CreateElement("sendPort");
                    sendPortNode.SetAttributeValue("name", s);
                    sendPortsNode.AppendChild(sendPortNode);
                }

                //Orchestrations
                XmlNode orchestrationsNode = root.SelectSingleNode("orchestrations");
                orchestrationsNode.InnerXml = "";
                foreach (string s in editConfig.BizTalkGroup.Orchestrations)
                {
                    XmlElement orchestrationNode = configXml.CreateElement("orchestration");
                    orchestrationNode.SetAttributeValue("name", s);
                    orchestrationsNode.AppendChild(orchestrationNode);
                }

                config = configXml.OuterXml;
            }
            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.BizTalkPortAndOrchEmptyConfig_xml;
        }

        public override void ReadConfiguration(XmlDocument config)
        {
            XmlNode root = config.DocumentElement.SelectSingleNode("bizTalkGroup");
            BizTalkGroup.SqlServer = root.ReadXmlElementAttr("sqlServer", ".");
            BizTalkGroup.MgmtDBName = root.ReadXmlElementAttr("mgmtDb", "BizTalkMgmtDb");
            BizTalkGroup.AllReceiveLocations = bool.Parse(root.ReadXmlElementAttr("allReceiveLocations", "True"));
            BizTalkGroup.AllSendPorts = bool.Parse(root.ReadXmlElementAttr("allSendPorts", "True"));
            BizTalkGroup.AllOrchestrations = bool.Parse(root.ReadXmlElementAttr("allOrchestrations", "True"));
            BizTalkGroup.ReceiveLocations = new List<string>();
            foreach (XmlElement receiveLocationNode in root.SelectNodes("receiveLocations/receiveLocation"))
            {
                string receiveLocationName = receiveLocationNode.ReadXmlElementAttr("name");
                if (receiveLocationName.Length > 0)
                    BizTalkGroup.ReceiveLocations.Add(receiveLocationName);
            }
            BizTalkGroup.SendPorts = new List<string>();
            foreach (XmlElement sendPortNode in root.SelectNodes("sendPorts/sendPort"))
            {
                string sendPortName = sendPortNode.ReadXmlElementAttr("name");
                if (sendPortName.Length > 0)
                    BizTalkGroup.SendPorts.Add(sendPortName);
            }
            BizTalkGroup.Orchestrations = new List<string>();
            foreach (XmlElement orchestrationNode in root.SelectNodes("orchestrations/orchestration"))
            {
                string orchestrationName = orchestrationNode.ReadXmlElementAttr("name");
                if (orchestrationName.Length > 0)
                    BizTalkGroup.Orchestrations.Add(orchestrationName);
            }
        }

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return (ICollectorDetailView)(new ShowDetails());
        }
    }
}
