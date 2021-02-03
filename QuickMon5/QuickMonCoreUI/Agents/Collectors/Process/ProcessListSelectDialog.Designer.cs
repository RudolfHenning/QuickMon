
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
            this.lvwProcess = new QuickMon.ListViewEx();
            this.idColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.displaynameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdLineColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(697, 526);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(616, 526);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 11;
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
            this.label1.TabIndex = 13;
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
            this.cboFieldSelector.TabIndex = 14;
            // 
            // llblRefresh
            // 
            this.llblRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRefresh.AutoSize = true;
            this.llblRefresh.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblRefresh.Location = new System.Drawing.Point(11, 531);
            this.llblRefresh.Name = "llblRefresh";
            this.llblRefresh.Size = new System.Drawing.Size(44, 13);
            this.llblRefresh.TabIndex = 16;
            this.llblRefresh.TabStop = true;
            this.llblRefresh.Text = "Refresh";
            this.llblRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRefresh_LinkClicked);
            // 
            // lvwProcess
            // 
            this.lvwProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProcess.AutoResizeColumnEnabled = false;
            this.lvwProcess.AutoResizeColumnIndex = 0;
            this.lvwProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumnHeader,
            this.processNameColumnHeader,
            this.exeColumnHeader,
            this.displaynameColumnHeader,
            this.pathColumnHeader,
            this.cmdLineColumnHeader});
            this.lvwProcess.FullRowSelect = true;
            this.lvwProcess.HideSelection = false;
            this.lvwProcess.Location = new System.Drawing.Point(2, 2);
            this.lvwProcess.Name = "lvwProcess";
            this.lvwProcess.Size = new System.Drawing.Size(780, 518);
            this.lvwProcess.TabIndex = 15;
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
            this.Controls.Add(this.llblRefresh);
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
    }
}