namespace QuickMon
{
    partial class EditServiceWindows
    {
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditServiceWindows));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fromTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.toTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSat = new System.Windows.Forms.CheckBox();
            this.chkFri = new System.Windows.Forms.CheckBox();
            this.chkThur = new System.Windows.Forms.CheckBox();
            this.chkWed = new System.Windows.Forms.CheckBox();
            this.chkTue = new System.Windows.Forms.CheckBox();
            this.chkMon = new System.Windows.Forms.CheckBox();
            this.chkSun = new System.Windows.Forms.CheckBox();
            this.dateTimePickerHoliday = new System.Windows.Forms.DateTimePicker();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.listBoxHolidays = new System.Windows.Forms.ListBox();
            this.cmdImport = new System.Windows.Forms.Button();
            this.lvwTimes = new QuickMon.ListViewEx();
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(346, 381);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(265, 381);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From time";
            // 
            // fromTimeMaskedTextBox
            // 
            this.fromTimeMaskedTextBox.Location = new System.Drawing.Point(67, 12);
            this.fromTimeMaskedTextBox.Mask = "00:00:00";
            this.fromTimeMaskedTextBox.Name = "fromTimeMaskedTextBox";
            this.fromTimeMaskedTextBox.PromptChar = '0';
            this.fromTimeMaskedTextBox.Size = new System.Drawing.Size(66, 20);
            this.fromTimeMaskedTextBox.TabIndex = 1;
            this.fromTimeMaskedTextBox.Text = "     1";
            this.fromTimeMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // toTimeMaskedTextBox
            // 
            this.toTimeMaskedTextBox.Location = new System.Drawing.Point(187, 12);
            this.toTimeMaskedTextBox.Mask = "00:00:00";
            this.toTimeMaskedTextBox.Name = "toTimeMaskedTextBox";
            this.toTimeMaskedTextBox.PromptChar = '0';
            this.toTimeMaskedTextBox.Size = new System.Drawing.Size(66, 20);
            this.toTimeMaskedTextBox.TabIndex = 3;
            this.toTimeMaskedTextBox.Text = "235959";
            this.toTimeMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To time";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdUpdate.Location = new System.Drawing.Point(258, 10);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 4;
            this.cmdUpdate.Text = "Add/Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Enabled = false;
            this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRemove.Location = new System.Drawing.Point(339, 10);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 5;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSat);
            this.groupBox1.Controls.Add(this.chkFri);
            this.groupBox1.Controls.Add(this.chkThur);
            this.groupBox1.Controls.Add(this.chkWed);
            this.groupBox1.Controls.Add(this.chkTue);
            this.groupBox1.Controls.Add(this.chkMon);
            this.groupBox1.Controls.Add(this.chkSun);
            this.groupBox1.Location = new System.Drawing.Point(12, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 41);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Days of Week";
            // 
            // chkSat
            // 
            this.chkSat.AutoSize = true;
            this.chkSat.Location = new System.Drawing.Point(318, 18);
            this.chkSat.Name = "chkSat";
            this.chkSat.Size = new System.Drawing.Size(42, 17);
            this.chkSat.TabIndex = 6;
            this.chkSat.Tag = "Saturday";
            this.chkSat.Text = "Sat";
            this.chkSat.UseVisualStyleBackColor = true;
            this.chkSat.Click += new System.EventHandler(this.chkDayOfWeek_CheckedChanged);
            // 
            // chkFri
            // 
            this.chkFri.AutoSize = true;
            this.chkFri.Location = new System.Drawing.Point(275, 18);
            this.chkFri.Name = "chkFri";
            this.chkFri.Size = new System.Drawing.Size(37, 17);
            this.chkFri.TabIndex = 5;
            this.chkFri.Tag = "Friday";
            this.chkFri.Text = "Fri";
            this.chkFri.UseVisualStyleBackColor = true;
            this.chkFri.Click += new System.EventHandler(this.chkDayOfWeek_CheckedChanged);
            // 
            // chkThur
            // 
            this.chkThur.AutoSize = true;
            this.chkThur.Location = new System.Drawing.Point(224, 18);
            this.chkThur.Name = "chkThur";
            this.chkThur.Size = new System.Drawing.Size(45, 17);
            this.chkThur.TabIndex = 4;
            this.chkThur.Tag = "Thursday";
            this.chkThur.Text = "Thu";
            this.chkThur.UseVisualStyleBackColor = true;
            this.chkThur.Click += new System.EventHandler(this.chkDayOfWeek_CheckedChanged);
            // 
            // chkWed
            // 
            this.chkWed.AutoSize = true;
            this.chkWed.Location = new System.Drawing.Point(169, 18);
            this.chkWed.Name = "chkWed";
            this.chkWed.Size = new System.Drawing.Size(49, 17);
            this.chkWed.TabIndex = 3;
            this.chkWed.Tag = "Wednesday";
            this.chkWed.Text = "Wed";
            this.chkWed.UseVisualStyleBackColor = true;
            this.chkWed.Click += new System.EventHandler(this.chkDayOfWeek_CheckedChanged);
            // 
            // chkTue
            // 
            this.chkTue.AutoSize = true;
            this.chkTue.Location = new System.Drawing.Point(118, 18);
            this.chkTue.Name = "chkTue";
            this.chkTue.Size = new System.Drawing.Size(45, 17);
            this.chkTue.TabIndex = 2;
            this.chkTue.Tag = "Tuesday";
            this.chkTue.Text = "Tue";
            this.chkTue.UseVisualStyleBackColor = true;
            this.chkTue.Click += new System.EventHandler(this.chkDayOfWeek_CheckedChanged);
            // 
            // chkMon
            // 
            this.chkMon.AutoSize = true;
            this.chkMon.Location = new System.Drawing.Point(65, 18);
            this.chkMon.Name = "chkMon";
            this.chkMon.Size = new System.Drawing.Size(47, 17);
            this.chkMon.TabIndex = 1;
            this.chkMon.Tag = "Monday";
            this.chkMon.Text = "Mon";
            this.chkMon.UseVisualStyleBackColor = true;
            this.chkMon.Click += new System.EventHandler(this.chkDayOfWeek_CheckedChanged);
            // 
            // chkSun
            // 
            this.chkSun.AutoSize = true;
            this.chkSun.Location = new System.Drawing.Point(14, 18);
            this.chkSun.Name = "chkSun";
            this.chkSun.Size = new System.Drawing.Size(45, 17);
            this.chkSun.TabIndex = 0;
            this.chkSun.Tag = "Sunday";
            this.chkSun.Text = "Sun";
            this.chkSun.UseVisualStyleBackColor = true;
            this.chkSun.Click += new System.EventHandler(this.chkDayOfWeek_CheckedChanged);
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
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdd.Location = new System.Drawing.Point(226, 21);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdClear);
            this.groupBox2.Controls.Add(this.listBoxHolidays);
            this.groupBox2.Controls.Add(this.cmdImport);
            this.groupBox2.Controls.Add(this.dateTimePickerHoliday);
            this.groupBox2.Controls.Add(this.cmdAdd);
            this.groupBox2.Location = new System.Drawing.Point(12, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 115);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Holidays/Exclusion";
            // 
            // cmdClear
            // 
            this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdClear.Location = new System.Drawing.Point(226, 79);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 23);
            this.cmdClear.TabIndex = 4;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // listBoxHolidays
            // 
            this.listBoxHolidays.FormattingEnabled = true;
            this.listBoxHolidays.Location = new System.Drawing.Point(14, 44);
            this.listBoxHolidays.Name = "listBoxHolidays";
            this.listBoxHolidays.Size = new System.Drawing.Size(200, 56);
            this.listBoxHolidays.Sorted = true;
            this.listBoxHolidays.TabIndex = 2;
            this.listBoxHolidays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxHolidays_KeyDown);
            // 
            // cmdImport
            // 
            this.cmdImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImport.Location = new System.Drawing.Point(226, 50);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(75, 23);
            this.cmdImport.TabIndex = 3;
            this.cmdImport.Text = "Import...";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // lvwTimes
            // 
            this.lvwTimes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo});
            this.lvwTimes.FullRowSelect = true;
            this.lvwTimes.Location = new System.Drawing.Point(12, 39);
            this.lvwTimes.Name = "lvwTimes";
            this.lvwTimes.Size = new System.Drawing.Size(409, 167);
            this.lvwTimes.TabIndex = 6;
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
            // EditServiceWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.Load += new System.EventHandler(this.EditServiceWindows_Load);
            this.Shown += new System.EventHandler(this.EditServiceWindows_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewEx lvwTimes;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox fromTimeMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox toTimeMaskedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.CheckBox chkSun;
        private System.Windows.Forms.CheckBox chkSat;
        private System.Windows.Forms.CheckBox chkFri;
        private System.Windows.Forms.CheckBox chkThur;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoliday;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxHolidays;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Button cmdClear;
    }
}