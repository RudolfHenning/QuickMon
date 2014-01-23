namespace QuickMon.Collectors
{
    partial class WMIQueryCollectorEditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMIQueryCollectorEditConfig));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.machineColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.namespaceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.queryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.AutoResizeColumnIndex = 3;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.machineColumnHeader,
            this.namespaceColumnHeader,
            this.queryColumnHeader});
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 168;
            // 
            // machineColumnHeader
            // 
            this.machineColumnHeader.Text = "Machine";
            this.machineColumnHeader.Width = 129;
            // 
            // namespaceColumnHeader
            // 
            this.namespaceColumnHeader.Text = "Namespace";
            this.namespaceColumnHeader.Width = 96;
            // 
            // queryColumnHeader
            // 
            this.queryColumnHeader.Text = "Query";
            this.queryColumnHeader.Width = 201;
            // 
            // WMIQueryCollectorEditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "WMIQueryCollectorEditConfig";
            this.Text = "WMIQueryCollectorEditConfig";
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader machineColumnHeader;
        private System.Windows.Forms.ColumnHeader namespaceColumnHeader;
        private System.Windows.Forms.ColumnHeader queryColumnHeader;
    }
}