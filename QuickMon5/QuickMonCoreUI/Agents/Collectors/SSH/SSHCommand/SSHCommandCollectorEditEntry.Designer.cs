namespace QuickMon.UI
{
    partial class SSHCommandCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SSHCommandCollectorEditEntry));
            this.cmdTest = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cboReturnType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCommandText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEditSSHConnection = new System.Windows.Forms.LinkLabel();
            this.txtSSHConnection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboOutputValueUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.stdCollectorOutputValueMatchesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.sequenceGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            this.warningGroupBox.SuspendLayout();
            this.successGroupBox.SuspendLayout();
            this.stdCollectorOutputValueMatchesContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTest.Location = new System.Drawing.Point(335, 459);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 11;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Return value type";
            // 
            // cboReturnType
            // 
            this.cboReturnType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnType.FormattingEnabled = true;
            this.cboReturnType.Items.AddRange(new object[] {
            "Returned Text",
            "Line Count",
            "Text Length"});
            this.cboReturnType.Location = new System.Drawing.Point(147, 162);
            this.cboReturnType.Name = "cboReturnType";
            this.cboReturnType.Size = new System.Drawing.Size(125, 21);
            this.cboReturnType.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 89);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(560, 20);
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
            // txtCommandText
            // 
            this.txtCommandText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandText.Location = new System.Drawing.Point(12, 131);
            this.txtCommandText.Multiline = true;
            this.txtCommandText.Name = "txtCommandText";
            this.txtCommandText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommandText.Size = new System.Drawing.Size(560, 25);
            this.txtCommandText.TabIndex = 6;
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
            // lblEditSSHConnection
            // 
            this.lblEditSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditSSHConnection.AutoSize = true;
            this.lblEditSSHConnection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblEditSSHConnection.Location = new System.Drawing.Point(547, 9);
            this.lblEditSSHConnection.Name = "lblEditSSHConnection";
            this.lblEditSSHConnection.Size = new System.Drawing.Size(25, 13);
            this.lblEditSSHConnection.TabIndex = 1;
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
            this.txtSSHConnection.Size = new System.Drawing.Size(560, 45);
            this.txtSSHConnection.TabIndex = 2;
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
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(416, 459);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(497, 459);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cboOutputValueUnit);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(12, 395);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 57);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display output";
            // 
            // cboOutputValueUnit
            // 
            this.cboOutputValueUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOutputValueUnit.FormattingEnabled = true;
            this.cboOutputValueUnit.Items.AddRange(new object[] {
            "%",
            "item(s)"});
            this.cboOutputValueUnit.Location = new System.Drawing.Point(92, 18);
            this.cboOutputValueUnit.Name = "cboOutputValueUnit";
            this.cboOutputValueUnit.Size = new System.Drawing.Size(452, 21);
            this.cboOutputValueUnit.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Location = new System.Drawing.Point(11, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Output unit";
            // 
            // sequenceGroupBox
            // 
            this.sequenceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceGroupBox.Controls.Add(this.errorGroupBox);
            this.sequenceGroupBox.Controls.Add(this.warningGroupBox);
            this.sequenceGroupBox.Controls.Add(this.successGroupBox);
            this.sequenceGroupBox.Controls.Add(this.cboReturnCheckSequence);
            this.sequenceGroupBox.Controls.Add(this.label5);
            this.sequenceGroupBox.Location = new System.Drawing.Point(12, 189);
            this.sequenceGroupBox.Name = "sequenceGroupBox";
            this.sequenceGroupBox.Size = new System.Drawing.Size(560, 200);
            this.sequenceGroupBox.TabIndex = 9;
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
            this.errorGroupBox.Size = new System.Drawing.Size(545, 44);
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
            this.cboErrorMatchType.Location = new System.Drawing.Point(425, 18);
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
            this.txtError.Size = new System.Drawing.Size(413, 20);
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
            this.warningGroupBox.Size = new System.Drawing.Size(545, 44);
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
            this.cboWarningMatchType.Location = new System.Drawing.Point(426, 18);
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
            this.txtWarning.Size = new System.Drawing.Size(414, 20);
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
            this.successGroupBox.Size = new System.Drawing.Size(545, 44);
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
            this.cboSuccessMatchType.Location = new System.Drawing.Point(425, 18);
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
            this.txtSuccess.Size = new System.Drawing.Size(413, 20);
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
            this.cboReturnCheckSequence.Size = new System.Drawing.Size(419, 21);
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
            // stdCollectorOutputValueMatchesContextMenuStrip
            // 
            this.stdCollectorOutputValueMatchesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.toolStripSeparator3,
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem});
            this.stdCollectorOutputValueMatchesContextMenuStrip.Name = "stdCollectorOutputValueMatchesContextMenuStrip";
            this.stdCollectorOutputValueMatchesContextMenuStrip.Size = new System.Drawing.Size(123, 154);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anyToolStripMenuItem,
            this.nullToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // anyToolStripMenuItem
            // 
            this.anyToolStripMenuItem.Name = "anyToolStripMenuItem";
            this.anyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.anyToolStripMenuItem.Text = "[any]";
            // 
            // nullToolStripMenuItem
            // 
            this.nullToolStripMenuItem.Name = "nullToolStripMenuItem";
            this.nullToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.nullToolStripMenuItem.Text = "[null]";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(119, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // SSHCommandCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 491);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.sequenceGroupBox);
            this.Controls.Add(this.cmdTest);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 530);
            this.Name = "SSHCommandCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSH Command Collector";
            this.Load += new System.EventHandler(this.SSHCommandCollectorEditEntry_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.sequenceGroupBox.ResumeLayout(false);
            this.errorGroupBox.ResumeLayout(false);
            this.errorGroupBox.PerformLayout();
            this.warningGroupBox.ResumeLayout(false);
            this.warningGroupBox.PerformLayout();
            this.successGroupBox.ResumeLayout(false);
            this.successGroupBox.PerformLayout();
            this.stdCollectorOutputValueMatchesContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboReturnType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCommandText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblEditSSHConnection;
        private System.Windows.Forms.TextBox txtSSHConnection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboOutputValueUnit;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.ContextMenuStrip stdCollectorOutputValueMatchesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nullToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}