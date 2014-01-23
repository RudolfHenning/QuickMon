namespace QuickMon.Collectors
{
    partial class SqlTableSizeCollectorEditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlTableSizeCollectorEditConfig));
            this.serverDatabaseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tablesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(386, 319);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(305, 319);
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverDatabaseColumnHeader,
            this.tablesColumnHeader});
            this.lvwEntries.Size = new System.Drawing.Size(473, 271);
            // 
            // serverDatabaseColumnHeader
            // 
            this.serverDatabaseColumnHeader.Text = "[Server].database";
            this.serverDatabaseColumnHeader.Width = 373;
            // 
            // tablesColumnHeader
            // 
            this.tablesColumnHeader.Text = "Tables";
            this.tablesColumnHeader.Width = 94;
            // 
            // SqlTableSizeCollectorEditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 350);
            this.MinimumSize = new System.Drawing.Size(473, 350);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SqlTableSizeCollectorEditConfig";
            this.Text = "EditConfig";
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader serverDatabaseColumnHeader;
        private System.Windows.Forms.ColumnHeader tablesColumnHeader;
    }
}