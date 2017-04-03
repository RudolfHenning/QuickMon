namespace QuickMon.UI
{
    partial class SqlDatabaseNotifierShowViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlDatabaseNotifierShowViewer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimeChooserTo = new HenIT.Controls.DateTimeChooser();
            this.dateTimeChooserFrom = new HenIT.Controls.DateTimeChooser();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.txtCollector = new System.Windows.Forms.TextBox();
            this.chkStayCurrent = new System.Windows.Forms.CheckBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAlertLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTopCount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.lvwMessages = new QuickMon.ListViewEx();
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCollector = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCurrentState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripRTBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.showDetailsForAllSelectedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerSelectItem = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.contextMenuStripRTBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDetails});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(675, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDetails
            // 
            this.toolStripStatusLabelDetails.Name = "toolStripStatusLabelDetails";
            this.toolStripStatusLabelDetails.Size = new System.Drawing.Size(660, 17);
            this.toolStripStatusLabelDetails.Spring = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimeChooserTo);
            this.panel1.Controls.Add(this.dateTimeChooserFrom);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.txtCollector);
            this.panel1.Controls.Add(this.chkStayCurrent);
            this.panel1.Controls.Add(this.txtSearchText);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboState);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboAlertLevel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboTopCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 86);
            this.panel1.TabIndex = 0;
            // 
            // dateTimeChooserTo
            // 
            this.dateTimeChooserTo.AutoSize = true;
            this.dateTimeChooserTo.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeChooserTo.Location = new System.Drawing.Point(409, 5);
            this.dateTimeChooserTo.Name = "dateTimeChooserTo";
            this.dateTimeChooserTo.SelectedDateTime = new System.DateTime(2011, 8, 11, 23, 59, 0, 0);
            this.dateTimeChooserTo.Size = new System.Drawing.Size(146, 25);
            this.dateTimeChooserTo.TabIndex = 4;
            // 
            // dateTimeChooserFrom
            // 
            this.dateTimeChooserFrom.AutoSize = true;
            this.dateTimeChooserFrom.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeChooserFrom.Location = new System.Drawing.Point(223, 5);
            this.dateTimeChooserFrom.Name = "dateTimeChooserFrom";
            this.dateTimeChooserFrom.SelectedDateTime = new System.DateTime(2011, 8, 11, 23, 59, 0, 0);
            this.dateTimeChooserFrom.Size = new System.Drawing.Size(146, 25);
            this.dateTimeChooserFrom.TabIndex = 2;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRefresh.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.Location = new System.Drawing.Point(624, 3);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(48, 43);
            this.cmdRefresh.TabIndex = 14;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // txtCollector
            // 
            this.txtCollector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCollector.Location = new System.Drawing.Point(80, 58);
            this.txtCollector.Name = "txtCollector";
            this.txtCollector.Size = new System.Drawing.Size(186, 20);
            this.txtCollector.TabIndex = 11;
            // 
            // chkStayCurrent
            // 
            this.chkStayCurrent.AutoSize = true;
            this.chkStayCurrent.Checked = true;
            this.chkStayCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStayCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkStayCurrent.Location = new System.Drawing.Point(385, 32);
            this.chkStayCurrent.Name = "chkStayCurrent";
            this.chkStayCurrent.Size = new System.Drawing.Size(81, 17);
            this.chkStayCurrent.TabIndex = 9;
            this.chkStayCurrent.Text = "Stay current";
            this.chkStayCurrent.UseVisualStyleBackColor = true;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchText.Location = new System.Drawing.Point(315, 57);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(268, 20);
            this.txtSearchText.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Collector";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "NotAvailable",
            "Good",
            "Warning",
            "Error",
            "Disabled",
            "ConfigurationError",
            "Any"});
            this.cboState.Location = new System.Drawing.Point(274, 30);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(99, 21);
            this.cboState.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Current state";
            // 
            // cboAlertLevel
            // 
            this.cboAlertLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlertLevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAlertLevel.FormattingEnabled = true;
            this.cboAlertLevel.Items.AddRange(new object[] {
            "Debug",
            "Info",
            "Warning",
            "Error",
            "Any"});
            this.cboAlertLevel.Location = new System.Drawing.Point(80, 30);
            this.cboAlertLevel.Name = "cboAlertLevel";
            this.cboAlertLevel.Size = new System.Drawing.Size(99, 21);
            this.cboAlertLevel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Alert level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "From";
            // 
            // cboTopCount
            // 
            this.cboTopCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTopCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTopCount.FormattingEnabled = true;
            this.cboTopCount.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "500",
            "1000",
            "2000",
            "5000",
            "10000",
            "20000",
            "All"});
            this.cboTopCount.Location = new System.Drawing.Point(80, 3);
            this.cboTopCount.Name = "cboTopCount";
            this.cboTopCount.Size = new System.Drawing.Size(99, 21);
            this.cboTopCount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 86);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.lvwMessages);
            this.splitContainerMain.Panel1.Controls.Add(this.cmdViewDetails);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.rtxDetails);
            this.splitContainerMain.Size = new System.Drawing.Size(675, 321);
            this.splitContainerMain.SplitterDistance = 192;
            this.splitContainerMain.TabIndex = 1;
            // 
            // lvwMessages
            // 
            this.lvwMessages.AutoResizeColumnEnabled = false;
            this.lvwMessages.AutoResizeColumnIndex = 4;
            this.lvwMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDate,
            this.columnHeaderTime,
            this.columnHeaderCollector,
            this.columnHeaderCurrentState,
            this.columnHeaderDetails});
            this.lvwMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMessages.FullRowSelect = true;
            this.lvwMessages.HideSelection = false;
            this.lvwMessages.Location = new System.Drawing.Point(0, 0);
            this.lvwMessages.Name = "lvwMessages";
            this.lvwMessages.Size = new System.Drawing.Size(675, 176);
            this.lvwMessages.SmallImageList = this.imageList1;
            this.lvwMessages.TabIndex = 0;
            this.lvwMessages.UseCompatibleStateImageBehavior = false;
            this.lvwMessages.View = System.Windows.Forms.View.Details;
            this.lvwMessages.SelectedIndexChanged += new System.EventHandler(this.lvwMessages_SelectedIndexChanged);
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 96;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.Width = 78;
            // 
            // columnHeaderCollector
            // 
            this.columnHeaderCollector.Text = "Collector";
            this.columnHeaderCollector.Width = 111;
            // 
            // columnHeaderCurrentState
            // 
            this.columnHeaderCurrentState.Text = "Current state";
            this.columnHeaderCurrentState.Width = 91;
            // 
            // columnHeaderDetails
            // 
            this.columnHeaderDetails.Text = "Details";
            this.columnHeaderDetails.Width = 192;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_ball_blue.ico");
            this.imageList1.Images.SetKeyName(1, "bullet_ball_green.ico");
            this.imageList1.Images.SetKeyName(2, "bullet_ball_yellow.ico");
            this.imageList1.Images.SetKeyName(3, "bullet_ball_red.ico");
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 176);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(675, 16);
            this.cmdViewDetails.TabIndex = 1;
            this.cmdViewDetails.Text = "ttt";
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // rtxDetails
            // 
            this.rtxDetails.ContextMenuStrip = this.contextMenuStripRTBox;
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(675, 125);
            this.rtxDetails.TabIndex = 0;
            this.rtxDetails.Text = "";
            // 
            // contextMenuStripRTBox
            // 
            this.contextMenuStripRTBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem1,
            this.toolStripMenuItem10,
            this.showDetailsForAllSelectedItemsToolStripMenuItem});
            this.contextMenuStripRTBox.Name = "contextMenuStripRTBox";
            this.contextMenuStripRTBox.Size = new System.Drawing.Size(252, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem1
            // 
            this.selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
            this.selectAllToolStripMenuItem1.Size = new System.Drawing.Size(251, 22);
            this.selectAllToolStripMenuItem1.Text = "Select all";
            this.selectAllToolStripMenuItem1.Click += new System.EventHandler(this.selectAllToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(248, 6);
            // 
            // showDetailsForAllSelectedItemsToolStripMenuItem
            // 
            this.showDetailsForAllSelectedItemsToolStripMenuItem.Name = "showDetailsForAllSelectedItemsToolStripMenuItem";
            this.showDetailsForAllSelectedItemsToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.showDetailsForAllSelectedItemsToolStripMenuItem.Text = "Show details for all selected items";
            this.showDetailsForAllSelectedItemsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsForAllSelectedItemsToolStripMenuItem_Click);
            // 
            // timerSelectItem
            // 
            this.timerSelectItem.Interval = 500;
            this.timerSelectItem.Tick += new System.EventHandler(this.timerSelectItem_Tick);
            // 
            // SqlDatabaseNotifierShowViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(675, 429);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(590, 426);
            this.Name = "SqlDatabaseNotifierShowViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sql Database Notifier Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SqlDatabaseNotifierShowViewer_FormClosing);
            this.Load += new System.EventHandler(this.SqlDatabaseNotifierShowViewer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.contextMenuStripRTBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.TextBox txtCollector;
        private System.Windows.Forms.CheckBox chkStayCurrent;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAlertLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTopCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private ListViewEx lvwMessages;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderCollector;
        private System.Windows.Forms.ColumnHeader columnHeaderCurrentState;
        private System.Windows.Forms.ColumnHeader columnHeaderDetails;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private HenIT.Controls.DateTimeChooser dateTimeChooserTo;
        private HenIT.Controls.DateTimeChooser dateTimeChooserFrom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDetails;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRTBox;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem showDetailsForAllSelectedItemsToolStripMenuItem;
        private System.Windows.Forms.Timer timerSelectItem;
    }
}