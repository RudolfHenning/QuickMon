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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lvwPerfCounters = new System.Windows.Forms.ListView();
            this.columnHeaderPerfCounter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarning = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCloneComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.timerCheckButtonEnabled = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(431, 287);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(350, 287);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lvwPerfCounters
            // 
            this.lvwPerfCounters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPerfCounters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPerfCounter,
            this.columnHeaderWarning,
            this.columnHeaderError});
            this.lvwPerfCounters.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwPerfCounters.FullRowSelect = true;
            this.lvwPerfCounters.Location = new System.Drawing.Point(0, 37);
            this.lvwPerfCounters.Name = "lvwPerfCounters";
            this.lvwPerfCounters.Size = new System.Drawing.Size(518, 244);
            this.lvwPerfCounters.TabIndex = 12;
            this.lvwPerfCounters.UseCompatibleStateImageBehavior = false;
            this.lvwPerfCounters.View = System.Windows.Forms.View.Details;
            this.lvwPerfCounters.SelectedIndexChanged += new System.EventHandler(this.lvwPerfCounters_SelectedIndexChanged);
            this.lvwPerfCounters.DoubleClick += new System.EventHandler(this.editToolStripButton_Click);
            this.lvwPerfCounters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwPerfCounters_KeyUp);
            // 
            // columnHeaderPerfCounter
            // 
            this.columnHeaderPerfCounter.Text = "Perf. Counter";
            this.columnHeaderPerfCounter.Width = 316;
            // 
            // columnHeaderWarning
            // 
            this.columnHeaderWarning.Text = "Warning";
            this.columnHeaderWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderWarning.Width = 86;
            // 
            // columnHeaderError
            // 
            this.columnHeaderError.Text = "Error";
            this.columnHeaderError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderError.Width = 84;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addCloneComputerToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 100);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // addCloneComputerToolStripMenuItem
            // 
            this.addCloneComputerToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_add;
            this.addCloneComputerToolStripMenuItem.Name = "addCloneComputerToolStripMenuItem";
            this.addCloneComputerToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.addCloneComputerToolStripMenuItem.Text = "Add - Same computer";
            this.addCloneComputerToolStripMenuItem.Click += new System.EventHandler(this.addCloneComputerToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_remove;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripButton_Click);
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
            this.toolStrip1.Size = new System.Drawing.Size(518, 39);
            this.toolStrip1.TabIndex = 13;
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
            // timerCheckButtonEnabled
            // 
            this.timerCheckButtonEnabled.Interval = 200;
            this.timerCheckButtonEnabled.Tick += new System.EventHandler(this.timerCheckButtonEnabled_Tick);
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(518, 322);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvwPerfCounters);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.Load += new System.EventHandler(this.EditConfig_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ListView lvwPerfCounters;
        private System.Windows.Forms.ColumnHeader columnHeaderPerfCounter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ColumnHeader columnHeaderWarning;
        private System.Windows.Forms.ColumnHeader columnHeaderError;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Timer timerCheckButtonEnabled;
        private System.Windows.Forms.ToolStripMenuItem addCloneComputerToolStripMenuItem;
    }
}