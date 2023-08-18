
namespace QuickMon
{
    partial class EditVariables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditVariables));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panelVariables = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwConfigVars = new QuickMon.ListViewEx();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripVariables = new System.Windows.Forms.ToolStrip();
            this.addConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panelVarEdit = new System.Windows.Forms.Panel();
            this.llblExpandConfigVarSection = new System.Windows.Forms.LinkLabel();
            this.txtConfigVarSearchFor = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtConfigVarReplaceByValue = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panelVariables.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStripVariables.SuspendLayout();
            this.panelVarEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(495, 381);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(576, 381);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            // 
            // panelVariables
            // 
            this.panelVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVariables.Controls.Add(this.panel3);
            this.panelVariables.Controls.Add(this.panelVarEdit);
            this.panelVariables.Location = new System.Drawing.Point(0, 0);
            this.panelVariables.Name = "panelVariables";
            this.panelVariables.Size = new System.Drawing.Size(664, 375);
            this.panelVariables.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvwConfigVars);
            this.panel3.Controls.Add(this.toolStripVariables);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(664, 261);
            this.panel3.TabIndex = 5;
            // 
            // lvwConfigVars
            // 
            this.lvwConfigVars.AutoResizeColumnEnabled = false;
            this.lvwConfigVars.AutoResizeColumnIndex = 1;
            this.lvwConfigVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.lvwConfigVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwConfigVars.FullRowSelect = true;
            this.lvwConfigVars.HideSelection = false;
            this.lvwConfigVars.Location = new System.Drawing.Point(0, 25);
            this.lvwConfigVars.Name = "lvwConfigVars";
            this.lvwConfigVars.Size = new System.Drawing.Size(664, 236);
            this.lvwConfigVars.TabIndex = 2;
            this.lvwConfigVars.UseCompatibleStateImageBehavior = false;
            this.lvwConfigVars.View = System.Windows.Forms.View.Details;
            this.lvwConfigVars.SelectedIndexChanged += new System.EventHandler(this.lvwConfigVars_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Search for";
            this.nameColumnHeader.Width = 243;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Replace by";
            this.valueColumnHeader.Width = 262;
            // 
            // toolStripVariables
            // 
            this.toolStripVariables.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripVariables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConfigVarToolStripButton,
            this.deleteConfigVarToolStripButton,
            this.toolStripSeparator1,
            this.moveUpConfigVarToolStripButton,
            this.moveDownConfigVarToolStripButton});
            this.toolStripVariables.Location = new System.Drawing.Point(0, 0);
            this.toolStripVariables.Name = "toolStripVariables";
            this.toolStripVariables.Size = new System.Drawing.Size(664, 25);
            this.toolStripVariables.TabIndex = 1;
            this.toolStripVariables.TabStop = true;
            this.toolStripVariables.Text = "toolStrip1";
            // 
            // addConfigVarToolStripButton
            // 
            this.addConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addConfigVarToolStripButton.Name = "addConfigVarToolStripButton";
            this.addConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addConfigVarToolStripButton.Text = "Create new";
            this.addConfigVarToolStripButton.ToolTipText = "Add entry";
            this.addConfigVarToolStripButton.Click += new System.EventHandler(this.addConfigVarToolStripButton_Click);
            // 
            // deleteConfigVarToolStripButton
            // 
            this.deleteConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteConfigVarToolStripButton.Enabled = false;
            this.deleteConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.deleteConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteConfigVarToolStripButton.Name = "deleteConfigVarToolStripButton";
            this.deleteConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteConfigVarToolStripButton.Text = "Delete selected item(s)";
            this.deleteConfigVarToolStripButton.Click += new System.EventHandler(this.deleteConfigVarToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // moveUpConfigVarToolStripButton
            // 
            this.moveUpConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpConfigVarToolStripButton.Enabled = false;
            this.moveUpConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpConfigVarToolStripButton.Name = "moveUpConfigVarToolStripButton";
            this.moveUpConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveUpConfigVarToolStripButton.Text = "Move selected item up";
            this.moveUpConfigVarToolStripButton.Click += new System.EventHandler(this.moveUpConfigVarToolStripButton_Click);
            // 
            // moveDownConfigVarToolStripButton
            // 
            this.moveDownConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownConfigVarToolStripButton.Enabled = false;
            this.moveDownConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownConfigVarToolStripButton.Name = "moveDownConfigVarToolStripButton";
            this.moveDownConfigVarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.moveDownConfigVarToolStripButton.Text = "Move selected item down";
            this.moveDownConfigVarToolStripButton.Click += new System.EventHandler(this.moveDownConfigVarToolStripButton_Click);
            // 
            // panelVarEdit
            // 
            this.panelVarEdit.Controls.Add(this.llblExpandConfigVarSection);
            this.panelVarEdit.Controls.Add(this.txtConfigVarSearchFor);
            this.panelVarEdit.Controls.Add(this.label40);
            this.panelVarEdit.Controls.Add(this.txtConfigVarReplaceByValue);
            this.panelVarEdit.Controls.Add(this.label41);
            this.panelVarEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVarEdit.Location = new System.Drawing.Point(0, 261);
            this.panelVarEdit.Name = "panelVarEdit";
            this.panelVarEdit.Size = new System.Drawing.Size(664, 114);
            this.panelVarEdit.TabIndex = 3;
            // 
            // llblExpandConfigVarSection
            // 
            this.llblExpandConfigVarSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblExpandConfigVarSection.AutoSize = true;
            this.llblExpandConfigVarSection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblExpandConfigVarSection.Location = new System.Drawing.Point(6, 97);
            this.llblExpandConfigVarSection.Name = "llblExpandConfigVarSection";
            this.llblExpandConfigVarSection.Size = new System.Drawing.Size(43, 13);
            this.llblExpandConfigVarSection.TabIndex = 4;
            this.llblExpandConfigVarSection.TabStop = true;
            this.llblExpandConfigVarSection.Text = "Expand";
            // 
            // txtConfigVarSearchFor
            // 
            this.txtConfigVarSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigVarSearchFor.Location = new System.Drawing.Point(80, 3);
            this.txtConfigVarSearchFor.Name = "txtConfigVarSearchFor";
            this.txtConfigVarSearchFor.Size = new System.Drawing.Size(581, 20);
            this.txtConfigVarSearchFor.TabIndex = 1;
            this.txtConfigVarSearchFor.TextChanged += new System.EventHandler(this.txtConfigVarSearchFor_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 6);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 13);
            this.label40.TabIndex = 0;
            this.label40.Text = "Search for";
            // 
            // txtConfigVarReplaceByValue
            // 
            this.txtConfigVarReplaceByValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigVarReplaceByValue.Location = new System.Drawing.Point(80, 28);
            this.txtConfigVarReplaceByValue.Multiline = true;
            this.txtConfigVarReplaceByValue.Name = "txtConfigVarReplaceByValue";
            this.txtConfigVarReplaceByValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfigVarReplaceByValue.Size = new System.Drawing.Size(581, 83);
            this.txtConfigVarReplaceByValue.TabIndex = 3;
            this.txtConfigVarReplaceByValue.TextChanged += new System.EventHandler(this.txtConfigVarReplaceByValue_TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(5, 31);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 13);
            this.label41.TabIndex = 2;
            this.label41.Text = "Replace with";
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(6, 381);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(483, 29);
            this.label42.TabIndex = 5;
            this.label42.Text = "Suggestions: Use \'variable\' names that are unique in the config. e.g. %SomeValue%" +
    ". Be careful when using quotes/doublequotes or any other characters that are \'sp" +
    "ecial\' in XML.";
            // 
            // EditVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 416);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.panelVariables);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditVariables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Variables";
            this.Load += new System.EventHandler(this.EditVariables_Load);
            this.panelVariables.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStripVariables.ResumeLayout(false);
            this.toolStripVariables.PerformLayout();
            this.panelVarEdit.ResumeLayout(false);
            this.panelVarEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel panelVariables;
        private System.Windows.Forms.Panel panel3;
        private ListViewEx lvwConfigVars;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.ToolStrip toolStripVariables;
        private System.Windows.Forms.ToolStripButton addConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton moveUpConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownConfigVarToolStripButton;
        private System.Windows.Forms.Panel panelVarEdit;
        private System.Windows.Forms.LinkLabel llblExpandConfigVarSection;
        private System.Windows.Forms.TextBox txtConfigVarSearchFor;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtConfigVarReplaceByValue;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
    }
}