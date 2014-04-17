namespace QuickMon.Collectors
{
    partial class OLEDBQueryCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OLEDBQueryCollectorEditEntry));
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.cmdBuildConnStr = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.chkUsePersistentConnection = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownCmndTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStateQuery = new FastColoredTextBoxNS.FastColoredTextBox();
            this.contextMenuStripSqlEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboReturnType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboErrorValue = new System.Windows.Forms.ComboBox();
            this.tabControlConfig = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.linkLabelQueryTips = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkReturnValueNotInverted = new System.Windows.Forms.CheckBox();
            this.cboWarningValue = new System.Windows.Forms.ComboBox();
            this.cboSuccessValue = new System.Windows.Forms.ComboBox();
            this.chkUseSPForSummary = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDetailQuery = new FastColoredTextBoxNS.FastColoredTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.chkUseSPForDetail = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.summaryQueryParseTextTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdTest = new System.Windows.Forms.Button();
            this.tabPageConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCmndTimeOut)).BeginInit();
            this.contextMenuStripSqlEdit.SuspendLayout();
            this.tabControlConfig.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageConnection.Controls.Add(this.linkLabel2);
            this.tabPageConnection.Controls.Add(this.cmdBuildConnStr);
            this.tabPageConnection.Controls.Add(this.label16);
            this.tabPageConnection.Controls.Add(this.txtConnectionString);
            this.tabPageConnection.Controls.Add(this.chkUsePersistentConnection);
            this.tabPageConnection.Controls.Add(this.label6);
            this.tabPageConnection.Controls.Add(this.numericUpDownCmndTimeOut);
            this.tabPageConnection.Controls.Add(this.label7);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(606, 268);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Connection";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(177, 9);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(194, 13);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "See connectionstrings.com for help/tips";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // cmdBuildConnStr
            // 
            this.cmdBuildConnStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBuildConnStr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBuildConnStr.Location = new System.Drawing.Point(463, 4);
            this.cmdBuildConnStr.Name = "cmdBuildConnStr";
            this.cmdBuildConnStr.Size = new System.Drawing.Size(137, 23);
            this.cmdBuildConnStr.TabIndex = 1;
            this.cmdBuildConnStr.Text = "Build connection string";
            this.cmdBuildConnStr.UseVisualStyleBackColor = true;
            this.cmdBuildConnStr.Click += new System.EventHandler(this.cmdBuildConnStr_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Connection string";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(23, 32);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionString.Size = new System.Drawing.Size(577, 80);
            this.txtConnectionString.TabIndex = 2;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            // 
            // chkUsePersistentConnection
            // 
            this.chkUsePersistentConnection.AutoSize = true;
            this.chkUsePersistentConnection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUsePersistentConnection.Location = new System.Drawing.Point(10, 148);
            this.chkUsePersistentConnection.Name = "chkUsePersistentConnection";
            this.chkUsePersistentConnection.Size = new System.Drawing.Size(147, 17);
            this.chkUsePersistentConnection.TabIndex = 6;
            this.chkUsePersistentConnection.Text = "Use persistent connection";
            this.chkUsePersistentConnection.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Time out value";
            // 
            // numericUpDownCmndTimeOut
            // 
            this.numericUpDownCmndTimeOut.Location = new System.Drawing.Point(139, 122);
            this.numericUpDownCmndTimeOut.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownCmndTimeOut.Name = "numericUpDownCmndTimeOut";
            this.numericUpDownCmndTimeOut.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownCmndTimeOut.TabIndex = 4;
            this.numericUpDownCmndTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sec";
            // 
            // txtStateQuery
            // 
            this.txtStateQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStateQuery.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtStateQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStateQuery.ContextMenuStrip = this.contextMenuStripSqlEdit;
            this.txtStateQuery.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStateQuery.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange;
            this.txtStateQuery.Language = FastColoredTextBoxNS.Language.SQL;
            this.txtStateQuery.Location = new System.Drawing.Point(9, 44);
            this.txtStateQuery.Name = "txtStateQuery";
            this.txtStateQuery.PreferredLineWidth = 0;
            this.txtStateQuery.Size = new System.Drawing.Size(591, 163);
            this.txtStateQuery.TabIndex = 3;
            this.txtStateQuery.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtStateQuery_TextChanged);
            // 
            // contextMenuStripSqlEdit
            // 
            this.contextMenuStripSqlEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selectAllToolStripMenuItem});
            this.contextMenuStripSqlEdit.Name = "contextMenuStripSqlEdit";
            this.contextMenuStripSqlEdit.Size = new System.Drawing.Size(123, 98);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "C&ut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "P&aste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // cboReturnType
            // 
            this.cboReturnType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboReturnType.FormattingEnabled = true;
            this.cboReturnType.Items.AddRange(new object[] {
            "Query value (any type)",
            "Query value (number)",
            "Row count",
            "Execution time (MS)"});
            this.cboReturnType.Location = new System.Drawing.Point(98, 210);
            this.cboReturnType.Name = "cboReturnType";
            this.cboReturnType.Size = new System.Drawing.Size(155, 21);
            this.cboReturnType.TabIndex = 5;
            this.cboReturnType.SelectedIndexChanged += new System.EventHandler(this.cboReturnType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Warning";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "SQL Query for summary";
            // 
            // cboErrorValue
            // 
            this.cboErrorValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboErrorValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboErrorValue.FormattingEnabled = true;
            this.cboErrorValue.Items.AddRange(new object[] {
            "[null]",
            "[any]"});
            this.cboErrorValue.Location = new System.Drawing.Point(396, 239);
            this.cboErrorValue.Name = "cboErrorValue";
            this.cboErrorValue.Size = new System.Drawing.Size(105, 21);
            this.cboErrorValue.TabIndex = 12;
            // 
            // tabControlConfig
            // 
            this.tabControlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlConfig.Controls.Add(this.tabPageConnection);
            this.tabControlConfig.Controls.Add(this.tabPage2);
            this.tabControlConfig.Controls.Add(this.tabPage1);
            this.tabControlConfig.Location = new System.Drawing.Point(10, 32);
            this.tabControlConfig.Name = "tabControlConfig";
            this.tabControlConfig.SelectedIndex = 0;
            this.tabControlConfig.Size = new System.Drawing.Size(614, 294);
            this.tabControlConfig.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.txtStateQuery);
            this.tabPage2.Controls.Add(this.cboReturnType);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.linkLabelQueryTips);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.cboErrorValue);
            this.tabPage2.Controls.Add(this.chkReturnValueNotInverted);
            this.tabPage2.Controls.Add(this.cboWarningValue);
            this.tabPage2.Controls.Add(this.cboSuccessValue);
            this.tabPage2.Controls.Add(this.chkUseSPForSummary);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(606, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Summary query";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Return type";
            // 
            // linkLabelQueryTips
            // 
            this.linkLabelQueryTips.AutoSize = true;
            this.linkLabelQueryTips.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelQueryTips.Location = new System.Drawing.Point(148, 26);
            this.linkLabelQueryTips.Name = "linkLabelQueryTips";
            this.linkLabelQueryTips.Size = new System.Drawing.Size(207, 13);
            this.linkLabelQueryTips.TabIndex = 2;
            this.linkLabelQueryTips.TabStop = true;
            this.linkLabelQueryTips.Text = "click here to see query tips and restrictions";
            this.linkLabelQueryTips.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQueryTips_LinkClicked);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(361, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Error";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Values: Success";
            // 
            // chkReturnValueNotInverted
            // 
            this.chkReturnValueNotInverted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReturnValueNotInverted.AutoSize = true;
            this.chkReturnValueNotInverted.Checked = true;
            this.chkReturnValueNotInverted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReturnValueNotInverted.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkReturnValueNotInverted.Location = new System.Drawing.Point(259, 211);
            this.chkReturnValueNotInverted.Name = "chkReturnValueNotInverted";
            this.chkReturnValueNotInverted.Size = new System.Drawing.Size(151, 17);
            this.chkReturnValueNotInverted.TabIndex = 6;
            this.chkReturnValueNotInverted.Text = "Success < Warning < Error";
            this.chkReturnValueNotInverted.UseVisualStyleBackColor = true;
            // 
            // cboWarningValue
            // 
            this.cboWarningValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboWarningValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboWarningValue.FormattingEnabled = true;
            this.cboWarningValue.Items.AddRange(new object[] {
            "[null]",
            "[any]"});
            this.cboWarningValue.Location = new System.Drawing.Point(259, 239);
            this.cboWarningValue.Name = "cboWarningValue";
            this.cboWarningValue.Size = new System.Drawing.Size(96, 21);
            this.cboWarningValue.TabIndex = 10;
            // 
            // cboSuccessValue
            // 
            this.cboSuccessValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSuccessValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSuccessValue.FormattingEnabled = true;
            this.cboSuccessValue.Items.AddRange(new object[] {
            "[null]",
            "[any]"});
            this.cboSuccessValue.Location = new System.Drawing.Point(98, 239);
            this.cboSuccessValue.Name = "cboSuccessValue";
            this.cboSuccessValue.Size = new System.Drawing.Size(102, 21);
            this.cboSuccessValue.TabIndex = 8;
            // 
            // chkUseSPForSummary
            // 
            this.chkUseSPForSummary.AutoSize = true;
            this.chkUseSPForSummary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseSPForSummary.Location = new System.Drawing.Point(6, 6);
            this.chkUseSPForSummary.Name = "chkUseSPForSummary";
            this.chkUseSPForSummary.Size = new System.Drawing.Size(236, 17);
            this.chkUseSPForSummary.TabIndex = 0;
            this.chkUseSPForSummary.Text = "Use predefined query (like in Access queries)";
            this.chkUseSPForSummary.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txtDetailQuery);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.chkUseSPForDetail);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(606, 268);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Detail query";
            // 
            // txtDetailQuery
            // 
            this.txtDetailQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetailQuery.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtDetailQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailQuery.ContextMenuStrip = this.contextMenuStripSqlEdit;
            this.txtDetailQuery.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDetailQuery.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange;
            this.txtDetailQuery.Language = FastColoredTextBoxNS.Language.SQL;
            this.txtDetailQuery.Location = new System.Drawing.Point(8, 43);
            this.txtDetailQuery.Name = "txtDetailQuery";
            this.txtDetailQuery.PreferredLineWidth = 0;
            this.txtDetailQuery.Size = new System.Drawing.Size(587, 172);
            this.txtDetailQuery.TabIndex = 3;
            this.txtDetailQuery.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtDetailQuery_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(148, 26);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(207, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "click here to see query tips and restrictions";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQueryTips_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "SQL Query for detail";
            // 
            // chkUseSPForDetail
            // 
            this.chkUseSPForDetail.AutoSize = true;
            this.chkUseSPForDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseSPForDetail.Location = new System.Drawing.Point(6, 6);
            this.chkUseSPForDetail.Name = "chkUseSPForDetail";
            this.chkUseSPForDetail.Size = new System.Drawing.Size(236, 17);
            this.chkUseSPForDetail.TabIndex = 0;
            this.chkUseSPForDetail.Text = "Use predefined query (like in Access queries)";
            this.chkUseSPForDetail.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(139, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(485, 20);
            this.txtName.TabIndex = 1;
            // 
            // summaryQueryParseTextTimer
            // 
            this.summaryQueryParseTextTimer.Interval = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name/description";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(468, 332);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(549, 332);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(387, 332);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 3;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // OLEDBQueryCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 362);
            this.Controls.Add(this.tabControlConfig);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdTest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(560, 400);
            this.Name = "OLEDBQueryCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OLE DB Query collector edit entry";
            this.Load += new System.EventHandler(this.OLEDBQueryCollectorEditEntry_Load);
            this.Shown += new System.EventHandler(this.OLEDBQueryCollectorEditEntry_Shown);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCmndTimeOut)).EndInit();
            this.contextMenuStripSqlEdit.ResumeLayout(false);
            this.tabControlConfig.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.CheckBox chkUsePersistentConnection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownCmndTimeOut;
        private System.Windows.Forms.Label label7;
        private FastColoredTextBoxNS.FastColoredTextBox txtStateQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSqlEdit;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboReturnType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboErrorValue;
        private System.Windows.Forms.TabControl tabControlConfig;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel linkLabelQueryTips;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkReturnValueNotInverted;
        private System.Windows.Forms.ComboBox cboWarningValue;
        private System.Windows.Forms.ComboBox cboSuccessValue;
        private System.Windows.Forms.CheckBox chkUseSPForSummary;
        private System.Windows.Forms.TabPage tabPage1;
        private FastColoredTextBoxNS.FastColoredTextBox txtDetailQuery;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkUseSPForDetail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Timer summaryQueryParseTextTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button cmdBuildConnStr;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}