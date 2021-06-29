namespace QuickMon.UI
{
    partial class SelectEventSources
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectEventSources));
            this.lvwSources = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdLoadEventLogs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLog = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdApplyFilter = new System.Windows.Forms.Button();
            this.txtQuickFilter = new QuickMon.Controls.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdRemoveSource = new System.Windows.Forms.Button();
            this.cmdAddSource = new System.Windows.Forms.Button();
            this.lvwSourcesSelected = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwSources
            // 
            this.lvwSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSources.HideSelection = false;
            this.lvwSources.Location = new System.Drawing.Point(0, 18);
            this.lvwSources.Name = "lvwSources";
            this.lvwSources.Size = new System.Drawing.Size(319, 274);
            this.lvwSources.TabIndex = 17;
            this.lvwSources.UseCompatibleStateImageBehavior = false;
            this.lvwSources.View = System.Windows.Forms.View.List;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Source(s)";
            // 
            // cmdLoadEventLogs
            // 
            this.cmdLoadEventLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadEventLogs.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdLoadEventLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLoadEventLogs.Location = new System.Drawing.Point(652, 6);
            this.cmdLoadEventLogs.Name = "cmdLoadEventLogs";
            this.cmdLoadEventLogs.Size = new System.Drawing.Size(42, 23);
            this.cmdLoadEventLogs.TabIndex = 13;
            this.cmdLoadEventLogs.Text = "Load";
            this.cmdLoadEventLogs.UseVisualStyleBackColor = true;
            this.cmdLoadEventLogs.Click += new System.EventHandler(this.cmdLoadEventLogs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Event log";
            // 
            // cboLog
            // 
            this.cboLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLog.FormattingEnabled = true;
            this.cboLog.Location = new System.Drawing.Point(99, 34);
            this.cboLog.Name = "cboLog";
            this.cboLog.Size = new System.Drawing.Size(595, 21);
            this.cboLog.TabIndex = 15;
            this.cboLog.SelectedIndexChanged += new System.EventHandler(this.cboLog_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Computer";
            // 
            // txtComputer
            // 
            this.txtComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputer.Location = new System.Drawing.Point(99, 8);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(547, 20);
            this.txtComputer.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 76);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwSourcesSelected);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(682, 315);
            this.splitContainer1.SplitterDistance = 382;
            this.splitContainer1.TabIndex = 18;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvwSources);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(382, 315);
            this.splitContainer2.SplitterDistance = 319;
            this.splitContainer2.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdApplyFilter);
            this.panel2.Controls.Add(this.txtQuickFilter);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 23);
            this.panel2.TabIndex = 35;
            // 
            // cmdApplyFilter
            // 
            this.cmdApplyFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdApplyFilter.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApplyFilter.Location = new System.Drawing.Point(274, 0);
            this.cmdApplyFilter.Name = "cmdApplyFilter";
            this.cmdApplyFilter.Size = new System.Drawing.Size(45, 23);
            this.cmdApplyFilter.TabIndex = 35;
            this.cmdApplyFilter.Text = "Apply";
            this.cmdApplyFilter.UseVisualStyleBackColor = true;
            this.cmdApplyFilter.Click += new System.EventHandler(this.cmdApplyFilter_Click);
            // 
            // txtQuickFilter
            // 
            this.txtQuickFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuickFilter.Location = new System.Drawing.Point(66, 3);
            this.txtQuickFilter.Name = "txtQuickFilter";
            this.txtQuickFilter.Size = new System.Drawing.Size(202, 20);
            this.txtQuickFilter.TabIndex = 34;
            this.txtQuickFilter.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.txtQuickFilter_EnterKeyPressed);
            this.txtQuickFilter.TextChanged += new System.EventHandler(this.txtQuickFilter_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Quick filter";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Available";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(59, 315);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdRemoveSource);
            this.panel1.Controls.Add(this.cmdAddSource);
            this.panel1.Location = new System.Drawing.Point(3, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 50);
            this.panel1.TabIndex = 2;
            // 
            // cmdRemoveSource
            // 
            this.cmdRemoveSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdRemoveSource.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdRemoveSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemoveSource.Image = global::QuickMon.Properties.Resources.arrow_left;
            this.cmdRemoveSource.Location = new System.Drawing.Point(0, 23);
            this.cmdRemoveSource.Name = "cmdRemoveSource";
            this.cmdRemoveSource.Size = new System.Drawing.Size(53, 23);
            this.cmdRemoveSource.TabIndex = 1;
            this.cmdRemoveSource.UseVisualStyleBackColor = true;
            this.cmdRemoveSource.Click += new System.EventHandler(this.cmdRemoveSource_Click);
            // 
            // cmdAddSource
            // 
            this.cmdAddSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdAddSource.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdAddSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddSource.Image = global::QuickMon.Properties.Resources.arrow_right;
            this.cmdAddSource.Location = new System.Drawing.Point(0, 0);
            this.cmdAddSource.Name = "cmdAddSource";
            this.cmdAddSource.Size = new System.Drawing.Size(53, 23);
            this.cmdAddSource.TabIndex = 0;
            this.cmdAddSource.UseVisualStyleBackColor = true;
            this.cmdAddSource.Click += new System.EventHandler(this.cmdAddSource_Click);
            // 
            // lvwSourcesSelected
            // 
            this.lvwSourcesSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSourcesSelected.HideSelection = false;
            this.lvwSourcesSelected.Location = new System.Drawing.Point(0, 18);
            this.lvwSourcesSelected.Name = "lvwSourcesSelected";
            this.lvwSourcesSelected.Size = new System.Drawing.Size(296, 297);
            this.lvwSourcesSelected.TabIndex = 20;
            this.lvwSourcesSelected.UseCompatibleStateImageBehavior = false;
            this.lvwSourcesSelected.View = System.Windows.Forms.View.List;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Selected";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(619, 397);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 32;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(538, 397);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 31;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // SelectEventSources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 432);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdLoadEventLogs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComputer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(523, 377);
            this.Name = "SelectEventSources";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Sources";
            this.Load += new System.EventHandler(this.SelectEventSources_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSources;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdLoadEventLogs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdRemoveSource;
        private System.Windows.Forms.Button cmdAddSource;
        private System.Windows.Forms.ListView lvwSourcesSelected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Panel panel2;
        private QuickMon.Controls.TextBoxEx txtQuickFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdApplyFilter;
    }
}