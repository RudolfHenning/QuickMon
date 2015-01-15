namespace QuickMon.Notifiers
{
    partial class AudioNotifierEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioNotifierEdit));
            this.warningVolumePercTrackBar = new System.Windows.Forms.TrackBar();
            this.warningRepeatCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorVolumePercTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.errorRepeatCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdErrorBrowseAudioFile = new System.Windows.Forms.Button();
            this.txtErrorAudioFilePath = new System.Windows.Forms.TextBox();
            this.cboErrorSystemSound = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdErrorTestSound = new System.Windows.Forms.Button();
            this.chkErrorEnabled = new System.Windows.Forms.CheckBox();
            this.chkErrorUseSystemSounds = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmdWarningBrowseAudioFile = new System.Windows.Forms.Button();
            this.soundOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.goodVolumePercTrackBar = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.goodRepeatCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdGoodBrowseAudioFile = new System.Windows.Forms.Button();
            this.txtGoodAudioFilePath = new System.Windows.Forms.TextBox();
            this.cboGoodSystemSound = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdGoodTestSound = new System.Windows.Forms.Button();
            this.chkGoodEnabled = new System.Windows.Forms.CheckBox();
            this.chkGoodUseSystemSounds = new System.Windows.Forms.CheckBox();
            this.txtWarningAudioFilePath = new System.Windows.Forms.TextBox();
            this.cboWarningSystemSound = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdWarningTestSound = new System.Windows.Forms.Button();
            this.chkWarningEnabled = new System.Windows.Forms.CheckBox();
            this.chkWarningUseSystemSounds = new System.Windows.Forms.CheckBox();
            this.warningGroupBox = new System.Windows.Forms.GroupBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.warningVolumePercTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningRepeatCountNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorVolumePercTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRepeatCountNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodVolumePercTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodRepeatCountNumericUpDown)).BeginInit();
            this.warningGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // warningVolumePercTrackBar
            // 
            this.warningVolumePercTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningVolumePercTrackBar.LargeChange = 10;
            this.warningVolumePercTrackBar.Location = new System.Drawing.Point(183, 78);
            this.warningVolumePercTrackBar.Maximum = 100;
            this.warningVolumePercTrackBar.Minimum = -1;
            this.warningVolumePercTrackBar.Name = "warningVolumePercTrackBar";
            this.warningVolumePercTrackBar.Size = new System.Drawing.Size(371, 45);
            this.warningVolumePercTrackBar.TabIndex = 9;
            this.warningVolumePercTrackBar.TickFrequency = 5;
            this.warningVolumePercTrackBar.Value = 100;
            // 
            // warningRepeatCountNumericUpDown
            // 
            this.warningRepeatCountNumericUpDown.Location = new System.Drawing.Point(76, 79);
            this.warningRepeatCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.warningRepeatCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.warningRepeatCountNumericUpDown.Name = "warningRepeatCountNumericUpDown";
            this.warningRepeatCountNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.warningRepeatCountNumericUpDown.TabIndex = 7;
            this.warningRepeatCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Repeat";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorVolumePercTrackBar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.errorRepeatCountNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdErrorBrowseAudioFile);
            this.groupBox1.Controls.Add(this.txtErrorAudioFilePath);
            this.groupBox1.Controls.Add(this.cboErrorSystemSound);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdErrorTestSound);
            this.groupBox1.Controls.Add(this.chkErrorEnabled);
            this.groupBox1.Controls.Add(this.chkErrorUseSystemSounds);
            this.groupBox1.Location = new System.Drawing.Point(12, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 131);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Good state";
            // 
            // errorVolumePercTrackBar
            // 
            this.errorVolumePercTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorVolumePercTrackBar.LargeChange = 10;
            this.errorVolumePercTrackBar.Location = new System.Drawing.Point(183, 78);
            this.errorVolumePercTrackBar.Maximum = 100;
            this.errorVolumePercTrackBar.Minimum = -1;
            this.errorVolumePercTrackBar.Name = "errorVolumePercTrackBar";
            this.errorVolumePercTrackBar.Size = new System.Drawing.Size(371, 45);
            this.errorVolumePercTrackBar.TabIndex = 9;
            this.errorVolumePercTrackBar.TickFrequency = 5;
            this.errorVolumePercTrackBar.Value = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Volume";
            // 
            // errorRepeatCountNumericUpDown
            // 
            this.errorRepeatCountNumericUpDown.Location = new System.Drawing.Point(76, 79);
            this.errorRepeatCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.errorRepeatCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.errorRepeatCountNumericUpDown.Name = "errorRepeatCountNumericUpDown";
            this.errorRepeatCountNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.errorRepeatCountNumericUpDown.TabIndex = 7;
            this.errorRepeatCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Repeat";
            // 
            // cmdErrorBrowseAudioFile
            // 
            this.cmdErrorBrowseAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdErrorBrowseAudioFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdErrorBrowseAudioFile.Location = new System.Drawing.Point(519, 50);
            this.cmdErrorBrowseAudioFile.Name = "cmdErrorBrowseAudioFile";
            this.cmdErrorBrowseAudioFile.Size = new System.Drawing.Size(35, 23);
            this.cmdErrorBrowseAudioFile.TabIndex = 5;
            this.cmdErrorBrowseAudioFile.Text = "- - -";
            this.cmdErrorBrowseAudioFile.UseVisualStyleBackColor = true;
            this.cmdErrorBrowseAudioFile.Click += new System.EventHandler(this.cmdBrowseErrorSoundFile_Click);
            // 
            // txtErrorAudioFilePath
            // 
            this.txtErrorAudioFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorAudioFilePath.Location = new System.Drawing.Point(76, 52);
            this.txtErrorAudioFilePath.Name = "txtErrorAudioFilePath";
            this.txtErrorAudioFilePath.Size = new System.Drawing.Size(437, 20);
            this.txtErrorAudioFilePath.TabIndex = 4;
            // 
            // cboErrorSystemSound
            // 
            this.cboErrorSystemSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboErrorSystemSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboErrorSystemSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboErrorSystemSound.FormattingEnabled = true;
            this.cboErrorSystemSound.Items.AddRange(new object[] {
            "Asterisk",
            "Beep",
            "Exclamation",
            "Hand",
            "Question"});
            this.cboErrorSystemSound.Location = new System.Drawing.Point(76, 52);
            this.cboErrorSystemSound.Name = "cboErrorSystemSound";
            this.cboErrorSystemSound.Size = new System.Drawing.Size(478, 21);
            this.cboErrorSystemSound.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sound";
            // 
            // cmdErrorTestSound
            // 
            this.cmdErrorTestSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdErrorTestSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdErrorTestSound.Image = global::QuickMon.Properties.Resources.TriangleRight;
            this.cmdErrorTestSound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdErrorTestSound.Location = new System.Drawing.Point(479, 11);
            this.cmdErrorTestSound.Name = "cmdErrorTestSound";
            this.cmdErrorTestSound.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.cmdErrorTestSound.Size = new System.Drawing.Size(75, 31);
            this.cmdErrorTestSound.TabIndex = 2;
            this.cmdErrorTestSound.Text = "Test";
            this.cmdErrorTestSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdErrorTestSound.UseVisualStyleBackColor = true;
            this.cmdErrorTestSound.Click += new System.EventHandler(this.cmdTestErrorSound_Click);
            // 
            // chkErrorEnabled
            // 
            this.chkErrorEnabled.AutoSize = true;
            this.chkErrorEnabled.Location = new System.Drawing.Point(15, 19);
            this.chkErrorEnabled.Name = "chkErrorEnabled";
            this.chkErrorEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkErrorEnabled.TabIndex = 0;
            this.chkErrorEnabled.Text = "Enabled";
            this.chkErrorEnabled.UseVisualStyleBackColor = true;
            this.chkErrorEnabled.CheckedChanged += new System.EventHandler(this.triggerOKCheck);
            // 
            // chkErrorUseSystemSounds
            // 
            this.chkErrorUseSystemSounds.AutoSize = true;
            this.chkErrorUseSystemSounds.Location = new System.Drawing.Point(104, 19);
            this.chkErrorUseSystemSounds.Name = "chkErrorUseSystemSounds";
            this.chkErrorUseSystemSounds.Size = new System.Drawing.Size(97, 17);
            this.chkErrorUseSystemSounds.TabIndex = 1;
            this.chkErrorUseSystemSounds.Text = "System sounds";
            this.chkErrorUseSystemSounds.UseVisualStyleBackColor = true;
            this.chkErrorUseSystemSounds.CheckedChanged += new System.EventHandler(this.triggerOKCheck);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(135, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Volume";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // cmdWarningBrowseAudioFile
            // 
            this.cmdWarningBrowseAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdWarningBrowseAudioFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdWarningBrowseAudioFile.Location = new System.Drawing.Point(519, 50);
            this.cmdWarningBrowseAudioFile.Name = "cmdWarningBrowseAudioFile";
            this.cmdWarningBrowseAudioFile.Size = new System.Drawing.Size(35, 23);
            this.cmdWarningBrowseAudioFile.TabIndex = 5;
            this.cmdWarningBrowseAudioFile.Text = "- - -";
            this.cmdWarningBrowseAudioFile.UseVisualStyleBackColor = true;
            this.cmdWarningBrowseAudioFile.Click += new System.EventHandler(this.cmdBrowseWarningSoundFile_Click);
            // 
            // soundOpenFileDialog
            // 
            this.soundOpenFileDialog.Filter = "Sound files|*.wav;*.mp3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.goodVolumePercTrackBar);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.goodRepeatCountNumericUpDown);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmdGoodBrowseAudioFile);
            this.groupBox2.Controls.Add(this.txtGoodAudioFilePath);
            this.groupBox2.Controls.Add(this.cboGoodSystemSound);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmdGoodTestSound);
            this.groupBox2.Controls.Add(this.chkGoodEnabled);
            this.groupBox2.Controls.Add(this.chkGoodUseSystemSounds);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 131);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Good state";
            // 
            // goodVolumePercTrackBar
            // 
            this.goodVolumePercTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goodVolumePercTrackBar.LargeChange = 10;
            this.goodVolumePercTrackBar.Location = new System.Drawing.Point(183, 78);
            this.goodVolumePercTrackBar.Maximum = 100;
            this.goodVolumePercTrackBar.Minimum = -1;
            this.goodVolumePercTrackBar.Name = "goodVolumePercTrackBar";
            this.goodVolumePercTrackBar.Size = new System.Drawing.Size(371, 45);
            this.goodVolumePercTrackBar.TabIndex = 9;
            this.goodVolumePercTrackBar.TickFrequency = 5;
            this.goodVolumePercTrackBar.Value = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Volume";
            // 
            // goodRepeatCountNumericUpDown
            // 
            this.goodRepeatCountNumericUpDown.Location = new System.Drawing.Point(76, 79);
            this.goodRepeatCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.goodRepeatCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.goodRepeatCountNumericUpDown.Name = "goodRepeatCountNumericUpDown";
            this.goodRepeatCountNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.goodRepeatCountNumericUpDown.TabIndex = 7;
            this.goodRepeatCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Repeat";
            // 
            // cmdGoodBrowseAudioFile
            // 
            this.cmdGoodBrowseAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGoodBrowseAudioFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGoodBrowseAudioFile.Location = new System.Drawing.Point(519, 50);
            this.cmdGoodBrowseAudioFile.Name = "cmdGoodBrowseAudioFile";
            this.cmdGoodBrowseAudioFile.Size = new System.Drawing.Size(35, 23);
            this.cmdGoodBrowseAudioFile.TabIndex = 5;
            this.cmdGoodBrowseAudioFile.Text = "- - -";
            this.cmdGoodBrowseAudioFile.UseVisualStyleBackColor = true;
            this.cmdGoodBrowseAudioFile.Click += new System.EventHandler(this.cmdBrowseGoodSoundFile_Click);
            // 
            // txtGoodAudioFilePath
            // 
            this.txtGoodAudioFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoodAudioFilePath.Location = new System.Drawing.Point(76, 52);
            this.txtGoodAudioFilePath.Name = "txtGoodAudioFilePath";
            this.txtGoodAudioFilePath.Size = new System.Drawing.Size(437, 20);
            this.txtGoodAudioFilePath.TabIndex = 4;
            // 
            // cboGoodSystemSound
            // 
            this.cboGoodSystemSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGoodSystemSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoodSystemSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboGoodSystemSound.FormattingEnabled = true;
            this.cboGoodSystemSound.Items.AddRange(new object[] {
            "Asterisk",
            "Beep",
            "Exclamation",
            "Hand",
            "Question"});
            this.cboGoodSystemSound.Location = new System.Drawing.Point(76, 52);
            this.cboGoodSystemSound.Name = "cboGoodSystemSound";
            this.cboGoodSystemSound.Size = new System.Drawing.Size(478, 21);
            this.cboGoodSystemSound.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Sound";
            // 
            // cmdGoodTestSound
            // 
            this.cmdGoodTestSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGoodTestSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGoodTestSound.Image = global::QuickMon.Properties.Resources.TriangleRight;
            this.cmdGoodTestSound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGoodTestSound.Location = new System.Drawing.Point(479, 11);
            this.cmdGoodTestSound.Name = "cmdGoodTestSound";
            this.cmdGoodTestSound.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.cmdGoodTestSound.Size = new System.Drawing.Size(75, 31);
            this.cmdGoodTestSound.TabIndex = 2;
            this.cmdGoodTestSound.Text = "Test";
            this.cmdGoodTestSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGoodTestSound.UseVisualStyleBackColor = true;
            this.cmdGoodTestSound.Click += new System.EventHandler(this.cmdTestGoodSound_Click);
            // 
            // chkGoodEnabled
            // 
            this.chkGoodEnabled.AutoSize = true;
            this.chkGoodEnabled.Location = new System.Drawing.Point(15, 19);
            this.chkGoodEnabled.Name = "chkGoodEnabled";
            this.chkGoodEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkGoodEnabled.TabIndex = 0;
            this.chkGoodEnabled.Text = "Enabled";
            this.chkGoodEnabled.UseVisualStyleBackColor = true;
            this.chkGoodEnabled.CheckedChanged += new System.EventHandler(this.triggerOKCheck);
            // 
            // chkGoodUseSystemSounds
            // 
            this.chkGoodUseSystemSounds.AutoSize = true;
            this.chkGoodUseSystemSounds.Location = new System.Drawing.Point(104, 19);
            this.chkGoodUseSystemSounds.Name = "chkGoodUseSystemSounds";
            this.chkGoodUseSystemSounds.Size = new System.Drawing.Size(97, 17);
            this.chkGoodUseSystemSounds.TabIndex = 1;
            this.chkGoodUseSystemSounds.Text = "System sounds";
            this.chkGoodUseSystemSounds.UseVisualStyleBackColor = true;
            this.chkGoodUseSystemSounds.CheckedChanged += new System.EventHandler(this.triggerOKCheck);
            // 
            // txtWarningAudioFilePath
            // 
            this.txtWarningAudioFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarningAudioFilePath.Location = new System.Drawing.Point(76, 52);
            this.txtWarningAudioFilePath.Name = "txtWarningAudioFilePath";
            this.txtWarningAudioFilePath.Size = new System.Drawing.Size(437, 20);
            this.txtWarningAudioFilePath.TabIndex = 4;
            // 
            // cboWarningSystemSound
            // 
            this.cboWarningSystemSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWarningSystemSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarningSystemSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboWarningSystemSound.FormattingEnabled = true;
            this.cboWarningSystemSound.Items.AddRange(new object[] {
            "Asterisk",
            "Beep",
            "Exclamation",
            "Hand",
            "Question"});
            this.cboWarningSystemSound.Location = new System.Drawing.Point(76, 52);
            this.cboWarningSystemSound.Name = "cboWarningSystemSound";
            this.cboWarningSystemSound.Size = new System.Drawing.Size(478, 21);
            this.cboWarningSystemSound.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Sound";
            // 
            // cmdWarningTestSound
            // 
            this.cmdWarningTestSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdWarningTestSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdWarningTestSound.Image = global::QuickMon.Properties.Resources.TriangleRight;
            this.cmdWarningTestSound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdWarningTestSound.Location = new System.Drawing.Point(479, 11);
            this.cmdWarningTestSound.Name = "cmdWarningTestSound";
            this.cmdWarningTestSound.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.cmdWarningTestSound.Size = new System.Drawing.Size(75, 31);
            this.cmdWarningTestSound.TabIndex = 2;
            this.cmdWarningTestSound.Text = "Test";
            this.cmdWarningTestSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdWarningTestSound.UseVisualStyleBackColor = true;
            this.cmdWarningTestSound.Click += new System.EventHandler(this.cmdTestWarningSound_Click);
            // 
            // chkWarningEnabled
            // 
            this.chkWarningEnabled.AutoSize = true;
            this.chkWarningEnabled.Location = new System.Drawing.Point(15, 19);
            this.chkWarningEnabled.Name = "chkWarningEnabled";
            this.chkWarningEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkWarningEnabled.TabIndex = 0;
            this.chkWarningEnabled.Text = "Enabled";
            this.chkWarningEnabled.UseVisualStyleBackColor = true;
            this.chkWarningEnabled.CheckedChanged += new System.EventHandler(this.triggerOKCheck);
            // 
            // chkWarningUseSystemSounds
            // 
            this.chkWarningUseSystemSounds.AutoSize = true;
            this.chkWarningUseSystemSounds.Location = new System.Drawing.Point(104, 19);
            this.chkWarningUseSystemSounds.Name = "chkWarningUseSystemSounds";
            this.chkWarningUseSystemSounds.Size = new System.Drawing.Size(97, 17);
            this.chkWarningUseSystemSounds.TabIndex = 1;
            this.chkWarningUseSystemSounds.Text = "System sounds";
            this.chkWarningUseSystemSounds.UseVisualStyleBackColor = true;
            this.chkWarningUseSystemSounds.CheckedChanged += new System.EventHandler(this.triggerOKCheck);
            // 
            // warningGroupBox
            // 
            this.warningGroupBox.Controls.Add(this.warningVolumePercTrackBar);
            this.warningGroupBox.Controls.Add(this.label10);
            this.warningGroupBox.Controls.Add(this.warningRepeatCountNumericUpDown);
            this.warningGroupBox.Controls.Add(this.label11);
            this.warningGroupBox.Controls.Add(this.cmdWarningBrowseAudioFile);
            this.warningGroupBox.Controls.Add(this.txtWarningAudioFilePath);
            this.warningGroupBox.Controls.Add(this.cboWarningSystemSound);
            this.warningGroupBox.Controls.Add(this.label12);
            this.warningGroupBox.Controls.Add(this.cmdWarningTestSound);
            this.warningGroupBox.Controls.Add(this.chkWarningEnabled);
            this.warningGroupBox.Controls.Add(this.chkWarningUseSystemSounds);
            this.warningGroupBox.Location = new System.Drawing.Point(12, 143);
            this.warningGroupBox.Name = "warningGroupBox";
            this.warningGroupBox.Size = new System.Drawing.Size(560, 131);
            this.warningGroupBox.TabIndex = 1;
            this.warningGroupBox.TabStop = false;
            this.warningGroupBox.Text = "Warning state";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(497, 420);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(416, 420);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // AudioNotifierEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 455);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.warningGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AudioNotifierEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Notifier Edit";
            this.Load += new System.EventHandler(this.AudioNotifierEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warningVolumePercTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningRepeatCountNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorVolumePercTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRepeatCountNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodVolumePercTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodRepeatCountNumericUpDown)).EndInit();
            this.warningGroupBox.ResumeLayout(false);
            this.warningGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar warningVolumePercTrackBar;
        private System.Windows.Forms.NumericUpDown warningRepeatCountNumericUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar errorVolumePercTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown errorRepeatCountNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdErrorBrowseAudioFile;
        private System.Windows.Forms.TextBox txtErrorAudioFilePath;
        private System.Windows.Forms.ComboBox cboErrorSystemSound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdErrorTestSound;
        private System.Windows.Forms.CheckBox chkErrorEnabled;
        private System.Windows.Forms.CheckBox chkErrorUseSystemSounds;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cmdWarningBrowseAudioFile;
        private System.Windows.Forms.OpenFileDialog soundOpenFileDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar goodVolumePercTrackBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown goodRepeatCountNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdGoodBrowseAudioFile;
        private System.Windows.Forms.TextBox txtGoodAudioFilePath;
        private System.Windows.Forms.ComboBox cboGoodSystemSound;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdGoodTestSound;
        private System.Windows.Forms.CheckBox chkGoodEnabled;
        private System.Windows.Forms.CheckBox chkGoodUseSystemSounds;
        private System.Windows.Forms.TextBox txtWarningAudioFilePath;
        private System.Windows.Forms.ComboBox cboWarningSystemSound;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdWarningTestSound;
        private System.Windows.Forms.CheckBox chkWarningEnabled;
        private System.Windows.Forms.CheckBox chkWarningUseSystemSounds;
        private System.Windows.Forms.GroupBox warningGroupBox;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}