namespace QuickMon.Forms
{
    partial class CollectorStatusViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorStatusViewer));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.cmdAgentDetailViewer = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.currentStatusTabPage = new System.Windows.Forms.TabPage();
            this.lblCollectorHostStatusText = new System.Windows.Forms.Label();
            this.lblCollectorHostStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwAgents = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentStatusTabPage2 = new System.Windows.Forms.TabPage();
            this.lvwProperties = new QuickMon.ListViewEx();
            this.propertyNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwHistory = new QuickMon.ListViewEx();
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.executedOncolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertsRaisedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statisticsTabPage = new System.Windows.Forms.TabPage();
            this.lvwStatistics = new QuickMon.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.currentStatusTabPage.SuspendLayout();
            this.currentStatusTabPage2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statisticsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(89, 5);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(380, 20);
            this.txtName.TabIndex = 2;
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
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "helpbwy24x24.png");
            this.treeImageList.Images.SetKeyName(1, "ok.png");
            this.treeImageList.Images.SetKeyName(2, "triang_yellow.png");
            this.treeImageList.Images.SetKeyName(3, "Error24x24.png");
            this.treeImageList.Images.SetKeyName(4, "ForbiddenGray16x16.png");
            // 
            // cmdAgentDetailViewer
            // 
            this.cmdAgentDetailViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAgentDetailViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdAgentDetailViewer.Enabled = false;
            this.cmdAgentDetailViewer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAgentDetailViewer.Image = global::QuickMon.Properties.Resources.FindDoc24x24;
            this.cmdAgentDetailViewer.Location = new System.Drawing.Point(476, 0);
            this.cmdAgentDetailViewer.Name = "cmdAgentDetailViewer";
            this.cmdAgentDetailViewer.Size = new System.Drawing.Size(39, 35);
            this.cmdAgentDetailViewer.TabIndex = 3;
            this.cmdAgentDetailViewer.UseVisualStyleBackColor = true;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRefresh.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.Location = new System.Drawing.Point(2, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(39, 35);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 38);
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
            this.splitContainer1.Size = new System.Drawing.Size(513, 471);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.currentStatusTabPage);
            this.tabControl1.Controls.Add(this.currentStatusTabPage2);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.statisticsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(513, 245);
            this.tabControl1.TabIndex = 0;
            // 
            // currentStatusTabPage
            // 
            this.currentStatusTabPage.BackColor = System.Drawing.Color.White;
            this.currentStatusTabPage.Controls.Add(this.lblCollectorHostStatusText);
            this.currentStatusTabPage.Controls.Add(this.lblCollectorHostStatus);
            this.currentStatusTabPage.Controls.Add(this.label2);
            this.currentStatusTabPage.Controls.Add(this.lvwAgents);
            this.currentStatusTabPage.Location = new System.Drawing.Point(4, 22);
            this.currentStatusTabPage.Name = "currentStatusTabPage";
            this.currentStatusTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.currentStatusTabPage.Size = new System.Drawing.Size(505, 219);
            this.currentStatusTabPage.TabIndex = 3;
            this.currentStatusTabPage.Text = "Global  and agent states";
            // 
            // lblCollectorHostStatusText
            // 
            this.lblCollectorHostStatusText.AutoSize = true;
            this.lblCollectorHostStatusText.Location = new System.Drawing.Point(83, 11);
            this.lblCollectorHostStatusText.Name = "lblCollectorHostStatusText";
            this.lblCollectorHostStatusText.Size = new System.Drawing.Size(53, 13);
            this.lblCollectorHostStatusText.TabIndex = 4;
            this.lblCollectorHostStatusText.Text = "Unknown";
            // 
            // lblCollectorHostStatus
            // 
            this.lblCollectorHostStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.lblCollectorHostStatus.Location = new System.Drawing.Point(462, 3);
            this.lblCollectorHostStatus.Name = "lblCollectorHostStatus";
            this.lblCollectorHostStatus.Size = new System.Drawing.Size(40, 29);
            this.lblCollectorHostStatus.TabIndex = 3;
            this.lblCollectorHostStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current state:";
            // 
            // lvwAgents
            // 
            this.lvwAgents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAgents.AutoResizeColumnEnabled = false;
            this.lvwAgents.AutoResizeColumnIndex = 0;
            this.lvwAgents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.typeColumnHeader});
            this.lvwAgents.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwAgents.FullRowSelect = true;
            this.lvwAgents.HideSelection = false;
            this.lvwAgents.Location = new System.Drawing.Point(3, 35);
            this.lvwAgents.Name = "lvwAgents";
            this.lvwAgents.Size = new System.Drawing.Size(499, 181);
            this.lvwAgents.SmallImageList = this.treeImageList;
            this.lvwAgents.TabIndex = 1;
            this.lvwAgents.UseCompatibleStateImageBehavior = false;
            this.lvwAgents.View = System.Windows.Forms.View.Details;
            this.lvwAgents.SelectedIndexChanged += new System.EventHandler(this.lvwAgents_SelectedIndexChanged);
            this.lvwAgents.DoubleClick += new System.EventHandler(this.lvwAgents_DoubleClick);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Agent Name";
            this.nameColumnHeader.Width = 227;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 205;
            // 
            // currentStatusTabPage2
            // 
            this.currentStatusTabPage2.BackColor = System.Drawing.Color.White;
            this.currentStatusTabPage2.Controls.Add(this.lvwProperties);
            this.currentStatusTabPage2.Location = new System.Drawing.Point(4, 22);
            this.currentStatusTabPage2.Name = "currentStatusTabPage2";
            this.currentStatusTabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.currentStatusTabPage2.Size = new System.Drawing.Size(505, 219);
            this.currentStatusTabPage2.TabIndex = 0;
            this.currentStatusTabPage2.Text = "Current state details";
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
            this.lvwProperties.Size = new System.Drawing.Size(499, 213);
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
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.lvwHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(505, 219);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            // 
            // lvwHistory
            // 
            this.lvwHistory.AutoResizeColumnEnabled = false;
            this.lvwHistory.AutoResizeColumnIndex = 0;
            this.lvwHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeColumnHeader,
            this.stateColumnHeader,
            this.durationColumnHeader,
            this.detailsColumnHeader,
            this.executedOncolumnHeader,
            this.alertsRaisedColumnHeader});
            this.lvwHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.HideSelection = false;
            this.lvwHistory.Location = new System.Drawing.Point(3, 3);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(499, 213);
            this.lvwHistory.SmallImageList = this.treeImageList;
            this.lvwHistory.TabIndex = 2;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            this.lvwHistory.SelectedIndexChanged += new System.EventHandler(this.lvwHistory_SelectedIndexChanged);
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 168;
            // 
            // stateColumnHeader
            // 
            this.stateColumnHeader.Text = "State";
            this.stateColumnHeader.Width = 80;
            // 
            // durationColumnHeader
            // 
            this.durationColumnHeader.Text = "Duration (ms)";
            this.durationColumnHeader.Width = 84;
            // 
            // detailsColumnHeader
            // 
            this.detailsColumnHeader.Text = "Details";
            this.detailsColumnHeader.Width = 144;
            // 
            // executedOncolumnHeader
            // 
            this.executedOncolumnHeader.Text = "Executed by";
            this.executedOncolumnHeader.Width = 92;
            // 
            // alertsRaisedColumnHeader
            // 
            this.alertsRaisedColumnHeader.Text = "Alerts";
            this.alertsRaisedColumnHeader.Width = 57;
            // 
            // statisticsTabPage
            // 
            this.statisticsTabPage.BackColor = System.Drawing.Color.White;
            this.statisticsTabPage.Controls.Add(this.lvwStatistics);
            this.statisticsTabPage.Location = new System.Drawing.Point(4, 22);
            this.statisticsTabPage.Name = "statisticsTabPage";
            this.statisticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.statisticsTabPage.Size = new System.Drawing.Size(505, 219);
            this.statisticsTabPage.TabIndex = 2;
            this.statisticsTabPage.Text = "Statistics";
            // 
            // lvwStatistics
            // 
            this.lvwStatistics.AutoResizeColumnEnabled = false;
            this.lvwStatistics.AutoResizeColumnIndex = 0;
            this.lvwStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwStatistics.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwStatistics.FullRowSelect = true;
            this.lvwStatistics.HideSelection = false;
            this.lvwStatistics.Location = new System.Drawing.Point(3, 3);
            this.lvwStatistics.Name = "lvwStatistics";
            this.lvwStatistics.Size = new System.Drawing.Size(499, 213);
            this.lvwStatistics.TabIndex = 1;
            this.lvwStatistics.UseCompatibleStateImageBehavior = false;
            this.lvwStatistics.View = System.Windows.Forms.View.Details;
            this.lvwStatistics.SelectedIndexChanged += new System.EventHandler(this.lvwStatistics_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 218;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 205;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.DarkGray;
            this.cmdViewDetails.BackgroundImage = global::QuickMon.Properties.Resources.MenuBlueShade;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 245);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(513, 16);
            this.cmdViewDetails.TabIndex = 1;
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
            this.rtxDetails.Size = new System.Drawing.Size(513, 206);
            this.rtxDetails.TabIndex = 0;
            this.rtxDetails.Text = "";
            // 
            // CollectorStatusViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 512);
            this.Controls.Add(this.cmdAgentDetailViewer);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 420);
            this.Name = "CollectorStatusViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Status Viewer";
            this.Load += new System.EventHandler(this.CollectorStatusViewer_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.currentStatusTabPage.ResumeLayout(false);
            this.currentStatusTabPage.PerformLayout();
            this.currentStatusTabPage2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statisticsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage currentStatusTabPage2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage statisticsTabPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private ListViewEx lvwProperties;
        private System.Windows.Forms.ColumnHeader propertyNameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private ListViewEx lvwStatistics;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private ListViewEx lvwHistory;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader stateColumnHeader;
        private System.Windows.Forms.ColumnHeader durationColumnHeader;
        private System.Windows.Forms.ColumnHeader detailsColumnHeader;
        private System.Windows.Forms.ColumnHeader executedOncolumnHeader;
        private System.Windows.Forms.ColumnHeader alertsRaisedColumnHeader;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.Button cmdAgentDetailViewer;
        private System.Windows.Forms.TabPage currentStatusTabPage;
        private ListViewEx lvwAgents;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.Label lblCollectorHostStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCollectorHostStatusText;
    }
}