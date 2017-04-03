namespace QuickMon.UI
{
    partial class RSSNotifierEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RSSNotifierEdit));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGenerator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLineLink = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.keepDataDaysNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblLineDescription = new System.Windows.Forms.Label();
            this.txtLineDescription = new System.Windows.Forms.TextBox();
            this.lblCopyCollectorName = new System.Windows.Forms.Label();
            this.lblCopyPreviousState = new System.Windows.Forms.Label();
            this.lblCopyCurrentState = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtLineCategory = new System.Windows.Forms.TextBox();
            this.lblLineTitle = new System.Windows.Forms.Label();
            this.txtLineTitle = new System.Windows.Forms.TextBox();
            this.lblCopyAlertLevel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRSSFilePath = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.saveFileDialogLogFile = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keepDataDaysNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(401, 459);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(320, 459);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLanguage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGenerator);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLink);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 158);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RSS Channel details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Language";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLanguage.Location = new System.Drawing.Point(142, 123);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(316, 20);
            this.txtLanguage.TabIndex = 9;
            this.txtLanguage.Text = "en-us";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(142, 97);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(316, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Generator";
            // 
            // txtGenerator
            // 
            this.txtGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenerator.Location = new System.Drawing.Point(142, 71);
            this.txtGenerator.Name = "txtGenerator";
            this.txtGenerator.Size = new System.Drawing.Size(316, 20);
            this.txtGenerator.TabIndex = 5;
            this.txtGenerator.Text = "QuickMon RSS notifier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Link";
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Location = new System.Drawing.Point(142, 45);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(316, 20);
            this.txtLink.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(142, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(316, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "QuickMon RSS alerts";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtLineLink);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.keepDataDaysNumericUpDown);
            this.groupBox2.Controls.Add(this.lblLineDescription);
            this.groupBox2.Controls.Add(this.txtLineDescription);
            this.groupBox2.Controls.Add(this.lblCopyCollectorName);
            this.groupBox2.Controls.Add(this.lblCopyPreviousState);
            this.groupBox2.Controls.Add(this.lblCopyCurrentState);
            this.groupBox2.Controls.Add(this.lblCategory);
            this.groupBox2.Controls.Add(this.txtLineCategory);
            this.groupBox2.Controls.Add(this.lblLineTitle);
            this.groupBox2.Controls.Add(this.txtLineTitle);
            this.groupBox2.Controls.Add(this.lblCopyAlertLevel);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 257);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Line item settings";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(8, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "%LineGuid%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Link";
            // 
            // txtLineLink
            // 
            this.txtLineLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineLink.Location = new System.Drawing.Point(142, 174);
            this.txtLineLink.Name = "txtLineLink";
            this.txtLineLink.Size = new System.Drawing.Size(316, 20);
            this.txtLineLink.TabIndex = 18;
            this.txtLineLink.Text = "%LineGuid%";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(365, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "%DateTime%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(206, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Days";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Keep entries for";
            // 
            // keepDataDaysNumericUpDown
            // 
            this.keepDataDaysNumericUpDown.Location = new System.Drawing.Point(142, 19);
            this.keepDataDaysNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.keepDataDaysNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.keepDataDaysNumericUpDown.Name = "keepDataDaysNumericUpDown";
            this.keepDataDaysNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.keepDataDaysNumericUpDown.TabIndex = 1;
            this.keepDataDaysNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblLineDescription
            // 
            this.lblLineDescription.AutoSize = true;
            this.lblLineDescription.Location = new System.Drawing.Point(10, 100);
            this.lblLineDescription.Name = "lblLineDescription";
            this.lblLineDescription.Size = new System.Drawing.Size(60, 13);
            this.lblLineDescription.TabIndex = 7;
            this.lblLineDescription.Text = "Description";
            this.lblLineDescription.DoubleClick += new System.EventHandler(this.lblLineDescription_DoubleClick);
            // 
            // txtLineDescription
            // 
            this.txtLineDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineDescription.Location = new System.Drawing.Point(142, 97);
            this.txtLineDescription.Multiline = true;
            this.txtLineDescription.Name = "txtLineDescription";
            this.txtLineDescription.Size = new System.Drawing.Size(316, 71);
            this.txtLineDescription.TabIndex = 8;
            this.txtLineDescription.Text = "<b>Date Time:</b> %DateTime%<br/>\r\n<b>Current state:</b> %CurrentState%<br/>\r\n<b>" +
    "Collector:</b> %CollectorType%<br/>\r\n<b>Details</b><br/>\r\n%Details%";
            // 
            // lblCopyCollectorName
            // 
            this.lblCopyCollectorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCopyCollectorName.AutoSize = true;
            this.lblCopyCollectorName.ForeColor = System.Drawing.Color.Gray;
            this.lblCopyCollectorName.Location = new System.Drawing.Point(267, 218);
            this.lblCopyCollectorName.Name = "lblCopyCollectorName";
            this.lblCopyCollectorName.Size = new System.Drawing.Size(92, 13);
            this.lblCopyCollectorName.TabIndex = 14;
            this.lblCopyCollectorName.Text = "%CollectorName%";
            // 
            // lblCopyPreviousState
            // 
            this.lblCopyPreviousState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCopyPreviousState.AutoSize = true;
            this.lblCopyPreviousState.ForeColor = System.Drawing.Color.Gray;
            this.lblCopyPreviousState.Location = new System.Drawing.Point(172, 218);
            this.lblCopyPreviousState.Name = "lblCopyPreviousState";
            this.lblCopyPreviousState.Size = new System.Drawing.Size(89, 13);
            this.lblCopyPreviousState.TabIndex = 13;
            this.lblCopyPreviousState.Text = "%PreviousState%";
            // 
            // lblCopyCurrentState
            // 
            this.lblCopyCurrentState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCopyCurrentState.AutoSize = true;
            this.lblCopyCurrentState.ForeColor = System.Drawing.Color.Gray;
            this.lblCopyCurrentState.Location = new System.Drawing.Point(84, 218);
            this.lblCopyCurrentState.Name = "lblCopyCurrentState";
            this.lblCopyCurrentState.Size = new System.Drawing.Size(82, 13);
            this.lblCopyCurrentState.TabIndex = 12;
            this.lblCopyCurrentState.Text = "%CurrentState%";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(10, 74);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category";
            this.lblCategory.DoubleClick += new System.EventHandler(this.lblCategory_DoubleClick);
            // 
            // txtLineCategory
            // 
            this.txtLineCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineCategory.Location = new System.Drawing.Point(142, 71);
            this.txtLineCategory.Name = "txtLineCategory";
            this.txtLineCategory.Size = new System.Drawing.Size(316, 20);
            this.txtLineCategory.TabIndex = 6;
            this.txtLineCategory.Text = "%CurrentState%, %CollectorType%";
            // 
            // lblLineTitle
            // 
            this.lblLineTitle.AutoSize = true;
            this.lblLineTitle.Location = new System.Drawing.Point(10, 48);
            this.lblLineTitle.Name = "lblLineTitle";
            this.lblLineTitle.Size = new System.Drawing.Size(27, 13);
            this.lblLineTitle.TabIndex = 3;
            this.lblLineTitle.Text = "Title";
            this.lblLineTitle.DoubleClick += new System.EventHandler(this.lblLineTitle_DoubleClick);
            // 
            // txtLineTitle
            // 
            this.txtLineTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineTitle.Location = new System.Drawing.Point(142, 45);
            this.txtLineTitle.Name = "txtLineTitle";
            this.txtLineTitle.Size = new System.Drawing.Size(316, 20);
            this.txtLineTitle.TabIndex = 4;
            this.txtLineTitle.Text = "%CollectorName% - %AlertLevel%";
            // 
            // lblCopyAlertLevel
            // 
            this.lblCopyAlertLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCopyAlertLevel.AutoSize = true;
            this.lblCopyAlertLevel.ForeColor = System.Drawing.Color.Gray;
            this.lblCopyAlertLevel.Location = new System.Drawing.Point(8, 218);
            this.lblCopyAlertLevel.Name = "lblCopyAlertLevel";
            this.lblCopyAlertLevel.Size = new System.Drawing.Size(70, 13);
            this.lblCopyAlertLevel.TabIndex = 11;
            this.lblCopyAlertLevel.Text = "%AlertLevel%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "RSS file location";
            // 
            // txtRSSFilePath
            // 
            this.txtRSSFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRSSFilePath.Location = new System.Drawing.Point(154, 6);
            this.txtRSSFilePath.Name = "txtRSSFilePath";
            this.txtRSSFilePath.Size = new System.Drawing.Size(283, 20);
            this.txtRSSFilePath.TabIndex = 1;
            this.txtRSSFilePath.Text = "rss.xml";
            this.txtRSSFilePath.TextChanged += new System.EventHandler(this.txtRSSFilePath_TextChanged);
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowse.Location = new System.Drawing.Point(443, 4);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(33, 23);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "- - -";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // saveFileDialogLogFile
            // 
            this.saveFileDialogLogFile.DefaultExt = "xml";
            this.saveFileDialogLogFile.FileName = "rss.xml";
            this.saveFileDialogLogFile.Filter = "RSS Files|*.xml";
            // 
            // RSSNotifierEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(488, 494);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRSSFilePath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RSSNotifierEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSSNotifierEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keepDataDaysNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGenerator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCopyAlertLevel;
        private System.Windows.Forms.Label lblLineTitle;
        private System.Windows.Forms.TextBox txtLineTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtLineCategory;
        private System.Windows.Forms.Label lblCopyPreviousState;
        private System.Windows.Forms.Label lblCopyCurrentState;
        private System.Windows.Forms.Label lblCopyCollectorName;
        private System.Windows.Forms.Label lblLineDescription;
        private System.Windows.Forms.TextBox txtLineDescription;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown keepDataDaysNumericUpDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRSSFilePath;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLogFile;
        private System.Windows.Forms.Label label6;
        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLineLink;
        private System.Windows.Forms.Label label8;
    }
}