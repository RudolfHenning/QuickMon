namespace QuickMon
{
    partial class EditConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConfig));
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwTables = new System.Windows.Forms.ListView();
            this.tableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTables = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdOK = new System.Windows.Forms.Button();
            this.timerCheckButtonEnabled = new System.Windows.Forms.Timer(this.components);
            this.columnResizeTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(528, 337);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.editToolStripButton,
            this.removeToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(615, 39);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = global::QuickMon.Properties.Resources.doc_add;
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.addToolStripButton.Text = "Add";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Enabled = false;
            this.editToolStripButton.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.editToolStripButton.Text = "Edit";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolStripButton.Enabled = false;
            this.removeToolStripButton.Image = global::QuickMon.Properties.Resources.doc_remove;
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.removeToolStripButton.Text = "Remove";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // lvwTables
            // 
            this.lvwTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tableColumnHeader,
            this.columnHeaderTables});
            this.lvwTables.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwTables.FullRowSelect = true;
            this.lvwTables.Location = new System.Drawing.Point(0, 42);
            this.lvwTables.Name = "lvwTables";
            this.lvwTables.Size = new System.Drawing.Size(615, 289);
            this.lvwTables.TabIndex = 16;
            this.lvwTables.UseCompatibleStateImageBehavior = false;
            this.lvwTables.View = System.Windows.Forms.View.Details;
            this.lvwTables.SelectedIndexChanged += new System.EventHandler(this.lvwTables_SelectedIndexChanged);
            this.lvwTables.DoubleClick += new System.EventHandler(this.editToolStripButton_Click);
            this.lvwTables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwTables_KeyDown);
            this.lvwTables.Resize += new System.EventHandler(this.lvwTables_Resize);
            // 
            // tableColumnHeader
            // 
            this.tableColumnHeader.Text = "Server\\Database";
            this.tableColumnHeader.Width = 418;
            // 
            // columnHeaderTables
            // 
            this.columnHeaderTables.Text = "Tables";
            this.columnHeaderTables.Width = 86;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 76);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(447, 337);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // timerCheckButtonEnabled
            // 
            this.timerCheckButtonEnabled.Interval = 200;
            this.timerCheckButtonEnabled.Tick += new System.EventHandler(this.timerCheckButtonEnabled_Tick);
            // 
            // columnResizeTimer
            // 
            this.columnResizeTimer.Interval = 200;
            this.columnResizeTimer.Tick += new System.EventHandler(this.columnResizeTimer_Tick);
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(615, 372);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvwTables);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.Shown += new System.EventHandler(this.EditConfig_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ListView lvwTables;
        private System.Windows.Forms.ColumnHeader columnHeaderTables;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Timer timerCheckButtonEnabled;
        private System.Windows.Forms.ColumnHeader tableColumnHeader;
        private System.Windows.Forms.Timer columnResizeTimer;
    }
}