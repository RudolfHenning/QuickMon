namespace QuickMon.Collectors
{
    partial class SoapWebServicePingCollectorShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoapWebServicePingCollectorShowDetails));
            //this.lvwHosts = new ListViewEx();
            this.columnHeaderURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwHosts
            // 
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderURL,
            this.columnHeaderResult});
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.AutoResizeColumnIndex = 0;
            // 
            // columnHeaderURL
            // 
            this.columnHeaderURL.Text = "Web Service";
            this.columnHeaderURL.Width = 302;
            // 
            // columnHeaderResult
            // 
            this.columnHeaderResult.Text = "Result";
            this.columnHeaderResult.Width = 120;
            // 
            // SoapWebServicePingCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 330);
            //this.Controls.Add(this.lvwHosts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoapWebServicePingCollectorShowDetails";
            this.Text = "SoapWebServicePingCollectorShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        //private ListViewEx lvwHosts;
        private System.Windows.Forms.ColumnHeader columnHeaderURL;
        private System.Windows.Forms.ColumnHeader columnHeaderResult;
    }
}