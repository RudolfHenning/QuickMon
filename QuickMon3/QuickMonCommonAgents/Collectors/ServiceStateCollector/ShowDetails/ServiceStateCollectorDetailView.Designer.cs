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
            //this.lvwServices = new QuickMon.ListViewEx();
            this.columnHeaderService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvwServices
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.AutoResizeColumnIndex = 0;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderService});
            //this.lvwServices.ContextMenuStrip = this.refreshContextMenuStrip;
            //this.lvwServices.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.lvwServices.FullRowSelect = true;
            //this.lvwServices.Location = new System.Drawing.Point(0, 39);
            //this.lvwServices.Name = "lvwServices";
            //this.lvwServices.Size = new System.Drawing.Size(405, 269);
            this.lvwEntries.SmallImageList = this.imageList1;
            //this.lvwServices.TabIndex = 12;
            //this.lvwServices.UseCompatibleStateImageBehavior = false;
            //this.lvwServices.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderService
            // 
            this.columnHeaderService.Text = "Service";
            this.columnHeaderService.Width = 349;
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
            //this.Controls.Add(this.lvwServices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServiceStateCollectorDetailView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail View";
           // this.Controls.SetChildIndex(this.lvwServices, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private ListViewEx lvwServices;
        private System.Windows.Forms.ColumnHeader columnHeaderService;
        private System.Windows.Forms.ImageList imageList1;
    }
}