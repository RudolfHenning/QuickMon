namespace QuickMon.Collectors
{
    partial class LinuxDiskIOCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxDiskIOCollectorEditEntry));
            this.privateKeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.warningColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSystemColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAutoAdd = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisk = new System.Windows.Forms.TextBox();
            this.lblAddFileSystem = new System.Windows.Forms.LinkLabel();
            this.lvwDisks = new QuickMon.ListViewEx();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.optPrivateKey = new System.Windows.Forms.RadioButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmdBrowsePrivateKeyFile = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.txtPassPhrase = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtPrivateKeyFile = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.sshPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.optPassword = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // privateKeyOpenFileDialog
            // 
            this.privateKeyOpenFileDialog.DefaultExt = "*";
            this.privateKeyOpenFileDialog.Filter = "Files|*.*";
            // 
            // errorColumnHeader
            // 
            this.errorColumnHeader.Text = "Error";
            this.errorColumnHeader.Width = 78;
            // 
            // warningColumnHeader
            // 
            this.warningColumnHeader.Text = "Warning";
            this.warningColumnHeader.Width = 75;
            // 
            // fileSystemColumnHeader
            // 
            this.fileSystemColumnHeader.Text = "Disk";
            this.fileSystemColumnHeader.Width = 233;
            // 
            // lblAutoAdd
            // 
            this.lblAutoAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAutoAdd.AutoSize = true;
            this.lblAutoAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAutoAdd.Location = new System.Drawing.Point(353, 16);
            this.lblAutoAdd.Name = "lblAutoAdd";
            this.lblAutoAdd.Size = new System.Drawing.Size(50, 13);
            this.lblAutoAdd.TabIndex = 2;
            this.lblAutoAdd.TabStop = true;
            this.lblAutoAdd.Text = "Auto add";
            this.lblAutoAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAutoAdd_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Disk";
            // 
            // txtDisk
            // 
            this.txtDisk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisk.Location = new System.Drawing.Point(100, 119);
            this.txtDisk.Name = "txtDisk";
            this.txtDisk.Size = new System.Drawing.Size(303, 20);
            this.txtDisk.TabIndex = 5;
            this.txtDisk.TextChanged += new System.EventHandler(this.txtFileSystem_TextChanged);
            // 
            // lblAddFileSystem
            // 
            this.lblAddFileSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddFileSystem.AutoSize = true;
            this.lblAddFileSystem.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAddFileSystem.Location = new System.Drawing.Point(292, 16);
            this.lblAddFileSystem.Name = "lblAddFileSystem";
            this.lblAddFileSystem.Size = new System.Drawing.Size(49, 13);
            this.lblAddFileSystem.TabIndex = 1;
            this.lblAddFileSystem.TabStop = true;
            this.lblAddFileSystem.Text = "Add new";
            this.lblAddFileSystem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddFileSystem_LinkClicked);
            // 
            // lvwDisks
            // 
            this.lvwDisks.AutoResizeColumnEnabled = false;
            this.lvwDisks.AutoResizeColumnIndex = 0;
            this.lvwDisks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileSystemColumnHeader,
            this.warningColumnHeader,
            this.errorColumnHeader});
            this.lvwDisks.FullRowSelect = true;
            this.lvwDisks.Location = new System.Drawing.Point(8, 32);
            this.lvwDisks.Name = "lvwDisks";
            this.lvwDisks.Size = new System.Drawing.Size(395, 81);
            this.lvwDisks.TabIndex = 3;
            this.lvwDisks.UseCompatibleStateImageBehavior = false;
            this.lvwDisks.View = System.Windows.Forms.View.Details;
            this.lvwDisks.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwFileSystems_DeleteKeyPressed);
            this.lvwDisks.SelectedIndexChanged += new System.EventHandler(this.lvwFileSystems_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.lblAutoAdd);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.txtDisk);
            this.groupBox6.Controls.Add(this.lblAddFileSystem);
            this.groupBox6.Controls.Add(this.lvwDisks);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.errorNumericUpDown);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.warningNumericUpDown);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox6.Location = new System.Drawing.Point(12, 221);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(409, 172);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Alert triggering";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Location = new System.Drawing.Point(368, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "KB/s";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Location = new System.Drawing.Point(209, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "KB/s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disks";
            // 
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.errorNumericUpDown.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.errorNumericUpDown.Location = new System.Drawing.Point(277, 146);
            this.errorNumericUpDown.Maximum = new decimal(new int[] {
            10485760,
            0,
            0,
            0});
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.errorNumericUpDown.TabIndex = 9;
            this.errorNumericUpDown.Value = new decimal(new int[] {
            51200,
            0,
            0,
            0});
            this.errorNumericUpDown.ValueChanged += new System.EventHandler(this.errorNumericUpDown_ValueChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label22.Location = new System.Drawing.Point(6, 148);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "Warning";
            // 
            // warningNumericUpDown
            // 
            this.warningNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.warningNumericUpDown.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.warningNumericUpDown.Location = new System.Drawing.Point(100, 146);
            this.warningNumericUpDown.Maximum = new decimal(new int[] {
            10485760,
            0,
            0,
            0});
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(103, 20);
            this.warningNumericUpDown.TabIndex = 7;
            this.warningNumericUpDown.Value = new decimal(new int[] {
            10240,
            0,
            0,
            0});
            this.warningNumericUpDown.ValueChanged += new System.EventHandler(this.warningNumericUpDown_ValueChanged);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label23.Location = new System.Drawing.Point(242, 148);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "Error";
            // 
            // optPrivateKey
            // 
            this.optPrivateKey.AutoSize = true;
            this.optPrivateKey.Location = new System.Drawing.Point(157, 21);
            this.optPrivateKey.Name = "optPrivateKey";
            this.optPrivateKey.Size = new System.Drawing.Size(78, 17);
            this.optPrivateKey.TabIndex = 1;
            this.optPrivateKey.Text = "Private key";
            this.optPrivateKey.UseVisualStyleBackColor = true;
            this.optPrivateKey.CheckedChanged += new System.EventHandler(this.optPrivateKey_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(122, 138);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(299, 20);
            this.txtPassword.TabIndex = 25;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 141);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 13);
            this.label24.TabIndex = 24;
            this.label24.Text = "Password";
            // 
            // cmdBrowsePrivateKeyFile
            // 
            this.cmdBrowsePrivateKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowsePrivateKeyFile.Enabled = false;
            this.cmdBrowsePrivateKeyFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowsePrivateKeyFile.Location = new System.Drawing.Point(380, 167);
            this.cmdBrowsePrivateKeyFile.Name = "cmdBrowsePrivateKeyFile";
            this.cmdBrowsePrivateKeyFile.Size = new System.Drawing.Size(41, 23);
            this.cmdBrowsePrivateKeyFile.TabIndex = 28;
            this.cmdBrowsePrivateKeyFile.Text = "- - -";
            this.cmdBrowsePrivateKeyFile.UseVisualStyleBackColor = true;
            this.cmdBrowsePrivateKeyFile.Click += new System.EventHandler(this.cmdBrowsePrivateKeyFile_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Username";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachineName.Location = new System.Drawing.Point(12, 27);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(352, 20);
            this.txtMachineName.TabIndex = 18;
            // 
            // txtPassPhrase
            // 
            this.txtPassPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassPhrase.Location = new System.Drawing.Point(122, 195);
            this.txtPassPhrase.Name = "txtPassPhrase";
            this.txtPassPhrase.PasswordChar = '*';
            this.txtPassPhrase.Size = new System.Drawing.Size(299, 20);
            this.txtPassPhrase.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Computer name";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(122, 112);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(299, 20);
            this.txtUsername.TabIndex = 23;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(265, 399);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 32;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 399);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 33;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // txtPrivateKeyFile
            // 
            this.txtPrivateKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivateKeyFile.Location = new System.Drawing.Point(122, 169);
            this.txtPrivateKeyFile.Name = "txtPrivateKeyFile";
            this.txtPrivateKeyFile.ReadOnly = true;
            this.txtPrivateKeyFile.Size = new System.Drawing.Size(252, 20);
            this.txtPrivateKeyFile.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(371, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "SSH port";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sshPortNumericUpDown
            // 
            this.sshPortNumericUpDown.Location = new System.Drawing.Point(370, 28);
            this.sshPortNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sshPortNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sshPortNumericUpDown.Name = "sshPortNumericUpDown";
            this.sshPortNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.sshPortNumericUpDown.TabIndex = 20;
            this.sshPortNumericUpDown.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.optPrivateKey);
            this.groupBox5.Controls.Add(this.optPassword);
            this.groupBox5.Location = new System.Drawing.Point(12, 54);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(409, 50);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Auhentication method";
            // 
            // optPassword
            // 
            this.optPassword.AutoSize = true;
            this.optPassword.Checked = true;
            this.optPassword.Location = new System.Drawing.Point(13, 21);
            this.optPassword.Name = "optPassword";
            this.optPassword.Size = new System.Drawing.Size(124, 17);
            this.optPassword.TabIndex = 0;
            this.optPassword.TabStop = true;
            this.optPassword.Text = "Username/Password";
            this.optPassword.UseVisualStyleBackColor = true;
            this.optPassword.CheckedChanged += new System.EventHandler(this.optPassword_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 198);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Passphrase";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 26;
            this.label20.Text = "Private key file";
            // 
            // LinuxDiskIOCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 433);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmdBrowsePrivateKeyFile);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.txtPassPhrase);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtPrivateKeyFile);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.sshPortNumericUpDown);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinuxDiskIOCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linux Disk IO";
            this.Load += new System.EventHandler(this.LinuxDiskIOCollectorEditEntry_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog privateKeyOpenFileDialog;
        private System.Windows.Forms.ColumnHeader errorColumnHeader;
        private System.Windows.Forms.ColumnHeader warningColumnHeader;
        private System.Windows.Forms.ColumnHeader fileSystemColumnHeader;
        private System.Windows.Forms.LinkLabel lblAutoAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisk;
        private System.Windows.Forms.LinkLabel lblAddFileSystem;
        private ListViewEx lvwDisks;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RadioButton optPrivateKey;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button cmdBrowsePrivateKeyFile;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.TextBox txtPassPhrase;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtPrivateKeyFile;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown sshPortNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton optPassword;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}