namespace QuickMon.Collectors
{
    partial class PerfCounterEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerfCounterEdit));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwCounters = new QuickMon.ListViewEx();
            this.columnHeaderCounter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwInstances = new QuickMon.ListViewEx();
            this.columnHeaderInstance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwCategories = new QuickMon.ListViewEx();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblWarning = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdLoadCategories = new System.Windows.Forms.Button();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(358, 363);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Category";
            this.columnHeaderCategory.Width = 197;
            // 
            // lvwCounters
            // 
            this.lvwCounters.AutoResizeColumnEnabled = false;
            this.lvwCounters.AutoResizeColumnIndex = 0;
            this.lvwCounters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCounter});
            this.lvwCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCounters.FullRowSelect = true;
            this.lvwCounters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCounters.HideSelection = false;
            this.lvwCounters.Location = new System.Drawing.Point(0, 0);
            this.lvwCounters.MultiSelect = false;
            this.lvwCounters.Name = "lvwCounters";
            this.lvwCounters.Size = new System.Drawing.Size(213, 189);
            this.lvwCounters.TabIndex = 0;
            this.lvwCounters.UseCompatibleStateImageBehavior = false;
            this.lvwCounters.View = System.Windows.Forms.View.Details;
            this.lvwCounters.SelectedIndexChanged += new System.EventHandler(this.lvwCounters_SelectedIndexChanged);
            this.lvwCounters.Resize += new System.EventHandler(this.lvwCategories_Resize);
            // 
            // columnHeaderCounter
            // 
            this.columnHeaderCounter.Text = "Counter";
            this.columnHeaderCounter.Width = 207;
            // 
            // lvwInstances
            // 
            this.lvwInstances.AutoResizeColumnEnabled = false;
            this.lvwInstances.AutoResizeColumnIndex = 0;
            this.lvwInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderInstance});
            this.lvwInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwInstances.FullRowSelect = true;
            this.lvwInstances.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwInstances.HideSelection = false;
            this.lvwInstances.Location = new System.Drawing.Point(0, 0);
            this.lvwInstances.MultiSelect = false;
            this.lvwInstances.Name = "lvwInstances";
            this.lvwInstances.Size = new System.Drawing.Size(420, 124);
            this.lvwInstances.TabIndex = 0;
            this.lvwInstances.UseCompatibleStateImageBehavior = false;
            this.lvwInstances.View = System.Windows.Forms.View.Details;
            this.lvwInstances.SelectedIndexChanged += new System.EventHandler(this.lvwInstances_SelectedIndexChanged);
            this.lvwInstances.Resize += new System.EventHandler(this.lvwCategories_Resize);
            // 
            // columnHeaderInstance
            // 
            this.columnHeaderInstance.Text = "Instance";
            this.columnHeaderInstance.Width = 414;
            // 
            // lvwCategories
            // 
            this.lvwCategories.AutoResizeColumnEnabled = false;
            this.lvwCategories.AutoResizeColumnIndex = 0;
            this.lvwCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCategory});
            this.lvwCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCategories.FullRowSelect = true;
            this.lvwCategories.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCategories.HideSelection = false;
            this.lvwCategories.Location = new System.Drawing.Point(0, 0);
            this.lvwCategories.MultiSelect = false;
            this.lvwCategories.Name = "lvwCategories";
            this.lvwCategories.Size = new System.Drawing.Size(203, 189);
            this.lvwCategories.TabIndex = 0;
            this.lvwCategories.UseCompatibleStateImageBehavior = false;
            this.lvwCategories.View = System.Windows.Forms.View.Details;
            this.lvwCategories.SelectedIndexChanged += new System.EventHandler(this.lvwCategories_SelectedIndexChanged);
            this.lvwCategories.Resize += new System.EventHandler(this.lvwCategories_Resize);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvwCategories);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvwCounters);
            this.splitContainer2.Size = new System.Drawing.Size(420, 189);
            this.splitContainer2.SplitterDistance = 203;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(13, 368);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(10, 13);
            this.lblWarning.TabIndex = 22;
            this.lblWarning.Text = ".";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 40);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwInstances);
            this.splitContainer1.Size = new System.Drawing.Size(420, 317);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 19;
            // 
            // cmdLoadCategories
            // 
            this.cmdLoadCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadCategories.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdLoadCategories.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdLoadCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLoadCategories.Location = new System.Drawing.Point(373, 11);
            this.cmdLoadCategories.Name = "cmdLoadCategories";
            this.cmdLoadCategories.Size = new System.Drawing.Size(60, 23);
            this.cmdLoadCategories.TabIndex = 18;
            this.cmdLoadCategories.Text = "Load";
            this.cmdLoadCategories.UseVisualStyleBackColor = true;
            this.cmdLoadCategories.Click += new System.EventHandler(this.cmdLoadCategories_Click);
            // 
            // txtComputer
            // 
            this.txtComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputer.Location = new System.Drawing.Point(96, 13);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(271, 20);
            this.txtComputer.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Computer";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(277, 363);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 20;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // PerfCounterEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 397);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdLoadCategories);
            this.Controls.Add(this.txtComputer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 430);
            this.Name = "PerfCounterEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Performance Counter";
            this.Load += new System.EventHandler(this.EditPerfCounter_Load);
            this.Shown += new System.EventHandler(this.EditPerfCounter_Shown);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
        private ListViewEx lvwCounters;
        private System.Windows.Forms.ColumnHeader columnHeaderCounter;
        private ListViewEx lvwInstances;
        private System.Windows.Forms.ColumnHeader columnHeaderInstance;
        private ListViewEx lvwCategories;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdLoadCategories;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
    }
}