using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.RTF;
using QuickMon.Constants;

namespace QuickMon.Notifiers
{
    public partial class InMemoryNotifierViewer : Form, INotivierViewer
    {
        private InMemoryNotifier notifierInstance;
        private AlertRaised lastAlert = null;

        public InMemoryNotifierViewer()
        {
            InitializeComponent();
        }

        #region INotivierViewer Members

        public void ShowNotifierViewer(INotifier notifier)
        {
            notifierInstance = (InMemoryNotifier)notifier;
            Show();
            RefreshDisplayData();
        }

        public void RefreshConfig(INotifier notifier)
        {
            notifierInstance = (InMemoryNotifier)notifier;
            RefreshDisplayData();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
        }

        public bool IsStillVisible()
        {
            return (!(this.Disposing || this.IsDisposed)) && this.Visible;
        }

        public void SetWindowTitle(string title)
        {
            this.Text = title;
        }

        public void CloseWindow()
        {
            this.Close();
        }
        public void LoadDisplayData()
        {
            //nothing to do
        }

        public void RefreshDisplayData()
        {
            if (notifierInstance != null && notifierInstance.Alerts != null)
            {
                RTFBuilder rtfBuilder = new RTFBuilder();
                if (notifierInstance.Alerts.Count == 0)
                {
                    
                }
                else
                {
                    if (lastAlert != null && lastAlert.RaisedTime == notifierInstance.Alerts[notifierInstance.Alerts.Count - 1].RaisedTime)
                        return;
                    else if (notifierInstance.Alerts.Count > 0)
                        lastAlert = notifierInstance.Alerts[notifierInstance.Alerts.Count - 1];

                    
                    for (int i = notifierInstance.Alerts.Count - 1; i >= 0; i--)
                    {
                        AlertRaised alertRaised = notifierInstance.Alerts[i];

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

                        rtfBuilder.Append(string.Format("\t{0} {1}\r\n{2}", alertRaised.RaisedFor, viaHost, alertRaised.State.RawDetails));
                        rtfBuilder.AppendLine();
                    }
                }
                alertsRichTextBox.Rtf = rtfBuilder.ToString();
            }
        }

        #endregion

        #region Auto refreshing
        private void StopAutoRefresh()
        {
            refreshTimer.Enabled = false;
            autoRefreshToolStripSplitButton.BackColor = Color.LightGreen;
            autoRefreshToolStripSplitButton.Image = Properties.Resources.clockBW;
            autoRefreshToolStripMenuItem.Checked = false;
        }
        private void StartAutoRefresh()
        {
            refreshTimer.Enabled = false;
            refreshTimer.Enabled = true;
            autoRefreshToolStripSplitButton.BackColor = SystemColors.Control;
            autoRefreshToolStripSplitButton.Image = Properties.Resources.clock;
            autoRefreshToolStripMenuItem.Checked = true;
        }
        private void ToggleAutoRefreshOnOff()
        {
            if (refreshTimer.Enabled)
            {
                StopAutoRefresh();
            }
            else
            {
                StartAutoRefresh();
            }
        }
        private void autoRefreshToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            ToggleAutoRefreshOnOff();
        }
        private void pollDisabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAutoRefresh();
        }
        private void pollSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = AutoFreshTimes.SlowAutoRefresh;
            StartAutoRefresh();
        }
        private void pollNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = AutoFreshTimes.NormalAutoRefresh;
            StartAutoRefresh();
        }
        private void pollFastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshTimer.Interval = AutoFreshTimes.FastAutoRefresh;
            StartAutoRefresh();
        }
        private void pollConfigureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimerConfig setTimerConfig = new SetTimerConfig();
            setTimerConfig.FrequencySec = (refreshTimer.Interval / 1000);
            setTimerConfig.TimerEnabled = refreshTimer.Enabled;
            if (setTimerConfig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                refreshTimer.Interval = setTimerConfig.FrequencySec * 1000;
                refreshTimer.Enabled = setTimerConfig.TimerEnabled;
                if (refreshTimer.Enabled)
                    StartAutoRefresh();
                else
                    StopAutoRefresh();
            }
        }
        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleAutoRefreshOnOff();
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshDisplayData();
        }
        #endregion

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDisplayData();
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDisplayData();
        }
        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all visible alerts?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                lock (notifierInstance.Alerts)
                {
                    notifierInstance.Alerts.Clear();
                }
                RefreshDisplayData();
            }
        }
       
    }
}
