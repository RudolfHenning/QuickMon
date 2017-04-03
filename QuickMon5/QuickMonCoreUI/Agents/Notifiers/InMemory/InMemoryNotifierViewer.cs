using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;
using QuickMon.Notifiers;
using HenIT.RTF;

namespace QuickMon.UI
{
    public partial class InMemoryNotifierViewer : NotifierViewerBase // FadeSnapForm, INotivierViewer, IChildWindowIdentity
    {
        public InMemoryNotifierViewer()
        {
            InitializeComponent();
        }
        
        private AlertRaised lastAlert = null;
        private bool busyRefreshing = false;

        public override void RefreshDisplayData()
        {
            if (SelectedNotifier != null)
            {
                busyRefreshing = true;
                Text = "In Memory Notifier Viewer - " + SelectedNotifier.Name;
                InMemoryNotifier thisNotifier = (InMemoryNotifier)SelectedNotifier;
                if (thisNotifier.Alerts != null)
                {
                    RTFBuilder rtfBuilder = new RTFBuilder();
                    if (thisNotifier.Alerts.Count == 0)
                    {

                    }
                    else
                    {
                        if (lastAlert != null && lastAlert.RaisedTime == thisNotifier.Alerts[thisNotifier.Alerts.Count - 1].RaisedTime)
                        {
                            busyRefreshing = false;
                            return;
                        }
                        else if (thisNotifier.Alerts.Count > 0)
                            lastAlert = thisNotifier.Alerts[thisNotifier.Alerts.Count - 1];


                        for (int i = thisNotifier.Alerts.Count - 1; i >= 0; i--)
                        {
                            AlertRaised alertRaised = thisNotifier.Alerts[i];
                            rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("***** ALERT *****");
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Time: ");
                            rtfBuilder.Append(string.Format("{0}:", alertRaised.RaisedTime.ToString("yyyy-MM-dd HH:mm:ss")));
                            rtfBuilder.AppendLine().FontStyle(FontStyle.Bold).Append("Alert Level: ");
                            if (alertRaised.Level == AlertLevel.Error)
                            {
                                rtfBuilder.ForeColor(Color.DarkRed);
                            }
                            else if (alertRaised.Level == AlertLevel.Warning)
                            {
                                rtfBuilder.ForeColor(Color.DarkOrange);
                            }
                            rtfBuilder.Append(string.Format(" {0}", alertRaised.Level));
                            rtfBuilder.FontStyle(FontStyle.Regular).ForeColor(SystemColors.ControlText);

                            string viaHost = "";
                            if (alertRaised.RaisedFor.OverrideRemoteAgentHost)
                                viaHost = string.Format("(via {0}:{1})", alertRaised.RaisedFor.OverrideRemoteAgentHostAddress, alertRaised.RaisedFor.OverrideRemoteAgentHostPort);
                            else if (alertRaised.RaisedFor.EnableRemoteExecute)
                                viaHost = string.Format("(via {0}:{1})", alertRaised.RaisedFor.RemoteAgentHostAddress, alertRaised.RaisedFor.RemoteAgentHostPort);

                            rtfBuilder.AppendLine().FontStyle(FontStyle.Bold).Append("Collector: ");
                            rtfBuilder.AppendLine(alertRaised.RaisedFor.Name);
                            if (viaHost != null && viaHost.Length > 0)
                            {
                                rtfBuilder.FontStyle(FontStyle.Bold).Append("Via: ");
                                rtfBuilder.AppendLine(viaHost);
                            }
                            rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Alert details: ");
                            string rawMsg = alertRaised.MessageRaw.TrimEnd('\r', '\n');
                            rawMsg = "\t" + rawMsg.Replace("\r\n", "\r\n\t");
                            rtfBuilder.Append(rawMsg);

                            //rtfBuilder.Append(string.Format("{0} {1}\r\n{2}", alertRaised.RaisedFor.Name, viaHost, alertRaised.MessageRaw));

                            rtfBuilder.Append(new string('-', 50)).AppendLine();
                        }
                    }
                    alertsRichTextBox.Rtf = rtfBuilder.ToString();
                }
            }
            busyRefreshing = false;
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            RefreshDisplayData();
        }
        
        private void InMemoryNotifierViewer_Load(object sender, EventArgs e)
        {
            //SnappingEnabled = true;
            chkAutoRefresh.Checked = AutoRefreshEnabled;
        }

        private void InMemoryNotifierViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshDisplayData();
            }
        }

        private void autoRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked && !busyRefreshing)
            {
                RefreshDisplayData();
            }
        }

        private void InMemoryNotifierViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DeRegisterChildWindow();
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            AutoRefreshEnabled = chkAutoRefresh.Checked;
        }
    }
}
