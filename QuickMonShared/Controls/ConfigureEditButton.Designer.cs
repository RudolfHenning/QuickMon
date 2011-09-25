namespace QuickMon.Controls
{
    partial class ConfigureEditButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdConfigure = new System.Windows.Forms.Button();
            this.contextMenuStripButton = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.manualConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromExistingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDropDown = new System.Windows.Forms.Button();
            this.contextMenuStripButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdConfigure
            // 
            this.cmdConfigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdConfigure.FlatAppearance.BorderSize = 0;
            this.cmdConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConfigure.Location = new System.Drawing.Point(0, 0);
            this.cmdConfigure.Name = "cmdConfigure";
            this.cmdConfigure.Size = new System.Drawing.Size(67, 22);
            this.cmdConfigure.TabIndex = 0;
            this.cmdConfigure.Text = "Configure";
            this.cmdConfigure.UseVisualStyleBackColor = true;
            this.cmdConfigure.Click += new System.EventHandler(this.cmdConfigure_Click);
            // 
            // contextMenuStripButton
            // 
            this.contextMenuStripButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualConfigurationToolStripMenuItem,
            this.importFromExistingToolStripMenuItem});
            this.contextMenuStripButton.Name = "contextMenuStripButton";
            this.contextMenuStripButton.Size = new System.Drawing.Size(222, 48);
            // 
            // manualConfigurationToolStripMenuItem
            // 
            this.manualConfigurationToolStripMenuItem.Name = "manualConfigurationToolStripMenuItem";
            this.manualConfigurationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.manualConfigurationToolStripMenuItem.Text = "Manually edit configuration";
            this.manualConfigurationToolStripMenuItem.Click += new System.EventHandler(this.manualConfigurationToolStripMenuItem_Click);
            // 
            // importFromExistingToolStripMenuItem
            // 
            this.importFromExistingToolStripMenuItem.Name = "importFromExistingToolStripMenuItem";
            this.importFromExistingToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.importFromExistingToolStripMenuItem.Text = "Import from existing";
            this.importFromExistingToolStripMenuItem.Click += new System.EventHandler(this.importFromExistingToolStripMenuItem_Click);
            // 
            // cmdDropDown
            // 
            this.cmdDropDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdDropDown.FlatAppearance.BorderSize = 0;
            this.cmdDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDropDown.Font = new System.Drawing.Font("Wingdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(3)));
            this.cmdDropDown.Location = new System.Drawing.Point(67, 0);
            this.cmdDropDown.Name = "cmdDropDown";
            this.cmdDropDown.Size = new System.Drawing.Size(19, 22);
            this.cmdDropDown.TabIndex = 1;
            this.cmdDropDown.Text = "Ú";
            this.cmdDropDown.UseVisualStyleBackColor = true;
            this.cmdDropDown.Click += new System.EventHandler(this.cmdDropDown_Click);
            // 
            // ConfigureEditButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdConfigure);
            this.Controls.Add(this.cmdDropDown);
            this.Name = "ConfigureEditButton";
            this.Size = new System.Drawing.Size(86, 22);
            this.contextMenuStripButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdDropDown;
        private System.Windows.Forms.Button cmdConfigure;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripButton;
        private System.Windows.Forms.ToolStripMenuItem manualConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromExistingToolStripMenuItem;


    }
}
