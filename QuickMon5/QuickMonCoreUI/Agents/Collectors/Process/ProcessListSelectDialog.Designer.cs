
namespace QuickMon.UI
{
    partial class ProcessListSelectDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessListSelectDialog));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFieldSelector = new System.Windows.Forms.ComboBox();
            this.llblRefresh = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new QuickMon.Controls.TextBoxEx();
            this.txtComputer = new QuickMon.Controls.TextBoxEx();
            this.lvwProcess = new QuickMon.ListViewEx();
            this.idColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.displaynameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdLineColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(697, 526);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(616, 526);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "Select";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Field to select";
            // 
            // cboFieldSelector
            // 
            this.cboFieldSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFieldSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFieldSelector.FormattingEnabled = true;
            this.cboFieldSelector.Items.AddRange(new object[] {
            "Process name",
            "Executable name",
            "Display name",
            "Full path",
            "Startup command line"});
            this.cboFieldSelector.Location = new System.Drawing.Point(489, 528);
            this.cboFieldSelector.Name = "cboFieldSelector";
            this.cboFieldSelector.Size = new System.Drawing.Size(121, 21);
            this.cboFieldSelector.TabIndex = 3;
            // 
            // llblRefresh
            // 
            this.llblRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblRefresh.AutoSize = true;
            this.llblRefresh.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblRefresh.Location = new System.Drawing.Point(728, 9);
            this.llblRefresh.Name = "llblRefresh";
            this.llblRefresh.Size = new System.Drawing.Size(44, 13);
            this.llblRefresh.TabIndex = 4;
            this.llblRefresh.TabStop = true;
            this.llblRefresh.Text = "Refresh";
            this.llblRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRefresh_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.llblRefresh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtComputer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 27);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Computer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(325, 5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(397, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.txtFilter_EnterKeyPressed);
            // 
            // txtComputer
            // 
            this.txtComputer.Location = new System.Drawing.Point(80, 5);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(192, 20);
            this.txtComputer.TabIndex = 1;
            this.txtComputer.EnterKeyPressed += new System.Windows.Forms.MethodInvoker(this.txtComputer_EnterKeyPressed);
            // 
            // lvwProcess
            // 
            this.lvwProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProcess.AutoResizeColumnEnabled = false;
            this.lvwProcess.AutoResizeColumnIndex = 4;
            this.lvwProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumnHeader,
            this.processNameColumnHeader,
            this.exeColumnHeader,
            this.displaynameColumnHeader,
            this.pathColumnHeader,
            this.cmdLineColumnHeader});
            this.lvwProcess.FullRowSelect = true;
            this.lvwProcess.HideSelection = false;
            this.lvwProcess.Location = new System.Drawing.Point(2, 29);
            this.lvwProcess.Name = "lvwProcess";
            this.lvwProcess.Size = new System.Drawing.Size(780, 491);
            this.lvwProcess.TabIndex = 1;
            this.lvwProcess.UseCompatibleStateImageBehavior = false;
            this.lvwProcess.View = System.Windows.Forms.View.Details;
            this.lvwProcess.SelectedIndexChanged += new System.EventHandler(this.lvwProcess_SelectedIndexChanged);
            // 
            // idColumnHeader
            // 
            this.idColumnHeader.Text = "Id";
            // 
            // processNameColumnHeader
            // 
            this.processNameColumnHeader.Text = "Process name";
            this.processNameColumnHeader.Width = 146;
            // 
            // exeColumnHeader
            // 
            this.exeColumnHeader.Text = "Executable name";
            this.exeColumnHeader.Width = 149;
            // 
            // displaynameColumnHeader
            // 
            this.displaynameColumnHeader.Text = "Display name";
            this.displaynameColumnHeader.Width = 150;
            // 
            // pathColumnHeader
            // 
            this.pathColumnHeader.Text = "Full path";
            this.pathColumnHeader.Width = 235;
            // 
            // cmdLineColumnHeader
            // 
            this.cmdLineColumnHeader.Text = "Startup command line";
            this.cmdLineColumnHeader.Width = 182;
            // 
            // ProcessListSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvwProcess);
            this.Controls.Add(this.cboFieldSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ProcessListSelectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Process";
            this.Load += new System.EventHandler(this.ProcessListSelectDialog_Load);
            this.Shown += new System.EventHandler(this.ProcessListSelectDialog_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFieldSelector;
        private ListViewEx lvwProcess;
        private System.Windows.Forms.ColumnHeader idColumnHeader;
        private System.Windows.Forms.ColumnHeader processNameColumnHeader;
        private System.Windows.Forms.ColumnHeader exeColumnHeader;
        private System.Windows.Forms.ColumnHeader displaynameColumnHeader;
        private System.Windows.Forms.ColumnHeader pathColumnHeader;
        private System.Windows.Forms.ColumnHeader cmdLineColumnHeader;
        private System.Windows.Forms.LinkLabel llblRefresh;
        private System.Windows.Forms.Panel panel1;
        private Controls.TextBoxEx txtComputer;
        private System.Windows.Forms.Label label2;
        private Controls.TextBoxEx txtFilter;
        private System.Windows.Forms.Label label3;
    }
}