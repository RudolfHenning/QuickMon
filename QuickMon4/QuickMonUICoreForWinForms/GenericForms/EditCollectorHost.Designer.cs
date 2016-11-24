﻿namespace QuickMon
{
    partial class EditCollectorHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCollectorHost));
            HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.chkExpandOnStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAgents = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.agentsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAgentEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agentsImageList = new System.Windows.Forms.ImageList(this.components);
            this.collectorAgentsEditToolStrip = new System.Windows.Forms.ToolStrip();
            this.addCollectorConfigEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addAgentEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editCollectorAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteCollectorAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enableAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.disableAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.agentCheckSequenceToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.tabDependencies = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cboChildCheckBehaviour = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMonitorPack = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboParentCollector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabOperational = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.linkLabelServiceWindows = new System.Windows.Forms.LinkLabel();
            this.pollingOverridesGroupBox = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
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
            this.tabRemoteSec = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboRemoteAgentServer = new System.Windows.Forms.ComboBox();
            this.chkRunLocalOnRemoteHostConnectionFailure = new System.Windows.Forms.CheckBox();
            this.chkBlockParentRHOverride = new System.Windows.Forms.CheckBox();
            this.chkForceRemoteExcuteOnChildCollectors = new System.Windows.Forms.CheckBox();
            this.llblRemoteAgentInstallHelp = new System.Windows.Forms.LinkLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.chkRemoteAgentEnabled = new System.Windows.Forms.CheckBox();
            this.remoteportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdRemoteAgentTest = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmdTestRunAs = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.chkRunAsEnabled = new System.Windows.Forms.CheckBox();
            this.txtRunAs = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.tabAlerts = new System.Windows.Forms.TabPage();
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
            this.chkAlertsPaused = new System.Windows.Forms.CheckBox();
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
            this.tabVariables = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label42 = new System.Windows.Forms.Label();
            this.txtConfigVarReplaceByValue = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtConfigVarSearchFor = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtCategories = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label50 = new System.Windows.Forms.Label();
            this.cmdSetNoteText = new System.Windows.Forms.Button();
            this.cboTextType = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtNotesText = new System.Windows.Forms.TextBox();
            this.lblNoteTextChangeIndicator = new System.Windows.Forms.Label();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.llblExportConfigAsTemplate = new System.Windows.Forms.LinkLabel();
            this.entriesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.triggerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.correctiveScriptOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboExpandOnStartOption = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label47 = new System.Windows.Forms.Label();
            this.agentsTreeListView = new HenIT.Windows.Controls.TreeListView();
            this.nameColumnHeadertlv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.summaryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwConfigVars = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabAgents.SuspendLayout();
            this.panel2.SuspendLayout();
            this.agentsContextMenuStrip.SuspendLayout();
            this.collectorAgentsEditToolStrip.SuspendLayout();
            this.tabDependencies.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabOperational.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pollingOverridesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlyAllowUpdateOncePerXSecNumericUpDown)).BeginInit();
            this.tabRemoteSec.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tabAlerts.SuspendLayout();
            this.correctiveScriptsGroupBox.SuspendLayout();
            this.alertSuppressionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXPolls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertPollsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXPollsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXMinNumericUpDown)).BeginInit();
            this.tabVariables.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkExpandOnStart
            // 
            this.chkExpandOnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExpandOnStart.AutoSize = true;
            this.chkExpandOnStart.Checked = true;
            this.chkExpandOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExpandOnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkExpandOnStart.Location = new System.Drawing.Point(425, 13);
            this.chkExpandOnStart.Name = "chkExpandOnStart";
            this.chkExpandOnStart.Size = new System.Drawing.Size(98, 17);
            this.chkExpandOnStart.TabIndex = 3;
            this.chkExpandOnStart.Text = "Expand on start";
            this.chkExpandOnStart.UseVisualStyleBackColor = true;
            this.chkExpandOnStart.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnabled.Location = new System.Drawing.Point(300, 14);
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
            this.txtName.Location = new System.Drawing.Point(60, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(235, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "This Collector Id:";
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(108, 179);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "Id";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(502, 351);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(421, 351);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAgents);
            this.tabControl1.Controls.Add(this.tabDependencies);
            this.tabControl1.Controls.Add(this.tabOperational);
            this.tabControl1.Controls.Add(this.tabRemoteSec);
            this.tabControl1.Controls.Add(this.tabAlerts);
            this.tabControl1.Controls.Add(this.tabVariables);
            this.tabControl1.Controls.Add(this.tabCategories);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(1, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 307);
            this.tabControl1.TabIndex = 5;
            // 
            // tabAgents
            // 
            this.tabAgents.BackColor = System.Drawing.Color.White;
            this.tabAgents.Controls.Add(this.panel2);
            this.tabAgents.Controls.Add(this.collectorAgentsEditToolStrip);
            this.tabAgents.Location = new System.Drawing.Point(4, 22);
            this.tabAgents.Name = "tabAgents";
            this.tabAgents.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgents.Size = new System.Drawing.Size(575, 281);
            this.tabAgents.TabIndex = 0;
            this.tabAgents.Text = "Agents";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.agentsTreeListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 248);
            this.panel2.TabIndex = 2;
            // 
            // agentsContextMenuStrip
            // 
            this.agentsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.agentsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAgentToolStripMenuItem,
            this.addAgentEntryToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.toolStripMenuItem2,
            this.enableToolStripMenuItem});
            this.agentsContextMenuStrip.Name = "agentsContextMenuStrip";
            this.agentsContextMenuStrip.Size = new System.Drawing.Size(166, 198);
            // 
            // addAgentToolStripMenuItem
            // 
            this.addAgentToolStripMenuItem.Image = global::QuickMon.Properties.Resources.GearWithPlus;
            this.addAgentToolStripMenuItem.Name = "addAgentToolStripMenuItem";
            this.addAgentToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.addAgentToolStripMenuItem.Text = "Add Agent";
            this.addAgentToolStripMenuItem.Click += new System.EventHandler(this.addCollectorConfigEntryToolStripButton_Click);
            // 
            // addAgentEntryToolStripMenuItem
            // 
            this.addAgentEntryToolStripMenuItem.Image = global::QuickMon.Properties.Resources.GearWithPlusGreen;
            this.addAgentEntryToolStripMenuItem.Name = "addAgentEntryToolStripMenuItem";
            this.addAgentEntryToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.addAgentEntryToolStripMenuItem.Text = "Add Agent entry";
            this.addAgentEntryToolStripMenuItem.Click += new System.EventHandler(this.addAgentEntryToolStripButton_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::QuickMon.Properties.Resources.proc2;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editCollectorAgentToolStripButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteCollectorAgentToolStripButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.moveUpToolStripMenuItem.Text = "Move up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpAgentToolStripButton_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.moveDownToolStripMenuItem.Text = "Move down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownAgentToolStripButton_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 6);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Image = global::QuickMon.Properties.Resources._246_7;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // agentsImageList
            // 
            this.agentsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("agentsImageList.ImageStream")));
            this.agentsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.agentsImageList.Images.SetKeyName(0, "NoGo.ico");
            this.agentsImageList.Images.SetKeyName(1, "Configuration.ico");
            this.agentsImageList.Images.SetKeyName(2, "127_9.ico");
            // 
            // collectorAgentsEditToolStrip
            // 
            this.collectorAgentsEditToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.collectorAgentsEditToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.collectorAgentsEditToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorConfigEntryToolStripButton,
            this.addAgentEntryToolStripButton,
            this.editCollectorAgentToolStripButton,
            this.deleteCollectorAgentToolStripButton,
            this.toolStripSeparator2,
            this.moveUpAgentToolStripButton,
            this.moveDownAgentToolStripButton,
            this.toolStripSeparator3,
            this.enableAgentToolStripButton,
            this.disableAgentToolStripButton,
            this.toolStripLabel1,
            this.agentCheckSequenceToolStripComboBox});
            this.collectorAgentsEditToolStrip.Location = new System.Drawing.Point(3, 3);
            this.collectorAgentsEditToolStrip.Name = "collectorAgentsEditToolStrip";
            this.collectorAgentsEditToolStrip.Size = new System.Drawing.Size(569, 27);
            this.collectorAgentsEditToolStrip.TabIndex = 0;
            this.collectorAgentsEditToolStrip.TabStop = true;
            this.collectorAgentsEditToolStrip.Text = "toolStrip1";
            // 
            // addCollectorConfigEntryToolStripButton
            // 
            this.addCollectorConfigEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCollectorConfigEntryToolStripButton.Image = global::QuickMon.Properties.Resources.GearWithPlus;
            this.addCollectorConfigEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCollectorConfigEntryToolStripButton.Name = "addCollectorConfigEntryToolStripButton";
            this.addCollectorConfigEntryToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addCollectorConfigEntryToolStripButton.Text = "Add new Agent";
            this.addCollectorConfigEntryToolStripButton.ToolTipText = "Add entry";
            this.addCollectorConfigEntryToolStripButton.Click += new System.EventHandler(this.addCollectorConfigEntryToolStripButton_Click);
            // 
            // addAgentEntryToolStripButton
            // 
            this.addAgentEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addAgentEntryToolStripButton.Enabled = false;
            this.addAgentEntryToolStripButton.Image = global::QuickMon.Properties.Resources.GearWithPlusGreen;
            this.addAgentEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addAgentEntryToolStripButton.Name = "addAgentEntryToolStripButton";
            this.addAgentEntryToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addAgentEntryToolStripButton.Text = "Add new Agent entry";
            this.addAgentEntryToolStripButton.Click += new System.EventHandler(this.addAgentEntryToolStripButton_Click);
            // 
            // editCollectorAgentToolStripButton
            // 
            this.editCollectorAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editCollectorAgentToolStripButton.Enabled = false;
            this.editCollectorAgentToolStripButton.Image = global::QuickMon.Properties.Resources.proc2;
            this.editCollectorAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editCollectorAgentToolStripButton.Name = "editCollectorAgentToolStripButton";
            this.editCollectorAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.editCollectorAgentToolStripButton.Text = "Edit selected Agent";
            this.editCollectorAgentToolStripButton.Click += new System.EventHandler(this.editCollectorAgentToolStripButton_Click);
            // 
            // deleteCollectorAgentToolStripButton
            // 
            this.deleteCollectorAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteCollectorAgentToolStripButton.Enabled = false;
            this.deleteCollectorAgentToolStripButton.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.deleteCollectorAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteCollectorAgentToolStripButton.Name = "deleteCollectorAgentToolStripButton";
            this.deleteCollectorAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.deleteCollectorAgentToolStripButton.Text = "Delete selected Agent(s)";
            this.deleteCollectorAgentToolStripButton.Click += new System.EventHandler(this.deleteCollectorAgentToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // moveUpAgentToolStripButton
            // 
            this.moveUpAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpAgentToolStripButton.Enabled = false;
            this.moveUpAgentToolStripButton.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpAgentToolStripButton.Name = "moveUpAgentToolStripButton";
            this.moveUpAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveUpAgentToolStripButton.Text = "Move selected item up";
            this.moveUpAgentToolStripButton.Click += new System.EventHandler(this.moveUpAgentToolStripButton_Click);
            // 
            // moveDownAgentToolStripButton
            // 
            this.moveDownAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownAgentToolStripButton.Enabled = false;
            this.moveDownAgentToolStripButton.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownAgentToolStripButton.Name = "moveDownAgentToolStripButton";
            this.moveDownAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveDownAgentToolStripButton.Text = "Move selected item down";
            this.moveDownAgentToolStripButton.Click += new System.EventHandler(this.moveDownAgentToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // enableAgentToolStripButton
            // 
            this.enableAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.enableAgentToolStripButton.Enabled = false;
            this.enableAgentToolStripButton.Image = global::QuickMon.Properties.Resources._246_7;
            this.enableAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enableAgentToolStripButton.Name = "enableAgentToolStripButton";
            this.enableAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.enableAgentToolStripButton.Text = "Enable";
            this.enableAgentToolStripButton.Click += new System.EventHandler(this.enableAgentToolStripButton_Click);
            // 
            // disableAgentToolStripButton
            // 
            this.disableAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.disableAgentToolStripButton.Enabled = false;
            this.disableAgentToolStripButton.Image = global::QuickMon.Properties.Resources.NoGo;
            this.disableAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disableAgentToolStripButton.Name = "disableAgentToolStripButton";
            this.disableAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.disableAgentToolStripButton.Text = "Disable";
            this.disableAgentToolStripButton.Click += new System.EventHandler(this.disableAgentToolStripButton_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(126, 24);
            this.toolStripLabel1.Text = "Agent check se&quence";
            // 
            // agentCheckSequenceToolStripComboBox
            // 
            this.agentCheckSequenceToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agentCheckSequenceToolStripComboBox.Items.AddRange(new object[] {
            "All",
            "First Success",
            "First Error"});
            this.agentCheckSequenceToolStripComboBox.Name = "agentCheckSequenceToolStripComboBox";
            this.agentCheckSequenceToolStripComboBox.Size = new System.Drawing.Size(121, 27);
            // 
            // tabDependencies
            // 
            this.tabDependencies.BackColor = System.Drawing.Color.White;
            this.tabDependencies.Controls.Add(this.label6);
            this.tabDependencies.Controls.Add(this.groupBox4);
            this.tabDependencies.Controls.Add(this.groupBox1);
            this.tabDependencies.Controls.Add(this.lblId);
            this.tabDependencies.Location = new System.Drawing.Point(4, 22);
            this.tabDependencies.Name = "tabDependencies";
            this.tabDependencies.Padding = new System.Windows.Forms.Padding(3);
            this.tabDependencies.Size = new System.Drawing.Size(575, 281);
            this.tabDependencies.TabIndex = 3;
            this.tabDependencies.Text = "Dependencies";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Controls.Add(this.cboChildCheckBehaviour);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(3, 116);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(566, 57);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(6, 1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 13);
            this.label38.TabIndex = 0;
            this.label38.Text = "Children";
            // 
            // cboChildCheckBehaviour
            // 
            this.cboChildCheckBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChildCheckBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChildCheckBehaviour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboChildCheckBehaviour.FormattingEnabled = true;
            this.cboChildCheckBehaviour.Items.AddRange(new object[] {
            "Only Run On Success",
            "Continue On Warning",
            "Continue On Warning Or Error"});
            this.cboChildCheckBehaviour.Location = new System.Drawing.Point(108, 19);
            this.cboChildCheckBehaviour.Name = "cboChildCheckBehaviour";
            this.cboChildCheckBehaviour.Size = new System.Drawing.Size(452, 21);
            this.cboChildCheckBehaviour.TabIndex = 2;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(10, 22);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(88, 13);
            this.label39.TabIndex = 1;
            this.label39.Text = "Check behaviour";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtMonitorPack);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboParentCollector);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtMonitorPack
            // 
            this.txtMonitorPack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonitorPack.Location = new System.Drawing.Point(108, 23);
            this.txtMonitorPack.Name = "txtMonitorPack";
            this.txtMonitorPack.ReadOnly = true;
            this.txtMonitorPack.Size = new System.Drawing.Size(452, 20);
            this.txtMonitorPack.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Monitor pack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parent";
            // 
            // cboParentCollector
            // 
            this.cboParentCollector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboParentCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParentCollector.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboParentCollector.FormattingEnabled = true;
            this.cboParentCollector.Location = new System.Drawing.Point(108, 55);
            this.cboParentCollector.Name = "cboParentCollector";
            this.cboParentCollector.Size = new System.Drawing.Size(452, 21);
            this.cboParentCollector.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Collector host";
            // 
            // tabOperational
            // 
            this.tabOperational.BackColor = System.Drawing.Color.White;
            this.tabOperational.Controls.Add(this.groupBox3);
            this.tabOperational.Controls.Add(this.pollingOverridesGroupBox);
            this.tabOperational.Location = new System.Drawing.Point(4, 22);
            this.tabOperational.Name = "tabOperational";
            this.tabOperational.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperational.Size = new System.Drawing.Size(575, 281);
            this.tabOperational.TabIndex = 1;
            this.tabOperational.Text = "Operational";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.linkLabelServiceWindows);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(6, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 54);
            this.groupBox3.TabIndex = 2;
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
            this.linkLabelServiceWindows.Size = new System.Drawing.Size(557, 35);
            this.linkLabelServiceWindows.TabIndex = 1;
            this.linkLabelServiceWindows.TabStop = true;
            this.linkLabelServiceWindows.Text = "None";
            this.linkLabelServiceWindows.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelServiceWindows_LinkClicked);
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
            this.pollingOverridesGroupBox.Location = new System.Drawing.Point(6, 6);
            this.pollingOverridesGroupBox.Name = "pollingOverridesGroupBox";
            this.pollingOverridesGroupBox.Size = new System.Drawing.Size(563, 136);
            this.pollingOverridesGroupBox.TabIndex = 0;
            this.pollingOverridesGroupBox.TabStop = false;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(273, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(284, 22);
            this.label36.TabIndex = 5;
            this.label36.Text = "Child collectors will Inherit setting unless overridden by higher value";
            // 
            // chkEnablePollingOverride
            // 
            this.chkEnablePollingOverride.AutoSize = true;
            this.chkEnablePollingOverride.Checked = true;
            this.chkEnablePollingOverride.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.TabIndex = 14;
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(218, 103);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(49, 13);
            this.label34.TabIndex = 15;
            this.label34.Text = "Seconds";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 103);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(85, 13);
            this.label35.TabIndex = 13;
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
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.TabIndex = 11;
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(492, 77);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 13);
            this.label32.TabIndex = 12;
            this.label32.Text = "Seconds";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(295, 77);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(125, 13);
            this.label33.TabIndex = 10;
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
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.TabIndex = 8;
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(218, 77);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 9;
            this.label30.Text = "Seconds";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 77);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(133, 13);
            this.label31.TabIndex = 7;
            this.label31.Text = "Frequency after first repeat";
            // 
            // chkEnablePollingFrequencySliding
            // 
            this.chkEnablePollingFrequencySliding.AutoSize = true;
            this.chkEnablePollingFrequencySliding.Location = new System.Drawing.Point(14, 53);
            this.chkEnablePollingFrequencySliding.Name = "chkEnablePollingFrequencySliding";
            this.chkEnablePollingFrequencySliding.Size = new System.Drawing.Size(370, 17);
            this.chkEnablePollingFrequencySliding.TabIndex = 6;
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
            // tabRemoteSec
            // 
            this.tabRemoteSec.BackColor = System.Drawing.Color.White;
            this.tabRemoteSec.Controls.Add(this.groupBox2);
            this.tabRemoteSec.Controls.Add(this.groupBox6);
            this.tabRemoteSec.Location = new System.Drawing.Point(4, 22);
            this.tabRemoteSec.Name = "tabRemoteSec";
            this.tabRemoteSec.Padding = new System.Windows.Forms.Padding(3);
            this.tabRemoteSec.Size = new System.Drawing.Size(575, 281);
            this.tabRemoteSec.TabIndex = 5;
            this.tabRemoteSec.Text = "Remote agent && Security";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboRemoteAgentServer);
            this.groupBox2.Controls.Add(this.chkRunLocalOnRemoteHostConnectionFailure);
            this.groupBox2.Controls.Add(this.chkBlockParentRHOverride);
            this.groupBox2.Controls.Add(this.chkForceRemoteExcuteOnChildCollectors);
            this.groupBox2.Controls.Add(this.llblRemoteAgentInstallHelp);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.chkRemoteAgentEnabled);
            this.groupBox2.Controls.Add(this.remoteportNumericUpDown);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cmdRemoteAgentTest);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cboRemoteAgentServer
            // 
            this.cboRemoteAgentServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRemoteAgentServer.FormattingEnabled = true;
            this.cboRemoteAgentServer.Location = new System.Drawing.Point(138, 23);
            this.cboRemoteAgentServer.Name = "cboRemoteAgentServer";
            this.cboRemoteAgentServer.Size = new System.Drawing.Size(198, 21);
            this.cboRemoteAgentServer.Sorted = true;
            this.cboRemoteAgentServer.TabIndex = 5;
            this.cboRemoteAgentServer.SelectedIndexChanged += new System.EventHandler(this.cboRemoteAgentServer_SelectedIndexChanged);
            this.cboRemoteAgentServer.SelectionChangeCommitted += new System.EventHandler(this.cboRemoteAgentServer_SelectionChangeCommitted);
            this.cboRemoteAgentServer.TextChanged += new System.EventHandler(this.cboRemoteAgentServer_TextChanged);
            this.cboRemoteAgentServer.Leave += new System.EventHandler(this.cboRemoteAgentServer_Leave);
            // 
            // chkRunLocalOnRemoteHostConnectionFailure
            // 
            this.chkRunLocalOnRemoteHostConnectionFailure.AutoSize = true;
            this.chkRunLocalOnRemoteHostConnectionFailure.Location = new System.Drawing.Point(256, 50);
            this.chkRunLocalOnRemoteHostConnectionFailure.Name = "chkRunLocalOnRemoteHostConnectionFailure";
            this.chkRunLocalOnRemoteHostConnectionFailure.Size = new System.Drawing.Size(221, 17);
            this.chkRunLocalOnRemoteHostConnectionFailure.TabIndex = 10;
            this.chkRunLocalOnRemoteHostConnectionFailure.Text = "Run locally if remote host connection fails";
            this.chkRunLocalOnRemoteHostConnectionFailure.UseVisualStyleBackColor = true;
            // 
            // chkBlockParentRHOverride
            // 
            this.chkBlockParentRHOverride.AutoSize = true;
            this.chkBlockParentRHOverride.Location = new System.Drawing.Point(28, 50);
            this.chkBlockParentRHOverride.Name = "chkBlockParentRHOverride";
            this.chkBlockParentRHOverride.Size = new System.Drawing.Size(190, 17);
            this.chkBlockParentRHOverride.TabIndex = 9;
            this.chkBlockParentRHOverride.Text = "Block parent remote agent settings";
            this.chkBlockParentRHOverride.UseVisualStyleBackColor = true;
            // 
            // chkForceRemoteExcuteOnChildCollectors
            // 
            this.chkForceRemoteExcuteOnChildCollectors.AutoSize = true;
            this.chkForceRemoteExcuteOnChildCollectors.BackColor = System.Drawing.Color.White;
            this.chkForceRemoteExcuteOnChildCollectors.Location = new System.Drawing.Point(256, 0);
            this.chkForceRemoteExcuteOnChildCollectors.Name = "chkForceRemoteExcuteOnChildCollectors";
            this.chkForceRemoteExcuteOnChildCollectors.Size = new System.Drawing.Size(139, 17);
            this.chkForceRemoteExcuteOnChildCollectors.TabIndex = 2;
            this.chkForceRemoteExcuteOnChildCollectors.Text = "Override child collectors";
            this.chkForceRemoteExcuteOnChildCollectors.UseVisualStyleBackColor = false;
            this.chkForceRemoteExcuteOnChildCollectors.CheckedChanged += new System.EventHandler(this.chkForceRemoteExcuteOnChildCollectors_CheckedChanged);
            // 
            // llblRemoteAgentInstallHelp
            // 
            this.llblRemoteAgentInstallHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblRemoteAgentInstallHelp.AutoSize = true;
            this.llblRemoteAgentInstallHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRemoteAgentInstallHelp.Location = new System.Drawing.Point(496, 1);
            this.llblRemoteAgentInstallHelp.Name = "llblRemoteAgentInstallHelp";
            this.llblRemoteAgentInstallHelp.Size = new System.Drawing.Size(57, 13);
            this.llblRemoteAgentInstallHelp.TabIndex = 3;
            this.llblRemoteAgentInstallHelp.TabStop = true;
            this.llblRemoteAgentInstallHelp.Text = "Install help";
            this.llblRemoteAgentInstallHelp.Visible = false;
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
            this.chkRemoteAgentEnabled.BackColor = System.Drawing.Color.White;
            this.chkRemoteAgentEnabled.Location = new System.Drawing.Point(108, 0);
            this.chkRemoteAgentEnabled.Name = "chkRemoteAgentEnabled";
            this.chkRemoteAgentEnabled.Size = new System.Drawing.Size(142, 17);
            this.chkRemoteAgentEnabled.TabIndex = 1;
            this.chkRemoteAgentEnabled.Text = "Enabled for this collector";
            this.chkRemoteAgentEnabled.UseVisualStyleBackColor = false;
            this.chkRemoteAgentEnabled.CheckedChanged += new System.EventHandler(this.chkRemoteAgentEnabled_CheckedChanged);
            // 
            // remoteportNumericUpDown
            // 
            this.remoteportNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteportNumericUpDown.Enabled = false;
            this.remoteportNumericUpDown.Location = new System.Drawing.Point(374, 24);
            this.remoteportNumericUpDown.Maximum = new decimal(new int[] {
            65536,
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
            this.remoteportNumericUpDown.TabIndex = 7;
            this.remoteportNumericUpDown.Value = new decimal(new int[] {
            48181,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Remote server name";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(342, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Port";
            // 
            // cmdRemoteAgentTest
            // 
            this.cmdRemoteAgentTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoteAgentTest.Enabled = false;
            this.cmdRemoteAgentTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoteAgentTest.Location = new System.Drawing.Point(487, 21);
            this.cmdRemoteAgentTest.Name = "cmdRemoteAgentTest";
            this.cmdRemoteAgentTest.Size = new System.Drawing.Size(70, 23);
            this.cmdRemoteAgentTest.TabIndex = 8;
            this.cmdRemoteAgentTest.Text = "Test";
            this.cmdRemoteAgentTest.UseVisualStyleBackColor = true;
            this.cmdRemoteAgentTest.Click += new System.EventHandler(this.cmdRemoteAgentTest_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.cmdTestRunAs);
            this.groupBox6.Controls.Add(this.label45);
            this.groupBox6.Controls.Add(this.chkRunAsEnabled);
            this.groupBox6.Controls.Add(this.txtRunAs);
            this.groupBox6.Controls.Add(this.label43);
            this.groupBox6.Controls.Add(this.label44);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Location = new System.Drawing.Point(6, 87);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(563, 78);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // cmdTestRunAs
            // 
            this.cmdTestRunAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestRunAs.Enabled = false;
            this.cmdTestRunAs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestRunAs.Location = new System.Drawing.Point(487, 21);
            this.cmdTestRunAs.Name = "cmdTestRunAs";
            this.cmdTestRunAs.Size = new System.Drawing.Size(70, 23);
            this.cmdTestRunAs.TabIndex = 9;
            this.cmdTestRunAs.Text = "Test";
            this.cmdTestRunAs.UseVisualStyleBackColor = true;
            this.cmdTestRunAs.Click += new System.EventHandler(this.cmdTestRunAs_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(105, 46);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(305, 13);
            this.label45.TabIndex = 4;
            this.label45.Text = "To set up a password use the Monitor pack configuration editor";
            // 
            // chkRunAsEnabled
            // 
            this.chkRunAsEnabled.AutoSize = true;
            this.chkRunAsEnabled.BackColor = System.Drawing.Color.White;
            this.chkRunAsEnabled.Checked = true;
            this.chkRunAsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunAsEnabled.Location = new System.Drawing.Point(72, 0);
            this.chkRunAsEnabled.Name = "chkRunAsEnabled";
            this.chkRunAsEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkRunAsEnabled.TabIndex = 3;
            this.chkRunAsEnabled.Text = "Enabled";
            this.chkRunAsEnabled.UseVisualStyleBackColor = false;
            // 
            // txtRunAs
            // 
            this.txtRunAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRunAs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRunAs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRunAs.Location = new System.Drawing.Point(108, 23);
            this.txtRunAs.Name = "txtRunAs";
            this.txtRunAs.Size = new System.Drawing.Size(373, 20);
            this.txtRunAs.TabIndex = 2;
            this.txtRunAs.TextChanged += new System.EventHandler(this.txtRunAs_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(47, 13);
            this.label43.TabIndex = 0;
            this.label43.Text = "Run as";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(10, 26);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(58, 13);
            this.label44.TabIndex = 1;
            this.label44.Text = "User name";
            // 
            // tabAlerts
            // 
            this.tabAlerts.BackColor = System.Drawing.Color.White;
            this.tabAlerts.Controls.Add(this.correctiveScriptsGroupBox);
            this.tabAlerts.Controls.Add(this.alertSuppressionGroupBox);
            this.tabAlerts.Location = new System.Drawing.Point(4, 22);
            this.tabAlerts.Name = "tabAlerts";
            this.tabAlerts.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlerts.Size = new System.Drawing.Size(575, 281);
            this.tabAlerts.TabIndex = 2;
            this.tabAlerts.Text = "Alerts";
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
            this.correctiveScriptsGroupBox.Location = new System.Drawing.Point(6, 112);
            this.correctiveScriptsGroupBox.Name = "correctiveScriptsGroupBox";
            this.correctiveScriptsGroupBox.Size = new System.Drawing.Size(561, 138);
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
            this.cmdBrowseForRestorationScript.Location = new System.Drawing.Point(521, 108);
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
            this.txtRestorationScript.Size = new System.Drawing.Size(382, 20);
            this.txtRestorationScript.TabIndex = 10;
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
            this.cmdBrowseForWarningCorrectiveScript.Location = new System.Drawing.Point(521, 31);
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
            this.cmdBrowseForErrorCorrectiveScript.Location = new System.Drawing.Point(521, 57);
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
            this.txtCorrectiveScriptOnWarning.Size = new System.Drawing.Size(382, 20);
            this.txtCorrectiveScriptOnWarning.TabIndex = 3;
            // 
            // txtCorrectiveScriptOnError
            // 
            this.txtCorrectiveScriptOnError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorrectiveScriptOnError.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCorrectiveScriptOnError.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtCorrectiveScriptOnError.Location = new System.Drawing.Point(134, 59);
            this.txtCorrectiveScriptOnError.Name = "txtCorrectiveScriptOnError";
            this.txtCorrectiveScriptOnError.Size = new System.Drawing.Size(382, 20);
            this.txtCorrectiveScriptOnError.TabIndex = 6;
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
            this.alertSuppressionGroupBox.Controls.Add(this.chkAlertsPaused);
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
            this.alertSuppressionGroupBox.Location = new System.Drawing.Point(6, 6);
            this.alertSuppressionGroupBox.Name = "alertSuppressionGroupBox";
            this.alertSuppressionGroupBox.Size = new System.Drawing.Size(561, 100);
            this.alertSuppressionGroupBox.TabIndex = 0;
            this.alertSuppressionGroupBox.TabStop = false;
            // 
            // chkAlertsPaused
            // 
            this.chkAlertsPaused.AutoSize = true;
            this.chkAlertsPaused.Location = new System.Drawing.Point(134, -1);
            this.chkAlertsPaused.Name = "chkAlertsPaused";
            this.chkAlertsPaused.Size = new System.Drawing.Size(208, 17);
            this.chkAlertsPaused.TabIndex = 1;
            this.chkAlertsPaused.Text = "Pause/ignore all alerts for this collector";
            this.chkAlertsPaused.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(313, 48);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(239, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Note that # of polls depends on polling frequency";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(269, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 18;
            this.label25.Text = "Polls";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(269, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "Polls";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(269, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 6;
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
            this.numericUpDownRepeatAlertInXPolls.TabIndex = 5;
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
            this.delayAlertPollsNumericUpDown.TabIndex = 17;
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
            this.AlertOnceInXPollsNumericUpDown.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(313, 74);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(224, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "(Only raise alert if Error/Warning state persists)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(313, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(232, 13);
            this.label21.TabIndex = 7;
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
            this.label4.TabIndex = 2;
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
            this.numericUpDownRepeatAlertInXMin.TabIndex = 3;
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
            this.delayAlertSecNumericUpDown.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Only alert once in";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Seconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Minutes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Delay alert";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 10;
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
            this.AlertOnceInXMinNumericUpDown.TabIndex = 9;
            // 
            // tabVariables
            // 
            this.tabVariables.BackColor = System.Drawing.Color.White;
            this.tabVariables.Controls.Add(this.groupBox5);
            this.tabVariables.Location = new System.Drawing.Point(4, 22);
            this.tabVariables.Name = "tabVariables";
            this.tabVariables.Padding = new System.Windows.Forms.Padding(3);
            this.tabVariables.Size = new System.Drawing.Size(575, 281);
            this.tabVariables.TabIndex = 4;
            this.tabVariables.Text = "Variables";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.toolStrip1);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.txtConfigVarReplaceByValue);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.txtConfigVarSearchFor);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.lvwConfigVars);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Location = new System.Drawing.Point(7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(562, 269);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConfigVarToolStripButton,
            this.deleteConfigVarToolStripButton,
            this.toolStripSeparator1,
            this.moveUpConfigVarToolStripButton,
            this.moveDownConfigVarToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(556, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addConfigVarToolStripButton
            // 
            this.addConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addConfigVarToolStripButton.Name = "addConfigVarToolStripButton";
            this.addConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addConfigVarToolStripButton.Text = "Create new";
            this.addConfigVarToolStripButton.ToolTipText = "Add entry";
            this.addConfigVarToolStripButton.Click += new System.EventHandler(this.addConfigVarToolStripButton_Click);
            // 
            // deleteConfigVarToolStripButton
            // 
            this.deleteConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteConfigVarToolStripButton.Enabled = false;
            this.deleteConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.deleteConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteConfigVarToolStripButton.Name = "deleteConfigVarToolStripButton";
            this.deleteConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.deleteConfigVarToolStripButton.Text = "Delete selected item(s)";
            this.deleteConfigVarToolStripButton.Click += new System.EventHandler(this.deleteConfigVarToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // moveUpConfigVarToolStripButton
            // 
            this.moveUpConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpConfigVarToolStripButton.Enabled = false;
            this.moveUpConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpConfigVarToolStripButton.Name = "moveUpConfigVarToolStripButton";
            this.moveUpConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveUpConfigVarToolStripButton.Text = "Move selected item up";
            this.moveUpConfigVarToolStripButton.Click += new System.EventHandler(this.moveUpConfigVarToolStripButton_Click);
            // 
            // moveDownConfigVarToolStripButton
            // 
            this.moveDownConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownConfigVarToolStripButton.Enabled = false;
            this.moveDownConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownConfigVarToolStripButton.Name = "moveDownConfigVarToolStripButton";
            this.moveDownConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveDownConfigVarToolStripButton.Text = "Move selected item down";
            this.moveDownConfigVarToolStripButton.Click += new System.EventHandler(this.moveDownConfigVarToolStripButton_Click);
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(6, 237);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(550, 29);
            this.label42.TabIndex = 7;
            this.label42.Text = "Suggestions: Use \'variable\' names that are unique in the config XML. e.g. %SomeVa" +
    "lue%. Be careful when using quotes/doublequotes or any other characters that are" +
    " \'special\' in XML.";
            // 
            // txtConfigVarReplaceByValue
            // 
            this.txtConfigVarReplaceByValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConfigVarReplaceByValue.Location = new System.Drawing.Point(335, 213);
            this.txtConfigVarReplaceByValue.Name = "txtConfigVarReplaceByValue";
            this.txtConfigVarReplaceByValue.Size = new System.Drawing.Size(173, 20);
            this.txtConfigVarReplaceByValue.TabIndex = 6;
            this.txtConfigVarReplaceByValue.TextChanged += new System.EventHandler(this.txtConfigVarReplaceByValue_TextChanged);
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(260, 216);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 13);
            this.label41.TabIndex = 5;
            this.label41.Text = "Replace with";
            // 
            // txtConfigVarSearchFor
            // 
            this.txtConfigVarSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConfigVarSearchFor.Location = new System.Drawing.Point(81, 213);
            this.txtConfigVarSearchFor.Name = "txtConfigVarSearchFor";
            this.txtConfigVarSearchFor.Size = new System.Drawing.Size(173, 20);
            this.txtConfigVarSearchFor.TabIndex = 4;
            this.txtConfigVarSearchFor.TextChanged += new System.EventHandler(this.txtConfigVarSearchFor_TextChanged);
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 216);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 13);
            this.label40.TabIndex = 3;
            this.label40.Text = "Search for";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(6, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(98, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Config variables";
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.groupBox7);
            this.tabCategories.Location = new System.Drawing.Point(4, 22);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(575, 281);
            this.tabCategories.TabIndex = 6;
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtCategories);
            this.groupBox7.Controls.Add(this.label46);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(569, 275);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            // 
            // txtCategories
            // 
            this.txtCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCategories.Location = new System.Drawing.Point(3, 16);
            this.txtCategories.Multiline = true;
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCategories.Size = new System.Drawing.Size(563, 256);
            this.txtCategories.TabIndex = 6;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.White;
            this.label46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(6, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(222, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Categories - (each line is a new entry)";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label50);
            this.tabPage1.Controls.Add(this.cmdSetNoteText);
            this.tabPage1.Controls.Add(this.cboTextType);
            this.tabPage1.Controls.Add(this.label49);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 281);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(7, 257);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(247, 13);
            this.label50.TabIndex = 3;
            this.label50.Text = "Use of variables like %CollectorName% are allowed";
            // 
            // cmdSetNoteText
            // 
            this.cmdSetNoteText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetNoteText.Enabled = false;
            this.cmdSetNoteText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSetNoteText.Location = new System.Drawing.Point(499, 252);
            this.cmdSetNoteText.Name = "cmdSetNoteText";
            this.cmdSetNoteText.Size = new System.Drawing.Size(70, 23);
            this.cmdSetNoteText.TabIndex = 4;
            this.cmdSetNoteText.Text = "Set";
            this.cmdSetNoteText.UseVisualStyleBackColor = true;
            this.cmdSetNoteText.Click += new System.EventHandler(this.cmdSetNoteText_Click);
            // 
            // cboTextType
            // 
            this.cboTextType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTextType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTextType.Items.AddRange(new object[] {
            "General notes/comments",
            "Alert Header Text (All alerts)",
            "Alert Footer Text (All alerts)",
            "Error Alert Text",
            "Warning Alert Text",
            "Good Alert Text "});
            this.cboTextType.Location = new System.Drawing.Point(55, 7);
            this.cboTextType.Name = "cboTextType";
            this.cboTextType.Size = new System.Drawing.Size(505, 21);
            this.cboTextType.TabIndex = 1;
            this.cboTextType.SelectedIndexChanged += new System.EventHandler(this.cboTextType_SelectedIndexChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(10, 10);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(31, 13);
            this.label49.TabIndex = 0;
            this.label49.Text = "Type";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.txtNotesText);
            this.groupBox8.Controls.Add(this.lblNoteTextChangeIndicator);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox8.Location = new System.Drawing.Point(3, 33);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(569, 213);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            // 
            // txtNotesText
            // 
            this.txtNotesText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotesText.Location = new System.Drawing.Point(3, 16);
            this.txtNotesText.Multiline = true;
            this.txtNotesText.Name = "txtNotesText";
            this.txtNotesText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotesText.Size = new System.Drawing.Size(563, 194);
            this.txtNotesText.TabIndex = 1;
            this.txtNotesText.TextChanged += new System.EventHandler(this.txtNotesText_TextChanged);
            // 
            // lblNoteTextChangeIndicator
            // 
            this.lblNoteTextChangeIndicator.AutoSize = true;
            this.lblNoteTextChangeIndicator.BackColor = System.Drawing.Color.White;
            this.lblNoteTextChangeIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNoteTextChangeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteTextChangeIndicator.Location = new System.Drawing.Point(6, 0);
            this.lblNoteTextChangeIndicator.Name = "lblNoteTextChangeIndicator";
            this.lblNoteTextChangeIndicator.Size = new System.Drawing.Size(32, 13);
            this.lblNoteTextChangeIndicator.TabIndex = 0;
            this.lblNoteTextChangeIndicator.Text = "Text";
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(12, 356);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(86, 13);
            this.llblRawEdit.TabIndex = 6;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW config";
            this.llblRawEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRawEdit_LinkClicked);
            // 
            // llblExportConfigAsTemplate
            // 
            this.llblExportConfigAsTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblExportConfigAsTemplate.AutoSize = true;
            this.llblExportConfigAsTemplate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblExportConfigAsTemplate.Location = new System.Drawing.Point(110, 356);
            this.llblExportConfigAsTemplate.Name = "llblExportConfigAsTemplate";
            this.llblExportConfigAsTemplate.Size = new System.Drawing.Size(126, 13);
            this.llblExportConfigAsTemplate.TabIndex = 7;
            this.llblExportConfigAsTemplate.TabStop = true;
            this.llblExportConfigAsTemplate.Text = "Export config as template";
            this.llblExportConfigAsTemplate.Visible = false;
            this.llblExportConfigAsTemplate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblExportConfigAsTemplate_LinkClicked);
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
            // correctiveScriptOpenFileDialog
            // 
            this.correctiveScriptOpenFileDialog.DefaultExt = "cmd";
            this.correctiveScriptOpenFileDialog.Filter = "Scripts|*.cmd;*.bat;*.exe|PowerShell scripts|*.ps1|All Files|*.*";
            this.correctiveScriptOpenFileDialog.Title = "Corrective script";
            // 
            // cboExpandOnStartOption
            // 
            this.cboExpandOnStartOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboExpandOnStartOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExpandOnStartOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboExpandOnStartOption.FormattingEnabled = true;
            this.cboExpandOnStartOption.Items.AddRange(new object[] {
            "Auto",
            "On Non Success",
            "On Success",
            "Never",
            "Always"});
            this.cboExpandOnStartOption.Location = new System.Drawing.Point(421, 12);
            this.cboExpandOnStartOption.Name = "cboExpandOnStartOption";
            this.cboExpandOnStartOption.Size = new System.Drawing.Size(113, 21);
            this.cboExpandOnStartOption.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cboExpandOnStartOption, "Expand the Collector on opening the UI application");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::QuickMon.Properties.Resources.BlueArcTopRight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(552, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 34);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(372, 16);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(43, 13);
            this.label47.TabIndex = 3;
            this.label47.Text = "Expand";
            // 
            // agentsTreeListView
            // 
            this.agentsTreeListView.AllowSorting = false;
            this.agentsTreeListView.AutoResizeColumnEnabled = false;
            this.agentsTreeListView.AutoResizeColumnIndex = 0;
            this.agentsTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeadertlv,
            this.summaryColumnHeader});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.agentsTreeListView.Comparer = treeListViewItemCollectionComparer1;
            this.agentsTreeListView.ContextMenuStrip = this.agentsContextMenuStrip;
            this.agentsTreeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentsTreeListView.LabelEdit = true;
            this.agentsTreeListView.Location = new System.Drawing.Point(0, 0);
            this.agentsTreeListView.Name = "agentsTreeListView";
            this.agentsTreeListView.Size = new System.Drawing.Size(569, 248);
            this.agentsTreeListView.SmallImageList = this.agentsImageList;
            this.agentsTreeListView.Sorting = System.Windows.Forms.SortOrder.None;
            this.agentsTreeListView.TabIndex = 0;
            this.agentsTreeListView.UseCompatibleStateImageBehavior = false;
            this.agentsTreeListView.AfterLabelEdit += new HenIT.Windows.Controls.TreeListViewLabelEditEventHandler(this.agentsTreeListView_AfterLabelEdit);
            this.agentsTreeListView.BeforeLabelEdit += new HenIT.Windows.Controls.TreeListViewBeforeLabelEditEventHandler(this.agentsTreeListView_BeforeLabelEdit);
            this.agentsTreeListView.SelectedIndexChanged += new System.EventHandler(this.agentsTreeListView_SelectedIndexChanged);
            this.agentsTreeListView.DoubleClick += new System.EventHandler(this.agentsTreeListView_DoubleClick);
            // 
            // nameColumnHeadertlv
            // 
            this.nameColumnHeadertlv.Text = "Agent/Entry name";
            this.nameColumnHeadertlv.Width = 270;
            // 
            // summaryColumnHeader
            // 
            this.summaryColumnHeader.Text = "Summary";
            this.summaryColumnHeader.Width = 277;
            // 
            // lvwConfigVars
            // 
            this.lvwConfigVars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConfigVars.AutoResizeColumnEnabled = false;
            this.lvwConfigVars.AutoResizeColumnIndex = 0;
            this.lvwConfigVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.lvwConfigVars.FullRowSelect = true;
            this.lvwConfigVars.Location = new System.Drawing.Point(3, 44);
            this.lvwConfigVars.Name = "lvwConfigVars";
            this.lvwConfigVars.Size = new System.Drawing.Size(553, 163);
            this.lvwConfigVars.TabIndex = 2;
            this.lvwConfigVars.UseCompatibleStateImageBehavior = false;
            this.lvwConfigVars.View = System.Windows.Forms.View.Details;
            this.lvwConfigVars.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwConfigVars_DeleteKeyPressed);
            this.lvwConfigVars.SelectedIndexChanged += new System.EventHandler(this.lvwConfigVars_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Search for";
            this.nameColumnHeader.Width = 243;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Replace by";
            this.valueColumnHeader.Width = 262;
            // 
            // EditCollectorHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 393);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.cboExpandOnStartOption);
            this.Controls.Add(this.llblRawEdit);
            this.Controls.Add(this.llblExportConfigAsTemplate);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chkExpandOnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 418);
            this.Name = "EditCollectorHost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Collector";
            this.Load += new System.EventHandler(this.EditCollectorHost_Load);
            this.Shown += new System.EventHandler(this.EditCollectorHost_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabAgents.ResumeLayout(false);
            this.tabAgents.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.agentsContextMenuStrip.ResumeLayout(false);
            this.collectorAgentsEditToolStrip.ResumeLayout(false);
            this.collectorAgentsEditToolStrip.PerformLayout();
            this.tabDependencies.ResumeLayout(false);
            this.tabDependencies.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabOperational.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pollingOverridesGroupBox.ResumeLayout(false);
            this.pollingOverridesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlyAllowUpdateOncePerXSecNumericUpDown)).EndInit();
            this.tabRemoteSec.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabAlerts.ResumeLayout(false);
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
            this.tabVariables.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabCategories.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkExpandOnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAgents;
        private System.Windows.Forms.TabPage tabOperational;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabelServiceWindows;
        private System.Windows.Forms.GroupBox pollingOverridesGroupBox;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox chkEnablePollingOverride;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterThirdRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterSecondRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterFirstRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chkEnablePollingFrequencySliding;
        private System.Windows.Forms.NumericUpDown onlyAllowUpdateOncePerXSecNumericUpDown;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabPage tabAlerts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox correctiveScriptsGroupBox;
        private System.Windows.Forms.CheckBox chkOnlyRunCorrectiveScriptsOnStateChange;
        private System.Windows.Forms.Button cmdBrowseForRestorationScript;
        private System.Windows.Forms.TextBox txtRestorationScript;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button cmdBrowseForWarningCorrectiveScript;
        private System.Windows.Forms.CheckBox chkCorrectiveScriptDisabled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdBrowseForErrorCorrectiveScript;
        private System.Windows.Forms.TextBox txtCorrectiveScriptOnWarning;
        private System.Windows.Forms.TextBox txtCorrectiveScriptOnError;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox alertSuppressionGroupBox;
        private System.Windows.Forms.CheckBox chkAlertsPaused;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeatAlertInXPolls;
        private System.Windows.Forms.NumericUpDown delayAlertPollsNumericUpDown;
        private System.Windows.Forms.NumericUpDown AlertOnceInXPollsNumericUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
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
        private System.Windows.Forms.ToolStrip collectorAgentsEditToolStrip;
        private System.Windows.Forms.ToolStripButton addCollectorConfigEntryToolStripButton;
        private System.Windows.Forms.ToolStripButton editCollectorAgentToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteCollectorAgentToolStripButton;
        private System.Windows.Forms.ColumnHeader entriesColumnHeader;
        private System.Windows.Forms.ColumnHeader triggerColumnHeader;
        private System.Windows.Forms.TabPage tabDependencies;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cboChildCheckBehaviour;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMonitorPack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboParentCollector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabVariables;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton moveUpConfigVarToolStripButton;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtConfigVarReplaceByValue;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtConfigVarSearchFor;
        private System.Windows.Forms.Label label40;
        private ListViewEx lvwConfigVars;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.LinkLabel llblExportConfigAsTemplate;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.ToolStripButton moveDownConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton moveUpAgentToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownAgentToolStripButton;
        private System.Windows.Forms.OpenFileDialog correctiveScriptOpenFileDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList agentsImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton enableAgentToolStripButton;
        private System.Windows.Forms.ToolStripButton disableAgentToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox agentCheckSequenceToolStripComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private HenIT.Windows.Controls.TreeListView agentsTreeListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeadertlv;
        private System.Windows.Forms.ColumnHeader summaryColumnHeader;
        private System.Windows.Forms.ToolStripButton addAgentEntryToolStripButton;
        private System.Windows.Forms.ContextMenuStrip agentsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addAgentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAgentEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.TabPage tabRemoteSec;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkRunLocalOnRemoteHostConnectionFailure;
        private System.Windows.Forms.CheckBox chkBlockParentRHOverride;
        private System.Windows.Forms.CheckBox chkForceRemoteExcuteOnChildCollectors;
        private System.Windows.Forms.LinkLabel llblRemoteAgentInstallHelp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkRemoteAgentEnabled;
        private System.Windows.Forms.NumericUpDown remoteportNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdRemoteAgentTest;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtRunAs;
        private System.Windows.Forms.CheckBox chkRunAsEnabled;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button cmdTestRunAs;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtCategories;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox cboRemoteAgentServer;
        private System.Windows.Forms.ComboBox cboExpandOnStartOption;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cboTextType;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtNotesText;
        private System.Windows.Forms.Label lblNoteTextChangeIndicator;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button cmdSetNoteText;
    }
}