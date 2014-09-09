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
            this.chkPinToTaskbar = new System.Windows.Forms.CheckBox();
            this.chkPinToStartMenu = new System.Windows.Forms.CheckBox();
            this.chkDesktopShortcut = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPausePollingDuringEditConfig = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkOverridesMonitorPackFrequency = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.freqSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPollingEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkDisplayFullPathForQuickRecentEntries = new System.Windows.Forms.CheckBox();
            this.cmdEditQuickSelectTypeFilters = new System.Windows.Forms.Button();
            this.txtRecentMonitorPackFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // concurrencyLevelNnumericUpDown
            // 
            this.concurrencyLevelNnumericUpDown.Location = new System.Drawing.Point(104, 80);
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
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Concurrency level";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(372, 217);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(291, 217);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkSnapToDesktop
            // 
            this.chkSnapToDesktop.AutoSize = true;
            this.chkSnapToDesktop.Location = new System.Drawing.Point(15, 13);
            this.chkSnapToDesktop.Name = "chkSnapToDesktop";
            this.chkSnapToDesktop.Size = new System.Drawing.Size(131, 17);
            this.chkSnapToDesktop.TabIndex = 0;
            this.chkSnapToDesktop.Text = "Snap to desktop sides";
            this.chkSnapToDesktop.UseVisualStyleBackColor = true;
            // 
            // chkAutosaveChanges
            // 
            this.chkAutosaveChanges.AutoSize = true;
            this.chkAutosaveChanges.Location = new System.Drawing.Point(155, 13);
            this.chkAutosaveChanges.Name = "chkAutosaveChanges";
            this.chkAutosaveChanges.Size = new System.Drawing.Size(118, 17);
            this.chkAutosaveChanges.TabIndex = 1;
            this.chkAutosaveChanges.Text = "Auto save changes";
            this.chkAutosaveChanges.UseVisualStyleBackColor = true;
            // 
            // chkPinToTaskbar
            // 
            this.chkPinToTaskbar.AutoSize = true;
            this.chkPinToTaskbar.Location = new System.Drawing.Point(19, 19);
            this.chkPinToTaskbar.Name = "chkPinToTaskbar";
            this.chkPinToTaskbar.Size = new System.Drawing.Size(95, 17);
            this.chkPinToTaskbar.TabIndex = 0;
            this.chkPinToTaskbar.Text = "Pin to Taskbar";
            this.chkPinToTaskbar.UseVisualStyleBackColor = true;
            this.chkPinToTaskbar.CheckedChanged += new System.EventHandler(this.chkPinToTaskbar_CheckedChanged);
            // 
            // chkPinToStartMenu
            // 
            this.chkPinToStartMenu.AutoSize = true;
            this.chkPinToStartMenu.Location = new System.Drawing.Point(120, 19);
            this.chkPinToStartMenu.Name = "chkPinToStartMenu";
            this.chkPinToStartMenu.Size = new System.Drawing.Size(108, 17);
            this.chkPinToStartMenu.TabIndex = 1;
            this.chkPinToStartMenu.Text = "Pin to Start Menu";
            this.chkPinToStartMenu.UseVisualStyleBackColor = true;
            this.chkPinToStartMenu.CheckedChanged += new System.EventHandler(this.chkPinToStartMenu_CheckedChanged);
            // 
            // chkDesktopShortcut
            // 
            this.chkDesktopShortcut.AutoSize = true;
            this.chkDesktopShortcut.Location = new System.Drawing.Point(234, 19);
            this.chkDesktopShortcut.Name = "chkDesktopShortcut";
            this.chkDesktopShortcut.Size = new System.Drawing.Size(154, 17);
            this.chkDesktopShortcut.TabIndex = 2;
            this.chkDesktopShortcut.Text = "Create shortcut on desktop";
            this.chkDesktopShortcut.UseVisualStyleBackColor = true;
            this.chkDesktopShortcut.CheckedChanged += new System.EventHandler(this.chkDesktopShortcut_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPinToTaskbar);
            this.groupBox1.Controls.Add(this.chkDesktopShortcut);
            this.groupBox1.Controls.Add(this.chkPinToStartMenu);
            this.groupBox1.Location = new System.Drawing.Point(15, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shortcuts";
            // 
            // chkPausePollingDuringEditConfig
            // 
            this.chkPausePollingDuringEditConfig.AutoSize = true;
            this.chkPausePollingDuringEditConfig.Checked = true;
            this.chkPausePollingDuringEditConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPausePollingDuringEditConfig.Location = new System.Drawing.Point(105, 111);
            this.chkPausePollingDuringEditConfig.Name = "chkPausePollingDuringEditConfig";
            this.chkPausePollingDuringEditConfig.Size = new System.Drawing.Size(229, 17);
            this.chkPausePollingDuringEditConfig.TabIndex = 8;
            this.chkPausePollingDuringEditConfig.Text = "Pause polling while editing config of agents";
            this.chkPausePollingDuringEditConfig.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "If Monitor pack has no frequency specified this setting is used.";
            // 
            // chkOverridesMonitorPackFrequency
            // 
            this.chkOverridesMonitorPackFrequency.AutoSize = true;
            this.chkOverridesMonitorPackFrequency.Location = new System.Drawing.Point(205, 35);
            this.chkOverridesMonitorPackFrequency.Name = "chkOverridesMonitorPackFrequency";
            this.chkOverridesMonitorPackFrequency.Size = new System.Drawing.Size(197, 17);
            this.chkOverridesMonitorPackFrequency.TabIndex = 4;
            this.chkOverridesMonitorPackFrequency.Text = "Overrides frequency in Monitor pack";
            this.chkOverridesMonitorPackFrequency.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(sec)";
            // 
            // freqSecNumericUpDown
            // 
            this.freqSecNumericUpDown.Location = new System.Drawing.Point(104, 34);
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
            this.label1.Location = new System.Drawing.Point(6, 36);
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
            this.chkPollingEnabled.Location = new System.Drawing.Point(6, 6);
            this.chkPollingEnabled.Name = "chkPollingEnabled";
            this.chkPollingEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkPollingEnabled.TabIndex = 0;
            this.chkPollingEnabled.Text = "Enabled";
            this.chkPollingEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkDisplayFullPathForQuickRecentEntries);
            this.groupBox4.Controls.Add(this.cmdEditQuickSelectTypeFilters);
            this.groupBox4.Controls.Add(this.txtRecentMonitorPackFilter);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(15, 92);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(412, 78);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Recent Montor pack file list";
            // 
            // chkDisplayFullPathForQuickRecentEntries
            // 
            this.chkDisplayFullPathForQuickRecentEntries.AutoSize = true;
            this.chkDisplayFullPathForQuickRecentEntries.Location = new System.Drawing.Point(14, 45);
            this.chkDisplayFullPathForQuickRecentEntries.Name = "chkDisplayFullPathForQuickRecentEntries";
            this.chkDisplayFullPathForQuickRecentEntries.Size = new System.Drawing.Size(186, 17);
            this.chkDisplayFullPathForQuickRecentEntries.TabIndex = 3;
            this.chkDisplayFullPathForQuickRecentEntries.Text = "Display full path in quick select list";
            this.chkDisplayFullPathForQuickRecentEntries.UseVisualStyleBackColor = true;
            // 
            // cmdEditQuickSelectTypeFilters
            // 
            this.cmdEditQuickSelectTypeFilters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditQuickSelectTypeFilters.Location = new System.Drawing.Point(361, 17);
            this.cmdEditQuickSelectTypeFilters.Name = "cmdEditQuickSelectTypeFilters";
            this.cmdEditQuickSelectTypeFilters.Size = new System.Drawing.Size(42, 23);
            this.cmdEditQuickSelectTypeFilters.TabIndex = 2;
            this.cmdEditQuickSelectTypeFilters.Text = "- - -";
            this.cmdEditQuickSelectTypeFilters.UseVisualStyleBackColor = true;
            this.cmdEditQuickSelectTypeFilters.Click += new System.EventHandler(this.cmdEditQuickSelectTypeFilters_Click);
            // 
            // txtRecentMonitorPackFilter
            // 
            this.txtRecentMonitorPackFilter.Location = new System.Drawing.Point(169, 19);
            this.txtRecentMonitorPackFilter.Name = "txtRecentMonitorPackFilter";
            this.txtRecentMonitorPackFilter.Size = new System.Drawing.Size(186, 20);
            this.txtRecentMonitorPackFilter.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtRecentMonitorPackFilter, "* - All, use ~ for exclude");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quick select Type Filters (csv)";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 206);
            this.tabControl1.TabIndex = 2;
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
            this.tabPage1.Size = new System.Drawing.Size(440, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Polling";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.chkSnapToDesktop);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.chkAutosaveChanges);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application";
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 252);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Settings";
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.concurrencyLevelNnumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqSecNumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown concurrencyLevelNnumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkSnapToDesktop;
        private System.Windows.Forms.CheckBox chkAutosaveChanges;
        private System.Windows.Forms.CheckBox chkPinToTaskbar;
        private System.Windows.Forms.CheckBox chkPinToStartMenu;
        private System.Windows.Forms.CheckBox chkDesktopShortcut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPollingEnabled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown freqSecNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOverridesMonitorPackFrequency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtRecentMonitorPackFilter;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdEditQuickSelectTypeFilters;
        private System.Windows.Forms.CheckBox chkDisplayFullPathForQuickRecentEntries;
        private System.Windows.Forms.CheckBox chkPausePollingDuringEditConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}