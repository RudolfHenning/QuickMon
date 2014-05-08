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
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lvwEntries = new System.Windows.Forms.ListView();
            this.columnHeaderServiceURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMethodName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderParameters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.columnResizeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(529, 294);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(529, 265);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemove.Enabled = false;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemove.Location = new System.Drawing.Point(529, 70);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 10;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Enabled = false;
            this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEdit.Location = new System.Drawing.Point(529, 41);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 9;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(529, 12);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lvwEntries
            // 
            this.lvwEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderServiceURL,
            this.columnHeaderName,
            this.columnHeaderMethodName,
            this.columnHeaderParameters});
            this.lvwEntries.FullRowSelect = true;
            this.lvwEntries.HideSelection = false;
            this.lvwEntries.Location = new System.Drawing.Point(0, 1);
            this.lvwEntries.Name = "lvwEntries";
            this.lvwEntries.Size = new System.Drawing.Size(516, 320);
            this.lvwEntries.TabIndex = 7;
            this.lvwEntries.UseCompatibleStateImageBehavior = false;
            this.lvwEntries.View = System.Windows.Forms.View.Details;
            this.lvwEntries.SelectedIndexChanged += new System.EventHandler(this.lvwEntries_SelectedIndexChanged);
            this.lvwEntries.DoubleClick += new System.EventHandler(this.cmdEdit_Click);
            this.lvwEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwEntries_KeyDown);
            this.lvwEntries.Resize += new System.EventHandler(this.lvwEntries_Resize);
            // 
            // columnHeaderServiceURL
            // 
            this.columnHeaderServiceURL.Text = "Service URL";
            this.columnHeaderServiceURL.Width = 120;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Service name";
            this.columnHeaderName.Width = 90;
            // 
            // columnHeaderMethodName
            // 
            this.columnHeaderMethodName.Text = "Method name";
            this.columnHeaderMethodName.Width = 90;
            // 
            // columnHeaderParameters
            // 
            this.columnHeaderParameters.Text = "Parameters";
            this.columnHeaderParameters.Width = 151;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 324);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // columnResizeTimer
            // 
            this.columnResizeTimer.Tick += new System.EventHandler(this.columnResizeTimer_Tick);
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(616, 346);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lvwEntries);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Config";
            this.Shown += new System.EventHandler(this.EditConfig_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListView lvwEntries;
        private System.Windows.Forms.ColumnHeader columnHeaderServiceURL;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderMethodName;
        private System.Windows.Forms.ColumnHeader columnHeaderParameters;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer columnResizeTimer;
    }
}