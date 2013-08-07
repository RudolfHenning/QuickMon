using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

//based on code found at CodeProject
//from Tom Janssens http://www.codeproject.com/Articles/19071/Quick-tool-A-minimalistic-Telnet-library 

namespace QuickMon
{
    public class SocketPing : CollectorBase
    {
        public SocketPing() : base() { }

        
        private SocketPingConfig socketPingConfig = new SocketPingConfig();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            long pingTotalTime = 0;
            int pingErrors = 0;
            int pingSuccesses = 0;
            LastDetailMsg.PlainText = "Pinging hosts";
            htmlTextTextDetails.AppendLine("<ul>");
            LastError = 0;
            LastErrorMsg = "";
            try
            {
                foreach (SocketPingEntry entry in socketPingConfig.Entries)
                {
                    lastAction = "Pinging " + entry.HostName;
                    int pingTime = entry.Ping();
                    if (pingTime >= entry.PingTimeOutMS) //if any time-out then it is an error
                    {
                        LastDetailMsg.PlainText = "Time-out pinging " + entry.HostName;
                        plainTextDetails.AppendLine(string.Format("Ping {0}: {1}ms - Warning", entry.HostName, pingTime));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Ping {0}: {1}ms - <b>Warning</b></li>", entry.HostName, pingTime));
                        pingErrors++;
                    }                    
                    else
                    {
                        plainTextDetails.AppendLine(string.Format("Ping {0}: {1}ms - Good", entry.HostName, pingTime));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Ping {0}: {1}ms - <b>Good</b></li>", entry.HostName, pingTime));
                        pingTotalTime += pingTime;
                        pingSuccesses++;
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
                LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
                LastDetailMsg.LastValue = pingTotalTime;
                if (pingErrors == 0 && pingSuccesses >= 0)
                    returnState = MonitorStates.Good;
                else if (pingErrors > 0 && pingSuccesses > 0)
                    returnState = MonitorStates.Warning;
                else
                    returnState = MonitorStates.Error;
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
            showDetails.SocketPingConfig = socketPingConfig;
            showDetails.Text = "Show details - " + collectorName;
            showDetails.Show();
        }

        public override string ConfigureAgent(string config)
        {
            XmlDocument configDoc = new XmlDocument();
            if (config.Length > 0)
                configDoc.LoadXml(config);
            else
                configDoc.LoadXml(GetDefaultOrEmptyConfigString());
            ReadConfiguration(configDoc);
            EditConfig editConfig = new EditConfig();
            editConfig.SelectedSocketPingConfig = socketPingConfig;
            if (editConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config = editConfig.SelectedSocketPingConfig.ToConfig();
            }

            return config;
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SocketPingEmptyConfig_xml;
        }

        public override void ReadConfiguration(System.Xml.XmlDocument configDoc)
        {
            socketPingConfig.ReadConfiguration(configDoc);
        }
    }
}
