namespace QuickMon.Collectors
{
    partial class DirectoryServicesQueryCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryServicesQueryCollectorEditEntry));
            this.txtDomainController = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.optEWG = new System.Windows.Forms.RadioButton();
            this.optGWE = new System.Windows.Forms.RadioButton();
            this.cmdRunQuery = new System.Windows.Forms.Button();
            this.sequenceGroupBox = new System.Windows.Forms.GroupBox();
            this.chkUseRowCount = new System.Windows.Forms.CheckBox();
            this.maxRowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPropertiestToLoad = new System.Windows.Forms.TextBox();
            this.cmdEditPropertiesToLoad = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueryText = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.scriptGroupBox = new System.Windows.Forms.GroupBox();
            this.cboSuccessMatchType = new System.Windows.Forms.ComboBox();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.successGroupBox = new System.Windows.Forms.GroupBox();
            this.cboWarningMatchType = new System.Windows.Forms.ComboBox();
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.warningGroupBox = new System.Windows.Forms.GroupBox();
            this.cboErrorMatchType = new System.Windows.Forms.ComboBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorGroupBox = new System.Windows.Forms.GroupBox();
            this.sequenceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxRowsNumericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.scriptGroupBox.SuspendLayout();
            this.successGroupBox.SuspendLayout();
            this.warningGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDomainController
            // 
            this.txtDomainController.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomainController.Location = new System.Drawing.Point(100, 38);
            this.txtDomainController.Name = "txtDomainController";
            this.txtDomainController.Size = new System.Drawing.Size(449, 20);
            this.txtDomainController.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(100, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(449, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // optEWG
            // 
            this.optEWG.AutoSize = true;
            this.optEWG.Location = new System.Drawing.Point(239, 19);
            this.optEWG.Name = "optEWG";
            this.optEWG.Size = new System.Drawing.Size(206, 17);
            this.optEWG.TabIndex = 1;
            this.optEWG.Text = "Error, Warning and then assume Good";
            this.optEWG.UseVisualStyleBackColor = true;
            // 
            // optGWE
            // 
            this.optGWE.AutoSize = true;
            this.optGWE.Checked = true;
            this.optGWE.Location = new System.Drawing.Point(16, 19);
            this.optGWE.Name = "optGWE";
            this.optGWE.Size = new System.Drawing.Size(206, 17);
            this.optGWE.TabIndex = 0;
            this.optGWE.TabStop = true;
            this.optGWE.Text = "Good, Warning and then assume Error";
            this.optGWE.UseVisualStyleBackColor = true;
            // 
            // cmdRunQuery
            // 
            this.cmdRunQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRunQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRunQuery.Location = new System.Drawing.Point(320, 457);
            this.cmdRunQuery.Name = "cmdRunQuery";
            this.cmdRunQuery.Size = new System.Drawing.Size(67, 23);
            this.cmdRunQuery.TabIndex = 10;
            this.cmdRunQuery.Text = "Test query";
            this.cmdRunQuery.UseVisualStyleBackColor = true;
            this.cmdRunQuery.Click += new System.EventHandler(this.cmdRunQuery_Click);
            // 
            // sequenceGroupBox
            // 
            this.sequenceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceGroupBox.Controls.Add(this.optEWG);
            this.sequenceGroupBox.Controls.Add(this.optGWE);
            this.sequenceGroupBox.Location = new System.Drawing.Point(9, 252);
            this.sequenceGroupBox.Name = "sequenceGroupBox";
            this.sequenceGroupBox.Size = new System.Drawing.Size(550, 49);
            this.sequenceGroupBox.TabIndex = 5;
            this.sequenceGroupBox.TabStop = false;
            this.sequenceGroupBox.Text = "Check sequence";
            // 
            // chkUseRowCount
            // 
            this.chkUseRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseRowCount.AutoSize = true;
            this.chkUseRowCount.Location = new System.Drawing.Point(359, 27);
            this.chkUseRowCount.Name = "chkUseRowCount";
            this.chkUseRowCount.Size = new System.Drawing.Size(146, 17);
            this.chkUseRowCount.TabIndex = 5;
            this.chkUseRowCount.Text = "Use Row count  as value";
            this.chkUseRowCount.UseVisualStyleBackColor = true;
            // 
            // maxRowsNumericUpDown
            // 
            this.maxRowsNumericUpDown.Location = new System.Drawing.Point(103, 26);
            this.maxRowsNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxRowsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRowsNumericUpDown.Name = "maxRowsNumericUpDown";
            this.maxRowsNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.maxRowsNumericUpDown.TabIndex = 4;
            this.maxRowsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max rows returned";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPropertiestToLoad
            // 
            this.txtPropertiestToLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertiestToLoad.Location = new System.Drawing.Point(103, 1);
            this.txtPropertiestToLoad.Name = "txtPropertiestToLoad";
            this.txtPropertiestToLoad.Size = new System.Drawing.Size(402, 20);
            this.txtPropertiestToLoad.TabIndex = 1;
            this.txtPropertiestToLoad.TextChanged += new System.EventHandler(this.txtPropertiestToLoad_TextChanged);
            // 
            // cmdEditPropertiesToLoad
            // 
            this.cmdEditPropertiesToLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditPropertiesToLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditPropertiesToLoad.Location = new System.Drawing.Point(511, 0);
            this.cmdEditPropertiesToLoad.Name = "cmdEditPropertiesToLoad";
            this.cmdEditPropertiesToLoad.Size = new System.Drawing.Size(33, 23);
            this.cmdEditPropertiesToLoad.TabIndex = 2;
            this.cmdEditPropertiesToLoad.Text = "- - -";
            this.cmdEditPropertiesToLoad.UseVisualStyleBackColor = true;
            this.cmdEditPropertiesToLoad.Click += new System.EventHandler(this.cmdEditPropertiesToLoad_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Properties to load";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQueryText
            // 
            this.txtQueryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQueryText.Location = new System.Drawing.Point(3, 16);
            this.txtQueryText.Multiline = true;
            this.txtQueryText.Name = "txtQueryText";
            this.txtQueryText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQueryText.Size = new System.Drawing.Size(544, 107);
            this.txtQueryText.TabIndex = 0;
            this.txtQueryText.WordWrap = false;
            this.txtQueryText.TextChanged += new System.EventHandler(this.txtQueryText_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkUseRowCount);
            this.panel2.Controls.Add(this.maxRowsNumericUpDown);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPropertiestToLoad);
            this.panel2.Controls.Add(this.cmdEditPropertiesToLoad);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 53);
            this.panel2.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(474, 457);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(393, 457);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 11;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // scriptGroupBox
            // 
            this.scriptGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptGroupBox.Controls.Add(this.txtQueryText);
            this.scriptGroupBox.Controls.Add(this.panel2);
            this.scriptGroupBox.Location = new System.Drawing.Point(9, 67);
            this.scriptGroupBox.Name = "scriptGroupBox";
            this.scriptGroupBox.Size = new System.Drawing.Size(550, 179);
            this.scriptGroupBox.TabIndex = 4;
            this.scriptGroupBox.TabStop = false;
            this.scriptGroupBox.Text = "Directory Services Query";
            // 
            // cboSuccessMatchType
            // 
            this.cboSuccessMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSuccessMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuccessMatchType.FormattingEnabled = true;
            this.cboSuccessMatchType.Items.AddRange(new object[] {
            "Match",
            "Contains",
            "StartsWith",
            "EndsWith",
            "RegEx",
            "IsNumber",
            "LargerThan",
            "SmallerThan",
            "Between"});
            this.cboSuccessMatchType.Location = new System.Drawing.Point(430, 18);
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
            this.txtSuccess.Size = new System.Drawing.Size(418, 20);
            this.txtSuccess.TabIndex = 0;
            this.txtSuccess.Text = "OK";
            this.txtSuccess.TextChanged += new System.EventHandler(this.txtSuccess_TextChanged);
            // 
            // successGroupBox
            // 
            this.successGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.successGroupBox.Controls.Add(this.cboSuccessMatchType);
            this.successGroupBox.Controls.Add(this.txtSuccess);
            this.successGroupBox.Location = new System.Drawing.Point(9, 307);
            this.successGroupBox.Name = "successGroupBox";
            this.successGroupBox.Size = new System.Drawing.Size(550, 44);
            this.successGroupBox.TabIndex = 6;
            this.successGroupBox.TabStop = false;
            this.successGroupBox.Text = "Success check";
            // 
            // cboWarningMatchType
            // 
            this.cboWarningMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWarningMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarningMatchType.FormattingEnabled = true;
            this.cboWarningMatchType.Items.AddRange(new object[] {
            "Match",
            "Contains",
            "StartsWith",
            "EndsWith",
            "RegEx",
            "IsNumber",
            "LargerThan",
            "SmallerThan",
            "Between"});
            this.cboWarningMatchType.Location = new System.Drawing.Point(431, 18);
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
            this.txtWarning.Size = new System.Drawing.Size(419, 20);
            this.txtWarning.TabIndex = 0;
            this.txtWarning.Text = "[null]";
            this.txtWarning.TextChanged += new System.EventHandler(this.txtWarning_TextChanged);
            // 
            // warningGroupBox
            // 
            this.warningGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningGroupBox.Controls.Add(this.cboWarningMatchType);
            this.warningGroupBox.Controls.Add(this.txtWarning);
            this.warningGroupBox.Location = new System.Drawing.Point(8, 357);
            this.warningGroupBox.Name = "warningGroupBox";
            this.warningGroupBox.Size = new System.Drawing.Size(550, 44);
            this.warningGroupBox.TabIndex = 7;
            this.warningGroupBox.TabStop = false;
            this.warningGroupBox.Text = "Warning check";
            // 
            // cboErrorMatchType
            // 
            this.cboErrorMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboErrorMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboErrorMatchType.FormattingEnabled = true;
            this.cboErrorMatchType.Items.AddRange(new object[] {
            "Match",
            "Contains",
            "StartsWith",
            "EndsWith",
            "RegEx",
            "IsNumber",
            "LargerThan",
            "SmallerThan",
            "Between"});
            this.cboErrorMatchType.Location = new System.Drawing.Point(430, 18);
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
            this.txtError.Size = new System.Drawing.Size(418, 20);
            this.txtError.TabIndex = 0;
            this.txtError.Text = "[any]";
            this.txtError.TextChanged += new System.EventHandler(this.txtError_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Domain controller";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tip: use [any] for any value, [null] for no value.";
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorGroupBox.Controls.Add(this.cboErrorMatchType);
            this.errorGroupBox.Controls.Add(this.txtError);
            this.errorGroupBox.Location = new System.Drawing.Point(9, 407);
            this.errorGroupBox.Name = "errorGroupBox";
            this.errorGroupBox.Size = new System.Drawing.Size(550, 44);
            this.errorGroupBox.TabIndex = 8;
            this.errorGroupBox.TabStop = false;
            this.errorGroupBox.Text = "Error check";
            // 
            // DirectoryServicesQueryCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 492);
            this.Controls.Add(this.txtDomainController);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmdRunQuery);
            this.Controls.Add(this.sequenceGroupBox);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.scriptGroupBox);
            this.Controls.Add(this.successGroupBox);
            this.Controls.Add(this.warningGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 530);
            this.Name = "DirectoryServicesQueryCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Directory Services Query  entry";
            this.Load += new System.EventHandler(this.DirectoryServicesQueryCollectorEditEntry_Load);
            this.sequenceGroupBox.ResumeLayout(false);
            this.sequenceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxRowsNumericUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.scriptGroupBox.ResumeLayout(false);
            this.scriptGroupBox.PerformLayout();
            this.successGroupBox.ResumeLayout(false);
            this.successGroupBox.PerformLayout();
            this.warningGroupBox.ResumeLayout(false);
            this.warningGroupBox.PerformLayout();
            this.errorGroupBox.ResumeLayout(false);
            this.errorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDomainController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton optEWG;
        private System.Windows.Forms.RadioButton optGWE;
        private System.Windows.Forms.Button cmdRunQuery;
        private System.Windows.Forms.GroupBox sequenceGroupBox;
        private System.Windows.Forms.CheckBox chkUseRowCount;
        private System.Windows.Forms.NumericUpDown maxRowsNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPropertiestToLoad;
        private System.Windows.Forms.Button cmdEditPropertiesToLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQueryText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.GroupBox scriptGroupBox;
        private System.Windows.Forms.ComboBox cboSuccessMatchType;
        private System.Windows.Forms.TextBox txtSuccess;
        private System.Windows.Forms.GroupBox successGroupBox;
        private System.Windows.Forms.ComboBox cboWarningMatchType;
        private System.Windows.Forms.TextBox txtWarning;
        private System.Windows.Forms.GroupBox warningGroupBox;
        private System.Windows.Forms.ComboBox cboErrorMatchType;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox errorGroupBox;
    }
}