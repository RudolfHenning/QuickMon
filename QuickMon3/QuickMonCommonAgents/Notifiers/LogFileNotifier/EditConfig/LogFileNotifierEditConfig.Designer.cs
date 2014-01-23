namespace QuickMon.Notifiers
{
    partial class LogFileNotifierEditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileNotifierEditConfig));
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCreateNewFileSizeKB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialogLogFile = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateNewFileSizeKB)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(400, 74);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(319, 74);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Create new file size";
            // 
            // numericUpDownCreateNewFileSizeKB
            // 
            this.numericUpDownCreateNewFileSizeKB.Location = new System.Drawing.Point(110, 38);
            this.numericUpDownCreateNewFileSizeKB.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.numericUpDownCreateNewFileSizeKB.Name = "numericUpDownCreateNewFileSizeKB";
            this.numericUpDownCreateNewFileSizeKB.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownCreateNewFileSizeKB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log file path";
            // 
            // saveFileDialogLogFile
            // 
            this.saveFileDialogLogFile.DefaultExt = "log";
            this.saveFileDialogLogFile.Filter = "Log Files|*.log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "KB - 0 = means never";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowse.Location = new System.Drawing.Point(442, 10);
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
            this.txtLogFilePath.Location = new System.Drawing.Point(110, 12);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.Size = new System.Drawing.Size(326, 20);
            this.txtLogFilePath.TabIndex = 1;
            this.txtLogFilePath.TextChanged += new System.EventHandler(this.txtLogFilePath_TextChanged);
            // 
            // LogFileNotifierEditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 109);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownCreateNewFileSizeKB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtLogFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogFileNotifierEditConfig";
            this.Text = "LogFileNotifierEditConfig";
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.txtLogFilePath, 0);
            this.Controls.SetChildIndex(this.cmdBrowse, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.numericUpDownCreateNewFileSizeKB, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateNewFileSizeKB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownCreateNewFileSizeKB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLogFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.TextBox txtLogFilePath;
    }
}