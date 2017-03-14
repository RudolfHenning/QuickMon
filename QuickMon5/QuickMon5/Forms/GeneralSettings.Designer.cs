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
            this.panelTvwDetailTextAlign = new System.Windows.Forms.Panel();
            this.optTvwDetailRightAlign = new System.Windows.Forms.RadioButton();
            this.optTvwDetailLeftAlign = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.nudMainWindowTreeViewExtraColumnSize = new System.Windows.Forms.NumericUpDown();
            this.chkDisplayFullPathForQuickRecentEntries = new System.Windows.Forms.CheckBox();
            this.chkDisableAutoAdminMode = new System.Windows.Forms.CheckBox();
            this.cmdEditQuickSelectTypeFilters = new System.Windows.Forms.Button();
            this.chkUseTemplates = new System.Windows.Forms.CheckBox();
            this.txtRecentMonitorPackFilter = new System.Windows.Forms.TextBox();
            this.chkCreateBackupOnSave = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.panelPasswordManagement = new System.Windows.Forms.Panel();
            this.lvwUserNameCache = new QuickMon.ListViewEx();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.cmdRemoveUserNameFromCache = new System.Windows.Forms.Button();
            this.cmdAddUserNameToCache = new System.Windows.Forms.Button();
            this.txtApplicationMasterKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSelectMasterKeyFile = new System.Windows.Forms.Button();
            this.txtApplicationMasterKeyFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdPasswordManagementToggle = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanelSettings.SuspendLayout();
            this.panelAppSettings.SuspendLayout();
            this.panelTvwDetailTextAlign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMainWindowTreeViewExtraColumnSize)).BeginInit();
            this.panelPollingSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).BeginInit();
            this.panelPasswordManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(547, 631);
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
            this.flowLayoutPanelSettings.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelSettings.Controls.Add(this.panelAppSettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelPollingSettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelPasswordManagement);
            this.flowLayoutPanelSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelSettings.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelSettings.Name = "flowLayoutPanelSettings";
            this.flowLayoutPanelSettings.Size = new System.Drawing.Size(633, 625);
            this.flowLayoutPanelSettings.TabIndex = 2;
            this.flowLayoutPanelSettings.WrapContents = false;
            this.flowLayoutPanelSettings.Resize += new System.EventHandler(this.flowLayoutPanelSettings_Resize);
            // 
            // panelAppSettings
            // 
            this.panelAppSettings.Controls.Add(this.panelTvwDetailTextAlign);
            this.panelAppSettings.Controls.Add(this.label9);
            this.panelAppSettings.Controls.Add(this.nudMainWindowTreeViewExtraColumnSize);
            this.panelAppSettings.Controls.Add(this.chkDisplayFullPathForQuickRecentEntries);
            this.panelAppSettings.Controls.Add(this.chkDisableAutoAdminMode);
            this.panelAppSettings.Controls.Add(this.cmdEditQuickSelectTypeFilters);
            this.panelAppSettings.Controls.Add(this.chkUseTemplates);
            this.panelAppSettings.Controls.Add(this.txtRecentMonitorPackFilter);
            this.panelAppSettings.Controls.Add(this.chkCreateBackupOnSave);
            this.panelAppSettings.Controls.Add(this.label5);
            this.panelAppSettings.Controls.Add(this.chkSnapToDesktop);
            this.panelAppSettings.Controls.Add(this.chkAutosaveChanges);
            this.panelAppSettings.Controls.Add(this.cmdAppSettingsToggle);
            this.panelAppSettings.Location = new System.Drawing.Point(3, 3);
            this.panelAppSettings.Name = "panelAppSettings";
            this.panelAppSettings.Size = new System.Drawing.Size(495, 187);
            this.panelAppSettings.TabIndex = 0;
            // 
            // panelTvwDetailTextAlign
            // 
            this.panelTvwDetailTextAlign.Controls.Add(this.optTvwDetailRightAlign);
            this.panelTvwDetailTextAlign.Controls.Add(this.optTvwDetailLeftAlign);
            this.panelTvwDetailTextAlign.Location = new System.Drawing.Point(180, 148);
            this.panelTvwDetailTextAlign.Name = "panelTvwDetailTextAlign";
            this.panelTvwDetailTextAlign.Size = new System.Drawing.Size(306, 28);
            this.panelTvwDetailTextAlign.TabIndex = 12;
            // 
            // optTvwDetailRightAlign
            // 
            this.optTvwDetailRightAlign.AutoSize = true;
            this.optTvwDetailRightAlign.Location = new System.Drawing.Point(80, 8);
            this.optTvwDetailRightAlign.Name = "optTvwDetailRightAlign";
            this.optTvwDetailRightAlign.Size = new System.Drawing.Size(75, 17);
            this.optTvwDetailRightAlign.TabIndex = 1;
            this.optTvwDetailRightAlign.TabStop = true;
            this.optTvwDetailRightAlign.Text = "Right align";
            this.optTvwDetailRightAlign.UseVisualStyleBackColor = true;
            // 
            // optTvwDetailLeftAlign
            // 
            this.optTvwDetailLeftAlign.AutoSize = true;
            this.optTvwDetailLeftAlign.Location = new System.Drawing.Point(3, 8);
            this.optTvwDetailLeftAlign.Name = "optTvwDetailLeftAlign";
            this.optTvwDetailLeftAlign.Size = new System.Drawing.Size(68, 17);
            this.optTvwDetailLeftAlign.TabIndex = 0;
            this.optTvwDetailLeftAlign.TabStop = true;
            this.optTvwDetailLeftAlign.Text = "Left align";
            this.optTvwDetailLeftAlign.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Detail column width";
            // 
            // nudMainWindowTreeViewExtraColumnSize
            // 
            this.nudMainWindowTreeViewExtraColumnSize.Location = new System.Drawing.Point(115, 156);
            this.nudMainWindowTreeViewExtraColumnSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMainWindowTreeViewExtraColumnSize.Name = "nudMainWindowTreeViewExtraColumnSize";
            this.nudMainWindowTreeViewExtraColumnSize.Size = new System.Drawing.Size(59, 20);
            this.nudMainWindowTreeViewExtraColumnSize.TabIndex = 11;
            this.nudMainWindowTreeViewExtraColumnSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkDisplayFullPathForQuickRecentEntries
            // 
            this.chkDisplayFullPathForQuickRecentEntries.AutoSize = true;
            this.chkDisplayFullPathForQuickRecentEntries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisplayFullPathForQuickRecentEntries.Location = new System.Drawing.Point(9, 133);
            this.chkDisplayFullPathForQuickRecentEntries.Name = "chkDisplayFullPathForQuickRecentEntries";
            this.chkDisplayFullPathForQuickRecentEntries.Size = new System.Drawing.Size(184, 17);
            this.chkDisplayFullPathForQuickRecentEntries.TabIndex = 9;
            this.chkDisplayFullPathForQuickRecentEntries.Text = "Display full path in quick select list";
            this.chkDisplayFullPathForQuickRecentEntries.UseVisualStyleBackColor = true;
            // 
            // chkDisableAutoAdminMode
            // 
            this.chkDisableAutoAdminMode.AutoSize = true;
            this.chkDisableAutoAdminMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisableAutoAdminMode.Location = new System.Drawing.Point(9, 85);
            this.chkDisableAutoAdminMode.Name = "chkDisableAutoAdminMode";
            this.chkDisableAutoAdminMode.Size = new System.Drawing.Size(399, 17);
            this.chkDisableAutoAdminMode.TabIndex = 5;
            this.chkDisableAutoAdminMode.Text = "Disable automatic Admin mode (Must be in Admin mode to remove existing task)";
            this.chkDisableAutoAdminMode.UseVisualStyleBackColor = true;
            // 
            // cmdEditQuickSelectTypeFilters
            // 
            this.cmdEditQuickSelectTypeFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditQuickSelectTypeFilters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditQuickSelectTypeFilters.Location = new System.Drawing.Point(450, 105);
            this.cmdEditQuickSelectTypeFilters.Name = "cmdEditQuickSelectTypeFilters";
            this.cmdEditQuickSelectTypeFilters.Size = new System.Drawing.Size(42, 23);
            this.cmdEditQuickSelectTypeFilters.TabIndex = 8;
            this.cmdEditQuickSelectTypeFilters.Text = "- - -";
            this.cmdEditQuickSelectTypeFilters.UseVisualStyleBackColor = true;
            this.cmdEditQuickSelectTypeFilters.Click += new System.EventHandler(this.cmdEditQuickSelectTypeFilters_Click);
            // 
            // chkUseTemplates
            // 
            this.chkUseTemplates.AutoSize = true;
            this.chkUseTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseTemplates.Location = new System.Drawing.Point(9, 62);
            this.chkUseTemplates.Name = "chkUseTemplates";
            this.chkUseTemplates.Size = new System.Drawing.Size(385, 17);
            this.chkUseTemplates.TabIndex = 4;
            this.chkUseTemplates.Text = "Use \'Templates\' when creating new objects (Monitor packs and Agent hosts)";
            this.chkUseTemplates.UseVisualStyleBackColor = true;
            // 
            // txtRecentMonitorPackFilter
            // 
            this.txtRecentMonitorPackFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecentMonitorPackFilter.Location = new System.Drawing.Point(164, 107);
            this.txtRecentMonitorPackFilter.Name = "txtRecentMonitorPackFilter";
            this.txtRecentMonitorPackFilter.Size = new System.Drawing.Size(280, 20);
            this.txtRecentMonitorPackFilter.TabIndex = 7;
            // 
            // chkCreateBackupOnSave
            // 
            this.chkCreateBackupOnSave.AutoSize = true;
            this.chkCreateBackupOnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCreateBackupOnSave.Location = new System.Drawing.Point(333, 39);
            this.chkCreateBackupOnSave.Name = "chkCreateBackupOnSave";
            this.chkCreateBackupOnSave.Size = new System.Drawing.Size(160, 17);
            this.chkCreateBackupOnSave.TabIndex = 3;
            this.chkCreateBackupOnSave.Text = "Back up previous saved files";
            this.chkCreateBackupOnSave.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quick select Type Filters (csv)";
            // 
            // chkSnapToDesktop
            // 
            this.chkSnapToDesktop.AutoSize = true;
            this.chkSnapToDesktop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSnapToDesktop.Location = new System.Drawing.Point(9, 39);
            this.chkSnapToDesktop.Name = "chkSnapToDesktop";
            this.chkSnapToDesktop.Size = new System.Drawing.Size(197, 17);
            this.chkSnapToDesktop.TabIndex = 1;
            this.chkSnapToDesktop.Text = "Snap Main Window to desktop sides";
            this.chkSnapToDesktop.UseVisualStyleBackColor = true;
            // 
            // chkAutosaveChanges
            // 
            this.chkAutosaveChanges.AutoSize = true;
            this.chkAutosaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAutosaveChanges.Location = new System.Drawing.Point(209, 39);
            this.chkAutosaveChanges.Name = "chkAutosaveChanges";
            this.chkAutosaveChanges.Size = new System.Drawing.Size(116, 17);
            this.chkAutosaveChanges.TabIndex = 2;
            this.chkAutosaveChanges.Text = "Auto save changes";
            this.chkAutosaveChanges.UseVisualStyleBackColor = true;
            // 
            // cmdAppSettingsToggle
            // 
            this.cmdAppSettingsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdAppSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAppSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAppSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdAppSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAppSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdAppSettingsToggle.Name = "cmdAppSettingsToggle";
            this.cmdAppSettingsToggle.Size = new System.Drawing.Size(495, 33);
            this.cmdAppSettingsToggle.TabIndex = 0;
            this.cmdAppSettingsToggle.Text = "Application Settings";
            this.cmdAppSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAppSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAppSettingsToggle.UseVisualStyleBackColor = false;
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
            this.panelPollingSettings.Location = new System.Drawing.Point(3, 196);
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
            this.chkPausePollingDuringEditConfig.TabIndex = 8;
            this.chkPausePollingDuringEditConfig.Text = "Pause polling while editing config of agents";
            this.chkPausePollingDuringEditConfig.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "If Monitor pack has no frequency specified this setting is used.";
            // 
            // chkOverridesMonitorPackFrequency
            // 
            this.chkOverridesMonitorPackFrequency.AutoSize = true;
            this.chkOverridesMonitorPackFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOverridesMonitorPackFrequency.Location = new System.Drawing.Point(208, 42);
            this.chkOverridesMonitorPackFrequency.Name = "chkOverridesMonitorPackFrequency";
            this.chkOverridesMonitorPackFrequency.Size = new System.Drawing.Size(195, 17);
            this.chkOverridesMonitorPackFrequency.TabIndex = 4;
            this.chkOverridesMonitorPackFrequency.Text = "Overrides frequency in Monitor pack";
            this.chkOverridesMonitorPackFrequency.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frequency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(sec)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
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
            this.freqSecNumericUpDown.TabIndex = 2;
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
            this.concurrencyLevelNnumericUpDown.TabIndex = 7;
            this.concurrencyLevelNnumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmdPollingSettingsToggle
            // 
            this.cmdPollingSettingsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdPollingSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdPollingSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPollingSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdPollingSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPollingSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdPollingSettingsToggle.Name = "cmdPollingSettingsToggle";
            this.cmdPollingSettingsToggle.Size = new System.Drawing.Size(495, 33);
            this.cmdPollingSettingsToggle.TabIndex = 0;
            this.cmdPollingSettingsToggle.Text = "Polling Settings";
            this.cmdPollingSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPollingSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPollingSettingsToggle.UseVisualStyleBackColor = false;
            this.cmdPollingSettingsToggle.Click += new System.EventHandler(this.cmdPollingSettingsToggle_Click);
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
            this.panelPasswordManagement.Location = new System.Drawing.Point(3, 352);
            this.panelPasswordManagement.Name = "panelPasswordManagement";
            this.panelPasswordManagement.Size = new System.Drawing.Size(495, 260);
            this.panelPasswordManagement.TabIndex = 0;
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
            this.lvwUserNameCache.TabIndex = 7;
            this.lvwUserNameCache.UseCompatibleStateImageBehavior = false;
            this.lvwUserNameCache.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "User name cache";
            this.columnHeader3.Width = 356;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(9, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(425, 14);
            this.label8.TabIndex = 6;
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
            this.cmdRemoveUserNameFromCache.TabIndex = 9;
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
            this.cmdAddUserNameToCache.TabIndex = 8;
            this.cmdAddUserNameToCache.Text = "+";
            this.cmdAddUserNameToCache.UseVisualStyleBackColor = true;
            // 
            // txtApplicationMasterKey
            // 
            this.txtApplicationMasterKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationMasterKey.Location = new System.Drawing.Point(163, 41);
            this.txtApplicationMasterKey.Name = "txtApplicationMasterKey";
            this.txtApplicationMasterKey.Size = new System.Drawing.Size(323, 20);
            this.txtApplicationMasterKey.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(9, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Application master key";
            // 
            // cmdSelectMasterKeyFile
            // 
            this.cmdSelectMasterKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectMasterKeyFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSelectMasterKeyFile.Location = new System.Drawing.Point(444, 65);
            this.cmdSelectMasterKeyFile.Name = "cmdSelectMasterKeyFile";
            this.cmdSelectMasterKeyFile.Size = new System.Drawing.Size(42, 23);
            this.cmdSelectMasterKeyFile.TabIndex = 5;
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
            this.txtApplicationMasterKeyFilePath.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(9, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Master key file";
            // 
            // cmdPasswordManagementToggle
            // 
            this.cmdPasswordManagementToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdPasswordManagementToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdPasswordManagementToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPasswordManagementToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdPasswordManagementToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPasswordManagementToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdPasswordManagementToggle.Name = "cmdPasswordManagementToggle";
            this.cmdPasswordManagementToggle.Size = new System.Drawing.Size(495, 33);
            this.cmdPasswordManagementToggle.TabIndex = 0;
            this.cmdPasswordManagementToggle.Text = "Password Management";
            this.cmdPasswordManagementToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPasswordManagementToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPasswordManagementToggle.UseVisualStyleBackColor = false;
            this.cmdPasswordManagementToggle.Click += new System.EventHandler(this.cmdPasswordManagementToggle_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(466, 631);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User name cache";
            this.columnHeader1.Width = 356;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User name cache";
            this.columnHeader2.Width = 356;
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuickMon.Properties.Resources.QuickMon5Background3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(634, 666);
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
            this.panelTvwDetailTextAlign.ResumeLayout(false);
            this.panelTvwDetailTextAlign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMainWindowTreeViewExtraColumnSize)).EndInit();
            this.panelPollingSettings.ResumeLayout(false);
            this.panelPollingSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).EndInit();
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
        private System.Windows.Forms.CheckBox chkDisplayFullPathForQuickRecentEntries;
        private System.Windows.Forms.Button cmdEditQuickSelectTypeFilters;
        private System.Windows.Forms.TextBox txtRecentMonitorPackFilter;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Panel panelTvwDetailTextAlign;
        private System.Windows.Forms.RadioButton optTvwDetailRightAlign;
        private System.Windows.Forms.RadioButton optTvwDetailLeftAlign;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudMainWindowTreeViewExtraColumnSize;
    }
}