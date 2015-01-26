namespace QuickMon.UI
{
    partial class CollectorAgentsDetailViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorAgentsDetailViewer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.summaryToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabDataSetViewer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.remoteportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRemoteAgentServer = new System.Windows.Forms.TextBox();
            this.chkRemoteAgentEnabled = new System.Windows.Forms.CheckBox();
            this.agentsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tabDataSetViewer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).BeginInit();
            this.agentsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(638, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // summaryToolStripStatusLabel
            // 
            this.summaryToolStripStatusLabel.Name = "summaryToolStripStatusLabel";
            this.summaryToolStripStatusLabel.Size = new System.Drawing.Size(623, 17);
            this.summaryToolStripStatusLabel.Spring = true;
            this.summaryToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDataSetViewer
            // 
            this.tabDataSetViewer.Controls.Add(this.tabPage1);
            this.tabDataSetViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataSetViewer.Location = new System.Drawing.Point(0, 31);
            this.tabDataSetViewer.Multiline = true;
            this.tabDataSetViewer.Name = "tabDataSetViewer";
            this.tabDataSetViewer.SelectedIndex = 0;
            this.tabDataSetViewer.Size = new System.Drawing.Size(638, 356);
            this.tabDataSetViewer.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(630, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripButton,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(638, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.refreshToolStripButton.Text = "Refresh (F5)";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.chkRemoteAgentEnabled);
            this.panel1.Controls.Add(this.remoteportNumericUpDown);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtRemoteAgentServer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 31);
            this.panel1.TabIndex = 2;
            // 
            // remoteportNumericUpDown
            // 
            this.remoteportNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteportNumericUpDown.Enabled = false;
            this.remoteportNumericUpDown.Location = new System.Drawing.Point(519, 5);
            this.remoteportNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Name = "remoteportNumericUpDown";
            this.remoteportNumericUpDown.Size = new System.Drawing.Size(107, 20);
            this.remoteportNumericUpDown.TabIndex = 4;
            this.remoteportNumericUpDown.Value = new decimal(new int[] {
            48181,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(121, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Server name";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(487, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Port";
            // 
            // txtRemoteAgentServer
            // 
            this.txtRemoteAgentServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteAgentServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRemoteAgentServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRemoteAgentServer.Enabled = false;
            this.txtRemoteAgentServer.Location = new System.Drawing.Point(194, 4);
            this.txtRemoteAgentServer.Name = "txtRemoteAgentServer";
            this.txtRemoteAgentServer.Size = new System.Drawing.Size(287, 20);
            this.txtRemoteAgentServer.TabIndex = 2;
            // 
            // chkRemoteAgentEnabled
            // 
            this.chkRemoteAgentEnabled.AutoSize = true;
            this.chkRemoteAgentEnabled.Location = new System.Drawing.Point(12, 6);
            this.chkRemoteAgentEnabled.Name = "chkRemoteAgentEnabled";
            this.chkRemoteAgentEnabled.Size = new System.Drawing.Size(103, 17);
            this.chkRemoteAgentEnabled.TabIndex = 0;
            this.chkRemoteAgentEnabled.Text = "Use remote host";
            this.chkRemoteAgentEnabled.UseVisualStyleBackColor = true;
            this.chkRemoteAgentEnabled.CheckedChanged += new System.EventHandler(this.chkRemoteAgentEnabled_CheckedChanged);
            // 
            // agentsContextMenuStrip
            // 
            this.agentsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.agentsContextMenuStrip.Name = "agentsContextMenuStrip";
            this.agentsContextMenuStrip.Size = new System.Drawing.Size(133, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // CollectorAgentsDetailViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 440);
            this.Controls.Add(this.tabDataSetViewer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "CollectorAgentsDetailViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Agents Detail Viewer";
            this.Load += new System.EventHandler(this.CollectorAgentsDetailViewer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabDataSetViewer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).EndInit();
            this.agentsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel summaryToolStripStatusLabel;
        private System.Windows.Forms.TabControl tabDataSetViewer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown remoteportNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRemoteAgentServer;
        private System.Windows.Forms.CheckBox chkRemoteAgentEnabled;
        private System.Windows.Forms.ContextMenuStrip agentsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}