using QuickMon.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public partial class LinuxCPUCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        #region Designer stuff
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkUseOnlyTotalCPUvalue;
        private System.Windows.Forms.NumericUpDown sshPortNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optPrivateKey;
        private System.Windows.Forms.RadioButton optPassword;
        private System.Windows.Forms.TextBox txtPrivateKeyFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassPhrase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdEditPerfCounter;
        private System.Windows.Forms.OpenFileDialog privateKeyOpenFileDialog;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSSHConnection;
        private System.Windows.Forms.LinkLabel lblEditSSHConnection;
        private System.Windows.Forms.Label label3;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxCPUCollectorEditEntry));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkUseOnlyTotalCPUvalue = new System.Windows.Forms.CheckBox();
            this.sshPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optPrivateKey = new System.Windows.Forms.RadioButton();
            this.optPassword = new System.Windows.Forms.RadioButton();
            this.txtPrivateKeyFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassPhrase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdEditPerfCounter = new System.Windows.Forms.Button();
            this.privateKeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSSHConnection = new System.Windows.Forms.TextBox();
            this.lblEditSSHConnection = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(122, 175);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(299, 20);
            this.txtUsername.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Computer name";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachineName.Location = new System.Drawing.Point(12, 90);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(352, 20);
            this.txtMachineName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 392);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 17;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(265, 392);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 16;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkUseOnlyTotalCPUvalue
            // 
            this.chkUseOnlyTotalCPUvalue.AutoSize = true;
            this.chkUseOnlyTotalCPUvalue.Checked = true;
            this.chkUseOnlyTotalCPUvalue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseOnlyTotalCPUvalue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseOnlyTotalCPUvalue.Location = new System.Drawing.Point(15, 291);
            this.chkUseOnlyTotalCPUvalue.Name = "chkUseOnlyTotalCPUvalue";
            this.chkUseOnlyTotalCPUvalue.Size = new System.Drawing.Size(124, 17);
            this.chkUseOnlyTotalCPUvalue.TabIndex = 14;
            this.chkUseOnlyTotalCPUvalue.Text = "Total CPU value only";
            this.chkUseOnlyTotalCPUvalue.UseVisualStyleBackColor = true;
            // 
            // sshPortNumericUpDown
            // 
            this.sshPortNumericUpDown.Location = new System.Drawing.Point(370, 91);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "SSH port";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.optPrivateKey);
            this.groupBox1.Controls.Add(this.optPassword);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auhentication method";
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
            // txtPrivateKeyFile
            // 
            this.txtPrivateKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivateKeyFile.Location = new System.Drawing.Point(122, 232);
            this.txtPrivateKeyFile.Name = "txtPrivateKeyFile";
            this.txtPrivateKeyFile.ReadOnly = true;
            this.txtPrivateKeyFile.Size = new System.Drawing.Size(252, 20);
            this.txtPrivateKeyFile.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Private key file";
            // 
            // txtPassPhrase
            // 
            this.txtPassPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassPhrase.Location = new System.Drawing.Point(122, 258);
            this.txtPassPhrase.Name = "txtPassPhrase";
            this.txtPassPhrase.PasswordChar = '*';
            this.txtPassPhrase.Size = new System.Drawing.Size(299, 20);
            this.txtPassPhrase.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Passphrase";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.errorNumericUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.warningNumericUpDown);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(12, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 57);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alert triggering";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Location = new System.Drawing.Point(11, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Warning";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Location = new System.Drawing.Point(234, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Error";
            // 
            // cmdEditPerfCounter
            // 
            this.cmdEditPerfCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditPerfCounter.Enabled = false;
            this.cmdEditPerfCounter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditPerfCounter.Location = new System.Drawing.Point(380, 230);
            this.cmdEditPerfCounter.Name = "cmdEditPerfCounter";
            this.cmdEditPerfCounter.Size = new System.Drawing.Size(41, 23);
            this.cmdEditPerfCounter.TabIndex = 11;
            this.cmdEditPerfCounter.Text = "- - -";
            this.cmdEditPerfCounter.UseVisualStyleBackColor = true;
            this.cmdEditPerfCounter.Click += new System.EventHandler(this.cmdEditPerfCounter_Click);
            // 
            // privateKeyOpenFileDialog
            // 
            this.privateKeyOpenFileDialog.DefaultExt = "*";
            this.privateKeyOpenFileDialog.Filter = "Files|*.*";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(122, 201);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(299, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "SSH Connection details";
            // 
            // txtSSHConnection
            // 
            this.txtSSHConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSSHConnection.Location = new System.Drawing.Point(12, 25);
            this.txtSSHConnection.Multiline = true;
            this.txtSSHConnection.Name = "txtSSHConnection";
            this.txtSSHConnection.ReadOnly = true;
            this.txtSSHConnection.Size = new System.Drawing.Size(409, 45);
            this.txtSSHConnection.TabIndex = 19;
            this.txtSSHConnection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSSHConnection_MouseClick);
            this.txtSSHConnection.DoubleClick += new System.EventHandler(this.txtSSHConnection_DoubleClick);
            // 
            // lblEditSSHConnection
            // 
            this.lblEditSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditSSHConnection.AutoSize = true;
            this.lblEditSSHConnection.Location = new System.Drawing.Point(396, 9);
            this.lblEditSSHConnection.Name = "lblEditSSHConnection";
            this.lblEditSSHConnection.Size = new System.Drawing.Size(25, 13);
            this.lblEditSSHConnection.TabIndex = 20;
            this.lblEditSSHConnection.TabStop = true;
            this.lblEditSSHConnection.Text = "Edit";
            this.lblEditSSHConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditSSHConnection_LinkClicked);
            // 
            // LinuxCPUCollectorEditEntry
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 427);
            this.Controls.Add(this.lblEditSSHConnection);
            this.Controls.Add(this.txtSSHConnection);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdEditPerfCounter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtPassPhrase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrivateKeyFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sshPortNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkUseOnlyTotalCPUvalue);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinuxCPUCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linux CPU";
            this.Load += new System.EventHandler(this.LinuxCPUCollectorEditEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sshPortNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 
        #endregion

        public LinuxCPUCollectorEditEntry()
        {
            InitializeComponent();
        }

        private QuickMon.Linux.SSHConnectionDetails sshConnectionDetails = new Linux.SSHConnectionDetails();

        private void optPassword_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = !optPassword.Checked;
            txtPassword.ReadOnly = !optPassword.Checked;
            txtPrivateKeyFile.ReadOnly = optPassword.Checked;
            cmdEditPerfCounter.Enabled = !optPassword.Checked;
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        private void optPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = optPrivateKey.Checked;
            txtPassword.ReadOnly = optPrivateKey.Checked;
            txtPrivateKeyFile.ReadOnly = !optPrivateKey.Checked;            
            cmdEditPerfCounter.Enabled = optPrivateKey.Checked;            
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxCPUEntry currentEntry = (LinuxCPUEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxCPUEntry();
            sshConnectionDetails = new Linux.SSHConnectionDetails() { ComputerName = currentEntry.MachineName, SSHPort = currentEntry.SSHPort, SSHSecurityOption = currentEntry.SSHSecurityOption, UserName = currentEntry.UserName, Password = currentEntry.Password, PrivateKeyFile = currentEntry.PrivateKeyFile, PassPhrase = currentEntry.PassPhrase };
            txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            txtMachineName.Text = sshConnectionDetails.ComputerName;
            sshPortNumericUpDown.SaveValueSet(sshConnectionDetails.SSHPort);
            optPrivateKey.Checked = sshConnectionDetails.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
            txtUsername.Text = sshConnectionDetails.UserName;
            txtPassword.Text = sshConnectionDetails.Password;
            txtPrivateKeyFile.Text = sshConnectionDetails.PrivateKeyFile;
            txtPassPhrase.Text = sshConnectionDetails.PassPhrase;

            //txtMachineName.Text = currentEntry.MachineName;
            //sshPortNumericUpDown.SaveValueSet(currentEntry.SSHPort);
            //optPrivateKey.Checked = currentEntry.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
            //txtUsername.Text = currentEntry.UserName;
            //txtPassword.Text = currentEntry.Password;
            //txtPrivateKeyFile.Text = currentEntry.PrivateKeyFile;
            //txtPassPhrase.Text = currentEntry.PassPhrase;
            chkUseOnlyTotalCPUvalue.Checked = currentEntry.UseOnlyTotalCPUvalue;
            warningNumericUpDown.SaveValueSet((decimal)currentEntry.WarningValue);
            errorNumericUpDown.SaveValueSet((decimal)currentEntry.ErrorValue); 
        }
        #endregion

        private void LinuxCPUCollectorEditEntry_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }

        private void cmdEditPerfCounter_Click(object sender, EventArgs e)
        {
            if (txtPrivateKeyFile.Text.Length > 0 && System.IO.Directory.Exists( System.IO.Path.GetDirectoryName( txtPrivateKeyFile.Text)))
            {
                privateKeyOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtPrivateKeyFile.Text);
            }
            if (privateKeyOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPrivateKeyFile.Text = privateKeyOpenFileDialog.FileName;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LinuxCPUEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new LinuxCPUEntry();
            selectedEntry = (LinuxCPUEntry)SelectedEntry;

            selectedEntry.MachineName = sshConnectionDetails.ComputerName;
            selectedEntry.SSHPort = sshConnectionDetails.SSHPort;
            selectedEntry.SSHSecurityOption = sshConnectionDetails.SSHSecurityOption;
            selectedEntry.UserName = sshConnectionDetails.UserName;
            selectedEntry.Password = sshConnectionDetails.Password;
            selectedEntry.PrivateKeyFile = sshConnectionDetails.PrivateKeyFile;
            selectedEntry.PassPhrase = sshConnectionDetails.PassPhrase;

            //selectedEntry.MachineName = txtMachineName.Text;
            //selectedEntry.SSHPort = (int)sshPortNumericUpDown.Value;
            //selectedEntry.SSHSecurityOption = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
            //selectedEntry.UserName = txtUsername.Text;

            //selectedEntry.PrivateKeyFile = txtPrivateKeyFile.Text;
            //selectedEntry.PassPhrase = txtPassPhrase.Text;
            selectedEntry.UseOnlyTotalCPUvalue = chkUseOnlyTotalCPUvalue.Checked;
            selectedEntry.WarningValue = (double)warningNumericUpDown.Value;
            selectedEntry.ErrorValue = (double)errorNumericUpDown.Value;
            
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void txtSSHConnection_DoubleClick(object sender, EventArgs e)
        {
            EditSSHConnection();
        }

        private void lblEditSSHConnection_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            EditSSHConnection();
        }

        private void EditSSHConnection()
        {
            EditSSHConnection editor = new Collectors.EditSSHConnection();
            editor.SSHConnectionDetails = sshConnectionDetails;
            if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sshConnectionDetails = editor.SSHConnectionDetails;
                txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

                txtMachineName.Text = sshConnectionDetails.ComputerName;
                sshPortNumericUpDown.SaveValueSet(sshConnectionDetails.SSHPort);
                optPrivateKey.Checked = sshConnectionDetails.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
                txtUsername.Text = sshConnectionDetails.UserName;
                txtPassword.Text = sshConnectionDetails.Password;
                txtPrivateKeyFile.Text = sshConnectionDetails.PrivateKeyFile;
                txtPassPhrase.Text = sshConnectionDetails.PassPhrase;
            }            
        }

        private void txtSSHConnection_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            EditSSHConnection();
        }
    }
}
