namespace QuickMon.UI
{
    partial class PerfCounterCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerfCounterCollectorEditEntry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboInstanceValueAggregation = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkInverseScale = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nudValueScale = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudMultiSampleWaitMS = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudNumberOfSamplesPerRefresh = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdEditPerfCounter = new System.Windows.Forms.Button();
            this.txtPerfCounter = new System.Windows.Forms.TextBox();
            this.optCustom = new System.Windows.Forms.RadioButton();
            this.cboPerformanceCounter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.optCommon = new System.Windows.Forms.RadioButton();
            this.cmdSample = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboOutputValueUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVerifyOnOK = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSampleWaitMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfSamplesPerRefresh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboInstanceValueAggregation);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.chkInverseScale);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nudValueScale);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.nudMultiSampleWaitMS);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudNumberOfSamplesPerRefresh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdEditPerfCounter);
            this.groupBox1.Controls.Add(this.txtPerfCounter);
            this.groupBox1.Controls.Add(this.optCustom);
            this.groupBox1.Controls.Add(this.cboPerformanceCounter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtComputerName);
            this.groupBox1.Controls.Add(this.lblComputerName);
            this.groupBox1.Controls.Add(this.optCommon);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Performance counter definition";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(161, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(310, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "You can use * in the instance name. This implies multi instancing";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(277, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(217, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "None = avg value when multi sample is used";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // cboInstanceValueAggregation
            // 
            this.cboInstanceValueAggregation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInstanceValueAggregation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstanceValueAggregation.FormattingEnabled = true;
            this.cboInstanceValueAggregation.Items.AddRange(new object[] {
            "None",
            "Sum",
            "Average",
            "Minimum",
            "Maximum",
            "First",
            "Last",
            "Count"});
            this.cboInstanceValueAggregation.Location = new System.Drawing.Point(164, 188);
            this.cboInstanceValueAggregation.Name = "cboInstanceValueAggregation";
            this.cboInstanceValueAggregation.Size = new System.Drawing.Size(107, 21);
            this.cboInstanceValueAggregation.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Multi sample aggregation";
            this.toolTip1.SetToolTip(this.label12, "When using this feature all instances of the specified counter are used - and not" +
        " just the specified instance");
            // 
            // chkInverseScale
            // 
            this.chkInverseScale.AutoSize = true;
            this.chkInverseScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInverseScale.Location = new System.Drawing.Point(277, 215);
            this.chkInverseScale.Name = "chkInverseScale";
            this.chkInverseScale.Size = new System.Drawing.Size(102, 17);
            this.chkInverseScale.TabIndex = 22;
            this.chkInverseScale.Text = "Inverse (x/scale)";
            this.chkInverseScale.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label11.Location = new System.Drawing.Point(6, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Value Scale factor";
            // 
            // nudValueScale
            // 
            this.nudValueScale.Location = new System.Drawing.Point(164, 215);
            this.nudValueScale.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.nudValueScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudValueScale.Name = "nudValueScale";
            this.nudValueScale.Size = new System.Drawing.Size(107, 20);
            this.nudValueScale.TabIndex = 21;
            this.nudValueScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(399, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "ms between samples";
            this.toolTip1.SetToolTip(this.label10, "Milliseconds between samples");
            // 
            // nudMultiSampleWaitMS
            // 
            this.nudMultiSampleWaitMS.Location = new System.Drawing.Point(327, 162);
            this.nudMultiSampleWaitMS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMultiSampleWaitMS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMultiSampleWaitMS.Name = "nudMultiSampleWaitMS";
            this.nudMultiSampleWaitMS.Size = new System.Drawing.Size(66, 20);
            this.nudMultiSampleWaitMS.TabIndex = 15;
            this.nudMultiSampleWaitMS.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(292, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Wait";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Times";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Repeat";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudNumberOfSamplesPerRefresh
            // 
            this.nudNumberOfSamplesPerRefresh.Location = new System.Drawing.Point(164, 162);
            this.nudNumberOfSamplesPerRefresh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfSamplesPerRefresh.Name = "nudNumberOfSamplesPerRefresh";
            this.nudNumberOfSamplesPerRefresh.Size = new System.Drawing.Size(66, 20);
            this.nudNumberOfSamplesPerRefresh.TabIndex = 12;
            this.nudNumberOfSamplesPerRefresh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Multi sampling";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Performance counter";
            // 
            // cmdEditPerfCounter
            // 
            this.cmdEditPerfCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditPerfCounter.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdEditPerfCounter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdEditPerfCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEditPerfCounter.Location = new System.Drawing.Point(473, 114);
            this.cmdEditPerfCounter.Name = "cmdEditPerfCounter";
            this.cmdEditPerfCounter.Size = new System.Drawing.Size(41, 23);
            this.cmdEditPerfCounter.TabIndex = 8;
            this.cmdEditPerfCounter.Text = "- - -";
            this.cmdEditPerfCounter.UseVisualStyleBackColor = true;
            this.cmdEditPerfCounter.Click += new System.EventHandler(this.cmdEditPerfCounter_Click);
            // 
            // txtPerfCounter
            // 
            this.txtPerfCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerfCounter.Location = new System.Drawing.Point(164, 116);
            this.txtPerfCounter.Name = "txtPerfCounter";
            this.txtPerfCounter.Size = new System.Drawing.Size(303, 20);
            this.txtPerfCounter.TabIndex = 7;
            this.txtPerfCounter.TextChanged += new System.EventHandler(this.txtPerfCounter_TextChanged);
            // 
            // optCustom
            // 
            this.optCustom.AutoSize = true;
            this.optCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optCustom.Location = new System.Drawing.Point(9, 99);
            this.optCustom.Name = "optCustom";
            this.optCustom.Size = new System.Drawing.Size(59, 17);
            this.optCustom.TabIndex = 5;
            this.optCustom.TabStop = true;
            this.optCustom.Text = "Custom";
            this.optCustom.UseVisualStyleBackColor = true;
            // 
            // cboPerformanceCounter
            // 
            this.cboPerformanceCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPerformanceCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerformanceCounter.FormattingEnabled = true;
            this.cboPerformanceCounter.Location = new System.Drawing.Point(164, 66);
            this.cboPerformanceCounter.Name = "cboPerformanceCounter";
            this.cboPerformanceCounter.Size = new System.Drawing.Size(350, 21);
            this.cboPerformanceCounter.TabIndex = 4;
            this.cboPerformanceCounter.SelectedIndexChanged += new System.EventHandler(this.cboPerformanceCounter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Performance counter";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputerName.Location = new System.Drawing.Point(164, 40);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(350, 20);
            this.txtComputerName.TabIndex = 2;
            this.txtComputerName.Text = ".";
            this.txtComputerName.TextChanged += new System.EventHandler(this.txtComputerName_TextChanged);
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(36, 43);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(81, 13);
            this.lblComputerName.TabIndex = 1;
            this.lblComputerName.Text = "Computer name";
            // 
            // optCommon
            // 
            this.optCommon.AutoSize = true;
            this.optCommon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optCommon.Location = new System.Drawing.Point(9, 19);
            this.optCommon.Name = "optCommon";
            this.optCommon.Size = new System.Drawing.Size(65, 17);
            this.optCommon.TabIndex = 0;
            this.optCommon.TabStop = true;
            this.optCommon.Text = "Common";
            this.optCommon.UseVisualStyleBackColor = true;
            this.optCommon.CheckedChanged += new System.EventHandler(this.optCommon_CheckedChanged);
            // 
            // cmdSample
            // 
            this.cmdSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSample.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdSample.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSample.Location = new System.Drawing.Point(280, 355);
            this.cmdSample.Name = "cmdSample";
            this.cmdSample.Size = new System.Drawing.Size(75, 23);
            this.cmdSample.TabIndex = 4;
            this.cmdSample.Text = "Test";
            this.cmdSample.UseVisualStyleBackColor = true;
            this.cmdSample.Click += new System.EventHandler(this.cmdSample_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.errorNumericUpDown);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.warningNumericUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(3, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alert triggering";
            // 
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.DecimalPlaces = 3;
            this.errorNumericUpDown.Location = new System.Drawing.Point(269, 19);
            this.errorNumericUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.errorNumericUpDown.TabIndex = 3;
            this.errorNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Warning";
            // 
            // warningNumericUpDown
            // 
            this.warningNumericUpDown.DecimalPlaces = 3;
            this.warningNumericUpDown.Location = new System.Drawing.Point(92, 19);
            this.warningNumericUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.warningNumericUpDown.TabIndex = 1;
            this.warningNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Location = new System.Drawing.Point(234, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Error";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(442, 355);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(361, 355);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cboOutputValueUnit);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(3, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 45);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display output";
            // 
            // cboOutputValueUnit
            // 
            this.cboOutputValueUnit.FormattingEnabled = true;
            this.cboOutputValueUnit.Items.AddRange(new object[] {
            "%",
            "byte(s)",
            "Bytes/sec",
            "C",
            "Connections",
            "GB",
            "KB",
            "IO/sec",
            "Item(s)",
            "MB",
            "Operations/sec",
            "Packets/sec",
            "Queued/sec",
            "Total/sec",
            "Transfers/sec"});
            this.cboOutputValueUnit.Location = new System.Drawing.Point(92, 18);
            this.cboOutputValueUnit.Name = "cboOutputValueUnit";
            this.cboOutputValueUnit.Size = new System.Drawing.Size(425, 21);
            this.cboOutputValueUnit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output unit";
            // 
            // chkVerifyOnOK
            // 
            this.chkVerifyOnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerifyOnOK.AutoSize = true;
            this.chkVerifyOnOK.Checked = true;
            this.chkVerifyOnOK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyOnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVerifyOnOK.Location = new System.Drawing.Point(154, 359);
            this.chkVerifyOnOK.Name = "chkVerifyOnOK";
            this.chkVerifyOnOK.Size = new System.Drawing.Size(120, 17);
            this.chkVerifyOnOK.TabIndex = 3;
            this.chkVerifyOnOK.Text = "Test on clicking \'OK\'";
            this.chkVerifyOnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerifyOnOK.UseVisualStyleBackColor = true;
            // 
            // PerfCounterCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 390);
            this.Controls.Add(this.chkVerifyOnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdSample);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerfCounterCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perf Counter Collector - Edit Entry";
            this.Load += new System.EventHandler(this.PerfCounterCollectorEditEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValueScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiSampleWaitMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfSamplesPerRefresh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPerformanceCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.RadioButton optCommon;
        private System.Windows.Forms.RadioButton optCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdEditPerfCounter;
        private System.Windows.Forms.TextBox txtPerfCounter;
        private System.Windows.Forms.Button cmdSample;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.NumericUpDown nudNumberOfSamplesPerRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMultiSampleWaitMS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboOutputValueUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudValueScale;
        private System.Windows.Forms.CheckBox chkInverseScale;
        private System.Windows.Forms.CheckBox chkVerifyOnOK;
        private System.Windows.Forms.ComboBox cboInstanceValueAggregation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label14;
    }
}