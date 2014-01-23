namespace QuickMon.Collectors
{
    partial class FileSystemCollectorEditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSystemCollectorEditConfig));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarningCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderErrorCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarningSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderErrorSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAgeMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAgeMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSizeMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSizeMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(626, 317);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(545, 317);
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPath,
            this.columnHeaderWarningCount,
            this.columnHeaderErrorCount,
            this.columnHeaderWarningSize,
            this.columnHeaderErrorSize,
            this.columnHeaderAgeMin,
            this.columnHeaderAgeMax,
            this.columnHeaderSizeMin,
            this.columnHeaderSizeMax});
            this.lvwEntries.Size = new System.Drawing.Size(715, 267);
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "Path";
            this.columnHeaderPath.Width = 201;
            // 
            // columnHeaderWarningCount
            // 
            this.columnHeaderWarningCount.Text = "Warning count";
            this.columnHeaderWarningCount.Width = 82;
            // 
            // columnHeaderErrorCount
            // 
            this.columnHeaderErrorCount.Text = "Error count";
            this.columnHeaderErrorCount.Width = 64;
            // 
            // columnHeaderWarningSize
            // 
            this.columnHeaderWarningSize.Text = "Warning Size KB";
            this.columnHeaderWarningSize.Width = 62;
            // 
            // columnHeaderErrorSize
            // 
            this.columnHeaderErrorSize.Text = "Error Size KB";
            // 
            // columnHeaderAgeMin
            // 
            this.columnHeaderAgeMin.Text = "Age min";
            // 
            // columnHeaderAgeMax
            // 
            this.columnHeaderAgeMax.Text = "Age max";
            // 
            // columnHeaderSizeMin
            // 
            this.columnHeaderSizeMin.Text = "Size min";
            // 
            // columnHeaderSizeMax
            // 
            this.columnHeaderSizeMax.Text = "Size max";
            // 
            // FileSystemCollectorEditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 347);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "FileSystemCollectorEditConfig";
            this.Text = "Edit Config";
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ColumnHeader columnHeaderWarningCount;
        private System.Windows.Forms.ColumnHeader columnHeaderErrorCount;
        private System.Windows.Forms.ColumnHeader columnHeaderWarningSize;
        private System.Windows.Forms.ColumnHeader columnHeaderErrorSize;
        private System.Windows.Forms.ColumnHeader columnHeaderAgeMin;
        private System.Windows.Forms.ColumnHeader columnHeaderAgeMax;
        private System.Windows.Forms.ColumnHeader columnHeaderSizeMin;
        private System.Windows.Forms.ColumnHeader columnHeaderSizeMax;
    }
}