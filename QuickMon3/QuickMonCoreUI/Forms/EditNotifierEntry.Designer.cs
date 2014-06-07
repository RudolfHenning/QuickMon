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
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.backgroundWorkerCheckOk = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAlertLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDetailLevel = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.alertForCollectorslinkLabel = new System.Windows.Forms.LinkLabel();
            this.cboAttendedOptionOverride = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.configEditContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.llblNotifierType = new System.Windows.Forms.LinkLabel();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.cmdConfigure = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llblUsePreset = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConfigSummary = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.configEditContextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Notifier type";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(395, 286);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(314, 286);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnabled.Location = new System.Drawing.Point(417, 13);
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
            this.txtName.Size = new System.Drawing.Size(302, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // backgroundWorkerCheckOk
            // 
            this.backgroundWorkerCheckOk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckOk_DoWork);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trigger Level";
            // 
            // cboAlertLevel
            // 
            this.cboAlertLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlertLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAlertLevel.FormattingEnabled = true;
            this.cboAlertLevel.Items.AddRange(new object[] {
            "Debug",
            "Info",
            "Warning",
            "Error"});
            this.cboAlertLevel.Location = new System.Drawing.Point(117, 23);
            this.cboAlertLevel.Name = "cboAlertLevel";
            this.cboAlertLevel.Size = new System.Drawing.Size(107, 21);
            this.cboAlertLevel.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cboAlertLevel, "Set the minmum alert level before notification is sent/logged");
            this.cboAlertLevel.SelectedIndexChanged += new System.EventHandler(this.cboAlertLevel_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Detail level";
            // 
            // cboDetailLevel
            // 
            this.cboDetailLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetailLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDetailLevel.FormattingEnabled = true;
            this.cboDetailLevel.Items.AddRange(new object[] {
            "Summary only",
            "Detail",
            "Both"});
            this.cboDetailLevel.Location = new System.Drawing.Point(307, 23);
            this.cboDetailLevel.Name = "cboDetailLevel";
            this.cboDetailLevel.Size = new System.Drawing.Size(112, 21);
            this.cboDetailLevel.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cboDetailLevel, "Set whether alerts are raised for each collector (Details) or just for the global" +
        " state (Summary)");
            this.cboDetailLevel.SelectedIndexChanged += new System.EventHandler(this.cboDetailLevel_SelectedIndexChanged);
            // 
            // alertForCollectorslinkLabel
            // 
            this.alertForCollectorslinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alertForCollectorslinkLabel.AutoEllipsis = true;
            this.alertForCollectorslinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.alertForCollectorslinkLabel.Location = new System.Drawing.Point(114, 50);
            this.alertForCollectorslinkLabel.Name = "alertForCollectorslinkLabel";
            this.alertForCollectorslinkLabel.Size = new System.Drawing.Size(349, 38);
            this.alertForCollectorslinkLabel.TabIndex = 6;
            this.alertForCollectorslinkLabel.TabStop = true;
            this.alertForCollectorslinkLabel.Text = "All Collectors";
            this.toolTip1.SetToolTip(this.alertForCollectorslinkLabel, "Specify for which collectors alerts will be raised/logged");
            this.alertForCollectorslinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.alertForCollectorslinkLabel_LinkClicked);
            // 
            // cboAttendedOptionOverride
            // 
            this.cboAttendedOptionOverride.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAttendedOptionOverride.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAttendedOptionOverride.FormattingEnabled = true;
            this.cboAttendedOptionOverride.Items.AddRange(new object[] {
            "Attended or Unattended",
            "Only Attended (with UI)",
            "Only UnAttended (e.g. under a service)"});
            this.cboAttendedOptionOverride.Location = new System.Drawing.Point(109, 58);
            this.cboAttendedOptionOverride.Name = "cboAttendedOptionOverride";
            this.cboAttendedOptionOverride.Size = new System.Drawing.Size(302, 21);
            this.cboAttendedOptionOverride.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboAttendedOptionOverride, "Should this notifier \'fire\' for only \'Attended\' or \'Unattended\' or \'Both\'");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Alert for";
            // 
            // configEditContextMenuStrip
            // 
            this.configEditContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.configEditContextMenuStrip.Name = "configEditContextMenuStrip";
            this.configEditContextMenuStrip.Size = new System.Drawing.Size(123, 70);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name";
            // 
            // llblNotifierType
            // 
            this.llblNotifierType.AutoSize = true;
            this.llblNotifierType.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblNotifierType.Location = new System.Drawing.Point(106, 39);
            this.llblNotifierType.Name = "llblNotifierType";
            this.llblNotifierType.Size = new System.Drawing.Size(63, 13);
            this.llblNotifierType.TabIndex = 4;
            this.llblNotifierType.TabStop = true;
            this.llblNotifierType.Text = "Notifier type";
            this.llblNotifierType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNotifierType_LinkClicked);
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(12, 78);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(92, 13);
            this.llblRawEdit.TabIndex = 2;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW markup";
            this.llblRawEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRawEdit_LinkClicked);
            // 
            // cmdConfigure
            // 
            this.cmdConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfigure.Enabled = false;
            this.cmdConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConfigure.Location = new System.Drawing.Point(385, 73);
            this.cmdConfigure.Name = "cmdConfigure";
            this.cmdConfigure.Size = new System.Drawing.Size(75, 23);
            this.cmdConfigure.TabIndex = 4;
            this.cmdConfigure.Text = "Configure";
            this.cmdConfigure.UseVisualStyleBackColor = true;
            this.cmdConfigure.Click += new System.EventHandler(this.cmdConfigure_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.llblUsePreset);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblConfigSummary);
            this.groupBox1.Controls.Add(this.cmdConfigure);
            this.groupBox1.Controls.Add(this.llblRawEdit);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(468, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // llblUsePreset
            // 
            this.llblUsePreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblUsePreset.AutoSize = true;
            this.llblUsePreset.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblUsePreset.Location = new System.Drawing.Point(134, 78);
            this.llblUsePreset.Name = "llblUsePreset";
            this.llblUsePreset.Size = new System.Drawing.Size(105, 13);
            this.llblUsePreset.TabIndex = 3;
            this.llblUsePreset.TabStop = true;
            this.llblUsePreset.Text = "Use Template config";
            this.llblUsePreset.Visible = false;
            this.llblUsePreset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblUsePreset_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Config summary";
            // 
            // lblConfigSummary
            // 
            this.lblConfigSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfigSummary.Location = new System.Drawing.Point(12, 20);
            this.lblConfigSummary.Name = "lblConfigSummary";
            this.lblConfigSummary.Size = new System.Drawing.Size(448, 50);
            this.lblConfigSummary.TabIndex = 1;
            this.lblConfigSummary.Text = "N/A";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboAlertLevel);
            this.groupBox2.Controls.Add(this.cboDetailLevel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.alertForCollectorslinkLabel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 91);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Alert handling";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Run attended";
            // 
            // EditNotifierEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(492, 321);
            this.Controls.Add(this.cboAttendedOptionOverride);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.llblNotifierType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "EditNotifierEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Notifier Entry";
            this.Load += new System.EventHandler(this.EditNotifierEntry_Load);
            this.Shown += new System.EventHandler(this.EditNotifierEntry_Shown);
            this.configEditContextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAlertLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDetailLevel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel alertForCollectorslinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip configEditContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel llblNotifierType;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.Button cmdConfigure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConfigSummary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAttendedOptionOverride;
        private System.Windows.Forms.LinkLabel llblUsePreset;
    }
}