namespace QuickMon.Collectors
{
    partial class EventLogCollectorViewDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventLogCollectorViewDetails));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwEntries2 = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.machLogColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListSummary = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerDetails = new System.Windows.Forms.SplitContainer();
            this.lvwDetails = new QuickMon.ListViewEx();
            this.columnHeaderLog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSummary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListDetails = new System.Windows.Forms.ImageList(this.components);
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.timerSelectItem = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).BeginInit();
            this.splitContainerDetails.Panel1.SuspendLayout();
            this.splitContainerDetails.Panel2.SuspendLayout();
            this.splitContainerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwEntries
            // 
            this.lvwEntries.Size = new System.Drawing.Size(716, 405);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwEntries2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerDetails);
            this.splitContainer1.Size = new System.Drawing.Size(716, 405);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 13;
            // 
            // lvwEntries2
            // 
            this.lvwEntries2.AutoResizeColumnEnabled = true;
            this.lvwEntries2.AutoResizeColumnIndex = 1;
            this.lvwEntries2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.machLogColumnHeader,
            this.columnHeaderCount});
            this.lvwEntries2.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lvwEntries2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEntries2.FullRowSelect = true;
            this.lvwEntries2.HideSelection = false;
            this.lvwEntries2.Location = new System.Drawing.Point(0, 0);
            this.lvwEntries2.Name = "lvwEntries2";
            this.lvwEntries2.Size = new System.Drawing.Size(716, 130);
            this.lvwEntries2.SmallImageList = this.imageListSummary;
            this.lvwEntries2.TabIndex = 23;
            this.lvwEntries2.UseCompatibleStateImageBehavior = false;
            this.lvwEntries2.View = System.Windows.Forms.View.Details;
            this.lvwEntries2.SelectedIndexChanged += new System.EventHandler(this.lvwEntries_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Computer\\Event Log";
            this.nameColumnHeader.Width = 181;
            // 
            // machLogColumnHeader
            // 
            this.machLogColumnHeader.Text = "Filter summary";
            this.machLogColumnHeader.Width = 464;
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "Count";
            this.columnHeaderCount.Width = 65;
            // 
            // imageListSummary
            // 
            this.imageListSummary.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSummary.ImageStream")));
            this.imageListSummary.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSummary.Images.SetKeyName(0, "bullet_ball_glass_blue.ico");
            this.imageListSummary.Images.SetKeyName(1, "bullet_ball_glass_green.ico");
            this.imageListSummary.Images.SetKeyName(2, "bullet_ball_glass_yellow.ico");
            this.imageListSummary.Images.SetKeyName(3, "bullet_ball_glass_red.ico");
            // 
            // splitContainerDetails
            // 
            this.splitContainerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDetails.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainerDetails.Size = new System.Drawing.Size(716, 271);
            this.splitContainerDetails.SplitterDistance = 133;
            this.splitContainerDetails.TabIndex = 10;
            // 
            // lvwDetails
            // 
            this.lvwDetails.AutoResizeColumnEnabled = true;
            this.lvwDetails.AutoResizeColumnIndex = 5;
            this.lvwDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLog,
            this.columnHeaderDate,
            this.columnHeaderTime,
            this.columnHeaderSource,
            this.columnHeaderEventID,
            this.columnHeaderSummary});
            this.lvwDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDetails.FullRowSelect = true;
            this.lvwDetails.HideSelection = false;
            this.lvwDetails.Location = new System.Drawing.Point(0, 0);
            this.lvwDetails.Name = "lvwDetails";
            this.lvwDetails.Size = new System.Drawing.Size(716, 117);
            this.lvwDetails.SmallImageList = this.imageListDetails;
            this.lvwDetails.TabIndex = 9;
            this.lvwDetails.UseCompatibleStateImageBehavior = false;
            this.lvwDetails.View = System.Windows.Forms.View.Details;
            this.lvwDetails.SelectedIndexChanged += new System.EventHandler(this.lvwDetails_SelectedIndexChanged);
            // 
            // columnHeaderLog
            // 
            this.columnHeaderLog.Text = "Log";
            this.columnHeaderLog.Width = 146;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 120;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.Width = 80;
            // 
            // columnHeaderSource
            // 
            this.columnHeaderSource.Text = "Source";
            this.columnHeaderSource.Width = 150;
            // 
            // columnHeaderEventID
            // 
            this.columnHeaderEventID.Text = "Event ID";
            this.columnHeaderEventID.Width = 70;
            // 
            // columnHeaderSummary
            // 
            this.columnHeaderSummary.Text = "Summary";
            this.columnHeaderSummary.Width = 144;
            // 
            // imageListDetails
            // 
            this.imageListDetails.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDetails.ImageStream")));
            this.imageListDetails.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDetails.Images.SetKeyName(0, "W95MBX04.ICO");
            this.imageListDetails.Images.SetKeyName(1, "W95MBX03.ICO");
            this.imageListDetails.Images.SetKeyName(2, "W95MBX01.ICO");
            this.imageListDetails.Images.SetKeyName(3, "lock on.ico");
            this.imageListDetails.Images.SetKeyName(4, "lock off.ico");
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 117);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(716, 16);
            this.cmdViewDetails.TabIndex = 8;
            this.cmdViewDetails.Text = "ttt";
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // rtxDetails
            // 
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(716, 134);
            this.rtxDetails.TabIndex = 2;
            this.rtxDetails.Text = "";
            // 
            // timerSelectItem
            // 
            this.timerSelectItem.Interval = 500;
            this.timerSelectItem.Tick += new System.EventHandler(this.timerSelectItem_Tick);
            // 
            // EventLogCollectorViewDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 466);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventLogCollectorViewDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Details";
            this.Load += new System.EventHandler(this.EventLogCollectorViewDetails_Load);
            this.Controls.SetChildIndex(this.lvwEntries, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerDetails.Panel1.ResumeLayout(false);
            this.splitContainerDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).EndInit();
            this.splitContainerDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ListViewEx lvwEntries2;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader machLogColumnHeader;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
        private System.Windows.Forms.SplitContainer splitContainerDetails;
        private ListViewEx lvwDetails;
        private System.Windows.Forms.ColumnHeader columnHeaderLog;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderSource;
        private System.Windows.Forms.ColumnHeader columnHeaderEventID;
        private System.Windows.Forms.ColumnHeader columnHeaderSummary;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.ImageList imageListSummary;
        private System.Windows.Forms.Timer timerSelectItem;
        private System.Windows.Forms.ImageList imageListDetails;
    }
}