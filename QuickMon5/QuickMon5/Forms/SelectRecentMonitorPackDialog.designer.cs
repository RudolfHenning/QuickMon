namespace QuickMon.UI
{
    partial class SelectRecentMonitorPackDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRecentMonitorPackDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.llblImportMonitorPacks = new System.Windows.Forms.LinkLabel();
            this.llblClearInvalid = new System.Windows.Forms.LinkLabel();
            this.llblResetList = new System.Windows.Forms.LinkLabel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lvwMonitorPacks = new QuickMon.ListViewEx();
            this.pathColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.llblImportMonitorPacks);
            this.panel1.Controls.Add(this.llblClearInvalid);
            this.panel1.Controls.Add(this.llblResetList);
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 50);
            this.panel1.TabIndex = 0;
            // 
            // llblImportMonitorPacks
            // 
            this.llblImportMonitorPacks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblImportMonitorPacks.AutoSize = true;
            this.llblImportMonitorPacks.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblImportMonitorPacks.Location = new System.Drawing.Point(212, 20);
            this.llblImportMonitorPacks.Name = "llblImportMonitorPacks";
            this.llblImportMonitorPacks.Size = new System.Drawing.Size(106, 13);
            this.llblImportMonitorPacks.TabIndex = 12;
            this.llblImportMonitorPacks.TabStop = true;
            this.llblImportMonitorPacks.Text = "Import Monitor packs";
            this.llblImportMonitorPacks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblImportMonitorPacks_LinkClicked);
            // 
            // llblClearInvalid
            // 
            this.llblClearInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblClearInvalid.AutoSize = true;
            this.llblClearInvalid.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblClearInvalid.Location = new System.Drawing.Point(91, 20);
            this.llblClearInvalid.Name = "llblClearInvalid";
            this.llblClearInvalid.Size = new System.Drawing.Size(91, 13);
            this.llblClearInvalid.TabIndex = 11;
            this.llblClearInvalid.TabStop = true;
            this.llblClearInvalid.Text = "Clear invalid items";
            this.llblClearInvalid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClearInvalid_LinkClicked);
            // 
            // llblResetList
            // 
            this.llblResetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblResetList.AutoSize = true;
            this.llblResetList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblResetList.Location = new System.Drawing.Point(12, 20);
            this.llblResetList.Name = "llblResetList";
            this.llblResetList.Size = new System.Drawing.Size(50, 13);
            this.llblResetList.TabIndex = 10;
            this.llblResetList.TabStop = true;
            this.llblResetList.Text = "Reset list";
            this.llblResetList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblResetList_LinkClicked);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(537, 15);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(456, 15);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "Select";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lvwMonitorPacks
            // 
            this.lvwMonitorPacks.AutoResizeColumnEnabled = false;
            this.lvwMonitorPacks.AutoResizeColumnIndex = 0;
            this.lvwMonitorPacks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pathColumnHeader1});
            this.lvwMonitorPacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMonitorPacks.FullRowSelect = true;
            this.lvwMonitorPacks.HideSelection = false;
            this.lvwMonitorPacks.Location = new System.Drawing.Point(0, 0);
            this.lvwMonitorPacks.Name = "lvwMonitorPacks";
            this.lvwMonitorPacks.Size = new System.Drawing.Size(624, 261);
            this.lvwMonitorPacks.TabIndex = 1;
            this.lvwMonitorPacks.UseCompatibleStateImageBehavior = false;
            this.lvwMonitorPacks.View = System.Windows.Forms.View.Details;
            this.lvwMonitorPacks.SelectedIndexChanged += new System.EventHandler(this.lvwMonitorPacks_SelectedIndexChanged);
            this.lvwMonitorPacks.DoubleClick += new System.EventHandler(this.lvwMonitorPacks_DoubleClick);
            this.lvwMonitorPacks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwMonitorPacks_KeyUp);
            // 
            // pathColumnHeader1
            // 
            this.pathColumnHeader1.Text = "Path";
            this.pathColumnHeader1.Width = 582;
            // 
            // SelectRecentMonitorPackDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 311);
            this.Controls.Add(this.lvwMonitorPacks);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 350);
            this.Name = "SelectRecentMonitorPackDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recently opened Monitor Packs";
            this.Load += new System.EventHandler(this.SelectRecentMonitorPackDialog_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SelectRecentMonitorPackDialog_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel llblImportMonitorPacks;
        private System.Windows.Forms.LinkLabel llblClearInvalid;
        private System.Windows.Forms.LinkLabel llblResetList;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private ListViewEx lvwMonitorPacks;
        private System.Windows.Forms.ColumnHeader pathColumnHeader1;
    }
}