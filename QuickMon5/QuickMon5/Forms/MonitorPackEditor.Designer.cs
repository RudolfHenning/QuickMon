namespace QuickMon
{ 
    partial class MonitorPackEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorPackEditor));
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanelSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.panelGeneralSettings = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMonitorPackPath = new System.Windows.Forms.Label();
            this.chkEnableStickyMainWindowLocation = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.freqSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.txtType = new System.Windows.Forms.TextBox();
            this.cmdGeneralSettingsToggle = new System.Windows.Forms.Button();
            this.panelAgentSettings = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPersistCollectorHistory = new System.Windows.Forms.CheckBox();
            this.chkCorrectiveScripts = new System.Windows.Forms.CheckBox();
            this.chkCollectorChildCheckBehaviourOverride = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChildCheckBehaviour = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.exportHistoryContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardExportAsCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label39 = new System.Windows.Forms.Label();
            this.collectorStateHistorySizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cmdAgentSettingsToggle = new System.Windows.Forms.Button();
            this.panelVariables = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwConfigVars = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripVariables = new System.Windows.Forms.ToolStrip();
            this.addConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panelVarEdit = new System.Windows.Forms.Panel();
            this.llblExpandConfigVarSection = new System.Windows.Forms.LinkLabel();
            this.txtConfigVarSearchFor = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtConfigVarReplaceByValue = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.cmdVariablesToggle = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.panelSecuritySettings = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdRemoveUserNameFromCache = new System.Windows.Forms.Button();
            this.cmdAddUserNameToCache = new System.Windows.Forms.Button();
            this.lvwUserNameCache = new QuickMon.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userCacheContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setPwdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userCacheImageList = new System.Windows.Forms.ImageList(this.components);
            this.txtMasterKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdSelectMasterKeyFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMasterKeyFilePath = new System.Windows.Forms.TextBox();
            this.cmdSecuritySettingsToggle = new System.Windows.Forms.Button();
            this.panelLoggingSettings = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkLoggingEnabled = new System.Windows.Forms.CheckBox();
            this.txtLoggingPath = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLoggingCollectorCategories = new System.Windows.Forms.TextBox();
            this.cmdLoggingPath = new System.Windows.Forms.Button();
            this.nudKeepLogFilesXDays = new System.Windows.Forms.NumericUpDown();
            this.chkLoggingCollectorEvents = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkLoggingNotifierEvents = new System.Windows.Forms.CheckBox();
            this.chkLoggingServiceWindowEvents = new System.Windows.Forms.CheckBox();
            this.chkLoggingAlertsRaised = new System.Windows.Forms.CheckBox();
            this.chkLoggingPollingOverridesTriggered = new System.Windows.Forms.CheckBox();
            this.chkLoggingCorrectiveScriptRun = new System.Windows.Forms.CheckBox();
            this.cmdLoggingSettingsToggle = new System.Windows.Forms.Button();
            this.metricsExportGroupBox = new System.Windows.Forms.GroupBox();
            this.chkCollectorMetricsExportIncludeDisabled = new System.Windows.Forms.CheckBox();
            this.cmdBrowseCollectorMetricsExportPath = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCollectorMetricsExportPath = new System.Windows.Forms.TextBox();
            this.chkCollectorMetricsExportToXMLEnabled = new System.Windows.Forms.CheckBox();
            this.chkCollectorMetricsExportToCSVEnabled = new System.Windows.Forms.CheckBox();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.fbdLogging = new System.Windows.Forms.FolderBrowserDialog();
            this.qmmxmlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.llblSaveCollectorHistoryNow = new System.Windows.Forms.LinkLabel();
            this.llblRestoreCollectorHistoryNow = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanelSettings.SuspendLayout();
            this.panelGeneralSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            this.panelAgentSettings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.exportHistoryContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collectorStateHistorySizeNumericUpDown)).BeginInit();
            this.panelVariables.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStripVariables.SuspendLayout();
            this.panelVarEdit.SuspendLayout();
            this.panelSecuritySettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.userCacheContextMenuStrip.SuspendLayout();
            this.panelLoggingSettings.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepLogFilesXDays)).BeginInit();
            this.metricsExportGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnabled.Location = new System.Drawing.Point(20, 39);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(128, 17);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Text = "Monitor Pack &Enabled";
            this.chkEnabled.UseVisualStyleBackColor = false;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(125, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(412, 22);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(9, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "&Name";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(416, 631);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(497, 631);
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
            this.flowLayoutPanelSettings.Controls.Add(this.panelGeneralSettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelAgentSettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelVariables);
            this.flowLayoutPanelSettings.Controls.Add(this.panelSecuritySettings);
            this.flowLayoutPanelSettings.Controls.Add(this.panelLoggingSettings);
            this.flowLayoutPanelSettings.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanelSettings.Name = "flowLayoutPanelSettings";
            this.flowLayoutPanelSettings.Size = new System.Drawing.Size(582, 625);
            this.flowLayoutPanelSettings.TabIndex = 2;
            this.flowLayoutPanelSettings.Resize += new System.EventHandler(this.flowLayoutPanelSettings_Resize);
            // 
            // panelGeneralSettings
            // 
            this.panelGeneralSettings.Controls.Add(this.panel1);
            this.panelGeneralSettings.Controls.Add(this.cmdGeneralSettingsToggle);
            this.panelGeneralSettings.Location = new System.Drawing.Point(3, 3);
            this.panelGeneralSettings.Name = "panelGeneralSettings";
            this.panelGeneralSettings.Size = new System.Drawing.Size(549, 171);
            this.panelGeneralSettings.TabIndex = 0;
            this.panelGeneralSettings.Resize += new System.EventHandler(this.panelGeneralSettings_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMonitorPackPath);
            this.panel1.Controls.Add(this.chkEnableStickyMainWindowLocation);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkEnabled);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.freqSecNumericUpDown);
            this.panel1.Controls.Add(this.txtType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 138);
            this.panel1.TabIndex = 12;
            // 
            // lblMonitorPackPath
            // 
            this.lblMonitorPackPath.AutoEllipsis = true;
            this.lblMonitorPackPath.BackColor = System.Drawing.Color.Transparent;
            this.lblMonitorPackPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMonitorPackPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMonitorPackPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitorPackPath.ForeColor = System.Drawing.Color.DimGray;
            this.lblMonitorPackPath.Location = new System.Drawing.Point(0, 118);
            this.lblMonitorPackPath.Name = "lblMonitorPackPath";
            this.lblMonitorPackPath.Size = new System.Drawing.Size(549, 20);
            this.lblMonitorPackPath.TabIndex = 11;
            this.lblMonitorPackPath.Text = " <Path>";
            this.lblMonitorPackPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMonitorPackPath.DoubleClick += new System.EventHandler(this.lblMonitorPackPath_DoubleClick);
            // 
            // chkEnableStickyMainWindowLocation
            // 
            this.chkEnableStickyMainWindowLocation.AutoSize = true;
            this.chkEnableStickyMainWindowLocation.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableStickyMainWindowLocation.Checked = true;
            this.chkEnableStickyMainWindowLocation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableStickyMainWindowLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnableStickyMainWindowLocation.Location = new System.Drawing.Point(156, 39);
            this.chkEnableStickyMainWindowLocation.Name = "chkEnableStickyMainWindowLocation";
            this.chkEnableStickyMainWindowLocation.Size = new System.Drawing.Size(213, 17);
            this.chkEnableStickyMainWindowLocation.TabIndex = 4;
            this.chkEnableStickyMainWindowLocation.Text = "Remember size/location of main window";
            this.chkEnableStickyMainWindowLocation.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Polling Frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "If frequency = 0 then application setting is used";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sec";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "&Type";
            // 
            // freqSecNumericUpDown
            // 
            this.freqSecNumericUpDown.Location = new System.Drawing.Point(126, 92);
            this.freqSecNumericUpDown.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.freqSecNumericUpDown.Name = "freqSecNumericUpDown";
            this.freqSecNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.freqSecNumericUpDown.TabIndex = 8;
            this.freqSecNumericUpDown.ValueChanged += new System.EventHandler(this.freqSecNumericUpDown_ValueChanged);
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(126, 62);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(411, 20);
            this.txtType.TabIndex = 6;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // cmdGeneralSettingsToggle
            // 
            this.cmdGeneralSettingsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdGeneralSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdGeneralSettingsToggle.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdGeneralSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGeneralSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdGeneralSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGeneralSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdGeneralSettingsToggle.Name = "cmdGeneralSettingsToggle";
            this.cmdGeneralSettingsToggle.Size = new System.Drawing.Size(549, 33);
            this.cmdGeneralSettingsToggle.TabIndex = 0;
            this.cmdGeneralSettingsToggle.Text = "General Settings";
            this.cmdGeneralSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGeneralSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdGeneralSettingsToggle.UseVisualStyleBackColor = false;
            this.cmdGeneralSettingsToggle.Click += new System.EventHandler(this.cmdGeneralSettingsToggle_Click);
            // 
            // panelAgentSettings
            // 
            this.panelAgentSettings.Controls.Add(this.panel2);
            this.panelAgentSettings.Controls.Add(this.cmdAgentSettingsToggle);
            this.panelAgentSettings.Location = new System.Drawing.Point(3, 180);
            this.panelAgentSettings.Name = "panelAgentSettings";
            this.panelAgentSettings.Size = new System.Drawing.Size(549, 174);
            this.panelAgentSettings.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.llblRestoreCollectorHistoryNow);
            this.panel2.Controls.Add(this.llblSaveCollectorHistoryNow);
            this.panel2.Controls.Add(this.chkPersistCollectorHistory);
            this.panel2.Controls.Add(this.chkCorrectiveScripts);
            this.panel2.Controls.Add(this.chkCollectorChildCheckBehaviourOverride);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboChildCheckBehaviour);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.collectorStateHistorySizeNumericUpDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 141);
            this.panel2.TabIndex = 8;
            // 
            // chkPersistCollectorHistory
            // 
            this.chkPersistCollectorHistory.AutoSize = true;
            this.chkPersistCollectorHistory.BackColor = System.Drawing.Color.Transparent;
            this.chkPersistCollectorHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPersistCollectorHistory.Location = new System.Drawing.Point(354, 34);
            this.chkPersistCollectorHistory.Name = "chkPersistCollectorHistory";
            this.chkPersistCollectorHistory.Size = new System.Drawing.Size(87, 17);
            this.chkPersistCollectorHistory.TabIndex = 4;
            this.chkPersistCollectorHistory.Text = "Persist history";
            this.chkPersistCollectorHistory.UseVisualStyleBackColor = false;
            // 
            // chkCorrectiveScripts
            // 
            this.chkCorrectiveScripts.AutoSize = true;
            this.chkCorrectiveScripts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCorrectiveScripts.Location = new System.Drawing.Point(12, 7);
            this.chkCorrectiveScripts.Name = "chkCorrectiveScripts";
            this.chkCorrectiveScripts.Size = new System.Drawing.Size(184, 17);
            this.chkCorrectiveScripts.TabIndex = 0;
            this.chkCorrectiveScripts.Text = "&Allow corrective scripts to execute";
            this.chkCorrectiveScripts.UseVisualStyleBackColor = true;
            // 
            // chkCollectorChildCheckBehaviourOverride
            // 
            this.chkCollectorChildCheckBehaviourOverride.AutoSize = true;
            this.chkCollectorChildCheckBehaviourOverride.BackColor = System.Drawing.Color.Transparent;
            this.chkCollectorChildCheckBehaviourOverride.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCollectorChildCheckBehaviourOverride.Location = new System.Drawing.Point(16, 110);
            this.chkCollectorChildCheckBehaviourOverride.Name = "chkCollectorChildCheckBehaviourOverride";
            this.chkCollectorChildCheckBehaviourOverride.Size = new System.Drawing.Size(377, 17);
            this.chkCollectorChildCheckBehaviourOverride.TabIndex = 9;
            this.chkCollectorChildCheckBehaviourOverride.Text = "Override Collector host(s). If not selected use setting on each Collector host";
            this.chkCollectorChildCheckBehaviourOverride.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "# of collector states to keep";
            // 
            // cboChildCheckBehaviour
            // 
            this.cboChildCheckBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChildCheckBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChildCheckBehaviour.FormattingEnabled = true;
            this.cboChildCheckBehaviour.Items.AddRange(new object[] {
            "Only Run On Success",
            "Continue On Warning",
            "Continue On Warning Or Error"});
            this.cboChildCheckBehaviour.Location = new System.Drawing.Point(140, 81);
            this.cboChildCheckBehaviour.Name = "cboChildCheckBehaviour";
            this.cboChildCheckBehaviour.Size = new System.Drawing.Size(397, 21);
            this.cboChildCheckBehaviour.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ContextMenuStrip = this.exportHistoryContextMenuStrip;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Collector &history";
            // 
            // exportHistoryContextMenuStrip
            // 
            this.exportHistoryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToClipboardToolStripMenuItem});
            this.exportHistoryContextMenuStrip.Name = "exportHistoryContextMenuStrip";
            this.exportHistoryContextMenuStrip.Size = new System.Drawing.Size(176, 26);
            // 
            // exportToClipboardToolStripMenuItem
            // 
            this.exportToClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardExportAsCSVToolStripMenuItem,
            this.asXMLToolStripMenuItem});
            this.exportToClipboardToolStripMenuItem.Name = "exportToClipboardToolStripMenuItem";
            this.exportToClipboardToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exportToClipboardToolStripMenuItem.Text = "Export to clipboard";
            // 
            // clipboardExportAsCSVToolStripMenuItem
            // 
            this.clipboardExportAsCSVToolStripMenuItem.Name = "clipboardExportAsCSVToolStripMenuItem";
            this.clipboardExportAsCSVToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.clipboardExportAsCSVToolStripMenuItem.Text = "As CSV";
            this.clipboardExportAsCSVToolStripMenuItem.Click += new System.EventHandler(this.clipboardExportAsCSVToolStripMenuItem_Click);
            // 
            // asXMLToolStripMenuItem
            // 
            this.asXMLToolStripMenuItem.Name = "asXMLToolStripMenuItem";
            this.asXMLToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.asXMLToolStripMenuItem.Text = "As XML";
            this.asXMLToolStripMenuItem.Click += new System.EventHandler(this.asXMLToolStripMenuItem_Click);
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(9, 84);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(125, 18);
            this.label39.TabIndex = 7;
            this.label39.Text = "Child check sequence behaviour";
            // 
            // collectorStateHistorySizeNumericUpDown
            // 
            this.collectorStateHistorySizeNumericUpDown.Location = new System.Drawing.Point(140, 34);
            this.collectorStateHistorySizeNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.collectorStateHistorySizeNumericUpDown.Name = "collectorStateHistorySizeNumericUpDown";
            this.collectorStateHistorySizeNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.collectorStateHistorySizeNumericUpDown.TabIndex = 2;
            // 
            // cmdAgentSettingsToggle
            // 
            this.cmdAgentSettingsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdAgentSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAgentSettingsToggle.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdAgentSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAgentSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdAgentSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgentSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdAgentSettingsToggle.Name = "cmdAgentSettingsToggle";
            this.cmdAgentSettingsToggle.Size = new System.Drawing.Size(549, 33);
            this.cmdAgentSettingsToggle.TabIndex = 0;
            this.cmdAgentSettingsToggle.Text = "Collectors and Notifiers";
            this.cmdAgentSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgentSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAgentSettingsToggle.UseVisualStyleBackColor = false;
            this.cmdAgentSettingsToggle.Click += new System.EventHandler(this.cmdAgentSettingsToggle_Click);
            // 
            // panelVariables
            // 
            this.panelVariables.Controls.Add(this.panel3);
            this.panelVariables.Controls.Add(this.panelVarEdit);
            this.panelVariables.Controls.Add(this.cmdVariablesToggle);
            this.panelVariables.Controls.Add(this.label42);
            this.panelVariables.Location = new System.Drawing.Point(3, 360);
            this.panelVariables.Name = "panelVariables";
            this.panelVariables.Size = new System.Drawing.Size(549, 300);
            this.panelVariables.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvwConfigVars);
            this.panel3.Controls.Add(this.toolStripVariables);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 110);
            this.panel3.TabIndex = 5;
            // 
            // lvwConfigVars
            // 
            this.lvwConfigVars.AutoResizeColumnEnabled = false;
            this.lvwConfigVars.AutoResizeColumnIndex = 1;
            this.lvwConfigVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.lvwConfigVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwConfigVars.FullRowSelect = true;
            this.lvwConfigVars.HideSelection = false;
            this.lvwConfigVars.Location = new System.Drawing.Point(0, 25);
            this.lvwConfigVars.Name = "lvwConfigVars";
            this.lvwConfigVars.Size = new System.Drawing.Size(549, 85);
            this.lvwConfigVars.TabIndex = 2;
            this.lvwConfigVars.UseCompatibleStateImageBehavior = false;
            this.lvwConfigVars.View = System.Windows.Forms.View.Details;
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
            // toolStripVariables
            // 
            this.toolStripVariables.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripVariables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConfigVarToolStripButton,
            this.deleteConfigVarToolStripButton,
            this.toolStripSeparator1,
            this.moveUpConfigVarToolStripButton,
            this.moveDownConfigVarToolStripButton});
            this.toolStripVariables.Location = new System.Drawing.Point(0, 0);
            this.toolStripVariables.Name = "toolStripVariables";
            this.toolStripVariables.Size = new System.Drawing.Size(549, 25);
            this.toolStripVariables.TabIndex = 1;
            this.toolStripVariables.TabStop = true;
            this.toolStripVariables.Text = "toolStrip1";
            // 
            // addConfigVarToolStripButton
            // 
            this.addConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addConfigVarToolStripButton.Name = "addConfigVarToolStripButton";
            this.addConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addConfigVarToolStripButton.Text = "Create new";
            this.addConfigVarToolStripButton.ToolTipText = "Add entry";
            this.addConfigVarToolStripButton.Click += new System.EventHandler(this.addConfigVarToolStripButton_Click);
            // 
            // deleteConfigVarToolStripButton
            // 
            this.deleteConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteConfigVarToolStripButton.Enabled = false;
            this.deleteConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.deleteConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteConfigVarToolStripButton.Name = "deleteConfigVarToolStripButton";
            this.deleteConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteConfigVarToolStripButton.Text = "Delete selected item(s)";
            this.deleteConfigVarToolStripButton.Click += new System.EventHandler(this.deleteConfigVarToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // moveUpConfigVarToolStripButton
            // 
            this.moveUpConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpConfigVarToolStripButton.Enabled = false;
            this.moveUpConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpConfigVarToolStripButton.Name = "moveUpConfigVarToolStripButton";
            this.moveUpConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
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
            this.moveDownConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveDownConfigVarToolStripButton.Text = "Move selected item down";
            this.moveDownConfigVarToolStripButton.Click += new System.EventHandler(this.moveDownConfigVarToolStripButton_Click);
            // 
            // panelVarEdit
            // 
            this.panelVarEdit.Controls.Add(this.llblExpandConfigVarSection);
            this.panelVarEdit.Controls.Add(this.txtConfigVarSearchFor);
            this.panelVarEdit.Controls.Add(this.label40);
            this.panelVarEdit.Controls.Add(this.txtConfigVarReplaceByValue);
            this.panelVarEdit.Controls.Add(this.label41);
            this.panelVarEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVarEdit.Location = new System.Drawing.Point(0, 143);
            this.panelVarEdit.Name = "panelVarEdit";
            this.panelVarEdit.Size = new System.Drawing.Size(549, 128);
            this.panelVarEdit.TabIndex = 3;
            // 
            // llblExpandConfigVarSection
            // 
            this.llblExpandConfigVarSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblExpandConfigVarSection.AutoSize = true;
            this.llblExpandConfigVarSection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblExpandConfigVarSection.Location = new System.Drawing.Point(6, 111);
            this.llblExpandConfigVarSection.Name = "llblExpandConfigVarSection";
            this.llblExpandConfigVarSection.Size = new System.Drawing.Size(43, 13);
            this.llblExpandConfigVarSection.TabIndex = 4;
            this.llblExpandConfigVarSection.TabStop = true;
            this.llblExpandConfigVarSection.Text = "Expand";
            this.llblExpandConfigVarSection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblExpandConfigVarSection_LinkClicked);
            // 
            // txtConfigVarSearchFor
            // 
            this.txtConfigVarSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigVarSearchFor.Location = new System.Drawing.Point(80, 3);
            this.txtConfigVarSearchFor.Name = "txtConfigVarSearchFor";
            this.txtConfigVarSearchFor.Size = new System.Drawing.Size(466, 20);
            this.txtConfigVarSearchFor.TabIndex = 1;
            this.txtConfigVarSearchFor.TextChanged += new System.EventHandler(this.txtConfigVarSearchFor_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 6);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 13);
            this.label40.TabIndex = 0;
            this.label40.Text = "Search for";
            // 
            // txtConfigVarReplaceByValue
            // 
            this.txtConfigVarReplaceByValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigVarReplaceByValue.Location = new System.Drawing.Point(80, 28);
            this.txtConfigVarReplaceByValue.Multiline = true;
            this.txtConfigVarReplaceByValue.Name = "txtConfigVarReplaceByValue";
            this.txtConfigVarReplaceByValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfigVarReplaceByValue.Size = new System.Drawing.Size(466, 97);
            this.txtConfigVarReplaceByValue.TabIndex = 3;
            this.txtConfigVarReplaceByValue.TextChanged += new System.EventHandler(this.txtConfigVarReplaceByValue_TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(5, 31);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 13);
            this.label41.TabIndex = 2;
            this.label41.Text = "Replace with";
            // 
            // cmdVariablesToggle
            // 
            this.cmdVariablesToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdVariablesToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdVariablesToggle.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdVariablesToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdVariablesToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdVariablesToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVariablesToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdVariablesToggle.Name = "cmdVariablesToggle";
            this.cmdVariablesToggle.Size = new System.Drawing.Size(549, 33);
            this.cmdVariablesToggle.TabIndex = 0;
            this.cmdVariablesToggle.Text = "Variables";
            this.cmdVariablesToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVariablesToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdVariablesToggle.UseVisualStyleBackColor = false;
            this.cmdVariablesToggle.Click += new System.EventHandler(this.cmdVariablesToggle_Click);
            // 
            // label42
            // 
            this.label42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(0, 271);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(549, 29);
            this.label42.TabIndex = 4;
            this.label42.Text = "Suggestions: Use \'variable\' names that are unique in the config. e.g. %SomeValue%" +
    ". Be careful when using quotes/doublequotes or any other characters that are \'sp" +
    "ecial\' in XML.";
            // 
            // panelSecuritySettings
            // 
            this.panelSecuritySettings.Controls.Add(this.groupBox2);
            this.panelSecuritySettings.Controls.Add(this.cmdSecuritySettingsToggle);
            this.panelSecuritySettings.Location = new System.Drawing.Point(3, 666);
            this.panelSecuritySettings.Name = "panelSecuritySettings";
            this.panelSecuritySettings.Size = new System.Drawing.Size(549, 289);
            this.panelSecuritySettings.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmdRemoveUserNameFromCache);
            this.groupBox2.Controls.Add(this.cmdAddUserNameToCache);
            this.groupBox2.Controls.Add(this.lvwUserNameCache);
            this.groupBox2.Controls.Add(this.txtMasterKey);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmdSelectMasterKeyFile);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMasterKeyFilePath);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(549, 256);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(398, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "The list below contains user names used by the collector hosts in this monitor pa" +
    "ck.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(404, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Application Master key file/value will be used if the following values are not sp" +
    "ecified";
            // 
            // cmdRemoveUserNameFromCache
            // 
            this.cmdRemoveUserNameFromCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoveUserNameFromCache.Enabled = false;
            this.cmdRemoveUserNameFromCache.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdRemoveUserNameFromCache.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdRemoveUserNameFromCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemoveUserNameFromCache.Font = new System.Drawing.Font("Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdRemoveUserNameFromCache.Location = new System.Drawing.Point(501, 154);
            this.cmdRemoveUserNameFromCache.Name = "cmdRemoveUserNameFromCache";
            this.cmdRemoveUserNameFromCache.Size = new System.Drawing.Size(42, 23);
            this.cmdRemoveUserNameFromCache.TabIndex = 10;
            this.cmdRemoveUserNameFromCache.Text = "Ä";
            this.cmdRemoveUserNameFromCache.UseVisualStyleBackColor = true;
            this.cmdRemoveUserNameFromCache.Click += new System.EventHandler(this.cmdRemoveUserNameFromCache_Click);
            // 
            // cmdAddUserNameToCache
            // 
            this.cmdAddUserNameToCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddUserNameToCache.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdAddUserNameToCache.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdAddUserNameToCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddUserNameToCache.Font = new System.Drawing.Font("Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdAddUserNameToCache.Location = new System.Drawing.Point(501, 125);
            this.cmdAddUserNameToCache.Name = "cmdAddUserNameToCache";
            this.cmdAddUserNameToCache.Size = new System.Drawing.Size(42, 23);
            this.cmdAddUserNameToCache.TabIndex = 9;
            this.cmdAddUserNameToCache.Text = "¬";
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
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwUserNameCache.ContextMenuStrip = this.userCacheContextMenuStrip;
            this.lvwUserNameCache.FullRowSelect = true;
            this.lvwUserNameCache.HideSelection = false;
            this.lvwUserNameCache.Location = new System.Drawing.Point(9, 107);
            this.lvwUserNameCache.Name = "lvwUserNameCache";
            this.lvwUserNameCache.Size = new System.Drawing.Size(486, 143);
            this.lvwUserNameCache.SmallImageList = this.userCacheImageList;
            this.lvwUserNameCache.TabIndex = 8;
            this.lvwUserNameCache.UseCompatibleStateImageBehavior = false;
            this.lvwUserNameCache.View = System.Windows.Forms.View.Details;
            this.lvwUserNameCache.SelectedIndexChanged += new System.EventHandler(this.lvwUserNameCache_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User name";
            this.columnHeader1.Width = 316;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "In Cache";
            this.columnHeader2.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Decryptable";
            this.columnHeader3.Width = 82;
            // 
            // userCacheContextMenuStrip
            // 
            this.userCacheContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPwdToolStripMenuItem,
            this.removeUserToolStripMenuItem,
            this.toolStripSeparator2,
            this.refreshToolStripMenuItem});
            this.userCacheContextMenuStrip.Name = "contextMenuStrip1";
            this.userCacheContextMenuStrip.Size = new System.Drawing.Size(230, 76);
            // 
            // setPwdToolStripMenuItem
            // 
            this.setPwdToolStripMenuItem.Name = "setPwdToolStripMenuItem";
            this.setPwdToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.setPwdToolStripMenuItem.Text = "Set/Add account && password";
            this.setPwdToolStripMenuItem.Click += new System.EventHandler(this.cmdAddUserNameToCache_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Enabled = false;
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.removeUserToolStripMenuItem.Text = "Remove";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.cmdRemoveUserNameFromCache_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // userCacheImageList
            // 
            this.userCacheImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("userCacheImageList.ImageStream")));
            this.userCacheImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.userCacheImageList.Images.SetKeyName(0, "125_31.ico");
            // 
            // txtMasterKey
            // 
            this.txtMasterKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMasterKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasterKey.Location = new System.Drawing.Point(131, 36);
            this.txtMasterKey.Name = "txtMasterKey";
            this.txtMasterKey.Size = new System.Drawing.Size(364, 20);
            this.txtMasterKey.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(17, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Master key";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Credential cache (Monitor pack)";
            // 
            // cmdSelectMasterKeyFile
            // 
            this.cmdSelectMasterKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectMasterKeyFile.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdSelectMasterKeyFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdSelectMasterKeyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSelectMasterKeyFile.Location = new System.Drawing.Point(501, 63);
            this.cmdSelectMasterKeyFile.Name = "cmdSelectMasterKeyFile";
            this.cmdSelectMasterKeyFile.Size = new System.Drawing.Size(42, 23);
            this.cmdSelectMasterKeyFile.TabIndex = 6;
            this.cmdSelectMasterKeyFile.Text = "- - -";
            this.cmdSelectMasterKeyFile.UseVisualStyleBackColor = true;
            this.cmdSelectMasterKeyFile.Click += new System.EventHandler(this.cmdSelectMasterKeyFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Master key file";
            // 
            // txtMasterKeyFilePath
            // 
            this.txtMasterKeyFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMasterKeyFilePath.Location = new System.Drawing.Point(131, 65);
            this.txtMasterKeyFilePath.Name = "txtMasterKeyFilePath";
            this.txtMasterKeyFilePath.Size = new System.Drawing.Size(364, 20);
            this.txtMasterKeyFilePath.TabIndex = 5;
            // 
            // cmdSecuritySettingsToggle
            // 
            this.cmdSecuritySettingsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdSecuritySettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdSecuritySettingsToggle.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdSecuritySettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSecuritySettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdSecuritySettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSecuritySettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdSecuritySettingsToggle.Name = "cmdSecuritySettingsToggle";
            this.cmdSecuritySettingsToggle.Size = new System.Drawing.Size(549, 33);
            this.cmdSecuritySettingsToggle.TabIndex = 0;
            this.cmdSecuritySettingsToggle.Text = "Security Settings";
            this.cmdSecuritySettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSecuritySettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSecuritySettingsToggle.UseVisualStyleBackColor = false;
            this.cmdSecuritySettingsToggle.Click += new System.EventHandler(this.cmdSecuritySettingsToggle_Click);
            // 
            // panelLoggingSettings
            // 
            this.panelLoggingSettings.Controls.Add(this.panel4);
            this.panelLoggingSettings.Controls.Add(this.cmdLoggingSettingsToggle);
            this.panelLoggingSettings.Controls.Add(this.metricsExportGroupBox);
            this.panelLoggingSettings.Location = new System.Drawing.Point(3, 961);
            this.panelLoggingSettings.Name = "panelLoggingSettings";
            this.panelLoggingSettings.Size = new System.Drawing.Size(549, 350);
            this.panelLoggingSettings.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkLoggingEnabled);
            this.panel4.Controls.Add(this.txtLoggingPath);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtLoggingCollectorCategories);
            this.panel4.Controls.Add(this.cmdLoggingPath);
            this.panel4.Controls.Add(this.nudKeepLogFilesXDays);
            this.panel4.Controls.Add(this.chkLoggingCollectorEvents);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.chkLoggingNotifierEvents);
            this.panel4.Controls.Add(this.chkLoggingServiceWindowEvents);
            this.panel4.Controls.Add(this.chkLoggingAlertsRaised);
            this.panel4.Controls.Add(this.chkLoggingPollingOverridesTriggered);
            this.panel4.Controls.Add(this.chkLoggingCorrectiveScriptRun);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 217);
            this.panel4.TabIndex = 16;
            // 
            // chkLoggingEnabled
            // 
            this.chkLoggingEnabled.AutoSize = true;
            this.chkLoggingEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoggingEnabled.Location = new System.Drawing.Point(8, 5);
            this.chkLoggingEnabled.Name = "chkLoggingEnabled";
            this.chkLoggingEnabled.Size = new System.Drawing.Size(112, 17);
            this.chkLoggingEnabled.TabIndex = 1;
            this.chkLoggingEnabled.Text = "Logging is enabled";
            this.chkLoggingEnabled.UseVisualStyleBackColor = true;
            // 
            // txtLoggingPath
            // 
            this.txtLoggingPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoggingPath.Location = new System.Drawing.Point(132, 32);
            this.txtLoggingPath.Name = "txtLoggingPath";
            this.txtLoggingPath.Size = new System.Drawing.Size(363, 20);
            this.txtLoggingPath.TabIndex = 5;
            this.txtLoggingPath.DoubleClick += new System.EventHandler(this.txtLoggingPath_DoubleClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(203, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Only for Collector categories (one per line)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Log file path";
            // 
            // txtLoggingCollectorCategories
            // 
            this.txtLoggingCollectorCategories.Location = new System.Drawing.Point(34, 98);
            this.txtLoggingCollectorCategories.Multiline = true;
            this.txtLoggingCollectorCategories.Name = "txtLoggingCollectorCategories";
            this.txtLoggingCollectorCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLoggingCollectorCategories.Size = new System.Drawing.Size(203, 104);
            this.txtLoggingCollectorCategories.TabIndex = 9;
            // 
            // cmdLoggingPath
            // 
            this.cmdLoggingPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoggingPath.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdLoggingPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdLoggingPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLoggingPath.Location = new System.Drawing.Point(501, 30);
            this.cmdLoggingPath.Name = "cmdLoggingPath";
            this.cmdLoggingPath.Size = new System.Drawing.Size(42, 23);
            this.cmdLoggingPath.TabIndex = 6;
            this.cmdLoggingPath.Text = "- - -";
            this.cmdLoggingPath.UseVisualStyleBackColor = true;
            this.cmdLoggingPath.Click += new System.EventHandler(this.cmdLoggingPath_Click);
            // 
            // nudKeepLogFilesXDays
            // 
            this.nudKeepLogFilesXDays.Location = new System.Drawing.Point(243, 4);
            this.nudKeepLogFilesXDays.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudKeepLogFilesXDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudKeepLogFilesXDays.Name = "nudKeepLogFilesXDays";
            this.nudKeepLogFilesXDays.Size = new System.Drawing.Size(61, 20);
            this.nudKeepLogFilesXDays.TabIndex = 3;
            this.nudKeepLogFilesXDays.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // chkLoggingCollectorEvents
            // 
            this.chkLoggingCollectorEvents.AutoSize = true;
            this.chkLoggingCollectorEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoggingCollectorEvents.Location = new System.Drawing.Point(34, 61);
            this.chkLoggingCollectorEvents.Name = "chkLoggingCollectorEvents";
            this.chkLoggingCollectorEvents.Size = new System.Drawing.Size(100, 17);
            this.chkLoggingCollectorEvents.TabIndex = 7;
            this.chkLoggingCollectorEvents.Text = "Collector Events";
            this.chkLoggingCollectorEvents.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(129, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Days to keep log files";
            // 
            // chkLoggingNotifierEvents
            // 
            this.chkLoggingNotifierEvents.AutoSize = true;
            this.chkLoggingNotifierEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoggingNotifierEvents.Location = new System.Drawing.Point(250, 61);
            this.chkLoggingNotifierEvents.Name = "chkLoggingNotifierEvents";
            this.chkLoggingNotifierEvents.Size = new System.Drawing.Size(92, 17);
            this.chkLoggingNotifierEvents.TabIndex = 10;
            this.chkLoggingNotifierEvents.Text = "Notifier Events";
            this.chkLoggingNotifierEvents.UseVisualStyleBackColor = true;
            // 
            // chkLoggingServiceWindowEvents
            // 
            this.chkLoggingServiceWindowEvents.AutoSize = true;
            this.chkLoggingServiceWindowEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoggingServiceWindowEvents.Location = new System.Drawing.Point(250, 153);
            this.chkLoggingServiceWindowEvents.Name = "chkLoggingServiceWindowEvents";
            this.chkLoggingServiceWindowEvents.Size = new System.Drawing.Size(139, 17);
            this.chkLoggingServiceWindowEvents.TabIndex = 14;
            this.chkLoggingServiceWindowEvents.Text = "Service windows Events";
            this.chkLoggingServiceWindowEvents.UseVisualStyleBackColor = true;
            // 
            // chkLoggingAlertsRaised
            // 
            this.chkLoggingAlertsRaised.AutoSize = true;
            this.chkLoggingAlertsRaised.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoggingAlertsRaised.Location = new System.Drawing.Point(250, 84);
            this.chkLoggingAlertsRaised.Name = "chkLoggingAlertsRaised";
            this.chkLoggingAlertsRaised.Size = new System.Drawing.Size(80, 17);
            this.chkLoggingAlertsRaised.TabIndex = 11;
            this.chkLoggingAlertsRaised.Text = "Alert Events";
            this.chkLoggingAlertsRaised.UseVisualStyleBackColor = true;
            // 
            // chkLoggingPollingOverridesTriggered
            // 
            this.chkLoggingPollingOverridesTriggered.AutoSize = true;
            this.chkLoggingPollingOverridesTriggered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoggingPollingOverridesTriggered.Location = new System.Drawing.Point(250, 130);
            this.chkLoggingPollingOverridesTriggered.Name = "chkLoggingPollingOverridesTriggered";
            this.chkLoggingPollingOverridesTriggered.Size = new System.Drawing.Size(180, 17);
            this.chkLoggingPollingOverridesTriggered.TabIndex = 13;
            this.chkLoggingPollingOverridesTriggered.Text = "Polling overrides triggered Events";
            this.chkLoggingPollingOverridesTriggered.UseVisualStyleBackColor = true;
            // 
            // chkLoggingCorrectiveScriptRun
            // 
            this.chkLoggingCorrectiveScriptRun.AutoSize = true;
            this.chkLoggingCorrectiveScriptRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLoggingCorrectiveScriptRun.Location = new System.Drawing.Point(250, 107);
            this.chkLoggingCorrectiveScriptRun.Name = "chkLoggingCorrectiveScriptRun";
            this.chkLoggingCorrectiveScriptRun.Size = new System.Drawing.Size(153, 17);
            this.chkLoggingCorrectiveScriptRun.TabIndex = 12;
            this.chkLoggingCorrectiveScriptRun.Text = "Corrective script run Events";
            this.chkLoggingCorrectiveScriptRun.UseVisualStyleBackColor = true;
            // 
            // cmdLoggingSettingsToggle
            // 
            this.cmdLoggingSettingsToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdLoggingSettingsToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdLoggingSettingsToggle.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdLoggingSettingsToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLoggingSettingsToggle.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            this.cmdLoggingSettingsToggle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoggingSettingsToggle.Location = new System.Drawing.Point(0, 0);
            this.cmdLoggingSettingsToggle.Name = "cmdLoggingSettingsToggle";
            this.cmdLoggingSettingsToggle.Size = new System.Drawing.Size(549, 33);
            this.cmdLoggingSettingsToggle.TabIndex = 0;
            this.cmdLoggingSettingsToggle.Text = "Logging Settings";
            this.cmdLoggingSettingsToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoggingSettingsToggle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdLoggingSettingsToggle.UseVisualStyleBackColor = false;
            this.cmdLoggingSettingsToggle.Click += new System.EventHandler(this.cmdLoggingSettingsToggle_Click);
            // 
            // metricsExportGroupBox
            // 
            this.metricsExportGroupBox.Controls.Add(this.chkCollectorMetricsExportIncludeDisabled);
            this.metricsExportGroupBox.Controls.Add(this.cmdBrowseCollectorMetricsExportPath);
            this.metricsExportGroupBox.Controls.Add(this.label15);
            this.metricsExportGroupBox.Controls.Add(this.txtCollectorMetricsExportPath);
            this.metricsExportGroupBox.Controls.Add(this.chkCollectorMetricsExportToXMLEnabled);
            this.metricsExportGroupBox.Controls.Add(this.chkCollectorMetricsExportToCSVEnabled);
            this.metricsExportGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metricsExportGroupBox.Location = new System.Drawing.Point(0, 250);
            this.metricsExportGroupBox.Name = "metricsExportGroupBox";
            this.metricsExportGroupBox.Size = new System.Drawing.Size(549, 100);
            this.metricsExportGroupBox.TabIndex = 15;
            this.metricsExportGroupBox.TabStop = false;
            this.metricsExportGroupBox.Text = "Collector Metrics Exports (only applies to master refresh)";
            // 
            // chkCollectorMetricsExportIncludeDisabled
            // 
            this.chkCollectorMetricsExportIncludeDisabled.AutoSize = true;
            this.chkCollectorMetricsExportIncludeDisabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCollectorMetricsExportIncludeDisabled.Location = new System.Drawing.Point(21, 70);
            this.chkCollectorMetricsExportIncludeDisabled.Name = "chkCollectorMetricsExportIncludeDisabled";
            this.chkCollectorMetricsExportIncludeDisabled.Size = new System.Drawing.Size(233, 17);
            this.chkCollectorMetricsExportIncludeDisabled.TabIndex = 10;
            this.chkCollectorMetricsExportIncludeDisabled.Text = "Include None/Disabled (only applies to CSV)";
            this.chkCollectorMetricsExportIncludeDisabled.UseVisualStyleBackColor = true;
            // 
            // cmdBrowseCollectorMetricsExportPath
            // 
            this.cmdBrowseCollectorMetricsExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseCollectorMetricsExportPath.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdBrowseCollectorMetricsExportPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdBrowseCollectorMetricsExportPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseCollectorMetricsExportPath.Location = new System.Drawing.Point(504, 42);
            this.cmdBrowseCollectorMetricsExportPath.Name = "cmdBrowseCollectorMetricsExportPath";
            this.cmdBrowseCollectorMetricsExportPath.Size = new System.Drawing.Size(42, 23);
            this.cmdBrowseCollectorMetricsExportPath.TabIndex = 9;
            this.cmdBrowseCollectorMetricsExportPath.Text = "- - -";
            this.cmdBrowseCollectorMetricsExportPath.UseVisualStyleBackColor = true;
            this.cmdBrowseCollectorMetricsExportPath.Click += new System.EventHandler(this.cmdBrowseCollectorMetricsExportPath_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Export path";
            // 
            // txtCollectorMetricsExportPath
            // 
            this.txtCollectorMetricsExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCollectorMetricsExportPath.Location = new System.Drawing.Point(133, 44);
            this.txtCollectorMetricsExportPath.Name = "txtCollectorMetricsExportPath";
            this.txtCollectorMetricsExportPath.Size = new System.Drawing.Size(365, 20);
            this.txtCollectorMetricsExportPath.TabIndex = 8;
            // 
            // chkCollectorMetricsExportToXMLEnabled
            // 
            this.chkCollectorMetricsExportToXMLEnabled.AutoSize = true;
            this.chkCollectorMetricsExportToXMLEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCollectorMetricsExportToXMLEnabled.Location = new System.Drawing.Point(124, 19);
            this.chkCollectorMetricsExportToXMLEnabled.Name = "chkCollectorMetricsExportToXMLEnabled";
            this.chkCollectorMetricsExportToXMLEnabled.Size = new System.Drawing.Size(90, 17);
            this.chkCollectorMetricsExportToXMLEnabled.TabIndex = 1;
            this.chkCollectorMetricsExportToXMLEnabled.Text = "Export to XML";
            this.chkCollectorMetricsExportToXMLEnabled.UseVisualStyleBackColor = true;
            // 
            // chkCollectorMetricsExportToCSVEnabled
            // 
            this.chkCollectorMetricsExportToCSVEnabled.AutoSize = true;
            this.chkCollectorMetricsExportToCSVEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCollectorMetricsExportToCSVEnabled.Location = new System.Drawing.Point(21, 19);
            this.chkCollectorMetricsExportToCSVEnabled.Name = "chkCollectorMetricsExportToCSVEnabled";
            this.chkCollectorMetricsExportToCSVEnabled.Size = new System.Drawing.Size(89, 17);
            this.chkCollectorMetricsExportToCSVEnabled.TabIndex = 0;
            this.chkCollectorMetricsExportToCSVEnabled.Text = "Export to CSV";
            this.chkCollectorMetricsExportToCSVEnabled.UseVisualStyleBackColor = true;
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(12, 636);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(86, 13);
            this.llblRawEdit.TabIndex = 3;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW config";
            this.llblRawEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRawEdit_LinkClicked);
            // 
            // fbdLogging
            // 
            this.fbdLogging.Description = "Select logging directory";
            // 
            // qmmxmlOpenFileDialog
            // 
            this.qmmxmlOpenFileDialog.CheckFileExists = false;
            this.qmmxmlOpenFileDialog.DefaultExt = "qmmxml";
            this.qmmxmlOpenFileDialog.Filter = "QuickMon master key files|*.qmmxml";
            this.qmmxmlOpenFileDialog.Title = "Select QuickMon master key file";
            // 
            // llblSaveCollectorHistoryNow
            // 
            this.llblSaveCollectorHistoryNow.AutoSize = true;
            this.llblSaveCollectorHistoryNow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblSaveCollectorHistoryNow.Location = new System.Drawing.Point(137, 61);
            this.llblSaveCollectorHistoryNow.Name = "llblSaveCollectorHistoryNow";
            this.llblSaveCollectorHistoryNow.Size = new System.Drawing.Size(88, 13);
            this.llblSaveCollectorHistoryNow.TabIndex = 5;
            this.llblSaveCollectorHistoryNow.TabStop = true;
            this.llblSaveCollectorHistoryNow.Text = "Save history now";
            this.llblSaveCollectorHistoryNow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSaveCollectorHistoryNow_LinkClicked);
            // 
            // llblRestoreCollectorHistoryNow
            // 
            this.llblRestoreCollectorHistoryNow.AutoSize = true;
            this.llblRestoreCollectorHistoryNow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRestoreCollectorHistoryNow.Location = new System.Drawing.Point(242, 61);
            this.llblRestoreCollectorHistoryNow.Name = "llblRestoreCollectorHistoryNow";
            this.llblRestoreCollectorHistoryNow.Size = new System.Drawing.Size(100, 13);
            this.llblRestoreCollectorHistoryNow.TabIndex = 6;
            this.llblRestoreCollectorHistoryNow.TabStop = true;
            this.llblRestoreCollectorHistoryNow.Text = "Restore history now";
            this.llblRestoreCollectorHistoryNow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRestoreCollectorHistoryNow_LinkClicked);
            // 
            // MonitorPackEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuickMon.Properties.Resources.QuickMon5Background3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 666);
            this.Controls.Add(this.llblRawEdit);
            this.Controls.Add(this.flowLayoutPanelSettings);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "MonitorPackEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor Pack Editor";
            this.Load += new System.EventHandler(this.MonitorPackEditor_Load);
            this.Shown += new System.EventHandler(this.MonitorPackEditor_Shown);
            this.ResizeEnd += new System.EventHandler(this.MonitorPackEditor_ResizeEnd);
            this.flowLayoutPanelSettings.ResumeLayout(false);
            this.panelGeneralSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).EndInit();
            this.panelAgentSettings.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.exportHistoryContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collectorStateHistorySizeNumericUpDown)).EndInit();
            this.panelVariables.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStripVariables.ResumeLayout(false);
            this.toolStripVariables.PerformLayout();
            this.panelVarEdit.ResumeLayout(false);
            this.panelVarEdit.PerformLayout();
            this.panelSecuritySettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.userCacheContextMenuStrip.ResumeLayout(false);
            this.panelLoggingSettings.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepLogFilesXDays)).EndInit();
            this.metricsExportGroupBox.ResumeLayout(false);
            this.metricsExportGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSettings;
        private System.Windows.Forms.Panel panelGeneralSettings;
        private System.Windows.Forms.Button cmdGeneralSettingsToggle;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown freqSecNumericUpDown;
        private System.Windows.Forms.Panel panelAgentSettings;
        private System.Windows.Forms.NumericUpDown collectorStateHistorySizeNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCorrectiveScripts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdAgentSettingsToggle;
        private System.Windows.Forms.Panel panelVariables;
        private System.Windows.Forms.ToolStrip toolStripVariables;
        private System.Windows.Forms.ToolStripButton addConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton moveUpConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownConfigVarToolStripButton;
        private System.Windows.Forms.Button cmdVariablesToggle;
        private System.Windows.Forms.Panel panelSecuritySettings;
        private System.Windows.Forms.Button cmdSecuritySettingsToggle;
        private ListViewEx lvwConfigVars;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Panel panelVarEdit;
        private System.Windows.Forms.TextBox txtConfigVarSearchFor;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtConfigVarReplaceByValue;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Panel panelLoggingSettings;
        private System.Windows.Forms.Button cmdLoggingSettingsToggle;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lblMonitorPackPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdRemoveUserNameFromCache;
        private System.Windows.Forms.Button cmdAddUserNameToCache;
        private ListViewEx lvwUserNameCache;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtMasterKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdSelectMasterKeyFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMasterKeyFilePath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLoggingCollectorCategories;
        private System.Windows.Forms.NumericUpDown nudKeepLogFilesXDays;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkLoggingServiceWindowEvents;
        private System.Windows.Forms.CheckBox chkLoggingPollingOverridesTriggered;
        private System.Windows.Forms.CheckBox chkLoggingCorrectiveScriptRun;
        private System.Windows.Forms.CheckBox chkLoggingAlertsRaised;
        private System.Windows.Forms.CheckBox chkLoggingNotifierEvents;
        private System.Windows.Forms.CheckBox chkLoggingCollectorEvents;
        private System.Windows.Forms.CheckBox chkLoggingEnabled;
        private System.Windows.Forms.Button cmdLoggingPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLoggingPath;
        private System.Windows.Forms.ContextMenuStrip userCacheContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem setPwdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbdLogging;
        private System.Windows.Forms.ImageList userCacheImageList;
        private System.Windows.Forms.OpenFileDialog qmmxmlOpenFileDialog;
        private System.Windows.Forms.LinkLabel llblExpandConfigVarSection;
        private System.Windows.Forms.ContextMenuStrip exportHistoryContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exportToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clipboardExportAsCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asXMLToolStripMenuItem;
        private System.Windows.Forms.GroupBox metricsExportGroupBox;
        private System.Windows.Forms.Button cmdBrowseCollectorMetricsExportPath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCollectorMetricsExportPath;
        private System.Windows.Forms.CheckBox chkCollectorMetricsExportToXMLEnabled;
        private System.Windows.Forms.CheckBox chkCollectorMetricsExportToCSVEnabled;
        private System.Windows.Forms.CheckBox chkCollectorMetricsExportIncludeDisabled;
        private System.Windows.Forms.CheckBox chkEnableStickyMainWindowLocation;
        private System.Windows.Forms.ComboBox cboChildCheckBehaviour;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.CheckBox chkCollectorChildCheckBehaviourOverride;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkPersistCollectorHistory;
        private System.Windows.Forms.LinkLabel llblRestoreCollectorHistoryNow;
        private System.Windows.Forms.LinkLabel llblSaveCollectorHistoryNow;
    }
}