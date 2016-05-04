namespace QuickMon.Collectors
{
    partial class LinuxSSHCommandCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxSSHCommandCollectorEditEntry));
            this.lblEditSSHConnection = new System.Windows.Forms.LinkLabel();
            this.txtSSHConnection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommandText = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboReturnType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.optEWG = new System.Windows.Forms.RadioButton();
            this.optGWE = new System.Windows.Forms.RadioButton();
            this.txtErrorValueOrMacro = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboErrorMatchType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtWarningValueOrMacro = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboWarningMatchType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGoodValueOrMacro = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSuccessMatchType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEditSSHConnection
            // 
            this.lblEditSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditSSHConnection.AutoSize = true;
            this.lblEditSSHConnection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblEditSSHConnection.Location = new System.Drawing.Point(447, 9);
            this.lblEditSSHConnection.Name = "lblEditSSHConnection";
            this.lblEditSSHConnection.Size = new System.Drawing.Size(25, 13);
            this.lblEditSSHConnection.TabIndex = 2;
            this.lblEditSSHConnection.TabStop = true;
            this.lblEditSSHConnection.Text = "Edit";
            this.lblEditSSHConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditSSHConnection_LinkClicked);
            // 
            // txtSSHConnection
            // 
            this.txtSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSSHConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSSHConnection.Location = new System.Drawing.Point(12, 25);
            this.txtSSHConnection.Multiline = true;
            this.txtSSHConnection.Name = "txtSSHConnection";
            this.txtSSHConnection.ReadOnly = true;
            this.txtSSHConnection.Size = new System.Drawing.Size(460, 45);
            this.txtSSHConnection.TabIndex = 1;
            this.txtSSHConnection.DoubleClick += new System.EventHandler(this.txtSSHConnection_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "SSH Connection details";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(316, 314);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 25;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(397, 314);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 26;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Command text (only single line instruction - no user interaction allowed)";
            // 
            // txtCommandText
            // 
            this.txtCommandText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandText.Location = new System.Drawing.Point(12, 131);
            this.txtCommandText.Name = "txtCommandText";
            this.txtCommandText.Size = new System.Drawing.Size(460, 20);
            this.txtCommandText.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 89);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(460, 20);
            this.txtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name/Description";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 201);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Return type";
            // 
            // cboReturnType
            // 
            this.cboReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnType.FormattingEnabled = true;
            this.cboReturnType.Items.AddRange(new object[] {
            "Returned Text",
            "Line Count",
            "Text Length"});
            this.cboReturnType.Location = new System.Drawing.Point(132, 198);
            this.cboReturnType.Name = "cboReturnType";
            this.cboReturnType.Size = new System.Drawing.Size(125, 21);
            this.cboReturnType.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Check sequence";
            // 
            // optEWG
            // 
            this.optEWG.AutoSize = true;
            this.optEWG.Location = new System.Drawing.Point(182, 171);
            this.optEWG.Name = "optEWG";
            this.optEWG.Size = new System.Drawing.Size(143, 17);
            this.optEWG.TabIndex = 9;
            this.optEWG.Text = "Error,Warning then Good";
            this.optEWG.UseVisualStyleBackColor = true;
            // 
            // optGWE
            // 
            this.optGWE.AutoSize = true;
            this.optGWE.Checked = true;
            this.optGWE.Location = new System.Drawing.Point(33, 171);
            this.optGWE.Name = "optGWE";
            this.optGWE.Size = new System.Drawing.Size(143, 17);
            this.optGWE.TabIndex = 8;
            this.optGWE.TabStop = true;
            this.optGWE.Text = "Good,Warning then Error";
            this.optGWE.UseVisualStyleBackColor = true;
            // 
            // txtErrorValueOrMacro
            // 
            this.txtErrorValueOrMacro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorValueOrMacro.Location = new System.Drawing.Point(347, 279);
            this.txtErrorValueOrMacro.Name = "txtErrorValueOrMacro";
            this.txtErrorValueOrMacro.Size = new System.Drawing.Size(125, 20);
            this.txtErrorValueOrMacro.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(263, 282);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Value or macro";
            // 
            // cboErrorMatchType
            // 
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
            this.cboErrorMatchType.Location = new System.Drawing.Point(132, 279);
            this.cboErrorMatchType.Name = "cboErrorMatchType";
            this.cboErrorMatchType.Size = new System.Drawing.Size(125, 21);
            this.cboErrorMatchType.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 282);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Error match type";
            // 
            // txtWarningValueOrMacro
            // 
            this.txtWarningValueOrMacro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarningValueOrMacro.Location = new System.Drawing.Point(347, 252);
            this.txtWarningValueOrMacro.Name = "txtWarningValueOrMacro";
            this.txtWarningValueOrMacro.Size = new System.Drawing.Size(125, 20);
            this.txtWarningValueOrMacro.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(263, 255);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Value or macro";
            // 
            // cboWarningMatchType
            // 
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
            this.cboWarningMatchType.Location = new System.Drawing.Point(132, 252);
            this.cboWarningMatchType.Name = "cboWarningMatchType";
            this.cboWarningMatchType.Size = new System.Drawing.Size(125, 21);
            this.cboWarningMatchType.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 255);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Warning match type";
            // 
            // txtGoodValueOrMacro
            // 
            this.txtGoodValueOrMacro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoodValueOrMacro.Location = new System.Drawing.Point(347, 225);
            this.txtGoodValueOrMacro.Name = "txtGoodValueOrMacro";
            this.txtGoodValueOrMacro.Size = new System.Drawing.Size(125, 20);
            this.txtGoodValueOrMacro.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(263, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Value or macro";
            // 
            // cboSuccessMatchType
            // 
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
            this.cboSuccessMatchType.Location = new System.Drawing.Point(132, 225);
            this.cboSuccessMatchType.Name = "cboSuccessMatchType";
            this.cboSuccessMatchType.Size = new System.Drawing.Size(125, 21);
            this.cboSuccessMatchType.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Good  match type";
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(235, 314);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 24;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // LinuxSSHCommandCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 346);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.txtErrorValueOrMacro);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cboErrorMatchType);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtWarningValueOrMacro);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboWarningMatchType);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtGoodValueOrMacro);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboSuccessMatchType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.optEWG);
            this.Controls.Add(this.optGWE);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboReturnType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCommandText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEditSSHConnection);
            this.Controls.Add(this.txtSSHConnection);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinuxSSHCommandCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSH Command Collector";
            this.Load += new System.EventHandler(this.LinuxSSHCommandCollectorEditEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblEditSSHConnection;
        private System.Windows.Forms.TextBox txtSSHConnection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommandText;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboReturnType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton optEWG;
        private System.Windows.Forms.RadioButton optGWE;
        private System.Windows.Forms.TextBox txtErrorValueOrMacro;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboErrorMatchType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtWarningValueOrMacro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboWarningMatchType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGoodValueOrMacro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSuccessMatchType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdTest;
    }
}