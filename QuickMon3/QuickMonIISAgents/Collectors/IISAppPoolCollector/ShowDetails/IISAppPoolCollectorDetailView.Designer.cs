namespace QuickMon.Collectors
{
    partial class IISAppPoolCollectorDetailView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IISAppPoolCollectorDetailView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.columnHeaderAppPool = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwEntries
            // 
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAppPool});
            this.lvwEntries.SmallImageList = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GUnknown.ico");
            this.imageList1.Images.SetKeyName(1, "GRunning.ico");
            this.imageList1.Images.SetKeyName(2, "GStopped.ico");
            this.imageList1.Images.SetKeyName(3, "GBusy.ico");
            // 
            // columnHeaderAppPool
            // 
            this.columnHeaderAppPool.Text = "Application pool";
            this.columnHeaderAppPool.Width = 462;
            // 
            // IISAppPoolCollectorDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IISAppPoolCollectorDetailView";
            this.Text = "IISAppPoolCollectorDetailView";
            this.Load += new System.EventHandler(this.IISAppPoolCollectorDetailView_Load);
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeaderAppPool;
    }
}