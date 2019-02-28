namespace QuickMon.UI
{
    partial class TemplateEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addTemplateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deletePresetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.importToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwTemplates = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTypeFilter = new QuickMon.Controls.ComboBoxWithBorder();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfig = new FastColoredTextBoxNS.FastColoredTextBox();
            this.configEditContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.llblVariableTip = new System.Windows.Forms.LinkLabel();
            this.cmdFormat = new System.Windows.Forms.Button();
            this.cmdSaveTemplate = new System.Windows.Forms.Button();
            this.chkWrapText = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboClass = new QuickMon.Controls.ComboBoxWithBorder();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboType = new QuickMon.Controls.ComboBoxWithBorder();
            this.label2 = new System.Windows.Forms.Label();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfig)).BeginInit();
            this.configEditContextMenuStrip.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTemplateToolStripButton,
            this.deletePresetToolStripButton,
            this.toolStripSeparator1,
            this.resetToolStripButton,
            this.exportToolStripButton,
            this.importToolStripButton,
            this.toolStripSeparator2,
            this.saveToolStripButton,
            this.refreshToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(904, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = true;
            // 
            // addTemplateToolStripButton
            // 
            this.addTemplateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addTemplateToolStripButton.Image = global::QuickMon.Properties.Resources.doc_addnew;
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
            this.deletePresetToolStripButton.Image = global::QuickMon.Properties.Resources.doc_remove3;
            this.deletePresetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deletePresetToolStripButton.Name = "deletePresetToolStripButton";
            this.deletePresetToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.deletePresetToolStripButton.Text = "Delete selected templates";
            this.deletePresetToolStripButton.Click += new System.EventHandler(this.deletePresetToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
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
            // exportToolStripButton
            // 
            this.exportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToolStripButton.Image = global::QuickMon.Properties.Resources.doc_export;
            this.exportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToolStripButton.Name = "exportToolStripButton";
            this.exportToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.exportToolStripButton.Text = "Export";
            this.exportToolStripButton.Click += new System.EventHandler(this.exportToolStripButton_Click);
            // 
            // importToolStripButton
            // 
            this.importToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importToolStripButton.Image = global::QuickMon.Properties.Resources.pastewithedit;
            this.importToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importToolStripButton.Name = "importToolStripButton";
            this.importToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.importToolStripButton.Text = "Import";
            this.importToolStripButton.Click += new System.EventHandler(this.importToolStripButton_Click);
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
            this.refreshToolStripButton.Image = global::QuickMon.Properties.Resources.refresh24x24;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(904, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(889, 17);
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
            this.splitContainer1.Panel1.Controls.Add(this.lvwTemplates);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtConfig);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(904, 438);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 4;
            // 
            // lvwTemplates
            // 
            this.lvwTemplates.AutoResizeColumnEnabled = false;
            this.lvwTemplates.AutoResizeColumnIndex = 0;
            this.lvwTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.classColumnHeader,
            this.descriptionColumnHeader});
            this.lvwTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTemplates.FullRowSelect = true;
            this.lvwTemplates.Location = new System.Drawing.Point(0, 22);
            this.lvwTemplates.Name = "lvwTemplates";
            this.lvwTemplates.Size = new System.Drawing.Size(405, 416);
            this.lvwTemplates.TabIndex = 0;
            this.lvwTemplates.UseCompatibleStateImageBehavior = false;
            this.lvwTemplates.View = System.Windows.Forms.View.Details;
            this.lvwTemplates.SelectedIndexChanged += new System.EventHandler(this.lvwTemplates_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 139;
            // 
            // classColumnHeader
            // 
            this.classColumnHeader.Text = "Class";
            this.classColumnHeader.Width = 142;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 157;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboTypeFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 22);
            this.panel1.TabIndex = 2;
            // 
            // cboTypeFilter
            // 
            this.cboTypeFilter.BorderColor = System.Drawing.Color.Gray;
            this.cboTypeFilter.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cboTypeFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTypeFilter.FormattingEnabled = true;
            this.cboTypeFilter.Items.AddRange(new object[] {
            "Monitor Pack",
            "Collector Host",
            "Collector Agent",
            "Notifier Host",
            "Notifier Agent",
            "All"});
            this.cboTypeFilter.Location = new System.Drawing.Point(58, 0);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new System.Drawing.Size(347, 21);
            this.cboTypeFilter.TabIndex = 1;
            this.cboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cboTypeFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConfig
            // 
            this.txtConfig.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtConfig.AutoIndentCharsPatterns = "";
            this.txtConfig.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.txtConfig.BackBrush = null;
            this.txtConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfig.CharHeight = 14;
            this.txtConfig.CharWidth = 8;
            this.txtConfig.CommentPrefix = null;
            this.txtConfig.ContextMenuStrip = this.configEditContextMenuStrip;
            this.txtConfig.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfig.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfig.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtConfig.IsReplaceMode = false;
            this.txtConfig.Language = FastColoredTextBoxNS.Language.XML;
            this.txtConfig.LeftBracket = '<';
            this.txtConfig.LeftBracket2 = '(';
            this.txtConfig.Location = new System.Drawing.Point(0, 112);
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.Paddings = new System.Windows.Forms.Padding(0);
            this.txtConfig.RightBracket = '>';
            this.txtConfig.RightBracket2 = ')';
            this.txtConfig.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtConfig.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtConfig.ServiceColors")));
            this.txtConfig.Size = new System.Drawing.Size(495, 290);
            this.txtConfig.TabIndex = 3;
            this.txtConfig.WordWrap = true;
            this.txtConfig.Zoom = 100;
            this.txtConfig.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtConfig_TextChanged);
            // 
            // configEditContextMenuStrip
            // 
            this.configEditContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.formatToolStripMenuItem});
            this.configEditContextMenuStrip.Name = "configEditContextMenuStrip";
            this.configEditContextMenuStrip.Size = new System.Drawing.Size(123, 92);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.formatToolStripMenuItem.Text = "Format";
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.llblVariableTip);
            this.panel3.Controls.Add(this.cmdFormat);
            this.panel3.Controls.Add(this.cmdSaveTemplate);
            this.panel3.Controls.Add(this.chkWrapText);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 402);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 36);
            this.panel3.TabIndex = 2;
            // 
            // llblVariableTip
            // 
            this.llblVariableTip.AutoSize = true;
            this.llblVariableTip.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblVariableTip.Location = new System.Drawing.Point(86, 11);
            this.llblVariableTip.Name = "llblVariableTip";
            this.llblVariableTip.Size = new System.Drawing.Size(64, 13);
            this.llblVariableTip.TabIndex = 3;
            this.llblVariableTip.TabStop = true;
            this.llblVariableTip.Text = "Variables tip";
            this.llblVariableTip.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblVariableTip_LinkClicked);
            // 
            // cmdFormat
            // 
            this.cmdFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFormat.Image = global::QuickMon.Properties.Resources.calculator;
            this.cmdFormat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFormat.Location = new System.Drawing.Point(344, 6);
            this.cmdFormat.Name = "cmdFormat";
            this.cmdFormat.Size = new System.Drawing.Size(70, 23);
            this.cmdFormat.TabIndex = 1;
            this.cmdFormat.Text = "Format";
            this.cmdFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFormat.UseVisualStyleBackColor = true;
            this.cmdFormat.Click += new System.EventHandler(this.cmdFormat_Click);
            // 
            // cmdSaveTemplate
            // 
            this.cmdSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaveTemplate.Image = global::QuickMon.Properties.Resources.save16x16;
            this.cmdSaveTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveTemplate.Location = new System.Drawing.Point(420, 6);
            this.cmdSaveTemplate.Name = "cmdSaveTemplate";
            this.cmdSaveTemplate.Size = new System.Drawing.Size(63, 23);
            this.cmdSaveTemplate.TabIndex = 2;
            this.cmdSaveTemplate.Text = "Save";
            this.cmdSaveTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSaveTemplate.UseVisualStyleBackColor = true;
            this.cmdSaveTemplate.Click += new System.EventHandler(this.cmdSaveTemplate_Click);
            // 
            // chkWrapText
            // 
            this.chkWrapText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWrapText.AutoSize = true;
            this.chkWrapText.Checked = true;
            this.chkWrapText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWrapText.Location = new System.Drawing.Point(6, 10);
            this.chkWrapText.Name = "chkWrapText";
            this.chkWrapText.Size = new System.Drawing.Size(72, 17);
            this.chkWrapText.TabIndex = 0;
            this.chkWrapText.Text = "Wrap text";
            this.chkWrapText.UseVisualStyleBackColor = true;
            this.chkWrapText.CheckedChanged += new System.EventHandler(this.chkWrapText_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboClass);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboType);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 112);
            this.panel2.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(89, 83);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(403, 20);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Description";
            // 
            // cboClass
            // 
            this.cboClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboClass.BorderColor = System.Drawing.Color.Gray;
            this.cboClass.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(89, 56);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(403, 21);
            this.cboClass.TabIndex = 5;
            this.cboClass.SelectedIndexChanged += new System.EventHandler(this.cboClass_SelectedIndexChanged);
            this.cboClass.TextChanged += new System.EventHandler(this.cboClass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "For class";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(89, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(403, 20);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Template name";
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.BorderColor = System.Drawing.Color.Gray;
            this.cboType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Monitor Pack",
            "Collector Host",
            "Collector Agent",
            "Notifier Host",
            "Notifier Agent"});
            this.cboType.Location = new System.Drawing.Point(89, 3);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(403, 21);
            this.cboType.TabIndex = 1;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Template type";
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.DefaultExt = "qmtemplate";
            this.exportFileDialog.FileName = "QuickMon5Templates.qmtemplate";
            this.exportFileDialog.Filter = "QuickMon Template Files|*.qmtemplate";
            this.exportFileDialog.Title = "Export templates";
            // 
            // importFileDialog
            // 
            this.importFileDialog.DefaultExt = "qmtemplate";
            this.importFileDialog.FileName = "QuickMon5Templates.qmtemplate";
            this.importFileDialog.Filter = "QuickMon Template Files|*.qmtemplate";
            this.importFileDialog.Title = "Import templates";
            // 
            // TemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(904, 491);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "TemplateEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Templates Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateEditor_FormClosing);
            this.Load += new System.EventHandler(this.TemplateEditor_Load);
            this.Shown += new System.EventHandler(this.TemplateEditor_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtConfig)).EndInit();
            this.configEditContextMenuStrip.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addTemplateToolStripButton;
        private System.Windows.Forms.ToolStripButton deletePresetToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton resetToolStripButton;
        private System.Windows.Forms.ToolStripButton exportToolStripButton;
        private System.Windows.Forms.ToolStripButton importToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ListViewEx lvwTemplates;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader classColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.Panel panel1;
        private Controls.ComboBoxWithBorder cboTypeFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cmdFormat;
        private System.Windows.Forms.Button cmdSaveTemplate;
        private System.Windows.Forms.CheckBox chkWrapText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private Controls.ComboBoxWithBorder cboClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private Controls.ComboBoxWithBorder cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private FastColoredTextBoxNS.FastColoredTextBox txtConfig;
        private System.Windows.Forms.ContextMenuStrip configEditContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.LinkLabel llblVariableTip;
    }
}