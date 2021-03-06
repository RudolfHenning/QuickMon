﻿namespace QuickMon
{
    partial class EditEventLogEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEventLogEntry));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.cboLog = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdLoadEventLogs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkInfo = new System.Windows.Forms.CheckBox();
            this.chkWarn = new System.Windows.Forms.CheckBox();
            this.chkErr = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lvwSources = new System.Windows.Forms.ListView();
            this.contextMenuStripSourceList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdEditEventIds = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEventIds = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optTextContains = new System.Windows.Forms.RadioButton();
            this.optTextStartWith = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownWithinLastXEntries = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownWarning = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownError = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWithLastMinutes = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSourceQuickFind = new System.Windows.Forms.TextBox();
            this.contextMenuStripQuickFind = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.containsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSourceCount = new System.Windows.Forms.Label();
            this.timerQuickFind = new System.Windows.Forms.Timer(this.components);
            this.timerSourcesSelected = new System.Windows.Forms.Timer(this.components);
            this.lblSrcSel = new System.Windows.Forms.Label();
            this.pictureBoxSecWarning = new System.Windows.Forms.PictureBox();
            this.lblSecWarning = new System.Windows.Forms.Label();
            this.contextMenuStripSourceList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithinLastXEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithLastMinutes)).BeginInit();
            this.contextMenuStripQuickFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(397, 377);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 28;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(316, 377);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 27;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Computer";
            // 
            // txtComputer
            // 
            this.txtComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputer.Location = new System.Drawing.Point(97, 12);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(327, 20);
            this.txtComputer.TabIndex = 1;
            this.txtComputer.TextChanged += new System.EventHandler(this.txtComputer_TextChanged);
            // 
            // cboLog
            // 
            this.cboLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLog.FormattingEnabled = true;
            this.cboLog.Location = new System.Drawing.Point(97, 38);
            this.cboLog.Name = "cboLog";
            this.cboLog.Size = new System.Drawing.Size(375, 21);
            this.cboLog.TabIndex = 4;
            this.cboLog.SelectedIndexChanged += new System.EventHandler(this.cboLog_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Event log";
            // 
            // cmdLoadEventLogs
            // 
            this.cmdLoadEventLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadEventLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLoadEventLogs.Location = new System.Drawing.Point(430, 10);
            this.cmdLoadEventLogs.Name = "cmdLoadEventLogs";
            this.cmdLoadEventLogs.Size = new System.Drawing.Size(42, 23);
            this.cmdLoadEventLogs.TabIndex = 2;
            this.cmdLoadEventLogs.Text = "Load";
            this.cmdLoadEventLogs.UseVisualStyleBackColor = true;
            this.cmdLoadEventLogs.Click += new System.EventHandler(this.cmdLoadEventLogs_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type";
            // 
            // chkInfo
            // 
            this.chkInfo.AutoSize = true;
            this.chkInfo.Checked = true;
            this.chkInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkInfo.Location = new System.Drawing.Point(97, 65);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.Size = new System.Drawing.Size(77, 17);
            this.chkInfo.TabIndex = 6;
            this.chkInfo.Text = "Information";
            this.chkInfo.UseVisualStyleBackColor = true;
            // 
            // chkWarn
            // 
            this.chkWarn.AutoSize = true;
            this.chkWarn.Checked = true;
            this.chkWarn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWarn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkWarn.Location = new System.Drawing.Point(181, 65);
            this.chkWarn.Name = "chkWarn";
            this.chkWarn.Size = new System.Drawing.Size(65, 17);
            this.chkWarn.TabIndex = 7;
            this.chkWarn.Text = "Warning";
            this.chkWarn.UseVisualStyleBackColor = true;
            // 
            // chkErr
            // 
            this.chkErr.AutoSize = true;
            this.chkErr.Checked = true;
            this.chkErr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkErr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkErr.Location = new System.Drawing.Point(260, 65);
            this.chkErr.Name = "chkErr";
            this.chkErr.Size = new System.Drawing.Size(47, 17);
            this.chkErr.TabIndex = 8;
            this.chkErr.Text = "Error";
            this.chkErr.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Source(s)";
            // 
            // lvwSources
            // 
            this.lvwSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSources.CheckBoxes = true;
            this.lvwSources.ContextMenuStrip = this.contextMenuStripSourceList;
            this.lvwSources.HideSelection = false;
            this.lvwSources.Location = new System.Drawing.Point(97, 88);
            this.lvwSources.Name = "lvwSources";
            this.lvwSources.Size = new System.Drawing.Size(375, 102);
            this.lvwSources.TabIndex = 10;
            this.lvwSources.UseCompatibleStateImageBehavior = false;
            this.lvwSources.View = System.Windows.Forms.View.List;
            this.lvwSources.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwSources_ItemChecked);
            this.lvwSources.SelectedIndexChanged += new System.EventHandler(this.lvwSources_SelectedIndexChanged);
            // 
            // contextMenuStripSourceList
            // 
            this.contextMenuStripSourceList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem1,
            this.checkSelectedToolStripMenuItem,
            this.uncheckSelectedToolStripMenuItem});
            this.contextMenuStripSourceList.Name = "contextMenuStripSourceList";
            this.contextMenuStripSourceList.Size = new System.Drawing.Size(184, 76);
            // 
            // allToolStripMenuItem1
            // 
            this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
            this.allToolStripMenuItem1.Size = new System.Drawing.Size(183, 24);
            this.allToolStripMenuItem1.Text = "All";
            this.allToolStripMenuItem1.Click += new System.EventHandler(this.allToolStripMenuItem1_Click);
            // 
            // checkSelectedToolStripMenuItem
            // 
            this.checkSelectedToolStripMenuItem.Name = "checkSelectedToolStripMenuItem";
            this.checkSelectedToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.checkSelectedToolStripMenuItem.Text = "Check selected";
            this.checkSelectedToolStripMenuItem.Click += new System.EventHandler(this.checkSelectedToolStripMenuItem_Click);
            // 
            // uncheckSelectedToolStripMenuItem
            // 
            this.uncheckSelectedToolStripMenuItem.Name = "uncheckSelectedToolStripMenuItem";
            this.uncheckSelectedToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.uncheckSelectedToolStripMenuItem.Text = "Uncheck selected";
            this.uncheckSelectedToolStripMenuItem.Click += new System.EventHandler(this.uncheckSelectedToolStripMenuItem_Click);
            // 
            // cmdEditEventIds
            // 
            this.cmdEditEventIds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditEventIds.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditEventIds.Location = new System.Drawing.Point(430, 214);
            this.cmdEditEventIds.Name = "cmdEditEventIds";
            this.cmdEditEventIds.Size = new System.Drawing.Size(42, 23);
            this.cmdEditEventIds.TabIndex = 16;
            this.cmdEditEventIds.Text = "- - -";
            this.cmdEditEventIds.UseVisualStyleBackColor = true;
            this.cmdEditEventIds.Click += new System.EventHandler(this.cmdEditEventIds_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Event Id(s)";
            // 
            // txtEventIds
            // 
            this.txtEventIds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventIds.Location = new System.Drawing.Point(97, 216);
            this.txtEventIds.Name = "txtEventIds";
            this.txtEventIds.Size = new System.Drawing.Size(327, 20);
            this.txtEventIds.TabIndex = 15;
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(6, 38);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(445, 20);
            this.txtText.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.optTextContains);
            this.groupBox1.Controls.Add(this.optTextStartWith);
            this.groupBox1.Controls.Add(this.txtText);
            this.groupBox1.Location = new System.Drawing.Point(15, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 65);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text";
            // 
            // optTextContains
            // 
            this.optTextContains.AutoSize = true;
            this.optTextContains.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optTextContains.Location = new System.Drawing.Point(99, 17);
            this.optTextContains.Name = "optTextContains";
            this.optTextContains.Size = new System.Drawing.Size(66, 17);
            this.optTextContains.TabIndex = 1;
            this.optTextContains.Text = "Contains";
            this.optTextContains.UseVisualStyleBackColor = true;
            // 
            // optTextStartWith
            // 
            this.optTextStartWith.AutoSize = true;
            this.optTextStartWith.Checked = true;
            this.optTextStartWith.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optTextStartWith.Location = new System.Drawing.Point(16, 17);
            this.optTextStartWith.Name = "optTextStartWith";
            this.optTextStartWith.Size = new System.Drawing.Size(74, 17);
            this.optTextStartWith.TabIndex = 0;
            this.optTextStartWith.TabStop = true;
            this.optTextStartWith.Text = "Starts with";
            this.optTextStartWith.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Within last";
            // 
            // numericUpDownWithinLastXEntries
            // 
            this.numericUpDownWithinLastXEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownWithinLastXEntries.Location = new System.Drawing.Point(114, 314);
            this.numericUpDownWithinLastXEntries.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownWithinLastXEntries.Name = "numericUpDownWithinLastXEntries";
            this.numericUpDownWithinLastXEntries.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownWithinLastXEntries.TabIndex = 19;
            this.numericUpDownWithinLastXEntries.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Error count";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Warning count";
            // 
            // numericUpDownWarning
            // 
            this.numericUpDownWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownWarning.Location = new System.Drawing.Point(114, 340);
            this.numericUpDownWarning.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownWarning.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWarning.Name = "numericUpDownWarning";
            this.numericUpDownWarning.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownWarning.TabIndex = 24;
            this.numericUpDownWarning.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWarning.ValueChanged += new System.EventHandler(this.txtComputer_TextChanged);
            // 
            // numericUpDownError
            // 
            this.numericUpDownError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownError.Location = new System.Drawing.Point(258, 340);
            this.numericUpDownError.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownError.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownError.Name = "numericUpDownError";
            this.numericUpDownError.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownError.TabIndex = 26;
            this.numericUpDownError.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownError.ValueChanged += new System.EventHandler(this.txtComputer_TextChanged);
            // 
            // numericUpDownWithLastMinutes
            // 
            this.numericUpDownWithLastMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownWithLastMinutes.Location = new System.Drawing.Point(258, 314);
            this.numericUpDownWithLastMinutes.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownWithLastMinutes.Name = "numericUpDownWithLastMinutes";
            this.numericUpDownWithLastMinutes.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownWithLastMinutes.TabIndex = 21;
            this.numericUpDownWithLastMinutes.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "entries and";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(334, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Minute(s)";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(94, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Quick find";
            // 
            // txtSourceQuickFind
            // 
            this.txtSourceQuickFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceQuickFind.ContextMenuStrip = this.contextMenuStripQuickFind;
            this.txtSourceQuickFind.Location = new System.Drawing.Point(158, 191);
            this.txtSourceQuickFind.Name = "txtSourceQuickFind";
            this.txtSourceQuickFind.Size = new System.Drawing.Size(314, 20);
            this.txtSourceQuickFind.TabIndex = 13;
            this.txtSourceQuickFind.TextChanged += new System.EventHandler(this.txtSourceQuickFind_TextChanged);
            // 
            // contextMenuStripQuickFind
            // 
            this.contextMenuStripQuickFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.containsToolStripMenuItem,
            this.allToolStripMenuItem});
            this.contextMenuStripQuickFind.Name = "contextMenuStripQuickFind";
            this.contextMenuStripQuickFind.Size = new System.Drawing.Size(133, 52);
            // 
            // containsToolStripMenuItem
            // 
            this.containsToolStripMenuItem.CheckOnClick = true;
            this.containsToolStripMenuItem.Name = "containsToolStripMenuItem";
            this.containsToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.containsToolStripMenuItem.Text = "Contains";
            this.containsToolStripMenuItem.Click += new System.EventHandler(this.containsToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.CheckOnClick = true;
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // lblSourceCount
            // 
            this.lblSourceCount.AutoSize = true;
            this.lblSourceCount.Location = new System.Drawing.Point(22, 110);
            this.lblSourceCount.Name = "lblSourceCount";
            this.lblSourceCount.Size = new System.Drawing.Size(18, 13);
            this.lblSourceCount.TabIndex = 11;
            this.lblSourceCount.Text = "All";
            // 
            // timerQuickFind
            // 
            this.timerQuickFind.Interval = 200;
            this.timerQuickFind.Tick += new System.EventHandler(this.timerQuickFind_Tick);
            // 
            // timerSourcesSelected
            // 
            this.timerSourcesSelected.Interval = 200;
            this.timerSourcesSelected.Tick += new System.EventHandler(this.timerSourcesSelected_Tick);
            // 
            // lblSrcSel
            // 
            this.lblSrcSel.AutoSize = true;
            this.lblSrcSel.Location = new System.Drawing.Point(22, 135);
            this.lblSrcSel.Name = "lblSrcSel";
            this.lblSrcSel.Size = new System.Drawing.Size(51, 13);
            this.lblSrcSel.TabIndex = 32;
            this.lblSrcSel.Text = "Sel:None";
            // 
            // pictureBoxSecWarning
            // 
            this.pictureBoxSecWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxSecWarning.ErrorImage = global::QuickMon.Properties.Resources.OUTLLIBR_9825;
            this.pictureBoxSecWarning.Image = global::QuickMon.Properties.Resources.OUTLLIBR_9825;
            this.pictureBoxSecWarning.Location = new System.Drawing.Point(8, 374);
            this.pictureBoxSecWarning.Name = "pictureBoxSecWarning";
            this.pictureBoxSecWarning.Size = new System.Drawing.Size(54, 34);
            this.pictureBoxSecWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSecWarning.TabIndex = 33;
            this.pictureBoxSecWarning.TabStop = false;
            // 
            // lblSecWarning
            // 
            this.lblSecWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSecWarning.AutoSize = true;
            this.lblSecWarning.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSecWarning.Location = new System.Drawing.Point(68, 382);
            this.lblSecWarning.Name = "lblSecWarning";
            this.lblSecWarning.Size = new System.Drawing.Size(145, 13);
            this.lblSecWarning.TabIndex = 34;
            this.lblSecWarning.Text = "Warning: Not in Admin mode!";
            // 
            // EditEventLogEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.lblSecWarning);
            this.Controls.Add(this.pictureBoxSecWarning);
            this.Controls.Add(this.lblSrcSel);
            this.Controls.Add(this.lblSourceCount);
            this.Controls.Add(this.txtSourceQuickFind);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownWithLastMinutes);
            this.Controls.Add(this.numericUpDownError);
            this.Controls.Add(this.numericUpDownWarning);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDownWithinLastXEntries);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdEditEventIds);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEventIds);
            this.Controls.Add(this.lvwSources);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkErr);
            this.Controls.Add(this.chkWarn);
            this.Controls.Add(this.chkInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdLoadEventLogs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComputer);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "EditEventLogEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Event Log Entry";
            this.Load += new System.EventHandler(this.EditEventLogEntry_Load);
            this.Shown += new System.EventHandler(this.EditEventLogEntry_Shown);
            this.contextMenuStripSourceList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithinLastXEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithLastMinutes)).EndInit();
            this.contextMenuStripQuickFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.ComboBox cboLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdLoadEventLogs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkInfo;
        private System.Windows.Forms.CheckBox chkWarn;
        private System.Windows.Forms.CheckBox chkErr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvwSources;
        private System.Windows.Forms.Button cmdEditEventIds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEventIds;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optTextContains;
        private System.Windows.Forms.RadioButton optTextStartWith;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownWithinLastXEntries;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownWarning;
        private System.Windows.Forms.NumericUpDown numericUpDownError;
        private System.Windows.Forms.NumericUpDown numericUpDownWithLastMinutes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSourceQuickFind;
        private System.Windows.Forms.Label lblSourceCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripQuickFind;
        private System.Windows.Forms.ToolStripMenuItem containsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.Timer timerQuickFind;
        private System.Windows.Forms.Timer timerSourcesSelected;
        private System.Windows.Forms.Label lblSrcSel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSourceList;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckSelectedToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxSecWarning;
        private System.Windows.Forms.Label lblSecWarning;
    }
}