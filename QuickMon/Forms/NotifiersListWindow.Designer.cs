namespace QuickMon
{
    partial class NotifiersListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifiersListWindow));
            this.lvwNotifiers = new System.Windows.Forms.ListView();
            this.columnHeaderNotifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwNotifiers
            // 
            this.lvwNotifiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNotifier});
            this.lvwNotifiers.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwNotifiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwNotifiers.FullRowSelect = true;
            this.lvwNotifiers.Location = new System.Drawing.Point(0, 0);
            this.lvwNotifiers.Name = "lvwNotifiers";
            this.lvwNotifiers.Size = new System.Drawing.Size(284, 262);
            this.lvwNotifiers.TabIndex = 0;
            this.lvwNotifiers.UseCompatibleStateImageBehavior = false;
            this.lvwNotifiers.View = System.Windows.Forms.View.Details;
            this.lvwNotifiers.SelectedIndexChanged += new System.EventHandler(this.lvwNotifiers_SelectedIndexChanged);
            this.lvwNotifiers.DoubleClick += new System.EventHandler(this.openViewerToolStripMenuItem_Click);
            // 
            // columnHeaderNotifier
            // 
            this.columnHeaderNotifier.Text = "Notifier";
            this.columnHeaderNotifier.Width = 255;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openViewerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 28);
            // 
            // openViewerToolStripMenuItem
            // 
            this.openViewerToolStripMenuItem.Enabled = false;
            this.openViewerToolStripMenuItem.Name = "openViewerToolStripMenuItem";
            this.openViewerToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.openViewerToolStripMenuItem.Text = "Open viewer";
            this.openViewerToolStripMenuItem.Click += new System.EventHandler(this.openViewerToolStripMenuItem_Click);
            // 
            // NotifiersListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lvwNotifiers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "NotifiersListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifier List";
            this.Shown += new System.EventHandler(this.NotifiersListWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotifiersListWindow_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwNotifiers;
        private System.Windows.Forms.ColumnHeader columnHeaderNotifier;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openViewerToolStripMenuItem;
    }
}