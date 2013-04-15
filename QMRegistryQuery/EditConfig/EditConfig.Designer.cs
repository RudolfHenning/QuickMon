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
            this.columnResizeTimer = new System.Windows.Forms.Timer(this.components);
            this.errorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwQueries = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.warningColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.timerCheckButtonEnabled = new System.Windows.Forms.Timer(this.components);
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.successColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnResizeTimer
            // 
            this.columnResizeTimer.Interval = 200;
            this.columnResizeTimer.Tick += new System.EventHandler(this.columnResizeTimer_Tick);
            // 
            // errorColumnHeader
            // 
            this.errorColumnHeader.Text = "Error";
            this.errorColumnHeader.Width = 82;
            // 
            // lvwQueries
            // 
            this.lvwQueries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwQueries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.columnPath,
            this.columnKey,
            this.successColumnHeader,
            this.warningColumnHeader,
            this.errorColumnHeader});
            this.lvwQueries.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwQueries.FullRowSelect = true;
            this.lvwQueries.Location = new System.Drawing.Point(0, 42);
            this.lvwQueries.Name = "lvwQueries";
            this.lvwQueries.Size = new System.Drawing.Size(710, 251);
            this.lvwQueries.TabIndex = 24;
            this.lvwQueries.UseCompatibleStateImageBehavior = false;
            this.lvwQueries.View = System.Windows.Forms.View.Details;
            this.lvwQueries.SelectedIndexChanged += new System.EventHandler(this.lvwQueries_SelectedIndexChanged);
            this.lvwQueries.DoubleClick += new System.EventHandler(this.editToolStripButton_Click);
            this.lvwQueries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwQueries_KeyDown);
            this.lvwQueries.Resize += new System.EventHandler(this.lvwQueries_Resize);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 119;
            // 
            // columnPath
            // 
            this.columnPath.Text = "Path";
            this.columnPath.Width = 274;
            // 
            // columnKey
            // 
            this.columnKey.Text = "Key";
            this.columnKey.Width = 90;
            // 
            // warningColumnHeader
            // 
            this.warningColumnHeader.Text = "Warning";
            this.warningColumnHeader.Width = 70;
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
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripButton_Click);
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
            this.toolStrip1.Size = new System.Drawing.Size(710, 39);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // timerCheckButtonEnabled
            // 
            this.timerCheckButtonEnabled.Interval = 200;
            this.timerCheckButtonEnabled.Tick += new System.EventHandler(this.timerCheckButtonEnabled_Tick);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(623, 299);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 23;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(542, 299);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 22;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // successColumnHeader
            // 
            this.successColumnHeader.Text = "Success";
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 334);
            this.Controls.Add(this.lvwQueries);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.Shown += new System.EventHandler(this.EditConfig_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer columnResizeTimer;
        private System.Windows.Forms.ColumnHeader errorColumnHeader;
        private System.Windows.Forms.ListView lvwQueries;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Timer timerCheckButtonEnabled;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.ColumnHeader columnKey;
        private System.Windows.Forms.ColumnHeader warningColumnHeader;
        private System.Windows.Forms.ColumnHeader successColumnHeader;
    }
}