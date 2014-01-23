namespace QuickMon.Collectors
{
    partial class SoapWebServicePingCollectorEditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoapWebServicePingCollectorEditConfig));
            this.columnHeaderServiceURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderServiceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMethodName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderParameters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            this.SuspendLayout();
            // 
            // lvwEntries
            // 
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderServiceURL,
            this.columnHeaderServiceName,
            this.columnHeaderMethodName,
            this.columnHeaderParameters});
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.AutoResizeColumnIndex = 0;
            // 
            // columnHeaderServiceURL
            // 
            this.columnHeaderServiceURL.Text = "Service URL";
            this.columnHeaderServiceURL.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeaderServiceName.Text = "Service name";
            this.columnHeaderServiceName.Width = 90;
            // 
            // columnHeaderMethodName
            // 
            this.columnHeaderMethodName.Text = "Method name";
            this.columnHeaderMethodName.Width = 90;
            // 
            // columnHeaderParameters
            // 
            this.columnHeaderParameters.Text = "Parameters";
            this.columnHeaderParameters.Width = 151;
            // 
            // SoapWebServicePingCollectorEditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MinimumSize = new System.Drawing.Size(550, 350);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoapWebServicePingCollectorEditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private System.Windows.Forms.ColumnHeader columnHeaderServiceURL;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceName;
        private System.Windows.Forms.ColumnHeader columnHeaderMethodName;
        private System.Windows.Forms.ColumnHeader columnHeaderParameters;
    }
}