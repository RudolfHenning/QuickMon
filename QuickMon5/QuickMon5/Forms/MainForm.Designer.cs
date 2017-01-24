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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("COLLECTORS");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.recentMonitorPacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.collectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.pollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.remoteHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(538, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(538, 344);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageListTreeView;
            this.treeView1.Location = new System.Drawing.Point(0, 33);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "COLLECTORS";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(432, 311);
            this.treeView1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImage = global::QuickMon5.Properties.Resources.QuickMon5Background1;
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1MinSize = 37;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(432, 33);
            this.splitContainer2.SplitterDistance = 44;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer3.Panel1.Controls.Add(this.linkLabel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer3.Panel2.Controls.Add(this.button3);
            this.splitContainer3.Panel2.Controls.Add(this.button2);
            this.splitContainer3.Size = new System.Drawing.Size(387, 33);
            this.splitContainer3.SplitterDistance = 309;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(309, 33);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "<New Monitor Pack>";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImage = global::QuickMon5.Properties.Resources.QuickMon5Background2;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(105, 344);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripButton4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton4.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton4.Image = global::QuickMon5.Properties.Resources.menu_alt_16b1;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(104, 33);
            this.toolStripButton4.Text = "Menu";
            this.toolStripButton4.ToolTipText = "Menu (CTRL + M)";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::QuickMon5.Properties.Resources.doc_new;
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(102, 36);
            this.toolStripButton1.Text = "New";
            this.toolStripButton1.ToolTipText = "New (CTRL + N)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recentMonitorPacksToolStripMenuItem});
            this.toolStripButton2.Image = global::QuickMon5.Properties.Resources.folderOpen;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(102, 36);
            this.toolStripButton2.Text = "Open";
            this.toolStripButton2.ToolTipText = "Open (CTRL + O)";
            // 
            // recentMonitorPacksToolStripMenuItem
            // 
            this.recentMonitorPacksToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.folderWLightning;
            this.recentMonitorPacksToolStripMenuItem.Name = "recentMonitorPacksToolStripMenuItem";
            this.recentMonitorPacksToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.recentMonitorPacksToolStripMenuItem.Text = "Recent Monitor Packs";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.toolStripButton3.Image = global::QuickMon5.Properties.Resources.save;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(102, 36);
            this.toolStripButton3.Text = "Save";
            this.toolStripButton3.ToolTipText = "Save (CTRL + S)";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.save;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectorsToolStripMenuItem,
            this.notifiersToolStripMenuItem});
            this.toolStripButton5.Image = global::QuickMon5.Properties.Resources.cubes3;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(102, 36);
            this.toolStripButton5.Text = "Agents";
            // 
            // collectorsToolStripMenuItem
            // 
            this.collectorsToolStripMenuItem.Name = "collectorsToolStripMenuItem";
            this.collectorsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.collectorsToolStripMenuItem.Text = "Collectors";
            // 
            // notifiersToolStripMenuItem
            // 
            this.notifiersToolStripMenuItem.Name = "notifiersToolStripMenuItem";
            this.notifiersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.notifiersToolStripMenuItem.Text = "Notifiers";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingToolStripMenuItem,
            this.templatesToolStripMenuItem,
            this.adminModeToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::QuickMon5.Properties.Resources.clock;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(102, 36);
            this.toolStripSplitButton1.Text = "Settings";
            this.toolStripSplitButton1.ToolTipText = "Settings (CTRL + E)";
            // 
            // pollingToolStripMenuItem
            // 
            this.pollingToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.clock;
            this.pollingToolStripMenuItem.Name = "pollingToolStripMenuItem";
            this.pollingToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.pollingToolStripMenuItem.Text = "Polling";
            // 
            // templatesToolStripMenuItem
            // 
            this.templatesToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.tables;
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            this.templatesToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.templatesToolStripMenuItem.Text = "Templates";
            // 
            // adminModeToolStripMenuItem
            // 
            this.adminModeToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.OUTLLIBR_9825;
            this.adminModeToolStripMenuItem.Name = "adminModeToolStripMenuItem";
            this.adminModeToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.adminModeToolStripMenuItem.Text = "Admin Mode";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteHostsToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::QuickMon5.Properties.Resources.info;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(102, 36);
            this.toolStripSplitButton2.Text = "About";
            // 
            // remoteHostsToolStripMenuItem
            // 
            this.remoteHostsToolStripMenuItem.Image = global::QuickMon5.Properties.Resources.remote;
            this.remoteHostsToolStripMenuItem.Name = "remoteHostsToolStripMenuItem";
            this.remoteHostsToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.remoteHostsToolStripMenuItem.Text = "Remote Hosts";
            this.remoteHostsToolStripMenuItem.ToolTipText = "Remote Hosts (CTRL + H)";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::QuickMon5.Properties.Resources.menu_alt_16b1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 33);
            this.button1.TabIndex = 2;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.button1, "Menu (CTRL + M)");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            this.button3.Location = new System.Drawing.Point(7, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 33);
            this.button3.TabIndex = 4;
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
            this.button2.Location = new System.Drawing.Point(42, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 33);
            this.button2.TabIndex = 3;
            this.toolTip1.SetToolTip(this.button2, "Recent Monitor Packs");
            this.button2.UseVisualStyleBackColor = false;
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "folder_32a.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 366);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "QuickMon 5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton2;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem recentMonitorPacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton5;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem collectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem remoteHostsToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListTreeView;
    }
}

