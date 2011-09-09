namespace QuickMon
{
    partial class EditDiskSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDiskSpace));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDriveLetter = new System.Windows.Forms.ComboBox();
            this.numericUpDownWarningSizeLeftMB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownErrorSizeLeftMB = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkWarningOnNotAvailable = new System.Windows.Forms.CheckBox();
            this.lblDriveType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarningSizeLeftMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorSizeLeftMB)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(242, 127);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(161, 127);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drive letter";
            // 
            // cboDriveLetter
            // 
            this.cboDriveLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDriveLetter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDriveLetter.FormattingEnabled = true;
            this.cboDriveLetter.Items.AddRange(new object[] {
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cboDriveLetter.Location = new System.Drawing.Point(123, 12);
            this.cboDriveLetter.Name = "cboDriveLetter";
            this.cboDriveLetter.Size = new System.Drawing.Size(64, 21);
            this.cboDriveLetter.TabIndex = 1;
            this.cboDriveLetter.SelectedIndexChanged += new System.EventHandler(this.cboDriveLetter_SelectedIndexChanged);
            // 
            // numericUpDownWarningSizeLeftMB
            // 
            this.numericUpDownWarningSizeLeftMB.Location = new System.Drawing.Point(123, 39);
            this.numericUpDownWarningSizeLeftMB.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.numericUpDownWarningSizeLeftMB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWarningSizeLeftMB.Name = "numericUpDownWarningSizeLeftMB";
            this.numericUpDownWarningSizeLeftMB.Size = new System.Drawing.Size(94, 20);
            this.numericUpDownWarningSizeLeftMB.TabIndex = 4;
            this.numericUpDownWarningSizeLeftMB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownErrorSizeLeftMB
            // 
            this.numericUpDownErrorSizeLeftMB.Location = new System.Drawing.Point(123, 65);
            this.numericUpDownErrorSizeLeftMB.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.numericUpDownErrorSizeLeftMB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownErrorSizeLeftMB.Name = "numericUpDownErrorSizeLeftMB";
            this.numericUpDownErrorSizeLeftMB.Size = new System.Drawing.Size(94, 20);
            this.numericUpDownErrorSizeLeftMB.TabIndex = 7;
            this.numericUpDownErrorSizeLeftMB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Warning size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Error size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "MB left";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "MB left";
            // 
            // chkWarningOnNotAvailable
            // 
            this.chkWarningOnNotAvailable.AutoSize = true;
            this.chkWarningOnNotAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkWarningOnNotAvailable.Location = new System.Drawing.Point(19, 91);
            this.chkWarningOnNotAvailable.Name = "chkWarningOnNotAvailable";
            this.chkWarningOnNotAvailable.Size = new System.Drawing.Size(219, 17);
            this.chkWarningOnNotAvailable.TabIndex = 9;
            this.chkWarningOnNotAvailable.Text = "Raise warning when drive is not available";
            this.chkWarningOnNotAvailable.UseVisualStyleBackColor = true;
            // 
            // lblDriveType
            // 
            this.lblDriveType.AutoSize = true;
            this.lblDriveType.Location = new System.Drawing.Point(193, 15);
            this.lblDriveType.Name = "lblDriveType";
            this.lblDriveType.Size = new System.Drawing.Size(10, 13);
            this.lblDriveType.TabIndex = 2;
            this.lblDriveType.Text = ".";
            // 
            // EditDiskSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 162);
            this.Controls.Add(this.lblDriveType);
            this.Controls.Add(this.chkWarningOnNotAvailable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownErrorSizeLeftMB);
            this.Controls.Add(this.numericUpDownWarningSizeLeftMB);
            this.Controls.Add(this.cboDriveLetter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDiskSpace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Disk space";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarningSizeLeftMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorSizeLeftMB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDriveLetter;
        private System.Windows.Forms.NumericUpDown numericUpDownWarningSizeLeftMB;
        private System.Windows.Forms.NumericUpDown numericUpDownErrorSizeLeftMB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkWarningOnNotAvailable;
        private System.Windows.Forms.Label lblDriveType;
    }
}