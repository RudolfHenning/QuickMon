using QuickMon.Controls;

namespace QuickMon
{
    partial class GlobalAgentHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalAgentHistory));
            this.panelTop = new System.Windows.Forms.Panel();
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.txtFilter = new QuickMon.Controls.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStateFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbomaxResults = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.statusStripCollector = new System.Windows.Forms.StatusStrip();
            this.lastUpdateTimeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.countsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.agentStateSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lvwHistory = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.rawViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rawViewCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawViewSelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llblDetails = new System.Windows.Forms.LinkLabel();
            this.lblResetText = new QuickMon.Controls.LinkLabelEx();
            this.panelTop.SuspendLayout();
            this.filtersPanel.SuspendLayout();
            this.statusStripCollector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).BeginInit();
            this.agentStateSplitContainer.Panel1.SuspendLayout();
            this.agentStateSplitContainer.Panel2.SuspendLayout();
            this.agentStateSplitContainer.SuspendLayout();
            this.rawViewContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.filtersPanel);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.cbomaxResults);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.cmdRefresh);
            this.panelTop.Controls.Add(this.cmdViewDetails);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 33);
            this.panelTop.TabIndex = 0;
            // 
            // filtersPanel
            // 
            this.filtersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersPanel.Controls.Add(this.lblResetText);
            this.filtersPanel.Controls.Add(this.txtFilter);
            this.filtersPanel.Controls.Add(this.label6);
            this.filtersPanel.Controls.Add(this.cboStateFilter);
            this.filtersPanel.Controls.Add(this.label5);
            this.filtersPanel.Controls.Add(this.label4);
            this.filtersPanel.Location = new System.Drawing.Point(0, 0);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(542, 33);
            this.filtersPanel.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.HideSelection = false;
            this.txtFilter.Location = new System.Drawing.Point(243, 5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(280, 21);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.txtFilter_EnterKeyPressed);
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(203, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Text";
            // 
            // cboStateFilter
            // 
            this.cboStateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStateFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStateFilter.FormattingEnabled = true;
            this.cboStateFilter.Items.AddRange(new object[] {
            "All",
            "Good",
            "Warning",
            "Error",
            "Warn & Err"});
            this.cboStateFilter.Location = new System.Drawing.Point(105, 3);
            this.cboStateFilter.Name = "cboStateFilter";
            this.cboStateFilter.Size = new System.Drawing.Size(92, 23);
            this.cboStateFilter.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "State";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Filters";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(671, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entries";
            // 
            // cbomaxResults
            // 
            this.cbomaxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbomaxResults.BackColor = System.Drawing.Color.White;
            this.cbomaxResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomaxResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbomaxResults.FormattingEnabled = true;
            this.cbomaxResults.Items.AddRange(new object[] {
            "10",
            "100",
            "1000",
            "10000",
            "100000"});
            this.cbomaxResults.Location = new System.Drawing.Point(587, 6);
            this.cbomaxResults.Name = "cbomaxResults";
            this.cbomaxResults.Size = new System.Drawing.Size(78, 21);
            this.cbomaxResults.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(548, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdRefresh.FlatAppearance.BorderSize = 0;
            this.cmdRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Location = new System.Drawing.Point(728, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(28, 33);
            this.cmdRefresh.TabIndex = 4;
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.Transparent;
            this.cmdViewDetails.BackgroundImage = global::QuickMon.Properties.Resources.comp_search24;
            this.cmdViewDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdViewDetails.Location = new System.Drawing.Point(756, 0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(28, 33);
            this.cmdViewDetails.TabIndex = 5;
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // statusStripCollector
            // 
            this.statusStripCollector.BackColor = System.Drawing.Color.Transparent;
            this.statusStripCollector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastUpdateTimeToolStripStatusLabel,
            this.countsToolStripStatusLabel});
            this.statusStripCollector.Location = new System.Drawing.Point(0, 539);
            this.statusStripCollector.Name = "statusStripCollector";
            this.statusStripCollector.Size = new System.Drawing.Size(784, 22);
            this.statusStripCollector.TabIndex = 2;
            this.statusStripCollector.Text = "statusStrip1";
            // 
            // lastUpdateTimeToolStripStatusLabel
            // 
            this.lastUpdateTimeToolStripStatusLabel.Name = "lastUpdateTimeToolStripStatusLabel";
            this.lastUpdateTimeToolStripStatusLabel.Size = new System.Drawing.Size(65, 17);
            this.lastUpdateTimeToolStripStatusLabel.Text = "<No data>";
            // 
            // countsToolStripStatusLabel
            // 
            this.countsToolStripStatusLabel.Name = "countsToolStripStatusLabel";
            this.countsToolStripStatusLabel.Size = new System.Drawing.Size(61, 17);
            this.countsToolStripStatusLabel.Text = "<Counts>";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(784, 1);
            this.label3.TabIndex = 1;
            // 
            // agentStateSplitContainer
            // 
            this.agentStateSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentStateSplitContainer.Location = new System.Drawing.Point(0, 33);
            this.agentStateSplitContainer.Name = "agentStateSplitContainer";
            this.agentStateSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // agentStateSplitContainer.Panel1
            // 
            this.agentStateSplitContainer.Panel1.Controls.Add(this.lvwHistory);
            this.agentStateSplitContainer.Panel1.Controls.Add(this.llblDetails);
            // 
            // agentStateSplitContainer.Panel2
            // 
            this.agentStateSplitContainer.Panel2.Controls.Add(this.rtxDetails);
            this.agentStateSplitContainer.Panel2.Controls.Add(this.label3);
            this.agentStateSplitContainer.Size = new System.Drawing.Size(784, 506);
            this.agentStateSplitContainer.SplitterDistance = 304;
            this.agentStateSplitContainer.SplitterWidth = 6;
            this.agentStateSplitContainer.TabIndex = 1;
            // 
            // lvwHistory
            // 
            this.lvwHistory.AutoResizeColumnEnabled = false;
            this.lvwHistory.AutoResizeColumnIndex = 0;
            this.lvwHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.timeColumnHeader,
            this.collectorValueColumnHeader,
            this.durationColumnHeader,
            this.alertCountColumnHeader});
            this.lvwHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.HideSelection = false;
            this.lvwHistory.Location = new System.Drawing.Point(0, 0);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(784, 286);
            this.lvwHistory.SmallImageList = this.imagesCollectorTree;
            this.lvwHistory.TabIndex = 0;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            this.lvwHistory.SelectedIndexChanged += new System.EventHandler(this.lvwHistory_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 328;
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 128;
            // 
            // collectorValueColumnHeader
            // 
            this.collectorValueColumnHeader.Text = "Value";
            this.collectorValueColumnHeader.Width = 97;
            // 
            // durationColumnHeader
            // 
            this.durationColumnHeader.Text = "Duration (ms)";
            this.durationColumnHeader.Width = 85;
            // 
            // alertCountColumnHeader
            // 
            this.alertCountColumnHeader.Text = "Alerts";
            this.alertCountColumnHeader.Width = 78;
            // 
            // imagesCollectorTree
            // 
            this.imagesCollectorTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesCollectorTree.ImageStream")));
            this.imagesCollectorTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesCollectorTree.Images.SetKeyName(0, "open_folder_blue24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(1, "helpbwy24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(2, "ok.png");
            this.imagesCollectorTree.Images.SetKeyName(3, "triang_yellow.png");
            this.imagesCollectorTree.Images.SetKeyName(4, "triang_red24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(5, "ok3.png");
            this.imagesCollectorTree.Images.SetKeyName(6, "triang_yellow2.png");
            this.imagesCollectorTree.Images.SetKeyName(7, "triang_red24x24faded.png");
            this.imagesCollectorTree.Images.SetKeyName(8, "ForbiddenBW16x16.png");
            this.imagesCollectorTree.Images.SetKeyName(9, "clock1.png");
            this.imagesCollectorTree.Images.SetKeyName(10, "Error24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(11, "Error2_24x24.png");
            // 
            // rtxDetails
            // 
            this.rtxDetails.ContextMenuStrip = this.rawViewContextMenuStrip;
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDetails.HideSelection = false;
            this.rtxDetails.Location = new System.Drawing.Point(0, 1);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(784, 195);
            this.rtxDetails.TabIndex = 3;
            this.rtxDetails.Text = "";
            // 
            // rawViewContextMenuStrip
            // 
            this.rawViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawViewCopyToolStripMenuItem,
            this.rawViewSelectAllToolStripMenuItem});
            this.rawViewContextMenuStrip.Name = "rawViewContextMenuStrip";
            this.rawViewContextMenuStrip.Size = new System.Drawing.Size(123, 48);
            // 
            // rawViewCopyToolStripMenuItem
            // 
            this.rawViewCopyToolStripMenuItem.Name = "rawViewCopyToolStripMenuItem";
            this.rawViewCopyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rawViewCopyToolStripMenuItem.Text = "C&opy";
            this.rawViewCopyToolStripMenuItem.Click += new System.EventHandler(this.rawViewCopyToolStripMenuItem_Click);
            // 
            // rawViewSelectAllToolStripMenuItem
            // 
            this.rawViewSelectAllToolStripMenuItem.Name = "rawViewSelectAllToolStripMenuItem";
            this.rawViewSelectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rawViewSelectAllToolStripMenuItem.Text = "Select &All";
            this.rawViewSelectAllToolStripMenuItem.Click += new System.EventHandler(this.rawViewSelectAllToolStripMenuItem_Click);
            // 
            // llblDetails
            // 
            this.llblDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.llblDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.llblDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llblDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblDetails.Location = new System.Drawing.Point(0, 286);
            this.llblDetails.Name = "llblDetails";
            this.llblDetails.Size = new System.Drawing.Size(784, 18);
            this.llblDetails.TabIndex = 2;
            this.llblDetails.TabStop = true;
            this.llblDetails.Text = "Details";
            this.llblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDetails_LinkClicked);
            // 
            // lblResetText
            // 
            this.lblResetText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResetText.AutoSize = true;
            this.lblResetText.BackColorOnEnter = System.Drawing.Color.LightCyan;
            this.lblResetText.BackColorOnLeave = System.Drawing.Color.White;
            this.lblResetText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblResetText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetText.ForeColor = System.Drawing.Color.Red;
            this.lblResetText.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblResetText.LinkColor = System.Drawing.Color.Red;
            this.lblResetText.Location = new System.Drawing.Point(524, 8);
            this.lblResetText.Name = "lblResetText";
            this.lblResetText.Size = new System.Drawing.Size(15, 13);
            this.lblResetText.TabIndex = 7;
            this.lblResetText.TabStop = true;
            this.lblResetText.Text = "X";
            this.lblResetText.Visible = false;
            this.lblResetText.Click += new System.EventHandler(this.lblResetText_Click);
            // 
            // GlobalAgentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.agentStateSplitContainer);
            this.Controls.Add(this.statusStripCollector);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "GlobalAgentHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Global Collector History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalAgentHistory_FormClosing);
            this.Load += new System.EventHandler(this.GlobalAgentHistory_Load);
            this.Shown += new System.EventHandler(this.GlobalAgentHistory_Shown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.filtersPanel.ResumeLayout(false);
            this.filtersPanel.PerformLayout();
            this.statusStripCollector.ResumeLayout(false);
            this.statusStripCollector.PerformLayout();
            this.agentStateSplitContainer.Panel1.ResumeLayout(false);
            this.agentStateSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).EndInit();
            this.agentStateSplitContainer.ResumeLayout(false);
            this.rawViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.StatusStrip statusStripCollector;
        private System.Windows.Forms.ToolStripStatusLabel lastUpdateTimeToolStripStatusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer agentStateSplitContainer;
        private ListViewEx lvwHistory;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader collectorValueColumnHeader;
        private System.Windows.Forms.ColumnHeader durationColumnHeader;
        private System.Windows.Forms.ColumnHeader alertCountColumnHeader;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbomaxResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ImageList imagesCollectorTree;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.ContextMenuStrip rawViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rawViewCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawViewSelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel countsToolStripStatusLabel;
        private System.Windows.Forms.Panel filtersPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStateFilter;
        private System.Windows.Forms.Label label5;
        private TextBoxEx txtFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel llblDetails;
        private LinkLabelEx lblResetText;
    }
}