namespace QuickMon
{
    partial class CollectorStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorStats));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwProperties = new QuickMon.ListViewEx();
            this.propertyNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.historyTabPage = new System.Windows.Forms.TabPage();
            this.lvwHistory = new QuickMon.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.historyImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.historyTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.cmdViewDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxDetails);
            this.splitContainer1.Size = new System.Drawing.Size(527, 493);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // lvwProperties
            // 
            this.lvwProperties.AutoResizeColumnEnabled = false;
            this.lvwProperties.AutoResizeColumnIndex = 0;
            this.lvwProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertyNameColumnHeader,
            this.valueColumnHeader});
            this.lvwProperties.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwProperties.FullRowSelect = true;
            this.lvwProperties.HideSelection = false;
            this.lvwProperties.Location = new System.Drawing.Point(3, 3);
            this.lvwProperties.Name = "lvwProperties";
            this.lvwProperties.Size = new System.Drawing.Size(513, 236);
            this.lvwProperties.TabIndex = 0;
            this.lvwProperties.UseCompatibleStateImageBehavior = false;
            this.lvwProperties.View = System.Windows.Forms.View.Details;
            this.lvwProperties.SelectedIndexChanged += new System.EventHandler(this.lvwProperties_SelectedIndexChanged);
            // 
            // propertyNameColumnHeader
            // 
            this.propertyNameColumnHeader.Text = "Property";
            this.propertyNameColumnHeader.Width = 218;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 205;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.DarkGray;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 268);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(527, 16);
            this.cmdViewDetails.TabIndex = 9;
            this.cmdViewDetails.Text = "ttt";
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // rtxDetails
            // 
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(527, 203);
            this.rtxDetails.TabIndex = 3;
            this.rtxDetails.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.historyTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 268);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwProperties);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Statistics";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // historyTabPage
            // 
            this.historyTabPage.Controls.Add(this.lvwHistory);
            this.historyTabPage.Location = new System.Drawing.Point(4, 22);
            this.historyTabPage.Name = "historyTabPage";
            this.historyTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.historyTabPage.Size = new System.Drawing.Size(519, 242);
            this.historyTabPage.TabIndex = 1;
            this.historyTabPage.Text = "History";
            this.historyTabPage.UseVisualStyleBackColor = true;
            // 
            // lvwHistory
            // 
            this.lvwHistory.AutoResizeColumnEnabled = false;
            this.lvwHistory.AutoResizeColumnIndex = 0;
            this.lvwHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.HideSelection = false;
            this.lvwHistory.Location = new System.Drawing.Point(3, 3);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(513, 236);
            this.lvwHistory.SmallImageList = this.historyImageList;
            this.lvwHistory.TabIndex = 1;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            this.lvwHistory.SelectedIndexChanged += new System.EventHandler(this.lvwProperties_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time and state";
            this.columnHeader1.Width = 218;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Details";
            this.columnHeader2.Width = 205;
            // 
            // historyImageList
            // 
            this.historyImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("historyImageList.ImageStream")));
            this.historyImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.historyImageList.Images.SetKeyName(0, "OrangeFolder.ico");
            this.historyImageList.Images.SetKeyName(1, "bullet_ball_glass_blue.ico");
            this.historyImageList.Images.SetKeyName(2, "ok.png");
            this.historyImageList.Images.SetKeyName(3, "triang_yellow.png");
            this.historyImageList.Images.SetKeyName(4, "Error24x24.png");
            // 
            // CollectorStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 493);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CollectorStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Statistics";
            this.Load += new System.EventHandler(this.CollectorStats_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CollectorStats_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.historyTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewEx lvwProperties;
        private System.Windows.Forms.ColumnHeader propertyNameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage historyTabPage;
        private ListViewEx lvwHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList historyImageList;
    }
}