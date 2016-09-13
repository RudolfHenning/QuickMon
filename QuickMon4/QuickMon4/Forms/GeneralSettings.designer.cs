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
            this.txtApplicationMasterKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApplicationMasterKeyFilePath = new System.Windows.Forms.TextBox();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmdRemoveUserNameFromCache = new System.Windows.Forms.Button();
            this.cmdAddUserNameToCache = new System.Windows.Forms.Button();
            this.lvwUserNameCache = new QuickMon.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userCacheContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userCacheImageList = new System.Windows.Forms.ImageList(this.components);
            this.cmdSelectMasterKeyFile = new System.Windows.Forms.Button();
            this.remoteHostListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.monitorPacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteHostStatusImageList = new System.Windows.Forms.ImageList(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.quickMonServiceOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.shadePanel1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialogSaveQmmxml = new System.Windows.Forms.SaveFileDialog();
            this.qmmxmlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.recentTabPage.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.userCacheContextMenuStrip.SuspendLayout();
            this.remoteHostListContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // concurrencyLevelNnumericUpDown
            // 
            this.concurrencyLevelNnumericUpDown.Location = new System.Drawing.Point(117, 89);
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
            this.label3.Location = new System.Drawing.Point(19, 91);
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
            this.cmdCancel.Location = new System.Drawing.Point(489, 306);
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
            this.cmdOK.Location = new System.Drawing.Point(408, 306);
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
            this.chkPausePollingDuringEditConfig.Location = new System.Drawing.Point(118, 120);
            this.chkPausePollingDuringEditConfig.Name = "chkPausePollingDuringEditConfig";
            this.chkPausePollingDuringEditConfig.Size = new System.Drawing.Size(227, 17);
            this.chkPausePollingDuringEditConfig.TabIndex = 8;
            this.chkPausePollingDuringEditConfig.Text = "Pause polling while editing config of agents";
            this.chkPausePollingDuringEditConfig.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "If Monitor pack has no frequency specified this setting is used.";
            // 
            // chkOverridesMonitorPackFrequency
            // 
            this.chkOverridesMonitorPackFrequency.AutoSize = true;
            this.chkOverridesMonitorPackFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOverridesMonitorPackFrequency.Location = new System.Drawing.Point(218, 44);
            this.chkOverridesMonitorPackFrequency.Name = "chkOverridesMonitorPackFrequency";
            this.chkOverridesMonitorPackFrequency.Size = new System.Drawing.Size(195, 17);
            this.chkOverridesMonitorPackFrequency.TabIndex = 4;
            this.chkOverridesMonitorPackFrequency.Text = "Overrides frequency in Monitor pack";
            this.chkOverridesMonitorPackFrequency.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(sec)";
            // 
            // freqSecNumericUpDown
            // 
            this.freqSecNumericUpDown.Location = new System.Drawing.Point(117, 43);
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
            this.label1.Location = new System.Drawing.Point(19, 45);
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
            this.txtRecentMonitorPackFilter.Size = new System.Drawing.Size(303, 20);
            this.txtRecentMonitorPackFilter.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtRecentMonitorPackFilter, "* - All, use ~ for exclude");
            // 
            // txtApplicationMasterKey
            // 
            this.txtApplicationMasterKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationMasterKey.Location = new System.Drawing.Point(156, 6);
            this.txtApplicationMasterKey.Name = "txtApplicationMasterKey";
            this.txtApplicationMasterKey.Size = new System.Drawing.Size(382, 20);
            this.txtApplicationMasterKey.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtApplicationMasterKey, "Do not loose this key as decryption the credentials is impossible without it!");
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(362, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Accounts the application is aware of. Note the file may contain more than shown h" +
    "ere.";
            this.toolTip1.SetToolTip(this.label8, "Do not loose this key as decryption the credentials is impossible without it!");
            // 
            // txtApplicationMasterKeyFilePath
            // 
            this.txtApplicationMasterKeyFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationMasterKeyFilePath.Location = new System.Drawing.Point(156, 32);
            this.txtApplicationMasterKeyFilePath.Name = "txtApplicationMasterKeyFilePath";
            this.txtApplicationMasterKeyFilePath.Size = new System.Drawing.Size(334, 20);
            this.txtApplicationMasterKeyFilePath.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.recentTabPage);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 269);
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
            this.tabPage1.Size = new System.Drawing.Size(565, 243);
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
            this.tabPage2.Size = new System.Drawing.Size(565, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application";
            // 
            // chkDisableAutoAdminMode
            // 
            this.chkDisableAutoAdminMode.AutoSize = true;
            this.chkDisableAutoAdminMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisableAutoAdminMode.Location = new System.Drawing.Point(19, 118);
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
            this.groupBox1.Size = new System.Drawing.Size(529, 50);
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
            this.chkUseTemplates.Location = new System.Drawing.Point(19, 95);
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
            this.recentTabPage.Size = new System.Drawing.Size(565, 243);
            this.recentTabPage.TabIndex = 3;
            this.recentTabPage.Text = "Recent";
            // 
            // chkDisplayFullPathForQuickRecentEntries
            // 
            this.chkDisplayFullPathForQuickRecentEntries.AutoSize = true;
            this.chkDisplayFullPathForQuickRecentEntries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDisplayFullPathForQuickRecentEntries.Location = new System.Drawing.Point(25, 43);
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
            this.cmdEditQuickSelectTypeFilters.Location = new System.Drawing.Point(473, 9);
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
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.label8);
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
            this.tabPage3.Size = new System.Drawing.Size(546, 232);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Security";
            // 
            // cmdRemoveUserNameFromCache
            // 
            this.cmdRemoveUserNameFromCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoveUserNameFromCache.Enabled = false;
            this.cmdRemoveUserNameFromCache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemoveUserNameFromCache.Font = new System.Drawing.Font("Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdRemoveUserNameFromCache.Location = new System.Drawing.Point(496, 104);
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
            this.cmdAddUserNameToCache.Location = new System.Drawing.Point(496, 75);
            this.cmdAddUserNameToCache.Name = "cmdAddUserNameToCache";
            this.cmdAddUserNameToCache.Size = new System.Drawing.Size(42, 23);
            this.cmdAddUserNameToCache.TabIndex = 6;
            this.cmdAddUserNameToCache.Text = "+";
            this.cmdAddUserNameToCache.UseVisualStyleBackColor = true;
            this.cmdAddUserNameToCache.Click += new System.EventHandler(this.cmdAddUserNameToCache_Click);
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
            this.lvwUserNameCache.Location = new System.Drawing.Point(6, 75);
            this.lvwUserNameCache.Name = "lvwUserNameCache";
            this.lvwUserNameCache.Size = new System.Drawing.Size(484, 152);
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
            // cmdSelectMasterKeyFile
            // 
            this.cmdSelectMasterKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectMasterKeyFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSelectMasterKeyFile.Location = new System.Drawing.Point(496, 30);
            this.cmdSelectMasterKeyFile.Name = "cmdSelectMasterKeyFile";
            this.cmdSelectMasterKeyFile.Size = new System.Drawing.Size(42, 23);
            this.cmdSelectMasterKeyFile.TabIndex = 4;
            this.cmdSelectMasterKeyFile.Text = "- - -";
            this.cmdSelectMasterKeyFile.UseVisualStyleBackColor = true;
            this.cmdSelectMasterKeyFile.Click += new System.EventHandler(this.cmdSelectMasterKeyFile_Click);
            // 
            // remoteHostListContextMenuStrip
            // 
            this.remoteHostListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorPacksToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.remoteHostListContextMenuStrip.Name = "contextMenuStrip1";
            this.remoteHostListContextMenuStrip.Size = new System.Drawing.Size(151, 76);
            // 
            // monitorPacksToolStripMenuItem
            // 
            this.monitorPacksToolStripMenuItem.Enabled = false;
            this.monitorPacksToolStripMenuItem.Name = "monitorPacksToolStripMenuItem";
            this.monitorPacksToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.monitorPacksToolStripMenuItem.Text = "Monitor packs";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
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
            // quickMonServiceOpenFileDialog
            // 
            this.quickMonServiceOpenFileDialog.DefaultExt = "exe";
            this.quickMonServiceOpenFileDialog.FileName = "QuickMonService.exe";
            this.quickMonServiceOpenFileDialog.Filter = "QuickMon 4 Service|QuickMonService.exe";
            this.quickMonServiceOpenFileDialog.Title = "Select QuickMon 4 Service";
            // 
            // shadePanel1
            // 
            this.shadePanel1.BackgroundImage = global::QuickMon.Properties.Resources.BlueHeader1;
            this.shadePanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shadePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.shadePanel1.Location = new System.Drawing.Point(0, 0);
            this.shadePanel1.Name = "shadePanel1";
            this.shadePanel1.Size = new System.Drawing.Size(584, 31);
            this.shadePanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuickMon.Properties.Resources.BlueHeader2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 31);
            this.panel1.TabIndex = 11;
            // 
            // saveFileDialogSaveQmmxml
            // 
            this.saveFileDialogSaveQmmxml.DefaultExt = "qmmxml";
            this.saveFileDialogSaveQmmxml.Filter = "QuickMon master key files|*.qmmxml";
            this.saveFileDialogSaveQmmxml.Title = "Select QuickMon master key file";
            // 
            // qmmxmlOpenFileDialog
            // 
            this.qmmxmlOpenFileDialog.CheckFileExists = false;
            this.qmmxmlOpenFileDialog.DefaultExt = "qmmxml";
            this.qmmxmlOpenFileDialog.Filter = "QuickMon master key files|*.qmmxml";
            this.qmmxmlOpenFileDialog.Title = "Select QuickMon master key file";
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.shadePanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.userCacheContextMenuStrip.ResumeLayout(false);
            this.remoteHostListContextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.OpenFileDialog qmmxmlOpenFileDialog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem monitorPacksToolStripMenuItem;
    }
}