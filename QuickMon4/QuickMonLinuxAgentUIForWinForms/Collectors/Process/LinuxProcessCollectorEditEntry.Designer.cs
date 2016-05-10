namespace QuickMon.Collectors
{
    partial class LinuxProcessCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxProcessCollectorEditEntry));
            this.lblEditSSHConnection = new System.Windows.Forms.LinkLabel();
            this.txtSSHConnection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboProcessCheckOption = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.topProcessCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.topXMemPercErrNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.topXMemPercWarnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.topXCPUPercErrNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.topXCPUPercWarnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.memPercErrNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.memPercWarnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cpuPercErrNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.cpuPercWarnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblAutoAdd = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.lblAddFileSystem = new System.Windows.Forms.LinkLabel();
            this.lvwProcesses = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpuWarningColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpuErrorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memWarningColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memErrorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.topProcessCountUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topXMemPercErrNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topXMemPercWarnNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topXCPUPercErrNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topXCPUPercWarnNumericUpDown)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memPercErrNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPercWarnNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuPercErrNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuPercWarnNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEditSSHConnection
            // 
            this.lblEditSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditSSHConnection.AutoSize = true;
            this.lblEditSSHConnection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblEditSSHConnection.Location = new System.Drawing.Point(495, 9);
            this.lblEditSSHConnection.Name = "lblEditSSHConnection";
            this.lblEditSSHConnection.Size = new System.Drawing.Size(25, 13);
            this.lblEditSSHConnection.TabIndex = 1;
            this.lblEditSSHConnection.TabStop = true;
            this.lblEditSSHConnection.Text = "Edit";
            // 
            // txtSSHConnection
            // 
            this.txtSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSSHConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSSHConnection.Location = new System.Drawing.Point(12, 25);
            this.txtSSHConnection.Multiline = true;
            this.txtSSHConnection.Name = "txtSSHConnection";
            this.txtSSHConnection.ReadOnly = true;
            this.txtSSHConnection.Size = new System.Drawing.Size(508, 45);
            this.txtSSHConnection.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "SSH Connection details";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 89);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(508, 20);
            this.txtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name/Description";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Check Option";
            // 
            // cboProcessCheckOption
            // 
            this.cboProcessCheckOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcessCheckOption.FormattingEnabled = true;
            this.cboProcessCheckOption.Items.AddRange(new object[] {
            "Top X By CPU",
            "Top X By Mem",
            "Specified"});
            this.cboProcessCheckOption.Location = new System.Drawing.Point(99, 115);
            this.cboProcessCheckOption.Name = "cboProcessCheckOption";
            this.cboProcessCheckOption.Size = new System.Drawing.Size(125, 21);
            this.cboProcessCheckOption.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Location = new System.Drawing.Point(250, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Top X processes";
            // 
            // topProcessCountUpDown
            // 
            this.topProcessCountUpDown.Location = new System.Drawing.Point(347, 116);
            this.topProcessCountUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.topProcessCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.topProcessCountUpDown.Name = "topProcessCountUpDown";
            this.topProcessCountUpDown.Size = new System.Drawing.Size(62, 20);
            this.topProcessCountUpDown.TabIndex = 8;
            this.topProcessCountUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU usage % Warning";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Location = new System.Drawing.Point(229, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Error";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.topXMemPercErrNumericUpDown);
            this.groupBox1.Controls.Add(this.topXMemPercWarnNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.topXCPUPercErrNumericUpDown);
            this.groupBox1.Controls.Add(this.topXCPUPercWarnNumericUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 71);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Top X criteria";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(380, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Set values to 0 to ignore";
            // 
            // topXMemPercErrNumericUpDown
            // 
            this.topXMemPercErrNumericUpDown.Location = new System.Drawing.Point(264, 42);
            this.topXMemPercErrNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.topXMemPercErrNumericUpDown.Name = "topXMemPercErrNumericUpDown";
            this.topXMemPercErrNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.topXMemPercErrNumericUpDown.TabIndex = 7;
            this.topXMemPercErrNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // topXMemPercWarnNumericUpDown
            // 
            this.topXMemPercWarnNumericUpDown.Location = new System.Drawing.Point(127, 42);
            this.topXMemPercWarnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.topXMemPercWarnNumericUpDown.Name = "topXMemPercWarnNumericUpDown";
            this.topXMemPercWarnNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.topXMemPercWarnNumericUpDown.TabIndex = 5;
            this.topXMemPercWarnNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mem usage % Warning";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Location = new System.Drawing.Point(229, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Error";
            // 
            // topXCPUPercErrNumericUpDown
            // 
            this.topXCPUPercErrNumericUpDown.Location = new System.Drawing.Point(264, 16);
            this.topXCPUPercErrNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.topXCPUPercErrNumericUpDown.Name = "topXCPUPercErrNumericUpDown";
            this.topXCPUPercErrNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.topXCPUPercErrNumericUpDown.TabIndex = 3;
            this.topXCPUPercErrNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // topXCPUPercWarnNumericUpDown
            // 
            this.topXCPUPercWarnNumericUpDown.Location = new System.Drawing.Point(127, 16);
            this.topXCPUPercWarnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.topXCPUPercWarnNumericUpDown.Name = "topXCPUPercWarnNumericUpDown";
            this.topXCPUPercWarnNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.topXCPUPercWarnNumericUpDown.TabIndex = 1;
            this.topXCPUPercWarnNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(283, 441);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 11;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(364, 441);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(445, 441);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.memPercErrNumericUpDown);
            this.groupBox6.Controls.Add(this.memPercWarnNumericUpDown);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.cpuPercErrNumericUpDown);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.cpuPercWarnNumericUpDown);
            this.groupBox6.Controls.Add(this.lblAutoAdd);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtProcessName);
            this.groupBox6.Controls.Add(this.lblAddFileSystem);
            this.groupBox6.Controls.Add(this.lvwProcesses);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox6.Location = new System.Drawing.Point(12, 219);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(520, 216);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Specific entries";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label15.Location = new System.Drawing.Point(392, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Set values to 0 to ignore";
            // 
            // memPercErrNumericUpDown
            // 
            this.memPercErrNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memPercErrNumericUpDown.Location = new System.Drawing.Point(264, 186);
            this.memPercErrNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.memPercErrNumericUpDown.Name = "memPercErrNumericUpDown";
            this.memPercErrNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.memPercErrNumericUpDown.TabIndex = 13;
            this.memPercErrNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.memPercErrNumericUpDown.ValueChanged += new System.EventHandler(this.memPercErrNumericUpDown_ValueChanged);
            // 
            // memPercWarnNumericUpDown
            // 
            this.memPercWarnNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memPercWarnNumericUpDown.Location = new System.Drawing.Point(127, 186);
            this.memPercWarnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.memPercWarnNumericUpDown.Name = "memPercWarnNumericUpDown";
            this.memPercWarnNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.memPercWarnNumericUpDown.TabIndex = 11;
            this.memPercWarnNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.memPercWarnNumericUpDown.ValueChanged += new System.EventHandler(this.memPercWarnNumericUpDown_ValueChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Location = new System.Drawing.Point(6, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Mem usage % Warning";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label13.Location = new System.Drawing.Point(229, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Error";
            // 
            // cpuPercErrNumericUpDown
            // 
            this.cpuPercErrNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cpuPercErrNumericUpDown.Location = new System.Drawing.Point(264, 160);
            this.cpuPercErrNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cpuPercErrNumericUpDown.Name = "cpuPercErrNumericUpDown";
            this.cpuPercErrNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.cpuPercErrNumericUpDown.TabIndex = 9;
            this.cpuPercErrNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.cpuPercErrNumericUpDown.ValueChanged += new System.EventHandler(this.cpuPercErrNumericUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label11.Location = new System.Drawing.Point(6, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "CPU usage % Warning";
            // 
            // cpuPercWarnNumericUpDown
            // 
            this.cpuPercWarnNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cpuPercWarnNumericUpDown.Location = new System.Drawing.Point(127, 160);
            this.cpuPercWarnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cpuPercWarnNumericUpDown.Name = "cpuPercWarnNumericUpDown";
            this.cpuPercWarnNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.cpuPercWarnNumericUpDown.TabIndex = 7;
            this.cpuPercWarnNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.cpuPercWarnNumericUpDown.ValueChanged += new System.EventHandler(this.cpuPercWarnNumericUpDown_ValueChanged);
            // 
            // lblAutoAdd
            // 
            this.lblAutoAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAutoAdd.AutoSize = true;
            this.lblAutoAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAutoAdd.Location = new System.Drawing.Point(435, 16);
            this.lblAutoAdd.Name = "lblAutoAdd";
            this.lblAutoAdd.Size = new System.Drawing.Size(80, 13);
            this.lblAutoAdd.TabIndex = 2;
            this.lblAutoAdd.TabStop = true;
            this.lblAutoAdd.Text = "Browse running";
            this.lblAutoAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAutoAdd_LinkClicked);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Process name";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessName.Location = new System.Drawing.Point(127, 134);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(387, 20);
            this.txtProcessName.TabIndex = 5;
            this.txtProcessName.TextChanged += new System.EventHandler(this.txtProcessName_TextChanged);
            // 
            // lblAddFileSystem
            // 
            this.lblAddFileSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddFileSystem.AutoSize = true;
            this.lblAddFileSystem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAddFileSystem.Location = new System.Drawing.Point(379, 16);
            this.lblAddFileSystem.Name = "lblAddFileSystem";
            this.lblAddFileSystem.Size = new System.Drawing.Size(49, 13);
            this.lblAddFileSystem.TabIndex = 1;
            this.lblAddFileSystem.TabStop = true;
            this.lblAddFileSystem.Text = "Add new";
            this.lblAddFileSystem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddFileSystem_LinkClicked);
            // 
            // lvwProcesses
            // 
            this.lvwProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProcesses.AutoResizeColumnEnabled = false;
            this.lvwProcesses.AutoResizeColumnIndex = 0;
            this.lvwProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.cpuWarningColumnHeader,
            this.cpuErrorColumnHeader,
            this.memWarningColumnHeader,
            this.memErrorColumnHeader});
            this.lvwProcesses.FullRowSelect = true;
            this.lvwProcesses.Location = new System.Drawing.Point(8, 32);
            this.lvwProcesses.Name = "lvwProcesses";
            this.lvwProcesses.Size = new System.Drawing.Size(506, 96);
            this.lvwProcesses.TabIndex = 3;
            this.lvwProcesses.UseCompatibleStateImageBehavior = false;
            this.lvwProcesses.View = System.Windows.Forms.View.Details;
            this.lvwProcesses.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwProcesses_DeleteKeyPressed);
            this.lvwProcesses.SelectedIndexChanged += new System.EventHandler(this.lvwProcesses_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 223;
            // 
            // cpuWarningColumnHeader
            // 
            this.cpuWarningColumnHeader.Text = "Cpu warn";
            this.cpuWarningColumnHeader.Width = 63;
            // 
            // cpuErrorColumnHeader
            // 
            this.cpuErrorColumnHeader.Text = "Cpu err";
            // 
            // memWarningColumnHeader
            // 
            this.memWarningColumnHeader.Text = "Mem warn";
            this.memWarningColumnHeader.Width = 71;
            // 
            // memErrorColumnHeader
            // 
            this.memErrorColumnHeader.Text = "Mem err";
            this.memErrorColumnHeader.Width = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Processes";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label23.Location = new System.Drawing.Point(229, 162);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "Error";
            // 
            // LinuxProcessCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 476);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.topProcessCountUpDown);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboProcessCheckOption);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEditSSHConnection);
            this.Controls.Add(this.txtSSHConnection);
            this.Controls.Add(this.label9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 513);
            this.Name = "LinuxProcessCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Collector";
            this.Load += new System.EventHandler(this.LinuxProcessCollectorEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.topProcessCountUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topXMemPercErrNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topXMemPercWarnNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topXCPUPercErrNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topXCPUPercWarnNumericUpDown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memPercErrNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPercWarnNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuPercErrNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuPercWarnNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblEditSSHConnection;
        private System.Windows.Forms.TextBox txtSSHConnection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboProcessCheckOption;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown topProcessCountUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown topXMemPercErrNumericUpDown;
        private System.Windows.Forms.NumericUpDown topXMemPercWarnNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown topXCPUPercErrNumericUpDown;
        private System.Windows.Forms.NumericUpDown topXCPUPercWarnNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown memPercErrNumericUpDown;
        private System.Windows.Forms.NumericUpDown memPercWarnNumericUpDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown cpuPercErrNumericUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown cpuPercWarnNumericUpDown;
        private System.Windows.Forms.LinkLabel lblAutoAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.LinkLabel lblAddFileSystem;
        private ListViewEx lvwProcesses;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader cpuWarningColumnHeader;
        private System.Windows.Forms.ColumnHeader cpuErrorColumnHeader;
        private System.Windows.Forms.ColumnHeader memWarningColumnHeader;
        private System.Windows.Forms.ColumnHeader memErrorColumnHeader;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label23;
    }
}