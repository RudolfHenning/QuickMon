namespace QuickMon.Collectors
{
    partial class DynamicWSCollectorShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicWSCollectorShowDetails));
            this.columnHeaderURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderURL,
            this.columnHeaderResult});
            this.lvwEntries.Size = new System.Drawing.Size(504, 269);
            // 
            // columnHeaderURL
            // 
            this.columnHeaderURL.Text = "Web Service";
            this.columnHeaderURL.Width = 378;
            // 
            // columnHeaderResult
            // 
            this.columnHeaderResult.Text = "Result";
            this.columnHeaderResult.Width = 120;
            // 
            // DynamicWSCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 330);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DynamicWSCollectorShowDetails";
            this.Text = "SoapWebServicePingCollectorShowDetails";
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeaderURL;
        private System.Windows.Forms.ColumnHeader columnHeaderResult;
    }
}