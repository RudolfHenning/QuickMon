namespace QuickMon.Collectors
{
    partial class LinuxDiskSpaceCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxDiskSpaceCollectorEditEntry));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.warningNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.errorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblAutoAdd = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileSystem = new System.Windows.Forms.TextBox();
            this.lblAddFileSystem = new System.Windows.Forms.LinkLabel();
            this.lvwFileSystems = new QuickMon.ListViewEx();
            this.fileSystemColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.warningColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.privateKeyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblEditSSHConnection = new System.Windows.Forms.LinkLabel();
            this.txtSSHConnection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(265, 255);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 255);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
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
            // warningNumericUpDown
            // 
            this.warningNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.warningNumericUpDown.DecimalPlaces = 2;
            this.warningNumericUpDown.Location = new System.Drawing.Point(100, 146);
            this.warningNumericUpDown.Name = "warningNumericUpDown";
            this.warningNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.warningNumericUpDown.TabIndex = 7;
            this.warningNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.warningNumericUpDown.ValueChanged += new System.EventHandler(this.warningNumericUpDown_ValueChanged);
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
            // errorNumericUpDown
            // 
            this.errorNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.errorNumericUpDown.DecimalPlaces = 2;
            this.errorNumericUpDown.Location = new System.Drawing.Point(277, 146);
            this.errorNumericUpDown.Name = "errorNumericUpDown";
            this.errorNumericUpDown.Size = new System.Drawing.Size(126, 20);
            this.errorNumericUpDown.TabIndex = 9;
            this.errorNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.errorNumericUpDown.ValueChanged += new System.EventHandler(this.errorNumericUpDown_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.lblAutoAdd);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.txtFileSystem);
            this.groupBox6.Controls.Add(this.lblAddFileSystem);
            this.groupBox6.Controls.Add(this.lvwFileSystems);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.errorNumericUpDown);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.warningNumericUpDown);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox6.Location = new System.Drawing.Point(12, 76);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(409, 172);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Alert triggering";
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
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File system";
            // 
            // txtFileSystem
            // 
            this.txtFileSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileSystem.Location = new System.Drawing.Point(100, 119);
            this.txtFileSystem.Name = "txtFileSystem";
            this.txtFileSystem.Size = new System.Drawing.Size(303, 20);
            this.txtFileSystem.TabIndex = 5;
            this.txtFileSystem.TextChanged += new System.EventHandler(this.txtFileSystem_TextChanged);
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
            // lvwFileSystems
            // 
            this.lvwFileSystems.AutoResizeColumnEnabled = false;
            this.lvwFileSystems.AutoResizeColumnIndex = 0;
            this.lvwFileSystems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileSystemColumnHeader,
            this.warningColumnHeader,
            this.errorColumnHeader});
            this.lvwFileSystems.FullRowSelect = true;
            this.lvwFileSystems.Location = new System.Drawing.Point(8, 32);
            this.lvwFileSystems.Name = "lvwFileSystems";
            this.lvwFileSystems.Size = new System.Drawing.Size(395, 81);
            this.lvwFileSystems.TabIndex = 3;
            this.lvwFileSystems.UseCompatibleStateImageBehavior = false;
            this.lvwFileSystems.View = System.Windows.Forms.View.Details;
            this.lvwFileSystems.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwFileSystems_DeleteKeyPressed);
            this.lvwFileSystems.SelectedIndexChanged += new System.EventHandler(this.lvwFileSystems_SelectedIndexChanged);
            // 
            // fileSystemColumnHeader
            // 
            this.fileSystemColumnHeader.Text = "File system";
            this.fileSystemColumnHeader.Width = 256;
            // 
            // warningColumnHeader
            // 
            this.warningColumnHeader.Text = "Warning";
            // 
            // errorColumnHeader
            // 
            this.errorColumnHeader.Text = "Error";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File systems";
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
            this.lblEditSSHConnection.TabIndex = 2;
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
            this.txtSSHConnection.TabIndex = 1;
            this.txtSSHConnection.DoubleClick += new System.EventHandler(this.txtSSHConnection_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "SSH Connection details";
            // 
            // LinuxDiskSpaceCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 289);
            this.Controls.Add(this.lblEditSSHConnection);
            this.Controls.Add(this.txtSSHConnection);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LinuxDiskSpaceCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linux Disk Space";
            this.Load += new System.EventHandler(this.LinuxDiskSpaceCollectorEditEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warningNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumericUpDown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown warningNumericUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown errorNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private ListViewEx lvwFileSystems;
        private System.Windows.Forms.ColumnHeader fileSystemColumnHeader;
        private System.Windows.Forms.ColumnHeader warningColumnHeader;
        private System.Windows.Forms.ColumnHeader errorColumnHeader;
        private System.Windows.Forms.LinkLabel lblAddFileSystem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileSystem;
        private System.Windows.Forms.LinkLabel lblAutoAdd;
        private System.Windows.Forms.OpenFileDialog privateKeyOpenFileDialog;
        private System.Windows.Forms.LinkLabel lblEditSSHConnection;
        private System.Windows.Forms.TextBox txtSSHConnection;
        private System.Windows.Forms.Label label9;
    }
}