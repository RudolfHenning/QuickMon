namespace QuickMon.Collectors
{
    partial class DirectoryServicesQueryCollectorShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryServicesQueryCollectorShowDetails));
            this.lvwResults = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerDetails = new System.Windows.Forms.SplitContainer();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.statesImageList = new System.Windows.Forms.ImageList(this.components);
            this.timerSelectItem = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).BeginInit();
            this.splitContainerDetails.Panel1.SuspendLayout();
            this.splitContainerDetails.Panel2.SuspendLayout();
            this.splitContainerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.AutoResizeColumnEnabled = false;
            this.lvwResults.AutoResizeColumnIndex = 0;
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.columnHeaderValue});
            this.lvwResults.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lvwResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwResults.FullRowSelect = true;
            this.lvwResults.HideSelection = false;
            this.lvwResults.Location = new System.Drawing.Point(0, 0);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(664, 181);
            this.lvwResults.SmallImageList = this.statesImageList;
            this.lvwResults.TabIndex = 7;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            this.lvwResults.SelectedIndexChanged += new System.EventHandler(this.lvwResults_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 207;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 121;
            // 
            // splitContainerDetails
            // 
            this.splitContainerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDetails.Location = new System.Drawing.Point(0, 39);
            this.splitContainerDetails.Name = "splitContainerDetails";
            this.splitContainerDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDetails.Panel1
            // 
            this.splitContainerDetails.Panel1.Controls.Add(this.lvwResults);
            this.splitContainerDetails.Panel1.Controls.Add(this.cmdViewDetails);
            // 
            // splitContainerDetails.Panel2
            // 
            this.splitContainerDetails.Panel2.Controls.Add(this.rtxDetails);
            this.splitContainerDetails.Size = new System.Drawing.Size(664, 362);
            this.splitContainerDetails.SplitterDistance = 197;
            this.splitContainerDetails.SplitterWidth = 8;
            this.splitContainerDetails.TabIndex = 9;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.DarkGray;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 181);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(664, 16);
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
            this.rtxDetails.Size = new System.Drawing.Size(664, 157);
            this.rtxDetails.TabIndex = 2;
            this.rtxDetails.Text = "";
            // 
            // statesImageList
            // 
            this.statesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statesImageList.ImageStream")));
            this.statesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.statesImageList.Images.SetKeyName(0, "GUnknown.ico");
            this.statesImageList.Images.SetKeyName(1, "GRunning.ico");
            this.statesImageList.Images.SetKeyName(2, "GPaused.ico");
            this.statesImageList.Images.SetKeyName(3, "GStopped.ico");
            // 
            // timerSelectItem
            // 
            this.timerSelectItem.Interval = 500;
            this.timerSelectItem.Tick += new System.EventHandler(this.timerSelectItem_Tick);
            // 
            // DirectoryServicesQueryCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 423);
            this.Controls.Add(this.splitContainerDetails);
            this.ExportButtonVisible = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DirectoryServicesQueryCollectorShowDetails";
            this.Text = "DirectoryServicesQueryCollectorShowDetails";
            this.Load += new System.EventHandler(this.DirectoryServicesQueryCollectorShowDetails_Load);
            this.Controls.SetChildIndex(this.splitContainerDetails, 0);
            this.splitContainerDetails.Panel1.ResumeLayout(false);
            this.splitContainerDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).EndInit();
            this.splitContainerDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewEx lvwResults;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.SplitContainer splitContainerDetails;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.ImageList statesImageList;
        private System.Windows.Forms.Timer timerSelectItem;
    }
}