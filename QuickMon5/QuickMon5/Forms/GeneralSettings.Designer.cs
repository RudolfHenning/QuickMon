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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettings));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanelSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAppSettings = new System.Windows.Forms.Panel();
            this.chkDisableAutoAdminMode = new System.Windows.Forms.CheckBox();
            this.chkUseTemplates = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPinToTaskbar = new System.Windows.Forms.CheckBox();
            this.chkDesktopShortcut = new System.Windows.Forms.CheckBox();
            this.chkPinToStartMenu = new System.Windows.Forms.CheckBox();
            this.chkCreateBackupOnSave = new System.Windows.Forms.CheckBox();
            this.chkSnapToDesktop = new System.Windows.Forms.CheckBox();
            this.chkAutosaveChanges = new System.Windows.Forms.CheckBox();
            this.cmdAppSettingsToggle = new System.Windows.Forms.Button();
            this.panelPollingSettings = new System.Windows.Forms.Panel();
            this.chkPausePollingDuringEditConfig = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkOverridesMonitorPackFrequency = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.freqSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.concurrencyLevelNnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cmdPollingSettingsToggle = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.panelRecentList = new System.Windows.Forms.Panel();
            this.cmdRecentToggle = new System.Windows.Forms.Button();
            this.chkDisplayFullPathForQuickRecentEntries = new System.Windows.Forms.CheckBox();
            this.cmdEditQuickSelectTypeFilters = new System.Windows.Forms.Button();
            this.txtRecentMonitorPackFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPasswordManagement = new System.Windows.Forms.Panel();
            this.cmdPasswordManagementToggle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdRemoveUserNameFromCache = new System.Windows.Forms.Button();
            this.cmdAddUserNameToCache = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtApplicationMasterKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSelectMasterKeyFile = new System.Windows.Forms.Button();
            this.txtApplicationMasterKeyFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwUserNameCache = new QuickMon.ListViewEx();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanelSettings.SuspendLayout();
            this.panelAppSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelPollingSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).BeginInit();
            this.panelRecentList.SuspendLayout();
            this.panelPasswordManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(443, 497);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanelSettings
            // 
            this.flowLayoutPanelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelSettings.AutoScroll = true;
            this.flowLayoutPanelSettings.Controls.Add(this.panelAppSettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelPollingSettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelRecentList);
            this.flowLayoutPanelSettings.Controls.Add(this.panelPasswordManagement);
            this.flowLayoutPanelSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelSettings.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelSettings.Name = "flowLayoutPanelSettings";
            this.flowLayoutPanelSettings.Size = new System.Drawing.Size(529, 491);
            this.flowLayoutPanelSettings.TabIndex = 2;
            this.flowLayoutPanelSettings.WrapContents = false;
            this.flowLayoutPanelSettings.Resize += new System.EventHandler(this.flowLayoutPanelSettings_Resize);
            // 
            // panelAppSettings
            // 
            this.panelAppSettings.Controls.Add(this.chkDisableAutoAdminMode);
            this.panelAppSettings.Controls.Add(this.chkUseTemplates);
            this.panelAppSettings.Controls.Add(this.groupBox1);
            this.panelAppSettings.Controls.Add(this.chkCreateBackupOnSave);
            this.panelAppSettings.Controls.Add(this.chkSnapToDesktop);
            this.panelAppSettings.Controls.Add(this.chkAutosaveChanges);
            this.panelAppSettings.Controls.Add(this.cmdAppSettingsToggle);
            this.panelAppSettings.Location = new System.Drawing.Point(3, 3);
            this.panelAppSettings.Name = "panelAppSettings";
            this.panelAppSettings.Size = new System.Drawing.Size(495, 172);
            this.panelAppSettings.TabIndex = 0;
            // 
            // chkDisableAutoAdminMode
            // 
            this.chkDisableAutoAdminMode.AutoSize = true;
            this.chkDisableAutoAdminMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisableAutoAdminMode.Location = new System.Drawing.Point(9, 141);
            this.chkDisableAutoAdminMode.Name = "chkDisableAutoAdminMode";
            this.chkDisableAutoAdminMode.Size = new System.Drawing.Size(399, 17);
            this.chkDisableAutoAdminMode.TabIndex = 8;
            this.chkDisableAutoAdminMode.Text = "Disable automatic Admin mode (Must be in Admin mode to remove existing task)";
            this.chkDisableAutoAdminMode.UseVisualStyleBackColor = true;
            // 
            // chkUseTemplates
            // 
            this.chkUseTemplates.AutoSize = true;
            this.chkUseTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseTemplates.Location = new System.Drawing.Point(9, 118);
            this.chkUseTemplates.Name = "chkUseTemplates";
            this.chkUseTemplates.Size = new System.Drawing.Size(385, 17);
            this.chkUseTemplates.TabIndex = 7;
            this.chkUseTemplates.Text = "Use \'Templates\' when creating new objects (Monitor packs and Agent hosts)";
            this.chkUseTemplates.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkPinToTaskbar);
            this.groupBox1.Controls.Add(this.chkDesktopShortcut);
            this.groupBox1.Controls.Add(this.chkPinToStartMenu);
            this.groupBox1.Location = new System.Drawing.Point(9, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 50);
            this.groupBox1.TabIndex = 6;
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
            this.chkCreateBackupOnSave.Location = new System.Drawing.Point(265, 39);
            this.chkCreateBackupOnSave.Name = "chkCreateBackupOnSave";
            this.chkCreateBackupOnSave.Size = new System.Drawing.Size(160, 17);
            this.chkCreateBackupOnSave.TabIndex = 5;
            this.chkCreateBackupOnSave.Text = "Back up previous saved files";
            this.chkCreateBackupOnSave.UseVisualStyleBackColor = true;
            // 
            // chkSnapToDesktop
            // 
            this.chkSnapToDesktop.AutoSize = true;
            this.chkSnapToDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSnapToDesktop.Location = new System.Drawing.Point(9, 39);
            this.chkSnapToDesktop.Name = "chkSnapToDesktop";
            this.chkSnapToDesktop.Size = new System.Drawing.Size(129, 17);
            this.chkSnapToDesktop.TabIndex = 3;
            this.chkSnapToDesktop.Text = "Snap to desktop sides";
            this.chkSnapToDesktop.UseVisualStyleBackColor = true;
            // 
            // chkAutosaveChanges
            // 
            this.chkAutosaveChanges.AutoSize = true;
            this.chkAutosaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAutosaveChanges.Location = new System.Drawing.Point(141, 39);
            this.chkAutosaveChanges.Name = "chkAutosaveChanges";
            this.chkAutosaveChanges.Size = new System.Drawing.Size(116, 17);
            this.chkAutosaveChanges.TabIndex = 4;
            this.chkAutosaveChanges.Text = "Auto save changes";
            this.chkAutosaveChanges.UseVisualStyleBackColor = true;
            // 
            // cmdAppSettingsToggle
            // 
            this.cmdAppSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAppSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAppSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdAppSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAppSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdAppSettingsToggle.Name = "cmdAppSettingsToggle";
            this.cmdAppSettingsToggle.Size = new System.Drawing.Size(495, 33);
            this.cmdAppSettingsToggle.TabIndex = 1;
            this.cmdAppSettingsToggle.Text = "Application Settings";
            this.cmdAppSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAppSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAppSettingsToggle.UseVisualStyleBackColor = true;
            this.cmdAppSettingsToggle.Click += new System.EventHandler(this.cmdAppSettingsToggle_Click);
            // 
            // panelPollingSettings
            // 
            this.panelPollingSettings.Controls.Add(this.chkPausePollingDuringEditConfig);
            this.panelPollingSettings.Controls.Add(this.label4);
            this.panelPollingSettings.Controls.Add(this.chkOverridesMonitorPackFrequency);
            this.panelPollingSettings.Controls.Add(this.label1);
            this.panelPollingSettings.Controls.Add(this.label2);
            this.panelPollingSettings.Controls.Add(this.label3);
            this.panelPollingSettings.Controls.Add(this.freqSecNumericUpDown);
            this.panelPollingSettings.Controls.Add(this.concurrencyLevelNnumericUpDown);
            this.panelPollingSettings.Controls.Add(this.cmdPollingSettingsToggle);
            this.panelPollingSettings.Location = new System.Drawing.Point(3, 181);
            this.panelPollingSettings.Name = "panelPollingSettings";
            this.panelPollingSettings.Size = new System.Drawing.Size(495, 150);
            this.panelPollingSettings.TabIndex = 1;
            // 
            // chkPausePollingDuringEditConfig
            // 
            this.chkPausePollingDuringEditConfig.AutoSize = true;
            this.chkPausePollingDuringEditConfig.Checked = true;
            this.chkPausePollingDuringEditConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPausePollingDuringEditConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPausePollingDuringEditConfig.Location = new System.Drawing.Point(108, 118);
            this.chkPausePollingDuringEditConfig.Name = "chkPausePollingDuringEditConfig";
            this.chkPausePollingDuringEditConfig.Size = new System.Drawing.Size(227, 17);
            this.chkPausePollingDuringEditConfig.TabIndex = 16;
            this.chkPausePollingDuringEditConfig.Text = "Pause polling while editing config of agents";
            this.chkPausePollingDuringEditConfig.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "If Monitor pack has no frequency specified this setting is used.";
            // 
            // chkOverridesMonitorPackFrequency
            // 
            this.chkOverridesMonitorPackFrequency.AutoSize = true;
            this.chkOverridesMonitorPackFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOverridesMonitorPackFrequency.Location = new System.Drawing.Point(208, 42);
            this.chkOverridesMonitorPackFrequency.Name = "chkOverridesMonitorPackFrequency";
            this.chkOverridesMonitorPackFrequency.Size = new System.Drawing.Size(195, 17);
            this.chkOverridesMonitorPackFrequency.TabIndex = 12;
            this.chkOverridesMonitorPackFrequency.Text = "Overrides frequency in Monitor pack";
            this.chkOverridesMonitorPackFrequency.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Frequency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "(sec)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Concurrency level";
            // 
            // freqSecNumericUpDown
            // 
            this.freqSecNumericUpDown.Location = new System.Drawing.Point(107, 41);
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
            this.freqSecNumericUpDown.TabIndex = 10;
            this.freqSecNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.freqSecNumericUpDown.ValueChanged += new System.EventHandler(this.freqSecNumericUpDown_ValueChanged);
            // 
            // concurrencyLevelNnumericUpDown
            // 
            this.concurrencyLevelNnumericUpDown.Location = new System.Drawing.Point(107, 87);
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
            this.concurrencyLevelNnumericUpDown.TabIndex = 15;
            this.concurrencyLevelNnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmdPollingSettingsToggle
            // 
            this.cmdPollingSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdPollingSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPollingSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdPollingSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPollingSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdPollingSettingsToggle.Name = "cmdPollingSettingsToggle";
            this.cmdPollingSettingsToggle.Size = new System.Drawing.Size(495, 33);
            this.cmdPollingSettingsToggle.TabIndex = 1;
            this.cmdPollingSettingsToggle.Text = "Polling Settings";
            this.cmdPollingSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPollingSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPollingSettingsToggle.UseVisualStyleBackColor = true;
            this.cmdPollingSettingsToggle.Click += new System.EventHandler(this.cmdPollingSettingsToggle_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(362, 497);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // panelRecentList
            // 
            this.panelRecentList.Controls.Add(this.chkDisplayFullPathForQuickRecentEntries);
            this.panelRecentList.Controls.Add(this.cmdEditQuickSelectTypeFilters);
            this.panelRecentList.Controls.Add(this.txtRecentMonitorPackFilter);
            this.panelRecentList.Controls.Add(this.label5);
            this.panelRecentList.Controls.Add(this.cmdRecentToggle);
            this.panelRecentList.Location = new System.Drawing.Point(3, 337);
            this.panelRecentList.Name = "panelRecentList";
            this.panelRecentList.Size = new System.Drawing.Size(495, 100);
            this.panelRecentList.TabIndex = 2;
            // 
            // cmdRecentToggle
            // 
            this.cmdRecentToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRecentToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRecentToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdRecentToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRecentToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdRecentToggle.Name = "cmdRecentToggle";
            this.cmdRecentToggle.Size = new System.Drawing.Size(495, 33);
            this.cmdRecentToggle.TabIndex = 1;
            this.cmdRecentToggle.Text = "Recent List";
            this.cmdRecentToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRecentToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRecentToggle.UseVisualStyleBackColor = true;
            this.cmdRecentToggle.Click += new System.EventHandler(this.cmdRecentToggle_Click);
            // 
            // chkDisplayFullPathForQuickRecentEntries
            // 
            this.chkDisplayFullPathForQuickRecentEntries.AutoSize = true;
            this.chkDisplayFullPathForQuickRecentEntries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisplayFullPathForQuickRecentEntries.Location = new System.Drawing.Point(25, 72);
            this.chkDisplayFullPathForQuickRecentEntries.Name = "chkDisplayFullPathForQuickRecentEntries";
            this.chkDisplayFullPathForQuickRecentEntries.Size = new System.Drawing.Size(184, 17);
            this.chkDisplayFullPathForQuickRecentEntries.TabIndex = 7;
            this.chkDisplayFullPathForQuickRecentEntries.Text = "Display full path in quick select list";
            this.chkDisplayFullPathForQuickRecentEntries.UseVisualStyleBackColor = true;
            // 
            // cmdEditQuickSelectTypeFilters
            // 
            this.cmdEditQuickSelectTypeFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditQuickSelectTypeFilters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditQuickSelectTypeFilters.Location = new System.Drawing.Point(450, 38);
            this.cmdEditQuickSelectTypeFilters.Name = "cmdEditQuickSelectTypeFilters";
            this.cmdEditQuickSelectTypeFilters.Size = new System.Drawing.Size(42, 23);
            this.cmdEditQuickSelectTypeFilters.TabIndex = 6;
            this.cmdEditQuickSelectTypeFilters.Text = "- - -";
            this.cmdEditQuickSelectTypeFilters.UseVisualStyleBackColor = true;
            this.cmdEditQuickSelectTypeFilters.Click += new System.EventHandler(this.cmdEditQuickSelectTypeFilters_Click);
            // 
            // txtRecentMonitorPackFilter
            // 
            this.txtRecentMonitorPackFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecentMonitorPackFilter.Location = new System.Drawing.Point(164, 40);
            this.txtRecentMonitorPackFilter.Name = "txtRecentMonitorPackFilter";
            this.txtRecentMonitorPackFilter.Size = new System.Drawing.Size(280, 20);
            this.txtRecentMonitorPackFilter.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quick select Type Filters (csv)";
            // 
            // panelPasswordManagement
            // 
            this.panelPasswordManagement.Controls.Add(this.lvwUserNameCache);
            this.panelPasswordManagement.Controls.Add(this.label8);
            this.panelPasswordManagement.Controls.Add(this.cmdRemoveUserNameFromCache);
            this.panelPasswordManagement.Controls.Add(this.cmdAddUserNameToCache);
            this.panelPasswordManagement.Controls.Add(this.txtApplicationMasterKey);
            this.panelPasswordManagement.Controls.Add(this.label7);
            this.panelPasswordManagement.Controls.Add(this.cmdSelectMasterKeyFile);
            this.panelPasswordManagement.Controls.Add(this.txtApplicationMasterKeyFilePath);
            this.panelPasswordManagement.Controls.Add(this.label6);
            this.panelPasswordManagement.Controls.Add(this.cmdPasswordManagementToggle);
            this.panelPasswordManagement.Location = new System.Drawing.Point(3, 443);
            this.panelPasswordManagement.Name = "panelPasswordManagement";
            this.panelPasswordManagement.Size = new System.Drawing.Size(495, 260);
            this.panelPasswordManagement.TabIndex = 3;
            // 
            // cmdPasswordManagementToggle
            // 
            this.cmdPasswordManagementToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdPasswordManagementToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPasswordManagementToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdPasswordManagementToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPasswordManagementToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdPasswordManagementToggle.Name = "cmdPasswordManagementToggle";
            this.cmdPasswordManagementToggle.Size = new System.Drawing.Size(495, 33);
            this.cmdPasswordManagementToggle.TabIndex = 1;
            this.cmdPasswordManagementToggle.Text = "Password management";
            this.cmdPasswordManagementToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPasswordManagementToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPasswordManagementToggle.UseVisualStyleBackColor = true;
            this.cmdPasswordManagementToggle.Click += new System.EventHandler(this.cmdPasswordManagementToggle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(9, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(425, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "Accounts the application is aware of. Note the file may contain more than shown h" +
    "ere.";
            // 
            // cmdRemoveUserNameFromCache
            // 
            this.cmdRemoveUserNameFromCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoveUserNameFromCache.Enabled = false;
            this.cmdRemoveUserNameFromCache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoveUserNameFromCache.Font = new System.Drawing.Font("Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdRemoveUserNameFromCache.Location = new System.Drawing.Point(444, 139);
            this.cmdRemoveUserNameFromCache.Name = "cmdRemoveUserNameFromCache";
            this.cmdRemoveUserNameFromCache.Size = new System.Drawing.Size(42, 23);
            this.cmdRemoveUserNameFromCache.TabIndex = 15;
            this.cmdRemoveUserNameFromCache.Text = "Ä";
            this.cmdRemoveUserNameFromCache.UseVisualStyleBackColor = true;
            // 
            // cmdAddUserNameToCache
            // 
            this.cmdAddUserNameToCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddUserNameToCache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddUserNameToCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddUserNameToCache.Location = new System.Drawing.Point(444, 110);
            this.cmdAddUserNameToCache.Name = "cmdAddUserNameToCache";
            this.cmdAddUserNameToCache.Size = new System.Drawing.Size(42, 23);
            this.cmdAddUserNameToCache.TabIndex = 14;
            this.cmdAddUserNameToCache.Text = "+";
            this.cmdAddUserNameToCache.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User name cache";
            this.columnHeader1.Width = 356;
            // 
            // txtApplicationMasterKey
            // 
            this.txtApplicationMasterKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationMasterKey.Location = new System.Drawing.Point(163, 41);
            this.txtApplicationMasterKey.Name = "txtApplicationMasterKey";
            this.txtApplicationMasterKey.Size = new System.Drawing.Size(323, 20);
            this.txtApplicationMasterKey.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(9, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Application master key";
            // 
            // cmdSelectMasterKeyFile
            // 
            this.cmdSelectMasterKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectMasterKeyFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSelectMasterKeyFile.Location = new System.Drawing.Point(444, 65);
            this.cmdSelectMasterKeyFile.Name = "cmdSelectMasterKeyFile";
            this.cmdSelectMasterKeyFile.Size = new System.Drawing.Size(42, 23);
            this.cmdSelectMasterKeyFile.TabIndex = 13;
            this.cmdSelectMasterKeyFile.Text = "- - -";
            this.cmdSelectMasterKeyFile.UseVisualStyleBackColor = true;
            // 
            // txtApplicationMasterKeyFilePath
            // 
            this.txtApplicationMasterKeyFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationMasterKeyFilePath.Location = new System.Drawing.Point(163, 67);
            this.txtApplicationMasterKeyFilePath.Name = "txtApplicationMasterKeyFilePath";
            this.txtApplicationMasterKeyFilePath.Size = new System.Drawing.Size(275, 20);
            this.txtApplicationMasterKeyFilePath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(9, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Master key file";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User name cache";
            this.columnHeader2.Width = 356;
            // 
            // lvwUserNameCache
            // 
            this.lvwUserNameCache.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwUserNameCache.AutoResizeColumnEnabled = false;
            this.lvwUserNameCache.AutoResizeColumnIndex = 0;
            this.lvwUserNameCache.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvwUserNameCache.FullRowSelect = true;
            this.lvwUserNameCache.Location = new System.Drawing.Point(12, 110);
            this.lvwUserNameCache.Name = "lvwUserNameCache";
            this.lvwUserNameCache.Size = new System.Drawing.Size(426, 141);
            this.lvwUserNameCache.TabIndex = 17;
            this.lvwUserNameCache.UseCompatibleStateImageBehavior = false;
            this.lvwUserNameCache.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "User name cache";
            this.columnHeader3.Width = 356;
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(530, 532);
            this.Controls.Add(this.flowLayoutPanelSettings);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 423);
            this.Name = "GeneralSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Settings";
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            this.Shown += new System.EventHandler(this.GeneralSettings_Shown);
            this.flowLayoutPanelSettings.ResumeLayout(false);
            this.panelAppSettings.ResumeLayout(false);
            this.panelAppSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPollingSettings.ResumeLayout(false);
            this.panelPollingSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).EndInit();
            this.panelRecentList.ResumeLayout(false);
            this.panelRecentList.PerformLayout();
            this.panelPasswordManagement.ResumeLayout(false);
            this.panelPasswordManagement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelAppSettings;
        private System.Windows.Forms.Button cmdAppSettingsToggle;
        private System.Windows.Forms.Panel panelPollingSettings;
        private System.Windows.Forms.Button cmdPollingSettingsToggle;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSettings;
        private System.Windows.Forms.CheckBox chkDisableAutoAdminMode;
        private System.Windows.Forms.CheckBox chkUseTemplates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPinToTaskbar;
        private System.Windows.Forms.CheckBox chkDesktopShortcut;
        private System.Windows.Forms.CheckBox chkPinToStartMenu;
        private System.Windows.Forms.CheckBox chkCreateBackupOnSave;
        private System.Windows.Forms.CheckBox chkSnapToDesktop;
        private System.Windows.Forms.CheckBox chkAutosaveChanges;
        private System.Windows.Forms.CheckBox chkPausePollingDuringEditConfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkOverridesMonitorPackFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown freqSecNumericUpDown;
        private System.Windows.Forms.NumericUpDown concurrencyLevelNnumericUpDown;
        private System.Windows.Forms.Panel panelRecentList;
        private System.Windows.Forms.CheckBox chkDisplayFullPathForQuickRecentEntries;
        private System.Windows.Forms.Button cmdEditQuickSelectTypeFilters;
        private System.Windows.Forms.TextBox txtRecentMonitorPackFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdRecentToggle;
        private System.Windows.Forms.Panel panelPasswordManagement;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdRemoveUserNameFromCache;
        private System.Windows.Forms.Button cmdAddUserNameToCache;
        private System.Windows.Forms.TextBox txtApplicationMasterKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdSelectMasterKeyFile;
        private System.Windows.Forms.TextBox txtApplicationMasterKeyFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdPasswordManagementToggle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private ListViewEx lvwUserNameCache;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}