﻿namespace QuickMon.Collectors
{
    partial class FileSystemCollectorEditFilterEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSystemCollectorEditFilterEntry));
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownFileAgeMax = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownFileAgeMin = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownSizeErrorIndicator = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownSizeWarningIndicator = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.numericUpDownCountErrorIndicator = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCountWarningIndicator = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContains = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkUseRegEx = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optDirectoryExistOnly = new System.Windows.Forms.RadioButton();
            this.optCheckIfFilesExistOnly = new System.Windows.Forms.RadioButton();
            this.optErrorOnFilesExist = new System.Windows.Forms.RadioButton();
            this.optCounts = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeErrorIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeWarningIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountErrorIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountWarningIndicator)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(399, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "File size - File size in KB must be between min/max to be included. 0 means no li" +
    "mit.";
            // 
            // numericUpDownFileSizeMax
            // 
            this.numericUpDownFileSizeMax.Location = new System.Drawing.Point(241, 190);
            this.numericUpDownFileSizeMax.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownFileSizeMax.Name = "numericUpDownFileSizeMax";
            this.numericUpDownFileSizeMax.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileSizeMax.TabIndex = 17;
            this.numericUpDownFileSizeMax.ValueChanged += new System.EventHandler(this.numericUpDownFileSizeMax_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(186, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Maximum";
            // 
            // numericUpDownFileSizeMin
            // 
            this.numericUpDownFileSizeMin.Location = new System.Drawing.Point(93, 190);
            this.numericUpDownFileSizeMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownFileSizeMin.Name = "numericUpDownFileSizeMin";
            this.numericUpDownFileSizeMin.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileSizeMin.TabIndex = 15;
            this.numericUpDownFileSizeMin.ValueChanged += new System.EventHandler(this.numericUpDownFileSizeMin_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(38, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Minimum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(421, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "File age - File age in minutes must be between min/max to be included. 0 means no" +
    " limit.";
            // 
            // numericUpDownFileAgeMax
            // 
            this.numericUpDownFileAgeMax.Location = new System.Drawing.Point(241, 141);
            this.numericUpDownFileAgeMax.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericUpDownFileAgeMax.Name = "numericUpDownFileAgeMax";
            this.numericUpDownFileAgeMax.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileAgeMax.TabIndex = 12;
            this.numericUpDownFileAgeMax.ValueChanged += new System.EventHandler(this.numericUpDownFileAgeMax_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Maximum";
            // 
            // numericUpDownFileAgeMin
            // 
            this.numericUpDownFileAgeMin.Location = new System.Drawing.Point(93, 141);
            this.numericUpDownFileAgeMin.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericUpDownFileAgeMin.Name = "numericUpDownFileAgeMin";
            this.numericUpDownFileAgeMin.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileAgeMin.TabIndex = 10;
            this.numericUpDownFileAgeMin.ValueChanged += new System.EventHandler(this.numericUpDownFileAgeMin_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Minimum";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(215, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Total Size - Total size of all files before specified condition is set";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(504, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "KB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(355, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "KB";
            // 
            // numericUpDownSizeErrorIndicator
            // 
            this.numericUpDownSizeErrorIndicator.Location = new System.Drawing.Point(438, 89);
            this.numericUpDownSizeErrorIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSizeErrorIndicator.Name = "numericUpDownSizeErrorIndicator";
            this.numericUpDownSizeErrorIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownSizeErrorIndicator.TabIndex = 14;
            this.numericUpDownSizeErrorIndicator.ValueChanged += new System.EventHandler(this.numericUpDownSizeErrorIndicator_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(383, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Errors";
            // 
            // numericUpDownSizeWarningIndicator
            // 
            this.numericUpDownSizeWarningIndicator.Location = new System.Drawing.Point(290, 89);
            this.numericUpDownSizeWarningIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSizeWarningIndicator.Name = "numericUpDownSizeWarningIndicator";
            this.numericUpDownSizeWarningIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownSizeWarningIndicator.TabIndex = 11;
            this.numericUpDownSizeWarningIndicator.ValueChanged += new System.EventHandler(this.numericUpDownSizeWarningIndicator_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(235, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Warnings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(332, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Total Count - Smallest number of files before specified condition is set";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(516, 363);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(435, 363);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // numericUpDownCountErrorIndicator
            // 
            this.numericUpDownCountErrorIndicator.Location = new System.Drawing.Point(438, 39);
            this.numericUpDownCountErrorIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCountErrorIndicator.Name = "numericUpDownCountErrorIndicator";
            this.numericUpDownCountErrorIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownCountErrorIndicator.TabIndex = 8;
            this.numericUpDownCountErrorIndicator.ValueChanged += new System.EventHandler(this.numericUpDownCountErrorIndicator_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Errors";
            // 
            // numericUpDownCountWarningIndicator
            // 
            this.numericUpDownCountWarningIndicator.Location = new System.Drawing.Point(290, 39);
            this.numericUpDownCountWarningIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCountWarningIndicator.Name = "numericUpDownCountWarningIndicator";
            this.numericUpDownCountWarningIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownCountWarningIndicator.TabIndex = 6;
            this.numericUpDownCountWarningIndicator.ValueChanged += new System.EventHandler(this.numericUpDownCountWarningIndicator_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Warnings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "e.g *.*";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(93, 50);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(139, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.Text = "*.*";
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowse.Location = new System.Drawing.Point(504, 22);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(68, 23);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtDirectory.Location = new System.Drawing.Point(93, 24);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(405, 20);
            this.txtDirectory.TabIndex = 1;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory";
            // 
            // txtContains
            // 
            this.txtContains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContains.Location = new System.Drawing.Point(93, 76);
            this.txtContains.Name = "txtContains";
            this.txtContains.Size = new System.Drawing.Size(479, 20);
            this.txtContains.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Contents";
            // 
            // chkUseRegEx
            // 
            this.chkUseRegEx.AutoSize = true;
            this.chkUseRegEx.Location = new System.Drawing.Point(93, 102);
            this.chkUseRegEx.Name = "chkUseRegEx";
            this.chkUseRegEx.Size = new System.Drawing.Size(143, 17);
            this.chkUseRegEx.TabIndex = 7;
            this.chkUseRegEx.Text = "Use Regular expressions";
            this.chkUseRegEx.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDirectory);
            this.groupBox1.Controls.Add(this.chkUseRegEx);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtContains);
            this.groupBox1.Controls.Add(this.cmdBrowse);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.numericUpDownFileSizeMax);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownFileSizeMin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numericUpDownFileAgeMax);
            this.groupBox1.Controls.Add(this.numericUpDownFileAgeMin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File filters";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.optCounts);
            this.groupBox2.Controls.Add(this.optErrorOnFilesExist);
            this.groupBox2.Controls.Add(this.optCheckIfFilesExistOnly);
            this.groupBox2.Controls.Add(this.optDirectoryExistOnly);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.numericUpDownCountWarningIndicator);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDownSizeErrorIndicator);
            this.groupBox2.Controls.Add(this.numericUpDownCountErrorIndicator);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.numericUpDownSizeWarningIndicator);
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 121);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test conditions";
            // 
            // optDirectoryExistOnly
            // 
            this.optDirectoryExistOnly.AutoSize = true;
            this.optDirectoryExistOnly.Location = new System.Drawing.Point(21, 42);
            this.optDirectoryExistOnly.Name = "optDirectoryExistOnly";
            this.optDirectoryExistOnly.Size = new System.Drawing.Size(159, 17);
            this.optDirectoryExistOnly.TabIndex = 1;
            this.optDirectoryExistOnly.Text = "Only check if directory exists";
            this.optDirectoryExistOnly.UseVisualStyleBackColor = true;
            this.optDirectoryExistOnly.CheckedChanged += new System.EventHandler(this.optDirectoryExistOnly_CheckedChanged);
            // 
            // optCheckIfFilesExistOnly
            // 
            this.optCheckIfFilesExistOnly.AutoSize = true;
            this.optCheckIfFilesExistOnly.Location = new System.Drawing.Point(21, 65);
            this.optCheckIfFilesExistOnly.Name = "optCheckIfFilesExistOnly";
            this.optCheckIfFilesExistOnly.Size = new System.Drawing.Size(169, 17);
            this.optCheckIfFilesExistOnly.TabIndex = 2;
            this.optCheckIfFilesExistOnly.Text = "Only check if [any] file(s) exists";
            this.optCheckIfFilesExistOnly.UseVisualStyleBackColor = true;
            this.optCheckIfFilesExistOnly.CheckedChanged += new System.EventHandler(this.optCheckIfFilesExistOnly_CheckedChanged);
            // 
            // optErrorOnFilesExist
            // 
            this.optErrorOnFilesExist.AutoSize = true;
            this.optErrorOnFilesExist.Location = new System.Drawing.Point(21, 88);
            this.optErrorOnFilesExist.Name = "optErrorOnFilesExist";
            this.optErrorOnFilesExist.Size = new System.Drawing.Size(169, 17);
            this.optErrorOnFilesExist.TabIndex = 3;
            this.optErrorOnFilesExist.Text = "Only check if [any] file(s) exists";
            this.optErrorOnFilesExist.UseVisualStyleBackColor = true;
            this.optErrorOnFilesExist.CheckedChanged += new System.EventHandler(this.optErrorOnFilesExist_CheckedChanged);
            // 
            // optCounts
            // 
            this.optCounts.AutoSize = true;
            this.optCounts.Checked = true;
            this.optCounts.Location = new System.Drawing.Point(21, 19);
            this.optCounts.Name = "optCounts";
            this.optCounts.Size = new System.Drawing.Size(91, 17);
            this.optCounts.TabIndex = 0;
            this.optCounts.Text = "Check counts";
            this.optCounts.UseVisualStyleBackColor = true;
            this.optCounts.CheckedChanged += new System.EventHandler(this.optCounts_CheckedChanged);
            // 
            // FileSystemCollectorEditFilterEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 397);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSystemCollectorEditFilterEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Filter Entry";
            this.Load += new System.EventHandler(this.FileSystemCollectorEditFilterEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeErrorIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeWarningIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountErrorIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountWarningIndicator)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDownFileSizeMax;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownFileSizeMin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownFileAgeMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownFileAgeMin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeErrorIndicator;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeWarningIndicator;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.NumericUpDown numericUpDownCountErrorIndicator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCountWarningIndicator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContains;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkUseRegEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optCounts;
        private System.Windows.Forms.RadioButton optErrorOnFilesExist;
        private System.Windows.Forms.RadioButton optCheckIfFilesExistOnly;
        private System.Windows.Forms.RadioButton optDirectoryExistOnly;
    }
}