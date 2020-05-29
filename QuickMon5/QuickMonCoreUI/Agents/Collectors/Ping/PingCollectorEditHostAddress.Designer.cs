namespace QuickMon.UI
{
    partial class PingCollectorEditHostAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingCollectorEditHostAddress));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmdTestAddress = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudExpextedTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPingType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.httpGroupBox = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtHTMLContent = new System.Windows.Forms.TextBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtHTTPHeaderPassword = new System.Windows.Forms.TextBox();
            this.txtHTTPHeaderUsername = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.chkIgnoreInvalidHTTPSCerts = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHttpProxy = new System.Windows.Forms.TextBox();
            this.socketPingGroupBox = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSocketPingMsgBody = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkUseTelNetLogin = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudSendTimeout = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nudReceiveTimeout = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.nudPortNumber = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkVerifyOnOK = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboHttpsProtocol = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpextedTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.httpGroupBox.SuspendLayout();
            this.socketPingGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiveTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(368, 482);
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
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(287, 482);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host/address";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(103, 43);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(337, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // cmdTestAddress
            // 
            this.cmdTestAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestAddress.Enabled = false;
            this.cmdTestAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTestAddress.Location = new System.Drawing.Point(214, 482);
            this.cmdTestAddress.Name = "cmdTestAddress";
            this.cmdTestAddress.Size = new System.Drawing.Size(67, 23);
            this.cmdTestAddress.TabIndex = 4;
            this.cmdTestAddress.Text = "Test";
            this.cmdTestAddress.UseVisualStyleBackColor = true;
            this.cmdTestAddress.Click += new System.EventHandler(this.cmdTestAddress_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(103, 69);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(337, 20);
            this.txtDescription.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Warning time";
            // 
            // nudExpextedTime
            // 
            this.nudExpextedTime.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudExpextedTime.Location = new System.Drawing.Point(103, 95);
            this.nudExpextedTime.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudExpextedTime.Name = "nudExpextedTime";
            this.nudExpextedTime.Size = new System.Drawing.Size(60, 20);
            this.nudExpextedTime.TabIndex = 8;
            this.nudExpextedTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "milliseconds (maximum time expected)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "milliseconds (time-out/abort ping)";
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudTimeOut.Location = new System.Drawing.Point(103, 121);
            this.nudTimeOut.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(60, 20);
            this.nudTimeOut.TabIndex = 11;
            this.nudTimeOut.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Error time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ping method";
            // 
            // cboPingType
            // 
            this.cboPingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPingType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboPingType.FormattingEnabled = true;
            this.cboPingType.Items.AddRange(new object[] {
            "ICMP Ping",
            "HTTP(S)",
            "Socket"});
            this.cboPingType.Location = new System.Drawing.Point(103, 15);
            this.cboPingType.Name = "cboPingType";
            this.cboPingType.Size = new System.Drawing.Size(337, 21);
            this.cboPingType.TabIndex = 1;
            this.cboPingType.SelectedIndexChanged += new System.EventHandler(this.cboPingType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboPingType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudTimeOut);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudExpextedTime);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General settings";
            // 
            // httpGroupBox
            // 
            this.httpGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.httpGroupBox.Controls.Add(this.cboHttpsProtocol);
            this.httpGroupBox.Controls.Add(this.label22);
            this.httpGroupBox.Controls.Add(this.label20);
            this.httpGroupBox.Controls.Add(this.txtHTMLContent);
            this.httpGroupBox.Controls.Add(this.txtProxyPassword);
            this.httpGroupBox.Controls.Add(this.txtProxyUsername);
            this.httpGroupBox.Controls.Add(this.label18);
            this.httpGroupBox.Controls.Add(this.label19);
            this.httpGroupBox.Controls.Add(this.txtHTTPHeaderPassword);
            this.httpGroupBox.Controls.Add(this.txtHTTPHeaderUsername);
            this.httpGroupBox.Controls.Add(this.label16);
            this.httpGroupBox.Controls.Add(this.label17);
            this.httpGroupBox.Controls.Add(this.chkIgnoreInvalidHTTPSCerts);
            this.httpGroupBox.Controls.Add(this.label8);
            this.httpGroupBox.Controls.Add(this.txtHttpProxy);
            this.httpGroupBox.Location = new System.Drawing.Point(3, 162);
            this.httpGroupBox.Name = "httpGroupBox";
            this.httpGroupBox.Size = new System.Drawing.Size(447, 180);
            this.httpGroupBox.TabIndex = 1;
            this.httpGroupBox.TabStop = false;
            this.httpGroupBox.Text = "HTTP(S) Ping";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "Contains content";
            // 
            // txtHTMLContent
            // 
            this.txtHTMLContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHTMLContent.Location = new System.Drawing.Point(116, 124);
            this.txtHTMLContent.Multiline = true;
            this.txtHTMLContent.Name = "txtHTMLContent";
            this.txtHTMLContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHTMLContent.Size = new System.Drawing.Size(318, 50);
            this.txtHTMLContent.TabIndex = 12;
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(304, 75);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.PasswordChar = '*';
            this.txtProxyPassword.Size = new System.Drawing.Size(91, 20);
            this.txtProxyPassword.TabIndex = 9;
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.Location = new System.Drawing.Point(116, 75);
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(91, 20);
            this.txtProxyUsername.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(245, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Password";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Proxy user *";
            this.toolTip1.SetToolTip(this.label19, "The Proxy Username and Password does not always work if the Proxy server is on an" +
        " AD domain. This functionality is provided \'as is\' for troubleshooting.");
            // 
            // txtHTTPHeaderPassword
            // 
            this.txtHTTPHeaderPassword.Location = new System.Drawing.Point(304, 19);
            this.txtHTTPHeaderPassword.Name = "txtHTTPHeaderPassword";
            this.txtHTTPHeaderPassword.PasswordChar = '*';
            this.txtHTTPHeaderPassword.Size = new System.Drawing.Size(91, 20);
            this.txtHTTPHeaderPassword.TabIndex = 3;
            // 
            // txtHTTPHeaderUsername
            // 
            this.txtHTTPHeaderUsername.Location = new System.Drawing.Point(116, 19);
            this.txtHTTPHeaderUsername.Name = "txtHTTPHeaderUsername";
            this.txtHTTPHeaderUsername.Size = new System.Drawing.Size(91, 20);
            this.txtHTTPHeaderUsername.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(245, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Password";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "HTTP Header User";
            // 
            // chkIgnoreInvalidHTTPSCerts
            // 
            this.chkIgnoreInvalidHTTPSCerts.AutoSize = true;
            this.chkIgnoreInvalidHTTPSCerts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkIgnoreInvalidHTTPSCerts.Location = new System.Drawing.Point(32, 101);
            this.chkIgnoreInvalidHTTPSCerts.Name = "chkIgnoreInvalidHTTPSCerts";
            this.chkIgnoreInvalidHTTPSCerts.Size = new System.Drawing.Size(180, 17);
            this.chkIgnoreInvalidHTTPSCerts.TabIndex = 10;
            this.chkIgnoreInvalidHTTPSCerts.Text = "Ignore invalid HTTPS certificates";
            this.chkIgnoreInvalidHTTPSCerts.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "HTTP Proxy";
            // 
            // txtHttpProxy
            // 
            this.txtHttpProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHttpProxy.Location = new System.Drawing.Point(116, 49);
            this.txtHttpProxy.Name = "txtHttpProxy";
            this.txtHttpProxy.Size = new System.Drawing.Size(280, 20);
            this.txtHttpProxy.TabIndex = 5;
            // 
            // socketPingGroupBox
            // 
            this.socketPingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.socketPingGroupBox.Controls.Add(this.label21);
            this.socketPingGroupBox.Controls.Add(this.txtSocketPingMsgBody);
            this.socketPingGroupBox.Controls.Add(this.groupBox2);
            this.socketPingGroupBox.Controls.Add(this.label9);
            this.socketPingGroupBox.Controls.Add(this.nudSendTimeout);
            this.socketPingGroupBox.Controls.Add(this.label12);
            this.socketPingGroupBox.Controls.Add(this.label13);
            this.socketPingGroupBox.Controls.Add(this.nudReceiveTimeout);
            this.socketPingGroupBox.Controls.Add(this.label14);
            this.socketPingGroupBox.Controls.Add(this.nudPortNumber);
            this.socketPingGroupBox.Controls.Add(this.label15);
            this.socketPingGroupBox.Location = new System.Drawing.Point(3, 348);
            this.socketPingGroupBox.Name = "socketPingGroupBox";
            this.socketPingGroupBox.Size = new System.Drawing.Size(447, 128);
            this.socketPingGroupBox.TabIndex = 2;
            this.socketPingGroupBox.TabStop = false;
            this.socketPingGroupBox.Text = "Socket Ping";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 100);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Text to send";
            // 
            // txtSocketPingMsgBody
            // 
            this.txtSocketPingMsgBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSocketPingMsgBody.Location = new System.Drawing.Point(103, 97);
            this.txtSocketPingMsgBody.Name = "txtSocketPingMsgBody";
            this.txtSocketPingMsgBody.Size = new System.Drawing.Size(331, 20);
            this.txtSocketPingMsgBody.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chkUseTelNetLogin);
            this.groupBox2.Location = new System.Drawing.Point(272, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 82);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Telnet";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(71, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(91, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(71, 26);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(91, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "User";
            // 
            // chkUseTelNetLogin
            // 
            this.chkUseTelNetLogin.AutoSize = true;
            this.chkUseTelNetLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseTelNetLogin.Location = new System.Drawing.Point(55, 0);
            this.chkUseTelNetLogin.Name = "chkUseTelNetLogin";
            this.chkUseTelNetLogin.Size = new System.Drawing.Size(68, 17);
            this.chkUseTelNetLogin.TabIndex = 0;
            this.chkUseTelNetLogin.Text = "Use login";
            this.chkUseTelNetLogin.UseVisualStyleBackColor = true;
            this.chkUseTelNetLogin.CheckedChanged += new System.EventHandler(this.chkUseTelNetLogin_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "milliseconds";
            // 
            // nudSendTimeout
            // 
            this.nudSendTimeout.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSendTimeout.Location = new System.Drawing.Point(103, 71);
            this.nudSendTimeout.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudSendTimeout.Name = "nudSendTimeout";
            this.nudSendTimeout.Size = new System.Drawing.Size(73, 20);
            this.nudSendTimeout.TabIndex = 6;
            this.nudSendTimeout.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Send timeout";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(182, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "milliseconds";
            // 
            // nudReceiveTimeout
            // 
            this.nudReceiveTimeout.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudReceiveTimeout.Location = new System.Drawing.Point(103, 45);
            this.nudReceiveTimeout.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudReceiveTimeout.Name = "nudReceiveTimeout";
            this.nudReceiveTimeout.Size = new System.Drawing.Size(73, 20);
            this.nudReceiveTimeout.TabIndex = 3;
            this.nudReceiveTimeout.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Receive timeout";
            // 
            // nudPortNumber
            // 
            this.nudPortNumber.Location = new System.Drawing.Point(103, 19);
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
            this.nudPortNumber.TabIndex = 1;
            this.nudPortNumber.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Port number";
            // 
            // chkVerifyOnOK
            // 
            this.chkVerifyOnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerifyOnOK.AutoSize = true;
            this.chkVerifyOnOK.Checked = true;
            this.chkVerifyOnOK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyOnOK.Location = new System.Drawing.Point(87, 486);
            this.chkVerifyOnOK.Name = "chkVerifyOnOK";
            this.chkVerifyOnOK.Size = new System.Drawing.Size(123, 17);
            this.chkVerifyOnOK.TabIndex = 3;
            this.chkVerifyOnOK.Text = "Test on clicking \'OK\'";
            this.chkVerifyOnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerifyOnOK.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(225, 103);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "Https protocol";
            // 
            // cboHttpsProtocol
            // 
            this.cboHttpsProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHttpsProtocol.FormattingEnabled = true;
            this.cboHttpsProtocol.Items.AddRange(new object[] {
            "Ssl3",
            "Tls",
            "Tls11",
            "Tls12"});
            this.cboHttpsProtocol.Location = new System.Drawing.Point(304, 100);
            this.cboHttpsProtocol.Name = "cboHttpsProtocol";
            this.cboHttpsProtocol.Size = new System.Drawing.Size(91, 21);
            this.cboHttpsProtocol.TabIndex = 14;
            // 
            // PingCollectorEditHostAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(455, 517);
            this.Controls.Add(this.chkVerifyOnOK);
            this.Controls.Add(this.socketPingGroupBox);
            this.Controls.Add(this.httpGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdTestAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PingCollectorEditHostAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Ping entry details";
            this.Load += new System.EventHandler(this.PingCollectorEditHostAddress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudExpextedTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.httpGroupBox.ResumeLayout(false);
            this.httpGroupBox.PerformLayout();
            this.socketPingGroupBox.ResumeLayout(false);
            this.socketPingGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceiveTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button cmdTestAddress;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudExpextedTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboPingType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox httpGroupBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHttpProxy;
        private System.Windows.Forms.GroupBox socketPingGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkUseTelNetLogin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudSendTimeout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudReceiveTimeout;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudPortNumber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkIgnoreInvalidHTTPSCerts;
        private System.Windows.Forms.TextBox txtHTTPHeaderPassword;
        private System.Windows.Forms.TextBox txtHTTPHeaderUsername;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtHTMLContent;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSocketPingMsgBody;
        private System.Windows.Forms.CheckBox chkVerifyOnOK;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboHttpsProtocol;
    }
}