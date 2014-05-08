namespace QuickMon
{
    partial class EditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdTestDB = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSQLServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllHostsApps = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lstHosts = new System.Windows.Forms.ListBox();
            this.cmdAddHost = new System.Windows.Forms.Button();
            this.cmdRemoveHost = new System.Windows.Forms.Button();
            this.cmdRemoveApp = new System.Windows.Forms.Button();
            this.cmdAddApp = new System.Windows.Forms.Button();
            this.lstApps = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMsgsWarning = new System.Windows.Forms.NumericUpDown();
            this.nudMsgsError = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudShowTopXEntries = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.chkRaiseHtmlAlerts = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMsgsWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMsgsError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShowTopXEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdTestDB);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSQLServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BizTalk system settings";
            // 
            // cmdTestDB
            // 
            this.cmdTestDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestDB.Location = new System.Drawing.Point(242, 71);
            this.cmdTestDB.Name = "cmdTestDB";
            this.cmdTestDB.Size = new System.Drawing.Size(75, 23);
            this.cmdTestDB.TabIndex = 4;
            this.cmdTestDB.Text = "Test";
            this.cmdTestDB.UseVisualStyleBackColor = true;
            this.cmdTestDB.Click += new System.EventHandler(this.cmdTestDB_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Location = new System.Drawing.Point(143, 45);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(174, 20);
            this.txtDatabase.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Management database";
            // 
            // txtSQLServer
            // 
            this.txtSQLServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQLServer.Location = new System.Drawing.Point(143, 19);
            this.txtSQLServer.Name = "txtSQLServer";
            this.txtSQLServer.Size = new System.Drawing.Size(174, 20);
            this.txtSQLServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Management DB server";
            // 
            // chkAllHostsApps
            // 
            this.chkAllHostsApps.AutoSize = true;
            this.chkAllHostsApps.Checked = true;
            this.chkAllHostsApps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllHostsApps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAllHostsApps.Location = new System.Drawing.Point(20, 168);
            this.chkAllHostsApps.Name = "chkAllHostsApps";
            this.chkAllHostsApps.Size = new System.Drawing.Size(155, 17);
            this.chkAllHostsApps.TabIndex = 5;
            this.chkAllHostsApps.Text = "Check all for all Hosts/Apps";
            this.chkAllHostsApps.UseVisualStyleBackColor = true;
            this.chkAllHostsApps.CheckedChanged += new System.EventHandler(this.chkAllHostsApps_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hosts";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(260, 388);
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
            this.cmdOK.Location = new System.Drawing.Point(179, 388);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lstHosts
            // 
            this.lstHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHosts.Enabled = false;
            this.lstHosts.FormattingEnabled = true;
            this.lstHosts.Location = new System.Drawing.Point(37, 3);
            this.lstHosts.Name = "lstHosts";
            this.lstHosts.Size = new System.Drawing.Size(203, 69);
            this.lstHosts.TabIndex = 1;
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddHost.Enabled = false;
            this.cmdAddHost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddHost.Location = new System.Drawing.Point(246, 3);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(34, 23);
            this.cmdAddHost.TabIndex = 2;
            this.cmdAddHost.Text = "+";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoveHost.Enabled = false;
            this.cmdRemoveHost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoveHost.Location = new System.Drawing.Point(246, 32);
            this.cmdRemoveHost.Name = "cmdRemoveHost";
            this.cmdRemoveHost.Size = new System.Drawing.Size(34, 23);
            this.cmdRemoveHost.TabIndex = 3;
            this.cmdRemoveHost.Text = "-";
            this.cmdRemoveHost.UseVisualStyleBackColor = true;
            this.cmdRemoveHost.Click += new System.EventHandler(this.cmdRemoveHost_Click);
            // 
            // cmdRemoveApp
            // 
            this.cmdRemoveApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoveApp.Enabled = false;
            this.cmdRemoveApp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoveApp.Location = new System.Drawing.Point(246, 32);
            this.cmdRemoveApp.Name = "cmdRemoveApp";
            this.cmdRemoveApp.Size = new System.Drawing.Size(34, 23);
            this.cmdRemoveApp.TabIndex = 3;
            this.cmdRemoveApp.Text = "-";
            this.cmdRemoveApp.UseVisualStyleBackColor = true;
            this.cmdRemoveApp.Click += new System.EventHandler(this.cmdRemoveApp_Click);
            // 
            // cmdAddApp
            // 
            this.cmdAddApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddApp.Enabled = false;
            this.cmdAddApp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddApp.Location = new System.Drawing.Point(246, 3);
            this.cmdAddApp.Name = "cmdAddApp";
            this.cmdAddApp.Size = new System.Drawing.Size(34, 23);
            this.cmdAddApp.TabIndex = 2;
            this.cmdAddApp.Text = "+";
            this.cmdAddApp.UseVisualStyleBackColor = true;
            this.cmdAddApp.Click += new System.EventHandler(this.cmdAddApp_Click);
            // 
            // lstApps
            // 
            this.lstApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstApps.Enabled = false;
            this.lstApps.FormattingEnabled = true;
            this.lstApps.Location = new System.Drawing.Point(37, 3);
            this.lstApps.Name = "lstApps";
            this.lstApps.Size = new System.Drawing.Size(203, 69);
            this.lstApps.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apps";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(55, 191);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstHosts);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cmdAddHost);
            this.splitContainer1.Panel1.Controls.Add(this.cmdRemoveHost);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstApps);
            this.splitContainer1.Panel2.Controls.Add(this.cmdRemoveApp);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAddApp);
            this.splitContainer1.Size = new System.Drawing.Size(280, 191);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "# of instances for warning";
            // 
            // nudMsgsWarning
            // 
            this.nudMsgsWarning.Location = new System.Drawing.Point(155, 116);
            this.nudMsgsWarning.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMsgsWarning.Name = "nudMsgsWarning";
            this.nudMsgsWarning.Size = new System.Drawing.Size(63, 20);
            this.nudMsgsWarning.TabIndex = 2;
            this.nudMsgsWarning.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudMsgsError
            // 
            this.nudMsgsError.Location = new System.Drawing.Point(272, 116);
            this.nudMsgsError.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMsgsError.Name = "nudMsgsError";
            this.nudMsgsError.Size = new System.Drawing.Size(63, 20);
            this.nudMsgsError.TabIndex = 3;
            this.nudMsgsError.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(224, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Error";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudShowTopXEntries
            // 
            this.nudShowTopXEntries.Location = new System.Drawing.Point(155, 142);
            this.nudShowTopXEntries.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudShowTopXEntries.Name = "nudShowTopXEntries";
            this.nudShowTopXEntries.Size = new System.Drawing.Size(63, 20);
            this.nudShowTopXEntries.TabIndex = 6;
            this.nudShowTopXEntries.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Show first X entries in alerts";
            // 
            // chkRaiseHtmlAlerts
            // 
            this.chkRaiseHtmlAlerts.AutoSize = true;
            this.chkRaiseHtmlAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkRaiseHtmlAlerts.Location = new System.Drawing.Point(12, 392);
            this.chkRaiseHtmlAlerts.Name = "chkRaiseHtmlAlerts";
            this.chkRaiseHtmlAlerts.Size = new System.Drawing.Size(124, 17);
            this.chkRaiseHtmlAlerts.TabIndex = 7;
            this.chkRaiseHtmlAlerts.Text = "Raise Alerts in HTML";
            this.chkRaiseHtmlAlerts.UseVisualStyleBackColor = true;
            this.chkRaiseHtmlAlerts.Visible = false;
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(347, 423);
            this.Controls.Add(this.chkRaiseHtmlAlerts);
            this.Controls.Add(this.nudShowTopXEntries);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudMsgsError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudMsgsWarning);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chkAllHostsApps);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(355, 390);
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.Load += new System.EventHandler(this.EditConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMsgsWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMsgsError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShowTopXEntries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSQLServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdTestDB;
        private System.Windows.Forms.CheckBox chkAllHostsApps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ListBox lstHosts;
        private System.Windows.Forms.Button cmdAddHost;
        private System.Windows.Forms.Button cmdRemoveHost;
        private System.Windows.Forms.Button cmdRemoveApp;
        private System.Windows.Forms.Button cmdAddApp;
        private System.Windows.Forms.ListBox lstApps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMsgsWarning;
        private System.Windows.Forms.NumericUpDown nudMsgsError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudShowTopXEntries;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkRaiseHtmlAlerts;
    }
}