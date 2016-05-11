namespace QuickMon.Collectors
{
    partial class LinuxProcessViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinuxProcessViewer));
            this.lvwProcesses = new QuickMon.ListViewEx();
            this.processColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpuColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdReload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwProcesses
            // 
            this.lvwProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProcesses.AutoResizeColumnEnabled = false;
            this.lvwProcesses.AutoResizeColumnIndex = 0;
            this.lvwProcesses.CheckBoxes = true;
            this.lvwProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processColumnHeader,
            this.cpuColumnHeader,
            this.memColumnHeader});
            this.lvwProcesses.FullRowSelect = true;
            this.lvwProcesses.Location = new System.Drawing.Point(0, 0);
            this.lvwProcesses.Name = "lvwProcesses";
            this.lvwProcesses.Size = new System.Drawing.Size(479, 343);
            this.lvwProcesses.TabIndex = 0;
            this.lvwProcesses.UseCompatibleStateImageBehavior = false;
            this.lvwProcesses.View = System.Windows.Forms.View.Details;
            // 
            // processColumnHeader
            // 
            this.processColumnHeader.Text = "Process";
            this.processColumnHeader.Width = 294;
            // 
            // cpuColumnHeader
            // 
            this.cpuColumnHeader.Text = "CPU %";
            this.cpuColumnHeader.Width = 79;
            // 
            // memColumnHeader
            // 
            this.memColumnHeader.Text = "Mem %";
            this.memColumnHeader.Width = 68;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(311, 349);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "Select";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(392, 349);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdReload
            // 
            this.cmdReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdReload.Location = new System.Drawing.Point(230, 349);
            this.cmdReload.Name = "cmdReload";
            this.cmdReload.Size = new System.Drawing.Size(75, 23);
            this.cmdReload.TabIndex = 1;
            this.cmdReload.Text = "Reload";
            this.cmdReload.UseVisualStyleBackColor = true;
            this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(47, 352);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(177, 20);
            this.txtFilter.TabIndex = 5;
            // 
            // LinuxProcessViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 384);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdReload);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lvwProcesses);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "LinuxProcessViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Viewer";
            this.Load += new System.EventHandler(this.LinuxProcessViewer_Load);
            this.Shown += new System.EventHandler(this.LinuxProcessViewer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewEx lvwProcesses;
        private System.Windows.Forms.ColumnHeader processColumnHeader;
        private System.Windows.Forms.ColumnHeader cpuColumnHeader;
        private System.Windows.Forms.ColumnHeader memColumnHeader;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdReload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
    }
}