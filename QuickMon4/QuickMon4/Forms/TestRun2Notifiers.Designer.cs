namespace QuickMon
{
    partial class TestRun2Notifiers
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSMTPServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.chkEventLog = new System.Windows.Forms.CheckBox();
            this.chkLogFile = new System.Windows.Forms.CheckBox();
            this.chkSMTP = new System.Windows.Forms.CheckBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.txtAlerts = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudConcurency = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurency)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRunTest
            // 
            this.cmdRunTest.Location = new System.Drawing.Point(12, 12);
            this.cmdRunTest.Name = "cmdRunTest";
            this.cmdRunTest.Size = new System.Drawing.Size(75, 23);
            this.cmdRunTest.TabIndex = 1;
            this.cmdRunTest.Text = "Run";
            this.cmdRunTest.UseVisualStyleBackColor = true;
            this.cmdRunTest.Click += new System.EventHandler(this.cmdRunTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtEmailAddress);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSMTPServer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtLogFile);
            this.groupBox2.Controls.Add(this.chkEventLog);
            this.groupBox2.Controls.Add(this.chkLogFile);
            this.groupBox2.Controls.Add(this.chkSMTP);
            this.groupBox2.Location = new System.Drawing.Point(23, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 122);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agent types";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailAddress.Location = new System.Drawing.Point(119, 90);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(286, 20);
            this.txtEmailAddress.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Address";
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMTPServer.Location = new System.Drawing.Point(119, 64);
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(286, 20);
            this.txtSMTPServer.TabIndex = 6;
            this.txtSMTPServer.Text = "smtp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server";
            // 
            // txtLogFile
            // 
            this.txtLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogFile.Location = new System.Drawing.Point(78, 40);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(327, 20);
            this.txtLogFile.TabIndex = 4;
            this.txtLogFile.Text = "c:\\Temp\\QuickMon4.log";
            // 
            // chkEventLog
            // 
            this.chkEventLog.AutoSize = true;
            this.chkEventLog.Location = new System.Drawing.Point(12, 19);
            this.chkEventLog.Name = "chkEventLog";
            this.chkEventLog.Size = new System.Drawing.Size(72, 17);
            this.chkEventLog.TabIndex = 3;
            this.chkEventLog.Text = "EventLog";
            this.chkEventLog.UseVisualStyleBackColor = true;
            // 
            // chkLogFile
            // 
            this.chkLogFile.AutoSize = true;
            this.chkLogFile.Location = new System.Drawing.Point(12, 42);
            this.chkLogFile.Name = "chkLogFile";
            this.chkLogFile.Size = new System.Drawing.Size(60, 17);
            this.chkLogFile.TabIndex = 2;
            this.chkLogFile.Text = "Log file";
            this.chkLogFile.UseVisualStyleBackColor = true;
            // 
            // chkSMTP
            // 
            this.chkSMTP.AutoSize = true;
            this.chkSMTP.Location = new System.Drawing.Point(12, 66);
            this.chkSMTP.Name = "chkSMTP";
            this.chkSMTP.Size = new System.Drawing.Size(56, 17);
            this.chkSMTP.TabIndex = 0;
            this.chkSMTP.Text = "SMTP";
            this.chkSMTP.UseVisualStyleBackColor = true;
            // 
            // cmdClear
            // 
            this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClear.Location = new System.Drawing.Point(375, 12);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(59, 23);
            this.cmdClear.TabIndex = 10;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            // 
            // txtAlerts
            // 
            this.txtAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlerts.Location = new System.Drawing.Point(3, 169);
            this.txtAlerts.Multiline = true;
            this.txtAlerts.Name = "txtAlerts";
            this.txtAlerts.ReadOnly = true;
            this.txtAlerts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlerts.Size = new System.Drawing.Size(443, 178);
            this.txtAlerts.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Threads";
            // 
            // nudConcurency
            // 
            this.nudConcurency.Location = new System.Drawing.Point(149, 15);
            this.nudConcurency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConcurency.Name = "nudConcurency";
            this.nudConcurency.Size = new System.Drawing.Size(51, 20);
            this.nudConcurency.TabIndex = 13;
            this.nudConcurency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TestRun2Notifiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudConcurency);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.txtAlerts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdRunTest);
            this.Name = "TestRun2Notifiers";
            this.Text = "TestRun2Notifiers";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRunTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkEventLog;
        private System.Windows.Forms.CheckBox chkLogFile;
        private System.Windows.Forms.CheckBox chkSMTP;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.TextBox txtAlerts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudConcurency;
    }
}