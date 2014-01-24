namespace QuickMon.Collectors
{
    partial class ServiceStateCollectorDetailView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceStateCollectorDetailView));
            this.columnHeaderService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderService});
            this.lvwEntries.Size = new System.Drawing.Size(405, 269);
            this.lvwEntries.SmallImageList = this.imageList1;
            // 
            // columnHeaderService
            // 
            this.columnHeaderService.Text = "Service";
            this.columnHeaderService.Width = 399;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Running.ico");
            this.imageList1.Images.SetKeyName(1, "Stopped.ico");
            this.imageList1.Images.SetKeyName(2, "Busy.ico");
            this.imageList1.Images.SetKeyName(3, "Unknown.ico");
            this.imageList1.Images.SetKeyName(4, "Paused.ico");
            // 
            // ServiceStateCollectorDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 330);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServiceStateCollectorDetailView";
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private ListViewEx lvwServices;
        private System.Windows.Forms.ColumnHeader columnHeaderService;
        private System.Windows.Forms.ImageList imageList1;
    }
}