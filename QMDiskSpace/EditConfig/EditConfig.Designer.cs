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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditConfig));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lvwDrives = new System.Windows.Forms.ListView();
            this.columnHeaderLetter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarningSizeLeftMB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderErrorSizeLeftMB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarnNotAvailable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(472, 221);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(472, 192);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemove.Enabled = false;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemove.Location = new System.Drawing.Point(472, 70);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 3;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Enabled = false;
            this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEdit.Location = new System.Drawing.Point(472, 41);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(472, 12);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lvwDrives
            // 
            this.lvwDrives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDrives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLetter,
            this.columnHeaderWarningSizeLeftMB,
            this.columnHeaderErrorSizeLeftMB,
            this.columnHeaderWarnNotAvailable});
            this.lvwDrives.FullRowSelect = true;
            this.lvwDrives.HideSelection = false;
            this.lvwDrives.Location = new System.Drawing.Point(0, 0);
            this.lvwDrives.Name = "lvwDrives";
            this.lvwDrives.Size = new System.Drawing.Size(466, 244);
            this.lvwDrives.TabIndex = 0;
            this.lvwDrives.UseCompatibleStateImageBehavior = false;
            this.lvwDrives.View = System.Windows.Forms.View.Details;
            this.lvwDrives.SelectedIndexChanged += new System.EventHandler(this.lvwHosts_SelectedIndexChanged);
            this.lvwDrives.DoubleClick += new System.EventHandler(this.cmdEdit_Click);
            // 
            // columnHeaderLetter
            // 
            this.columnHeaderLetter.Text = "Drive letter";
            this.columnHeaderLetter.Width = 89;
            // 
            // columnHeaderWarningSizeLeftMB
            // 
            this.columnHeaderWarningSizeLeftMB.Text = "Warning size left (MB)";
            this.columnHeaderWarningSizeLeftMB.Width = 123;
            // 
            // columnHeaderErrorSizeLeftMB
            // 
            this.columnHeaderErrorSizeLeftMB.Text = "Error size left (MB)";
            this.columnHeaderErrorSizeLeftMB.Width = 105;
            // 
            // columnHeaderWarnNotAvailable
            // 
            this.columnHeaderWarnNotAvailable.Text = "Warn on not available";
            this.columnHeaderWarnNotAvailable.Width = 120;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 247);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(559, 269);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lvwDrives);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListView lvwDrives;
        private System.Windows.Forms.ColumnHeader columnHeaderLetter;
        private System.Windows.Forms.ColumnHeader columnHeaderWarningSizeLeftMB;
        private System.Windows.Forms.ColumnHeader columnHeaderErrorSizeLeftMB;
        private System.Windows.Forms.ColumnHeader columnHeaderWarnNotAvailable;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}