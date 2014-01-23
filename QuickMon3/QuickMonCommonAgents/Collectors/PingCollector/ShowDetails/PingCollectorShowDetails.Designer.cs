namespace QuickMon.Collectors
{
    partial class PingCollectorShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingCollectorShowDetails));
            //this.lvwHosts = new QuickMon.ListViewEx();
            this.columnHeaderHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infoColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwHosts
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.AutoResizeColumnIndex = 2;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHost,
            this.columnHeaderPing,
            this.infoColumnHeader});
            //this.lvwHosts.ContextMenuStrip = this.refreshContextMenuStrip;
            //this.lvwHosts.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.lvwHosts.FullRowSelect = true;
            //this.lvwHosts.Location = new System.Drawing.Point(0, 0);
            //this.lvwHosts.Name = "lvwHosts";
            //this.lvwHosts.Size = new System.Drawing.Size(504, 330);
            //this.lvwHosts.TabIndex = 10;
            //this.lvwHosts.UseCompatibleStateImageBehavior = false;
            //this.lvwHosts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderHost
            // 
            this.columnHeaderHost.Text = "Address";
            this.columnHeaderHost.Width = 214;
            // 
            // columnHeaderPing
            // 
            this.columnHeaderPing.Text = "Ping time";
            this.columnHeaderPing.Width = 80;
            // 
            // infoColumnHeader
            // 
            this.infoColumnHeader.Text = "More info";
            this.infoColumnHeader.Width = 204;
            // 
            // PingCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 330);
            //this.Controls.Add(this.lvwHosts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PingCollectorShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Details";
            //this.Controls.SetChildIndex(this.lvwHosts, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private ListViewEx lvwHosts;
        private System.Windows.Forms.ColumnHeader columnHeaderHost;
        private System.Windows.Forms.ColumnHeader columnHeaderPing;
        private System.Windows.Forms.ColumnHeader infoColumnHeader;
    }
}