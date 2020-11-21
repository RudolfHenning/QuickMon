namespace QuickMon
{
    partial class CollectorFilterView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorFilterView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFilter = new QuickMon.Controls.TextBoxEx();
            this.cboStateFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.agentStateSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lvwCollectorStates = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.PathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).BeginInit();
            this.agentStateSplitContainer.Panel1.SuspendLayout();
            this.agentStateSplitContainer.Panel2.SuspendLayout();
            this.agentStateSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.cboStateFilter);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmdViewDetails);
            this.panel1.Controls.Add(this.cboFilterType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 33);
            this.panel1.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.HideSelection = false;
            this.txtFilter.Location = new System.Drawing.Point(175, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(352, 21);
            this.txtFilter.TabIndex = 17;
            // 
            // cboStateFilter
            // 
            this.cboStateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.cboStateFilter.Location = new System.Drawing.Point(578, 5);
            this.cboStateFilter.Name = "cboStateFilter";
            this.cboStateFilter.Size = new System.Drawing.Size(92, 23);
            this.cboStateFilter.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(533, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "State";
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.Transparent;
            this.cmdViewDetails.BackgroundImage = global::QuickMon.Properties.Resources.comp_search24;
            this.cmdViewDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdViewDetails.Location = new System.Drawing.Point(703, 0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(28, 33);
            this.cmdViewDetails.TabIndex = 14;
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Items.AddRange(new object[] {
            "All",
            "Collector name",
            "Category",
            "Value"});
            this.cboFilterType.Location = new System.Drawing.Point(60, 5);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(109, 23);
            this.cboFilterType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Filters";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(731, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            this.agentStateSplitContainer.Panel1.Controls.Add(this.lvwCollectorStates);
            // 
            // agentStateSplitContainer.Panel2
            // 
            this.agentStateSplitContainer.Panel2.Controls.Add(this.rtxDetails);
            this.agentStateSplitContainer.Panel2.Controls.Add(this.label3);
            this.agentStateSplitContainer.Size = new System.Drawing.Size(731, 424);
            this.agentStateSplitContainer.SplitterDistance = 254;
            this.agentStateSplitContainer.SplitterWidth = 6;
            this.agentStateSplitContainer.TabIndex = 14;
            // 
            // lvwCollectorStates
            // 
            this.lvwCollectorStates.AutoResizeColumnEnabled = false;
            this.lvwCollectorStates.AutoResizeColumnIndex = 1;
            this.lvwCollectorStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwCollectorStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.PathColumnHeader,
            this.collectorValueColumnHeader});
            this.lvwCollectorStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCollectorStates.FullRowSelect = true;
            this.lvwCollectorStates.Location = new System.Drawing.Point(0, 0);
            this.lvwCollectorStates.Name = "lvwCollectorStates";
            this.lvwCollectorStates.Size = new System.Drawing.Size(731, 254);
            this.lvwCollectorStates.SmallImageList = this.imagesCollectorTree;
            this.lvwCollectorStates.TabIndex = 0;
            this.lvwCollectorStates.UseCompatibleStateImageBehavior = false;
            this.lvwCollectorStates.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 242;
            // 
            // collectorValueColumnHeader
            // 
            this.collectorValueColumnHeader.Text = "Value";
            this.collectorValueColumnHeader.Width = 157;
            // 
            // rtxDetails
            // 
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDetails.HideSelection = false;
            this.rtxDetails.Location = new System.Drawing.Point(0, 1);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(731, 163);
            this.rtxDetails.TabIndex = 3;
            this.rtxDetails.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(731, 1);
            this.label3.TabIndex = 1;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdRefresh.FlatAppearance.BorderSize = 0;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Location = new System.Drawing.Point(675, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(28, 33);
            this.cmdRefresh.TabIndex = 18;
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
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
            // PathColumnHeader
            // 
            this.PathColumnHeader.Text = "Path";
            this.PathColumnHeader.Width = 299;
            // 
            // CollectorFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 479);
            this.Controls.Add(this.agentStateSplitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectorFilterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector states by filter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CollectorFilterView_FormClosing);
            this.Load += new System.EventHandler(this.CollectorFilterView_Load);
            this.Shown += new System.EventHandler(this.CollectorFilterView_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.agentStateSplitContainer.Panel1.ResumeLayout(false);
            this.agentStateSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).EndInit();
            this.agentStateSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer agentStateSplitContainer;
        private ListViewEx lvwCollectorStates;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader collectorValueColumnHeader;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.ComboBox cboStateFilter;
        private System.Windows.Forms.Label label5;
        private Controls.TextBoxEx txtFilter;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ImageList imagesCollectorTree;
        private System.Windows.Forms.ColumnHeader PathColumnHeader;
    }
}