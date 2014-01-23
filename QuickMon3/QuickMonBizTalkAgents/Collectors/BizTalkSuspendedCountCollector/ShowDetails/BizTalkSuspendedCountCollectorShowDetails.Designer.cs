using HenIT.Controls;
namespace QuickMon.Collectors
{
    partial class BizTalkSuspendedCountCollectorShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BizTalkSuspendedCountCollectorShowDetails));
            this.hostColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.appColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uriColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adapterColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.additionalInfoColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwEntries = new QuickMon.ListViewEx();
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this.splitContainerDetails = new System.Windows.Forms.SplitContainer();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.rtxDetails = new HenIT.Controls.RichTextControlEx();
            this.contextMenuStripRTF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerSelectItem = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).BeginInit();
            this.splitContainerDetails.Panel1.SuspendLayout();
            this.splitContainerDetails.Panel2.SuspendLayout();
            this.splitContainerDetails.SuspendLayout();
            this.contextMenuStripRTF.SuspendLayout();
            this.SuspendLayout();
            // 
            // hostColumnHeader
            // 
            this.hostColumnHeader.Text = "Host";
            this.hostColumnHeader.Width = 136;
            // 
            // appColumnHeader
            // 
            this.appColumnHeader.Text = "Application";
            this.appColumnHeader.Width = 113;
            // 
            // msgTypeColumnHeader
            // 
            this.msgTypeColumnHeader.Text = "Message Type";
            this.msgTypeColumnHeader.Width = 101;
            // 
            // serverColumnHeader
            // 
            this.serverColumnHeader.Text = "Server";
            this.serverColumnHeader.Width = 92;
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 115;
            // 
            // uriColumnHeader
            // 
            this.uriColumnHeader.Text = "URI";
            // 
            // adapterColumnHeader
            // 
            this.adapterColumnHeader.Text = "Adapter";
            // 
            // additionalInfoColumnHeader
            // 
            this.additionalInfoColumnHeader.Text = "Additional Info";
            this.additionalInfoColumnHeader.Width = 151;
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = false;
            this.lvwEntries.AutoResizeColumnIndex = 7;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hostColumnHeader,
            this.appColumnHeader,
            this.msgTypeColumnHeader,
            this.serverColumnHeader,
            this.timeColumnHeader,
            this.uriColumnHeader,
            this.adapterColumnHeader,
            this.additionalInfoColumnHeader});
            this.lvwEntries.ContextMenuStrip = this.refreshContextMenuStrip;
            this.lvwEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEntries.FullRowSelect = true;
            this.lvwEntries.HideSelection = false;
            this.lvwEntries.Location = new System.Drawing.Point(0, 0);
            this.lvwEntries.Name = "lvwEntries";
            this.lvwEntries.Size = new System.Drawing.Size(834, 216);
            this.lvwEntries.TabIndex = 0;
            this.lvwEntries.UseCompatibleStateImageBehavior = false;
            this.lvwEntries.View = System.Windows.Forms.View.Details;
            this.lvwEntries.SelectedIndexChanged += new System.EventHandler(this.lvwEntries_SelectedIndexChanged);
            // 
            // saveFileDialogCSV
            // 
            this.saveFileDialogCSV.DefaultExt = "csv";
            this.saveFileDialogCSV.Filter = "CSV Files|*.csv";
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
            this.splitContainerDetails.Panel1.Controls.Add(this.lvwEntries);
            this.splitContainerDetails.Panel1.Controls.Add(this.cmdViewDetails);
            // 
            // splitContainerDetails.Panel2
            // 
            this.splitContainerDetails.Panel2.Controls.Add(this.rtxDetails);
            this.splitContainerDetails.Size = new System.Drawing.Size(834, 348);
            this.splitContainerDetails.SplitterDistance = 232;
            this.splitContainerDetails.TabIndex = 0;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.BackColor = System.Drawing.Color.DarkGray;
            this.cmdViewDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdViewDetails.FlatAppearance.BorderSize = 0;
            this.cmdViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdViewDetails.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdViewDetails.Location = new System.Drawing.Point(0, 216);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(834, 16);
            this.cmdViewDetails.TabIndex = 1;
            this.cmdViewDetails.Text = "ttt";
            this.cmdViewDetails.UseVisualStyleBackColor = false;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // rtxDetails
            // 
            this.rtxDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rtxDetails.ContextMenuStrip = this.contextMenuStripRTF;
            this.rtxDetails.DefaultRTFFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtxDetails.SelectionLength = 0;
            this.rtxDetails.SelectionStart = 0;
            this.rtxDetails.Size = new System.Drawing.Size(834, 112);
            this.rtxDetails.TabIndex = 0;
            // 
            // contextMenuStripRTF
            // 
            this.contextMenuStripRTF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.contextMenuStripRTF.Name = "contextMenuStripRTF";
            this.contextMenuStripRTF.Size = new System.Drawing.Size(123, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // timerSelectItem
            // 
            this.timerSelectItem.Interval = 500;
            this.timerSelectItem.Tick += new System.EventHandler(this.timerSelectItem_Tick);
            // 
            // BizTalkSuspendedCountCollectorShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 409);
            this.Controls.Add(this.splitContainerDetails);
            this.ExportButtonVisible = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BizTalkSuspendedCountCollectorShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BizTalkSuspendedCountCollectorShowDetails";
            this.Controls.SetChildIndex(this.splitContainerDetails, 0);
            this.splitContainerDetails.Panel1.ResumeLayout(false);
            this.splitContainerDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetails)).EndInit();
            this.splitContainerDetails.ResumeLayout(false);
            this.contextMenuStripRTF.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ColumnHeader hostColumnHeader;
        private System.Windows.Forms.ColumnHeader appColumnHeader;
        private System.Windows.Forms.ColumnHeader msgTypeColumnHeader;
        private System.Windows.Forms.ColumnHeader serverColumnHeader;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader uriColumnHeader;
        private System.Windows.Forms.ColumnHeader adapterColumnHeader;
        private System.Windows.Forms.ColumnHeader additionalInfoColumnHeader;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCSV;
        public ListViewEx lvwEntries;
        private System.Windows.Forms.SplitContainer splitContainerDetails;
        private System.Windows.Forms.Button cmdViewDetails;
        private RichTextControlEx rtxDetails;
        private System.Windows.Forms.Timer timerSelectItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRTF;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}