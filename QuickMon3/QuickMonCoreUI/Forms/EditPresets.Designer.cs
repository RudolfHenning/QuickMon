namespace QuickMon.Forms
{
    partial class EditPresets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPresets));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addTemplateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deletePresetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.resetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkWrapText = new System.Windows.Forms.CheckBox();
            this.cmdSaveTemplate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfig = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAgentType = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.saveTemplateFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.listViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportSelectedTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwPresets = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.listViewContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTemplateToolStripButton,
            this.deletePresetToolStripButton,
            this.exportToolStripButton,
            this.toolStripSeparator1,
            this.importToolStripButton,
            this.resetToolStripButton,
            this.toolStripSeparator2,
            this.saveToolStripButton,
            this.refreshToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(683, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.TabStop = true;
            // 
            // addTemplateToolStripButton
            // 
            this.addTemplateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addTemplateToolStripButton.Image = global::QuickMon.Properties.Resources.doc_add;
            this.addTemplateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addTemplateToolStripButton.Name = "addTemplateToolStripButton";
            this.addTemplateToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.addTemplateToolStripButton.Text = "Add new template";
            this.addTemplateToolStripButton.Click += new System.EventHandler(this.addTemplateToolStripButton_Click);
            // 
            // deletePresetToolStripButton
            // 
            this.deletePresetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deletePresetToolStripButton.Enabled = false;
            this.deletePresetToolStripButton.Image = global::QuickMon.Properties.Resources.doc_remove;
            this.deletePresetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deletePresetToolStripButton.Name = "deletePresetToolStripButton";
            this.deletePresetToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.deletePresetToolStripButton.Text = "Delete selected templates";
            this.deletePresetToolStripButton.Click += new System.EventHandler(this.deletePresetToolStripButton_Click);
            // 
            // exportToolStripButton
            // 
            this.exportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToolStripButton.Enabled = false;
            this.exportToolStripButton.Image = global::QuickMon.Properties.Resources.doc_export;
            this.exportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToolStripButton.Name = "exportToolStripButton";
            this.exportToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.exportToolStripButton.Text = "Export selected templates";
            this.exportToolStripButton.Click += new System.EventHandler(this.exportToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // importToolStripButton
            // 
            this.importToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importToolStripButton.Image = global::QuickMon.Properties.Resources.folder_add;
            this.importToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importToolStripButton.Name = "importToolStripButton";
            this.importToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.importToolStripButton.Text = "Import templates from File";
            this.importToolStripButton.Click += new System.EventHandler(this.importToolStripButton_Click);
            // 
            // resetToolStripButton
            // 
            this.resetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetToolStripButton.Image = global::QuickMon.Properties.Resources.undo;
            this.resetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetToolStripButton.Name = "resetToolStripButton";
            this.resetToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.resetToolStripButton.Text = "Reset all templates";
            this.resetToolStripButton.Click += new System.EventHandler(this.resetToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::QuickMon.Properties.Resources.save;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.saveToolStripButton.Text = "Save templates";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::QuickMon.Properties.Resources.doc_refresh;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.refreshToolStripButton.Text = "Reload all templates";
            this.refreshToolStripButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 447);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(668, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwPresets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkWrapText);
            this.splitContainer1.Panel2.Controls.Add(this.cmdSaveTemplate);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtConfig);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.cboAgentType);
            this.splitContainer1.Panel2.Controls.Add(this.txtDescription);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(683, 416);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "58.ico");
            this.imageList1.Images.SetKeyName(1, "59.ico");
            this.imageList1.Images.SetKeyName(2, "5_50.ico");
            // 
            // chkWrapText
            // 
            this.chkWrapText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWrapText.AutoSize = true;
            this.chkWrapText.Checked = true;
            this.chkWrapText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWrapText.Location = new System.Drawing.Point(6, 391);
            this.chkWrapText.Name = "chkWrapText";
            this.chkWrapText.Size = new System.Drawing.Size(72, 17);
            this.chkWrapText.TabIndex = 6;
            this.chkWrapText.Text = "Wrap text";
            this.chkWrapText.UseVisualStyleBackColor = true;
            this.chkWrapText.CheckedChanged += new System.EventHandler(this.chkWrapText_CheckedChanged);
            // 
            // cmdSaveTemplate
            // 
            this.cmdSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveTemplate.Location = new System.Drawing.Point(278, 387);
            this.cmdSaveTemplate.Name = "cmdSaveTemplate";
            this.cmdSaveTemplate.Size = new System.Drawing.Size(75, 23);
            this.cmdSaveTemplate.TabIndex = 7;
            this.cmdSaveTemplate.Text = "Save";
            this.cmdSaveTemplate.UseVisualStyleBackColor = true;
            this.cmdSaveTemplate.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Config";
            // 
            // txtConfig
            // 
            this.txtConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfig.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.txtConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfig.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfig.Language = FastColoredTextBoxNS.Language.HTML;
            this.txtConfig.Location = new System.Drawing.Point(6, 78);
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.PreferredLineWidth = 0;
            this.txtConfig.Size = new System.Drawing.Size(356, 303);
            this.txtConfig.TabIndex = 5;
            this.txtConfig.WordWrap = true;
            this.txtConfig.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtConfig_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Agent type";
            // 
            // cboAgentType
            // 
            this.cboAgentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAgentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgentType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAgentType.FormattingEnabled = true;
            this.cboAgentType.Location = new System.Drawing.Point(108, 8);
            this.cboAgentType.Name = "cboAgentType";
            this.cboAgentType.Size = new System.Drawing.Size(245, 21);
            this.cboAgentType.TabIndex = 1;
            this.cboAgentType.SelectedIndexChanged += new System.EventHandler(this.cboAgentType_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(108, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(245, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description";
            // 
            // openFileDialogOpen
            // 
            this.openFileDialogOpen.DefaultExt = "qps";
            this.openFileDialogOpen.Filter = "QuickMon Template files|*.qps";
            // 
            // saveTemplateFileDialog
            // 
            this.saveTemplateFileDialog.DefaultExt = "qps";
            this.saveTemplateFileDialog.Filter = "QuickMon Template files|*.qps";
            // 
            // listViewContextMenuStrip
            // 
            this.listViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTemplateToolStripMenuItem,
            this.deleteTemplateToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportSelectedTemplatesToolStripMenuItem,
            this.saveTemplatesToolStripMenuItem,
            this.refreshTemplatesToolStripMenuItem});
            this.listViewContextMenuStrip.Name = "listViewContextMenuStrip";
            this.listViewContextMenuStrip.Size = new System.Drawing.Size(158, 120);
            // 
            // addTemplateToolStripMenuItem
            // 
            this.addTemplateToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_add;
            this.addTemplateToolStripMenuItem.Name = "addTemplateToolStripMenuItem";
            this.addTemplateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addTemplateToolStripMenuItem.Text = "Add template";
            this.addTemplateToolStripMenuItem.Click += new System.EventHandler(this.addTemplateToolStripButton_Click);
            // 
            // deleteTemplateToolStripMenuItem
            // 
            this.deleteTemplateToolStripMenuItem.Enabled = false;
            this.deleteTemplateToolStripMenuItem.Image = global::QuickMon.Properties.Resources.whack;
            this.deleteTemplateToolStripMenuItem.Name = "deleteTemplateToolStripMenuItem";
            this.deleteTemplateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteTemplateToolStripMenuItem.Text = "Delete template";
            this.deleteTemplateToolStripMenuItem.Click += new System.EventHandler(this.deletePresetToolStripButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
            // 
            // exportSelectedTemplatesToolStripMenuItem
            // 
            this.exportSelectedTemplatesToolStripMenuItem.Enabled = false;
            this.exportSelectedTemplatesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_export;
            this.exportSelectedTemplatesToolStripMenuItem.Name = "exportSelectedTemplatesToolStripMenuItem";
            this.exportSelectedTemplatesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exportSelectedTemplatesToolStripMenuItem.Text = "Export";
            this.exportSelectedTemplatesToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripButton_Click);
            // 
            // saveTemplatesToolStripMenuItem
            // 
            this.saveTemplatesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.save;
            this.saveTemplatesToolStripMenuItem.Name = "saveTemplatesToolStripMenuItem";
            this.saveTemplatesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveTemplatesToolStripMenuItem.Text = "Save";
            this.saveTemplatesToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // refreshTemplatesToolStripMenuItem
            // 
            this.refreshTemplatesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.refresh;
            this.refreshTemplatesToolStripMenuItem.Name = "refreshTemplatesToolStripMenuItem";
            this.refreshTemplatesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshTemplatesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.refreshTemplatesToolStripMenuItem.Text = "Refresh";
            this.refreshTemplatesToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // lvwPresets
            // 
            this.lvwPresets.AutoResizeColumnEnabled = false;
            this.lvwPresets.AutoResizeColumnIndex = 0;
            this.lvwPresets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader});
            this.lvwPresets.ContextMenuStrip = this.listViewContextMenuStrip;
            this.lvwPresets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPresets.Location = new System.Drawing.Point(0, 0);
            this.lvwPresets.Name = "lvwPresets";
            this.lvwPresets.Size = new System.Drawing.Size(314, 416);
            this.lvwPresets.SmallImageList = this.imageList1;
            this.lvwPresets.TabIndex = 0;
            this.lvwPresets.UseCompatibleStateImageBehavior = false;
            this.lvwPresets.View = System.Windows.Forms.View.Details;
            this.lvwPresets.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwPresets_DeleteKeyPressed);
            this.lvwPresets.SelectedIndexChanged += new System.EventHandler(this.lvwPresets_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Description";
            this.nameColumnHeader.Width = 277;
            // 
            // EditPresets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 469);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditPresets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Templates";
            this.Load += new System.EventHandler(this.EditPresets_Load);
            this.Shown += new System.EventHandler(this.EditPresets_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.listViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addTemplateToolStripButton;
        private System.Windows.Forms.ToolStripButton deletePresetToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton importToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ListViewEx lvwPresets;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAgentType;
        private System.Windows.Forms.Label label4;
        private FastColoredTextBoxNS.FastColoredTextBox txtConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton resetToolStripButton;
        private System.Windows.Forms.Button cmdSaveTemplate;
        private System.Windows.Forms.CheckBox chkWrapText;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpen;
        private System.Windows.Forms.ToolStripButton exportToolStripButton;
        private System.Windows.Forms.SaveFileDialog saveTemplateFileDialog;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshTemplatesToolStripMenuItem;
    }
}