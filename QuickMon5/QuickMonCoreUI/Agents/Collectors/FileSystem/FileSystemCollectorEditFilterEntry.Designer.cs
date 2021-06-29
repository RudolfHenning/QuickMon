namespace QuickMon.UI
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
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudFindTextInLastXLines = new System.Windows.Forms.NumericUpDown();
            this.chkIncludeSubDirs = new System.Windows.Forms.CheckBox();
            this.cboFileSizeUnit = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboFileAgeUnit = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboFileSizeIndicatorUnit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.optCounts = new System.Windows.Forms.RadioButton();
            this.optErrorOnFilesExist = new System.Windows.Forms.RadioButton();
            this.optCheckIfFilesExistOnly = new System.Windows.Forms.RadioButton();
            this.optDirectoryExistOnly = new System.Windows.Forms.RadioButton();
            this.chkShowFilenamesInDetails = new System.Windows.Forms.CheckBox();
            this.cmdTest = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFistWithTopWarning = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.topFileNameCountInDetailsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ShowFileCountAndSizeInOutputValue = new System.Windows.Forms.RadioButton();
            this.optShowFileSizeInOutputValue = new System.Windows.Forms.RadioButton();
            this.optShowFileCountInOutputValue = new System.Windows.Forms.RadioButton();
            this.chkVerifyOnOK = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeErrorIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeWarningIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountErrorIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountWarningIndicator)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFindTextInLastXLines)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topFileNameCountInDetailsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(399, 13);
            this.label15.TabIndex = 20;
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
            this.numericUpDownFileSizeMax.TabIndex = 24;
            this.numericUpDownFileSizeMax.ValueChanged += new System.EventHandler(this.numericUpDownFileSizeMax_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(186, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 23;
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
            this.numericUpDownFileSizeMin.TabIndex = 22;
            this.numericUpDownFileSizeMin.ValueChanged += new System.EventHandler(this.numericUpDownFileSizeMin_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(38, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "Minimum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(371, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "File age - File age must be between min/max to be included. 0 means no limit.";
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
            this.numericUpDownFileAgeMax.TabIndex = 17;
            this.numericUpDownFileAgeMax.ValueChanged += new System.EventHandler(this.numericUpDownFileAgeMax_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 16;
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
            this.numericUpDownFileAgeMin.TabIndex = 15;
            this.numericUpDownFileAgeMin.ValueChanged += new System.EventHandler(this.numericUpDownFileAgeMin_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Minimum";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Total Size - Total size of all files before specified condition is set";
            // 
            // numericUpDownSizeErrorIndicator
            // 
            this.numericUpDownSizeErrorIndicator.Location = new System.Drawing.Point(385, 90);
            this.numericUpDownSizeErrorIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSizeErrorIndicator.Name = "numericUpDownSizeErrorIndicator";
            this.numericUpDownSizeErrorIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownSizeErrorIndicator.TabIndex = 13;
            this.numericUpDownSizeErrorIndicator.ValueChanged += new System.EventHandler(this.numericUpDownSizeErrorIndicator_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Errors";
            // 
            // numericUpDownSizeWarningIndicator
            // 
            this.numericUpDownSizeWarningIndicator.Location = new System.Drawing.Point(262, 90);
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
            this.label13.Location = new System.Drawing.Point(207, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Warnings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(332, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Total Count - Smallest number of files before specified condition is set";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(518, 430);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(437, 430);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // numericUpDownCountErrorIndicator
            // 
            this.numericUpDownCountErrorIndicator.Location = new System.Drawing.Point(385, 40);
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
            this.label5.Location = new System.Drawing.Point(336, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Errors";
            // 
            // numericUpDownCountWarningIndicator
            // 
            this.numericUpDownCountWarningIndicator.Location = new System.Drawing.Point(262, 40);
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
            this.label4.Location = new System.Drawing.Point(207, 42);
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
            this.label3.TabIndex = 5;
            this.label3.Text = "e.g *.*";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(93, 50);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(139, 20);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.Text = "*.*";
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowse.Location = new System.Drawing.Point(506, 22);
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
            this.txtDirectory.Size = new System.Drawing.Size(407, 20);
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
            this.txtContains.Size = new System.Drawing.Size(481, 20);
            this.txtContains.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Contents";
            // 
            // chkUseRegEx
            // 
            this.chkUseRegEx.AutoSize = true;
            this.chkUseRegEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseRegEx.Location = new System.Drawing.Point(93, 102);
            this.chkUseRegEx.Name = "chkUseRegEx";
            this.chkUseRegEx.Size = new System.Drawing.Size(140, 17);
            this.chkUseRegEx.TabIndex = 9;
            this.chkUseRegEx.Text = "Use Regular expressions";
            this.chkUseRegEx.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nudFindTextInLastXLines);
            this.groupBox1.Controls.Add(this.chkIncludeSubDirs);
            this.groupBox1.Controls.Add(this.cboFileSizeUnit);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cboFileAgeUnit);
            this.groupBox1.Controls.Add(this.label19);
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
            this.groupBox1.Size = new System.Drawing.Size(580, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File filters";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(395, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(149, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "number of lines (0 = whole file)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Find text in last";
            // 
            // nudFindTextInLastXLines
            // 
            this.nudFindTextInLastXLines.Location = new System.Drawing.Point(325, 102);
            this.nudFindTextInLastXLines.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudFindTextInLastXLines.Name = "nudFindTextInLastXLines";
            this.nudFindTextInLastXLines.Size = new System.Drawing.Size(64, 20);
            this.nudFindTextInLastXLines.TabIndex = 11;
            // 
            // chkIncludeSubDirs
            // 
            this.chkIncludeSubDirs.AutoSize = true;
            this.chkIncludeSubDirs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIncludeSubDirs.Location = new System.Drawing.Point(290, 51);
            this.chkIncludeSubDirs.Name = "chkIncludeSubDirs";
            this.chkIncludeSubDirs.Size = new System.Drawing.Size(256, 17);
            this.chkIncludeSubDirs.TabIndex = 6;
            this.chkIncludeSubDirs.Text = "Include Sub Directories (Warning - could be slow)";
            this.chkIncludeSubDirs.UseVisualStyleBackColor = true;
            // 
            // cboFileSizeUnit
            // 
            this.cboFileSizeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileSizeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboFileSizeUnit.FormattingEnabled = true;
            this.cboFileSizeUnit.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cboFileSizeUnit.Location = new System.Drawing.Point(367, 189);
            this.cboFileSizeUnit.Name = "cboFileSizeUnit";
            this.cboFileSizeUnit.Size = new System.Drawing.Size(75, 21);
            this.cboFileSizeUnit.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(335, 192);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Unit";
            // 
            // cboFileAgeUnit
            // 
            this.cboFileAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileAgeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboFileAgeUnit.FormattingEnabled = true;
            this.cboFileAgeUnit.Items.AddRange(new object[] {
            "Millisecond",
            "Second",
            "Minute",
            "Hour",
            "Day",
            "Week",
            "Month",
            "Year"});
            this.cboFileAgeUnit.Location = new System.Drawing.Point(367, 140);
            this.cboFileAgeUnit.Name = "cboFileAgeUnit";
            this.cboFileAgeUnit.Size = new System.Drawing.Size(110, 21);
            this.cboFileAgeUnit.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(335, 143);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Unit";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboFileSizeIndicatorUnit);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.optCounts);
            this.groupBox2.Controls.Add(this.optErrorOnFilesExist);
            this.groupBox2.Controls.Add(this.optCheckIfFilesExistOnly);
            this.groupBox2.Controls.Add(this.optDirectoryExistOnly);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDownCountWarningIndicator);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDownSizeErrorIndicator);
            this.groupBox2.Controls.Add(this.numericUpDownCountErrorIndicator);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.numericUpDownSizeWarningIndicator);
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 121);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test conditions";
            // 
            // cboFileSizeIndicatorUnit
            // 
            this.cboFileSizeIndicatorUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileSizeIndicatorUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboFileSizeIndicatorUnit.FormattingEnabled = true;
            this.cboFileSizeIndicatorUnit.Items.AddRange(new object[] {
            "Bytes",
            "KB",
            "MB",
            "GB"});
            this.cboFileSizeIndicatorUnit.Location = new System.Drawing.Point(487, 89);
            this.cboFileSizeIndicatorUnit.Name = "cboFileSizeIndicatorUnit";
            this.cboFileSizeIndicatorUnit.Size = new System.Drawing.Size(75, 21);
            this.cboFileSizeIndicatorUnit.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(455, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Unit";
            // 
            // optCounts
            // 
            this.optCounts.AutoSize = true;
            this.optCounts.Checked = true;
            this.optCounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optCounts.Location = new System.Drawing.Point(21, 19);
            this.optCounts.Name = "optCounts";
            this.optCounts.Size = new System.Drawing.Size(90, 17);
            this.optCounts.TabIndex = 0;
            this.optCounts.TabStop = true;
            this.optCounts.Text = "Check counts";
            this.optCounts.UseVisualStyleBackColor = true;
            this.optCounts.CheckedChanged += new System.EventHandler(this.optCounts_CheckedChanged);
            // 
            // optErrorOnFilesExist
            // 
            this.optErrorOnFilesExist.AutoSize = true;
            this.optErrorOnFilesExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optErrorOnFilesExist.Location = new System.Drawing.Point(21, 88);
            this.optErrorOnFilesExist.Name = "optErrorOnFilesExist";
            this.optErrorOnFilesExist.Size = new System.Drawing.Size(136, 17);
            this.optErrorOnFilesExist.TabIndex = 3;
            this.optErrorOnFilesExist.Text = "Error if [any] file(s) exists";
            this.optErrorOnFilesExist.UseVisualStyleBackColor = true;
            this.optErrorOnFilesExist.CheckedChanged += new System.EventHandler(this.optErrorOnFilesExist_CheckedChanged);
            // 
            // optCheckIfFilesExistOnly
            // 
            this.optCheckIfFilesExistOnly.AutoSize = true;
            this.optCheckIfFilesExistOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optCheckIfFilesExistOnly.Location = new System.Drawing.Point(21, 65);
            this.optCheckIfFilesExistOnly.Name = "optCheckIfFilesExistOnly";
            this.optCheckIfFilesExistOnly.Size = new System.Drawing.Size(168, 17);
            this.optCheckIfFilesExistOnly.TabIndex = 2;
            this.optCheckIfFilesExistOnly.Text = "Only check if [any] file(s) exists";
            this.optCheckIfFilesExistOnly.UseVisualStyleBackColor = true;
            this.optCheckIfFilesExistOnly.CheckedChanged += new System.EventHandler(this.optCheckIfFilesExistOnly_CheckedChanged);
            // 
            // optDirectoryExistOnly
            // 
            this.optDirectoryExistOnly.AutoSize = true;
            this.optDirectoryExistOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optDirectoryExistOnly.Location = new System.Drawing.Point(21, 42);
            this.optDirectoryExistOnly.Name = "optDirectoryExistOnly";
            this.optDirectoryExistOnly.Size = new System.Drawing.Size(158, 17);
            this.optDirectoryExistOnly.TabIndex = 1;
            this.optDirectoryExistOnly.Text = "Only check if directory exists";
            this.optDirectoryExistOnly.UseVisualStyleBackColor = true;
            this.optDirectoryExistOnly.CheckedChanged += new System.EventHandler(this.optDirectoryExistOnly_CheckedChanged);
            // 
            // chkShowFilenamesInDetails
            // 
            this.chkShowFilenamesInDetails.AutoSize = true;
            this.chkShowFilenamesInDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowFilenamesInDetails.Location = new System.Drawing.Point(12, 19);
            this.chkShowFilenamesInDetails.Name = "chkShowFilenamesInDetails";
            this.chkShowFilenamesInDetails.Size = new System.Drawing.Size(89, 17);
            this.chkShowFilenamesInDetails.TabIndex = 0;
            this.chkShowFilenamesInDetails.Text = "List file names";
            this.chkShowFilenamesInDetails.UseVisualStyleBackColor = true;
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTest.Location = new System.Drawing.Point(356, 430);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 4;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblFistWithTopWarning);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.topFileNameCountInDetailsNumericUpDown);
            this.groupBox3.Controls.Add(this.ShowFileCountAndSizeInOutputValue);
            this.groupBox3.Controls.Add(this.optShowFileSizeInOutputValue);
            this.groupBox3.Controls.Add(this.optShowFileCountInOutputValue);
            this.groupBox3.Controls.Add(this.chkShowFilenamesInDetails);
            this.groupBox3.Location = new System.Drawing.Point(12, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 61);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display/Output";
            // 
            // lblFistWithTopWarning
            // 
            this.lblFistWithTopWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFistWithTopWarning.ForeColor = System.Drawing.Color.Maroon;
            this.lblFistWithTopWarning.Location = new System.Drawing.Point(6, 40);
            this.lblFistWithTopWarning.Name = "lblFistWithTopWarning";
            this.lblFistWithTopWarning.Size = new System.Drawing.Size(383, 18);
            this.lblFistWithTopWarning.TabIndex = 6;
            this.lblFistWithTopWarning.Text = "Warning: specifying List file names with a large \'Top\' value can slow down the co" +
    "llector!";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(211, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 13);
            this.label23.TabIndex = 3;
            this.label23.Text = "file(s) ( 0=All)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(109, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Top";
            // 
            // topFileNameCountInDetailsNumericUpDown
            // 
            this.topFileNameCountInDetailsNumericUpDown.Location = new System.Drawing.Point(141, 19);
            this.topFileNameCountInDetailsNumericUpDown.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.topFileNameCountInDetailsNumericUpDown.Name = "topFileNameCountInDetailsNumericUpDown";
            this.topFileNameCountInDetailsNumericUpDown.Size = new System.Drawing.Size(64, 20);
            this.topFileNameCountInDetailsNumericUpDown.TabIndex = 2;
            this.topFileNameCountInDetailsNumericUpDown.ValueChanged += new System.EventHandler(this.topFileNameCountInDetailsNumericUpDown_ValueChanged);
            // 
            // ShowFileCountAndSizeInOutputValue
            // 
            this.ShowFileCountAndSizeInOutputValue.AutoSize = true;
            this.ShowFileCountAndSizeInOutputValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowFileCountAndSizeInOutputValue.Location = new System.Drawing.Point(437, 19);
            this.ShowFileCountAndSizeInOutputValue.Name = "ShowFileCountAndSizeInOutputValue";
            this.ShowFileCountAndSizeInOutputValue.Size = new System.Drawing.Size(112, 17);
            this.ShowFileCountAndSizeInOutputValue.TabIndex = 6;
            this.ShowFileCountAndSizeInOutputValue.TabStop = true;
            this.ShowFileCountAndSizeInOutputValue.Text = "File count and size";
            this.ShowFileCountAndSizeInOutputValue.UseVisualStyleBackColor = true;
            // 
            // optShowFileSizeInOutputValue
            // 
            this.optShowFileSizeInOutputValue.AutoSize = true;
            this.optShowFileSizeInOutputValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optShowFileSizeInOutputValue.Location = new System.Drawing.Point(369, 19);
            this.optShowFileSizeInOutputValue.Name = "optShowFileSizeInOutputValue";
            this.optShowFileSizeInOutputValue.Size = new System.Drawing.Size(61, 17);
            this.optShowFileSizeInOutputValue.TabIndex = 5;
            this.optShowFileSizeInOutputValue.TabStop = true;
            this.optShowFileSizeInOutputValue.Text = "File size";
            this.optShowFileSizeInOutputValue.UseVisualStyleBackColor = true;
            // 
            // optShowFileCountInOutputValue
            // 
            this.optShowFileCountInOutputValue.AutoSize = true;
            this.optShowFileCountInOutputValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optShowFileCountInOutputValue.Location = new System.Drawing.Point(292, 19);
            this.optShowFileCountInOutputValue.Name = "optShowFileCountInOutputValue";
            this.optShowFileCountInOutputValue.Size = new System.Drawing.Size(70, 17);
            this.optShowFileCountInOutputValue.TabIndex = 4;
            this.optShowFileCountInOutputValue.TabStop = true;
            this.optShowFileCountInOutputValue.Text = "File count";
            this.optShowFileCountInOutputValue.UseVisualStyleBackColor = true;
            // 
            // chkVerifyOnOK
            // 
            this.chkVerifyOnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerifyOnOK.AutoSize = true;
            this.chkVerifyOnOK.Checked = true;
            this.chkVerifyOnOK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyOnOK.Location = new System.Drawing.Point(226, 434);
            this.chkVerifyOnOK.Name = "chkVerifyOnOK";
            this.chkVerifyOnOK.Size = new System.Drawing.Size(123, 17);
            this.chkVerifyOnOK.TabIndex = 3;
            this.chkVerifyOnOK.Text = "Test on clicking \'OK\'";
            this.chkVerifyOnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerifyOnOK.UseVisualStyleBackColor = true;
            // 
            // FileSystemCollectorEditFilterEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(604, 464);
            this.Controls.Add(this.chkVerifyOnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdTest);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudFindTextInLastXLines)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topFileNameCountInDetailsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cboFileAgeUnit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboFileSizeUnit;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboFileSizeIndicatorUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkShowFilenamesInDetails;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.CheckBox chkIncludeSubDirs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton ShowFileCountAndSizeInOutputValue;
        private System.Windows.Forms.RadioButton optShowFileSizeInOutputValue;
        private System.Windows.Forms.RadioButton optShowFileCountInOutputValue;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudFindTextInLastXLines;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown topFileNameCountInDetailsNumericUpDown;
        private System.Windows.Forms.Label lblFistWithTopWarning;
        private System.Windows.Forms.CheckBox chkVerifyOnOK;
    }
}