namespace QuickMon
{
    partial class EditSocketPingEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSocketPingEntry));
            this.label5 = new System.Windows.Forms.Label();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudPortNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdTestAddress = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudReceiveTimeout = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudSendTimeout = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkUseTelNetLogin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiveTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "milliseconds";
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudTimeOut.Location = new System.Drawing.Point(100, 63);
            this.nudTimeOut.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(73, 20);
            this.nudTimeOut.TabIndex = 6;
            this.nudTimeOut.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Time-outtime";
            // 
            // nudPortNumber
            // 
            this.nudPortNumber.Location = new System.Drawing.Point(100, 37);
            this.nudPortNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPortNumber.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudPortNumber.Name = "nudPortNumber";
            this.nudPortNumber.Size = new System.Drawing.Size(73, 20);
            this.nudPortNumber.TabIndex = 4;
            this.nudPortNumber.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port number";
            // 
            // cmdTestAddress
            // 
            this.cmdTestAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestAddress.Location = new System.Drawing.Point(360, 9);
            this.cmdTestAddress.Name = "cmdTestAddress";
            this.cmdTestAddress.Size = new System.Drawing.Size(40, 23);
            this.cmdTestAddress.TabIndex = 2;
            this.cmdTestAddress.Text = "Test";
            this.cmdTestAddress.UseVisualStyleBackColor = true;
            this.cmdTestAddress.Click += new System.EventHandler(this.cmdTestAddress_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(100, 11);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(254, 20);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host name";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(325, 148);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(244, 148);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "milliseconds";
            // 
            // nudReceiveTimeout
            // 
            this.nudReceiveTimeout.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudReceiveTimeout.Location = new System.Drawing.Point(100, 91);
            this.nudReceiveTimeout.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudReceiveTimeout.Name = "nudReceiveTimeout";
            this.nudReceiveTimeout.Size = new System.Drawing.Size(73, 20);
            this.nudReceiveTimeout.TabIndex = 9;
            this.nudReceiveTimeout.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Receive timeout";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "milliseconds";
            // 
            // nudSendTimeout
            // 
            this.nudSendTimeout.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSendTimeout.Location = new System.Drawing.Point(100, 117);
            this.nudSendTimeout.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudSendTimeout.Name = "nudSendTimeout";
            this.nudSendTimeout.Size = new System.Drawing.Size(73, 20);
            this.nudSendTimeout.TabIndex = 12;
            this.nudSendTimeout.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Send timeout";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chkUseTelNetLogin);
            this.groupBox1.Location = new System.Drawing.Point(247, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 98);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telnet";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(71, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(74, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(71, 39);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(74, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "User";
            // 
            // chkUseTelNetLogin
            // 
            this.chkUseTelNetLogin.AutoSize = true;
            this.chkUseTelNetLogin.Location = new System.Drawing.Point(15, 19);
            this.chkUseTelNetLogin.Name = "chkUseTelNetLogin";
            this.chkUseTelNetLogin.Size = new System.Drawing.Size(70, 17);
            this.chkUseTelNetLogin.TabIndex = 0;
            this.chkUseTelNetLogin.Text = "Use login";
            this.chkUseTelNetLogin.UseVisualStyleBackColor = true;
            this.chkUseTelNetLogin.CheckedChanged += new System.EventHandler(this.chkUseTelNetLogin_CheckedChanged);
            // 
            // EditSocketPingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 183);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudSendTimeout);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudReceiveTimeout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudTimeOut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudPortNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdTestAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSocketPingEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Socket Ping Entry";
            this.Shown += new System.EventHandler(this.EditSocketPingEntry_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiveTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendTimeout)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudPortNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdTestAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudReceiveTimeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudSendTimeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUseTelNetLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}