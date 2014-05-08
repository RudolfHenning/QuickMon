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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwResults = new QuickMon.ListViewEx();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showSQLQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.autoRefreshtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerDetails = new System.Windows.Forms.SplitContainer();
            this.lvwDetails = new QuickMon.ListViewEx();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerSelectItem = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripRTF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).BeginInit();
            this.splitContainerDetails.Panel1.SuspendLayout();
            this.splitContainerDetails.Panel2.SuspendLayout();
            this.splitContainerDetails.SuspendLayout();
            this.contextMenuStripRTF.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDetails});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(645, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDetails
            // 
            this.toolStripStatusLabelDetails.AutoSize = false;
            this.toolStripStatusLabelDetails.Name = "toolStripStatusLabelDetails";
            this.toolStripStatusLabelDetails.Size = new System.Drawing.Size(630, 17);
            this.toolStripStatusLabelDetails.Spring = true;
            this.toolStripStatusLabelDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // lvwResults
            // 
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderValue});
            this.lvwResults.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwResults.FullRowSelect = true;
            this.lvwResults.Location = new System.Drawing.Point(0, 0);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(645, 105);
            this.lvwResults.SmallImageList = this.imageList1;
            this.lvwResults.TabIndex = 6;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            this.lvwResults.SelectedIndexChanged += new System.EventHandler(this.lvwResults_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 145;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 95;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.autoRefreshToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showSQLQueryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(245, 82);
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.CheckOnClick = true;
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.autoRefreshToolStripMenuItem.Text = "Auto refresh";
            this.autoRefreshToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.autoRefreshToolStripMenuItem_CheckStateChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(241, 6);
            // 
            // showSQLQueryToolStripMenuItem
            // 
            this.showSQLQueryToolStripMenuItem.Enabled = false;
            this.showSQLQueryToolStripMenuItem.Name = "showSQLQueryToolStripMenuItem";
            this.showSQLQueryToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.showSQLQueryToolStripMenuItem.Text = "Edit SQL Query (local copy)";
            this.showSQLQueryToolStripMenuItem.Click += new System.EventHandler(this.showSQLQueryToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_ball_glass_blue.ico");
            this.imageList1.Images.SetKeyName(1, "bullet_ball_glass_green.ico");
            this.imageList1.Images.SetKeyName(2, "bullet_ball_glass_yellow.ico");
            this.imageList1.Images.SetKeyName(3, "bullet_ball_glass_red.ico");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.autoRefreshtoolStripButton,
            this.toolStripSeparator1,
            this.exportToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(645, 39);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // autoRefreshtoolStripButton
            // 
            this.autoRefreshtoolStripButton.CheckOnClick = true;
            this.autoRefreshtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.autoRefreshtoolStripButton.Image = global::QuickMon.Properties.Resources.satelitedish;
            this.autoRefreshtoolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.autoRefreshtoolStripButton.Name = "autoRefreshtoolStripButton";
            this.autoRefreshtoolStripButton.Size = new System.Drawing.Size(36, 36);
            this.autoRefreshtoolStripButton.Text = "Auto refresh";
            this.autoRefreshtoolStripButton.CheckStateChanged += new System.EventHandler(this.autoRefreshtoolStripButton_CheckStateChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // exportToolStripButton
            // 
            this.exportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToolStripButton.Enabled = false;
            this.exportToolStripButton.Image = global::QuickMon.Properties.Resources.Download;
            this.exportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToolStripButton.Name = "exportToolStripButton";
            this.exportToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.exportToolStripButton.Text = "Export";
            this.exportToolStripButton.Click += new System.EventHandler(this.exportToolStripButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwResults);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerDetails);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(645, 407);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainerDetails
            // 
            this.splitContainerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDetails.Location = new System.Drawing.Point(0, 19);
            this.splitContainerDetails.Name = "splitContainerDetails";
            this.splitContainerDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDetails.Panel1
            // 
            this.splitContainerDetails.Panel1.Controls.Add(this.lvwDetails);
            this.splitContainerDetails.Panel1.Controls.Add(this.cmdViewDetails);
            // 
            // splitContainerDetails.Panel2
            // 
            this.splitContainerDetails.Panel2.Controls.Add(this.rtxDetails);
            this.splitContainerDetails.Size = new System.Drawing.Size(645, 275);
            this.splitContainerDetails.SplitterDistance = 154;
            this.splitContainerDetails.SplitterWidth = 8;
            this.splitContainerDetails.TabIndex = 8;
            // 
            // lvwDetails
            // 
            this.lvwDetails.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDetails.FullRowSelect = true;
            this.lvwDetails.Location = new System.Drawing.Point(0, 0);
            this.lvwDetails.Name = "lvwDetails";
            this.lvwDetails.Size = new System.Drawing.Size(645, 138);
            this.lvwDetails.TabIndex = 7;
            this.lvwDetails.UseCompatibleStateImageBehavior = false;
            this.lvwDetails.View = System.Windows.Forms.View.Details;
            this.lvwDetails.SelectedIndexChanged += new System.EventHandler(this.lvwDetails_SelectedIndexChanged);
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.DarkGray;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 138);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(645, 16);
            this.cmdViewDetails.TabIndex = 8;
            this.cmdViewDetails.Text = "ttt";
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // rtxDetails
            // 
            this.rtxDetails.ContextMenuStrip = this.contextMenuStripRTF;
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(645, 113);
            this.rtxDetails.TabIndex = 2;
            this.rtxDetails.Text = "";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(645, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Details";
            // 
            // timerSelectItem
            // 
            this.timerSelectItem.Interval = 500;
            this.timerSelectItem.Tick += new System.EventHandler(this.timerSelectItem_Tick);
            // 
            // saveFileDialogCSV
            // 
            this.saveFileDialogCSV.DefaultExt = "csv";
            this.saveFileDialogCSV.Filter = "CSV Files|*.csv";
            // 
            // contextMenuStripRTF
            // 
            this.contextMenuStripRTF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.contextMenuStripRTF.Name = "contextMenuStripRTF";
            this.contextMenuStripRTF.Size = new System.Drawing.Size(153, 74);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
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
            this.ClientSize = new System.Drawing.Size(645, 468);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Details";
            this.Load += new System.EventHandler(this.ShowDetails_Load);
            this.Shown += new System.EventHandler(this.ShowDetails_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerDetails.Panel1.ResumeLayout(false);
            this.splitContainerDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).EndInit();
            this.splitContainerDetails.ResumeLayout(false);
            this.contextMenuStripRTF.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDetails;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private ListViewEx lvwResults;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private ListViewEx lvwDetails;
        private System.Windows.Forms.SplitContainer splitContainerDetails;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.Timer timerSelectItem;
        private System.Windows.Forms.ToolStripButton exportToolStripButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCSV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRTF;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton autoRefreshtoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStripMenuItem showSQLQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}