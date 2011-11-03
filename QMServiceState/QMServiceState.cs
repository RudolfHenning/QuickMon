using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceProcess;
using System.Diagnostics;

namespace QuickMon
{
	public class ServiceState : CollectorBase
	{
		public ServiceState() : base() { }

		private List<ServiceStateDefinition> services = new List<ServiceStateDefinition>();

		public override MonitorStates GetState()
		{
			MonitorStates returnState = MonitorStates.Good;
			Stopwatch sw = new Stopwatch();
			
			StringBuilder plainTextDetails = new StringBuilder();
			StringBuilder htmlTextTextDetails = new StringBuilder();
			string lastAction = "Getting service states";
			int errorCount = 0;
			int okCount = 0;

			LastDetailMsg.PlainText = "Getting service states";
			LastError = 0;
			LastErrorMsg = "";			
			try
			{
				foreach (ServiceStateDefinition machine in services)
				{
					List<string> runningServices = new List<string>();
					List<string> notRunningServices = new List<string>();
					sw.Restart();
					lastAction = "Getting service states on " + machine.MachineName;
					ServiceController[] allServices = ServiceController.GetServices(machine.MachineName);
					foreach (ServiceController srvc in (from s in allServices
														where machine.Services.Contains(s.DisplayName)
														select s))
					{
						lastAction = string.Format("Getting service state for {0}\\{1}", machine.MachineName, srvc.DisplayName);
						if (srvc.Status == ServiceControllerStatus.Running)
						{
							okCount++;
							runningServices.Add(srvc.DisplayName);
						}
						else
						{
							errorCount++;
							notRunningServices.Add(string.Format("{0} ({1})", srvc.DisplayName, srvc.Status));
						}
					}
					sw.Stop();
					plainTextDetails.AppendLine(string.Format("{0}", machine.MachineName));
					htmlTextTextDetails.AppendLine(string.Format("<b>{0}</b><br /><blockquote>", machine.MachineName));
					if (notRunningServices.Count > 0)
					{
						plainTextDetails.AppendLine("\tServices not running");
						htmlTextTextDetails.AppendLine("Services not running<br /><ul>");
						foreach (string item in notRunningServices)
						{
							plainTextDetails.AppendLine(string.Format("\t\t{0}", item));
							htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", item));
						}
						htmlTextTextDetails.AppendLine("</ul>");
					}
					if (runningServices.Count > 0)
					{
						plainTextDetails.AppendLine("\tServices running");
						htmlTextTextDetails.AppendLine("Services running<br /><ul>");
						foreach (string item in runningServices)
						{
							plainTextDetails.AppendLine(string.Format("\t\t{0}", item));
							htmlTextTextDetails.AppendLine(string.Format("<li>{0}</li>", item));
						}
						htmlTextTextDetails.AppendLine("</ul>");
					}
					htmlTextTextDetails.AppendLine("</blockquote>");

#if DEBUG
					Trace.WriteLine(string.Format("GetState - ServiceStates: {0} - {1}ms", machine.MachineName, sw.ElapsedMilliseconds));
#endif
				}
				if (okCount == 0 && errorCount > 0)
					returnState = MonitorStates.Error;
				else if (okCount > 0 && errorCount > 0)
					returnState = MonitorStates.Warning;

				LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
				LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
			}
			catch (Exception ex)
			{
				LastError = 1;
				LastErrorMsg = ex.Message;
				LastDetailMsg.PlainText = ex.Message;
				LastDetailMsg.HtmlText = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
				returnState = MonitorStates.Error;
			}
			
			return returnState;
		}

		public override void ShowStatusDetails(string collectorName)
		{
			ShowDetails showDetails = new ShowDetails();
			showDetails.Services = services;
			showDetails.Text = "Show details - " + collectorName;
			showDetails.ShowDetail();
		}

		public override string ConfigureAgent(string config)
		{
			EditConfig editConfig = new EditConfig();
			editConfig.CustomConfig = config;
			if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
			{
				config = editConfig.CustomConfig;
			}
			return config;
		}
		public override string GetDefaultOrEmptyConfigString()
		{
			return Properties.Resources.ServiceStateEmptyConfig_xml;
		}

		public override void ReadConfiguration(XmlDocument config)
		{
			services = new List<ServiceStateDefinition>();
			XmlElement root = config.DocumentElement;
			foreach (XmlElement machine in root.SelectNodes("machine"))
			{
				ServiceStateDefinition serviceStateDefinition = new ServiceStateDefinition();
				serviceStateDefinition.MachineName = machine.Attributes.GetNamedItem("name").Value;
				serviceStateDefinition.Services = new List<string>();
				foreach (XmlElement service in machine.SelectNodes("service"))
				{
					serviceStateDefinition.Services.Add(service.Attributes.GetNamedItem("name").Value);					
				}
				services.Add(serviceStateDefinition);
			}
		}		
	}
}
