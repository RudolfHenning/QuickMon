namespace QuickMon5
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("COLLECTORS ");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.saveContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.agentsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSlimMenu = new System.Windows.Forms.Panel();
            this.splitButtonInfo = new QuickMon5.Controls.SplitButton.SplitButton();
            this.splitButtonTools = new QuickMon5.Controls.SplitButton.SplitButton();
            this.splitButtonAgents = new QuickMon5.Controls.SplitButton.SplitButton();
            this.splitButtonSave = new QuickMon5.Controls.SplitButton.SplitButton();
            this.splitButtonOpen = new QuickMon5.Controls.SplitButton.SplitButton();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveContextMenuStrip.SuspendLayout();
            this.openContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.agentsContextMenuStrip.SuspendLayout();
            this.panelSlimMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Location = new System.Drawing.Point(0, 355);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(432, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "folder-24.png");
            this.imageListTreeView.Images.SetKeyName(1, "folder_32a.png");
            // 
            // saveContextMenuStrip
            // 
            this.saveContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.saveContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem1});
            this.saveContextMenuStrip.Name = "saveContextMenuStrip";
            this.saveContextMenuStrip.Size = new System.Drawing.Size(123, 34);
            // 
            // openContextMenuStrip
            // 
            this.openContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.openContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.openContextMenuStrip.Name = "saveContextMenuStrip";
            this.openContextMenuStrip.Size = new System.Drawing.Size(198, 34);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(45, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 40);
            this.panel1.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(317, 40);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "<New Monitor Pack>";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageListTreeView;
            this.treeView1.Location = new System.Drawing.Point(45, 40);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "COLLECTORS ";
            treeNode1.ToolTipText = "COLLECTORS";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(387, 315);
            this.treeView1.TabIndex = 4;
            // 
            // agentsContextMenuStrip
            // 
            this.agentsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.agentsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectorsToolStripMenuItem,
            this.notifiersToolStripMenuItem});
            this.agentsContextMenuStrip.Name = "saveContextMenuStrip";
            this.agentsContextMenuStrip.Size = new System.Drawing.Size(128, 48);
            // 
            // collectorsToolStripMenuItem
            // 
            this.collectorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorToolStripMenuItem,
            this.editCollectorToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.collectorsToolStripMenuItem.Name = "collectorsToolStripMenuItem";
            this.collectorsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.collectorsToolStripMenuItem.Text = "Collectors";
            // 
            // notifiersToolStripMenuItem
            // 
            this.notifiersToolStripMenuItem.Name = "notifiersToolStripMenuItem";
            this.notifiersToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.notifiersToolStripMenuItem.Text = "Notifiers";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::QuickMon5.Properties.Resources.refresh24x24;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(317, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 40);
            this.button3.TabIndex = 3;
            this.toolTip1.SetToolTip(this.button3, "Refresh current Monitor Pack");
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::QuickMon5.Properties.Resources.folderWLightning16x16;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(352, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 40);
            this.button2.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button2, "Recent Monitor Packs");
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panelSlimMenu
            // 
            this.panelSlimMenu.BackgroundImage = global::QuickMon5.Properties.Resources.QuickMon5Background2;
            this.panelSlimMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSlimMenu.Controls.Add(this.splitButtonInfo);
            this.panelSlimMenu.Controls.Add(this.splitButtonTools);
            this.panelSlimMenu.Controls.Add(this.splitButtonAgents);
            this.panelSlimMenu.Controls.Add(this.splitButtonSave);
            this.panelSlimMenu.Controls.Add(this.splitButtonOpen);
            this.panelSlimMenu.Controls.Add(this.cmdNew);
            this.panelSlimMenu.Controls.Add(this.cmdMenu);
            this.panelSlimMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlimMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSlimMenu.Name = "panelSlimMenu";
            this.panelSlimMenu.Size = new System.Drawing.Size(45, 355);
            this.panelSlimMenu.TabIndex = 2;
            // 
            // splitButtonInfo
            // 
            this.splitButtonInfo.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonInfo.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonInfo.ButtonImage = global::QuickMon5.Properties.Resources.info24x24;
            this.splitButtonInfo.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonInfo.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonInfo.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonInfo.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonInfo.ButtonText = "";
            this.splitButtonInfo.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonInfo.ButtonToolTip = "Open existing monitor pack (CTRL + O)";
            this.splitButtonInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonInfo.Location = new System.Drawing.Point(0, 187);
            this.splitButtonInfo.Name = "splitButtonInfo";
            this.splitButtonInfo.Size = new System.Drawing.Size(45, 31);
            this.splitButtonInfo.TabIndex = 6;
            // 
            // splitButtonTools
            // 
            this.splitButtonTools.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonTools.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonTools.ButtonImage = global::QuickMon5.Properties.Resources.tools24x24;
            this.splitButtonTools.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonTools.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonTools.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonTools.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonTools.ButtonText = "";
            this.splitButtonTools.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonTools.ButtonToolTip = "Open existing monitor pack (CTRL + O)";
            this.splitButtonTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonTools.Location = new System.Drawing.Point(0, 156);
            this.splitButtonTools.Name = "splitButtonTools";
            this.splitButtonTools.Size = new System.Drawing.Size(45, 31);
            this.splitButtonTools.TabIndex = 5;
            // 
            // splitButtonAgents
            // 
            this.splitButtonAgents.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonAgents.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonAgents.ButtonImage = global::QuickMon5.Properties.Resources.cubes24x24;
            this.splitButtonAgents.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonAgents.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonAgents.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonAgents.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonAgents.ButtonText = "";
            this.splitButtonAgents.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonAgents.ButtonToolTip = "Open existing monitor pack (CTRL + O)";
            this.splitButtonAgents.ContextMenuStrip = this.agentsContextMenuStrip;
            this.splitButtonAgents.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonAgents.Location = new System.Drawing.Point(0, 125);
            this.splitButtonAgents.Name = "splitButtonAgents";
            this.splitButtonAgents.Size = new System.Drawing.Size(45, 31);
            this.splitButtonAgents.TabIndex = 4;
            this.splitButtonAgents.SplitButtonClicked += new System.EventHandler(this.splitButtonAgents_SplitButtonClicked);
            // 
            // splitButtonSave
            // 
            this.splitButtonSave.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonSave.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonSave.ButtonImage = global::QuickMon5.Properties.Resources.save24x24;
            this.splitButtonSave.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonSave.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonSave.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonSave.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonSave.ButtonText = "";
            this.splitButtonSave.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonSave.ButtonToolTip = "Open existing monitor pack (CTRL + O)";
            this.splitButtonSave.ContextMenuStrip = this.saveContextMenuStrip;
            this.splitButtonSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonSave.Location = new System.Drawing.Point(0, 94);
            this.splitButtonSave.Name = "splitButtonSave";
            this.splitButtonSave.Size = new System.Drawing.Size(45, 31);
            this.splitButtonSave.TabIndex = 3;
            this.splitButtonSave.SplitButtonClicked += new System.EventHandler(this.splitButtonSave_SplitButtonClicked);
            // 
            // splitButtonOpen
            // 
            this.splitButtonOpen.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonOpen.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonOpen.ButtonImage = global::QuickMon5.Properties.Resources.folderOpen24x24;
            this.splitButtonOpen.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonOpen.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonOpen.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonOpen.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonOpen.ButtonText = "";
            this.splitButtonOpen.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonOpen.ButtonToolTip = "Open existing monitor pack (CTRL + O)";
            this.splitButtonOpen.ContextMenuStrip = this.openContextMenuStrip;
            this.splitButtonOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonOpen.Location = new System.Drawing.Point(0, 63);
            this.splitButtonOpen.Name = "splitButtonOpen";
            this.splitButtonOpen.Size = new System.Drawing.Size(45, 31);
            this.splitButtonOpen.TabIndex = 2;
            this.splitButtonOpen.ButtonClicked += new System.EventHandler(this.splitButtonOpen_ButtonClicked);
            this.splitButtonOpen.SplitButtonClicked += new System.EventHandler(this.splitButtonOpen_SplitButtonClicked);
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.Color.Transparent;
            this.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdNew.FlatAppearance.BorderSize = 0;
            this.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Image = global::QuickMon5.Properties.Resources.doc_new1;
            this.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNew.Location = new System.Drawing.Point(0, 33);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(45, 30);
            this.cmdNew.TabIndex = 1;
            this.cmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNew.UseVisualStyleBackColor = false;
            // 
            // cmdMenu
            // 
            this.cmdMenu.BackColor = System.Drawing.Color.Transparent;
            this.cmdMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdMenu.FlatAppearance.BorderSize = 0;
            this.cmdMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMenu.Image = global::QuickMon5.Properties.Resources.menu_alt_16b1;
            this.cmdMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMenu.Location = new System.Drawing.Point(0, 0);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cmdMenu.Size = new System.Drawing.Size(45, 33);
            this.cmdMenu.TabIndex = 0;
            this.cmdMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdMenu, "Menu (CTRL + M)");
            this.cmdMenu.UseVisualStyleBackColor = false;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Image = global::QuickMon5.Properties.Resources.SaveAs24x24;
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(122, 30);
            this.saveAsToolStripMenuItem1.Text = "Save As";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::QuickMon5.Properties.Resources.folderWLightning1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 30);
            this.toolStripMenuItem1.Text = "Recent Monitor Packs";
            // 
            // addCollectorToolStripMenuItem
            // 
            this.addCollectorToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.add;
            this.addCollectorToolStripMenuItem.Name = "addCollectorToolStripMenuItem";
            this.addCollectorToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.addCollectorToolStripMenuItem.Text = "Add";
            // 
            // editCollectorToolStripMenuItem
            // 
            this.editCollectorToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.doc_edit24x24;
            this.editCollectorToolStripMenuItem.Name = "editCollectorToolStripMenuItem";
            this.editCollectorToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.editCollectorToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.stop24x24;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.comp_search24;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(160, 30);
            this.detailsToolStripMenuItem.Text = "Details";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 377);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSlimMenu);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "QuickMon 5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.saveContextMenuStrip.ResumeLayout(false);
            this.openContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.agentsContextMenuStrip.ResumeLayout(false);
            this.panelSlimMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.Panel panelSlimMenu;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdMenu;
        private Controls.SplitButton.SplitButton splitButtonOpen;
        private Controls.SplitButton.SplitButton splitButtonInfo;
        private Controls.SplitButton.SplitButton splitButtonTools;
        private Controls.SplitButton.SplitButton splitButtonSave;
        private System.Windows.Forms.ContextMenuStrip saveContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem1;
        private Controls.SplitButton.SplitButton splitButtonAgents;
        private System.Windows.Forms.ContextMenuStrip openContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip agentsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem collectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
    }
}

