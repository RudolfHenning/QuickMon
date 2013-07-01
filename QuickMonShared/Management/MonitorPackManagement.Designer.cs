namespace QuickMon.Management
{
    partial class MonitorPackManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorPackManagement));
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Collectors", 4, 4);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Notifiers", 5, 5);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Monitor Pack Agent Instances", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.toolStripManagement = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripSplitButton();
            this.recentItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConfigure = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.infoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.filePathtoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorkerNodeSelection = new System.ComponentModel.BackgroundWorker();
            this.openFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtAgentsRegistrationFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDefaultViewerNotifier = new System.Windows.Forms.ComboBox();
            this.chkRunCorrectiveScripts = new System.Windows.Forms.CheckBox();
            this.tvwMonPack = new QuickMon.TreeViewEx();
            this.toolStripManagement.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripManagement
            // 
            this.toolStripManagement.AllowItemReorder = true;
            this.toolStripManagement.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripManagement.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonLoad,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonAdd,
            this.toolStripButtonConfigure,
            this.toolStripButtonRemove,
            this.toolStripSeparator2,
            this.moveUpToolStripButton,
            this.moveDownToolStripButton,
            this.toolStripSeparator3,
            this.infoToolStripButton});
            this.toolStripManagement.Location = new System.Drawing.Point(0, 0);
            this.toolStripManagement.Name = "toolStripManagement";
            this.toolStripManagement.Size = new System.Drawing.Size(498, 39);
            this.toolStripManagement.TabIndex = 0;
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::QuickMon.Properties.Resources.doc_new2;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonNew.Text = "New";
            this.toolStripButtonNew.ToolTipText = "New monitor pack";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recentItemsToolStripMenuItem});
            this.toolStripButtonLoad.Image = global::QuickMon.Properties.Resources.folder_doc;
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(48, 36);
            this.toolStripButtonLoad.Text = "Load";
            this.toolStripButtonLoad.ToolTipText = "Load monitor pack";
            this.toolStripButtonLoad.ButtonClick += new System.EventHandler(this.toolStripoad_Click);
            // 
            // recentItemsToolStripMenuItem
            // 
            this.recentItemsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_favor;
            this.recentItemsToolStripMenuItem.Name = "recentItemsToolStripMenuItem";
            this.recentItemsToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.recentItemsToolStripMenuItem.Text = "Recent items";
            this.recentItemsToolStripMenuItem.Click += new System.EventHandler(this.recentToolStripButton_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::QuickMon.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.ToolTipText = "Save monitor pack";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Enabled = false;
            this.toolStripButtonAdd.Image = global::QuickMon.Properties.Resources.add;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.ToolTipText = "Add agent";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonConfigure
            // 
            this.toolStripButtonConfigure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConfigure.Enabled = false;
            this.toolStripButtonConfigure.Image = global::QuickMon.Properties.Resources.project;
            this.toolStripButtonConfigure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConfigure.Name = "toolStripButtonConfigure";
            this.toolStripButtonConfigure.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonConfigure.Text = "Edit configuration";
            this.toolStripButtonConfigure.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Enabled = false;
            this.toolStripButtonRemove.Image = global::QuickMon.Properties.Resources.stop;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRemove.Text = "Remove";
            this.toolStripButtonRemove.ToolTipText = "Remove agent";
            this.toolStripButtonRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // moveUpToolStripButton
            // 
            this.moveUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpToolStripButton.Enabled = false;
            this.moveUpToolStripButton.Image = global::QuickMon.Properties.Resources.up;
            this.moveUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpToolStripButton.Name = "moveUpToolStripButton";
            this.moveUpToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.moveUpToolStripButton.Text = "Move down";
            this.moveUpToolStripButton.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripButton
            // 
            this.moveDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownToolStripButton.Enabled = false;
            this.moveDownToolStripButton.Image = global::QuickMon.Properties.Resources.down;
            this.moveDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownToolStripButton.Name = "moveDownToolStripButton";
            this.moveDownToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.moveDownToolStripButton.Text = "Move down";
            this.moveDownToolStripButton.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // infoToolStripButton
            // 
            this.infoToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoToolStripButton.Image = global::QuickMon.Properties.Resources.info;
            this.infoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoToolStripButton.Name = "infoToolStripButton";
            this.infoToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.infoToolStripButton.Text = "About";
            this.infoToolStripButton.Click += new System.EventHandler(this.infoToolStripButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.enableToolStripMenuItem,
            this.toolStripMenuItem1,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.monitorPackToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 178);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Enabled = false;
            this.configureToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.configureToolStripMenuItem.Image = global::QuickMon.Properties.Resources.project;
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.configureToolStripMenuItem.Text = "Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Visible = false;
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Enabled = false;
            this.moveUpToolStripMenuItem.Image = global::QuickMon.Properties.Resources.up;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.moveUpToolStripMenuItem.Text = "Move up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Enabled = false;
            this.moveDownToolStripMenuItem.Image = global::QuickMon.Properties.Resources.down;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.moveDownToolStripMenuItem.Text = "Move down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // monitorPackToolStripMenuItem
            // 
            this.monitorPackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportSelectedToolStripMenuItem});
            this.monitorPackToolStripMenuItem.Name = "monitorPackToolStripMenuItem";
            this.monitorPackToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.monitorPackToolStripMenuItem.Text = "Monitor pack";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_new2;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_doc;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.toolStripoad_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_favor;
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.recentToolStripMenuItem.Text = "Recent";
            this.recentToolStripMenuItem.Click += new System.EventHandler(this.recentToolStripButton_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::QuickMon.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // exportSelectedToolStripMenuItem
            // 
            this.exportSelectedToolStripMenuItem.Enabled = false;
            this.exportSelectedToolStripMenuItem.Image = global::QuickMon.Properties.Resources._274_2;
            this.exportSelectedToolStripMenuItem.Name = "exportSelectedToolStripMenuItem";
            this.exportSelectedToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.exportSelectedToolStripMenuItem.Text = "Export selected";
            this.exportSelectedToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "4_18.ico");
            this.imageList1.Images.SetKeyName(1, "find.png");
            this.imageList1.Images.SetKeyName(2, "document_pencil_16.png");
            this.imageList1.Images.SetKeyName(3, "125_30.ico");
            this.imageList1.Images.SetKeyName(4, "403_9.ico");
            this.imageList1.Images.SetKeyName(5, "bookmarks.ico");
            this.imageList1.Images.SetKeyName(6, "205_1.ico");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePathtoolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(498, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // filePathtoolStripStatusLabel
            // 
            this.filePathtoolStripStatusLabel.AutoSize = false;
            this.filePathtoolStripStatusLabel.Name = "filePathtoolStripStatusLabel";
            this.filePathtoolStripStatusLabel.Size = new System.Drawing.Size(483, 17);
            this.filePathtoolStripStatusLabel.Spring = true;
            this.filePathtoolStripStatusLabel.Text = ".";
            this.filePathtoolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backgroundWorkerNodeSelection
            // 
            this.backgroundWorkerNodeSelection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerNodeSelection_DoWork);
            // 
            // openFileDialogOpen
            // 
            this.openFileDialogOpen.DefaultExt = "qmconfig";
            this.openFileDialogOpen.Filter = "QuickMon config files|*.qmconfig";
            // 
            // saveFileDialogSave
            // 
            this.saveFileDialogSave.DefaultExt = "qmconfig";
            this.saveFileDialogSave.Filter = "QuickMon config files|*.qmconfig";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(86, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(329, 20);
            this.txtName.TabIndex = 2;
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkEnabled.Location = new System.Drawing.Point(422, 44);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(64, 17);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtAgentsRegistrationFile
            // 
            this.txtAgentsRegistrationFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgentsRegistrationFile.Location = new System.Drawing.Point(86, 68);
            this.txtAgentsRegistrationFile.Name = "txtAgentsRegistrationFile";
            this.txtAgentsRegistrationFile.ReadOnly = true;
            this.txtAgentsRegistrationFile.Size = new System.Drawing.Size(361, 20);
            this.txtAgentsRegistrationFile.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Agents Path:";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBrowse.Location = new System.Drawing.Point(453, 66);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(33, 23);
            this.cmdBrowse.TabIndex = 6;
            this.cmdBrowse.Text = "- - -";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(419, 365);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(340, 365);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 11;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Default notifier viewer";
            // 
            // cboDefaultViewerNotifier
            // 
            this.cboDefaultViewerNotifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefaultViewerNotifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultViewerNotifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDefaultViewerNotifier.FormattingEnabled = true;
            this.cboDefaultViewerNotifier.Location = new System.Drawing.Point(129, 367);
            this.cboDefaultViewerNotifier.Name = "cboDefaultViewerNotifier";
            this.cboDefaultViewerNotifier.Size = new System.Drawing.Size(205, 21);
            this.cboDefaultViewerNotifier.TabIndex = 10;
            // 
            // chkRunCorrectiveScripts
            // 
            this.chkRunCorrectiveScripts.AutoSize = true;
            this.chkRunCorrectiveScripts.Checked = true;
            this.chkRunCorrectiveScripts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunCorrectiveScripts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkRunCorrectiveScripts.Location = new System.Drawing.Point(86, 94);
            this.chkRunCorrectiveScripts.Name = "chkRunCorrectiveScripts";
            this.chkRunCorrectiveScripts.Size = new System.Drawing.Size(141, 17);
            this.chkRunCorrectiveScripts.TabIndex = 7;
            this.chkRunCorrectiveScripts.Text = "Enable corrective scripts";
            this.chkRunCorrectiveScripts.UseVisualStyleBackColor = true;
            // 
            // tvwMonPack
            // 
            this.tvwMonPack.AllowDrop = true;
            this.tvwMonPack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwMonPack.ContextMenuStrip = this.contextMenuStrip1;
            this.tvwMonPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwMonPack.HideSelection = false;
            this.tvwMonPack.ImageIndex = 0;
            this.tvwMonPack.ImageList = this.imageList1;
            this.tvwMonPack.Location = new System.Drawing.Point(0, 117);
            this.tvwMonPack.Name = "tvwMonPack";
            treeNode4.ImageIndex = 4;
            treeNode4.Name = "Collectors";
            treeNode4.SelectedImageIndex = 4;
            treeNode4.Text = "Collectors";
            treeNode5.ImageIndex = 5;
            treeNode5.Name = "Notifiers";
            treeNode5.SelectedImageIndex = 5;
            treeNode5.Text = "Notifiers";
            treeNode6.Name = "MonitorPackNode";
            treeNode6.Text = "Monitor Pack Agent Instances";
            this.tvwMonPack.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.tvwMonPack.SelectedImageIndex = 0;
            this.tvwMonPack.ShowRootLines = false;
            this.tvwMonPack.Size = new System.Drawing.Size(498, 244);
            this.tvwMonPack.TabIndex = 8;
            this.tvwMonPack.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.tvwMonPack_EnterKeyPressed);
            this.tvwMonPack.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.tvwMonPack_DeleteKeyPressed);
            this.tvwMonPack.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvwMonPack_AfterCollapse);
            this.tvwMonPack.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvwMonPack_ItemDrag);
            this.tvwMonPack.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwMonPack_AfterSelect);
            this.tvwMonPack.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwMonPack_DragDrop);
            this.tvwMonPack.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwMonPack_DragOver);
            this.tvwMonPack.DoubleClick += new System.EventHandler(this.tvwMonPack_DoubleClick);
            // 
            // MonitorPackManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(498, 415);
            this.Controls.Add(this.chkRunCorrectiveScripts);
            this.Controls.Add(this.cboDefaultViewerNotifier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtAgentsRegistrationFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvwMonPack);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripManagement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(510, 333);
            this.Name = "MonitorPackManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor Pack Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorPackManagement_FormClosing);
            this.Load += new System.EventHandler(this.MonitorPackManagement_Load);
            this.Shown += new System.EventHandler(this.MonitorPackManagement_Shown);
            this.toolStripManagement.ResumeLayout(false);
            this.toolStripManagement.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripManagement;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private TreeViewEx tvwMonPack;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerNodeSelection;
        private System.Windows.Forms.ToolStripButton toolStripButtonConfigure;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtAgentsRegistrationFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDefaultViewerNotifier;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel filePathtoolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton moveUpToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton infoToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkRunCorrectiveScripts;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonLoad;
        private System.Windows.Forms.ToolStripMenuItem recentItemsToolStripMenuItem;
    }
}