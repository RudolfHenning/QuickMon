namespace QuickMon.Controls
{
    partial class DataTableViewerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwDataTable = new ListViewEx();
            this.SuspendLayout();
            // 
            // lvwDataTable
            // 
            this.lvwDataTable.AutoResizeColumnEnabled = false;
            this.lvwDataTable.AutoResizeColumnIndex = 0;
            this.lvwDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDataTable.FullRowSelect = true;
            this.lvwDataTable.Location = new System.Drawing.Point(0, 0);
            this.lvwDataTable.Name = "lvwDataTable";
            this.lvwDataTable.Size = new System.Drawing.Size(532, 298);
            this.lvwDataTable.TabIndex = 2;
            this.lvwDataTable.UseCompatibleStateImageBehavior = false;
            this.lvwDataTable.View = System.Windows.Forms.View.Details;
            // 
            // DataTableViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwDataTable);
            this.Name = "DataTableViewerControl";
            this.Size = new System.Drawing.Size(532, 298);
            this.Load += new System.EventHandler(this.DataTableViewerControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewEx lvwDataTable;
    }
}
