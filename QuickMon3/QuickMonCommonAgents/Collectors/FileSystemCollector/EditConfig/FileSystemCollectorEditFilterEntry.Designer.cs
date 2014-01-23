namespace QuickMon.Collectors
{
    partial class FileSystemCollectorEditFilterEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSystemCollectorEditFilterEntry));
            this.chkDirectoryExistOnly = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownFileSizeMax = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownFileSizeMin = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownFileAgeMax = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownFileAgeMin = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownSizeErrorIndicator = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownSizeWarningIndicator = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.numericUpDownCountErrorIndicator = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCountWarningIndicator = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeErrorIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeWarningIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountErrorIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountWarningIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDirectoryExistOnly
            // 
            this.chkDirectoryExistOnly.AutoSize = true;
            this.chkDirectoryExistOnly.Location = new System.Drawing.Point(66, 39);
            this.chkDirectoryExistOnly.Name = "chkDirectoryExistOnly";
            this.chkDirectoryExistOnly.Size = new System.Drawing.Size(160, 17);
            this.chkDirectoryExistOnly.TabIndex = 3;
            this.chkDirectoryExistOnly.Text = "Only check if directory exists";
            this.chkDirectoryExistOnly.UseVisualStyleBackColor = true;
            this.chkDirectoryExistOnly.CheckedChanged += new System.EventHandler(this.chkDirectoryExistOnly_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(399, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "File size - File size in KB must be between min/max to be included. 0 means no li" +
    "mit.";
            // 
            // numericUpDownFileSizeMax
            // 
            this.numericUpDownFileSizeMax.Location = new System.Drawing.Point(214, 253);
            this.numericUpDownFileSizeMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFileSizeMax.Name = "numericUpDownFileSizeMax";
            this.numericUpDownFileSizeMax.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileSizeMax.TabIndex = 28;
            this.numericUpDownFileSizeMax.ValueChanged += new System.EventHandler(this.numericUpDownFileSizeMax_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(159, 255);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Maximum";
            // 
            // numericUpDownFileSizeMin
            // 
            this.numericUpDownFileSizeMin.Location = new System.Drawing.Point(66, 253);
            this.numericUpDownFileSizeMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFileSizeMin.Name = "numericUpDownFileSizeMin";
            this.numericUpDownFileSizeMin.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileSizeMin.TabIndex = 26;
            this.numericUpDownFileSizeMin.ValueChanged += new System.EventHandler(this.numericUpDownFileSizeMin_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 255);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Minimum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(425, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "File age - File age in seconds must be between min/max to be included. 0 means no" +
    " limit.";
            // 
            // numericUpDownFileAgeMax
            // 
            this.numericUpDownFileAgeMax.Location = new System.Drawing.Point(214, 203);
            this.numericUpDownFileAgeMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFileAgeMax.Name = "numericUpDownFileAgeMax";
            this.numericUpDownFileAgeMax.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileAgeMax.TabIndex = 23;
            this.numericUpDownFileAgeMax.ValueChanged += new System.EventHandler(this.numericUpDownFileAgeMax_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Maximum";
            // 
            // numericUpDownFileAgeMin
            // 
            this.numericUpDownFileAgeMin.Location = new System.Drawing.Point(66, 203);
            this.numericUpDownFileAgeMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFileAgeMin.Name = "numericUpDownFileAgeMin";
            this.numericUpDownFileAgeMin.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFileAgeMin.TabIndex = 21;
            this.numericUpDownFileAgeMin.ValueChanged += new System.EventHandler(this.numericUpDownFileAgeMin_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Minimum";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Total Size - Total size of all files before specified condition is set";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "KB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "KB";
            // 
            // numericUpDownSizeErrorIndicator
            // 
            this.numericUpDownSizeErrorIndicator.Location = new System.Drawing.Point(214, 155);
            this.numericUpDownSizeErrorIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSizeErrorIndicator.Name = "numericUpDownSizeErrorIndicator";
            this.numericUpDownSizeErrorIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownSizeErrorIndicator.TabIndex = 17;
            this.numericUpDownSizeErrorIndicator.ValueChanged += new System.EventHandler(this.numericUpDownSizeErrorIndicator_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Errors";
            // 
            // numericUpDownSizeWarningIndicator
            // 
            this.numericUpDownSizeWarningIndicator.Location = new System.Drawing.Point(66, 155);
            this.numericUpDownSizeWarningIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSizeWarningIndicator.Name = "numericUpDownSizeWarningIndicator";
            this.numericUpDownSizeWarningIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownSizeWarningIndicator.TabIndex = 14;
            this.numericUpDownSizeWarningIndicator.ValueChanged += new System.EventHandler(this.numericUpDownSizeWarningIndicator_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Warnings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(332, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Total Count - Smallest number of files before specified condition is set";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(376, 286);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 30;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(295, 286);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 29;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // numericUpDownCountErrorIndicator
            // 
            this.numericUpDownCountErrorIndicator.Location = new System.Drawing.Point(214, 105);
            this.numericUpDownCountErrorIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCountErrorIndicator.Name = "numericUpDownCountErrorIndicator";
            this.numericUpDownCountErrorIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownCountErrorIndicator.TabIndex = 11;
            this.numericUpDownCountErrorIndicator.ValueChanged += new System.EventHandler(this.numericUpDownCountErrorIndicator_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Errors";
            // 
            // numericUpDownCountWarningIndicator
            // 
            this.numericUpDownCountWarningIndicator.Location = new System.Drawing.Point(66, 105);
            this.numericUpDownCountWarningIndicator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCountWarningIndicator.Name = "numericUpDownCountWarningIndicator";
            this.numericUpDownCountWarningIndicator.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownCountWarningIndicator.TabIndex = 9;
            this.numericUpDownCountWarningIndicator.ValueChanged += new System.EventHandler(this.numericUpDownCountWarningIndicator_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Warnings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "e.g *.*";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(66, 62);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(101, 20);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.Text = "*.*";
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowse.Location = new System.Drawing.Point(383, 11);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(68, 23);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtDirectory.Location = new System.Drawing.Point(66, 13);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(311, 20);
            this.txtDirectory.TabIndex = 1;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory";
            // 
            // FileSystemCollectorEditFilterEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 320);
            this.Controls.Add(this.chkDirectoryExistOnly);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numericUpDownFileSizeMax);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.numericUpDownFileSizeMin);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownFileAgeMax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownFileAgeMin);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDownSizeErrorIndicator);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDownSizeWarningIndicator);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.numericUpDownCountErrorIndicator);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownCountWarningIndicator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSystemCollectorEditFilterEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Filte rEntry";
            this.Load += new System.EventHandler(this.FileSystemCollectorEditFilterEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileSizeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileAgeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeErrorIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeWarningIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountErrorIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountWarningIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDirectoryExistOnly;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDownFileSizeMax;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownFileSizeMin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownFileAgeMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownFileAgeMin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeErrorIndicator;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeWarningIndicator;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.NumericUpDown numericUpDownCountErrorIndicator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCountWarningIndicator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}