namespace QuickMon.Management
{
    partial class SelectNotifierCollectors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectNotifierCollectors));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lvwCollectors = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.allLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(367, 276);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(286, 276);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lvwCollectors
            // 
            this.lvwCollectors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCollectors.CheckBoxes = true;
            this.lvwCollectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderType});
            this.lvwCollectors.FullRowSelect = true;
            this.lvwCollectors.HideSelection = false;
            this.lvwCollectors.Location = new System.Drawing.Point(2, 2);
            this.lvwCollectors.MultiSelect = false;
            this.lvwCollectors.Name = "lvwCollectors";
            this.lvwCollectors.Size = new System.Drawing.Size(453, 268);
            this.lvwCollectors.SmallImageList = this.imageList1;
            this.lvwCollectors.TabIndex = 0;
            this.lvwCollectors.UseCompatibleStateImageBehavior = false;
            this.lvwCollectors.View = System.Windows.Forms.View.Details;
            this.lvwCollectors.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwCollectors_ItemChecked);
            this.lvwCollectors.Resize += new System.EventHandler(this.lvwCollectors_Resize);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Collector name";
            this.columnHeaderName.Width = 274;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 152;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "4_18.ico");
            this.imageList1.Images.SetKeyName(1, "find.png");
            this.imageList1.Images.SetKeyName(2, "document_pencil_16.png");
            this.imageList1.Images.SetKeyName(3, "125_30.ico");
            this.imageList1.Images.SetKeyName(4, "403_9.ico");
            this.imageList1.Images.SetKeyName(5, "bookmarks.ico");
            this.imageList1.Images.SetKeyName(6, "205_1.ico");
            // 
            // allLinkLabel
            // 
            this.allLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.allLinkLabel.AutoSize = true;
            this.allLinkLabel.Location = new System.Drawing.Point(12, 281);
            this.allLinkLabel.Name = "allLinkLabel";
            this.allLinkLabel.Size = new System.Drawing.Size(18, 13);
            this.allLinkLabel.TabIndex = 1;
            this.allLinkLabel.TabStop = true;
            this.allLinkLabel.Text = "All";
            this.allLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.allLinkLabel_LinkClicked);
            // 
            // SelectNotifierCollectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 311);
            this.Controls.Add(this.allLinkLabel);
            this.Controls.Add(this.lvwCollectors);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "SelectNotifierCollectors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Notifier Collectors";
            this.Shown += new System.EventHandler(this.SelectNotifierCollectors_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ListView lvwCollectors;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.LinkLabel allLinkLabel;
    }
}