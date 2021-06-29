namespace QuickMon.UI
{
    partial class WMIQueryCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMIQueryCollectorEditEntry));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMachines = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStateQuery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.chkUseRowCountAsValue = new System.Windows.Forms.CheckBox();
            this.sequenceGroupBox = new System.Windows.Forms.GroupBox();
            this.errorGroupBox = new System.Windows.Forms.GroupBox();
            this.cboErrorMatchType = new System.Windows.Forms.ComboBox();
            this.txtError = new QuickMon.Controls.STDCollectorOutputValueMatchTextBox();
            this.warningGroupBox = new System.Windows.Forms.GroupBox();
            this.cboWarningMatchType = new System.Windows.Forms.ComboBox();
            this.txtWarning = new QuickMon.Controls.STDCollectorOutputValueMatchTextBox();
            this.successGroupBox = new System.Windows.Forms.GroupBox();
            this.cboSuccessMatchType = new System.Windows.Forms.ComboBox();
            this.txtSuccess = new QuickMon.Controls.STDCollectorOutputValueMatchTextBox();
            this.cboReturnCheckSequence = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdEditSummaryQuery = new System.Windows.Forms.Button();
            this.cmdTestDB = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboOutputValueUnit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.sequenceGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            this.warningGroupBox.SuspendLayout();
            this.successGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(463, 446);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(382, 446);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtNamespace
            // 
            this.txtNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamespace.Location = new System.Drawing.Point(152, 35);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(386, 20);
            this.txtNamespace.TabIndex = 3;
            this.txtNamespace.Text = "root\\CIMV2";
            this.txtNamespace.TextChanged += new System.EventHandler(this.txtNamespace_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "WMI Root namespace";
            // 
            // txtMachines
            // 
            this.txtMachines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachines.Location = new System.Drawing.Point(152, 61);
            this.txtMachines.Name = "txtMachines";
            this.txtMachines.Size = new System.Drawing.Size(386, 20);
            this.txtMachines.TabIndex = 5;
            this.txtMachines.Text = ".";
            this.txtMachines.TextChanged += new System.EventHandler(this.txtMachines_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Machine name";
            // 
            // txtStateQuery
            // 
            this.txtStateQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStateQuery.Location = new System.Drawing.Point(13, 25);
            this.txtStateQuery.Multiline = true;
            this.txtStateQuery.Name = "txtStateQuery";
            this.txtStateQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStateQuery.Size = new System.Drawing.Size(495, 93);
            this.txtStateQuery.TabIndex = 3;
            this.txtStateQuery.Text = "SELECT FreeSpace FROM Win32_LogicalDisk where Caption = \'C:\'";
            this.txtStateQuery.TextChanged += new System.EventHandler(this.txtStateQuery_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "WMI query for summary";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageSummary);
            this.tabControl1.Location = new System.Drawing.Point(12, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(526, 353);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.BackColor = System.Drawing.Color.White;
            this.tabPageSummary.Controls.Add(this.chkUseRowCountAsValue);
            this.tabPageSummary.Controls.Add(this.sequenceGroupBox);
            this.tabPageSummary.Controls.Add(this.cmdEditSummaryQuery);
            this.tabPageSummary.Controls.Add(this.txtStateQuery);
            this.tabPageSummary.Controls.Add(this.label3);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(518, 327);
            this.tabPageSummary.TabIndex = 0;
            this.tabPageSummary.Text = "State query";
            // 
            // chkUseRowCountAsValue
            // 
            this.chkUseRowCountAsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseRowCountAsValue.AutoSize = true;
            this.chkUseRowCountAsValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseRowCountAsValue.Location = new System.Drawing.Point(373, 6);
            this.chkUseRowCountAsValue.Name = "chkUseRowCountAsValue";
            this.chkUseRowCountAsValue.Size = new System.Drawing.Size(136, 17);
            this.chkUseRowCountAsValue.TabIndex = 2;
            this.chkUseRowCountAsValue.Text = "Row count as the value";
            this.chkUseRowCountAsValue.UseVisualStyleBackColor = true;
            // 
            // sequenceGroupBox
            // 
            this.sequenceGroupBox.Controls.Add(this.errorGroupBox);
            this.sequenceGroupBox.Controls.Add(this.warningGroupBox);
            this.sequenceGroupBox.Controls.Add(this.successGroupBox);
            this.sequenceGroupBox.Controls.Add(this.cboReturnCheckSequence);
            this.sequenceGroupBox.Controls.Add(this.label5);
            this.sequenceGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sequenceGroupBox.Location = new System.Drawing.Point(3, 124);
            this.sequenceGroupBox.Name = "sequenceGroupBox";
            this.sequenceGroupBox.Size = new System.Drawing.Size(512, 200);
            this.sequenceGroupBox.TabIndex = 4;
            this.sequenceGroupBox.TabStop = false;
            this.sequenceGroupBox.Text = "Evaluate returned value/data";
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorGroupBox.Controls.Add(this.cboErrorMatchType);
            this.errorGroupBox.Controls.Add(this.txtError);
            this.errorGroupBox.Location = new System.Drawing.Point(9, 147);
            this.errorGroupBox.Name = "errorGroupBox";
            this.errorGroupBox.Size = new System.Drawing.Size(497, 44);
            this.errorGroupBox.TabIndex = 4;
            this.errorGroupBox.TabStop = false;
            this.errorGroupBox.Text = "Error check";
            // 
            // cboErrorMatchType
            // 
            this.cboErrorMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboErrorMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboErrorMatchType.FormattingEnabled = true;
            this.cboErrorMatchType.Items.AddRange(new object[] {
            "Match",
            "DoesNotMatch",
            "Contains",
            "DoesNotContain",
            "StartsWith",
            "DoesNotStartWith",
            "EndsWith",
            "DoesNotEndWith",
            "RegEx",
            "IsNumber",
            "IsNotANumber",
            "LargerThan",
            "SmallerThan",
            "Between",
            "NotBetween"});
            this.cboErrorMatchType.Location = new System.Drawing.Point(377, 18);
            this.cboErrorMatchType.Name = "cboErrorMatchType";
            this.cboErrorMatchType.Size = new System.Drawing.Size(110, 21);
            this.cboErrorMatchType.TabIndex = 1;
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Location = new System.Drawing.Point(6, 18);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(365, 20);
            this.txtError.TabIndex = 0;
            this.txtError.Text = "[any]";
            // 
            // warningGroupBox
            // 
            this.warningGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningGroupBox.Controls.Add(this.cboWarningMatchType);
            this.warningGroupBox.Controls.Add(this.txtWarning);
            this.warningGroupBox.Location = new System.Drawing.Point(8, 97);
            this.warningGroupBox.Name = "warningGroupBox";
            this.warningGroupBox.Size = new System.Drawing.Size(497, 44);
            this.warningGroupBox.TabIndex = 3;
            this.warningGroupBox.TabStop = false;
            this.warningGroupBox.Text = "Warning check";
            // 
            // cboWarningMatchType
            // 
            this.cboWarningMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWarningMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarningMatchType.FormattingEnabled = true;
            this.cboWarningMatchType.Items.AddRange(new object[] {
            "Match",
            "DoesNotMatch",
            "Contains",
            "DoesNotContain",
            "StartsWith",
            "DoesNotStartWith",
            "EndsWith",
            "DoesNotEndWith",
            "RegEx",
            "IsNumber",
            "IsNotANumber",
            "LargerThan",
            "SmallerThan",
            "Between",
            "NotBetween"});
            this.cboWarningMatchType.Location = new System.Drawing.Point(378, 18);
            this.cboWarningMatchType.Name = "cboWarningMatchType";
            this.cboWarningMatchType.Size = new System.Drawing.Size(110, 21);
            this.cboWarningMatchType.TabIndex = 1;
            // 
            // txtWarning
            // 
            this.txtWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarning.Location = new System.Drawing.Point(6, 18);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.Size = new System.Drawing.Size(366, 20);
            this.txtWarning.TabIndex = 0;
            this.txtWarning.Text = "[null]";
            // 
            // successGroupBox
            // 
            this.successGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.successGroupBox.Controls.Add(this.cboSuccessMatchType);
            this.successGroupBox.Controls.Add(this.txtSuccess);
            this.successGroupBox.Location = new System.Drawing.Point(9, 47);
            this.successGroupBox.Name = "successGroupBox";
            this.successGroupBox.Size = new System.Drawing.Size(497, 44);
            this.successGroupBox.TabIndex = 2;
            this.successGroupBox.TabStop = false;
            this.successGroupBox.Text = "Success check";
            // 
            // cboSuccessMatchType
            // 
            this.cboSuccessMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSuccessMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuccessMatchType.FormattingEnabled = true;
            this.cboSuccessMatchType.Items.AddRange(new object[] {
            "Match",
            "DoesNotMatch",
            "Contains",
            "DoesNotContain",
            "StartsWith",
            "DoesNotStartWith",
            "EndsWith",
            "DoesNotEndWith",
            "RegEx",
            "IsNumber",
            "IsNotANumber",
            "LargerThan",
            "SmallerThan",
            "Between",
            "NotBetween"});
            this.cboSuccessMatchType.Location = new System.Drawing.Point(377, 18);
            this.cboSuccessMatchType.Name = "cboSuccessMatchType";
            this.cboSuccessMatchType.Size = new System.Drawing.Size(110, 21);
            this.cboSuccessMatchType.TabIndex = 1;
            // 
            // txtSuccess
            // 
            this.txtSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSuccess.Location = new System.Drawing.Point(6, 18);
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.Size = new System.Drawing.Size(365, 20);
            this.txtSuccess.TabIndex = 0;
            this.txtSuccess.Text = "OK";
            // 
            // cboReturnCheckSequence
            // 
            this.cboReturnCheckSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReturnCheckSequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnCheckSequence.Items.AddRange(new object[] {
            "Good, Warning and then assume Error",
            "Error, Warning and then assume Good",
            "Good, Error and then assume Warning",
            "Error, Good and then assume Warning",
            "Warning, Good and then assume Error",
            "Warning, Error and then assume Good"});
            this.cboReturnCheckSequence.Location = new System.Drawing.Point(135, 19);
            this.cboReturnCheckSequence.Name = "cboReturnCheckSequence";
            this.cboReturnCheckSequence.Size = new System.Drawing.Size(371, 21);
            this.cboReturnCheckSequence.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Check sequence";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdEditSummaryQuery
            // 
            this.cmdEditSummaryQuery.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdEditSummaryQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditSummaryQuery.Image = global::QuickMon.Properties.Resources.settings_16;
            this.cmdEditSummaryQuery.Location = new System.Drawing.Point(136, 2);
            this.cmdEditSummaryQuery.Name = "cmdEditSummaryQuery";
            this.cmdEditSummaryQuery.Size = new System.Drawing.Size(36, 23);
            this.cmdEditSummaryQuery.TabIndex = 1;
            this.cmdEditSummaryQuery.UseVisualStyleBackColor = true;
            this.cmdEditSummaryQuery.Click += new System.EventHandler(this.cmdEditSummaryQuery_Click);
            // 
            // cmdTestDB
            // 
            this.cmdTestDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestDB.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdTestDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTestDB.Location = new System.Drawing.Point(301, 446);
            this.cmdTestDB.Name = "cmdTestDB";
            this.cmdTestDB.Size = new System.Drawing.Size(75, 23);
            this.cmdTestDB.TabIndex = 9;
            this.cmdTestDB.Text = "Test";
            this.cmdTestDB.UseVisualStyleBackColor = true;
            this.cmdTestDB.Click += new System.EventHandler(this.cmdTestDB_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(152, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(386, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name";
            // 
            // cboOutputValueUnit
            // 
            this.cboOutputValueUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOutputValueUnit.FormattingEnabled = true;
            this.cboOutputValueUnit.Items.AddRange(new object[] {
            "%",
            "item(s)",
            "KB",
            "MB"});
            this.cboOutputValueUnit.Location = new System.Drawing.Point(94, 448);
            this.cboOutputValueUnit.Name = "cboOutputValueUnit";
            this.cboOutputValueUnit.Size = new System.Drawing.Size(201, 21);
            this.cboOutputValueUnit.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Location = new System.Drawing.Point(13, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Output unit";
            // 
            // WMIQueryCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(558, 481);
            this.Controls.Add(this.cboOutputValueUnit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdTestDB);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtMachines);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 372);
            this.Name = "WMIQueryCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit WMI Query Config";
            this.Load += new System.EventHandler(this.EditConfigEntry_Load);
            this.Shown += new System.EventHandler(this.EditConfig_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            this.tabPageSummary.PerformLayout();
            this.sequenceGroupBox.ResumeLayout(false);
            this.errorGroupBox.ResumeLayout(false);
            this.errorGroupBox.PerformLayout();
            this.warningGroupBox.ResumeLayout(false);
            this.warningGroupBox.PerformLayout();
            this.successGroupBox.ResumeLayout(false);
            this.successGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdEditSummaryQuery;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button cmdTestDB;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TextBox txtStateQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtMachines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboOutputValueUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox sequenceGroupBox;
        private System.Windows.Forms.GroupBox errorGroupBox;
        private System.Windows.Forms.ComboBox cboErrorMatchType;
        private Controls.STDCollectorOutputValueMatchTextBox txtError;
        private System.Windows.Forms.GroupBox warningGroupBox;
        private System.Windows.Forms.ComboBox cboWarningMatchType;
        private Controls.STDCollectorOutputValueMatchTextBox txtWarning;
        private System.Windows.Forms.GroupBox successGroupBox;
        private System.Windows.Forms.ComboBox cboSuccessMatchType;
        private Controls.STDCollectorOutputValueMatchTextBox txtSuccess;
        private System.Windows.Forms.ComboBox cboReturnCheckSequence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkUseRowCountAsValue;
    }
}