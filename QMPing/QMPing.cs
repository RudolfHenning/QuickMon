using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
	public class Ping : CollectorBase
	{
		public Ping() : base() { }

		private List<HostEntry> hostEntries = new List<HostEntry>();

		public override MonitorStates GetState()
		{
			MonitorStates returnState = MonitorStates.Good;
			StringBuilder plainTextDetails = new StringBuilder();
			StringBuilder htmlTextTextDetails = new StringBuilder();
			string lastAction = "";
			LastDetailMsg.PlainText = "Pinging hosts";
			htmlTextTextDetails.AppendLine("<ul>");
			LastError = 0;
			LastErrorMsg = "";
			try
			{
				foreach (HostEntry host in hostEntries)
				{
					int pingTime = -1;

					using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
					{
						lastAction = "Pinging " + host.HostName;
						System.Net.NetworkInformation.PingReply reply = ping.Send(host.HostName, host.TimeOut);

						if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
							pingTime = Convert.ToInt32(reply.RoundtripTime);
						else // if (reply.Status == System.Net.NetworkInformation.IPStatus.TimedOut)
							pingTime = int.MaxValue;

						if (pingTime >= host.TimeOut) //if any time-out then it is an error
						{
							LastDetailMsg.PlainText = "Time-out pinging " + host.HostName;
							LastErrorMsg = "Time-out pinging " + host.HostName;
							LastDetailMsg.HtmlText = string.Format("<p><b>Time-out pinging:</b> {0}</p>", host.HostName);
							return MonitorStates.Error;
						}
						else if (pingTime > host.MaxTime)
						{
							returnState = MonitorStates.Warning;
							plainTextDetails.AppendLine(string.Format("Ping {0}: {1}ms - Warning", host.HostName, pingTime));
							htmlTextTextDetails.AppendLine(string.Format("<li>Ping {0}: {1}ms - <b>Warning</b></li>", host.HostName, pingTime));
						}
						else
						{
							plainTextDetails.AppendLine(string.Format("Ping {0}: {1}ms - Good", host.HostName, pingTime));
							htmlTextTextDetails.AppendLine(string.Format("<li>Ping {0}: {1}ms - <b>Good</b></li>", host.HostName, pingTime));
						}
					}
				}
				htmlTextTextDetails.AppendLine("</ul>");
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
		public override void ShowStatusDetails()
		{
			ShowDetails showDetails = new ShowDetails();
            showDetails.HostEntries = hostEntries;
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
			return Properties.Resources.PingEmptyConfig_xml;
		}

		public override void ReadConfiguration(XmlDocument config)
		{
			hostEntries = new List<HostEntry>();
			XmlElement root = config.DocumentElement;
			foreach (XmlElement host in root.SelectNodes("hosts/host"))
			{
				HostEntry hostEntry = new HostEntry();
				hostEntry.HostName = host.Attributes.GetNamedItem("hostName").Value;
				hostEntry.Description = host.Attributes.GetNamedItem("description").Value;
				int tmp = 0;
				if (int.TryParse(host.Attributes.GetNamedItem("maxTime").Value, out tmp))
					hostEntry.MaxTime = tmp;
				if (int.TryParse(host.Attributes.GetNamedItem("timeOut").Value, out tmp))
					hostEntry.TimeOut = tmp;
				hostEntries.Add(hostEntry);
			}
		}		
	}
}
