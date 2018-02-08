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
            this.optKeyboardInteractive = new System.Windows.Forms.RadioButton();
            this.optPrivateKey = new System.Windows.Forms.RadioButton();
            this.optPassword = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmdTest = new System.Windows.Forms.Button();
            this.privateKeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chkPersistent = new System.Windows.Forms.CheckBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOpenConnectionStringFile = new System.Windows.Forms.Button();
            this.connectionStringFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.connectionStringSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cmdSaveToFile = new System.Windows.Forms.Button();
            this.cmdSetFromFile = new System.Windows.Forms.Button();
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
            this.txtPassword.Size = new System.Drawing.Size(309, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
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
            this.cmdBrowsePrivateKeyFile.Location = new System.Drawing.Point(390, 167);
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
            this.txtMachineName.Size = new System.Drawing.Size(362, 20);
            this.txtMachineName.TabIndex = 1;
            this.txtMachineName.TextChanged += new System.EventHandler(this.txtMachineName_TextChanged);
            // 
            // txtPassPhrase
            // 
            this.txtPassPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassPhrase.Location = new System.Drawing.Point(122, 195);
            this.txtPassPhrase.Name = "txtPassPhrase";
            this.txtPassPhrase.PasswordChar = '*';
            this.txtPassPhrase.Size = new System.Drawing.Size(309, 20);
            this.txtPassPhrase.TabIndex = 13;
            this.txtPassPhrase.TextChanged += new System.EventHandler(this.txtPassPhrase_TextChanged);
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
            this.txtUsername.Size = new System.Drawing.Size(309, 20);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(275, 284);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 21;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(356, 284);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 22;
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
            this.txtPrivateKeyFile.Size = new System.Drawing.Size(262, 20);
            this.txtPrivateKeyFile.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(377, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "SSH port";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sshPortNumericUpDown
            // 
            this.sshPortNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sshPortNumericUpDown.Location = new System.Drawing.Point(380, 27);
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
            this.groupBox5.Controls.Add(this.optKeyboardInteractive);
            this.groupBox5.Controls.Add(this.optPrivateKey);
            this.groupBox5.Controls.Add(this.optPassword);
            this.groupBox5.Location = new System.Drawing.Point(12, 54);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(419, 50);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Auhentication method";
            // 
            // optKeyboardInteractive
            // 
            this.optKeyboardInteractive.AutoSize = true;
            this.optKeyboardInteractive.Location = new System.Drawing.Point(250, 21);
            this.optKeyboardInteractive.Name = "optKeyboardInteractive";
            this.optKeyboardInteractive.Size = new System.Drawing.Size(122, 17);
            this.optKeyboardInteractive.TabIndex = 2;
            this.optKeyboardInteractive.Text = "Keyboard interactive";
            this.optKeyboardInteractive.UseVisualStyleBackColor = true;
            this.optKeyboardInteractive.CheckedChanged += new System.EventHandler(this.optKeyboardInteractive_CheckedChanged);
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
            this.cmdTest.Location = new System.Drawing.Point(12, 284);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(105, 23);
            this.cmdTest.TabIndex = 19;
            this.cmdTest.Text = "Test connection";
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
            this.chkPersistent.CheckedChanged += new System.EventHandler(this.chkPersistent_CheckedChanged);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtConnectionString.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtConnectionString.Location = new System.Drawing.Point(12, 258);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(325, 20);
            this.txtConnectionString.TabIndex = 16;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            this.txtConnectionString.Leave += new System.EventHandler(this.txtConnectionString_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Connection string file (connectring string will be saved to this file)";
            // 
            // cmdOpenConnectionStringFile
            // 
            this.cmdOpenConnectionStringFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpenConnectionStringFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOpenConnectionStringFile.Location = new System.Drawing.Point(343, 256);
            this.cmdOpenConnectionStringFile.Name = "cmdOpenConnectionStringFile";
            this.cmdOpenConnectionStringFile.Size = new System.Drawing.Size(41, 23);
            this.cmdOpenConnectionStringFile.TabIndex = 17;
            this.cmdOpenConnectionStringFile.Text = "Load";
            this.cmdOpenConnectionStringFile.UseVisualStyleBackColor = true;
            this.cmdOpenConnectionStringFile.Click += new System.EventHandler(this.cmdOpenConnectionStringFile_Click);
            // 
            // connectionStringFileOpenFileDialog
            // 
            this.connectionStringFileOpenFileDialog.DefaultExt = "txt";
            this.connectionStringFileOpenFileDialog.Filter = "Files|*.txt";
            this.connectionStringFileOpenFileDialog.Title = "Connection string file";
            // 
            // connectionStringSaveFileDialog
            // 
            this.connectionStringSaveFileDialog.DefaultExt = "txt";
            this.connectionStringSaveFileDialog.Filter = "Files|*.txt";
            this.connectionStringSaveFileDialog.Title = "Connection string file";
            // 
            // cmdSaveToFile
            // 
            this.cmdSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSaveToFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveToFile.Location = new System.Drawing.Point(123, 284);
            this.cmdSaveToFile.Name = "cmdSaveToFile";
            this.cmdSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.cmdSaveToFile.TabIndex = 20;
            this.cmdSaveToFile.Text = "Save to file";
            this.cmdSaveToFile.UseVisualStyleBackColor = true;
            this.cmdSaveToFile.Click += new System.EventHandler(this.cmdSaveToFile_Click);
            // 
            // cmdSetFromFile
            // 
            this.cmdSetFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSetFromFile.Location = new System.Drawing.Point(390, 256);
            this.cmdSetFromFile.Name = "cmdSetFromFile";
            this.cmdSetFromFile.Size = new System.Drawing.Size(41, 23);
            this.cmdSetFromFile.TabIndex = 18;
            this.cmdSetFromFile.Text = "Set";
            this.cmdSetFromFile.UseVisualStyleBackColor = true;
            this.cmdSetFromFile.Click += new System.EventHandler(this.cmdSetFromFile_Click);
            // 
            // EditSSHConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 318);
            this.Controls.Add(this.cmdSetFromFile);
            this.Controls.Add(this.cmdSaveToFile);
            this.Controls.Add(this.cmdOpenConnectionStringFile);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.RadioButton optKeyboardInteractive;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOpenConnectionStringFile;
        private System.Windows.Forms.OpenFileDialog connectionStringFileOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog connectionStringSaveFileDialog;
        private System.Windows.Forms.Button cmdSaveToFile;
        private System.Windows.Forms.Button cmdSetFromFile;
    }
}