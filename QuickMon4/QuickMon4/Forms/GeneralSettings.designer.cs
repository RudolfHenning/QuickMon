namespace QuickMon
{
    partial class GeneralSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettings));
            this.concurrencyLevelNnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkSnapToDesktop = new System.Windows.Forms.CheckBox();
            this.chkAutosaveChanges = new System.Windows.Forms.CheckBox();
            this.chkPausePollingDuringEditConfig = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkOverridesMonitorPackFrequency = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.freqSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPollingEnabled = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtRecentMonitorPackFilter = new System.Windows.Forms.TextBox();
            this.txtApplicationMasterKeyFilePath = new System.Windows.Forms.TextBox();
            this.txtApplicationMasterKey = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkDisableAutoAdminMode = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPinToTaskbar = new System.Windows.Forms.CheckBox();
            this.chkDesktopShortcut = new System.Windows.Forms.CheckBox();
            this.chkPinToStartMenu = new System.Windows.Forms.CheckBox();
            this.chkCreateBackupOnSave = new System.Windows.Forms.CheckBox();
            this.chkUseTemplates = new System.Windows.Forms.CheckBox();
            this.recentTabPage = new System.Windows.Forms.TabPage();
            this.chkDisplayFullPathForQuickRecentEntries = new System.Windows.Forms.CheckBox();
            this.cmdEditQuickSelectTypeFilters = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageRemoteHosts = new System.Windows.Forms.TabPage();
            this.llblStartLocalService = new System.Windows.Forms.LinkLabel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.llblFirewallRule = new System.Windows.Forms.LinkLabel();
            this.remoteportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.llblLocalServiceRegistered = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.lblComputer = new System.Windows.Forms.Label();
            this.remoteHostListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteHostStatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmdRemoveUserNameFromCache = new System.Windows.Forms.Button();
            this.cmdAddUserNameToCache = new System.Windows.Forms.Button();
            this.userCacheContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userCacheImageList = new System.Windows.Forms.ImageList(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSelectMasterKeyFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.quickMonServiceOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.shadePanel1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialogSaveQmmxml = new System.Windows.Forms.SaveFileDialog();
            this.lvwRemoteHosts = new QuickMon.ListViewEx();
            this.remoteAgentColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.versionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwUserNameCache = new QuickMon.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.recentTabPage.SuspendLayout();
            this.tabPageRemoteHosts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).BeginInit();
            this.remoteHostListContextMenuStrip.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.userCacheContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // concurrencyLevelNnumericUpDown
            // 
            this.concurrencyLevelNnumericUpDown.Location = new System.Drawing.Point(104, 87);
            this.concurrencyLevelNnumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.concurrencyLevelNnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.concurrencyLevelNnumericUpDown.Name = "concurrencyLevelNnumericUpDown";
            this.concurrencyLevelNnumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.concurrencyLevelNnumericUpDown.TabIndex = 7;
            this.concurrencyLevelNnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Concurrency level";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(372, 238);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(291, 238);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkSnapToDesktop
            // 
            this.chkSnapToDesktop.AutoSize = true;
            this.chkSnapToDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSnapToDesktop.Location = new System.Drawing.Point(15, 13);
            this.chkSnapToDesktop.Name = "chkSnapToDesktop";
            this.chkSnapToDesktop.Size = new System.Drawing.Size(129, 17);
            this.chkSnapToDesktop.TabIndex = 0;
            this.chkSnapToDesktop.Text = "Snap to desktop sides";
            this.chkSnapToDesktop.UseVisualStyleBackColor = true;
            // 
            // chkAutosaveChanges
            // 
            this.chkAutosaveChanges.AutoSize = true;
            this.chkAutosaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAutosaveChanges.Location = new System.Drawing.Point(147, 13);
            this.chkAutosaveChanges.Name = "chkAutosaveChanges";
            this.chkAutosaveChanges.Size = new System.Drawing.Size(116, 17);
            this.chkAutosaveChanges.TabIndex = 1;
            this.chkAutosaveChanges.Text = "Auto save changes";
            this.chkAutosaveChanges.UseVisualStyleBackColor = true;
            // 
            // chkPausePollingDuringEditConfig
            // 
            this.chkPausePollingDuringEditConfig.AutoSize = true;
            this.chkPausePollingDuringEditConfig.Checked = true;
            this.chkPausePollingDuringEditConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPausePollingDuringEditConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPausePollingDuringEditConfig.Location = new System.Drawing.Point(105, 118);
            this.chkPausePollingDuringEditConfig.Name = "chkPausePollingDuringEditConfig";
            this.chkPausePollingDuringEditConfig.Size = new System.Drawing.Size(227, 17);
            this.chkPausePollingDuringEditConfig.TabIndex = 8;
            this.chkPausePollingDuringEditConfig.Text = "Pause polling while editing config of agents";
            this.chkPausePollingDuringEditConfig.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "If Monitor pack has no frequency specified this setting is used.";
            // 
            // chkOverridesMonitorPackFrequency
            // 
            this.chkOverridesMonitorPackFrequency.AutoSize = true;
            this.chkOverridesMonitorPackFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOverridesMonitorPackFrequency.Location = new System.Drawing.Point(205, 42);
            this.chkOverridesMonitorPackFrequency.Name = "chkOverridesMonitorPackFrequency";
            this.chkOverridesMonitorPackFrequency.Size = new System.Drawing.Size(195, 17);
            this.chkOverridesMonitorPackFrequency.TabIndex = 4;
            this.chkOverridesMonitorPackFrequency.Text = "Overrides frequency in Monitor pack";
            this.chkOverridesMonitorPackFrequency.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(sec)";
            // 
            // freqSecNumericUpDown
            // 
            this.freqSecNumericUpDown.Location = new System.Drawing.Point(104, 41);
            this.freqSecNumericUpDown.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.freqSecNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.freqSecNumericUpDown.Name = "freqSecNumericUpDown";
            this.freqSecNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.freqSecNumericUpDown.TabIndex = 2;
            this.freqSecNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.freqSecNumericUpDown.ValueChanged += new System.EventHandler(this.freqSecNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frequency";
            // 
            // chkPollingEnabled
            // 
            this.chkPollingEnabled.AutoSize = true;
            this.chkPollingEnabled.Checked = true;
            this.chkPollingEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPollingEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPollingEnabled.Location = new System.Drawing.Point(9, 10);
            this.chkPollingEnabled.Name = "chkPollingEnabled";
            this.chkPollingEnabled.Size = new System.Drawing.Size(90, 17);
            this.chkPollingEnabled.TabIndex = 0;
            this.chkPollingEnabled.Text = "Enable polling";
            this.chkPollingEnabled.UseVisualStyleBackColor = true;
            // 
            // txtRecentMonitorPackFilter
            // 
            this.txtRecentMonitorPackFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecentMonitorPackFilter.Location = new System.Drawing.Point(164, 11);
            this.txtRecentMonitorPackFilter.Name = "txtRecentMonitorPackFilter";
            this.txtRecentMonitorPackFilter.Size = new System.Drawing.Size(186, 20);
            this.txtRecentMonitorPackFilter.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtRecentMonitorPackFilter, "* - All, use ~ for exclude");
            // 
            // txtApplicationMasterKeyFilePath
            // 
            this.txtApplicationMasterKeyFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationMasterKeyFilePath.Location = new System.Drawing.Point(156, 32);
            this.txtApplicationMasterKeyFilePath.Name = "txtApplicationMasterKeyFilePath";
            this.txtApplicationMasterKeyFilePath.Size = new System.Drawing.Size(236, 20);
            this.txtApplicationMasterKeyFilePath.TabIndex = 3;
            // 
            // txtApplicationMasterKey
            // 
            this.txtApplicationMasterKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationMasterKey.Location = new System.Drawing.Point(156, 6);
            this.txtApplicationMasterKey.Name = "txtApplicationMasterKey";
            this.txtApplicationMasterKey.Size = new System.Drawing.Size(284, 20);
            this.txtApplicationMasterKey.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtApplicationMasterKey, "Do not loose this key as decryption the credentials is impossible without it!");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.recentTabPage);
            this.tabControl1.Controls.Add(this.tabPageRemoteHosts);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(456, 201);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.chkPausePollingDuringEditConfig);
            this.tabPage1.Controls.Add(this.chkPollingEnabled);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chkOverridesMonitorPackFrequency);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.freqSecNumericUpDown);
            this.tabPage1.Controls.Add(this.concurrencyLevelNnumericUpDown);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(448, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Polling";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.chkDisableAutoAdminMode);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.chkCreateBackupOnSave);
            this.tabPage2.Controls.Add(this.chkUseTemplates);
            this.tabPage2.Controls.Add(this.chkSnapToDesktop);
            this.tabPage2.Controls.Add(this.chkAutosaveChanges);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(448, 175);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application";
            // 
            // chkDisableAutoAdminMode
            // 
            this.chkDisableAutoAdminMode.AutoSize = true;
            this.chkDisableAutoAdminMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisableAutoAdminMode.Location = new System.Drawing.Point(7, 115);
            this.chkDisableAutoAdminMode.Name = "chkDisableAutoAdminMode";
            this.chkDisableAutoAdminMode.Size = new System.Drawing.Size(399, 17);
            this.chkDisableAutoAdminMode.TabIndex = 5;
            this.chkDisableAutoAdminMode.Text = "Disable automatic Admin mode (Must be in Admin mode to remove existing task)";
            this.chkDisableAutoAdminMode.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkPinToTaskbar);
            this.groupBox1.Controls.Add(this.chkDesktopShortcut);
            this.groupBox1.Controls.Add(this.chkPinToStartMenu);
            this.groupBox1.Location = new System.Drawing.Point(6, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shortcuts";
            // 
            // chkPinToTaskbar
            // 
            this.chkPinToTaskbar.AutoSize = true;
            this.chkPinToTaskbar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPinToTaskbar.Location = new System.Drawing.Point(19, 19);
            this.chkPinToTaskbar.Name = "chkPinToTaskbar";
            this.chkPinToTaskbar.Size = new System.Drawing.Size(93, 17);
            this.chkPinToTaskbar.TabIndex = 0;
            this.chkPinToTaskbar.Text = "Pin to Taskbar";
            this.chkPinToTaskbar.UseVisualStyleBackColor = true;
            this.chkPinToTaskbar.CheckedChanged += new System.EventHandler(this.chkPinToTaskbar_CheckedChanged);
            // 
            // chkDesktopShortcut
            // 
            this.chkDesktopShortcut.AutoSize = true;
            this.chkDesktopShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDesktopShortcut.Location = new System.Drawing.Point(234, 19);
            this.chkDesktopShortcut.Name = "chkDesktopShortcut";
            this.chkDesktopShortcut.Size = new System.Drawing.Size(152, 17);
            this.chkDesktopShortcut.TabIndex = 2;
            this.chkDesktopShortcut.Text = "Create shortcut on desktop";
            this.chkDesktopShortcut.UseVisualStyleBackColor = true;
            this.chkDesktopShortcut.CheckedChanged += new System.EventHandler(this.chkDesktopShortcut_CheckedChanged);
            // 
            // chkPinToStartMenu
            // 
            this.chkPinToStartMenu.AutoSize = true;
            this.chkPinToStartMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPinToStartMenu.Location = new System.Drawing.Point(120, 19);
            this.chkPinToStartMenu.Name = "chkPinToStartMenu";
            this.chkPinToStartMenu.Size = new System.Drawing.Size(106, 17);
            this.chkPinToStartMenu.TabIndex = 1;
            this.chkPinToStartMenu.Text = "Pin to Start Menu";
            this.chkPinToStartMenu.UseVisualStyleBackColor = true;
            this.chkPinToStartMenu.CheckedChanged += new System.EventHandler(this.chkPinToStartMenu_CheckedChanged);
            // 
            // chkCreateBackupOnSave
            // 
            this.chkCreateBackupOnSave.AutoSize = true;
            this.chkCreateBackupOnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCreateBackupOnSave.Location = new System.Drawing.Point(271, 13);
            this.chkCreateBackupOnSave.Name = "chkCreateBackupOnSave";
            this.chkCreateBackupOnSave.Size = new System.Drawing.Size(160, 17);
            this.chkCreateBackupOnSave.TabIndex = 2;
            this.chkCreateBackupOnSave.Text = "Back up previous saved files";
            this.chkCreateBackupOnSave.UseVisualStyleBackColor = true;
            // 
            // chkUseTemplates
            // 
            this.chkUseTemplates.AutoSize = true;
            this.chkUseTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseTemplates.Location = new System.Drawing.Point(7, 92);
            this.chkUseTemplates.Name = "chkUseTemplates";
            this.chkUseTemplates.Size = new System.Drawing.Size(385, 17);
            this.chkUseTemplates.TabIndex = 4;
            this.chkUseTemplates.Text = "Use \'Templates\' when creating new objects (Monitor packs and Agent hosts)";
            this.chkUseTemplates.UseVisualStyleBackColor = true;
            // 
            // recentTabPage
            // 
            this.recentTabPage.BackColor = System.Drawing.Color.White;
            this.recentTabPage.Controls.Add(this.chkDisplayFullPathForQuickRecentEntries);
            this.recentTabPage.Controls.Add(this.cmdEditQuickSelectTypeFilters);
            this.recentTabPage.Controls.Add(this.txtRecentMonitorPackFilter);
            this.recentTabPage.Controls.Add(this.label5);
            this.recentTabPage.Location = new System.Drawing.Point(4, 22);
            this.recentTabPage.Name = "recentTabPage";
            this.recentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.recentTabPage.Size = new System.Drawing.Size(448, 175);
            this.recentTabPage.TabIndex = 3;
            this.recentTabPage.Text = "Recent";
            // 
            // chkDisplayFullPathForQuickRecentEntries
            // 
            this.chkDisplayFullPathForQuickRecentEntries.AutoSize = true;
            this.chkDisplayFullPathForQuickRecentEntries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisplayFullPathForQuickRecentEntries.Location = new System.Drawing.Point(21, 37);
            this.chkDisplayFullPathForQuickRecentEntries.Name = "chkDisplayFullPathForQuickRecentEntries";
            this.chkDisplayFullPathForQuickRecentEntries.Size = new System.Drawing.Size(184, 17);
            this.chkDisplayFullPathForQuickRecentEntries.TabIndex = 3;
            this.chkDisplayFullPathForQuickRecentEntries.Text = "Display full path in quick select list";
            this.chkDisplayFullPathForQuickRecentEntries.UseVisualStyleBackColor = true;
            // 
            // cmdEditQuickSelectTypeFilters
            // 
            this.cmdEditQuickSelectTypeFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditQuickSelectTypeFilters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditQuickSelectTypeFilters.Location = new System.Drawing.Point(356, 9);
            this.cmdEditQuickSelectTypeFilters.Name = "cmdEditQuickSelectTypeFilters";
            this.cmdEditQuickSelectTypeFilters.Size = new System.Drawing.Size(42, 23);
            this.cmdEditQuickSelectTypeFilters.TabIndex = 2;
            this.cmdEditQuickSelectTypeFilters.Text = "- - -";
            this.cmdEditQuickSelectTypeFilters.UseVisualStyleBackColor = true;
            this.cmdEditQuickSelectTypeFilters.Click += new System.EventHandler(this.cmdEditQuickSelectTypeFilters_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quick select Type Filters (csv)";
            // 
            // tabPageRemoteHosts
            // 
            this.tabPageRemoteHosts.BackColor = System.Drawing.Color.White;
            this.tabPageRemoteHosts.Controls.Add(this.llblStartLocalService);
            this.tabPageRemoteHosts.Controls.Add(this.cmdAdd);
            this.tabPageRemoteHosts.Controls.Add(this.llblFirewallRule);
            this.tabPageRemoteHosts.Controls.Add(this.remoteportNumericUpDown);
            this.tabPageRemoteHosts.Controls.Add(this.llblLocalServiceRegistered);
            this.tabPageRemoteHosts.Controls.Add(this.label14);
            this.tabPageRemoteHosts.Controls.Add(this.txtComputer);
            this.tabPageRemoteHosts.Controls.Add(this.lblComputer);
            this.tabPageRemoteHosts.Controls.Add(this.lvwRemoteHosts);
            this.tabPageRemoteHosts.Location = new System.Drawing.Point(4, 22);
            this.tabPageRemoteHosts.Name = "tabPageRemoteHosts";
            this.tabPageRemoteHosts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRemoteHosts.Size = new System.Drawing.Size(448, 175);
            this.tabPageRemoteHosts.TabIndex = 2;
            this.tabPageRemoteHosts.Text = "Remote hosts";
            // 
            // llblStartLocalService
            // 
            this.llblStartLocalService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblStartLocalService.AutoSize = true;
            this.llblStartLocalService.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblStartLocalService.Location = new System.Drawing.Point(6, 154);
            this.llblStartLocalService.Name = "llblStartLocalService";
            this.llblStartLocalService.Size = new System.Drawing.Size(170, 13);
            this.llblStartLocalService.TabIndex = 8;
            this.llblStartLocalService.TabStop = true;
            this.llblStartLocalService.Text = "Start local \'Remote Agent/Service\'";
            this.llblStartLocalService.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblStartLocalService_LinkClicked);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.Enabled = false;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(389, 124);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(45, 23);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // llblFirewallRule
            // 
            this.llblFirewallRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llblFirewallRule.AutoSize = true;
            this.llblFirewallRule.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblFirewallRule.Location = new System.Drawing.Point(222, 154);
            this.llblFirewallRule.Name = "llblFirewallRule";
            this.llblFirewallRule.Size = new System.Drawing.Size(218, 13);
            this.llblFirewallRule.TabIndex = 7;
            this.llblFirewallRule.TabStop = true;
            this.llblFirewallRule.Text = "Add Remote Host Firewall rule for port 48181";
            this.llblFirewallRule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblFirewallRule_LinkClicked);
            // 
            // remoteportNumericUpDown
            // 
            this.remoteportNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteportNumericUpDown.Location = new System.Drawing.Point(292, 127);
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
            this.remoteportNumericUpDown.Size = new System.Drawing.Size(91, 20);
            this.remoteportNumericUpDown.TabIndex = 4;
            this.remoteportNumericUpDown.Value = new decimal(new int[] {
            48181,
            0,
            0,
            0});
            // 
            // llblLocalServiceRegistered
            // 
            this.llblLocalServiceRegistered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblLocalServiceRegistered.AutoSize = true;
            this.llblLocalServiceRegistered.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblLocalServiceRegistered.Location = new System.Drawing.Point(6, 154);
            this.llblLocalServiceRegistered.Name = "llblLocalServiceRegistered";
            this.llblLocalServiceRegistered.Size = new System.Drawing.Size(187, 13);
            this.llblLocalServiceRegistered.TabIndex = 6;
            this.llblLocalServiceRegistered.TabStop = true;
            this.llblLocalServiceRegistered.Text = "Register local \'Remote Agent/Service\'";
            this.llblLocalServiceRegistered.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLocalServiceRegistered_LinkClicked);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(260, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Port";
            // 
            // txtComputer
            // 
            this.txtComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputer.Location = new System.Drawing.Point(85, 126);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(170, 20);
            this.txtComputer.TabIndex = 2;
            this.txtComputer.TextChanged += new System.EventHandler(this.txtComputer_TextChanged);
            this.txtComputer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComputer_KeyDown);
            // 
            // lblComputer
            // 
            this.lblComputer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComputer.AutoSize = true;
            this.lblComputer.Location = new System.Drawing.Point(6, 129);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(73, 13);
            this.lblComputer.TabIndex = 1;
            this.lblComputer.Text = "Add computer";
            this.lblComputer.DoubleClick += new System.EventHandler(this.lblComputer_DoubleClick);
            // 
            // remoteHostListContextMenuStrip
            // 
            this.remoteHostListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem1,
            this.removeToolStripMenuItem});
            this.remoteHostListContextMenuStrip.Name = "contextMenuStrip1";
            this.remoteHostListContextMenuStrip.Size = new System.Drawing.Size(133, 54);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // remoteHostStatusImageList
            // 
            this.remoteHostStatusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("remoteHostStatusImageList.ImageStream")));
            this.remoteHostStatusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.remoteHostStatusImageList.Images.SetKeyName(0, "GUnknown.ico");
            this.remoteHostStatusImageList.Images.SetKeyName(1, "GRunning.ico");
            this.remoteHostStatusImageList.Images.SetKeyName(2, "GBusy.ico");
            this.remoteHostStatusImageList.Images.SetKeyName(3, "GStopped.ico");
            this.remoteHostStatusImageList.Images.SetKeyName(4, "GPaused.ico");
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.cmdRemoveUserNameFromCache);
            this.tabPage3.Controls.Add(this.cmdAddUserNameToCache);
            this.tabPage3.Controls.Add(this.lvwUserNameCache);
            this.tabPage3.Controls.Add(this.txtApplicationMasterKey);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.cmdSelectMasterKeyFile);
            this.tabPage3.Controls.Add(this.txtApplicationMasterKeyFilePath);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(448, 175);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Security";
            // 
            // cmdRemoveUserNameFromCache
            // 
            this.cmdRemoveUserNameFromCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoveUserNameFromCache.Enabled = false;
            this.cmdRemoveUserNameFromCache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoveUserNameFromCache.Font = new System.Drawing.Font("Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdRemoveUserNameFromCache.Location = new System.Drawing.Point(398, 88);
            this.cmdRemoveUserNameFromCache.Name = "cmdRemoveUserNameFromCache";
            this.cmdRemoveUserNameFromCache.Size = new System.Drawing.Size(42, 23);
            this.cmdRemoveUserNameFromCache.TabIndex = 7;
            this.cmdRemoveUserNameFromCache.Text = "Ä";
            this.cmdRemoveUserNameFromCache.UseVisualStyleBackColor = true;
            this.cmdRemoveUserNameFromCache.Click += new System.EventHandler(this.cmdRemoveUserNameFromCache_Click);
            // 
            // cmdAddUserNameToCache
            // 
            this.cmdAddUserNameToCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddUserNameToCache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddUserNameToCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddUserNameToCache.Location = new System.Drawing.Point(398, 59);
            this.cmdAddUserNameToCache.Name = "cmdAddUserNameToCache";
            this.cmdAddUserNameToCache.Size = new System.Drawing.Size(42, 23);
            this.cmdAddUserNameToCache.TabIndex = 6;
            this.cmdAddUserNameToCache.Text = "+";
            this.cmdAddUserNameToCache.UseVisualStyleBackColor = true;
            this.cmdAddUserNameToCache.Click += new System.EventHandler(this.cmdAddUserNameToCache_Click);
            // 
            // userCacheContextMenuStrip
            // 
            this.userCacheContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inCacheToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem,
            this.removeUserToolStripMenuItem});
            this.userCacheContextMenuStrip.Name = "contextMenuStrip1";
            this.userCacheContextMenuStrip.Size = new System.Drawing.Size(126, 76);
            // 
            // inCacheToolStripMenuItem
            // 
            this.inCacheToolStripMenuItem.Enabled = false;
            this.inCacheToolStripMenuItem.Name = "inCacheToolStripMenuItem";
            this.inCacheToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.inCacheToolStripMenuItem.Text = "In Cache?";
            this.inCacheToolStripMenuItem.Click += new System.EventHandler(this.inCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.addToolStripMenuItem.Text = "Add/Set";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.cmdAddUserNameToCache_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Enabled = false;
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.removeUserToolStripMenuItem.Text = "Remove";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.cmdRemoveUserNameFromCache_Click);
            // 
            // userCacheImageList
            // 
            this.userCacheImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("userCacheImageList.ImageStream")));
            this.userCacheImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.userCacheImageList.Images.SetKeyName(0, "125_31.ico");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(15, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Application master key";
            this.toolTip1.SetToolTip(this.label7, "Do not loose this key as decryption the credentials is impossible without it!");
            // 
            // cmdSelectMasterKeyFile
            // 
            this.cmdSelectMasterKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectMasterKeyFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSelectMasterKeyFile.Location = new System.Drawing.Point(398, 30);
            this.cmdSelectMasterKeyFile.Name = "cmdSelectMasterKeyFile";
            this.cmdSelectMasterKeyFile.Size = new System.Drawing.Size(42, 23);
            this.cmdSelectMasterKeyFile.TabIndex = 4;
            this.cmdSelectMasterKeyFile.Text = "- - -";
            this.cmdSelectMasterKeyFile.UseVisualStyleBackColor = true;
            this.cmdSelectMasterKeyFile.Click += new System.EventHandler(this.cmdSelectMasterKeyFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(15, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Master key file";
            this.toolTip1.SetToolTip(this.label6, "Do not loose this key as decryption the credentials is impossible without it!");
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // quickMonServiceOpenFileDialog
            // 
            this.quickMonServiceOpenFileDialog.DefaultExt = "exe";
            this.quickMonServiceOpenFileDialog.FileName = "QuickMonService.exe";
            this.quickMonServiceOpenFileDialog.Filter = "QuickMon 3 Service|QuickMonService.exe";
            this.quickMonServiceOpenFileDialog.Title = "Select QuickMon 3 Service";
            // 
            // shadePanel1
            // 
            this.shadePanel1.BackgroundImage = global::QuickMon.Properties.Resources.BlueHeader1;
            this.shadePanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shadePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.shadePanel1.Location = new System.Drawing.Point(0, 0);
            this.shadePanel1.Name = "shadePanel1";
            this.shadePanel1.Size = new System.Drawing.Size(459, 31);
            this.shadePanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuickMon.Properties.Resources.BlueHeader2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 31);
            this.panel1.TabIndex = 11;
            // 
            // saveFileDialogSaveQmmxml
            // 
            this.saveFileDialogSaveQmmxml.DefaultExt = "qmmxml";
            this.saveFileDialogSaveQmmxml.Filter = "QuickMon master key files|*.qmmxml";
            // 
            // lvwRemoteHosts
            // 
            this.lvwRemoteHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwRemoteHosts.AutoResizeColumnEnabled = false;
            this.lvwRemoteHosts.AutoResizeColumnIndex = 2;
            this.lvwRemoteHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.remoteAgentColumnHeader,
            this.portColumnHeader,
            this.versionColumnHeader});
            this.lvwRemoteHosts.ContextMenuStrip = this.remoteHostListContextMenuStrip;
            this.lvwRemoteHosts.FullRowSelect = true;
            this.lvwRemoteHosts.Location = new System.Drawing.Point(0, 0);
            this.lvwRemoteHosts.Name = "lvwRemoteHosts";
            this.lvwRemoteHosts.Size = new System.Drawing.Size(440, 118);
            this.lvwRemoteHosts.SmallImageList = this.remoteHostStatusImageList;
            this.lvwRemoteHosts.TabIndex = 0;
            this.lvwRemoteHosts.UseCompatibleStateImageBehavior = false;
            this.lvwRemoteHosts.View = System.Windows.Forms.View.Details;
            this.lvwRemoteHosts.SelectedIndexChanged += new System.EventHandler(this.lvwRemoteHosts_SelectedIndexChanged);
            this.lvwRemoteHosts.DoubleClick += new System.EventHandler(this.lvwRemoteHosts_DoubleClick);
            // 
            // remoteAgentColumnHeader
            // 
            this.remoteAgentColumnHeader.Text = "Remote host";
            this.remoteAgentColumnHeader.Width = 150;
            // 
            // portColumnHeader
            // 
            this.portColumnHeader.Text = "Port";
            this.portColumnHeader.Width = 74;
            // 
            // versionColumnHeader
            // 
            this.versionColumnHeader.Text = "Version";
            this.versionColumnHeader.Width = 97;
            // 
            // lvwUserNameCache
            // 
            this.lvwUserNameCache.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwUserNameCache.AutoResizeColumnEnabled = false;
            this.lvwUserNameCache.AutoResizeColumnIndex = 0;
            this.lvwUserNameCache.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwUserNameCache.ContextMenuStrip = this.userCacheContextMenuStrip;
            this.lvwUserNameCache.FullRowSelect = true;
            this.lvwUserNameCache.Location = new System.Drawing.Point(6, 59);
            this.lvwUserNameCache.Name = "lvwUserNameCache";
            this.lvwUserNameCache.Size = new System.Drawing.Size(386, 110);
            this.lvwUserNameCache.SmallImageList = this.userCacheImageList;
            this.lvwUserNameCache.TabIndex = 5;
            this.lvwUserNameCache.UseCompatibleStateImageBehavior = false;
            this.lvwUserNameCache.View = System.Windows.Forms.View.Details;
            this.lvwUserNameCache.SelectedIndexChanged += new System.EventHandler(this.lvwUserNameCache_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User name cache";
            this.columnHeader1.Width = 356;
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 282);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.shadePanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 320);
            this.Name = "GeneralSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            this.Shown += new System.EventHandler(this.GeneralSettings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.recentTabPage.ResumeLayout(false);
            this.recentTabPage.PerformLayout();
            this.tabPageRemoteHosts.ResumeLayout(false);
            this.tabPageRemoteHosts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).EndInit();
            this.remoteHostListContextMenuStrip.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.userCacheContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown concurrencyLevelNnumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkSnapToDesktop;
        private System.Windows.Forms.CheckBox chkAutosaveChanges;
        private System.Windows.Forms.CheckBox chkPollingEnabled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown freqSecNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOverridesMonitorPackFrequency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkPausePollingDuringEditConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPageRemoteHosts;
        private ListViewEx lvwRemoteHosts;
        private System.Windows.Forms.ColumnHeader remoteAgentColumnHeader;
        private System.Windows.Forms.ColumnHeader portColumnHeader;
        private System.Windows.Forms.ColumnHeader versionColumnHeader;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.NumericUpDown remoteportNumericUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.LinkLabel llblFirewallRule;
        private System.Windows.Forms.LinkLabel llblLocalServiceRegistered;
        private System.Windows.Forms.ImageList remoteHostStatusImageList;
        private System.Windows.Forms.ContextMenuStrip remoteHostListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.OpenFileDialog quickMonServiceOpenFileDialog;
        private System.Windows.Forms.Panel shadePanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkUseTemplates;
        private System.Windows.Forms.CheckBox chkCreateBackupOnSave;
        private System.Windows.Forms.LinkLabel llblStartLocalService;
        private System.Windows.Forms.TabPage recentTabPage;
        private System.Windows.Forms.CheckBox chkDisplayFullPathForQuickRecentEntries;
        private System.Windows.Forms.Button cmdEditQuickSelectTypeFilters;
        private System.Windows.Forms.TextBox txtRecentMonitorPackFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPinToTaskbar;
        private System.Windows.Forms.CheckBox chkDesktopShortcut;
        private System.Windows.Forms.CheckBox chkPinToStartMenu;
        private System.Windows.Forms.CheckBox chkDisableAutoAdminMode;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtApplicationMasterKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdSelectMasterKeyFile;
        private System.Windows.Forms.TextBox txtApplicationMasterKeyFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdRemoveUserNameFromCache;
        private System.Windows.Forms.Button cmdAddUserNameToCache;
        private ListViewEx lvwUserNameCache;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSaveQmmxml;
        private System.Windows.Forms.ImageList userCacheImageList;
        private System.Windows.Forms.ContextMenuStrip userCacheContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem inCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
    }
}