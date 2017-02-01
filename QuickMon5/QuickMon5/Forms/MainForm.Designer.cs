using HenIT.Windows.Controls;
using QuickMon;
using QuickMon.Controls;

namespace QuickMon
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Health", 3, 3);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Ping localhost", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Health", 4, 4);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Ping server", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Memory agent");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("NOTIFIERS", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.saveContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.agentsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remoteHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panelSlimMenu = new System.Windows.Forms.Panel();
            this.masterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.llblNotifierViewToggle = new System.Windows.Forms.LinkLabel();
            this.imagesNotifiersTree = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new QuickMon.Controls.TreeViewExBase();
            this.lblCollectors = new HenIT.Windows.Controls.HiLightLabel();
            this.lblVersion = new HenIT.Windows.Controls.HiLightLabel();
            this.tvwNotifiers = new QuickMon.Controls.TreeViewExBase();
            this.lblNotifiers = new HenIT.Windows.Controls.HiLightLabel();
            this.splitButtonInfo = new QuickMon.Controls.SplitButton.SplitButton();
            this.splitButtonTools = new QuickMon.Controls.SplitButton.SplitButton();
            this.splitButtonAgents = new QuickMon.Controls.SplitButton.SplitButton();
            this.splitButtonSave = new QuickMon.Controls.SplitButton.SplitButton();
            this.saveContextMenuStrip.SuspendLayout();
            this.openContextMenuStrip.SuspendLayout();
            this.agentsContextMenuStrip.SuspendLayout();
            this.settingsContextMenuStrip.SuspendLayout();
            this.aboutContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSlimMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).BeginInit();
            this.masterSplitContainer.Panel1.SuspendLayout();
            this.masterSplitContainer.Panel2.SuspendLayout();
            this.masterSplitContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(472, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imagesCollectorTree
            // 
            this.imagesCollectorTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesCollectorTree.ImageStream")));
            this.imagesCollectorTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesCollectorTree.Images.SetKeyName(0, "open_folder_blue24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(1, "folder-24.png");
            this.imagesCollectorTree.Images.SetKeyName(2, "helpbwy24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(3, "ok.png");
            this.imagesCollectorTree.Images.SetKeyName(4, "triang_yellow.png");
            this.imagesCollectorTree.Images.SetKeyName(5, "Error24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(6, "ok3.png");
            this.imagesCollectorTree.Images.SetKeyName(7, "triang_yellow2.png");
            this.imagesCollectorTree.Images.SetKeyName(8, "Error2_24x24.png");
            // 
            // saveContextMenuStrip
            // 
            this.saveContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.saveContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem1});
            this.saveContextMenuStrip.Name = "saveContextMenuStrip";
            this.saveContextMenuStrip.Size = new System.Drawing.Size(123, 34);
            // 
            // saveAsToolStripMenuItem1
            // 
            this.saveAsToolStripMenuItem1.Image = global::QuickMon.Properties.Resources.SaveAs24x24;
            this.saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            this.saveAsToolStripMenuItem1.Size = new System.Drawing.Size(122, 30);
            this.saveAsToolStripMenuItem1.Text = "Save As";
            // 
            // openContextMenuStrip
            // 
            this.openContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.openContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.openContextMenuStrip.Name = "saveContextMenuStrip";
            this.openContextMenuStrip.Size = new System.Drawing.Size(239, 34);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::QuickMon.Properties.Resources.folderWLightning1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(238, 30);
            this.toolStripMenuItem1.Text = "Recent Monitor Packs";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(357, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 38);
            this.button3.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button3, "Refresh current Monitor Pack");
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::QuickMon.Properties.Resources.folderWLightning16x16;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(392, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 38);
            this.button2.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button2, "Recent Monitor Packs");
            this.button2.UseVisualStyleBackColor = false;
            // 
            // cmdOpen
            // 
            this.cmdOpen.BackColor = System.Drawing.Color.Transparent;
            this.cmdOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdOpen.FlatAppearance.BorderSize = 0;
            this.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpen.Image = global::QuickMon.Properties.Resources.folderOpen24x24;
            this.cmdOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOpen.Location = new System.Drawing.Point(0, 63);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(45, 30);
            this.cmdOpen.TabIndex = 2;
            this.cmdOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdOpen, "New  CTRL+O");
            this.cmdOpen.UseVisualStyleBackColor = false;
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.Color.Transparent;
            this.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdNew.FlatAppearance.BorderSize = 0;
            this.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Image = global::QuickMon.Properties.Resources.doc_new1;
            this.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNew.Location = new System.Drawing.Point(0, 33);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(45, 30);
            this.cmdNew.TabIndex = 1;
            this.cmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdNew, "New  CTRL+N");
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
            this.cmdMenu.Image = global::QuickMon.Properties.Resources.menu_alt_16b1;
            this.cmdMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMenu.Location = new System.Drawing.Point(0, 0);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cmdMenu.Size = new System.Drawing.Size(45, 33);
            this.cmdMenu.TabIndex = 0;
            this.cmdMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdMenu, "Menu  CTRL+M");
            this.cmdMenu.UseVisualStyleBackColor = false;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
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
            // addCollectorToolStripMenuItem
            // 
            this.addCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addCollectorToolStripMenuItem.Name = "addCollectorToolStripMenuItem";
            this.addCollectorToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.addCollectorToolStripMenuItem.Text = "Add";
            // 
            // editCollectorToolStripMenuItem
            // 
            this.editCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.editCollectorToolStripMenuItem.Name = "editCollectorToolStripMenuItem";
            this.editCollectorToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.editCollectorToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search24;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            // 
            // notifiersToolStripMenuItem
            // 
            this.notifiersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNotifierToolStripMenuItem,
            this.editNotifierToolStripMenuItem,
            this.deleteNotifierToolStripMenuItem,
            this.detailsNotifierToolStripMenuItem});
            this.notifiersToolStripMenuItem.Name = "notifiersToolStripMenuItem";
            this.notifiersToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.notifiersToolStripMenuItem.Text = "Notifiers";
            // 
            // addNotifierToolStripMenuItem
            // 
            this.addNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addNotifierToolStripMenuItem.Name = "addNotifierToolStripMenuItem";
            this.addNotifierToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.addNotifierToolStripMenuItem.Text = "Add";
            // 
            // editNotifierToolStripMenuItem
            // 
            this.editNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.editNotifierToolStripMenuItem.Name = "editNotifierToolStripMenuItem";
            this.editNotifierToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.editNotifierToolStripMenuItem.Text = "Edit";
            // 
            // deleteNotifierToolStripMenuItem
            // 
            this.deleteNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.deleteNotifierToolStripMenuItem.Name = "deleteNotifierToolStripMenuItem";
            this.deleteNotifierToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.deleteNotifierToolStripMenuItem.Text = "Delete";
            // 
            // detailsNotifierToolStripMenuItem
            // 
            this.detailsNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search24;
            this.detailsNotifierToolStripMenuItem.Name = "detailsNotifierToolStripMenuItem";
            this.detailsNotifierToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.detailsNotifierToolStripMenuItem.Text = "Details";
            // 
            // settingsContextMenuStrip
            // 
            this.settingsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.settingsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingToolStripMenuItem,
            this.templatesToolStripMenuItem,
            this.adminModeToolStripMenuItem});
            this.settingsContextMenuStrip.Name = "saveContextMenuStrip";
            this.settingsContextMenuStrip.Size = new System.Drawing.Size(153, 94);
            // 
            // pollingToolStripMenuItem
            // 
            this.pollingToolStripMenuItem.Image = global::QuickMon.Properties.Resources.clock24x24;
            this.pollingToolStripMenuItem.Name = "pollingToolStripMenuItem";
            this.pollingToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.pollingToolStripMenuItem.Text = "Polling";
            // 
            // templatesToolStripMenuItem
            // 
            this.templatesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.tables24x24;
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            this.templatesToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.templatesToolStripMenuItem.Text = "Templates";
            // 
            // adminModeToolStripMenuItem
            // 
            this.adminModeToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Shield24x24;
            this.adminModeToolStripMenuItem.Name = "adminModeToolStripMenuItem";
            this.adminModeToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.adminModeToolStripMenuItem.Text = "Admin mode";
            // 
            // aboutContextMenuStrip
            // 
            this.aboutContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.aboutContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteHostsToolStripMenuItem});
            this.aboutContextMenuStrip.Name = "saveContextMenuStrip";
            this.aboutContextMenuStrip.Size = new System.Drawing.Size(200, 34);
            // 
            // remoteHostsToolStripMenuItem
            // 
            this.remoteHostsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_web24x24;
            this.remoteHostsToolStripMenuItem.Name = "remoteHostsToolStripMenuItem";
            this.remoteHostsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.remoteHostsToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.remoteHostsToolStripMenuItem.Text = "Remote Hosts";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuickMon.Properties.Resources.QuickMon5Background3;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(45, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 38);
            this.panel1.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(357, 38);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "<New Monitor Pack>";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSlimMenu
            // 
            this.panelSlimMenu.BackgroundImage = global::QuickMon.Properties.Resources.QuickMon5Background2;
            this.panelSlimMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSlimMenu.Controls.Add(this.splitButtonInfo);
            this.panelSlimMenu.Controls.Add(this.splitButtonTools);
            this.panelSlimMenu.Controls.Add(this.splitButtonAgents);
            this.panelSlimMenu.Controls.Add(this.splitButtonSave);
            this.panelSlimMenu.Controls.Add(this.cmdOpen);
            this.panelSlimMenu.Controls.Add(this.cmdNew);
            this.panelSlimMenu.Controls.Add(this.cmdMenu);
            this.panelSlimMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlimMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSlimMenu.Name = "panelSlimMenu";
            this.panelSlimMenu.Size = new System.Drawing.Size(45, 481);
            this.panelSlimMenu.TabIndex = 2;
            // 
            // masterSplitContainer
            // 
            this.masterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterSplitContainer.Location = new System.Drawing.Point(45, 38);
            this.masterSplitContainer.Name = "masterSplitContainer";
            this.masterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // masterSplitContainer.Panel1
            // 
            this.masterSplitContainer.Panel1.Controls.Add(this.treeView1);
            this.masterSplitContainer.Panel1.Controls.Add(this.panel2);
            this.masterSplitContainer.Panel1.Controls.Add(this.llblNotifierViewToggle);
            // 
            // masterSplitContainer.Panel2
            // 
            this.masterSplitContainer.Panel2.Controls.Add(this.tvwNotifiers);
            this.masterSplitContainer.Panel2.Controls.Add(this.lblNotifiers);
            this.masterSplitContainer.Size = new System.Drawing.Size(427, 443);
            this.masterSplitContainer.SplitterDistance = 275;
            this.masterSplitContainer.SplitterWidth = 6;
            this.masterSplitContainer.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCollectors);
            this.panel2.Controls.Add(this.lblVersion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 23);
            this.panel2.TabIndex = 42;
            // 
            // llblNotifierViewToggle
            // 
            this.llblNotifierViewToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.llblNotifierViewToggle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llblNotifierViewToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNotifierViewToggle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.llblNotifierViewToggle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblNotifierViewToggle.Location = new System.Drawing.Point(0, 255);
            this.llblNotifierViewToggle.Name = "llblNotifierViewToggle";
            this.llblNotifierViewToggle.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.llblNotifierViewToggle.Size = new System.Drawing.Size(427, 20);
            this.llblNotifierViewToggle.TabIndex = 40;
            this.llblNotifierViewToggle.TabStop = true;
            this.llblNotifierViewToggle.Text = "Show Notifiers";
            this.llblNotifierViewToggle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNotifierViewToggle_LinkClicked);
            // 
            // imagesNotifiersTree
            // 
            this.imagesNotifiersTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesNotifiersTree.ImageStream")));
            this.imagesNotifiersTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesNotifiersTree.Images.SetKeyName(0, "open_folder_blue24x24.png");
            this.imagesNotifiersTree.Images.SetKeyName(1, "SpeakerBlue.ico");
            this.imagesNotifiersTree.Images.SetKeyName(2, "SpeakerBW.ico");
            this.imagesNotifiersTree.Images.SetKeyName(3, "Speaker_doc.png");
            this.imagesNotifiersTree.Images.SetKeyName(4, "Speaker_docBW.png");
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.AllowKeyBoardNodeReorder = true;
            this.treeView1.AutoScrollToSelectedNodeWaitTimeMS = 500;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxEnhancements = false;
            this.treeView1.DisableCollapseOnDoubleClick = true;
            this.treeView1.DisableExpandOnDoubleClick = false;
            this.treeView1.DisableNode0Collapse = false;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.DragColor = System.Drawing.Color.Aquamarine;
            this.treeView1.EnableAutoScrollToSelectedNode = false;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imagesCollectorTree;
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 22;
            this.treeView1.Location = new System.Drawing.Point(0, 23);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 3;
            treeNode1.Name = "Node1";
            treeNode1.SelectedImageIndex = 3;
            treeNode1.Text = "Health";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Ping localhost";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "Node2";
            treeNode3.SelectedImageIndex = 4;
            treeNode3.Text = "Health";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Ping server";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            this.treeView1.RootAlwaysExpanded = false;
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(427, 232);
            this.treeView1.TabIndex = 0;
            // 
            // lblCollectors
            // 
            this.lblCollectors.BackColor = System.Drawing.Color.Transparent;
            this.lblCollectors.BoldHighLighFont = true;
            this.lblCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCollectors.FadedBackColor = System.Drawing.Color.Transparent;
            this.lblCollectors.FadedColor = System.Drawing.SystemColors.ControlText;
            this.lblCollectors.FadedFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectors.HighLightBackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCollectors.HighLightColor = System.Drawing.SystemColors.ControlText;
            this.lblCollectors.HighLightFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectors.Location = new System.Drawing.Point(0, 0);
            this.lblCollectors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCollectors.Name = "lblCollectors";
            this.lblCollectors.Size = new System.Drawing.Size(369, 23);
            this.lblCollectors.StartFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCollectors.StartForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCollectors.TabIndex = 42;
            this.lblCollectors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.BoldHighLighFont = true;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersion.FadedBackColor = System.Drawing.Color.Transparent;
            this.lblVersion.FadedColor = System.Drawing.Color.Silver;
            this.lblVersion.FadedFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.HighLightBackColor = System.Drawing.Color.WhiteSmoke;
            this.lblVersion.HighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVersion.HighLightFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(369, 0);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblVersion.Size = new System.Drawing.Size(58, 23);
            this.lblVersion.StartFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblVersion.StartForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVersion.TabIndex = 43;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lblVersion, "Version");
            // 
            // tvwNotifiers
            // 
            this.tvwNotifiers.AllowKeyBoardNodeReorder = false;
            this.tvwNotifiers.AutoScrollToSelectedNodeWaitTimeMS = 500;
            this.tvwNotifiers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwNotifiers.CheckBoxEnhancements = false;
            this.tvwNotifiers.DisableCollapseOnDoubleClick = true;
            this.tvwNotifiers.DisableExpandOnDoubleClick = false;
            this.tvwNotifiers.DisableNode0Collapse = false;
            this.tvwNotifiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNotifiers.DragColor = System.Drawing.Color.Aquamarine;
            this.tvwNotifiers.EnableAutoScrollToSelectedNode = false;
            this.tvwNotifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwNotifiers.FullRowSelect = true;
            this.tvwNotifiers.HideSelection = false;
            this.tvwNotifiers.ImageIndex = 0;
            this.tvwNotifiers.ImageList = this.imagesNotifiersTree;
            this.tvwNotifiers.Indent = 20;
            this.tvwNotifiers.ItemHeight = 22;
            this.tvwNotifiers.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvwNotifiers.Location = new System.Drawing.Point(0, 23);
            this.tvwNotifiers.Margin = new System.Windows.Forms.Padding(5);
            this.tvwNotifiers.Name = "tvwNotifiers";
            treeNode5.ImageKey = "Speaker_doc.png";
            treeNode5.Name = "Node0";
            treeNode5.SelectedImageKey = "Speaker_doc.png";
            treeNode5.Text = "Memory agent";
            treeNode6.BackColor = System.Drawing.Color.White;
            treeNode6.ImageKey = "SpeakerBlue.ico";
            treeNode6.Name = "root";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.SelectedImageKey = "SpeakerBlue.ico";
            treeNode6.Text = "NOTIFIERS";
            this.tvwNotifiers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.tvwNotifiers.RootAlwaysExpanded = false;
            this.tvwNotifiers.SelectedImageIndex = 0;
            this.tvwNotifiers.Size = new System.Drawing.Size(427, 139);
            this.tvwNotifiers.TabIndex = 4;
            this.tvwNotifiers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNotifiers_AfterSelect);
            // 
            // lblNotifiers
            // 
            this.lblNotifiers.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifiers.BoldHighLighFont = true;
            this.lblNotifiers.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotifiers.FadedBackColor = System.Drawing.Color.Transparent;
            this.lblNotifiers.FadedColor = System.Drawing.SystemColors.ControlText;
            this.lblNotifiers.FadedFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifiers.HighLightBackColor = System.Drawing.Color.WhiteSmoke;
            this.lblNotifiers.HighLightColor = System.Drawing.SystemColors.ControlText;
            this.lblNotifiers.HighLightFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifiers.Location = new System.Drawing.Point(0, 0);
            this.lblNotifiers.Margin = new System.Windows.Forms.Padding(4);
            this.lblNotifiers.Name = "lblNotifiers";
            this.lblNotifiers.Size = new System.Drawing.Size(427, 23);
            this.lblNotifiers.StartFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotifiers.StartForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotifiers.TabIndex = 44;
            this.lblNotifiers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitButtonInfo
            // 
            this.splitButtonInfo.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonInfo.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonInfo.ButtonImage = global::QuickMon.Properties.Resources.info24x24;
            this.splitButtonInfo.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonInfo.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonInfo.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonInfo.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonInfo.ButtonText = "";
            this.splitButtonInfo.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonInfo.ButtonToolTip = "About";
            this.splitButtonInfo.ContextMenuStrip = this.aboutContextMenuStrip;
            this.splitButtonInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonInfo.Location = new System.Drawing.Point(0, 186);
            this.splitButtonInfo.Name = "splitButtonInfo";
            this.splitButtonInfo.Size = new System.Drawing.Size(45, 31);
            this.splitButtonInfo.TabIndex = 6;
            this.splitButtonInfo.SplitButtonClicked += new System.EventHandler(this.splitButtonInfo_SplitButtonClicked);
            // 
            // splitButtonTools
            // 
            this.splitButtonTools.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonTools.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonTools.ButtonImage = global::QuickMon.Properties.Resources.tools24x24;
            this.splitButtonTools.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonTools.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonTools.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonTools.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonTools.ButtonText = "";
            this.splitButtonTools.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonTools.ButtonToolTip = "Settings  CTRL+E ";
            this.splitButtonTools.ContextMenuStrip = this.settingsContextMenuStrip;
            this.splitButtonTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonTools.Location = new System.Drawing.Point(0, 155);
            this.splitButtonTools.Name = "splitButtonTools";
            this.splitButtonTools.Size = new System.Drawing.Size(45, 31);
            this.splitButtonTools.TabIndex = 5;
            this.splitButtonTools.SplitButtonClicked += new System.EventHandler(this.splitButtonTools_SplitButtonClicked);
            // 
            // splitButtonAgents
            // 
            this.splitButtonAgents.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonAgents.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonAgents.ButtonImage = global::QuickMon.Properties.Resources.cubes24x24;
            this.splitButtonAgents.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonAgents.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonAgents.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonAgents.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonAgents.ButtonText = "";
            this.splitButtonAgents.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonAgents.ButtonToolTip = "Agents";
            this.splitButtonAgents.ContextMenuStrip = this.agentsContextMenuStrip;
            this.splitButtonAgents.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonAgents.Location = new System.Drawing.Point(0, 124);
            this.splitButtonAgents.Name = "splitButtonAgents";
            this.splitButtonAgents.Size = new System.Drawing.Size(45, 31);
            this.splitButtonAgents.TabIndex = 4;
            this.splitButtonAgents.ButtonClicked += new System.EventHandler(this.splitButtonAgents_SplitButtonClicked);
            this.splitButtonAgents.SplitButtonClicked += new System.EventHandler(this.splitButtonAgents_SplitButtonClicked);
            // 
            // splitButtonSave
            // 
            this.splitButtonSave.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonSave.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonSave.ButtonImage = global::QuickMon.Properties.Resources.save24x24;
            this.splitButtonSave.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonSave.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonSave.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonSave.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonSave.ButtonText = "";
            this.splitButtonSave.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonSave.ButtonToolTip = "Save  CTRL+S";
            this.splitButtonSave.ContextMenuStrip = this.saveContextMenuStrip;
            this.splitButtonSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonSave.Location = new System.Drawing.Point(0, 93);
            this.splitButtonSave.Name = "splitButtonSave";
            this.splitButtonSave.Size = new System.Drawing.Size(45, 31);
            this.splitButtonSave.TabIndex = 3;
            this.splitButtonSave.SplitButtonClicked += new System.EventHandler(this.splitButtonSave_SplitButtonClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(472, 503);
            this.Controls.Add(this.masterSplitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSlimMenu);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "MainForm";
            this.Text = "QuickMon 5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.saveContextMenuStrip.ResumeLayout(false);
            this.openContextMenuStrip.ResumeLayout(false);
            this.agentsContextMenuStrip.ResumeLayout(false);
            this.settingsContextMenuStrip.ResumeLayout(false);
            this.aboutContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSlimMenu.ResumeLayout(false);
            this.masterSplitContainer.Panel1.ResumeLayout(false);
            this.masterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).EndInit();
            this.masterSplitContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imagesCollectorTree;
        private System.Windows.Forms.Panel panelSlimMenu;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdMenu;
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
        private TreeViewExBase treeView1;
        private System.Windows.Forms.ContextMenuStrip agentsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem collectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip settingsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminModeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip aboutContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem remoteHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsNotifierToolStripMenuItem;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.SplitContainer masterSplitContainer;
        private System.Windows.Forms.LinkLabel llblNotifierViewToggle;
        private TreeViewExBase tvwNotifiers;
        private System.Windows.Forms.Panel panel2;
        private HiLightLabel lblCollectors;
        private HiLightLabel lblVersion;
        private HiLightLabel lblNotifiers;
        private System.Windows.Forms.ImageList imagesNotifiersTree;
    }
}

