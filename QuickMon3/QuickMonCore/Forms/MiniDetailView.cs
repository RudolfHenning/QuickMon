using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Constants;

namespace QuickMon.Forms
{
    public class MiniDetailView : BaseDetailView
    {
        public MiniDetailView()
        {
            LocalInitializeComponent();
        }
        public bool ExportButtonVisible 
        {
            get { return toolStripButtonExportData.Visible; }
            set { toolStripButtonExportData.Visible = value; } 
        }

        #region UI Components
        public System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSplitButton autoRefreshToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem pollDisabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollSlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollFastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollConfigureToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripButtonExportData;
        public System.Windows.Forms.Timer refreshTimer;
        public System.Windows.Forms.ContextMenuStrip refreshContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDetails;
        private System.ComponentModel.IContainer components = null;

        private void LocalInitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.autoRefreshToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.pollDisabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollConfigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonExportData = new ToolStripButton();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefreshToolStripMenuItem = new ToolStripMenuItem();

            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain.SuspendLayout();
            this.refreshContextMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();            

            // 
            // toolStrip1
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.autoRefreshToolStripSplitButton,
            this.toolStripButtonExportData });
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStrip1";
            this.toolStripMain.Size = new System.Drawing.Size(500, 39);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            this.toolStripMain.TabStop = true;
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::QuickMon.Properties.Resources.doc_refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // autoRefreshToolStripSplitButton
            // 
            this.autoRefreshToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.autoRefreshToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollDisabledToolStripMenuItem,
            this.pollSlowToolStripMenuItem,
            this.pollNormalToolStripMenuItem,
            this.pollFastToolStripMenuItem,
            this.pollConfigureToolStripMenuItem});
            this.autoRefreshToolStripSplitButton.Image = global::QuickMon.Properties.Resources.clockBW;
            this.autoRefreshToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoRefreshToolStripSplitButton.Name = "autoRefreshToolStripSplitButton";
            this.autoRefreshToolStripSplitButton.Size = new System.Drawing.Size(48, 36);
            this.autoRefreshToolStripSplitButton.Text = "Auto refresh";
            this.autoRefreshToolStripSplitButton.ButtonClick += new System.EventHandler(this.autoRefreshToolStripSplitButton_ButtonClick);
            // 
            // pollDisabledToolStripMenuItem
            // 
            this.pollDisabledToolStripMenuItem.Name = "pollDisabledToolStripMenuItem";
            this.pollDisabledToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pollDisabledToolStripMenuItem.Text = "Stop";
            this.pollDisabledToolStripMenuItem.Click += new System.EventHandler(this.pollDisabledToolStripMenuItem_Click);
            // 
            // pollSlowToolStripMenuItem
            // 
            this.pollSlowToolStripMenuItem.Name = "pollSlowToolStripMenuItem";
            this.pollSlowToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pollSlowToolStripMenuItem.Text = "Slow";
            this.pollSlowToolStripMenuItem.Click += new System.EventHandler(this.pollSlowToolStripMenuItem_Click);
            // 
            // pollNormalToolStripMenuItem
            // 
            this.pollNormalToolStripMenuItem.Name = "pollNormalToolStripMenuItem";
            this.pollNormalToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pollNormalToolStripMenuItem.Text = "Normal";
            this.pollNormalToolStripMenuItem.Click += new System.EventHandler(this.pollNormalToolStripMenuItem_Click);
            // 
            // pollFastToolStripMenuItem
            // 
            this.pollFastToolStripMenuItem.Name = "pollFastToolStripMenuItem";
            this.pollFastToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pollFastToolStripMenuItem.Text = "Fast";
            this.pollFastToolStripMenuItem.Click += new System.EventHandler(this.pollFastToolStripMenuItem_Click);
            // 
            // pollConfigureToolStripMenuItem
            // 
            this.pollConfigureToolStripMenuItem.Name = "pollConfigureToolStripMenuItem";
            this.pollConfigureToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pollConfigureToolStripMenuItem.Text = "Configure";
            this.pollConfigureToolStripMenuItem.Click += new System.EventHandler(this.pollConfigureToolStripMenuItem_Click);
            // 
            // toolStripButtonExportData
            // 
            this.toolStripButtonExportData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportData.Image = global::QuickMon.Properties.Resources.edit_32;
            this.toolStripButtonExportData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportData.Name = "toolStripButtonExportData";
            this.toolStripButtonExportData.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonExportData.Text = "Export";
            this.toolStripButtonExportData.Click += new System.EventHandler(this.toolStripButtonExportData_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // contextMenuStrip1
            // 
            this.refreshContextMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.refreshContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.autoRefreshToolStripMenuItem});
            this.refreshContextMenuStrip.Name = "contextMenuStrip1";
            this.refreshContextMenuStrip.Size = new System.Drawing.Size(136, 48);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.autoRefreshToolStripMenuItem.Text = "Auto refresh";
            this.autoRefreshToolStripMenuItem.Click += new System.EventHandler(this.autoRefreshToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDetails});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabelDetails.AutoSize = false;
            this.toolStripStatusLabelDetails.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabelDetails.Size = new System.Drawing.Size(489, 17);
            this.toolStripStatusLabelDetails.Spring = true;
            this.toolStripStatusLabelDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PingCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripMain);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.refreshContextMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        } 
        #endregion

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDisplayData();
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
        private void toolStripButtonExportData_Click(object sender, EventArgs e)
        {
            RunExport();
        }
        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleAutoRefreshOnOff();
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            bool currentTimerState = refreshTimer.Enabled;
            refreshTimer.Enabled = false;
            RefreshDisplayData();
            refreshTimer.Enabled = currentTimerState;
        }
        #endregion

        #region Virtual methods
        public virtual void RunExport() { }
        #endregion
    }
}
