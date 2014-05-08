namespace QuickMon
{
    partial class ShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDetails));
            this.lvwDatabases = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerColumnWidthChanged = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.autoRefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.timerItemSelected = new System.Windows.Forms.Timer(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDatabases
            // 
            this.lvwDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize});
            this.lvwDatabases.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDatabases.FullRowSelect = true;
            this.lvwDatabases.Location = new System.Drawing.Point(0, 39);
            this.lvwDatabases.Name = "lvwDatabases";
            this.lvwDatabases.Size = new System.Drawing.Size(364, 213);
            this.lvwDatabases.SmallImageList = this.imageList1;
            this.lvwDatabases.TabIndex = 4;
            this.lvwDatabases.UseCompatibleStateImageBehavior = false;
            this.lvwDatabases.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 210;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size (MB)";
            this.columnHeaderSize.Width = 113;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.autoRefreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 52);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.CheckOnClick = true;
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.autoRefreshToolStripMenuItem.Text = "Auto refresh";
            this.autoRefreshToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.autoRefreshToolStripMenuItem_CheckStateChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_ball_green.ico");
            this.imageList1.Images.SetKeyName(1, "bullet_ball_yellow.ico");
            this.imageList1.Images.SetKeyName(2, "bullet_ball_red.ico");
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::QuickMon.Properties.Resources.doc_refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 252);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(364, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(349, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerColumnWidthChanged
            // 
            this.timerColumnWidthChanged.Interval = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.autoRefreshToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(364, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // autoRefreshToolStripButton
            // 
            this.autoRefreshToolStripButton.CheckOnClick = true;
            this.autoRefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.autoRefreshToolStripButton.Image = global::QuickMon.Properties.Resources.satelitedish;
            this.autoRefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoRefreshToolStripButton.Name = "autoRefreshToolStripButton";
            this.autoRefreshToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.autoRefreshToolStripButton.Text = "Auto refresh";
            this.autoRefreshToolStripButton.CheckStateChanged += new System.EventHandler(this.autoRefreshToolStripButton_CheckStateChanged);
            // 
            // timerItemSelected
            // 
            this.timerItemSelected.Interval = 200;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // ShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 274);
            this.Controls.Add(this.lvwDatabases);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Details";
            this.Resize += new System.EventHandler(this.ShowDetails_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDatabases;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timerColumnWidthChanged;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Timer timerItemSelected;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton autoRefreshToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.Timer refreshTimer;
    }
}