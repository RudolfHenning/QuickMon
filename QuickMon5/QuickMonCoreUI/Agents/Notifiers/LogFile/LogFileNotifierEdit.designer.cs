namespace QuickMon.UI
{
    partial class LogFileNotifierEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileNotifierEdit));
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCreateNewFileSizeKB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.saveFileDialogLogFile = new System.Windows.Forms.SaveFileDialog();
            this.chkAppendDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkUseLocalTimeFormat = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomTimeFormat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateNewFileSizeKB)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Create new file size";
            // 
            // numericUpDownCreateNewFileSizeKB
            // 
            this.numericUpDownCreateNewFileSizeKB.Location = new System.Drawing.Point(111, 66);
            this.numericUpDownCreateNewFileSizeKB.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.numericUpDownCreateNewFileSizeKB.Name = "numericUpDownCreateNewFileSizeKB";
            this.numericUpDownCreateNewFileSizeKB.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownCreateNewFileSizeKB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log file path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "KB - 0 = means never";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBrowse.Location = new System.Drawing.Point(443, 10);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(33, 23);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "- - -";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtLogFilePath
            // 
            this.txtLogFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLogFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtLogFilePath.Location = new System.Drawing.Point(111, 12);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.Size = new System.Drawing.Size(326, 20);
            this.txtLogFilePath.TabIndex = 1;
            this.txtLogFilePath.TextChanged += new System.EventHandler(this.txtLogFilePath_TextChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(400, 105);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(319, 105);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 11;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // saveFileDialogLogFile
            // 
            this.saveFileDialogLogFile.DefaultExt = "log";
            this.saveFileDialogLogFile.Filter = "Log Files|*.log";
            // 
            // chkAppendDate
            // 
            this.chkAppendDate.AutoSize = true;
            this.chkAppendDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAppendDate.Location = new System.Drawing.Point(109, 92);
            this.chkAppendDate.Name = "chkAppendDate";
            this.chkAppendDate.Size = new System.Drawing.Size(141, 17);
            this.chkAppendDate.TabIndex = 10;
            this.chkAppendDate.Text = "Append date to file name";
            this.chkAppendDate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Time format";
            // 
            // chkUseLocalTimeFormat
            // 
            this.chkUseLocalTimeFormat.AutoSize = true;
            this.chkUseLocalTimeFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseLocalTimeFormat.Location = new System.Drawing.Point(111, 38);
            this.chkUseLocalTimeFormat.Name = "chkUseLocalTimeFormat";
            this.chkUseLocalTimeFormat.Size = new System.Drawing.Size(121, 17);
            this.chkUseLocalTimeFormat.TabIndex = 4;
            this.chkUseLocalTimeFormat.Text = "Use local time format";
            this.chkUseLocalTimeFormat.UseVisualStyleBackColor = true;
            this.chkUseLocalTimeFormat.CheckedChanged += new System.EventHandler(this.chkUseLocalTimeFormat_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Custom format";
            // 
            // txtCustomTimeFormat
            // 
            this.txtCustomTimeFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomTimeFormat.Location = new System.Drawing.Point(318, 37);
            this.txtCustomTimeFormat.Name = "txtCustomTimeFormat";
            this.txtCustomTimeFormat.Size = new System.Drawing.Size(157, 20);
            this.txtCustomTimeFormat.TabIndex = 6;
            this.txtCustomTimeFormat.Text = "yyyy-MM-dd HH:mm:ss";
            // 
            // LogFileNotifierEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 140);
            this.Controls.Add(this.txtCustomTimeFormat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkUseLocalTimeFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAppendDate);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownCreateNewFileSizeKB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtLogFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogFileNotifierEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log File Notifier";
            this.Load += new System.EventHandler(this.LogFileNotifierEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateNewFileSizeKB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownCreateNewFileSizeKB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.TextBox txtLogFilePath;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLogFile;
        private System.Windows.Forms.CheckBox chkAppendDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkUseLocalTimeFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomTimeFormat;
    }
}