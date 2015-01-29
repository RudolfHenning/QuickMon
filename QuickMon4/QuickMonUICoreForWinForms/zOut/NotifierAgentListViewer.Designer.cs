namespace QuickMon.Forms
{
    partial class NotifierAgentListViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifierAgentListViewer));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifiersImageList = new System.Windows.Forms.ImageList(this.components);
            this.lvwAgents = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(55, 6);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(380, 20);
            this.txtName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // notifiersImageList
            // 
            this.notifiersImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("notifiersImageList.ImageStream")));
            this.notifiersImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.notifiersImageList.Images.SetKeyName(0, "SpeakerBW.ico");
            this.notifiersImageList.Images.SetKeyName(1, "SpeakerBlue.ico");
            // 
            // lvwAgents
            // 
            this.lvwAgents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAgents.AutoResizeColumnEnabled = false;
            this.lvwAgents.AutoResizeColumnIndex = 0;
            this.lvwAgents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.typeColumnHeader});
            this.lvwAgents.FullRowSelect = true;
            this.lvwAgents.HideSelection = false;
            this.lvwAgents.Location = new System.Drawing.Point(3, 32);
            this.lvwAgents.Name = "lvwAgents";
            this.lvwAgents.Size = new System.Drawing.Size(443, 198);
            this.lvwAgents.SmallImageList = this.notifiersImageList;
            this.lvwAgents.TabIndex = 5;
            this.lvwAgents.UseCompatibleStateImageBehavior = false;
            this.lvwAgents.View = System.Windows.Forms.View.Details;
            this.lvwAgents.DoubleClick += new System.EventHandler(this.lvwAgents_DoubleClick);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Agent Name";
            this.nameColumnHeader.Width = 206;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 212;
            // 
            // NotifierAgentListViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 233);
            this.Controls.Add(this.lvwAgents);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotifierAgentListViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifier Agent List Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotifierAgentListViewer_FormClosing);
            this.Load += new System.EventHandler(this.NotifierAgentListViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private ListViewEx lvwAgents;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ImageList notifiersImageList;
    }
}