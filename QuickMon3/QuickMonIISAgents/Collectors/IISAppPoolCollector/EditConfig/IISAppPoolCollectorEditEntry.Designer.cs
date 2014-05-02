namespace QuickMon.Collectors
{
    partial class IISAppPoolCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IISAppPoolCollectorEditEntry));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAppPools = new System.Windows.Forms.ListBox();
            this.appPoolListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddAppPool = new System.Windows.Forms.TextBox();
            this.cmdAddAppPool = new System.Windows.Forms.Button();
            this.cmdImportSM = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkUsePerfCounters = new System.Windows.Forms.CheckBox();
            this.ImportCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.appPoolListContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(347, 306);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(259, 306);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtComputer
            // 
            this.txtComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputer.Location = new System.Drawing.Point(78, 12);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(344, 20);
            this.txtComputer.TabIndex = 1;
            this.txtComputer.TextChanged += new System.EventHandler(this.txtComputer_TextChanged);
            this.txtComputer.Leave += new System.EventHandler(this.txtComputer_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Computer";
            // 
            // lstAppPools
            // 
            this.lstAppPools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAppPools.ContextMenuStrip = this.appPoolListContextMenuStrip;
            this.lstAppPools.FormattingEnabled = true;
            this.lstAppPools.Location = new System.Drawing.Point(78, 57);
            this.lstAppPools.Name = "lstAppPools";
            this.lstAppPools.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAppPools.Size = new System.Drawing.Size(344, 186);
            this.lstAppPools.Sorted = true;
            this.lstAppPools.TabIndex = 3;
            this.lstAppPools.SelectedIndexChanged += new System.EventHandler(this.lstAppPools_SelectedIndexChanged);
            this.lstAppPools.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstAppPools_KeyDown);
            // 
            // appPoolListContextMenuStrip
            // 
            this.appPoolListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.appPoolListContextMenuStrip.Name = "contextMenuStrip1";
            this.appPoolListContextMenuStrip.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Application pools";
            // 
            // txtAddAppPool
            // 
            this.txtAddAppPool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddAppPool.Location = new System.Drawing.Point(78, 251);
            this.txtAddAppPool.Name = "txtAddAppPool";
            this.txtAddAppPool.Size = new System.Drawing.Size(284, 20);
            this.txtAddAppPool.TabIndex = 4;
            // 
            // cmdAddAppPool
            // 
            this.cmdAddAppPool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddAppPool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAddAppPool.Location = new System.Drawing.Point(368, 249);
            this.cmdAddAppPool.Name = "cmdAddAppPool";
            this.cmdAddAppPool.Size = new System.Drawing.Size(54, 23);
            this.cmdAddAppPool.TabIndex = 5;
            this.cmdAddAppPool.Text = "Add";
            this.cmdAddAppPool.UseVisualStyleBackColor = true;
            this.cmdAddAppPool.Click += new System.EventHandler(this.cmdAddAppPool_Click);
            // 
            // cmdImportSM
            // 
            this.cmdImportSM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdImportSM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImportSM.Location = new System.Drawing.Point(13, 306);
            this.cmdImportSM.Name = "cmdImportSM";
            this.cmdImportSM.Size = new System.Drawing.Size(75, 23);
            this.cmdImportSM.TabIndex = 7;
            this.cmdImportSM.Text = "Import";
            this.toolTip1.SetToolTip(this.cmdImportSM, "Attempt to Import existing application pools on specified machine");
            this.cmdImportSM.UseVisualStyleBackColor = true;
            this.cmdImportSM.Click += new System.EventHandler(this.cmdImportSM_Click);
            // 
            // chkUsePerfCounters
            // 
            this.chkUsePerfCounters.AutoSize = true;
            this.chkUsePerfCounters.Location = new System.Drawing.Point(78, 277);
            this.chkUsePerfCounters.Name = "chkUsePerfCounters";
            this.chkUsePerfCounters.Size = new System.Drawing.Size(240, 17);
            this.chkUsePerfCounters.TabIndex = 6;
            this.chkUsePerfCounters.Text = "Use Performance counters (only IIS 7 or later)";
            this.toolTip1.SetToolTip(this.chkUsePerfCounters, "Using performance counters are only available on IIS 7 or later");
            this.chkUsePerfCounters.UseVisualStyleBackColor = true;
            this.chkUsePerfCounters.CheckedChanged += new System.EventHandler(this.chkUsePerfCounters_CheckedChanged);
            // 
            // ImportCheckTimer
            // 
            this.ImportCheckTimer.Interval = 500;
            this.ImportCheckTimer.Tick += new System.EventHandler(this.ImportCheckTimer_Tick);
            // 
            // IISAppPoolCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 341);
            this.Controls.Add(this.chkUsePerfCounters);
            this.Controls.Add(this.cmdImportSM);
            this.Controls.Add(this.cmdAddAppPool);
            this.Controls.Add(this.txtAddAppPool);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstAppPools);
            this.Controls.Add(this.txtComputer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IISAppPoolCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit IIS Application Pool Collector Entry";
            this.Load += new System.EventHandler(this.IISAppPoolCollectorEditEntry_Load);
            this.appPoolListContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAppPools;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddAppPool;
        private System.Windows.Forms.Button cmdAddAppPool;
        private System.Windows.Forms.ContextMenuStrip appPoolListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button cmdImportSM;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkUsePerfCounters;
        private System.Windows.Forms.Timer ImportCheckTimer;
    }
}