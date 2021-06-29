
namespace QuickMon.UI
{
    partial class ProcessCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessCollectorEditEntry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMemErrorFormatted = new System.Windows.Forms.Label();
            this.lblMemWarningFormatted = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudThreadCountErr = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudThreadCountWarn = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMemErr = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudMemWarn = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudCPUErr = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCPUWarn = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMaxInstanceCount = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.nudMinInstanceCount = new System.Windows.Forms.NumericUpDown();
            this.cboTestType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkVerifyOnOK = new System.Windows.Forms.CheckBox();
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdBrowseProcesses = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCountErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCountWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCPUErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCPUWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxInstanceCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinInstanceCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblMemErrorFormatted);
            this.groupBox1.Controls.Add(this.lblMemWarningFormatted);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.nudThreadCountErr);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nudThreadCountWarn);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nudMemErr);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.nudMemWarn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudCPUErr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudCPUWarn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudMaxInstanceCount);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.nudMinInstanceCount);
            this.groupBox1.Controls.Add(this.cboTestType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 155);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test conditions";
            // 
            // lblMemErrorFormatted
            // 
            this.lblMemErrorFormatted.AutoSize = true;
            this.lblMemErrorFormatted.Location = new System.Drawing.Point(514, 126);
            this.lblMemErrorFormatted.Name = "lblMemErrorFormatted";
            this.lblMemErrorFormatted.Size = new System.Drawing.Size(10, 13);
            this.lblMemErrorFormatted.TabIndex = 20;
            this.lblMemErrorFormatted.Text = ".";
            // 
            // lblMemWarningFormatted
            // 
            this.lblMemWarningFormatted.AutoSize = true;
            this.lblMemWarningFormatted.Location = new System.Drawing.Point(220, 126);
            this.lblMemWarningFormatted.Name = "lblMemWarningFormatted";
            this.lblMemWarningFormatted.Size = new System.Drawing.Size(10, 13);
            this.lblMemWarningFormatted.TabIndex = 19;
            this.lblMemWarningFormatted.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(319, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Maximum";
            // 
            // nudThreadCountErr
            // 
            this.nudThreadCountErr.Location = new System.Drawing.Point(425, 72);
            this.nudThreadCountErr.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudThreadCountErr.Name = "nudThreadCountErr";
            this.nudThreadCountErr.Size = new System.Drawing.Size(83, 20);
            this.nudThreadCountErr.TabIndex = 9;
            this.nudThreadCountErr.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Thread count minumum";
            // 
            // nudThreadCountWarn
            // 
            this.nudThreadCountWarn.Location = new System.Drawing.Point(135, 72);
            this.nudThreadCountWarn.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudThreadCountWarn.Name = "nudThreadCountWarn";
            this.nudThreadCountWarn.Size = new System.Drawing.Size(79, 20);
            this.nudThreadCountWarn.TabIndex = 7;
            this.nudThreadCountWarn.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mem (KB) Error";
            // 
            // nudMemErr
            // 
            this.nudMemErr.Location = new System.Drawing.Point(425, 124);
            this.nudMemErr.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.nudMemErr.Name = "nudMemErr";
            this.nudMemErr.Size = new System.Drawing.Size(83, 20);
            this.nudMemErr.TabIndex = 18;
            this.nudMemErr.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMemErr.ValueChanged += new System.EventHandler(this.nudMemErr_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Mem (KB) Warning";
            // 
            // nudMemWarn
            // 
            this.nudMemWarn.Location = new System.Drawing.Point(135, 124);
            this.nudMemWarn.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.nudMemWarn.Name = "nudMemWarn";
            this.nudMemWarn.Size = new System.Drawing.Size(79, 20);
            this.nudMemWarn.TabIndex = 16;
            this.nudMemWarn.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMemWarn.ValueChanged += new System.EventHandler(this.nudMemWarn_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "CPU % Error";
            // 
            // nudCPUErr
            // 
            this.nudCPUErr.Location = new System.Drawing.Point(425, 98);
            this.nudCPUErr.Name = "nudCPUErr";
            this.nudCPUErr.Size = new System.Drawing.Size(83, 20);
            this.nudCPUErr.TabIndex = 14;
            this.nudCPUErr.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "CPU % Warning";
            // 
            // nudCPUWarn
            // 
            this.nudCPUWarn.Location = new System.Drawing.Point(135, 98);
            this.nudCPUWarn.Name = "nudCPUWarn";
            this.nudCPUWarn.Size = new System.Drawing.Size(79, 20);
            this.nudCPUWarn.TabIndex = 12;
            this.nudCPUWarn.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Maximum";
            // 
            // nudMaxInstanceCount
            // 
            this.nudMaxInstanceCount.Location = new System.Drawing.Point(425, 46);
            this.nudMaxInstanceCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMaxInstanceCount.Name = "nudMaxInstanceCount";
            this.nudMaxInstanceCount.Size = new System.Drawing.Size(83, 20);
            this.nudMaxInstanceCount.TabIndex = 5;
            this.nudMaxInstanceCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Instance count Minimum";
            // 
            // nudMinInstanceCount
            // 
            this.nudMinInstanceCount.Location = new System.Drawing.Point(135, 46);
            this.nudMinInstanceCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMinInstanceCount.Name = "nudMinInstanceCount";
            this.nudMinInstanceCount.Size = new System.Drawing.Size(79, 20);
            this.nudMinInstanceCount.TabIndex = 3;
            this.nudMinInstanceCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboTestType
            // 
            this.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestType.FormattingEnabled = true;
            this.cboTestType.Items.AddRange(new object[] {
            "Instance Running (any number)",
            "Instance Not Running",
            "Instance Count",
            "Thread Count",
            "Processor Usage",
            "Memory Usage"});
            this.cboTestType.Location = new System.Drawing.Point(135, 19);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(178, 21);
            this.cboTestType.TabIndex = 1;
            this.cboTestType.SelectedIndexChanged += new System.EventHandler(this.cboTestType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Alert trigger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Process filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFilter.Location = new System.Drawing.Point(142, 65);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(467, 20);
            this.txtFilter.TabIndex = 5;
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Items.AddRange(new object[] {
            "Process name",
            "Executable name",
            "Display name",
            "Full path",
            "Startup command line"});
            this.cboFilterType.Location = new System.Drawing.Point(142, 38);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(178, 21);
            this.cboFilterType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name/description";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(142, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(505, 20);
            this.txtName.TabIndex = 1;
            // 
            // chkVerifyOnOK
            // 
            this.chkVerifyOnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerifyOnOK.AutoSize = true;
            this.chkVerifyOnOK.Checked = true;
            this.chkVerifyOnOK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyOnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVerifyOnOK.Location = new System.Drawing.Point(283, 259);
            this.chkVerifyOnOK.Name = "chkVerifyOnOK";
            this.chkVerifyOnOK.Size = new System.Drawing.Size(120, 17);
            this.chkVerifyOnOK.TabIndex = 7;
            this.chkVerifyOnOK.Text = "Test on clicking \'OK\'";
            this.chkVerifyOnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerifyOnOK.UseVisualStyleBackColor = true;
            this.chkVerifyOnOK.Visible = false;
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTest.Location = new System.Drawing.Point(410, 255);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 8;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(572, 255);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(491, 255);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdBrowseProcesses
            // 
            this.cmdBrowseProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseProcesses.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdBrowseProcesses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowseProcesses.Location = new System.Drawing.Point(615, 63);
            this.cmdBrowseProcesses.Name = "cmdBrowseProcesses";
            this.cmdBrowseProcesses.Size = new System.Drawing.Size(36, 23);
            this.cmdBrowseProcesses.TabIndex = 11;
            this.cmdBrowseProcesses.Text = "- - -";
            this.cmdBrowseProcesses.UseVisualStyleBackColor = true;
            this.cmdBrowseProcesses.Click += new System.EventHandler(this.cmdBrowseProcesses_Click);
            // 
            // ProcessCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 290);
            this.Controls.Add(this.cmdBrowseProcesses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cboFilterType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkVerifyOnOK);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Process Entry";
            this.Load += new System.EventHandler(this.ProcessCollectorEditEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCountErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCountWarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemWarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCPUErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCPUWarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxInstanceCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinInstanceCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkVerifyOnOK;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTestType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMaxInstanceCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudMinInstanceCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCPUErr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCPUWarn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudThreadCountErr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudThreadCountWarn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMemErr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudMemWarn;
        private System.Windows.Forms.Button cmdBrowseProcesses;
        private System.Windows.Forms.Label lblMemWarningFormatted;
        private System.Windows.Forms.Label lblMemErrorFormatted;
    }
}