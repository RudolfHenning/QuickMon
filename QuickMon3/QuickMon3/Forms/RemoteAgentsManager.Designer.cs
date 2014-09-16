namespace QuickMon.Forms
{
    partial class RemoteAgentsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAgentsManager));
            this.llblLocalServiceRegistered = new System.Windows.Forms.LinkLabel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.attemptToStartAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblComputer = new System.Windows.Forms.Label();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.remoteportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.llblFirewallRule = new System.Windows.Forms.LinkLabel();
            this.lvwRemoteHosts = new QuickMon.ListViewEx();
            this.remoteAgentColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.versionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // llblLocalServiceRegistered
            // 
            this.llblLocalServiceRegistered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblLocalServiceRegistered.AutoSize = true;
            this.llblLocalServiceRegistered.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblLocalServiceRegistered.Location = new System.Drawing.Point(12, 274);
            this.llblLocalServiceRegistered.Name = "llblLocalServiceRegistered";
            this.llblLocalServiceRegistered.Size = new System.Drawing.Size(187, 13);
            this.llblLocalServiceRegistered.TabIndex = 6;
            this.llblLocalServiceRegistered.TabStop = true;
            this.llblLocalServiceRegistered.Text = "Register local \'Remote Agent/Service\'";
            this.llblLocalServiceRegistered.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLocalServiceRegistered_LinkClicked);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(336, 277);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(255, 277);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem1,
            this.attemptToStartAgentToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 76);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // attemptToStartAgentToolStripMenuItem
            // 
            this.attemptToStartAgentToolStripMenuItem.Enabled = false;
            this.attemptToStartAgentToolStripMenuItem.Name = "attemptToStartAgentToolStripMenuItem";
            this.attemptToStartAgentToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.attemptToStartAgentToolStripMenuItem.Text = "Attempt to start Agent";
            this.attemptToStartAgentToolStripMenuItem.Click += new System.EventHandler(this.attemptToStartAgentToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GRunning.ico");
            this.imageList1.Images.SetKeyName(1, "GStopped.ico");
            this.imageList1.Images.SetKeyName(2, "GBusy.ico");
            this.imageList1.Images.SetKeyName(3, "GUnknown.ico");
            this.imageList1.Images.SetKeyName(4, "GPaused.ico");
            // 
            // lblComputer
            // 
            this.lblComputer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComputer.AutoSize = true;
            this.lblComputer.Location = new System.Drawing.Point(12, 251);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(52, 13);
            this.lblComputer.TabIndex = 1;
            this.lblComputer.Text = "Computer";
            this.lblComputer.DoubleClick += new System.EventHandler(this.lblComputer_DoubleClick);
            // 
            // txtComputer
            // 
            this.txtComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputer.Location = new System.Drawing.Point(70, 248);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(162, 20);
            this.txtComputer.TabIndex = 2;
            this.txtComputer.TextChanged += new System.EventHandler(this.txtComputer_TextChanged);
            this.txtComputer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComputer_KeyDown);
            // 
            // remoteportNumericUpDown
            // 
            this.remoteportNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteportNumericUpDown.Location = new System.Drawing.Point(269, 249);
            this.remoteportNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Name = "remoteportNumericUpDown";
            this.remoteportNumericUpDown.Size = new System.Drawing.Size(91, 20);
            this.remoteportNumericUpDown.TabIndex = 4;
            this.remoteportNumericUpDown.Value = new decimal(new int[] {
            8181,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(237, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Port";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.Enabled = false;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(366, 246);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(45, 23);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.FileName = "QuickMonService.exe";
            this.openFileDialog1.Filter = "QuickMon 3 Service|QuickMonService.exe";
            this.openFileDialog1.Title = "Select QuickMon 3 Service";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // llblFirewallRule
            // 
            this.llblFirewallRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblFirewallRule.AutoSize = true;
            this.llblFirewallRule.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblFirewallRule.Location = new System.Drawing.Point(12, 292);
            this.llblFirewallRule.Name = "llblFirewallRule";
            this.llblFirewallRule.Size = new System.Drawing.Size(176, 13);
            this.llblFirewallRule.TabIndex = 7;
            this.llblFirewallRule.TabStop = true;
            this.llblFirewallRule.Text = "Try to add Firewall rule for port 8181";
            this.llblFirewallRule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblFirewallRule_LinkClicked);
            // 
            // lvwRemoteHosts
            // 
            this.lvwRemoteHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwRemoteHosts.AutoResizeColumnEnabled = false;
            this.lvwRemoteHosts.AutoResizeColumnIndex = 0;
            this.lvwRemoteHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.remoteAgentColumnHeader,
            this.portColumnHeader,
            this.versionColumnHeader});
            this.lvwRemoteHosts.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwRemoteHosts.FullRowSelect = true;
            this.lvwRemoteHosts.Location = new System.Drawing.Point(1, 2);
            this.lvwRemoteHosts.Name = "lvwRemoteHosts";
            this.lvwRemoteHosts.Size = new System.Drawing.Size(424, 240);
            this.lvwRemoteHosts.SmallImageList = this.imageList1;
            this.lvwRemoteHosts.TabIndex = 0;
            this.lvwRemoteHosts.UseCompatibleStateImageBehavior = false;
            this.lvwRemoteHosts.View = System.Windows.Forms.View.Details;
            this.lvwRemoteHosts.SelectedIndexChanged += new System.EventHandler(this.lvwRemoteHosts_SelectedIndexChanged);
            // 
            // remoteAgentColumnHeader
            // 
            this.remoteAgentColumnHeader.Text = "Remote agent";
            this.remoteAgentColumnHeader.Width = 149;
            // 
            // portColumnHeader
            // 
            this.portColumnHeader.Text = "Port";
            this.portColumnHeader.Width = 70;
            // 
            // versionColumnHeader
            // 
            this.versionColumnHeader.Text = "Version";
            this.versionColumnHeader.Width = 97;
            // 
            // RemoteAgentsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(423, 312);
            this.Controls.Add(this.llblFirewallRule);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.remoteportNumericUpDown);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtComputer);
            this.Controls.Add(this.lblComputer);
            this.Controls.Add(this.lvwRemoteHosts);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.llblLocalServiceRegistered);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "RemoteAgentsManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Agent Manager";
            this.Load += new System.EventHandler(this.RemoteHostsManager_Load);
            this.Shown += new System.EventHandler(this.RemoteAgentsManager_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llblLocalServiceRegistered;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private ListViewEx lvwRemoteHosts;
        private System.Windows.Forms.ColumnHeader remoteAgentColumnHeader;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.NumericUpDown remoteportNumericUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem attemptToStartAgentToolStripMenuItem;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.LinkLabel llblFirewallRule;
        private System.Windows.Forms.ColumnHeader versionColumnHeader;
        private System.Windows.Forms.ColumnHeader portColumnHeader;
    }
}