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
    public partial class InMemoryNotifierViewer : Form, INotivierViewer
    {
        public InMemoryNotifierViewer()
        {
            InitializeComponent();
        }
        
        public INotifier SelectedNotifier { get; set; }
        private AlertRaised lastAlert = null;

        public bool IsViewerStillVisible()
        {
            return this.IsStillVisible();
        }

        public void ShowNotifierViewer()
        {
            if (SelectedNotifier != null)
            {
                Text = "In Memory Notifier Viewer - " + SelectedNotifier.Name;
            }
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
            RefreshDisplayData();
        }

        private void RefreshDisplayData()
        {
            if (SelectedNotifier != null)
            {
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
                            return;
                        else if (thisNotifier.Alerts.Count > 0)
                            lastAlert = thisNotifier.Alerts[thisNotifier.Alerts.Count - 1];


                        for (int i = thisNotifier.Alerts.Count - 1; i >= 0; i--)
                        {
                            AlertRaised alertRaised = thisNotifier.Alerts[i];

                            rtfBuilder.Append(string.Format("{0}:", alertRaised.RaisedTime.ToString("yyyy-MM-dd HH:mm:ss"))).FontStyle(FontStyle.Bold);
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

                            rtfBuilder.Append(string.Format("\t{0} {1}\r\n{2}", alertRaised.RaisedFor, viaHost, alertRaised.MessageRaw));
                            rtfBuilder.AppendLine();
                        }
                    }
                    alertsRichTextBox.Rtf = rtfBuilder.ToString();
                }
            }
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            RefreshDisplayData();
        }
    }
}
