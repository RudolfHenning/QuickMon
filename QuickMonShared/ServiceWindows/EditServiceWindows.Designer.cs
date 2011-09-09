namespace QuickMon
{
    partial class EditServiceWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditServiceWindows));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lvwTimes = new QuickMon.ListViewEx();
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.fromTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.toTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(314, 256);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(233, 256);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lvwTimes
            // 
            this.lvwTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTimes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo});
            this.lvwTimes.FullRowSelect = true;
            this.lvwTimes.Location = new System.Drawing.Point(12, 41);
            this.lvwTimes.Name = "lvwTimes";
            this.lvwTimes.Size = new System.Drawing.Size(296, 209);
            this.lvwTimes.TabIndex = 5;
            this.lvwTimes.UseCompatibleStateImageBehavior = false;
            this.lvwTimes.View = System.Windows.Forms.View.Details;
            this.lvwTimes.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwTimes_DeleteKeyPressed);
            this.lvwTimes.SelectedIndexChanged += new System.EventHandler(this.lvwTimes_SelectedIndexChanged);
            // 
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "From time";
            this.columnHeaderFrom.Width = 130;
            // 
            // columnHeaderTo
            // 
            this.columnHeaderTo.Text = "To time";
            this.columnHeaderTo.Width = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From time";
            // 
            // fromTimeMaskedTextBox
            // 
            this.fromTimeMaskedTextBox.Location = new System.Drawing.Point(76, 12);
            this.fromTimeMaskedTextBox.Mask = "00:00:00";
            this.fromTimeMaskedTextBox.Name = "fromTimeMaskedTextBox";
            this.fromTimeMaskedTextBox.PromptChar = '0';
            this.fromTimeMaskedTextBox.Size = new System.Drawing.Size(66, 20);
            this.fromTimeMaskedTextBox.TabIndex = 1;
            this.fromTimeMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // toTimeMaskedTextBox
            // 
            this.toTimeMaskedTextBox.Location = new System.Drawing.Point(240, 12);
            this.toTimeMaskedTextBox.Mask = "00:00:00";
            this.toTimeMaskedTextBox.Name = "toTimeMaskedTextBox";
            this.toTimeMaskedTextBox.PromptChar = '0';
            this.toTimeMaskedTextBox.Size = new System.Drawing.Size(66, 20);
            this.toTimeMaskedTextBox.TabIndex = 3;
            this.toTimeMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To time";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUpdate.Location = new System.Drawing.Point(314, 10);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 4;
            this.cmdUpdate.Text = "Add/Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemove.Enabled = false;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemove.Location = new System.Drawing.Point(314, 41);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 6;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // EditServiceWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 291);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.toTimeMaskedTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fromTimeMaskedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwTimes);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditServiceWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Service Windows";
            this.Shown += new System.EventHandler(this.EditServiceWindows_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private ListViewEx lvwTimes;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox fromTimeMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox toTimeMaskedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdRemove;
    }
}