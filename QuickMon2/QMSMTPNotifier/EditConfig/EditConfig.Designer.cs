﻿namespace QuickMon
{
    partial class EditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConfig));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSMTPServer = new System.Windows.Forms.TextBox();
            this.chkUseDefultCredentials = new System.Windows.Forms.CheckBox();
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFromAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToAddress = new System.Windows.Forms.TextBox();
            this.chkIsBodyHtml = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkTLS = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtReplyToAddress = new System.Windows.Forms.TextBox();
            this.priorityGroupBox = new System.Windows.Forms.GroupBox();
            this.optPriorityLow = new System.Windows.Forms.RadioButton();
            this.optPriorityNormal = new System.Windows.Forms.RadioButton();
            this.optPriorityHigh = new System.Windows.Forms.RadioButton();
            this.groupBoxCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.priorityGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(424, 439);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(262, 439);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 23;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(343, 439);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 24;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP server";
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.Location = new System.Drawing.Point(92, 12);
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(278, 20);
            this.txtSMTPServer.TabIndex = 1;
            // 
            // chkUseDefultCredentials
            // 
            this.chkUseDefultCredentials.AutoSize = true;
            this.chkUseDefultCredentials.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseDefultCredentials.Location = new System.Drawing.Point(92, 38);
            this.chkUseDefultCredentials.Name = "chkUseDefultCredentials";
            this.chkUseDefultCredentials.Size = new System.Drawing.Size(133, 17);
            this.chkUseDefultCredentials.TabIndex = 4;
            this.chkUseDefultCredentials.Text = "Use default credentials";
            this.chkUseDefultCredentials.UseVisualStyleBackColor = true;
            this.chkUseDefultCredentials.CheckedChanged += new System.EventHandler(this.chkUseDefultCredentials_CheckedChanged);
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCredentials.Controls.Add(this.label4);
            this.groupBoxCredentials.Controls.Add(this.txtPassword);
            this.groupBoxCredentials.Controls.Add(this.label3);
            this.groupBoxCredentials.Controls.Add(this.txtUserName);
            this.groupBoxCredentials.Controls.Add(this.label2);
            this.groupBoxCredentials.Controls.Add(this.txtDomain);
            this.groupBoxCredentials.Location = new System.Drawing.Point(92, 61);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(305, 95);
            this.groupBoxCredentials.TabIndex = 6;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "Custom credentials";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(100, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(199, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User name";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(100, 45);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(199, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Domain";
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomain.Location = new System.Drawing.Point(100, 19);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(199, 20);
            this.txtDomain.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "From address";
            // 
            // txtFromAddress
            // 
            this.txtFromAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromAddress.Location = new System.Drawing.Point(92, 162);
            this.txtFromAddress.Name = "txtFromAddress";
            this.txtFromAddress.Size = new System.Drawing.Size(173, 20);
            this.txtFromAddress.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "To address(es)";
            this.toolTip1.SetToolTip(this.label6, "Use , (comma) to separate multiple addresses");
            // 
            // txtToAddress
            // 
            this.txtToAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToAddress.Location = new System.Drawing.Point(92, 188);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(407, 20);
            this.txtToAddress.TabIndex = 13;
            // 
            // chkIsBodyHtml
            // 
            this.chkIsBodyHtml.AutoSize = true;
            this.chkIsBodyHtml.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIsBodyHtml.Location = new System.Drawing.Point(92, 266);
            this.chkIsBodyHtml.Name = "chkIsBodyHtml";
            this.chkIsBodyHtml.Size = new System.Drawing.Size(92, 17);
            this.chkIsBodyHtml.TabIndex = 18;
            this.chkIsBodyHtml.Text = "Is body HTML";
            this.chkIsBodyHtml.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Subject *";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(92, 240);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(407, 20);
            this.txtSubject.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Body *";
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(92, 289);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(407, 83);
            this.txtBody.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 375);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(331, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "* Body and Subject may contain one or more of the following macros:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(48, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(424, 46);
            this.label10.TabIndex = 22;
            this.label10.Text = "%DateTime% %AlertLevel% %CurrentState% %PreviousState% \r\n%CollectorName% %Collect" +
    "orType% \r\n%Details% (Only applies to Body)";
            // 
            // chkTLS
            // 
            this.chkTLS.AutoSize = true;
            this.chkTLS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkTLS.Location = new System.Drawing.Point(235, 38);
            this.chkTLS.Name = "chkTLS";
            this.chkTLS.Size = new System.Drawing.Size(92, 17);
            this.chkTLS.TabIndex = 5;
            this.chkTLS.Text = "Use TLS/SSL";
            this.chkTLS.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(376, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Port";
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.Location = new System.Drawing.Point(409, 12);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.portNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.portNumericUpDown.TabIndex = 3;
            this.toolTip1.SetToolTip(this.portNumericUpDown, "SMTP default port - 25\r\nTSL default port - 587 \r\nOther ports - 465, 475, 2525");
            this.portNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Sender";
            this.toolTip1.SetToolTip(this.label12, "Use , (comma) to separate multiple addresses");
            // 
            // txtSender
            // 
            this.txtSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSender.Location = new System.Drawing.Point(326, 162);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(173, 20);
            this.txtSender.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtSender, "May only contain a single address");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Reply to";
            this.toolTip1.SetToolTip(this.label13, "Use , (comma) to separate multiple addresses");
            // 
            // txtReplyToAddress
            // 
            this.txtReplyToAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplyToAddress.Location = new System.Drawing.Point(92, 214);
            this.txtReplyToAddress.Name = "txtReplyToAddress";
            this.txtReplyToAddress.Size = new System.Drawing.Size(407, 20);
            this.txtReplyToAddress.TabIndex = 15;
            // 
            // priorityGroupBox
            // 
            this.priorityGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityGroupBox.Controls.Add(this.optPriorityHigh);
            this.priorityGroupBox.Controls.Add(this.optPriorityNormal);
            this.priorityGroupBox.Controls.Add(this.optPriorityLow);
            this.priorityGroupBox.Location = new System.Drawing.Point(409, 61);
            this.priorityGroupBox.Name = "priorityGroupBox";
            this.priorityGroupBox.Size = new System.Drawing.Size(94, 95);
            this.priorityGroupBox.TabIndex = 7;
            this.priorityGroupBox.TabStop = false;
            this.priorityGroupBox.Text = "Priority";
            // 
            // optPriorityLow
            // 
            this.optPriorityLow.AutoSize = true;
            this.optPriorityLow.Location = new System.Drawing.Point(8, 22);
            this.optPriorityLow.Name = "optPriorityLow";
            this.optPriorityLow.Size = new System.Drawing.Size(45, 17);
            this.optPriorityLow.TabIndex = 0;
            this.optPriorityLow.Text = "Low";
            this.optPriorityLow.UseVisualStyleBackColor = true;
            // 
            // optPriorityNormal
            // 
            this.optPriorityNormal.AutoSize = true;
            this.optPriorityNormal.Checked = true;
            this.optPriorityNormal.Location = new System.Drawing.Point(8, 44);
            this.optPriorityNormal.Name = "optPriorityNormal";
            this.optPriorityNormal.Size = new System.Drawing.Size(58, 17);
            this.optPriorityNormal.TabIndex = 1;
            this.optPriorityNormal.TabStop = true;
            this.optPriorityNormal.Text = "Normal";
            this.optPriorityNormal.UseVisualStyleBackColor = true;
            // 
            // optPriorityHigh
            // 
            this.optPriorityHigh.AutoSize = true;
            this.optPriorityHigh.Location = new System.Drawing.Point(8, 67);
            this.optPriorityHigh.Name = "optPriorityHigh";
            this.optPriorityHigh.Size = new System.Drawing.Size(47, 17);
            this.optPriorityHigh.TabIndex = 2;
            this.optPriorityHigh.Text = "High";
            this.optPriorityHigh.UseVisualStyleBackColor = true;
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(515, 474);
            this.Controls.Add(this.priorityGroupBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtReplyToAddress);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.portNumericUpDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkTLS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.chkIsBodyHtml);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtToAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFromAddress);
            this.Controls.Add(this.groupBoxCredentials);
            this.Controls.Add(this.chkUseDefultCredentials);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSMTPServer);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdTest);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.priorityGroupBox.ResumeLayout(false);
            this.priorityGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.CheckBox chkUseDefultCredentials;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFromAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtToAddress;
        private System.Windows.Forms.CheckBox chkIsBodyHtml;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkTLS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtReplyToAddress;
        private System.Windows.Forms.GroupBox priorityGroupBox;
        private System.Windows.Forms.RadioButton optPriorityHigh;
        private System.Windows.Forms.RadioButton optPriorityNormal;
        private System.Windows.Forms.RadioButton optPriorityLow;
    }
}