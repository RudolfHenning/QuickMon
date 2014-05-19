namespace QuickMon.Forms
{
    partial class EditCollectorConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCollectorConfig));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.agentSettingstabPage = new System.Windows.Forms.TabPage();
            this.panCollectorConfigContainer = new System.Windows.Forms.Panel();
            this.itemsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entriesImageList = new System.Windows.Forms.ImageList(this.components);
            this.collectorEditToolStrip = new System.Windows.Forms.ToolStrip();
            this.addCollectorConfigEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editCollectorConfigEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteCollectorConfigEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llblCollectorType = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pollingOverridesGroupBox = new System.Windows.Forms.GroupBox();
            this.chkEnablePollingOverride = new System.Windows.Forms.CheckBox();
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.chkEnablePollingFrequencySliding = new System.Windows.Forms.CheckBox();
            this.onlyAllowUpdateOncePerXSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.linkLabelServiceWindows = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkForceRemoteExcuteOnChildCollectors = new System.Windows.Forms.CheckBox();
            this.llblRemoteAgentInstallHelp = new System.Windows.Forms.LinkLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.chkRemoteAgentEnabled = new System.Windows.Forms.CheckBox();
            this.remoteportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRemoteAgentServer = new System.Windows.Forms.TextBox();
            this.cmdRemoteAgentTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboParentCollector = new System.Windows.Forms.ComboBox();
            this.chkCollectOnParentWarning = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.alertsTabPage = new System.Windows.Forms.TabPage();
            this.correctiveScriptsGroupBox = new System.Windows.Forms.GroupBox();
            this.chkOnlyRunCorrectiveScriptsOnStateChange = new System.Windows.Forms.CheckBox();
            this.cmdBrowseForRestorationScript = new System.Windows.Forms.Button();
            this.txtRestorationScript = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdBrowseForWarningCorrectiveScript = new System.Windows.Forms.Button();
            this.chkCorrectiveScriptDisabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdBrowseForErrorCorrectiveScript = new System.Windows.Forms.Button();
            this.txtCorrectiveScriptOnWarning = new System.Windows.Forms.TextBox();
            this.txtCorrectiveScriptOnError = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.alertSuppressionGroupBox = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDownRepeatAlertInXPolls = new System.Windows.Forms.NumericUpDown();
            this.delayAlertPollsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AlertOnceInXPollsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownRepeatAlertInXMin = new System.Windows.Forms.NumericUpDown();
            this.delayAlertSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AlertOnceInXMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.correctiveScriptOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label36 = new System.Windows.Forms.Label();
            this.tvwEntries = new QuickMon.TreeViewEx();
            this.lvwEntries = new QuickMon.ListViewEx();
            this.entriesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.triggerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.agentSettingstabPage.SuspendLayout();
            this.panCollectorConfigContainer.SuspendLayout();
            this.itemsContextMenuStrip.SuspendLayout();
            this.collectorEditToolStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pollingOverridesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlyAllowUpdateOncePerXSecNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.alertsTabPage.SuspendLayout();
            this.correctiveScriptsGroupBox.SuspendLayout();
            this.alertSuppressionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXPolls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertPollsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXPollsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXMinNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(497, 432);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(416, 432);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
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
            this.chkEnabled.Location = new System.Drawing.Point(509, 13);
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
            this.txtName.Location = new System.Drawing.Point(62, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(441, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Id";
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(34, 437);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 5;
            this.lblId.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.agentSettingstabPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.alertsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(1, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 388);
            this.tabControl1.TabIndex = 3;
            // 
            // agentSettingstabPage
            // 
            this.agentSettingstabPage.AutoScroll = true;
            this.agentSettingstabPage.BackColor = System.Drawing.SystemColors.Control;
            this.agentSettingstabPage.Controls.Add(this.panCollectorConfigContainer);
            this.agentSettingstabPage.Controls.Add(this.panel2);
            this.agentSettingstabPage.Controls.Add(this.panel1);
            this.agentSettingstabPage.Location = new System.Drawing.Point(4, 22);
            this.agentSettingstabPage.Name = "agentSettingstabPage";
            this.agentSettingstabPage.Padding = new System.Windows.Forms.Padding(3);
            this.agentSettingstabPage.Size = new System.Drawing.Size(574, 362);
            this.agentSettingstabPage.TabIndex = 0;
            this.agentSettingstabPage.Text = "Agent settings";
            // 
            // panCollectorConfigContainer
            // 
            this.panCollectorConfigContainer.AutoScroll = true;
            this.panCollectorConfigContainer.Controls.Add(this.tvwEntries);
            this.panCollectorConfigContainer.Controls.Add(this.lvwEntries);
            this.panCollectorConfigContainer.Controls.Add(this.collectorEditToolStrip);
            this.panCollectorConfigContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCollectorConfigContainer.Location = new System.Drawing.Point(3, 29);
            this.panCollectorConfigContainer.Name = "panCollectorConfigContainer";
            this.panCollectorConfigContainer.Size = new System.Drawing.Size(568, 304);
            this.panCollectorConfigContainer.TabIndex = 1;
            // 
            // itemsContextMenuStrip
            // 
            this.itemsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.deleteItemToolStripMenuItem});
            this.itemsContextMenuStrip.Name = "itemsContextMenuStrip";
            this.itemsContextMenuStrip.Size = new System.Drawing.Size(138, 70);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.addItemToolStripMenuItem.Text = "Add entry";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addCollectorConfigEntryToolStripButton_Click);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Image = global::QuickMon.Properties.Resources.proc2;
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.editItemToolStripMenuItem.Text = "Edit entry";
            this.editItemToolStripMenuItem.Click += new System.EventHandler(this.editCollectorConfigEntryToolStripButton_Click);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Enabled = false;
            this.deleteItemToolStripMenuItem.Image = global::QuickMon.Properties.Resources.whack;
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete entry";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteCollectorConfigEntryToolStripButton_Click);
            // 
            // entriesImageList
            // 
            this.entriesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("entriesImageList.ImageStream")));
            this.entriesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.entriesImageList.Images.SetKeyName(0, "5_50.ico");
            this.entriesImageList.Images.SetKeyName(1, "243.ico");
            // 
            // collectorEditToolStrip
            // 
            this.collectorEditToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.collectorEditToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorConfigEntryToolStripButton,
            this.editCollectorConfigEntryToolStripButton,
            this.deleteCollectorConfigEntryToolStripButton});
            this.collectorEditToolStrip.Location = new System.Drawing.Point(0, 0);
            this.collectorEditToolStrip.Name = "collectorEditToolStrip";
            this.collectorEditToolStrip.Size = new System.Drawing.Size(568, 25);
            this.collectorEditToolStrip.TabIndex = 0;
            this.collectorEditToolStrip.Text = "toolStrip1";
            // 
            // addCollectorConfigEntryToolStripButton
            // 
            this.addCollectorConfigEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCollectorConfigEntryToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addCollectorConfigEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCollectorConfigEntryToolStripButton.Name = "addCollectorConfigEntryToolStripButton";
            this.addCollectorConfigEntryToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addCollectorConfigEntryToolStripButton.Text = "Add Collector entry";
            this.addCollectorConfigEntryToolStripButton.ToolTipText = "Add entry";
            this.addCollectorConfigEntryToolStripButton.Click += new System.EventHandler(this.addCollectorConfigEntryToolStripButton_Click);
            // 
            // editCollectorConfigEntryToolStripButton
            // 
            this.editCollectorConfigEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editCollectorConfigEntryToolStripButton.Image = global::QuickMon.Properties.Resources.proc2;
            this.editCollectorConfigEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editCollectorConfigEntryToolStripButton.Name = "editCollectorConfigEntryToolStripButton";
            this.editCollectorConfigEntryToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editCollectorConfigEntryToolStripButton.Text = "Edit Collector Entry";
            this.editCollectorConfigEntryToolStripButton.Click += new System.EventHandler(this.editCollectorConfigEntryToolStripButton_Click);
            // 
            // deleteCollectorConfigEntryToolStripButton
            // 
            this.deleteCollectorConfigEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteCollectorConfigEntryToolStripButton.Enabled = false;
            this.deleteCollectorConfigEntryToolStripButton.Image = global::QuickMon.Properties.Resources.whack;
            this.deleteCollectorConfigEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteCollectorConfigEntryToolStripButton.Name = "deleteCollectorConfigEntryToolStripButton";
            this.deleteCollectorConfigEntryToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteCollectorConfigEntryToolStripButton.Text = "Delete Collector Entry";
            this.deleteCollectorConfigEntryToolStripButton.Click += new System.EventHandler(this.deleteCollectorConfigEntryToolStripButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.llblRawEdit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 333);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 26);
            this.panel2.TabIndex = 1;
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(3, 10);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(92, 13);
            this.llblRawEdit.TabIndex = 0;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW markup";
            this.llblRawEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRawEdit_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llblCollectorType);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 26);
            this.panel1.TabIndex = 0;
            // 
            // llblCollectorType
            // 
            this.llblCollectorType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblCollectorType.AutoSize = true;
            this.llblCollectorType.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblCollectorType.Location = new System.Drawing.Point(111, 6);
            this.llblCollectorType.Name = "llblCollectorType";
            this.llblCollectorType.Size = new System.Drawing.Size(71, 13);
            this.llblCollectorType.TabIndex = 1;
            this.llblCollectorType.TabStop = true;
            this.llblCollectorType.Text = "Collector type";
            this.llblCollectorType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCollectorType_LinkClicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Collector type";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.pollingOverridesGroupBox);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Operational settings";
            // 
            // pollingOverridesGroupBox
            // 
            this.pollingOverridesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pollingOverridesGroupBox.Controls.Add(this.label36);
            this.pollingOverridesGroupBox.Controls.Add(this.chkEnablePollingOverride);
            this.pollingOverridesGroupBox.Controls.Add(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label34);
            this.pollingOverridesGroupBox.Controls.Add(this.label35);
            this.pollingOverridesGroupBox.Controls.Add(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label32);
            this.pollingOverridesGroupBox.Controls.Add(this.label33);
            this.pollingOverridesGroupBox.Controls.Add(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label30);
            this.pollingOverridesGroupBox.Controls.Add(this.label31);
            this.pollingOverridesGroupBox.Controls.Add(this.chkEnablePollingFrequencySliding);
            this.pollingOverridesGroupBox.Controls.Add(this.onlyAllowUpdateOncePerXSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label28);
            this.pollingOverridesGroupBox.Controls.Add(this.label29);
            this.pollingOverridesGroupBox.Controls.Add(this.label27);
            this.pollingOverridesGroupBox.Location = new System.Drawing.Point(7, 68);
            this.pollingOverridesGroupBox.Name = "pollingOverridesGroupBox";
            this.pollingOverridesGroupBox.Size = new System.Drawing.Size(561, 136);
            this.pollingOverridesGroupBox.TabIndex = 1;
            this.pollingOverridesGroupBox.TabStop = false;
            // 
            // chkEnablePollingOverride
            // 
            this.chkEnablePollingOverride.AutoSize = true;
            this.chkEnablePollingOverride.Location = new System.Drawing.Point(117, -1);
            this.chkEnablePollingOverride.Name = "chkEnablePollingOverride";
            this.chkEnablePollingOverride.Size = new System.Drawing.Size(65, 17);
            this.chkEnablePollingOverride.TabIndex = 1;
            this.chkEnablePollingOverride.Text = "Enabled";
            this.chkEnablePollingOverride.UseVisualStyleBackColor = true;
            this.chkEnablePollingOverride.CheckedChanged += new System.EventHandler(this.chkEnablePollingOverride_CheckedChanged);
            // 
            // pollSlideFrequencyAfterThirdRepeatSecNumericUpDown
            // 
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Location = new System.Drawing.Point(155, 101);
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Maximum = new decimal(new int[] {
            3603,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Name = "pollSlideFrequencyAfterThirdRepeatSecNumericUpDown";
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.TabIndex = 13;
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.ValueChanged += new System.EventHandler(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown_ValueChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(218, 103);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(49, 13);
            this.label34.TabIndex = 14;
            this.label34.Text = "Seconds";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 103);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(85, 13);
            this.label35.TabIndex = 12;
            this.label35.Text = "After third repeat";
            // 
            // pollSlideFrequencyAfterSecondRepeatSecNumericUpDown
            // 
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Location = new System.Drawing.Point(426, 75);
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Maximum = new decimal(new int[] {
            3602,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Name = "pollSlideFrequencyAfterSecondRepeatSecNumericUpDown";
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.TabIndex = 10;
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.ValueChanged += new System.EventHandler(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(492, 77);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 13);
            this.label32.TabIndex = 11;
            this.label32.Text = "Seconds";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(295, 77);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(125, 13);
            this.label33.TabIndex = 9;
            this.label33.Text = "After second repeat";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pollSlideFrequencyAfterFirstRepeatSecNumericUpDown
            // 
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Location = new System.Drawing.Point(155, 75);
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Maximum = new decimal(new int[] {
            3601,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Name = "pollSlideFrequencyAfterFirstRepeatSecNumericUpDown";
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.TabIndex = 7;
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.ValueChanged += new System.EventHandler(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown_ValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(218, 77);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 8;
            this.label30.Text = "Seconds";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 77);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(133, 13);
            this.label31.TabIndex = 6;
            this.label31.Text = "Frequency after first repeat";
            // 
            // chkEnablePollingFrequencySliding
            // 
            this.chkEnablePollingFrequencySliding.AutoSize = true;
            this.chkEnablePollingFrequencySliding.Location = new System.Drawing.Point(14, 53);
            this.chkEnablePollingFrequencySliding.Name = "chkEnablePollingFrequencySliding";
            this.chkEnablePollingFrequencySliding.Size = new System.Drawing.Size(370, 17);
            this.chkEnablePollingFrequencySliding.TabIndex = 5;
            this.chkEnablePollingFrequencySliding.Text = "Enable frequency sliding - (Frequency decrease if state does not change)";
            this.chkEnablePollingFrequencySliding.UseVisualStyleBackColor = true;
            this.chkEnablePollingFrequencySliding.CheckedChanged += new System.EventHandler(this.chkEnablePollingFrequencySliding_CheckedChanged);
            // 
            // onlyAllowUpdateOncePerXSecNumericUpDown
            // 
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Location = new System.Drawing.Point(155, 25);
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Name = "onlyAllowUpdateOncePerXSecNumericUpDown";
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.onlyAllowUpdateOncePerXSecNumericUpDown.TabIndex = 3;
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.onlyAllowUpdateOncePerXSecNumericUpDown.ValueChanged += new System.EventHandler(this.onlyAllowUpdateOncePerXSecNumericUpDown_ValueChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(218, 27);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 13);
            this.label28.TabIndex = 4;
            this.label28.Text = "Seconds";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(11, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(120, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Only update once every";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(101, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Polling overrides";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.linkLabelServiceWindows);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(7, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 54);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Service window(s)";
            // 
            // linkLabelServiceWindows
            // 
            this.linkLabelServiceWindows.AutoEllipsis = true;
            this.linkLabelServiceWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelServiceWindows.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelServiceWindows.Location = new System.Drawing.Point(3, 16);
            this.linkLabelServiceWindows.Name = "linkLabelServiceWindows";
            this.linkLabelServiceWindows.Size = new System.Drawing.Size(554, 35);
            this.linkLabelServiceWindows.TabIndex = 1;
            this.linkLabelServiceWindows.TabStop = true;
            this.linkLabelServiceWindows.Text = "None";
            this.linkLabelServiceWindows.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelServiceWindows_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkForceRemoteExcuteOnChildCollectors);
            this.groupBox2.Controls.Add(this.llblRemoteAgentInstallHelp);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.chkRemoteAgentEnabled);
            this.groupBox2.Controls.Add(this.remoteportNumericUpDown);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtRemoteAgentServer);
            this.groupBox2.Controls.Add(this.cmdRemoteAgentTest);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 75);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // chkForceRemoteExcuteOnChildCollectors
            // 
            this.chkForceRemoteExcuteOnChildCollectors.AutoSize = true;
            this.chkForceRemoteExcuteOnChildCollectors.Location = new System.Drawing.Point(177, 23);
            this.chkForceRemoteExcuteOnChildCollectors.Name = "chkForceRemoteExcuteOnChildCollectors";
            this.chkForceRemoteExcuteOnChildCollectors.Size = new System.Drawing.Size(139, 17);
            this.chkForceRemoteExcuteOnChildCollectors.TabIndex = 2;
            this.chkForceRemoteExcuteOnChildCollectors.Text = "Override child collectors";
            this.chkForceRemoteExcuteOnChildCollectors.UseVisualStyleBackColor = true;
            this.chkForceRemoteExcuteOnChildCollectors.CheckedChanged += new System.EventHandler(this.chkRemoteAgentEnabled_CheckedChanged);
            // 
            // llblRemoteAgentInstallHelp
            // 
            this.llblRemoteAgentInstallHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblRemoteAgentInstallHelp.AutoSize = true;
            this.llblRemoteAgentInstallHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRemoteAgentInstallHelp.Location = new System.Drawing.Point(494, 1);
            this.llblRemoteAgentInstallHelp.Name = "llblRemoteAgentInstallHelp";
            this.llblRemoteAgentInstallHelp.Size = new System.Drawing.Size(57, 13);
            this.llblRemoteAgentInstallHelp.TabIndex = 0;
            this.llblRemoteAgentInstallHelp.TabStop = true;
            this.llblRemoteAgentInstallHelp.Text = "Install help";
            this.llblRemoteAgentInstallHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRemoteAgentInstallHelp_LinkClicked);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Remote agent";
            // 
            // chkRemoteAgentEnabled
            // 
            this.chkRemoteAgentEnabled.AutoSize = true;
            this.chkRemoteAgentEnabled.Location = new System.Drawing.Point(25, 23);
            this.chkRemoteAgentEnabled.Name = "chkRemoteAgentEnabled";
            this.chkRemoteAgentEnabled.Size = new System.Drawing.Size(142, 17);
            this.chkRemoteAgentEnabled.TabIndex = 1;
            this.chkRemoteAgentEnabled.Text = "Enabled for this collector";
            this.chkRemoteAgentEnabled.UseVisualStyleBackColor = true;
            this.chkRemoteAgentEnabled.CheckedChanged += new System.EventHandler(this.chkRemoteAgentEnabled_CheckedChanged);
            // 
            // remoteportNumericUpDown
            // 
            this.remoteportNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteportNumericUpDown.Enabled = false;
            this.remoteportNumericUpDown.Location = new System.Drawing.Point(372, 49);
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
            this.remoteportNumericUpDown.Size = new System.Drawing.Size(107, 20);
            this.remoteportNumericUpDown.TabIndex = 6;
            this.remoteportNumericUpDown.Value = new decimal(new int[] {
            8181,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Remote server name";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(340, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Port";
            // 
            // txtRemoteAgentServer
            // 
            this.txtRemoteAgentServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteAgentServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRemoteAgentServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRemoteAgentServer.Enabled = false;
            this.txtRemoteAgentServer.Location = new System.Drawing.Point(138, 48);
            this.txtRemoteAgentServer.Name = "txtRemoteAgentServer";
            this.txtRemoteAgentServer.Size = new System.Drawing.Size(196, 20);
            this.txtRemoteAgentServer.TabIndex = 4;
            this.txtRemoteAgentServer.Leave += new System.EventHandler(this.txtRemoteAgentServer_Leave);
            // 
            // cmdRemoteAgentTest
            // 
            this.cmdRemoteAgentTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoteAgentTest.Enabled = false;
            this.cmdRemoteAgentTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoteAgentTest.Location = new System.Drawing.Point(485, 46);
            this.cmdRemoteAgentTest.Name = "cmdRemoteAgentTest";
            this.cmdRemoteAgentTest.Size = new System.Drawing.Size(70, 23);
            this.cmdRemoteAgentTest.TabIndex = 7;
            this.cmdRemoteAgentTest.Text = "Test";
            this.cmdRemoteAgentTest.UseVisualStyleBackColor = true;
            this.cmdRemoteAgentTest.Click += new System.EventHandler(this.cmdRemoteAgentTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboParentCollector);
            this.groupBox1.Controls.Add(this.chkCollectOnParentWarning);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dependencies";
            // 
            // cboParentCollector
            // 
            this.cboParentCollector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboParentCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParentCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboParentCollector.FormattingEnabled = true;
            this.cboParentCollector.Location = new System.Drawing.Point(108, 19);
            this.cboParentCollector.Name = "cboParentCollector";
            this.cboParentCollector.Size = new System.Drawing.Size(447, 21);
            this.cboParentCollector.TabIndex = 3;
            // 
            // chkCollectOnParentWarning
            // 
            this.chkCollectOnParentWarning.AutoSize = true;
            this.chkCollectOnParentWarning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCollectOnParentWarning.Location = new System.Drawing.Point(109, -1);
            this.chkCollectOnParentWarning.Name = "chkCollectOnParentWarning";
            this.chkCollectOnParentWarning.Size = new System.Drawing.Size(270, 17);
            this.chkCollectOnParentWarning.TabIndex = 1;
            this.chkCollectOnParentWarning.Text = "Continue checking dependant collectors on warning";
            this.chkCollectOnParentWarning.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parent collector";
            // 
            // alertsTabPage
            // 
            this.alertsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.alertsTabPage.Controls.Add(this.correctiveScriptsGroupBox);
            this.alertsTabPage.Controls.Add(this.alertSuppressionGroupBox);
            this.alertsTabPage.Location = new System.Drawing.Point(4, 22);
            this.alertsTabPage.Name = "alertsTabPage";
            this.alertsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.alertsTabPage.Size = new System.Drawing.Size(574, 362);
            this.alertsTabPage.TabIndex = 2;
            this.alertsTabPage.Text = "Alerting settings";
            // 
            // correctiveScriptsGroupBox
            // 
            this.correctiveScriptsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.correctiveScriptsGroupBox.Controls.Add(this.chkOnlyRunCorrectiveScriptsOnStateChange);
            this.correctiveScriptsGroupBox.Controls.Add(this.cmdBrowseForRestorationScript);
            this.correctiveScriptsGroupBox.Controls.Add(this.txtRestorationScript);
            this.correctiveScriptsGroupBox.Controls.Add(this.label20);
            this.correctiveScriptsGroupBox.Controls.Add(this.label19);
            this.correctiveScriptsGroupBox.Controls.Add(this.cmdBrowseForWarningCorrectiveScript);
            this.correctiveScriptsGroupBox.Controls.Add(this.chkCorrectiveScriptDisabled);
            this.correctiveScriptsGroupBox.Controls.Add(this.label7);
            this.correctiveScriptsGroupBox.Controls.Add(this.cmdBrowseForErrorCorrectiveScript);
            this.correctiveScriptsGroupBox.Controls.Add(this.txtCorrectiveScriptOnWarning);
            this.correctiveScriptsGroupBox.Controls.Add(this.txtCorrectiveScriptOnError);
            this.correctiveScriptsGroupBox.Controls.Add(this.label12);
            this.correctiveScriptsGroupBox.Location = new System.Drawing.Point(7, 117);
            this.correctiveScriptsGroupBox.Name = "correctiveScriptsGroupBox";
            this.correctiveScriptsGroupBox.Size = new System.Drawing.Size(560, 138);
            this.correctiveScriptsGroupBox.TabIndex = 1;
            this.correctiveScriptsGroupBox.TabStop = false;
            // 
            // chkOnlyRunCorrectiveScriptsOnStateChange
            // 
            this.chkOnlyRunCorrectiveScriptsOnStateChange.AutoSize = true;
            this.chkOnlyRunCorrectiveScriptsOnStateChange.Location = new System.Drawing.Point(134, 85);
            this.chkOnlyRunCorrectiveScriptsOnStateChange.Name = "chkOnlyRunCorrectiveScriptsOnStateChange";
            this.chkOnlyRunCorrectiveScriptsOnStateChange.Size = new System.Drawing.Size(260, 17);
            this.chkOnlyRunCorrectiveScriptsOnStateChange.TabIndex = 8;
            this.chkOnlyRunCorrectiveScriptsOnStateChange.Text = "Only run when state change (warnings and errors)\r\n";
            this.chkOnlyRunCorrectiveScriptsOnStateChange.UseVisualStyleBackColor = true;
            // 
            // cmdBrowseForRestorationScript
            // 
            this.cmdBrowseForRestorationScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseForRestorationScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowseForRestorationScript.Location = new System.Drawing.Point(520, 108);
            this.cmdBrowseForRestorationScript.Name = "cmdBrowseForRestorationScript";
            this.cmdBrowseForRestorationScript.Size = new System.Drawing.Size(33, 23);
            this.cmdBrowseForRestorationScript.TabIndex = 11;
            this.cmdBrowseForRestorationScript.Text = "- - -";
            this.cmdBrowseForRestorationScript.UseVisualStyleBackColor = true;
            this.cmdBrowseForRestorationScript.Click += new System.EventHandler(this.cmdBrowseForRestorationScript_Click);
            // 
            // txtRestorationScript
            // 
            this.txtRestorationScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRestorationScript.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRestorationScript.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtRestorationScript.Location = new System.Drawing.Point(134, 110);
            this.txtRestorationScript.Name = "txtRestorationScript";
            this.txtRestorationScript.Size = new System.Drawing.Size(381, 20);
            this.txtRestorationScript.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtRestorationScript, "Only runs once when state change from Warning/Error to Good");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(116, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Restoration (only once)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Corrective scripts";
            // 
            // cmdBrowseForWarningCorrectiveScript
            // 
            this.cmdBrowseForWarningCorrectiveScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseForWarningCorrectiveScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowseForWarningCorrectiveScript.Location = new System.Drawing.Point(520, 31);
            this.cmdBrowseForWarningCorrectiveScript.Name = "cmdBrowseForWarningCorrectiveScript";
            this.cmdBrowseForWarningCorrectiveScript.Size = new System.Drawing.Size(33, 23);
            this.cmdBrowseForWarningCorrectiveScript.TabIndex = 4;
            this.cmdBrowseForWarningCorrectiveScript.Text = "- - -";
            this.cmdBrowseForWarningCorrectiveScript.UseVisualStyleBackColor = true;
            this.cmdBrowseForWarningCorrectiveScript.Click += new System.EventHandler(this.cmdBrowseForWarningCorrectiveScript_Click);
            // 
            // chkCorrectiveScriptDisabled
            // 
            this.chkCorrectiveScriptDisabled.AutoSize = true;
            this.chkCorrectiveScriptDisabled.Location = new System.Drawing.Point(134, 2);
            this.chkCorrectiveScriptDisabled.Name = "chkCorrectiveScriptDisabled";
            this.chkCorrectiveScriptDisabled.Size = new System.Drawing.Size(144, 17);
            this.chkCorrectiveScriptDisabled.TabIndex = 1;
            this.chkCorrectiveScriptDisabled.Text = "Disable corrective scripts";
            this.chkCorrectiveScriptDisabled.UseVisualStyleBackColor = true;
            this.chkCorrectiveScriptDisabled.CheckedChanged += new System.EventHandler(this.chkCorrectiveScriptDisabled_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "On Warning";
            // 
            // cmdBrowseForErrorCorrectiveScript
            // 
            this.cmdBrowseForErrorCorrectiveScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseForErrorCorrectiveScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowseForErrorCorrectiveScript.Location = new System.Drawing.Point(520, 57);
            this.cmdBrowseForErrorCorrectiveScript.Name = "cmdBrowseForErrorCorrectiveScript";
            this.cmdBrowseForErrorCorrectiveScript.Size = new System.Drawing.Size(33, 23);
            this.cmdBrowseForErrorCorrectiveScript.TabIndex = 7;
            this.cmdBrowseForErrorCorrectiveScript.Text = "- - -";
            this.cmdBrowseForErrorCorrectiveScript.UseVisualStyleBackColor = true;
            this.cmdBrowseForErrorCorrectiveScript.Click += new System.EventHandler(this.cmdBrowseForErrorCorrectiveScript_Click);
            // 
            // txtCorrectiveScriptOnWarning
            // 
            this.txtCorrectiveScriptOnWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorrectiveScriptOnWarning.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCorrectiveScriptOnWarning.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtCorrectiveScriptOnWarning.Location = new System.Drawing.Point(134, 33);
            this.txtCorrectiveScriptOnWarning.Name = "txtCorrectiveScriptOnWarning";
            this.txtCorrectiveScriptOnWarning.Size = new System.Drawing.Size(381, 20);
            this.txtCorrectiveScriptOnWarning.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtCorrectiveScriptOnWarning, "Corrective script that runs every time a state of \'Warning\' is returned.\r\n");
            // 
            // txtCorrectiveScriptOnError
            // 
            this.txtCorrectiveScriptOnError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorrectiveScriptOnError.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCorrectiveScriptOnError.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtCorrectiveScriptOnError.Location = new System.Drawing.Point(134, 59);
            this.txtCorrectiveScriptOnError.Name = "txtCorrectiveScriptOnError";
            this.txtCorrectiveScriptOnError.Size = new System.Drawing.Size(381, 20);
            this.txtCorrectiveScriptOnError.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtCorrectiveScriptOnError, "Corrective script that runs every time a state of \'Error\' is returned.\r\n");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "On Error";
            // 
            // alertSuppressionGroupBox
            // 
            this.alertSuppressionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alertSuppressionGroupBox.Controls.Add(this.label26);
            this.alertSuppressionGroupBox.Controls.Add(this.label25);
            this.alertSuppressionGroupBox.Controls.Add(this.label24);
            this.alertSuppressionGroupBox.Controls.Add(this.label23);
            this.alertSuppressionGroupBox.Controls.Add(this.numericUpDownRepeatAlertInXPolls);
            this.alertSuppressionGroupBox.Controls.Add(this.delayAlertPollsNumericUpDown);
            this.alertSuppressionGroupBox.Controls.Add(this.AlertOnceInXPollsNumericUpDown);
            this.alertSuppressionGroupBox.Controls.Add(this.label22);
            this.alertSuppressionGroupBox.Controls.Add(this.label21);
            this.alertSuppressionGroupBox.Controls.Add(this.label18);
            this.alertSuppressionGroupBox.Controls.Add(this.label4);
            this.alertSuppressionGroupBox.Controls.Add(this.numericUpDownRepeatAlertInXMin);
            this.alertSuppressionGroupBox.Controls.Add(this.delayAlertSecNumericUpDown);
            this.alertSuppressionGroupBox.Controls.Add(this.label8);
            this.alertSuppressionGroupBox.Controls.Add(this.label10);
            this.alertSuppressionGroupBox.Controls.Add(this.label5);
            this.alertSuppressionGroupBox.Controls.Add(this.label11);
            this.alertSuppressionGroupBox.Controls.Add(this.label9);
            this.alertSuppressionGroupBox.Controls.Add(this.AlertOnceInXMinNumericUpDown);
            this.alertSuppressionGroupBox.Location = new System.Drawing.Point(7, 9);
            this.alertSuppressionGroupBox.Name = "alertSuppressionGroupBox";
            this.alertSuppressionGroupBox.Size = new System.Drawing.Size(560, 100);
            this.alertSuppressionGroupBox.TabIndex = 0;
            this.alertSuppressionGroupBox.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(313, 48);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(239, 13);
            this.label26.TabIndex = 12;
            this.label26.Text = "Note that # of polls depends on polling frequency";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(269, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "Polls";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(269, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 11;
            this.label24.Text = "Polls";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(269, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 5;
            this.label23.Text = "Polls";
            // 
            // numericUpDownRepeatAlertInXPolls
            // 
            this.numericUpDownRepeatAlertInXPolls.Location = new System.Drawing.Point(214, 20);
            this.numericUpDownRepeatAlertInXPolls.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownRepeatAlertInXPolls.Name = "numericUpDownRepeatAlertInXPolls";
            this.numericUpDownRepeatAlertInXPolls.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownRepeatAlertInXPolls.TabIndex = 4;
            // 
            // delayAlertPollsNumericUpDown
            // 
            this.delayAlertPollsNumericUpDown.Location = new System.Drawing.Point(214, 72);
            this.delayAlertPollsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.delayAlertPollsNumericUpDown.Name = "delayAlertPollsNumericUpDown";
            this.delayAlertPollsNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.delayAlertPollsNumericUpDown.TabIndex = 16;
            // 
            // AlertOnceInXPollsNumericUpDown
            // 
            this.AlertOnceInXPollsNumericUpDown.Location = new System.Drawing.Point(214, 46);
            this.AlertOnceInXPollsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AlertOnceInXPollsNumericUpDown.Name = "AlertOnceInXPollsNumericUpDown";
            this.AlertOnceInXPollsNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.AlertOnceInXPollsNumericUpDown.TabIndex = 10;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(313, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(224, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "(Only raise alert if Error/Warning state persists)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(313, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(232, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "(0 = never, Only applies to Errors and Warnings)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Alert suppresion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Repeat alert after";
            // 
            // numericUpDownRepeatAlertInXMin
            // 
            this.numericUpDownRepeatAlertInXMin.Location = new System.Drawing.Point(107, 20);
            this.numericUpDownRepeatAlertInXMin.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownRepeatAlertInXMin.Name = "numericUpDownRepeatAlertInXMin";
            this.numericUpDownRepeatAlertInXMin.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownRepeatAlertInXMin.TabIndex = 2;
            // 
            // delayAlertSecNumericUpDown
            // 
            this.delayAlertSecNumericUpDown.Location = new System.Drawing.Point(107, 72);
            this.delayAlertSecNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.delayAlertSecNumericUpDown.Name = "delayAlertSecNumericUpDown";
            this.delayAlertSecNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.delayAlertSecNumericUpDown.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Only alert once in";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Seconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Minutes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Delay alert";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Minutes";
            // 
            // AlertOnceInXMinNumericUpDown
            // 
            this.AlertOnceInXMinNumericUpDown.Location = new System.Drawing.Point(107, 46);
            this.AlertOnceInXMinNumericUpDown.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.AlertOnceInXMinNumericUpDown.Name = "AlertOnceInXMinNumericUpDown";
            this.AlertOnceInXMinNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.AlertOnceInXMinNumericUpDown.TabIndex = 8;
            // 
            // correctiveScriptOpenFileDialog
            // 
            this.correctiveScriptOpenFileDialog.DefaultExt = "cmd";
            this.correctiveScriptOpenFileDialog.Filter = "Scripts|*.cmd;*.bat;*.exe|PowerShell scripts|*.ps1|All Files|*.*";
            this.correctiveScriptOpenFileDialog.Title = "Corrective script";
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(271, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(284, 22);
            this.label36.TabIndex = 15;
            this.label36.Text = "Child collectors will Inherit setting unless overridden by higher value";
            // 
            // tvwEntries
            // 
            this.tvwEntries.ContextMenuStrip = this.itemsContextMenuStrip;
            this.tvwEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwEntries.FullRowSelect = true;
            this.tvwEntries.ImageIndex = 0;
            this.tvwEntries.ImageList = this.entriesImageList;
            this.tvwEntries.Location = new System.Drawing.Point(0, 160);
            this.tvwEntries.Name = "tvwEntries";
            this.tvwEntries.SelectedImageIndex = 0;
            this.tvwEntries.Size = new System.Drawing.Size(568, 144);
            this.tvwEntries.TabIndex = 2;
            this.tvwEntries.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwEntries_AfterSelect);
            this.tvwEntries.DoubleClick += new System.EventHandler(this.tvwEntries_DoubleClick);
            this.tvwEntries.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvwEntries_KeyUp);
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = false;
            this.lvwEntries.AutoResizeColumnIndex = 0;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.entriesColumnHeader,
            this.triggerColumnHeader});
            this.lvwEntries.ContextMenuStrip = this.itemsContextMenuStrip;
            this.lvwEntries.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwEntries.FullRowSelect = true;
            this.lvwEntries.HideSelection = false;
            this.lvwEntries.Location = new System.Drawing.Point(0, 25);
            this.lvwEntries.Name = "lvwEntries";
            this.lvwEntries.Size = new System.Drawing.Size(568, 135);
            this.lvwEntries.SmallImageList = this.entriesImageList;
            this.lvwEntries.TabIndex = 1;
            this.lvwEntries.UseCompatibleStateImageBehavior = false;
            this.lvwEntries.View = System.Windows.Forms.View.Details;
            this.lvwEntries.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwEntries_EnterKeyPressed);
            this.lvwEntries.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwEntries_DeleteKeyPressed);
            this.lvwEntries.SelectedIndexChanged += new System.EventHandler(this.lvwEntries_SelectedIndexChanged);
            this.lvwEntries.DoubleClick += new System.EventHandler(this.lvwEntries_DoubleClick);
            // 
            // entriesColumnHeader
            // 
            this.entriesColumnHeader.Text = "Entries";
            this.entriesColumnHeader.Width = 293;
            // 
            // triggerColumnHeader
            // 
            this.triggerColumnHeader.Text = "Alert triggers";
            this.triggerColumnHeader.Width = 249;
            // 
            // EditCollectorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "EditCollectorConfig";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Collector Config";
            this.Load += new System.EventHandler(this.EditCollectorConfig_Load);
            this.tabControl1.ResumeLayout(false);
            this.agentSettingstabPage.ResumeLayout(false);
            this.panCollectorConfigContainer.ResumeLayout(false);
            this.panCollectorConfigContainer.PerformLayout();
            this.itemsContextMenuStrip.ResumeLayout(false);
            this.collectorEditToolStrip.ResumeLayout(false);
            this.collectorEditToolStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.pollingOverridesGroupBox.ResumeLayout(false);
            this.pollingOverridesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlyAllowUpdateOncePerXSecNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.alertsTabPage.ResumeLayout(false);
            this.correctiveScriptsGroupBox.ResumeLayout(false);
            this.correctiveScriptsGroupBox.PerformLayout();
            this.alertSuppressionGroupBox.ResumeLayout(false);
            this.alertSuppressionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXPolls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertPollsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXPollsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXMinNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage agentSettingstabPage;
        private System.Windows.Forms.Panel panCollectorConfigContainer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel llblCollectorType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabelServiceWindows;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkRemoteAgentEnabled;
        private System.Windows.Forms.NumericUpDown remoteportNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRemoteAgentServer;
        private System.Windows.Forms.Button cmdRemoteAgentTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboParentCollector;
        private System.Windows.Forms.CheckBox chkCollectOnParentWarning;
        private System.Windows.Forms.Label label2;
        private ListViewEx lvwEntries;
        private System.Windows.Forms.ColumnHeader entriesColumnHeader;
        private System.Windows.Forms.ToolStrip collectorEditToolStrip;
        private System.Windows.Forms.ToolStripButton addCollectorConfigEntryToolStripButton;
        private System.Windows.Forms.ToolStripButton editCollectorConfigEntryToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteCollectorConfigEntryToolStripButton;
        private System.Windows.Forms.ContextMenuStrip itemsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog correctiveScriptOpenFileDialog;
        private TreeViewEx tvwEntries;
        private System.Windows.Forms.ImageList entriesImageList;
        private System.Windows.Forms.GroupBox correctiveScriptsGroupBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button cmdBrowseForWarningCorrectiveScript;
        private System.Windows.Forms.CheckBox chkCorrectiveScriptDisabled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdBrowseForErrorCorrectiveScript;
        private System.Windows.Forms.TextBox txtCorrectiveScriptOnWarning;
        private System.Windows.Forms.TextBox txtCorrectiveScriptOnError;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox alertSuppressionGroupBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeatAlertInXMin;
        private System.Windows.Forms.NumericUpDown delayAlertSecNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown AlertOnceInXMinNumericUpDown;
        private System.Windows.Forms.ColumnHeader triggerColumnHeader;
        private System.Windows.Forms.LinkLabel llblRemoteAgentInstallHelp;
        private System.Windows.Forms.Button cmdBrowseForRestorationScript;
        private System.Windows.Forms.TextBox txtRestorationScript;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkOnlyRunCorrectiveScriptsOnStateChange;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeatAlertInXPolls;
        private System.Windows.Forms.NumericUpDown delayAlertPollsNumericUpDown;
        private System.Windows.Forms.NumericUpDown AlertOnceInXPollsNumericUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox chkForceRemoteExcuteOnChildCollectors;
        private System.Windows.Forms.TabPage alertsTabPage;
        private System.Windows.Forms.GroupBox pollingOverridesGroupBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chkEnablePollingOverride;
        private System.Windows.Forms.NumericUpDown onlyAllowUpdateOncePerXSecNumericUpDown;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox chkEnablePollingFrequencySliding;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterThirdRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterSecondRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterFirstRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label36;
    }
}