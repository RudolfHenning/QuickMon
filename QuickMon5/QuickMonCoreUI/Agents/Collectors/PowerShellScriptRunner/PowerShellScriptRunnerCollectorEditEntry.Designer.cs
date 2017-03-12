namespace QuickMon.UI
{
    partial class PowerShellScriptRunnerCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerShellScriptRunnerCollectorEditEntry));
            this.label2 = new System.Windows.Forms.Label();
            this.cboErrorMatchType = new System.Windows.Forms.ComboBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.errorGroupBox = new System.Windows.Forms.GroupBox();
            this.cboWarningMatchType = new System.Windows.Forms.ComboBox();
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.warningGroupBox = new System.Windows.Forms.GroupBox();
            this.cboSuccessMatchType = new System.Windows.Forms.ComboBox();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.successGroupBox = new System.Windows.Forms.GroupBox();
            this.ps1OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdRunScript = new System.Windows.Forms.Button();
            this.cmdLoadScript = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdImportScript = new System.Windows.Forms.Button();
            this.scriptGroupBox = new System.Windows.Forms.GroupBox();
            this.optEWG = new System.Windows.Forms.RadioButton();
            this.optGWE = new System.Windows.Forms.RadioButton();
            this.sequenceGroupBox = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorGroupBox.SuspendLayout();
            this.warningGroupBox.SuspendLayout();
            this.successGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.scriptGroupBox.SuspendLayout();
            this.sequenceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tip: use [any] for any value, [null] for no value.";
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
            this.cboErrorMatchType.Location = new System.Drawing.Point(432, 18);
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
            this.txtError.Size = new System.Drawing.Size(420, 20);
            this.txtError.TabIndex = 0;
            this.txtError.Text = "[any]";
            this.txtError.TextChanged += new System.EventHandler(this.txtError_TextChanged);
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorGroupBox.Controls.Add(this.cboErrorMatchType);
            this.errorGroupBox.Controls.Add(this.txtError);
            this.errorGroupBox.Location = new System.Drawing.Point(9, 404);
            this.errorGroupBox.Name = "errorGroupBox";
            this.errorGroupBox.Size = new System.Drawing.Size(552, 44);
            this.errorGroupBox.TabIndex = 6;
            this.errorGroupBox.TabStop = false;
            this.errorGroupBox.Text = "Error check";
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
            this.cboWarningMatchType.Location = new System.Drawing.Point(433, 18);
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
            this.txtWarning.Size = new System.Drawing.Size(421, 20);
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
            this.warningGroupBox.Location = new System.Drawing.Point(8, 354);
            this.warningGroupBox.Name = "warningGroupBox";
            this.warningGroupBox.Size = new System.Drawing.Size(552, 44);
            this.warningGroupBox.TabIndex = 5;
            this.warningGroupBox.TabStop = false;
            this.warningGroupBox.Text = "Warning check";
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
            this.cboSuccessMatchType.Location = new System.Drawing.Point(432, 18);
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
            this.txtSuccess.Size = new System.Drawing.Size(420, 20);
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
            this.successGroupBox.Location = new System.Drawing.Point(9, 304);
            this.successGroupBox.Name = "successGroupBox";
            this.successGroupBox.Size = new System.Drawing.Size(552, 44);
            this.successGroupBox.TabIndex = 4;
            this.successGroupBox.TabStop = false;
            this.successGroupBox.Text = "Success check";
            // 
            // ps1OpenFileDialog
            // 
            this.ps1OpenFileDialog.DefaultExt = "ps1";
            this.ps1OpenFileDialog.Filter = "PowerShell files|*.ps1";
            this.ps1OpenFileDialog.Title = "Select PowerShell script";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(476, 454);
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
            this.cmdOK.Location = new System.Drawing.Point(395, 454);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdRunScript
            // 
            this.cmdRunScript.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdRunScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRunScript.Location = new System.Drawing.Point(168, 0);
            this.cmdRunScript.Name = "cmdRunScript";
            this.cmdRunScript.Size = new System.Drawing.Size(67, 28);
            this.cmdRunScript.TabIndex = 2;
            this.cmdRunScript.Text = "Test script";
            this.cmdRunScript.UseVisualStyleBackColor = true;
            this.cmdRunScript.Click += new System.EventHandler(this.cmdRunScript_Click);
            // 
            // cmdLoadScript
            // 
            this.cmdLoadScript.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdLoadScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadScript.Location = new System.Drawing.Point(87, 0);
            this.cmdLoadScript.Name = "cmdLoadScript";
            this.cmdLoadScript.Size = new System.Drawing.Size(81, 28);
            this.cmdLoadScript.TabIndex = 1;
            this.cmdLoadScript.Text = "Load script";
            this.cmdLoadScript.UseVisualStyleBackColor = true;
            this.cmdLoadScript.Click += new System.EventHandler(this.cmdLoadScript_Click);
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(3, 16);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(546, 158);
            this.txtScript.TabIndex = 0;
            this.txtScript.WordWrap = false;
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdRunScript);
            this.panel1.Controls.Add(this.cmdLoadScript);
            this.panel1.Controls.Add(this.cmdImportScript);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 28);
            this.panel1.TabIndex = 2;
            // 
            // cmdImportScript
            // 
            this.cmdImportScript.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdImportScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImportScript.Location = new System.Drawing.Point(0, 0);
            this.cmdImportScript.Name = "cmdImportScript";
            this.cmdImportScript.Size = new System.Drawing.Size(87, 28);
            this.cmdImportScript.TabIndex = 0;
            this.cmdImportScript.Text = "Import script";
            this.cmdImportScript.UseVisualStyleBackColor = true;
            this.cmdImportScript.Click += new System.EventHandler(this.cmdImportScript_Click);
            // 
            // scriptGroupBox
            // 
            this.scriptGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptGroupBox.Controls.Add(this.txtScript);
            this.scriptGroupBox.Controls.Add(this.panel1);
            this.scriptGroupBox.Location = new System.Drawing.Point(9, 38);
            this.scriptGroupBox.Name = "scriptGroupBox";
            this.scriptGroupBox.Size = new System.Drawing.Size(552, 205);
            this.scriptGroupBox.TabIndex = 2;
            this.scriptGroupBox.TabStop = false;
            this.scriptGroupBox.Text = "PowerShell script";
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
            // sequenceGroupBox
            // 
            this.sequenceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceGroupBox.Controls.Add(this.optEWG);
            this.sequenceGroupBox.Controls.Add(this.optGWE);
            this.sequenceGroupBox.Location = new System.Drawing.Point(9, 249);
            this.sequenceGroupBox.Name = "sequenceGroupBox";
            this.sequenceGroupBox.Size = new System.Drawing.Size(552, 49);
            this.sequenceGroupBox.TabIndex = 3;
            this.sequenceGroupBox.TabStop = false;
            this.sequenceGroupBox.Text = "Check sequence";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(75, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(476, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
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
            // PowerShellScriptRunnerCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 489);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorGroupBox);
            this.Controls.Add(this.warningGroupBox);
            this.Controls.Add(this.successGroupBox);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.scriptGroupBox);
            this.Controls.Add(this.sequenceGroupBox);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "PowerShellScriptRunnerCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit PowerShell Script RunnerCollector Entry";
            this.Load += new System.EventHandler(this.PowerShellScriptRunnerCollectorEditEntry_Load);
            this.errorGroupBox.ResumeLayout(false);
            this.errorGroupBox.PerformLayout();
            this.warningGroupBox.ResumeLayout(false);
            this.warningGroupBox.PerformLayout();
            this.successGroupBox.ResumeLayout(false);
            this.successGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.scriptGroupBox.ResumeLayout(false);
            this.scriptGroupBox.PerformLayout();
            this.sequenceGroupBox.ResumeLayout(false);
            this.sequenceGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboErrorMatchType;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.GroupBox errorGroupBox;
        private System.Windows.Forms.ComboBox cboWarningMatchType;
        private System.Windows.Forms.TextBox txtWarning;
        private System.Windows.Forms.GroupBox warningGroupBox;
        private System.Windows.Forms.ComboBox cboSuccessMatchType;
        private System.Windows.Forms.TextBox txtSuccess;
        private System.Windows.Forms.GroupBox successGroupBox;
        private System.Windows.Forms.OpenFileDialog ps1OpenFileDialog;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdRunScript;
        private System.Windows.Forms.Button cmdLoadScript;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdImportScript;
        private System.Windows.Forms.GroupBox scriptGroupBox;
        private System.Windows.Forms.RadioButton optEWG;
        private System.Windows.Forms.RadioButton optGWE;
        private System.Windows.Forms.GroupBox sequenceGroupBox;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}