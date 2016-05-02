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
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblWarning = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblError = new System.Windows.Forms.Label();
            this.alertTriggeringGroupBox = new System.Windows.Forms.GroupBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.privateKeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblEditSSHConnection = new System.Windows.Forms.LinkLabel();
            this.txtSSHConnection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            this.alertTriggeringGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.DecimalPlaces = 3;
            this.errorNumericUpDown.Location = new System.Drawing.Point(269, 19);
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.errorNumericUpDown.TabIndex = 3;
            this.errorNumericUpDown.Value = new decimal(new int[] {
            10,
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
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.warningNumericUpDown.TabIndex = 1;
            this.warningNumericUpDown.Value = new decimal(new int[] {
            20,
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
            this.alertTriggeringGroupBox.Location = new System.Drawing.Point(12, 76);
            this.alertTriggeringGroupBox.Name = "alertTriggeringGroupBox";
            this.alertTriggeringGroupBox.Size = new System.Drawing.Size(409, 57);
            this.alertTriggeringGroupBox.TabIndex = 14;
            this.alertTriggeringGroupBox.TabStop = false;
            this.alertTriggeringGroupBox.Text = "Alert triggering";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 143);
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
            this.cmdOK.Location = new System.Drawing.Point(265, 143);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // privateKeyOpenFileDialog
            // 
            this.privateKeyOpenFileDialog.DefaultExt = "*";
            this.privateKeyOpenFileDialog.Filter = "Files|*.*";
            // 
            // lblEditSSHConnection
            // 
            this.lblEditSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditSSHConnection.AutoSize = true;
            this.lblEditSSHConnection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblEditSSHConnection.Location = new System.Drawing.Point(396, 9);
            this.lblEditSSHConnection.Name = "lblEditSSHConnection";
            this.lblEditSSHConnection.Size = new System.Drawing.Size(25, 13);
            this.lblEditSSHConnection.TabIndex = 19;
            this.lblEditSSHConnection.TabStop = true;
            this.lblEditSSHConnection.Text = "Edit";
            this.lblEditSSHConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditSSHConnection_LinkClicked);
            // 
            // txtSSHConnection
            // 
            this.txtSSHConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSSHConnection.Location = new System.Drawing.Point(12, 25);
            this.txtSSHConnection.Multiline = true;
            this.txtSSHConnection.Name = "txtSSHConnection";
            this.txtSSHConnection.ReadOnly = true;
            this.txtSSHConnection.Size = new System.Drawing.Size(409, 45);
            this.txtSSHConnection.TabIndex = 18;
            this.txtSSHConnection.DoubleClick += new System.EventHandler(this.txtSSHConnection_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "SSH Connection details";
            // 
            // LinuxMemoryCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 177);
            this.Controls.Add(this.lblEditSSHConnection);
            this.Controls.Add(this.txtSSHConnection);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.alertTriggeringGroupBox);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinuxMemoryCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linux Memory Free Percentage";
            this.Load += new System.EventHandler(this.LinuxMemoryCollectorEditEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            this.alertTriggeringGroupBox.ResumeLayout(false);
            this.alertTriggeringGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.OpenFileDialog privateKeyOpenFileDialog;
        private System.Windows.Forms.GroupBox alertTriggeringGroupBox;
        private System.Windows.Forms.LinkLabel lblEditSSHConnection;
        private System.Windows.Forms.TextBox txtSSHConnection;
        private System.Windows.Forms.Label label9;
        
    }
}