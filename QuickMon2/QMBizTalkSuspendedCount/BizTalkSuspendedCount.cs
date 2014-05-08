using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
	public class BizTalkSuspendedCount : CollectorBase
	{
		internal BizTalkGroup BizTalkGroup = new BizTalkGroup();

		public override MonitorStates GetState()
		{
			MonitorStates returnState = MonitorStates.Good;
			LastDetailMsg.PlainText = "";
			LastDetailMsg.HtmlText = "";
            int instancesSuspended = 0;

			LastDetailMsg.PlainText = "Getting service states";
			LastError = 0;
			LastErrorMsg = "";			
			try
			{
				instancesSuspended = BizTalkGroup.GetSuspendedMsgsCount();
				if (instancesSuspended < BizTalkGroup.InstancesWarning)
				{
					returnState = MonitorStates.Good;
				}
				else if (instancesSuspended >= BizTalkGroup.InstancesError)
				{
					returnState = MonitorStates.Error;
				}
				else
				{
					returnState = MonitorStates.Warning;
				}
				if (instancesSuspended > 0)
				{
                    LastDetailMsg.PlainText = string.Format("Total suspended count: {0}\r\n", instancesSuspended);
                    LastDetailMsg.HtmlText = string.Format("<b>Total suspended count:</b> {0}<hr />\r\n", instancesSuspended);

					if (returnState != MonitorStates.Good && BizTalkGroup.ShowLastXDetails > 0)
					{
                        LastDetailMsg.AppendCollectorMessage(BizTalkGroup.GetLastXDetails());
					}
				}
				else
				{
                    LastDetailMsg.PlainText = "No suspended instances";
                    LastDetailMsg.HtmlText = "No suspended instances";
				}
			}
			catch (Exception ex)
			{
				LastError = 1;
				LastErrorMsg = ex.Message;
                LastDetailMsg.PlainText = ex.Message;
                LastDetailMsg.HtmlText = string.Format("<blockquote>{0}</blockquote>", ex.Message);
				
				returnState = MonitorStates.Error;
			}
			return returnState;
		}

        public override void ShowStatusDetails(string collectorName)
		{
			ShowDetails showDetails = new ShowDetails();
            showDetails.BizTalkGroup = BizTalkGroup;
            showDetails.Text = "Show details - " + collectorName;
			showDetails.ShowDetail();
		}

		public override string ConfigureAgent(string config)
		{
			EditConfig editConfig = new EditConfig();
			editConfig.CustomConfig = config;
			if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
				config = editConfig.CustomConfig;
			return config;
		}
		public override string GetDefaultOrEmptyConfigString()
		{
			return Properties.Resources.BizTalkSuspendedCountEmptyConfig_xml;
		}

		public override void ReadConfiguration(XmlDocument config)
		{            
			XmlNode root = config.DocumentElement.SelectSingleNode("bizTalkGroup");
			BizTalkGroup.SqlServer = root.ReadXmlElementAttr("sqlServer", ".");
			BizTalkGroup.MgmtDBName = root.ReadXmlElementAttr("mgmtDb", "BizTalkMgmtDb");
			BizTalkGroup.InstancesWarning = int.Parse(root.ReadXmlElementAttr("instancesWarning", "1"));
			BizTalkGroup.InstancesError = int.Parse(root.ReadXmlElementAttr("instancesError", "1"));
			BizTalkGroup.ShowLastXDetails = int.Parse(root.ReadXmlElementAttr("showLastXDetails", "0"));

			foreach (XmlElement host in root.SelectNodes("hosts/host"))
			{
				string hostName = host.ReadXmlElementAttr("name");
				if (hostName.Length > 0)
					BizTalkGroup.Hosts.Add(hostName);
			}
			foreach (XmlElement app in root.SelectNodes("apps/app"))
			{
				string appName = app.ReadXmlElementAttr("name");
				if (appName.Length > 0)
					BizTalkGroup.Apps.Add(app.Attributes.GetNamedItem("name").Value);
			}
			//bizTalkGroup.RaiseHtmlAlerts = bool.Parse(root.ReadXmlElementAttr("raiseHtmlAlerts", "True"));
		}

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return (ICollectorDetailView)(new ShowDetails());
        }
    }
}
