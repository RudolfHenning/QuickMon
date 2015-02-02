namespace QuickMon
{
    partial class TestRun1
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
            this.cmdRunTest = new System.Windows.Forms.Button();
            this.chkRemoteHost = new System.Windows.Forms.CheckBox();
            this.txtRemoteHost = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opt1stError = new System.Windows.Forms.RadioButton();
            this.opt1stSuccess = new System.Windows.Forms.RadioButton();
            this.optAll = new System.Windows.Forms.RadioButton();
            this.nudConcurency = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClear = new System.Windows.Forms.Button();
            this.txtAlerts = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEventLog = new System.Windows.Forms.CheckBox();
            this.chkFileFolder = new System.Windows.Forms.CheckBox();
            this.chkPerfCounters = new System.Windows.Forms.CheckBox();
            this.chkServices = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.WaitingPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurency)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRunTest
            // 
            this.cmdRunTest.Location = new System.Drawing.Point(12, 12);
            this.cmdRunTest.Name = "cmdRunTest";
            this.cmdRunTest.Size = new System.Drawing.Size(75, 23);
            this.cmdRunTest.TabIndex = 0;
            this.cmdRunTest.Text = "Run";
            this.cmdRunTest.UseVisualStyleBackColor = true;
            this.cmdRunTest.Click += new System.EventHandler(this.cmdRunTest_Click);
            // 
            // chkRemoteHost
            // 
            this.chkRemoteHost.AutoSize = true;
            this.chkRemoteHost.Location = new System.Drawing.Point(12, 43);
            this.chkRemoteHost.Name = "chkRemoteHost";
            this.chkRemoteHost.Size = new System.Drawing.Size(103, 17);
            this.chkRemoteHost.TabIndex = 3;
            this.chkRemoteHost.Text = "Use remote host";
            this.chkRemoteHost.UseVisualStyleBackColor = true;
            // 
            // txtRemoteHost
            // 
            this.txtRemoteHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteHost.Location = new System.Drawing.Point(121, 41);
            this.txtRemoteHost.Name = "txtRemoteHost";
            this.txtRemoteHost.Size = new System.Drawing.Size(449, 20);
            this.txtRemoteHost.TabIndex = 4;
            this.txtRemoteHost.Text = "localhost";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.opt1stError);
            this.groupBox1.Controls.Add(this.opt1stSuccess);
            this.groupBox1.Controls.Add(this.optAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 41);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agent check sequence";
            // 
            // opt1stError
            // 
            this.opt1stError.AutoSize = true;
            this.opt1stError.Location = new System.Drawing.Point(149, 19);
            this.opt1stError.Name = "opt1stError";
            this.opt1stError.Size = new System.Drawing.Size(64, 17);
            this.opt1stError.TabIndex = 2;
            this.opt1stError.Text = "1st Error";
            this.opt1stError.UseVisualStyleBackColor = true;
            // 
            // opt1stSuccess
            // 
            this.opt1stSuccess.AutoSize = true;
            this.opt1stSuccess.Location = new System.Drawing.Point(60, 19);
            this.opt1stSuccess.Name = "opt1stSuccess";
            this.opt1stSuccess.Size = new System.Drawing.Size(83, 17);
            this.opt1stSuccess.TabIndex = 1;
            this.opt1stSuccess.Text = "1st Success";
            this.opt1stSuccess.UseVisualStyleBackColor = true;
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Checked = true;
            this.optAll.Location = new System.Drawing.Point(18, 19);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(36, 17);
            this.optAll.TabIndex = 0;
            this.optAll.TabStop = true;
            this.optAll.Text = "All";
            this.optAll.UseVisualStyleBackColor = true;
            // 
            // nudConcurency
            // 
            this.nudConcurency.Location = new System.Drawing.Point(155, 15);
            this.nudConcurency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConcurency.Name = "nudConcurency";
            this.nudConcurency.Size = new System.Drawing.Size(51, 20);
            this.nudConcurency.TabIndex = 2;
            this.nudConcurency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Threads";
            // 
            // cmdClear
            // 
            this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClear.Location = new System.Drawing.Point(495, 144);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 23);
            this.cmdClear.TabIndex = 8;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // txtAlerts
            // 
            this.txtAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlerts.Location = new System.Drawing.Point(1, 173);
            this.txtAlerts.Multiline = true;
            this.txtAlerts.Name = "txtAlerts";
            this.txtAlerts.ReadOnly = true;
            this.txtAlerts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlerts.Size = new System.Drawing.Size(580, 221);
            this.txtAlerts.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEventLog);
            this.groupBox2.Controls.Add(this.chkFileFolder);
            this.groupBox2.Controls.Add(this.chkPerfCounters);
            this.groupBox2.Controls.Add(this.chkServices);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 46);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agent types";
            // 
            // chkEventLog
            // 
            this.chkEventLog.AutoSize = true;
            this.chkEventLog.Location = new System.Drawing.Point(212, 23);
            this.chkEventLog.Name = "chkEventLog";
            this.chkEventLog.Size = new System.Drawing.Size(72, 17);
            this.chkEventLog.TabIndex = 3;
            this.chkEventLog.Text = "EventLog";
            this.chkEventLog.UseVisualStyleBackColor = true;
            // 
            // chkFileFolder
            // 
            this.chkFileFolder.AutoSize = true;
            this.chkFileFolder.Location = new System.Drawing.Point(164, 23);
            this.chkFileFolder.Name = "chkFileFolder";
            this.chkFileFolder.Size = new System.Drawing.Size(42, 17);
            this.chkFileFolder.TabIndex = 2;
            this.chkFileFolder.Text = "File";
            this.chkFileFolder.UseVisualStyleBackColor = true;
            // 
            // chkPerfCounters
            // 
            this.chkPerfCounters.AutoSize = true;
            this.chkPerfCounters.Location = new System.Drawing.Point(91, 23);
            this.chkPerfCounters.Name = "chkPerfCounters";
            this.chkPerfCounters.Size = new System.Drawing.Size(67, 17);
            this.chkPerfCounters.TabIndex = 1;
            this.chkPerfCounters.Text = "Perf Cntr";
            this.chkPerfCounters.UseVisualStyleBackColor = true;
            // 
            // chkServices
            // 
            this.chkServices.AutoSize = true;
            this.chkServices.Location = new System.Drawing.Point(18, 23);
            this.chkServices.Name = "chkServices";
            this.chkServices.Size = new System.Drawing.Size(67, 17);
            this.chkServices.TabIndex = 0;
            this.chkServices.Text = "Services";
            this.chkServices.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtHostName);
            this.groupBox3.Location = new System.Drawing.Point(241, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 41);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Run for computers";
            // 
            // txtHostName
            // 
            this.txtHostName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHostName.Location = new System.Drawing.Point(6, 15);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(317, 20);
            this.txtHostName.TabIndex = 0;
            this.txtHostName.Text = "localhost";
            // 
            // WaitingPictureBox
            // 
            this.WaitingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WaitingPictureBox.Image = global::QuickMon.Properties.Resources.animated;
            this.WaitingPictureBox.Location = new System.Drawing.Point(224, 173);
            this.WaitingPictureBox.Name = "WaitingPictureBox";
            this.WaitingPictureBox.Size = new System.Drawing.Size(104, 102);
            this.WaitingPictureBox.TabIndex = 10;
            this.WaitingPictureBox.TabStop = false;
            // 
            // TestRun1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 396);
            this.Controls.Add(this.WaitingPictureBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.txtAlerts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudConcurency);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkRemoteHost);
            this.Controls.Add(this.txtRemoteHost);
            this.Controls.Add(this.cmdRunTest);
            this.Name = "TestRun1";
            this.Text = "TestRun1";
            this.Load += new System.EventHandler(this.TestRun1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurency)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaitingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRunTest;
        private System.Windows.Forms.CheckBox chkRemoteHost;
        private System.Windows.Forms.TextBox txtRemoteHost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton opt1stError;
        private System.Windows.Forms.RadioButton opt1stSuccess;
        private System.Windows.Forms.RadioButton optAll;
        private System.Windows.Forms.NumericUpDown nudConcurency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.TextBox txtAlerts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkServices;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.CheckBox chkPerfCounters;
        private System.Windows.Forms.CheckBox chkFileFolder;
        private System.Windows.Forms.CheckBox chkEventLog;
        private System.Windows.Forms.PictureBox WaitingPictureBox;
    }
}