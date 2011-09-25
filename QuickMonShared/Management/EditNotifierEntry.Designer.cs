namespace QuickMon.Management
{
    partial class EditNotifierEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditNotifierEntry));
            this.cmdCancelConfig = new System.Windows.Forms.Button();
            this.cmdSaveConfig = new System.Windows.Forms.Button();
            this.lblConfigWarn = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.txtConfig = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNotifier = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorkerCheckOk = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAlertLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDetailLevel = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.alertForCollectorslinkLabel = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.configureEditButtonNotifier = new QuickMon.Controls.ConfigureEditButton();
            this.SuspendLayout();
            // 
            // cmdCancelConfig
            // 
            this.cmdCancelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancelConfig.Image = global::QuickMon.Properties.Resources.whack;
            this.cmdCancelConfig.Location = new System.Drawing.Point(436, 171);
            this.cmdCancelConfig.Name = "cmdCancelConfig";
            this.cmdCancelConfig.Size = new System.Drawing.Size(39, 23);
            this.cmdCancelConfig.TabIndex = 17;
            this.cmdCancelConfig.UseVisualStyleBackColor = true;
            this.cmdCancelConfig.Click += new System.EventHandler(this.cmdCancelConfig_Click);
            // 
            // cmdSaveConfig
            // 
            this.cmdSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveConfig.Image = global::QuickMon.Properties.Resources.DISK04;
            this.cmdSaveConfig.Location = new System.Drawing.Point(396, 171);
            this.cmdSaveConfig.Name = "cmdSaveConfig";
            this.cmdSaveConfig.Size = new System.Drawing.Size(39, 23);
            this.cmdSaveConfig.TabIndex = 16;
            this.cmdSaveConfig.UseVisualStyleBackColor = true;
            this.cmdSaveConfig.Click += new System.EventHandler(this.cmdSaveConfig_Click);
            // 
            // lblConfigWarn
            // 
            this.lblConfigWarn.AutoSize = true;
            this.lblConfigWarn.ForeColor = System.Drawing.Color.Red;
            this.lblConfigWarn.Location = new System.Drawing.Point(106, 176);
            this.lblConfigWarn.Name = "lblConfigWarn";
            this.lblConfigWarn.Size = new System.Drawing.Size(224, 13);
            this.lblConfigWarn.TabIndex = 14;
            this.lblConfigWarn.Text = "Warning! Manual editing can break the agent!";
            this.lblConfigWarn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(14, 176);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(69, 13);
            this.lblConfig.TabIndex = 13;
            this.lblConfig.Text = "Configuration";
            this.lblConfig.Visible = false;
            // 
            // txtConfig
            // 
            this.txtConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfig.Location = new System.Drawing.Point(15, 195);
            this.txtConfig.Multiline = true;
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfig.Size = new System.Drawing.Size(460, 126);
            this.txtConfig.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Notifier type";
            // 
            // cboNotifier
            // 
            this.cboNotifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNotifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboNotifier.FormattingEnabled = true;
            this.cboNotifier.Location = new System.Drawing.Point(109, 61);
            this.cboNotifier.Name = "cboNotifier";
            this.cboNotifier.Size = new System.Drawing.Size(361, 21);
            this.cboNotifier.TabIndex = 4;
            this.cboNotifier.SelectedIndexChanged += new System.EventHandler(this.cboNotifier_SelectedIndexChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(395, 327);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 20;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(314, 327);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 19;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnabled.Location = new System.Drawing.Point(109, 38);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(63, 17);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(109, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(361, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // backgroundWorkerCheckOk
            // 
            this.backgroundWorkerCheckOk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckOk_DoWork);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alert level";
            // 
            // cboAlertLevel
            // 
            this.cboAlertLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAlertLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlertLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAlertLevel.FormattingEnabled = true;
            this.cboAlertLevel.Items.AddRange(new object[] {
            "Debug",
            "Info",
            "Warning",
            "Error"});
            this.cboAlertLevel.Location = new System.Drawing.Point(109, 88);
            this.cboAlertLevel.Name = "cboAlertLevel";
            this.cboAlertLevel.Size = new System.Drawing.Size(93, 21);
            this.cboAlertLevel.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboAlertLevel, "Set the minmum alert level before notification is sent/logged");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Detail level";
            // 
            // cboDetailLevel
            // 
            this.cboDetailLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDetailLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetailLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDetailLevel.FormattingEnabled = true;
            this.cboDetailLevel.Items.AddRange(new object[] {
            "Summary only",
            "Detail",
            "Both"});
            this.cboDetailLevel.Location = new System.Drawing.Point(273, 88);
            this.cboDetailLevel.Name = "cboDetailLevel";
            this.cboDetailLevel.Size = new System.Drawing.Size(102, 21);
            this.cboDetailLevel.TabIndex = 8;
            this.toolTip1.SetToolTip(this.cboDetailLevel, "Set whether alerts are raised for each collector (Details) or just for the global" +
        " state (Summary)");
            // 
            // alertForCollectorslinkLabel
            // 
            this.alertForCollectorslinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alertForCollectorslinkLabel.AutoEllipsis = true;
            this.alertForCollectorslinkLabel.Location = new System.Drawing.Point(110, 118);
            this.alertForCollectorslinkLabel.Name = "alertForCollectorslinkLabel";
            this.alertForCollectorslinkLabel.Size = new System.Drawing.Size(365, 21);
            this.alertForCollectorslinkLabel.TabIndex = 10;
            this.alertForCollectorslinkLabel.TabStop = true;
            this.alertForCollectorslinkLabel.Text = "All Collectors";
            this.toolTip1.SetToolTip(this.alertForCollectorslinkLabel, "Specify for which collectors alerts will be raised/logged");
            this.alertForCollectorslinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.alertForCollectorslinkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alert for";
            // 
            // configureEditButtonNotifier
            // 
            this.configureEditButtonNotifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.configureEditButtonNotifier.Location = new System.Drawing.Point(222, 327);
            this.configureEditButtonNotifier.Name = "configureEditButtonNotifier";
            this.configureEditButtonNotifier.Size = new System.Drawing.Size(86, 23);
            this.configureEditButtonNotifier.TabIndex = 19;
            this.configureEditButtonNotifier.ConfigureClicked += new System.EventHandler(this.cmdConfig_Click);
            this.configureEditButtonNotifier.ManualConfigureClicked += new System.EventHandler(this.cmdManualConfig_Click);
            this.configureEditButtonNotifier.ImportConfigurationClicked += new System.EventHandler(this.configureEditButtonNotifier_ImportConfigurationClicked);
            // 
            // EditNotifierEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 362);
            this.Controls.Add(this.configureEditButtonNotifier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.alertForCollectorslinkLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboDetailLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboAlertLevel);
            this.Controls.Add(this.cmdCancelConfig);
            this.Controls.Add(this.cmdSaveConfig);
            this.Controls.Add(this.lblConfigWarn);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.txtConfig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNotifier);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "EditNotifierEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Notifier Entry";
            this.Load += new System.EventHandler(this.EditNotifierEntry_Load);
            this.Shown += new System.EventHandler(this.EditNotifierEntry_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancelConfig;
        private System.Windows.Forms.Button cmdSaveConfig;
        private System.Windows.Forms.Label lblConfigWarn;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.TextBox txtConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNotifier;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAlertLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDetailLevel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel alertForCollectorslinkLabel;
        private System.Windows.Forms.Label label5;
        private Controls.ConfigureEditButton configureEditButtonNotifier;
    }
}