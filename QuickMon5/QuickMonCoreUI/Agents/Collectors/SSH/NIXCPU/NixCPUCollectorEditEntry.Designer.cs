namespace QuickMon.UI
{
    partial class NixCPUCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NixCPUCollectorEditEntry));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.chkUseOnlyTotalCPUvalue = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMSSampleDelay = new System.Windows.Forms.NumericUpDown();
            this.lblEditSSHConnection = new System.Windows.Forms.LinkLabel();
            this.txtSSHConnection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMSSampleDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(12, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 57);
            this.groupBox2.TabIndex = 4;
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
            90,
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
            80,
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
            // chkUseOnlyTotalCPUvalue
            // 
            this.chkUseOnlyTotalCPUvalue.AutoSize = true;
            this.chkUseOnlyTotalCPUvalue.Checked = true;
            this.chkUseOnlyTotalCPUvalue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseOnlyTotalCPUvalue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseOnlyTotalCPUvalue.Location = new System.Drawing.Point(12, 12);
            this.chkUseOnlyTotalCPUvalue.Name = "chkUseOnlyTotalCPUvalue";
            this.chkUseOnlyTotalCPUvalue.Size = new System.Drawing.Size(124, 17);
            this.chkUseOnlyTotalCPUvalue.TabIndex = 0;
            this.chkUseOnlyTotalCPUvalue.Text = "Total CPU value only";
            this.chkUseOnlyTotalCPUvalue.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 191);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(265, 191);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(298, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(148, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "2 Sample delay";
            // 
            // nudMSSampleDelay
            // 
            this.nudMSSampleDelay.Location = new System.Drawing.Point(233, 12);
            this.nudMSSampleDelay.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudMSSampleDelay.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMSSampleDelay.Name = "nudMSSampleDelay";
            this.nudMSSampleDelay.Size = new System.Drawing.Size(59, 20);
            this.nudMSSampleDelay.TabIndex = 2;
            this.nudMSSampleDelay.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // lblEditSSHConnection
            // 
            this.lblEditSSHConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditSSHConnection.AutoSize = true;
            this.lblEditSSHConnection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblEditSSHConnection.Location = new System.Drawing.Point(296, 2);
            this.lblEditSSHConnection.Name = "lblEditSSHConnection";
            this.lblEditSSHConnection.Size = new System.Drawing.Size(109, 13);
            this.lblEditSSHConnection.TabIndex = 6;
            this.lblEditSSHConnection.TabStop = true;
            this.lblEditSSHConnection.Text = "Edit connection string";
            this.lblEditSSHConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditSSHConnection_LinkClicked);
            // 
            // txtSSHConnection
            // 
            this.txtSSHConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSSHConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSSHConnection.Location = new System.Drawing.Point(3, 16);
            this.txtSSHConnection.Multiline = true;
            this.txtSSHConnection.Name = "txtSSHConnection";
            this.txtSSHConnection.ReadOnly = true;
            this.txtSSHConnection.Size = new System.Drawing.Size(403, 52);
            this.txtSSHConnection.TabIndex = 7;
            this.txtSSHConnection.DoubleClick += new System.EventHandler(this.txtSSHConnection_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "SSH Connection details";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblEditSSHConnection);
            this.groupBox1.Controls.Add(this.txtSSHConnection);
            this.groupBox1.Location = new System.Drawing.Point(12, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SSH Connection details";
            // 
            // NixCPUCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 225);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkUseOnlyTotalCPUvalue);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMSSampleDelay);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NixCPUCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nix CPU";
            this.Load += new System.EventHandler(this.NixCPUCollectorEditEntry_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMSSampleDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkUseOnlyTotalCPUvalue;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMSSampleDelay;
        private System.Windows.Forms.LinkLabel lblEditSSHConnection;
        private System.Windows.Forms.TextBox txtSSHConnection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}