namespace QuickMon.Collectors
{
    partial class LinuxMemoryCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxMemoryCollectorEditEntry));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmdEditPerfCounter = new System.Windows.Forms.Button();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblWarning = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblError = new System.Windows.Forms.Label();
            this.alertTriggeringGroupBox = new System.Windows.Forms.GroupBox();
            this.txtPassPhrase = new System.Windows.Forms.TextBox();
            this.lblPassphrase = new System.Windows.Forms.Label();
            this.txtPrivateKeyFile = new System.Windows.Forms.TextBox();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.authenticationsGroupBox = new System.Windows.Forms.GroupBox();
            this.optPrivateKey = new System.Windows.Forms.RadioButton();
            this.optPassword = new System.Windows.Forms.RadioButton();
            this.sshPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblSSHPort = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.privateKeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.alertTriggeringGroupBox.SuspendLayout();
            this.authenticationsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).BeginInit();
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
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 141);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // cmdEditPerfCounter
            // 
            this.cmdEditPerfCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditPerfCounter.Enabled = false;
            this.cmdEditPerfCounter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditPerfCounter.Location = new System.Drawing.Point(380, 167);
            this.cmdEditPerfCounter.Name = "cmdEditPerfCounter";
            this.cmdEditPerfCounter.Size = new System.Drawing.Size(41, 23);
            this.cmdEditPerfCounter.TabIndex = 11;
            this.cmdEditPerfCounter.Text = "- - -";
            this.cmdEditPerfCounter.UseVisualStyleBackColor = true;
            this.cmdEditPerfCounter.Click += new System.EventHandler(this.cmdEditPerfCounter_Click);
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
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWarning.Location = new System.Drawing.Point(11, 21);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(47, 13);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "Warning";
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
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblError.Location = new System.Drawing.Point(234, 21);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(29, 13);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Error";
            // 
            // alertTriggeringGroupBox
            // 
            this.alertTriggeringGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alertTriggeringGroupBox.Controls.Add(this.lblWarning);
            this.alertTriggeringGroupBox.Controls.Add(this.lblError);
            this.alertTriggeringGroupBox.Controls.Add(this.warningNumericUpDown);
            this.alertTriggeringGroupBox.Controls.Add(this.errorNumericUpDown);
            this.alertTriggeringGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.alertTriggeringGroupBox.Location = new System.Drawing.Point(15, 221);
            this.alertTriggeringGroupBox.Name = "alertTriggeringGroupBox";
            this.alertTriggeringGroupBox.Size = new System.Drawing.Size(409, 57);
            this.alertTriggeringGroupBox.TabIndex = 14;
            this.alertTriggeringGroupBox.TabStop = false;
            this.alertTriggeringGroupBox.Text = "Alert triggering";
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
            // lblPassphrase
            // 
            this.lblPassphrase.AutoSize = true;
            this.lblPassphrase.Location = new System.Drawing.Point(12, 198);
            this.lblPassphrase.Name = "lblPassphrase";
            this.lblPassphrase.Size = new System.Drawing.Size(62, 13);
            this.lblPassphrase.TabIndex = 12;
            this.lblPassphrase.Text = "Passphrase";
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
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(12, 172);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(76, 13);
            this.lblPrivateKey.TabIndex = 9;
            this.lblPrivateKey.Text = "Private key file";
            // 
            // authenticationsGroupBox
            // 
            this.authenticationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authenticationsGroupBox.Controls.Add(this.optPrivateKey);
            this.authenticationsGroupBox.Controls.Add(this.optPassword);
            this.authenticationsGroupBox.Location = new System.Drawing.Point(12, 54);
            this.authenticationsGroupBox.Name = "authenticationsGroupBox";
            this.authenticationsGroupBox.Size = new System.Drawing.Size(409, 50);
            this.authenticationsGroupBox.TabIndex = 4;
            this.authenticationsGroupBox.TabStop = false;
            this.authenticationsGroupBox.Text = "Auhentication method";
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
            // lblSSHPort
            // 
            this.lblSSHPort.AutoSize = true;
            this.lblSSHPort.Location = new System.Drawing.Point(371, 12);
            this.lblSSHPort.Name = "lblSSHPort";
            this.lblSSHPort.Size = new System.Drawing.Size(50, 13);
            this.lblSSHPort.TabIndex = 1;
            this.lblSSHPort.Text = "SSH port";
            this.lblSSHPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 293);
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
            this.cmdOK.Location = new System.Drawing.Point(265, 293);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
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
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(12, 10);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(81, 13);
            this.lblComputerName.TabIndex = 0;
            this.lblComputerName.Text = "Computer name";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachineName.Location = new System.Drawing.Point(12, 27);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(352, 20);
            this.txtMachineName.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 115);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "Username";
            // 
            // privateKeyOpenFileDialog
            // 
            this.privateKeyOpenFileDialog.DefaultExt = "*";
            this.privateKeyOpenFileDialog.Filter = "Files|*.*";
            // 
            // LinuxMemoryCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 327);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.cmdEditPerfCounter);
            this.Controls.Add(this.txtPassPhrase);
            this.Controls.Add(this.lblPassphrase);
            this.Controls.Add(this.txtPrivateKeyFile);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.authenticationsGroupBox);
            this.Controls.Add(this.alertTriggeringGroupBox);
            this.Controls.Add(this.sshPortNumericUpDown);
            this.Controls.Add(this.lblSSHPort);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblComputerName);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinuxMemoryCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linux Memory";
            this.Load += new System.EventHandler(this.LinuxMemoryCollectorEditEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.alertTriggeringGroupBox.ResumeLayout(false);
            this.alertTriggeringGroupBox.PerformLayout();
            this.authenticationsGroupBox.ResumeLayout(false);
            this.authenticationsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button cmdEditPerfCounter;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtPassPhrase;
        private System.Windows.Forms.Label lblPassphrase;
        private System.Windows.Forms.TextBox txtPrivateKeyFile;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.GroupBox authenticationsGroupBox;
        private System.Windows.Forms.RadioButton optPrivateKey;
        private System.Windows.Forms.RadioButton optPassword;
        private System.Windows.Forms.NumericUpDown sshPortNumericUpDown;
        private System.Windows.Forms.Label lblSSHPort;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.OpenFileDialog privateKeyOpenFileDialog;
        private System.Windows.Forms.GroupBox alertTriggeringGroupBox;
        
    }
}