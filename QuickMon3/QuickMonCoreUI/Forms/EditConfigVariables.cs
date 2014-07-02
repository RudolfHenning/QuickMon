using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class EditConfigVariables : Form
    {
        public EditConfigVariables()
        {
            InitializeComponent();
        }

        private bool loadEntry = false;
        public List<ConfigVariable> SelectedConfigVariables { get; set; }

        private void EditConfigVariables_Load(object sender, EventArgs e)
        {
            lvwConfigVars.AutoResizeColumnIndex = 1;
            lvwConfigVars.AutoResizeColumnEnabled = true;
            if (SelectedConfigVariables == null)
                SelectedConfigVariables = new List<ConfigVariable>();
        }

        private void EditConfigVariables_Shown(object sender, EventArgs e)
        {
            loadEntry = true;
            foreach(ConfigVariable cv in SelectedConfigVariables)
            {
                ListViewItem lvi = new ListViewItem(cv.Name);
                lvi.SubItems.Add(cv.Value);
                lvi.Tag = cv;
                lvwConfigVars.Items.Add(lvi);
            }
            loadEntry = false;
        }

        private void lvwConfigVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count == 1)
            {
                loadEntry = true;
                txtName.Text = lvwConfigVars.SelectedItems[0].Text;
                txtValue.Text = lvwConfigVars.SelectedItems[0].SubItems[1].Text;
                loadEntry = false;
            }
            else
            {
                loadEntry = true;
                txtName.Text = "";
                txtValue.Text = "";
                loadEntry = false;
            }
            cmdDelete.Enabled = lvwConfigVars.SelectedItems.Count > 0;
        }

        private void UpdateListFromText()
        {
            if (!loadEntry)
            {
                if (lvwConfigVars.SelectedItems.Count == 1)
                {
                    lvwConfigVars.SelectedItems[0].Text = txtName.Text;
                    lvwConfigVars.SelectedItems[0].SubItems[1].Text = txtValue.Text;
                }
                else if (lvwConfigVars.SelectedItems.Count == 0)
                {
                    ListViewItem lvi = new ListViewItem(txtName.Text);
                    lvi.SubItems.Add(txtValue.Text);
                    lvi.Tag = new ConfigVariable() { Name = txtName.Text, Value = txtValue.Text };
                    lvwConfigVars.Items.Add(lvi);
                    lvi.Selected = true;
                }
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            UpdateListFromText();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            UpdateListFromText();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            loadEntry = true;
            lvwConfigVars.SelectedItems.Clear();
            txtName.Text = "";
            txtValue.Text = "";
            loadEntry = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count > 0)
            {
                loadEntry = true;
                if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwConfigVars.SelectedItems)
                        lvwConfigVars.Items.Remove(lvi);
                }
                txtName.Text = "";
                txtValue.Text = "";
                loadEntry = false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            List<ConfigVariable> acceptedVars = new List<ConfigVariable>();
            foreach(ListViewItem lvi in lvwConfigVars.Items)
            {
                if (lvi.Text.Trim().Length ==0)
                {
                    MessageBox.Show("All entries must have a 'Search for' value!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (lvi.SubItems[1].Text.Trim().Length == 0)
                {
                    if (MessageBox.Show("Are you sure you want to accept a blank 'Replace by' value for '" + lvi.Text + "'?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==  System.Windows.Forms.DialogResult.No)
                        return;
                }
                acceptedVars.Add(new ConfigVariable() { Name = lvi.Text, Value = lvi.SubItems[1].Text });
            }
            SelectedConfigVariables = acceptedVars;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
