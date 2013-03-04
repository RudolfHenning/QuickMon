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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Collectors");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripSplitButton();
            this.recentMonitorPacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonConfigPack = new System.Windows.Forms.ToolStripSplitButton();
            this.configureCollectorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonNotifiers = new System.Windows.Forms.ToolStripSplitButton();
            this.showAllNotifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.infoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOptions = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lastUpdateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvwCollectors = new QuickMon.TreeViewEx();
            this.contextMenuStriptvw = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.notifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultNotifierViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.disablePollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentMonitorPackFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureMonitorPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            this.timerAppIconRefresher = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerRefresh = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStriptvw.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoad,
            this.toolStripButtonConfigPack,
            this.toolStripButtonNotifiers,
            this.toolStripSeparator1,
            this.toolStripButtonRefresh,
            this.infoToolStripButton,
            this.toolStripButtonOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(374, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.TabStop = true;
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recentMonitorPacksToolStripMenuItem});
            this.toolStripButtonLoad.Image = global::QuickMon.Properties.Resources.folder;
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(48, 36);
            this.toolStripButtonLoad.Text = "Open Monitor Pack file";
            this.toolStripButtonLoad.ButtonClick += new System.EventHandler(this.toolStripButtonLoad_Click);
            // 
            // recentMonitorPacksToolStripMenuItem
            // 
            this.recentMonitorPacksToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_favor;
            this.recentMonitorPacksToolStripMenuItem.Name = "recentMonitorPacksToolStripMenuItem";
            this.recentMonitorPacksToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.recentMonitorPacksToolStripMenuItem.Text = "Recent monitor packs";
            this.recentMonitorPacksToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRecentFiles_Click);
            // 
            // toolStripButtonConfigPack
            // 
            this.toolStripButtonConfigPack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConfigPack.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureCollectorToolStripMenuItem1});
            this.toolStripButtonConfigPack.Image = global::QuickMon.Properties.Resources.QEdit3;
            this.toolStripButtonConfigPack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConfigPack.Name = "toolStripButtonConfigPack";
            this.toolStripButtonConfigPack.Size = new System.Drawing.Size(48, 36);
            this.toolStripButtonConfigPack.Text = "Configure Monitor Pack";
            this.toolStripButtonConfigPack.ButtonClick += new System.EventHandler(this.toolStripButtonConfigPack_Click);
            // 
            // configureCollectorToolStripMenuItem1
            // 
            this.configureCollectorToolStripMenuItem1.Enabled = false;
            this.configureCollectorToolStripMenuItem1.Name = "configureCollectorToolStripMenuItem1";
            this.configureCollectorToolStripMenuItem1.Size = new System.Drawing.Size(193, 24);
            this.configureCollectorToolStripMenuItem1.Text = "Configure collector";
            this.configureCollectorToolStripMenuItem1.Click += new System.EventHandler(this.configureCollectorToolStripMenuItem_Click);
            // 
            // toolStripButtonNotifiers
            // 
            this.toolStripButtonNotifiers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNotifiers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllNotifiersToolStripMenuItem});
            this.toolStripButtonNotifiers.Image = global::QuickMon.Properties.Resources.MegaPhone;
            this.toolStripButtonNotifiers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNotifiers.Name = "toolStripButtonNotifiers";
            this.toolStripButtonNotifiers.Size = new System.Drawing.Size(48, 36);
            this.toolStripButtonNotifiers.Text = "Notifiers";
            this.toolStripButtonNotifiers.ToolTipText = "View default notifier or list of all notifiers";
            this.toolStripButtonNotifiers.ButtonClick += new System.EventHandler(this.toolStripButtonNotifiers_Click);
            // 
            // showAllNotifiersToolStripMenuItem
            // 
            this.showAllNotifiersToolStripMenuItem.Name = "showAllNotifiersToolStripMenuItem";
            this.showAllNotifiersToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.showAllNotifiersToolStripMenuItem.Text = "Show all notifiers";
            this.showAllNotifiersToolStripMenuItem.Click += new System.EventHandler(this.notifiersToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::QuickMon.Properties.Resources.doc_refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
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
            // toolStripButtonOptions
            // 
            this.toolStripButtonOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOptions.Image = global::QuickMon.Properties.Resources.tools;
            this.toolStripButtonOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOptions.Name = "toolStripButtonOptions";
            this.toolStripButtonOptions.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonOptions.Text = "Application Options";
            this.toolStripButtonOptions.Click += new System.EventHandler(this.toolStripButtonOptions_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastUpdateToolStripStatusLabel,
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(374, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lastUpdateToolStripStatusLabel
            // 
            this.lastUpdateToolStripStatusLabel.Name = "lastUpdateToolStripStatusLabel";
            this.lastUpdateToolStripStatusLabel.Size = new System.Drawing.Size(12, 19);
            this.lastUpdateToolStripStatusLabel.Text = ".";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(347, 19);
            this.toolStripStatusLabelStatus.Spring = true;
            this.toolStripStatusLabelStatus.Text = ".";
            this.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvwCollectors
            // 
            this.tvwCollectors.ContextMenuStrip = this.contextMenuStriptvw;
            this.tvwCollectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCollectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCollectors.ImageIndex = 0;
            this.tvwCollectors.ImageList = this.imageList1;
            this.tvwCollectors.Location = new System.Drawing.Point(0, 39);
            this.tvwCollectors.Name = "tvwCollectors";
            treeNode1.Name = "root";
            treeNode1.Text = "Collectors";
            this.tvwCollectors.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvwCollectors.SelectedImageIndex = 0;
            this.tvwCollectors.ShowRootLines = false;
            this.tvwCollectors.Size = new System.Drawing.Size(374, 312);
            this.tvwCollectors.TabIndex = 0;
            this.tvwCollectors.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwCollectors_BeforeCollapse);
            this.tvwCollectors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCollectors_AfterSelect);
            this.tvwCollectors.DoubleClick += new System.EventHandler(this.tvwCollectors_DoubleClick);
            // 
            // contextMenuStriptvw
            // 
            this.contextMenuStriptvw.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.disableCollectorToolStripMenuItem,
            this.configureCollectorToolStripMenuItem,
            this.toolStripMenuItem2,
            this.notifiersToolStripMenuItem,
            this.defaultNotifierViewerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.disablePollingToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.systemToolStripMenuItem});
            this.contextMenuStriptvw.Name = "contextMenuStriptvw";
            this.contextMenuStriptvw.Size = new System.Drawing.Size(217, 230);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Enabled = false;
            this.showDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDetailsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.search;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.showDetailsToolStripMenuItem.Text = "Show details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // disableCollectorToolStripMenuItem
            // 
            this.disableCollectorToolStripMenuItem.Enabled = false;
            this.disableCollectorToolStripMenuItem.Name = "disableCollectorToolStripMenuItem";
            this.disableCollectorToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.disableCollectorToolStripMenuItem.Text = "Disable collector";
            this.disableCollectorToolStripMenuItem.Click += new System.EventHandler(this.disableCollectorToolStripMenuItem_Click);
            // 
            // configureCollectorToolStripMenuItem
            // 
            this.configureCollectorToolStripMenuItem.Enabled = false;
            this.configureCollectorToolStripMenuItem.Image = global::QuickMon.Properties.Resources.QEdit3;
            this.configureCollectorToolStripMenuItem.Name = "configureCollectorToolStripMenuItem";
            this.configureCollectorToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.configureCollectorToolStripMenuItem.Text = "Configure collector";
            this.configureCollectorToolStripMenuItem.Click += new System.EventHandler(this.configureCollectorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // notifiersToolStripMenuItem
            // 
            this.notifiersToolStripMenuItem.Image = global::QuickMon.Properties.Resources.MegaPhone;
            this.notifiersToolStripMenuItem.Name = "notifiersToolStripMenuItem";
            this.notifiersToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.notifiersToolStripMenuItem.Text = "Notifiers";
            this.notifiersToolStripMenuItem.Click += new System.EventHandler(this.notifiersToolStripMenuItem_Click);
            // 
            // defaultNotifierViewerToolStripMenuItem
            // 
            this.defaultNotifierViewerToolStripMenuItem.Enabled = false;
            this.defaultNotifierViewerToolStripMenuItem.Name = "defaultNotifierViewerToolStripMenuItem";
            this.defaultNotifierViewerToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.defaultNotifierViewerToolStripMenuItem.Text = "Default notifier viewer ";
            this.defaultNotifierViewerToolStripMenuItem.Click += new System.EventHandler(this.defaultNotifierViewerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // disablePollingToolStripMenuItem
            // 
            this.disablePollingToolStripMenuItem.Name = "disablePollingToolStripMenuItem";
            this.disablePollingToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.disablePollingToolStripMenuItem.Text = "Disable polling";
            this.disablePollingToolStripMenuItem.Click += new System.EventHandler(this.disablePollingToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMonitorPackToolStripMenuItem,
            this.recentMonitorPackFilesToolStripMenuItem,
            this.configureMonitorPackToolStripMenuItem,
            this.applicationOptionsToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // loadMonitorPackToolStripMenuItem
            // 
            this.loadMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder;
            this.loadMonitorPackToolStripMenuItem.Name = "loadMonitorPackToolStripMenuItem";
            this.loadMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.loadMonitorPackToolStripMenuItem.Text = "Load Monitor pack";
            this.loadMonitorPackToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
            // 
            // recentMonitorPackFilesToolStripMenuItem
            // 
            this.recentMonitorPackFilesToolStripMenuItem.Image = global::QuickMon.Properties.Resources.folder_favor;
            this.recentMonitorPackFilesToolStripMenuItem.Name = "recentMonitorPackFilesToolStripMenuItem";
            this.recentMonitorPackFilesToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.recentMonitorPackFilesToolStripMenuItem.Text = "Recent Monitor pack files";
            this.recentMonitorPackFilesToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRecentFiles_Click);
            // 
            // configureMonitorPackToolStripMenuItem
            // 
            this.configureMonitorPackToolStripMenuItem.Image = global::QuickMon.Properties.Resources.QEdit3;
            this.configureMonitorPackToolStripMenuItem.Name = "configureMonitorPackToolStripMenuItem";
            this.configureMonitorPackToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.configureMonitorPackToolStripMenuItem.Text = "Configure Monitor pack";
            this.configureMonitorPackToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonConfigPack_Click);
            // 
            // applicationOptionsToolStripMenuItem
            // 
            this.applicationOptionsToolStripMenuItem.Image = global::QuickMon.Properties.Resources.tools;
            this.applicationOptionsToolStripMenuItem.Name = "applicationOptionsToolStripMenuItem";
            this.applicationOptionsToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.applicationOptionsToolStripMenuItem.Text = "Application Options";
            this.applicationOptionsToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonOptions_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "23_6.ico");
            this.imageList1.Images.SetKeyName(1, "bullet_ball_glass_blue.ico");
            this.imageList1.Images.SetKeyName(2, "bullet_ball_glass_green.ico");
            this.imageList1.Images.SetKeyName(3, "bullet_ball_glass_yellow.ico");
            this.imageList1.Images.SetKeyName(4, "bullet_ball_glass_red.ico");
            this.imageList1.Images.SetKeyName(5, "205_1.ico");
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
            // timerAppIconRefresher
            // 
            this.timerAppIconRefresher.Enabled = true;
            this.timerAppIconRefresher.Interval = 5557;
            this.timerAppIconRefresher.Tick += new System.EventHandler(this.timerAppIconRefresher_Tick);
            // 
            // backgroundWorkerRefresh
            // 
            this.backgroundWorkerRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRefresh_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 375);
            this.Controls.Add(this.tvwCollectors);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.Text = "Quick Monitor 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStriptvw.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private TreeViewEx tvwCollectors;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStriptvw;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.Timer timerAppIconRefresher;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRefresh;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disablePollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureMonitorPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem notifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultNotifierViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lastUpdateToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem recentMonitorPackFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureCollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton infoToolStripButton;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonNotifiers;
        private System.Windows.Forms.ToolStripMenuItem showAllNotifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonConfigPack;
        private System.Windows.Forms.ToolStripMenuItem configureCollectorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonLoad;
        private System.Windows.Forms.ToolStripMenuItem recentMonitorPacksToolStripMenuItem;
    }
}

