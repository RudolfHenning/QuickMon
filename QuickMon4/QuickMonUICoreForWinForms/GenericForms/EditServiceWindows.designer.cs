namespace QuickMon.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditServiceWindows));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.toTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fromTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSat = new System.Windows.Forms.CheckBox();
            this.chkFri = new System.Windows.Forms.CheckBox();
            this.chkThur = new System.Windows.Forms.CheckBox();
            this.chkWed = new System.Windows.Forms.CheckBox();
            this.chkTue = new System.Windows.Forms.CheckBox();
            this.chkMon = new System.Windows.Forms.CheckBox();
            this.chkSun = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.listBoxHolidays = new System.Windows.Forms.ListBox();
            this.cmdImport = new System.Windows.Forms.Button();
            this.dateTimePickerHoliday = new System.Windows.Forms.DateTimePicker();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwTimes = new QuickMon.ListViewEx();
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.daysColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.cmdUpdate);
            this.groupBox1.Controls.Add(this.toTimeMaskedTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fromTimeMaskedTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkSat);
            this.groupBox1.Controls.Add(this.chkFri);
            this.groupBox1.Controls.Add(this.chkThur);
            this.groupBox1.Controls.Add(this.chkWed);
            this.groupBox1.Controls.Add(this.chkTue);
            this.groupBox1.Controls.Add(this.chkMon);
            this.groupBox1.Controls.Add(this.chkSun);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Window";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAll.Location = new System.Drawing.Point(363, 18);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(35, 17);
            this.chkAll.TabIndex = 12;
            this.chkAll.Tag = "All";
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Enabled = false;
            this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUpdate.Location = new System.Drawing.Point(328, 39);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 11;
            this.cmdUpdate.Text = "Add/Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // toTimeMaskedTextBox
            // 
            this.toTimeMaskedTextBox.Location = new System.Drawing.Point(185, 41);
            this.toTimeMaskedTextBox.Mask = "00:00:00";
            this.toTimeMaskedTextBox.Name = "toTimeMaskedTextBox";
            this.toTimeMaskedTextBox.PromptChar = '0';
            this.toTimeMaskedTextBox.Size = new System.Drawing.Size(66, 20);
            this.toTimeMaskedTextBox.TabIndex = 10;
            this.toTimeMaskedTextBox.Text = "235959";
            this.toTimeMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "To time";
            // 
            // fromTimeMaskedTextBox
            // 
            this.fromTimeMaskedTextBox.Location = new System.Drawing.Point(65, 41);
            this.fromTimeMaskedTextBox.Mask = "00:00:00";
            this.fromTimeMaskedTextBox.Name = "fromTimeMaskedTextBox";
            this.fromTimeMaskedTextBox.PromptChar = '0';
            this.fromTimeMaskedTextBox.Size = new System.Drawing.Size(66, 20);
            this.fromTimeMaskedTextBox.TabIndex = 8;
            this.fromTimeMaskedTextBox.Text = "     1";
            this.fromTimeMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "From time";
            // 
            // chkSat
            // 
            this.chkSat.AutoSize = true;
            this.chkSat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSat.Location = new System.Drawing.Point(318, 18);
            this.chkSat.Name = "chkSat";
            this.chkSat.Size = new System.Drawing.Size(40, 17);
            this.chkSat.TabIndex = 6;
            this.chkSat.Tag = "Saturday";
            this.chkSat.Text = "Sat";
            this.chkSat.UseVisualStyleBackColor = true;
            this.chkSat.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkFri
            // 
            this.chkFri.AutoSize = true;
            this.chkFri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkFri.Location = new System.Drawing.Point(275, 18);
            this.chkFri.Name = "chkFri";
            this.chkFri.Size = new System.Drawing.Size(35, 17);
            this.chkFri.TabIndex = 5;
            this.chkFri.Tag = "Friday";
            this.chkFri.Text = "Fri";
            this.chkFri.UseVisualStyleBackColor = true;
            this.chkFri.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkThur
            // 
            this.chkThur.AutoSize = true;
            this.chkThur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkThur.Location = new System.Drawing.Point(224, 18);
            this.chkThur.Name = "chkThur";
            this.chkThur.Size = new System.Drawing.Size(43, 17);
            this.chkThur.TabIndex = 4;
            this.chkThur.Tag = "Thursday";
            this.chkThur.Text = "Thu";
            this.chkThur.UseVisualStyleBackColor = true;
            this.chkThur.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkWed
            // 
            this.chkWed.AutoSize = true;
            this.chkWed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkWed.Location = new System.Drawing.Point(169, 18);
            this.chkWed.Name = "chkWed";
            this.chkWed.Size = new System.Drawing.Size(47, 17);
            this.chkWed.TabIndex = 3;
            this.chkWed.Tag = "Wednesday";
            this.chkWed.Text = "Wed";
            this.chkWed.UseVisualStyleBackColor = true;
            this.chkWed.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkTue
            // 
            this.chkTue.AutoSize = true;
            this.chkTue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkTue.Location = new System.Drawing.Point(118, 18);
            this.chkTue.Name = "chkTue";
            this.chkTue.Size = new System.Drawing.Size(43, 17);
            this.chkTue.TabIndex = 2;
            this.chkTue.Tag = "Tuesday";
            this.chkTue.Text = "Tue";
            this.chkTue.UseVisualStyleBackColor = true;
            this.chkTue.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkMon
            // 
            this.chkMon.AutoSize = true;
            this.chkMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkMon.Location = new System.Drawing.Point(65, 18);
            this.chkMon.Name = "chkMon";
            this.chkMon.Size = new System.Drawing.Size(45, 17);
            this.chkMon.TabIndex = 1;
            this.chkMon.Tag = "Monday";
            this.chkMon.Text = "Mon";
            this.chkMon.UseVisualStyleBackColor = true;
            this.chkMon.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkSun
            // 
            this.chkSun.AutoSize = true;
            this.chkSun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSun.Location = new System.Drawing.Point(14, 18);
            this.chkSun.Name = "chkSun";
            this.chkSun.Size = new System.Drawing.Size(43, 17);
            this.chkSun.TabIndex = 0;
            this.chkSun.Tag = "Sunday";
            this.chkSun.Text = "Sun";
            this.chkSun.UseVisualStyleBackColor = true;
            this.chkSun.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmdClear);
            this.groupBox2.Controls.Add(this.listBoxHolidays);
            this.groupBox2.Controls.Add(this.cmdImport);
            this.groupBox2.Controls.Add(this.dateTimePickerHoliday);
            this.groupBox2.Controls.Add(this.cmdAdd);
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Holidays/Exclusion";
            // 
            // cmdClear
            // 
            this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdClear.Location = new System.Drawing.Point(224, 77);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 23);
            this.cmdClear.TabIndex = 4;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // listBoxHolidays
            // 
            this.listBoxHolidays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxHolidays.FormattingEnabled = true;
            this.listBoxHolidays.Location = new System.Drawing.Point(14, 44);
            this.listBoxHolidays.Name = "listBoxHolidays";
            this.listBoxHolidays.Size = new System.Drawing.Size(200, 54);
            this.listBoxHolidays.Sorted = true;
            this.listBoxHolidays.TabIndex = 2;
            // 
            // cmdImport
            // 
            this.cmdImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImport.Location = new System.Drawing.Point(224, 48);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(75, 23);
            this.cmdImport.TabIndex = 3;
            this.cmdImport.Text = "Import...";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // dateTimePickerHoliday
            // 
            this.dateTimePickerHoliday.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerHoliday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHoliday.Location = new System.Drawing.Point(14, 18);
            this.dateTimePickerHoliday.Name = "dateTimePickerHoliday";
            this.dateTimePickerHoliday.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerHoliday.TabIndex = 0;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(224, 19);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 387);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(265, 387);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lvwTimes
            // 
            this.lvwTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTimes.AutoResizeColumnEnabled = false;
            this.lvwTimes.AutoResizeColumnIndex = 0;
            this.lvwTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwTimes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo,
            this.daysColumnHeader});
            this.lvwTimes.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwTimes.FullRowSelect = true;
            this.lvwTimes.HideSelection = false;
            this.lvwTimes.Location = new System.Drawing.Point(12, 89);
            this.lvwTimes.Name = "lvwTimes";
            this.lvwTimes.Size = new System.Drawing.Size(409, 167);
            this.lvwTimes.TabIndex = 1;
            this.lvwTimes.UseCompatibleStateImageBehavior = false;
            this.lvwTimes.View = System.Windows.Forms.View.Details;
            this.lvwTimes.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwTimes_DeleteKeyPressed);
            this.lvwTimes.SelectedIndexChanged += new System.EventHandler(this.lvwTimes_SelectedIndexChanged);
            // 
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "From time";
            this.columnHeaderFrom.Width = 111;
            // 
            // columnHeaderTo
            // 
            this.columnHeaderTo.Text = "To time";
            this.columnHeaderTo.Width = 119;
            // 
            // daysColumnHeader
            // 
            this.daysColumnHeader.Text = "Days";
            this.daysColumnHeader.Width = 150;
            // 
            // EditServiceWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwTimes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditServiceWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Service Windows";
            this.Load += new System.EventHandler(this.EditServiceWindows_Load);
            this.Shown += new System.EventHandler(this.EditServiceWindows_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QuickMon.ListViewEx lvwTimes;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSat;
        private System.Windows.Forms.CheckBox chkFri;
        private System.Windows.Forms.CheckBox chkThur;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.CheckBox chkSun;
        private System.Windows.Forms.MaskedTextBox toTimeMaskedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox fromTimeMaskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader daysColumnHeader;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.ListBox listBoxHolidays;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoliday;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}