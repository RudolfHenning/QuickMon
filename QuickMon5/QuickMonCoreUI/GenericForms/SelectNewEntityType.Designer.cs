namespace QuickMon.UI
{
    partial class SelectNewEntityType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectNewEntityType));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkShowCustomConfig = new System.Windows.Forms.CheckBox();
            this.cmdSkip = new System.Windows.Forms.Button();
            this.chkEditAfterCreate = new System.Windows.Forms.CheckBox();
            this.lvwAgentType = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(412, 332);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
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
            this.cmdOK.Location = new System.Drawing.Point(331, 332);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "Select";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkShowCustomConfig
            // 
            this.chkShowCustomConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowCustomConfig.AutoSize = true;
            this.chkShowCustomConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowCustomConfig.Location = new System.Drawing.Point(127, 335);
            this.chkShowCustomConfig.Name = "chkShowCustomConfig";
            this.chkShowCustomConfig.Size = new System.Drawing.Size(148, 17);
            this.chkShowCustomConfig.TabIndex = 2;
            this.chkShowCustomConfig.Text = "Show custom config editor";
            this.chkShowCustomConfig.UseVisualStyleBackColor = true;
            // 
            // cmdSkip
            // 
            this.cmdSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSkip.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdSkip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSkip.Location = new System.Drawing.Point(493, 332);
            this.cmdSkip.Name = "cmdSkip";
            this.cmdSkip.Size = new System.Drawing.Size(75, 23);
            this.cmdSkip.TabIndex = 5;
            this.cmdSkip.Text = "Skip";
            this.cmdSkip.UseVisualStyleBackColor = true;
            this.cmdSkip.Click += new System.EventHandler(this.cmdSkip_Click);
            // 
            // chkEditAfterCreate
            // 
            this.chkEditAfterCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEditAfterCreate.AutoSize = true;
            this.chkEditAfterCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEditAfterCreate.Location = new System.Drawing.Point(12, 335);
            this.chkEditAfterCreate.Name = "chkEditAfterCreate";
            this.chkEditAfterCreate.Size = new System.Drawing.Size(106, 17);
            this.chkEditAfterCreate.TabIndex = 1;
            this.chkEditAfterCreate.Text = "Edit after creation";
            this.chkEditAfterCreate.UseVisualStyleBackColor = true;
            // 
            // lvwAgentType
            // 
            this.lvwAgentType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAgentType.AutoResizeColumnEnabled = false;
            this.lvwAgentType.AutoResizeColumnIndex = 1;
            this.lvwAgentType.BackgroundImage = global::QuickMon.Properties.Resources.LongBlueShadeHorisontal;
            this.lvwAgentType.BackgroundImageTiled = true;
            this.lvwAgentType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.detailsColumnHeader});
            this.lvwAgentType.FullRowSelect = true;
            this.lvwAgentType.HideSelection = false;
            this.lvwAgentType.Location = new System.Drawing.Point(-1, 3);
            this.lvwAgentType.MultiSelect = false;
            this.lvwAgentType.Name = "lvwAgentType";
            this.lvwAgentType.Size = new System.Drawing.Size(574, 323);
            this.lvwAgentType.TabIndex = 0;
            this.lvwAgentType.UseCompatibleStateImageBehavior = false;
            this.lvwAgentType.View = System.Windows.Forms.View.Details;
            this.lvwAgentType.SelectedIndexChanged += new System.EventHandler(this.lvwAgentType_SelectedIndexChanged);
            this.lvwAgentType.DoubleClick += new System.EventHandler(this.lvwAgentType_DoubleClick);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 213;
            // 
            // detailsColumnHeader
            // 
            this.detailsColumnHeader.Text = "Details";
            this.detailsColumnHeader.Width = 264;
            // 
            // SelectNewEntityType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(576, 367);
            this.Controls.Add(this.chkEditAfterCreate);
            this.Controls.Add(this.cmdSkip);
            this.Controls.Add(this.chkShowCustomConfig);
            this.Controls.Add(this.lvwAgentType);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectNewEntityType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select New Type";
            this.Load += new System.EventHandler(this.SelectNewEntityType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private ListViewEx lvwAgentType;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader detailsColumnHeader;
        private System.Windows.Forms.CheckBox chkShowCustomConfig;
        private System.Windows.Forms.Button cmdSkip;
        private System.Windows.Forms.CheckBox chkEditAfterCreate;
    }
}