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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.adminModeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.saveContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblVersion = new HenIT.Windows.Controls.HiLightLabel();
            this.cmdRecentMonitorPacks = new System.Windows.Forms.Button();
            this.cmdPauseRunMP = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cmdRemoteHosts = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdMenu = new System.Windows.Forms.Button();
            this.cmdTemplates = new System.Windows.Forms.Button();
            this.cmdAdminMode = new System.Windows.Forms.Button();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.settingsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remoteHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tvwCollectors = new QuickMon.Controls.TreeViewExBase();
            this.collectorsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.configOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAndEditCollectorConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMetricsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allHistoryToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCollectors = new HenIT.Windows.Controls.HiLightLabel();
            this.llblNotifierViewToggle = new System.Windows.Forms.LinkLabel();
            this.tvwNotifiers = new QuickMon.Controls.TreeViewExBase();
            this.notifiersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesNotifiersTree = new System.Windows.Forms.ImageList(this.components);
            this.lblNotifiers = new HenIT.Windows.Controls.HiLightLabel();
            this.openFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llblMonitorPack = new System.Windows.Forms.LinkLabel();
            this.cboRecentMonitorPacks = new System.Windows.Forms.ComboBox();
            this.panelSlimMenu = new System.Windows.Forms.Panel();
            this.splitButtonNotifiers = new QuickMon.Controls.SplitButton.SplitButton();
            this.splitButtonCollectors = new QuickMon.Controls.SplitButton.SplitButton();
            this.splitButtonSave = new QuickMon.Controls.SplitButton.SplitButton();
            this.refreshBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            this.collectorHistoryToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allHistoryToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.saveContextMenuStrip.SuspendLayout();
            this.openContextMenuStrip.SuspendLayout();
            this.settingsContextMenuStrip.SuspendLayout();
            this.aboutContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).BeginInit();
            this.masterSplitContainer.Panel1.SuspendLayout();
            this.masterSplitContainer.Panel2.SuspendLayout();
            this.masterSplitContainer.SuspendLayout();
            this.collectorsContextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.notifiersContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSlimMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminModeToolStripStatusLabel,
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // adminModeToolStripStatusLabel
            // 
            this.adminModeToolStripStatusLabel.Image = global::QuickMon.Properties.Resources.OUTLLIBR_9825;
            this.adminModeToolStripStatusLabel.Name = "adminModeToolStripStatusLabel";
            this.adminModeToolStripStatusLabel.Size = new System.Drawing.Size(16, 17);
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(453, 17);
            this.toolStripStatusLabelStatus.Spring = true;
            this.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // saveContextMenuStrip
            // 
            this.saveContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.saveContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.saveContextMenuStrip.Name = "saveContextMenuStrip";
            this.saveContextMenuStrip.Size = new System.Drawing.Size(123, 34);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.SaveAs24x24;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(122, 30);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
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
            this.lblVersion.HighLightFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.LabelText = "Label";
            this.lblVersion.Location = new System.Drawing.Point(381, 0);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 4, 10, 4);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblVersion.Size = new System.Drawing.Size(58, 23);
            this.lblVersion.StartFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblVersion.StartForeColor = System.Drawing.Color.Silver;
            this.lblVersion.TabIndex = 43;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lblVersion, "Version");
            this.lblVersion.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cmdRecentMonitorPacks
            // 
            this.cmdRecentMonitorPacks.BackColor = System.Drawing.Color.Transparent;
            this.cmdRecentMonitorPacks.BackgroundImage = global::QuickMon.Properties.Resources.folderWLightning16x16;
            this.cmdRecentMonitorPacks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRecentMonitorPacks.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdRecentMonitorPacks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdRecentMonitorPacks.FlatAppearance.BorderSize = 0;
            this.cmdRecentMonitorPacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRecentMonitorPacks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRecentMonitorPacks.Location = new System.Drawing.Point(334, 0);
            this.cmdRecentMonitorPacks.Name = "cmdRecentMonitorPacks";
            this.cmdRecentMonitorPacks.Size = new System.Drawing.Size(35, 38);
            this.cmdRecentMonitorPacks.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmdRecentMonitorPacks, "Recent Monitor Packs");
            this.cmdRecentMonitorPacks.UseVisualStyleBackColor = false;
            this.cmdRecentMonitorPacks.Click += new System.EventHandler(this.cmdRecentMonitorPacks_Click);
            // 
            // cmdPauseRunMP
            // 
            this.cmdPauseRunMP.BackColor = System.Drawing.Color.Transparent;
            this.cmdPauseRunMP.BackgroundImage = global::QuickMon.Properties.Resources._141;
            this.cmdPauseRunMP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdPauseRunMP.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdPauseRunMP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdPauseRunMP.FlatAppearance.BorderSize = 0;
            this.cmdPauseRunMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPauseRunMP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPauseRunMP.Location = new System.Drawing.Point(369, 0);
            this.cmdPauseRunMP.Name = "cmdPauseRunMP";
            this.cmdPauseRunMP.Size = new System.Drawing.Size(35, 38);
            this.cmdPauseRunMP.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmdPauseRunMP, "Pause Auto refresh");
            this.cmdPauseRunMP.UseVisualStyleBackColor = false;
            this.cmdPauseRunMP.Click += new System.EventHandler(this.cmdPauseRunMP_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdRefresh.FlatAppearance.BorderSize = 0;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(404, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(35, 38);
            this.cmdRefresh.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmdRefresh, "Refresh current Monitor Pack");
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdAbout
            // 
            this.cmdAbout.BackColor = System.Drawing.Color.Transparent;
            this.cmdAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAbout.FlatAppearance.BorderSize = 0;
            this.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAbout.Image = global::QuickMon.Properties.Resources.info24x24;
            this.cmdAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAbout.Location = new System.Drawing.Point(0, 276);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(45, 30);
            this.cmdAbout.TabIndex = 11;
            this.cmdAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdAbout, "About");
            this.cmdAbout.UseVisualStyleBackColor = false;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cmdRemoteHosts
            // 
            this.cmdRemoteHosts.BackColor = System.Drawing.Color.Transparent;
            this.cmdRemoteHosts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRemoteHosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRemoteHosts.FlatAppearance.BorderSize = 0;
            this.cmdRemoteHosts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemoteHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoteHosts.Image = global::QuickMon.Properties.Resources.remote24x24;
            this.cmdRemoteHosts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemoteHosts.Location = new System.Drawing.Point(0, 216);
            this.cmdRemoteHosts.Name = "cmdRemoteHosts";
            this.cmdRemoteHosts.Size = new System.Drawing.Size(45, 30);
            this.cmdRemoteHosts.TabIndex = 7;
            this.cmdRemoteHosts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdRemoteHosts, "Remote Hosts");
            this.cmdRemoteHosts.UseVisualStyleBackColor = false;
            this.cmdRemoteHosts.Click += new System.EventHandler(this.cmdRemoteHosts_Click);
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
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
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
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
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
            // cmdTemplates
            // 
            this.cmdTemplates.BackColor = System.Drawing.Color.Transparent;
            this.cmdTemplates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdTemplates.FlatAppearance.BorderSize = 0;
            this.cmdTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTemplates.Image = global::QuickMon.Properties.Resources.tables24x24;
            this.cmdTemplates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTemplates.Location = new System.Drawing.Point(0, 186);
            this.cmdTemplates.Name = "cmdTemplates";
            this.cmdTemplates.Size = new System.Drawing.Size(45, 30);
            this.cmdTemplates.TabIndex = 6;
            this.cmdTemplates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdTemplates, "Templates");
            this.cmdTemplates.UseVisualStyleBackColor = false;
            this.cmdTemplates.Click += new System.EventHandler(this.cmdTemplates_Click);
            // 
            // cmdAdminMode
            // 
            this.cmdAdminMode.BackColor = System.Drawing.Color.Transparent;
            this.cmdAdminMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdAdminMode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdAdminMode.FlatAppearance.BorderSize = 0;
            this.cmdAdminMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAdminMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdminMode.Image = global::QuickMon.Properties.Resources.Shield24x24;
            this.cmdAdminMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdminMode.Location = new System.Drawing.Point(0, 439);
            this.cmdAdminMode.Name = "cmdAdminMode";
            this.cmdAdminMode.Size = new System.Drawing.Size(45, 30);
            this.cmdAdminMode.TabIndex = 12;
            this.cmdAdminMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdAdminMode, "Admin Mode");
            this.cmdAdminMode.UseVisualStyleBackColor = false;
            this.cmdAdminMode.Click += new System.EventHandler(this.cmdAdminMode_Click);
            // 
            // cmdSettings
            // 
            this.cmdSettings.BackColor = System.Drawing.Color.Transparent;
            this.cmdSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdSettings.FlatAppearance.BorderSize = 0;
            this.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSettings.Image = global::QuickMon.Properties.Resources.tools24x24;
            this.cmdSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSettings.Location = new System.Drawing.Point(0, 246);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(45, 30);
            this.cmdSettings.TabIndex = 10;
            this.cmdSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.cmdSettings, "Settings");
            this.cmdSettings.UseVisualStyleBackColor = false;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // settingsContextMenuStrip
            // 
            this.settingsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.settingsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingToolStripMenuItem,
            this.templatesToolStripMenuItem,
            this.actionScriptsToolStripMenuItem,
            this.adminModeToolStripMenuItem});
            this.settingsContextMenuStrip.Name = "saveContextMenuStrip";
            this.settingsContextMenuStrip.Size = new System.Drawing.Size(156, 124);
            // 
            // pollingToolStripMenuItem
            // 
            this.pollingToolStripMenuItem.Image = global::QuickMon.Properties.Resources.clock24x24;
            this.pollingToolStripMenuItem.Name = "pollingToolStripMenuItem";
            this.pollingToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.pollingToolStripMenuItem.Text = "Polling";
            // 
            // templatesToolStripMenuItem
            // 
            this.templatesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.tables24x24;
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            this.templatesToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.templatesToolStripMenuItem.Text = "Templates";
            this.templatesToolStripMenuItem.Visible = false;
            this.templatesToolStripMenuItem.Click += new System.EventHandler(this.templatesToolStripMenuItem_Click);
            // 
            // actionScriptsToolStripMenuItem
            // 
            this.actionScriptsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.scroll24x24;
            this.actionScriptsToolStripMenuItem.Name = "actionScriptsToolStripMenuItem";
            this.actionScriptsToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.actionScriptsToolStripMenuItem.Text = "Action Scripts";
            this.actionScriptsToolStripMenuItem.Visible = false;
            // 
            // adminModeToolStripMenuItem
            // 
            this.adminModeToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Shield24x24;
            this.adminModeToolStripMenuItem.Name = "adminModeToolStripMenuItem";
            this.adminModeToolStripMenuItem.Size = new System.Drawing.Size(155, 30);
            this.adminModeToolStripMenuItem.Text = "Admin mode";
            this.adminModeToolStripMenuItem.Click += new System.EventHandler(this.adminModeToolStripMenuItem_Click);
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
            // masterSplitContainer
            // 
            this.masterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterSplitContainer.Location = new System.Drawing.Point(45, 38);
            this.masterSplitContainer.Name = "masterSplitContainer";
            this.masterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // masterSplitContainer.Panel1
            // 
            this.masterSplitContainer.Panel1.Controls.Add(this.tvwCollectors);
            this.masterSplitContainer.Panel1.Controls.Add(this.panel2);
            this.masterSplitContainer.Panel1.Controls.Add(this.llblNotifierViewToggle);
            // 
            // masterSplitContainer.Panel2
            // 
            this.masterSplitContainer.Panel2.Controls.Add(this.tvwNotifiers);
            this.masterSplitContainer.Panel2.Controls.Add(this.lblNotifiers);
            this.masterSplitContainer.Size = new System.Drawing.Size(439, 431);
            this.masterSplitContainer.SplitterDistance = 254;
            this.masterSplitContainer.SplitterWidth = 6;
            this.masterSplitContainer.TabIndex = 6;
            // 
            // tvwCollectors
            // 
            this.tvwCollectors.AllowDrop = true;
            this.tvwCollectors.AllowKeyBoardNodeReorder = true;
            this.tvwCollectors.AutoScrollToSelectedNodeWaitTimeMS = 500;
            this.tvwCollectors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwCollectors.CheckBoxEnhancements = false;
            this.tvwCollectors.ContextMenuStrip = this.collectorsContextMenuStrip;
            this.tvwCollectors.DisableCollapseOnDoubleClick = true;
            this.tvwCollectors.DisableExpandOnDoubleClick = false;
            this.tvwCollectors.DisableNode0Collapse = false;
            this.tvwCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCollectors.DragColor = System.Drawing.Color.Aquamarine;
            this.tvwCollectors.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvwCollectors.EnableAutoScrollToSelectedNode = false;
            this.tvwCollectors.ExtraColumnTextAlign = QuickMon.Controls.TreeViewExExtraColumnTextAlign.Left;
            this.tvwCollectors.ExtraColumnWidth = 120;
            this.tvwCollectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCollectors.HideSelection = false;
            this.tvwCollectors.HighLightWholeNode = true;
            this.tvwCollectors.ImageIndex = 0;
            this.tvwCollectors.ImageList = this.imagesCollectorTree;
            this.tvwCollectors.Indent = 20;
            this.tvwCollectors.ItemHeight = 24;
            this.tvwCollectors.Location = new System.Drawing.Point(0, 23);
            this.tvwCollectors.Name = "tvwCollectors";
            this.tvwCollectors.RootAlwaysExpanded = false;
            this.tvwCollectors.SelectedImageIndex = 0;
            this.tvwCollectors.ShowColumnSeparatorLine = true;
            this.tvwCollectors.ShowLines = false;
            this.tvwCollectors.Size = new System.Drawing.Size(439, 206);
            this.tvwCollectors.TabIndex = 0;
            this.tvwCollectors.TreeNodeMoved += new QuickMon.Controls.TreeNodeMovedDelegate(this.tvwCollectors_TreeNodeMoved);
            this.tvwCollectors.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwCollectors_NodeMouseClick);
            this.tvwCollectors.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwCollectors_NodeMouseDoubleClick);
            this.tvwCollectors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvwCollectors_MouseClick);
            this.tvwCollectors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwCollectors_MouseUp);
            // 
            // collectorsContextMenuStrip
            // 
            this.collectorsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.collectorsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.addCollectorToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.disableCollectorToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.configOperationsToolStripMenuItem,
            this.exportMetricsToolStripMenuItem});
            this.collectorsContextMenuStrip.Name = "saveContextMenuStrip";
            this.collectorsContextMenuStrip.Size = new System.Drawing.Size(178, 272);
            this.collectorsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.collectorsContextMenuStrip_Opening);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search24;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // addCollectorToolStripMenuItem
            // 
            this.addCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addCollectorToolStripMenuItem.Name = "addCollectorToolStripMenuItem";
            this.addCollectorToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.addCollectorToolStripMenuItem.Text = "Add";
            this.addCollectorToolStripMenuItem.Click += new System.EventHandler(this.addCollectorToolStripMenuItem_Click);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Blue3DGearEdit24;
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.configureToolStripMenuItem.Text = "Edit";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // disableCollectorToolStripMenuItem
            // 
            this.disableCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.ForbiddenBlue24x24;
            this.disableCollectorToolStripMenuItem.Name = "disableCollectorToolStripMenuItem";
            this.disableCollectorToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.disableCollectorToolStripMenuItem.Text = "Disable";
            this.disableCollectorToolStripMenuItem.Click += new System.EventHandler(this.disableCollectorToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::QuickMon.Properties.Resources.refresh24x24;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // configOperationsToolStripMenuItem
            // 
            this.configOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCollectorToolStripMenuItem,
            this.pasteCollectorToolStripMenuItem,
            this.pasteAndEditCollectorConfigToolStripMenuItem});
            this.configOperationsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_new1;
            this.configOperationsToolStripMenuItem.Name = "configOperationsToolStripMenuItem";
            this.configOperationsToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.configOperationsToolStripMenuItem.Text = "Config operations";
            // 
            // copyCollectorToolStripMenuItem
            // 
            this.copyCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.copy24x24;
            this.copyCollectorToolStripMenuItem.Name = "copyCollectorToolStripMenuItem";
            this.copyCollectorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyCollectorToolStripMenuItem.Text = "Copy";
            this.copyCollectorToolStripMenuItem.Click += new System.EventHandler(this.copyCollectorToolStripMenuItem_Click);
            // 
            // pasteCollectorToolStripMenuItem
            // 
            this.pasteCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.paste24x24;
            this.pasteCollectorToolStripMenuItem.Name = "pasteCollectorToolStripMenuItem";
            this.pasteCollectorToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pasteCollectorToolStripMenuItem.Text = "Paste";
            this.pasteCollectorToolStripMenuItem.Click += new System.EventHandler(this.pasteCollectorToolStripMenuItem_Click);
            // 
            // pasteAndEditCollectorConfigToolStripMenuItem
            // 
            this.pasteAndEditCollectorConfigToolStripMenuItem.Image = global::QuickMon.Properties.Resources.pastewithedit24x24;
            this.pasteAndEditCollectorConfigToolStripMenuItem.Name = "pasteAndEditCollectorConfigToolStripMenuItem";
            this.pasteAndEditCollectorConfigToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pasteAndEditCollectorConfigToolStripMenuItem.Text = "Paste and Edit";
            this.pasteAndEditCollectorConfigToolStripMenuItem.Click += new System.EventHandler(this.pasteAndEditCollectorConfigToolStripMenuItem_Click);
            // 
            // exportMetricsToolStripMenuItem
            // 
            this.exportMetricsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyToCSVToolStripMenuItem,
            this.allHistoryToCSVToolStripMenuItem,
            this.collectorHistoryToXMLToolStripMenuItem,
            this.allHistoryToXMLToolStripMenuItem});
            this.exportMetricsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.DocExport;
            this.exportMetricsToolStripMenuItem.Name = "exportMetricsToolStripMenuItem";
            this.exportMetricsToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.exportMetricsToolStripMenuItem.Text = "Export Metrics";
            // 
            // historyToCSVToolStripMenuItem
            // 
            this.historyToCSVToolStripMenuItem.Name = "historyToCSVToolStripMenuItem";
            this.historyToCSVToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.historyToCSVToolStripMenuItem.Text = "Collector History To CSV";
            this.historyToCSVToolStripMenuItem.Click += new System.EventHandler(this.historyToCSVToolStripMenuItem_Click);
            // 
            // allHistoryToCSVToolStripMenuItem
            // 
            this.allHistoryToCSVToolStripMenuItem.Name = "allHistoryToCSVToolStripMenuItem";
            this.allHistoryToCSVToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.allHistoryToCSVToolStripMenuItem.Text = "Monitor pack History to CSV";
            this.allHistoryToCSVToolStripMenuItem.Click += new System.EventHandler(this.allHistoryToCSVToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCollectors);
            this.panel2.Controls.Add(this.lblVersion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 23);
            this.panel2.TabIndex = 42;
            // 
            // lblCollectors
            // 
            this.lblCollectors.BackColor = System.Drawing.Color.Transparent;
            this.lblCollectors.BoldHighLighFont = true;
            this.lblCollectors.ContextMenuStrip = this.collectorsContextMenuStrip;
            this.lblCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCollectors.FadedBackColor = System.Drawing.Color.Transparent;
            this.lblCollectors.FadedColor = System.Drawing.SystemColors.ControlText;
            this.lblCollectors.FadedFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectors.HighLightBackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCollectors.HighLightColor = System.Drawing.SystemColors.ControlText;
            this.lblCollectors.HighLightFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectors.LabelText = "Collectors";
            this.lblCollectors.Location = new System.Drawing.Point(0, 0);
            this.lblCollectors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCollectors.Name = "lblCollectors";
            this.lblCollectors.Size = new System.Drawing.Size(381, 23);
            this.lblCollectors.StartFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCollectors.StartForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCollectors.TabIndex = 42;
            this.lblCollectors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCollectors.Click += new System.EventHandler(this.lblCollectors_Click);
            // 
            // llblNotifierViewToggle
            // 
            this.llblNotifierViewToggle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.llblNotifierViewToggle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.llblNotifierViewToggle.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblNotifierViewToggle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.llblNotifierViewToggle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblNotifierViewToggle.Location = new System.Drawing.Point(0, 229);
            this.llblNotifierViewToggle.Name = "llblNotifierViewToggle";
            this.llblNotifierViewToggle.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.llblNotifierViewToggle.Size = new System.Drawing.Size(439, 25);
            this.llblNotifierViewToggle.TabIndex = 40;
            this.llblNotifierViewToggle.TabStop = true;
            this.llblNotifierViewToggle.Text = "► Show Notifiers";
            this.llblNotifierViewToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblNotifierViewToggle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNotifierViewToggle_LinkClicked);
            this.llblNotifierViewToggle.DoubleClick += new System.EventHandler(this.llblNotifierViewToggle_DoubleClick);
            // 
            // tvwNotifiers
            // 
            this.tvwNotifiers.AllowKeyBoardNodeReorder = false;
            this.tvwNotifiers.AutoScrollToSelectedNodeWaitTimeMS = 500;
            this.tvwNotifiers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwNotifiers.CheckBoxEnhancements = false;
            this.tvwNotifiers.ContextMenuStrip = this.notifiersContextMenuStrip;
            this.tvwNotifiers.DisableCollapseOnDoubleClick = true;
            this.tvwNotifiers.DisableExpandOnDoubleClick = false;
            this.tvwNotifiers.DisableNode0Collapse = false;
            this.tvwNotifiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNotifiers.DragColor = System.Drawing.Color.Aquamarine;
            this.tvwNotifiers.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvwNotifiers.EnableAutoScrollToSelectedNode = false;
            this.tvwNotifiers.ExtraColumnTextAlign = QuickMon.Controls.TreeViewExExtraColumnTextAlign.Left;
            this.tvwNotifiers.ExtraColumnWidth = 100;
            this.tvwNotifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwNotifiers.FullRowSelect = true;
            this.tvwNotifiers.HideSelection = false;
            this.tvwNotifiers.HighLightWholeNode = false;
            this.tvwNotifiers.ImageIndex = 0;
            this.tvwNotifiers.ImageList = this.imagesNotifiersTree;
            this.tvwNotifiers.Indent = 20;
            this.tvwNotifiers.ItemHeight = 24;
            this.tvwNotifiers.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvwNotifiers.Location = new System.Drawing.Point(0, 23);
            this.tvwNotifiers.Margin = new System.Windows.Forms.Padding(5);
            this.tvwNotifiers.Name = "tvwNotifiers";
            this.tvwNotifiers.RootAlwaysExpanded = false;
            this.tvwNotifiers.SelectedImageIndex = 0;
            this.tvwNotifiers.ShowColumnSeparatorLine = false;
            this.tvwNotifiers.ShowLines = false;
            this.tvwNotifiers.Size = new System.Drawing.Size(439, 148);
            this.tvwNotifiers.TabIndex = 4;
            this.tvwNotifiers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNotifiers_AfterSelect);
            this.tvwNotifiers.DoubleClick += new System.EventHandler(this.tvwNotifiers_DoubleClick);
            // 
            // notifiersContextMenuStrip
            // 
            this.notifiersContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.notifiersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNotifierToolStripMenuItem,
            this.editNotifierToolStripMenuItem,
            this.deleteNotifierToolStripMenuItem,
            this.enableNotifierToolStripMenuItem,
            this.viewNotifierToolStripMenuItem});
            this.notifiersContextMenuStrip.Name = "saveContextMenuStrip";
            this.notifiersContextMenuStrip.Size = new System.Drawing.Size(121, 154);
            this.notifiersContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.notifiersContextMenuStrip_Opening);
            // 
            // addNotifierToolStripMenuItem
            // 
            this.addNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addNotifierToolStripMenuItem.Name = "addNotifierToolStripMenuItem";
            this.addNotifierToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.addNotifierToolStripMenuItem.Text = "Add";
            this.addNotifierToolStripMenuItem.Click += new System.EventHandler(this.addNotifierToolStripMenuItem_Click);
            // 
            // editNotifierToolStripMenuItem
            // 
            this.editNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Blue3DGearEdit24;
            this.editNotifierToolStripMenuItem.Name = "editNotifierToolStripMenuItem";
            this.editNotifierToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.editNotifierToolStripMenuItem.Text = "Edit";
            this.editNotifierToolStripMenuItem.Click += new System.EventHandler(this.editNotifierToolStripMenuItem_Click);
            // 
            // deleteNotifierToolStripMenuItem
            // 
            this.deleteNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.deleteNotifierToolStripMenuItem.Name = "deleteNotifierToolStripMenuItem";
            this.deleteNotifierToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.deleteNotifierToolStripMenuItem.Text = "Delete";
            this.deleteNotifierToolStripMenuItem.Click += new System.EventHandler(this.deleteNotifierToolStripMenuItem_Click);
            // 
            // enableNotifierToolStripMenuItem
            // 
            this.enableNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.ForbiddenBlue24x24;
            this.enableNotifierToolStripMenuItem.Name = "enableNotifierToolStripMenuItem";
            this.enableNotifierToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.enableNotifierToolStripMenuItem.Text = "Disable";
            this.enableNotifierToolStripMenuItem.Click += new System.EventHandler(this.enableNotifierToolStripMenuItem_Click);
            // 
            // viewNotifierToolStripMenuItem
            // 
            this.viewNotifierToolStripMenuItem.Image = global::QuickMon.Properties.Resources.comp_search24;
            this.viewNotifierToolStripMenuItem.Name = "viewNotifierToolStripMenuItem";
            this.viewNotifierToolStripMenuItem.Size = new System.Drawing.Size(120, 30);
            this.viewNotifierToolStripMenuItem.Text = "View";
            this.viewNotifierToolStripMenuItem.Click += new System.EventHandler(this.viewNotifierToolStripMenuItem_Click);
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
            // lblNotifiers
            // 
            this.lblNotifiers.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifiers.BoldHighLighFont = true;
            this.lblNotifiers.ContextMenuStrip = this.notifiersContextMenuStrip;
            this.lblNotifiers.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotifiers.FadedBackColor = System.Drawing.Color.Transparent;
            this.lblNotifiers.FadedColor = System.Drawing.SystemColors.ControlText;
            this.lblNotifiers.FadedFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifiers.HighLightBackColor = System.Drawing.Color.WhiteSmoke;
            this.lblNotifiers.HighLightColor = System.Drawing.SystemColors.ControlText;
            this.lblNotifiers.HighLightFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifiers.LabelText = "Notifiers";
            this.lblNotifiers.Location = new System.Drawing.Point(0, 0);
            this.lblNotifiers.Margin = new System.Windows.Forms.Padding(4);
            this.lblNotifiers.Name = "lblNotifiers";
            this.lblNotifiers.Size = new System.Drawing.Size(439, 23);
            this.lblNotifiers.StartFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotifiers.StartForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotifiers.TabIndex = 44;
            this.lblNotifiers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotifiers.Click += new System.EventHandler(this.lblNotifiers_Click);
            // 
            // openFileDialogOpen
            // 
            this.openFileDialogOpen.DefaultExt = "qmp";
            this.openFileDialogOpen.Filter = "QuickMon Monitor Pack files|*.qmp";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuickMon.Properties.Resources.QuickMon5Background3;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.llblMonitorPack);
            this.panel1.Controls.Add(this.cboRecentMonitorPacks);
            this.panel1.Controls.Add(this.cmdRecentMonitorPacks);
            this.panel1.Controls.Add(this.cmdPauseRunMP);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(45, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 38);
            this.panel1.TabIndex = 3;
            // 
            // llblMonitorPack
            // 
            this.llblMonitorPack.BackColor = System.Drawing.Color.Transparent;
            this.llblMonitorPack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llblMonitorPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblMonitorPack.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblMonitorPack.Location = new System.Drawing.Point(0, 0);
            this.llblMonitorPack.Name = "llblMonitorPack";
            this.llblMonitorPack.Size = new System.Drawing.Size(334, 38);
            this.llblMonitorPack.TabIndex = 0;
            this.llblMonitorPack.TabStop = true;
            this.llblMonitorPack.Text = "<New Monitor Pack>";
            this.llblMonitorPack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblMonitorPack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblMonitorPack_LinkClicked);
            this.llblMonitorPack.Click += new System.EventHandler(this.llblMonitorPack_Click);
            // 
            // cboRecentMonitorPacks
            // 
            this.cboRecentMonitorPacks.DropDownHeight = 200;
            this.cboRecentMonitorPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecentMonitorPacks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboRecentMonitorPacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboRecentMonitorPacks.FormattingEnabled = true;
            this.cboRecentMonitorPacks.IntegralHeight = false;
            this.cboRecentMonitorPacks.Location = new System.Drawing.Point(0, 0);
            this.cboRecentMonitorPacks.Name = "cboRecentMonitorPacks";
            this.cboRecentMonitorPacks.Size = new System.Drawing.Size(120, 24);
            this.cboRecentMonitorPacks.TabIndex = 4;
            this.cboRecentMonitorPacks.SelectionChangeCommitted += new System.EventHandler(this.cboRecentMonitorPacks_SelectionChangeCommitted);
            this.cboRecentMonitorPacks.DropDownClosed += new System.EventHandler(this.cboRecentMonitorPacks_DropDownClosed);
            // 
            // panelSlimMenu
            // 
            this.panelSlimMenu.BackgroundImage = global::QuickMon.Properties.Resources.QuickMon5Background2;
            this.panelSlimMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSlimMenu.Controls.Add(this.cmdAbout);
            this.panelSlimMenu.Controls.Add(this.cmdSettings);
            this.panelSlimMenu.Controls.Add(this.cmdRemoteHosts);
            this.panelSlimMenu.Controls.Add(this.cmdTemplates);
            this.panelSlimMenu.Controls.Add(this.splitButtonNotifiers);
            this.panelSlimMenu.Controls.Add(this.splitButtonCollectors);
            this.panelSlimMenu.Controls.Add(this.splitButtonSave);
            this.panelSlimMenu.Controls.Add(this.cmdOpen);
            this.panelSlimMenu.Controls.Add(this.cmdNew);
            this.panelSlimMenu.Controls.Add(this.cmdMenu);
            this.panelSlimMenu.Controls.Add(this.cmdAdminMode);
            this.panelSlimMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlimMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSlimMenu.Name = "panelSlimMenu";
            this.panelSlimMenu.Size = new System.Drawing.Size(45, 469);
            this.panelSlimMenu.TabIndex = 2;
            // 
            // splitButtonNotifiers
            // 
            this.splitButtonNotifiers.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonNotifiers.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonNotifiers.ButtonImage = global::QuickMon.Properties.Resources.Notifiers24x24;
            this.splitButtonNotifiers.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonNotifiers.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonNotifiers.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonNotifiers.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonNotifiers.ButtonText = "";
            this.splitButtonNotifiers.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonNotifiers.ButtonToolTip = "Notifiers";
            this.splitButtonNotifiers.ContextMenuStrip = this.notifiersContextMenuStrip;
            this.splitButtonNotifiers.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonNotifiers.Location = new System.Drawing.Point(0, 155);
            this.splitButtonNotifiers.Name = "splitButtonNotifiers";
            this.splitButtonNotifiers.Size = new System.Drawing.Size(45, 31);
            this.splitButtonNotifiers.TabIndex = 5;
            this.splitButtonNotifiers.ButtonClicked += new System.EventHandler(this.splitButtonNotifiers_ButtonClicked);
            this.splitButtonNotifiers.SplitButtonClicked += new System.EventHandler(this.splitButtonNotifiers_SplitButtonClicked);
            // 
            // splitButtonCollectors
            // 
            this.splitButtonCollectors.BackColor = System.Drawing.Color.Transparent;
            this.splitButtonCollectors.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButtonCollectors.ButtonImage = global::QuickMon.Properties.Resources.Collectors24x24;
            this.splitButtonCollectors.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonCollectors.ButtonImageLayOut = System.Windows.Forms.ImageLayout.Stretch;
            this.splitButtonCollectors.ButtonMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitButtonCollectors.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.splitButtonCollectors.ButtonText = "";
            this.splitButtonCollectors.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButtonCollectors.ButtonToolTip = "Collectors";
            this.splitButtonCollectors.ContextMenuStrip = this.collectorsContextMenuStrip;
            this.splitButtonCollectors.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitButtonCollectors.Location = new System.Drawing.Point(0, 124);
            this.splitButtonCollectors.Name = "splitButtonCollectors";
            this.splitButtonCollectors.Size = new System.Drawing.Size(45, 31);
            this.splitButtonCollectors.TabIndex = 4;
            this.splitButtonCollectors.ButtonClicked += new System.EventHandler(this.splitButtonCollectors_ButtonClicked);
            this.splitButtonCollectors.SplitButtonClicked += new System.EventHandler(this.splitButtonCollectors_SplitButtonClicked);
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
            this.splitButtonSave.ButtonClicked += new System.EventHandler(this.splitButtonSave_ButtonClicked);
            this.splitButtonSave.SplitButtonClicked += new System.EventHandler(this.splitButtonSave_SplitButtonClicked);
            // 
            // saveFileDialogSave
            // 
            this.saveFileDialogSave.DefaultExt = "qmp";
            this.saveFileDialogSave.Filter = "QuickMon Monitor Pack files|*.qmp";
            // 
            // collectorHistoryToXMLToolStripMenuItem
            // 
            this.collectorHistoryToXMLToolStripMenuItem.Name = "collectorHistoryToXMLToolStripMenuItem";
            this.collectorHistoryToXMLToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.collectorHistoryToXMLToolStripMenuItem.Text = "Collector History To XML";
            this.collectorHistoryToXMLToolStripMenuItem.Click += new System.EventHandler(this.collectorHistoryToXMLToolStripMenuItem_Click);
            // 
            // allHistoryToXMLToolStripMenuItem
            // 
            this.allHistoryToXMLToolStripMenuItem.Name = "allHistoryToXMLToolStripMenuItem";
            this.allHistoryToXMLToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.allHistoryToXMLToolStripMenuItem.Text = "Monitor pack History To XML";
            this.allHistoryToXMLToolStripMenuItem.Click += new System.EventHandler(this.allHistoryToXMLToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 491);
            this.Controls.Add(this.masterSplitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSlimMenu);
            this.Controls.Add(this.statusStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(450, 430);
            this.Name = "MainForm";
            this.Text = "QuickMon 5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.saveContextMenuStrip.ResumeLayout(false);
            this.openContextMenuStrip.ResumeLayout(false);
            this.settingsContextMenuStrip.ResumeLayout(false);
            this.aboutContextMenuStrip.ResumeLayout(false);
            this.masterSplitContainer.Panel1.ResumeLayout(false);
            this.masterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterSplitContainer)).EndInit();
            this.masterSplitContainer.ResumeLayout(false);
            this.collectorsContextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.notifiersContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSlimMenu.ResumeLayout(false);
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
        private Controls.SplitButton.SplitButton splitButtonSave;
        private System.Windows.Forms.ContextMenuStrip saveContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip openContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel llblMonitorPack;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdRecentMonitorPacks;
        private TreeViewExBase tvwCollectors;
        private System.Windows.Forms.ToolStripMenuItem addCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip settingsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminModeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip aboutContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem remoteHostsToolStripMenuItem;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.SplitContainer masterSplitContainer;
        private System.Windows.Forms.LinkLabel llblNotifierViewToggle;
        private TreeViewExBase tvwNotifiers;
        private System.Windows.Forms.Panel panel2;
        private HiLightLabel lblCollectors;
        private HiLightLabel lblVersion;
        private HiLightLabel lblNotifiers;
        private System.Windows.Forms.ImageList imagesNotifiersTree;
        private Controls.SplitButton.SplitButton splitButtonCollectors;
        private Controls.SplitButton.SplitButton splitButtonNotifiers;
        private System.Windows.Forms.ContextMenuStrip collectorsContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteAndEditCollectorConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableCollectorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip notifiersContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewNotifierToolStripMenuItem;
        private System.Windows.Forms.Button cmdRemoteHosts;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Button cmdPauseRunMP;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpen;
        private System.ComponentModel.BackgroundWorker refreshBackgroundWorker;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSave;
        private System.Windows.Forms.ComboBox cboRecentMonitorPacks;
        private System.Windows.Forms.ToolStripStatusLabel adminModeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem actionScriptsToolStripMenuItem;
        private System.Windows.Forms.Button cmdTemplates;
        private System.Windows.Forms.Button cmdAdminMode;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMetricsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allHistoryToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectorHistoryToXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allHistoryToXMLToolStripMenuItem;
    }
}

