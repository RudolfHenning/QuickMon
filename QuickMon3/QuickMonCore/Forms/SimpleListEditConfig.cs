using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public class SimpleListEditConfig : Form, IEditConfigWindow
    {
        public SimpleListEditConfig()
        {
            LocalInitializeComponent();
        }

        #region UI Components
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOK;
        public System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        public System.Windows.Forms.ContextMenuStrip editingContextMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        public ListViewEx lvwEntries;
        private System.ComponentModel.IContainer components = null;

        private void LocalInitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editingContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwEntries = new ListViewEx();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancel.Location = new System.Drawing.Point(511, 321);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdOK.Location = new System.Drawing.Point(430, 321);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 20;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // toolStrip1
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.editToolStripButton,
            this.removeToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "toolStrip1";
            this.mainToolStrip.Size = new System.Drawing.Size(581, 39);
            this.mainToolStrip.TabIndex = 23;
            this.mainToolStrip.TabStop = true;
            this.mainToolStrip.Text = "";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = global::QuickMon.Properties.Resources.doc_add;
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.addToolStripButton.Text = "Add";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Enabled = false;
            this.editToolStripButton.Image = global::QuickMon.Properties.Resources.doc_edit;
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.editToolStripButton.Text = "Edit";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolStripButton.Enabled = false;
            this.removeToolStripButton.Image = global::QuickMon.Properties.Resources.doc_remove;
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.removeToolStripButton.Text = "Remove";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);

            // 
            // editingContextMenuStrip
            // 
            this.editingContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.editingContextMenuStrip.Name = "editingContextMenuStrip";
            this.editingContextMenuStrip.Size = new System.Drawing.Size(118, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripButton_Click);
            // 
            // lvwEntries
            // 
            this.lvwEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEntries.ContextMenuStrip = this.editingContextMenuStrip;
            this.lvwEntries.FullRowSelect = true;
            this.lvwEntries.Location = new System.Drawing.Point(0, 42);
            this.lvwEntries.Name = "lvwEntries";
            this.lvwEntries.Size = new System.Drawing.Size(600, 271);
            this.lvwEntries.TabIndex = 24;
            this.lvwEntries.UseCompatibleStateImageBehavior = false;
            this.lvwEntries.View = System.Windows.Forms.View.Details;
            this.lvwEntries.SelectedIndexChanged += new System.EventHandler(this.lvwEntries_SelectedIndexChanged);
            this.lvwEntries.DoubleClick += new System.EventHandler(this.editToolStripButton_Click);
            this.lvwEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwEntries_KeyDown);
            this.lvwEntries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwEntries_KeyPress);
            // 
            // EditConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lvwEntries);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Name = "EditConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Confiig";
            this.Load += new System.EventHandler(this.SimpleListEditConfig_Load);
            this.Resize += new System.EventHandler(this.SimpleListEditConfig_Resize);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Form events
        private void SimpleListEditConfig_Load(object sender, EventArgs e)
        {
            LoadList();
            DoResize();
        }
        private void SimpleListEditConfig_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        #endregion

        #region Toolbar events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            AddItem();
            CheckEnableButtons();
            CheckOKEnabled();
        }
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            EditItem();
            CheckEnableButtons();
            CheckOKEnabled();
        }
        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteItems();
            CheckEnableButtons();
            CheckOKEnabled();
        }
        #endregion

        #region Buttons events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            OKClicked();
        }
        #endregion

        #region List view events
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnableButtons();
        }
        private void lvwEntries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editToolStripButton_Click(sender, e);
                e.Handled = true;
            }
        }
        private void lvwEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                removeToolStripButton_Click(null, null);
        }
        #endregion

        #region Virtual overrides
        public virtual void LoadList() 
        {
            CheckOKEnabled();
        }
        public virtual void DoResize() { }
        public virtual void AddItem() { CheckOKEnabled(); }
        public virtual void EditItem() { CheckOKEnabled(); }
        public virtual void DeleteItems()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected entries?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                    {
                        lvwEntries.Items.Remove(lvi);
                    }
                    CheckOKEnabled();
                }
            }
        }
        public virtual void OKClicked() { MessageBox.Show("Method OKClicked needs to be implmented in inherited class"); }
        public virtual void CheckEnableButtons()
        {
            editToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count == 1;
            editToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1;
            removeToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count > 0;
            removeToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
        }
        public virtual bool CheckOKEnabled()
        {
            cmdOK.Enabled = (lvwEntries.Items.Count > 0);
            return cmdOK.Enabled;
        } 
        #endregion

        #region IEditConfigWindow Members
        public IAgentConfig SelectedConfig { get; set; }
        public void SetTitle(string title)
        {
            Text = title;
        }
        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }
        #endregion
    }
}
