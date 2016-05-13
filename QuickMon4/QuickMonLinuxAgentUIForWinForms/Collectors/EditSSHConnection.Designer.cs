namespace QuickMon.Collectors
{
    partial class EditSSHConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSSHConnection));
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
            this.optPrivateKey = new System.Windows.Forms.RadioButton();
            this.optPassword = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmdTest = new System.Windows.Forms.Button();
            this.privateKeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chkPersistent = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(122, 138);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(299, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 141);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 13);
            this.label24.TabIndex = 7;
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
            this.cmdBrowsePrivateKeyFile.TabIndex = 11;
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
            this.label17.TabIndex = 5;
            this.label17.Text = "Username";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachineName.Location = new System.Drawing.Point(12, 27);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(352, 20);
            this.txtMachineName.TabIndex = 1;
            // 
            // txtPassPhrase
            // 
            this.txtPassPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassPhrase.Location = new System.Drawing.Point(122, 195);
            this.txtPassPhrase.Name = "txtPassPhrase";
            this.txtPassPhrase.PasswordChar = '*';
            this.txtPassPhrase.Size = new System.Drawing.Size(299, 20);
            this.txtPassPhrase.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Computer name";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(122, 112);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(299, 20);
            this.txtUsername.TabIndex = 6;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(265, 243);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 16;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 243);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 17;
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
            this.txtPrivateKeyFile.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(371, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 2;
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
            this.sshPortNumericUpDown.TabIndex = 3;
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
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Auhentication method";
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
            this.label21.TabIndex = 12;
            this.label21.Text = "Passphrase";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Private key file";
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTest.Location = new System.Drawing.Point(18, 243);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(75, 23);
            this.cmdTest.TabIndex = 15;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // privateKeyOpenFileDialog
            // 
            this.privateKeyOpenFileDialog.DefaultExt = "*";
            this.privateKeyOpenFileDialog.Filter = "Files|*.*";
            // 
            // chkPersistent
            // 
            this.chkPersistent.AutoSize = true;
            this.chkPersistent.Location = new System.Drawing.Point(18, 220);
            this.chkPersistent.Name = "chkPersistent";
            this.chkPersistent.Size = new System.Drawing.Size(258, 17);
            this.chkPersistent.TabIndex = 14;
            this.chkPersistent.Text = "Persistent (try to keep connection open for reuse)";
            this.chkPersistent.UseVisualStyleBackColor = true;
            // 
            // EditSSHConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 277);
            this.Controls.Add(this.chkPersistent);
            this.Controls.Add(this.cmdTest);
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
            this.Name = "EditSSHConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit SSH Connection";
            this.Load += new System.EventHandler(this.EditSSHConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.RadioButton optPrivateKey;
        private System.Windows.Forms.RadioButton optPassword;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.OpenFileDialog privateKeyOpenFileDialog;
        private System.Windows.Forms.CheckBox chkPersistent;
    }
}