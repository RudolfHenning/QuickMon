namespace QuickMon.UI
{
    partial class EditCollectorAgentEntries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCollectorAgentEntries));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entriesImageList = new System.Windows.Forms.ImageList(this.components);
            this.collectorEditToolStrip = new System.Windows.Forms.ToolStrip();
            this.addCollectorConfigEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editCollectorAgentEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteCollectorAgentEntriesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAgentType = new System.Windows.Forms.TextBox();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.tvwEntries = new QuickMon.TreeViewEx();
            this.lvwEntries = new QuickMon.ListViewEx();
            this.entriesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.triggerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.collectorEditToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(463, 373);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(382, 373);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tvwEntries);
            this.panel1.Controls.Add(this.lvwEntries);
            this.panel1.Controls.Add(this.collectorEditToolStrip);
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 305);
            this.panel1.TabIndex = 5;
            // 
            // entriesImageList
            // 
            this.entriesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("entriesImageList.ImageStream")));
            this.entriesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.entriesImageList.Images.SetKeyName(0, "5_50.ico");
            this.entriesImageList.Images.SetKeyName(1, "243.ico");
            // 
            // collectorEditToolStrip
            // 
            this.collectorEditToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.collectorEditToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorConfigEntryToolStripButton,
            this.editCollectorAgentEntryToolStripButton,
            this.deleteCollectorAgentEntriesToolStripButton});
            this.collectorEditToolStrip.Location = new System.Drawing.Point(0, 0);
            this.collectorEditToolStrip.Name = "collectorEditToolStrip";
            this.collectorEditToolStrip.Size = new System.Drawing.Size(550, 25);
            this.collectorEditToolStrip.TabIndex = 0;
            this.collectorEditToolStrip.TabStop = true;
            this.collectorEditToolStrip.Text = "toolStrip1";
            // 
            // addCollectorConfigEntryToolStripButton
            // 
            this.addCollectorConfigEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCollectorConfigEntryToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addCollectorConfigEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCollectorConfigEntryToolStripButton.Name = "addCollectorConfigEntryToolStripButton";
            this.addCollectorConfigEntryToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addCollectorConfigEntryToolStripButton.Text = "Add Collector entry";
            this.addCollectorConfigEntryToolStripButton.ToolTipText = "Add entry";
            this.addCollectorConfigEntryToolStripButton.Click += new System.EventHandler(this.addCollectorConfigEntryToolStripButton_Click);
            // 
            // editCollectorAgentEntryToolStripButton
            // 
            this.editCollectorAgentEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editCollectorAgentEntryToolStripButton.Enabled = false;
            this.editCollectorAgentEntryToolStripButton.Image = global::QuickMon.Properties.Resources.proc2;
            this.editCollectorAgentEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editCollectorAgentEntryToolStripButton.Name = "editCollectorAgentEntryToolStripButton";
            this.editCollectorAgentEntryToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editCollectorAgentEntryToolStripButton.Text = "Edit Entry";
            this.editCollectorAgentEntryToolStripButton.Click += new System.EventHandler(this.editCollectorAgentEntryToolStripButton_Click);
            // 
            // deleteCollectorAgentEntriesToolStripButton
            // 
            this.deleteCollectorAgentEntriesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteCollectorAgentEntriesToolStripButton.Enabled = false;
            this.deleteCollectorAgentEntriesToolStripButton.Image = global::QuickMon.Properties.Resources.whack;
            this.deleteCollectorAgentEntriesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteCollectorAgentEntriesToolStripButton.Name = "deleteCollectorAgentEntriesToolStripButton";
            this.deleteCollectorAgentEntriesToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteCollectorAgentEntriesToolStripButton.Text = "Delete Entry";
            this.deleteCollectorAgentEntriesToolStripButton.Click += new System.EventHandler(this.deleteCollectorAgentEntriesToolStripButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnabled.Location = new System.Drawing.Point(475, 12);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(63, 17);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(109, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(360, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Type";
            // 
            // txtAgentType
            // 
            this.txtAgentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgentType.Location = new System.Drawing.Point(109, 38);
            this.txtAgentType.Name = "txtAgentType";
            this.txtAgentType.ReadOnly = true;
            this.txtAgentType.Size = new System.Drawing.Size(360, 20);
            this.txtAgentType.TabIndex = 4;
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(12, 378);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(86, 13);
            this.llblRawEdit.TabIndex = 8;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW config";
            this.llblRawEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRawEdit_LinkClicked);
            // 
            // tvwEntries
            // 
            this.tvwEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwEntries.FullRowSelect = true;
            this.tvwEntries.ImageIndex = 0;
            this.tvwEntries.ImageList = this.entriesImageList;
            this.tvwEntries.Location = new System.Drawing.Point(0, 154);
            this.tvwEntries.Name = "tvwEntries";
            this.tvwEntries.SelectedImageIndex = 0;
            this.tvwEntries.Size = new System.Drawing.Size(550, 151);
            this.tvwEntries.TabIndex = 2;
            this.tvwEntries.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.tvwEntries_EnterKeyPressed);
            this.tvwEntries.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.tvwEntries_DeleteKeyPressed);
            this.tvwEntries.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwEntries_AfterSelect);
            this.tvwEntries.DoubleClick += new System.EventHandler(this.tvwEntries_DoubleClick);
            // 
            // lvwEntries
            // 
            this.lvwEntries.AutoResizeColumnEnabled = false;
            this.lvwEntries.AutoResizeColumnIndex = 0;
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.entriesColumnHeader,
            this.triggerColumnHeader});
            this.lvwEntries.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwEntries.FullRowSelect = true;
            this.lvwEntries.HideSelection = false;
            this.lvwEntries.Location = new System.Drawing.Point(0, 25);
            this.lvwEntries.Name = "lvwEntries";
            this.lvwEntries.Size = new System.Drawing.Size(550, 129);
            this.lvwEntries.SmallImageList = this.entriesImageList;
            this.lvwEntries.TabIndex = 1;
            this.lvwEntries.UseCompatibleStateImageBehavior = false;
            this.lvwEntries.View = System.Windows.Forms.View.Details;
            this.lvwEntries.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwEntries_EnterKeyPressed);
            this.lvwEntries.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwEntries_DeleteKeyPressed);
            this.lvwEntries.SelectedIndexChanged += new System.EventHandler(this.lvwEntries_SelectedIndexChanged);
            this.lvwEntries.DoubleClick += new System.EventHandler(this.lvwEntries_DoubleClick);
            // 
            // entriesColumnHeader
            // 
            this.entriesColumnHeader.Text = "Entry";
            this.entriesColumnHeader.Width = 246;
            // 
            // triggerColumnHeader
            // 
            this.triggerColumnHeader.Text = "Alert triggers";
            this.triggerColumnHeader.Width = 215;
            // 
            // EditCollectorAgentEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 408);
            this.Controls.Add(this.llblRawEdit);
            this.Controls.Add(this.txtAgentType);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 360);
            this.Name = "EditCollectorAgentEntries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Collector Agent";
            this.Load += new System.EventHandler(this.EditEntriesInListView_Load);
            this.Shown += new System.EventHandler(this.EditEntriesInListView_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.collectorEditToolStrip.ResumeLayout(false);
            this.collectorEditToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private ListViewEx lvwEntries;
        private System.Windows.Forms.ColumnHeader entriesColumnHeader;
        private System.Windows.Forms.ColumnHeader triggerColumnHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip collectorEditToolStrip;
        private System.Windows.Forms.ToolStripButton addCollectorConfigEntryToolStripButton;
        private System.Windows.Forms.ToolStripButton editCollectorAgentEntryToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteCollectorAgentEntriesToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label15;
        private TreeViewEx tvwEntries;
        private System.Windows.Forms.TextBox txtAgentType;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.ImageList entriesImageList;
    }
}