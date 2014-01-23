namespace QuickMon.Collectors
{
    partial class PerfCounterShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerfCounterShowDetails));
            //this.lvwPerfCounters = new QuickMon.ListViewEx();
            this.columnHeaderPerfCounter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAlertDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwPerfCounters
            // 
            this.lvwEntries.AutoResizeColumnEnabled = true;
            this.lvwEntries.AutoResizeColumnIndex = 0;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPerfCounter,
            this.columnHeaderValue,
            this.columnHeaderAlertDetails});
            //this.lvwPerfCounters.ContextMenuStrip = this.refreshContextMenuStrip;
            //this.lvwPerfCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.lvwPerfCounters.FullRowSelect = true;
            //this.lvwPerfCounters.Location = new System.Drawing.Point(0, 39);
            //this.lvwPerfCounters.Name = "lvwPerfCounters";
            //this.lvwPerfCounters.Size = new System.Drawing.Size(607, 281);
            //this.lvwPerfCounters.TabIndex = 14;
            //this.lvwPerfCounters.UseCompatibleStateImageBehavior = false;
            //this.lvwPerfCounters.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPerfCounter
            // 
            this.columnHeaderPerfCounter.Text = "Performance counter";
            this.columnHeaderPerfCounter.Width = 386;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 115;
            // 
            // columnHeaderAlertDetails
            // 
            this.columnHeaderAlertDetails.Text = "Warn/Err";
            this.columnHeaderAlertDetails.Width = 100;
            // 
            // PerfCounterShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 342);
            //this.Controls.Add(this.lvwPerfCounters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PerfCounterShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Details";
            //this.Controls.SetChildIndex(this.lvwPerfCounters, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private ListViewEx lvwPerfCounters;
        private System.Windows.Forms.ColumnHeader columnHeaderPerfCounter;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.ColumnHeader columnHeaderAlertDetails;
    }
}