namespace QuickMon.Forms
{
    partial class SelectNewAgentType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectNewAgentType));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.llblExtraAgents = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optSelectPreset = new System.Windows.Forms.RadioButton();
            this.optShowConfigEditor = new System.Windows.Forms.RadioButton();
            this.chkShowCustomConfig = new System.Windows.Forms.CheckBox();
            this.lvwAgentType = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkShowDetails = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(427, 387);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(346, 387);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // llblExtraAgents
            // 
            this.llblExtraAgents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblExtraAgents.AutoSize = true;
            this.llblExtraAgents.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblExtraAgents.Location = new System.Drawing.Point(12, 392);
            this.llblExtraAgents.Name = "llblExtraAgents";
            this.llblExtraAgents.Size = new System.Drawing.Size(318, 13);
            this.llblExtraAgents.TabIndex = 4;
            this.llblExtraAgents.TabStop = true;
            this.llblExtraAgents.Text = "Please see https://quickmon.codeplex.com/ for more Agent types";
            this.llblExtraAgents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblExtraAgents_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.optSelectPreset);
            this.groupBox1.Controls.Add(this.optShowConfigEditor);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "How to choose Agent";
            // 
            // optSelectPreset
            // 
            this.optSelectPreset.AutoSize = true;
            this.optSelectPreset.Checked = true;
            this.optSelectPreset.Location = new System.Drawing.Point(20, 19);
            this.optSelectPreset.Name = "optSelectPreset";
            this.optSelectPreset.Size = new System.Drawing.Size(84, 17);
            this.optSelectPreset.TabIndex = 0;
            this.optSelectPreset.TabStop = true;
            this.optSelectPreset.Text = "By Template";
            this.optSelectPreset.UseVisualStyleBackColor = true;
            this.optSelectPreset.CheckedChanged += new System.EventHandler(this.optSelectPreset_CheckedChanged);
            // 
            // optShowConfigEditor
            // 
            this.optShowConfigEditor.AutoSize = true;
            this.optShowConfigEditor.Location = new System.Drawing.Point(210, 19);
            this.optShowConfigEditor.Name = "optShowConfigEditor";
            this.optShowConfigEditor.Size = new System.Drawing.Size(91, 17);
            this.optShowConfigEditor.TabIndex = 1;
            this.optShowConfigEditor.Text = "By Agent type";
            this.optShowConfigEditor.UseVisualStyleBackColor = true;
            this.optShowConfigEditor.CheckedChanged += new System.EventHandler(this.optShowConfigEditor_CheckedChanged);
            // 
            // chkShowCustomConfig
            // 
            this.chkShowCustomConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowCustomConfig.AutoSize = true;
            this.chkShowCustomConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkShowCustomConfig.Location = new System.Drawing.Point(6, 364);
            this.chkShowCustomConfig.Name = "chkShowCustomConfig";
            this.chkShowCustomConfig.Size = new System.Drawing.Size(218, 17);
            this.chkShowCustomConfig.TabIndex = 2;
            this.chkShowCustomConfig.Text = "Show custom config editor after selection";
            this.chkShowCustomConfig.UseVisualStyleBackColor = true;
            // 
            // lvwAgentType
            // 
            this.lvwAgentType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAgentType.AutoResizeColumnEnabled = false;
            this.lvwAgentType.AutoResizeColumnIndex = 0;
            this.lvwAgentType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.detailsColumnHeader});
            this.lvwAgentType.FullRowSelect = true;
            this.lvwAgentType.HideSelection = false;
            this.lvwAgentType.Location = new System.Drawing.Point(4, 51);
            this.lvwAgentType.MultiSelect = false;
            this.lvwAgentType.Name = "lvwAgentType";
            this.lvwAgentType.Size = new System.Drawing.Size(510, 307);
            this.lvwAgentType.SmallImageList = this.imageList1;
            this.lvwAgentType.TabIndex = 1;
            this.lvwAgentType.UseCompatibleStateImageBehavior = false;
            this.lvwAgentType.View = System.Windows.Forms.View.Details;
            this.lvwAgentType.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwAgentType_EnterKeyPressed);
            this.lvwAgentType.SelectedIndexChanged += new System.EventHandler(this.lvwAgentType_SelectedIndexChanged);
            this.lvwAgentType.DoubleClick += new System.EventHandler(this.cmdOK_Click);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "58.ico");
            this.imageList1.Images.SetKeyName(1, "5_50.ico");
            this.imageList1.Images.SetKeyName(2, "59.ico");
            // 
            // chkShowDetails
            // 
            this.chkShowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowDetails.AutoSize = true;
            this.chkShowDetails.Location = new System.Drawing.Point(416, 364);
            this.chkShowDetails.Name = "chkShowDetails";
            this.chkShowDetails.Size = new System.Drawing.Size(86, 17);
            this.chkShowDetails.TabIndex = 3;
            this.chkShowDetails.Text = "Show details";
            this.chkShowDetails.UseVisualStyleBackColor = true;
            this.chkShowDetails.CheckedChanged += new System.EventHandler(this.chkShowDetails_CheckedChanged);
            // 
            // SelectNewAgentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 422);
            this.Controls.Add(this.chkShowDetails);
            this.Controls.Add(this.lvwAgentType);
            this.Controls.Add(this.chkShowCustomConfig);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.llblExtraAgents);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 460);
            this.Name = "SelectNewAgentType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectNewAgentType";
            this.Load += new System.EventHandler(this.SelectNewAgentType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.LinkLabel llblExtraAgents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optSelectPreset;
        private System.Windows.Forms.RadioButton optShowConfigEditor;
        private System.Windows.Forms.CheckBox chkShowCustomConfig;
        private ListViewEx lvwAgentType;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader detailsColumnHeader;
        private System.Windows.Forms.CheckBox chkShowDetails;
        private System.Windows.Forms.ImageList imageList1;
    }
}