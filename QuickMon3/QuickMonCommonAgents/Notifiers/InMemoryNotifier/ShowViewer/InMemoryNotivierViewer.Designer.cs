namespace QuickMon.Notifiers
{
    partial class InMemoryNotifierViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InMemoryNotifierViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.autoRefreshToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.pollDisabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollConfigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.alertsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.autoRefreshToolStripSplitButton,
            this.toolStripSeparator1,
            this.clearToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(592, 39);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
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
            this.pollDisabledToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.pollDisabledToolStripMenuItem.Text = "Stop";
            this.pollDisabledToolStripMenuItem.Click += new System.EventHandler(this.pollDisabledToolStripMenuItem_Click);
            // 
            // pollSlowToolStripMenuItem
            // 
            this.pollSlowToolStripMenuItem.Name = "pollSlowToolStripMenuItem";
            this.pollSlowToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.pollSlowToolStripMenuItem.Text = "Slow";
            this.pollSlowToolStripMenuItem.Click += new System.EventHandler(this.pollSlowToolStripMenuItem_Click);
            // 
            // pollNormalToolStripMenuItem
            // 
            this.pollNormalToolStripMenuItem.Name = "pollNormalToolStripMenuItem";
            this.pollNormalToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.pollNormalToolStripMenuItem.Text = "Normal";
            this.pollNormalToolStripMenuItem.Click += new System.EventHandler(this.pollNormalToolStripMenuItem_Click);
            // 
            // pollFastToolStripMenuItem
            // 
            this.pollFastToolStripMenuItem.Name = "pollFastToolStripMenuItem";
            this.pollFastToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.pollFastToolStripMenuItem.Text = "Fast";
            this.pollFastToolStripMenuItem.Click += new System.EventHandler(this.pollFastToolStripMenuItem_Click);
            // 
            // pollConfigureToolStripMenuItem
            // 
            this.pollConfigureToolStripMenuItem.Name = "pollConfigureToolStripMenuItem";
            this.pollConfigureToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.pollConfigureToolStripMenuItem.Text = "Configure";
            this.pollConfigureToolStripMenuItem.Click += new System.EventHandler(this.pollConfigureToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // clearToolStripButton
            // 
            this.clearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearToolStripButton.Image = global::QuickMon.Properties.Resources.page_white_lightning;
            this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearToolStripButton.Name = "clearToolStripButton";
            this.clearToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.clearToolStripButton.Text = "Clear all entries";
            this.clearToolStripButton.Click += new System.EventHandler(this.clearToolStripButton_Click);
            // 
            // alertsRichTextBox
            // 
            this.alertsRichTextBox.ContextMenuStrip = this.contextMenuStrip1;
            this.alertsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alertsRichTextBox.Location = new System.Drawing.Point(0, 39);
            this.alertsRichTextBox.Name = "alertsRichTextBox";
            this.alertsRichTextBox.ReadOnly = true;
            this.alertsRichTextBox.Size = new System.Drawing.Size(592, 291);
            this.alertsRichTextBox.TabIndex = 9;
            this.alertsRichTextBox.Text = "";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.autoRefreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 74);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.autoRefreshToolStripMenuItem.Text = "Auto refresh";
            this.autoRefreshToolStripMenuItem.Click += new System.EventHandler(this.autoRefreshToolStripMenuItem_Click);
            // 
            // InMemoryNotifierViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 330);
            this.Controls.Add(this.alertsRichTextBox);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InMemoryNotifierViewer";
            this.Text = "InMemoryNotivierViewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.RichTextBox alertsRichTextBox;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton clearToolStripButton;
        private System.Windows.Forms.ToolStripSplitButton autoRefreshToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem pollDisabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollSlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollFastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollConfigureToolStripMenuItem;
    }
}