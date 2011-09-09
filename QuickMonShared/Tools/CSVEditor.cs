using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;


namespace QuickMon
{
    public partial class CSVEditor : Form
    {
        public CSVEditor()
        {
            InitializeComponent();
        }

        #region Properties
        public string ItemDescription
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }
        public string ItemWindowHeader
        {
            get { return Text; }
            set { Text = value; }
        }
        public string Tip
        {
            get { return lblTips.Text; }
            set { lblTips.Text = value; }
        }
        public bool Sorted
        {
            get { return lstItem.Sorted; }
            set
            {
                lstItem.Sorted = value;
                cmdMoveUp.Visible = !lstItem.Sorted;
                cmdMoveDown.Visible = !lstItem.Sorted;
            }
        }
        private bool clearTextOnUpdate = false;
        [Description("Clear text box after update")]
        public bool ClearTextOnUpdate { get { return clearTextOnUpdate; } set { clearTextOnUpdate = value; } }

        public string CSVData { get; set; } 
        #endregion

        #region Form events
        private void CSVEditor_Load(object sender, EventArgs e)
        {
            if (CSVData != null && CSVData.Length > 0)
            {
                lstItem.Items.AddRange(CSVData.ToListFromCSVString().ToArray());
            }
        } 
        #endregion

        #region List events
        private void lstItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItem.SelectedIndex > -1)
            {
                txtItem.Text = lstItem.SelectedItem.ToString();
                cmdAddUpdate.Text = "&Update";
                cmdMoveUp.Enabled = lstItem.SelectedIndex > 0;
                cmdMoveDown.Enabled = lstItem.SelectedIndex < lstItem.Items.Count - 1;
            }
            else
            {
                cmdMoveUp.Enabled = false;
                cmdMoveUp.Enabled = false;
            }
            cmdRemove.Enabled = (lstItem.SelectedIndex > -1);
        } 
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            CSVData = "";
            foreach (object item in lstItem.Items)
            {
                CSVData += item.ToString() + ", ";
            }
            CSVData = CSVData.Trim(' ',',');
            DialogResult = DialogResult.OK;
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            lstItem.SelectedIndex = -1;
            cmdAddUpdate.Text = "&Add";
            txtItem.Text = "";
            txtItem.Focus();
        }
        private void cmdAddUpdate_Click(object sender, EventArgs e)
        {
            if (txtItem.Text.Contains(","))
            {
                MessageBox.Show("Text cannot contain a comma ','!", "Add",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (lstItem.SelectedIndex > -1)
                {
                    lstItem.Items[lstItem.SelectedIndex] = txtItem.Text;
                }
                else
                {
                    lstItem.SelectedIndex = lstItem.Items.Add(txtItem.Text);
                    cmdAddUpdate.Text = "&Update";
                }
                if (clearTextOnUpdate)
                {
                    cmdNew_Click(sender, e);
                }
            }
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this item?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lstItem.SelectedIndex > -1)
                {
                    lstItem.Items.RemoveAt(lstItem.SelectedIndex);
                    txtItem.Text = "";
                }
            }
        }
        private void cmdMoveUp_Click(object sender, EventArgs e)
        {
            if (lstItem.SelectedIndex > 0)
            {
                SwapItems(lstItem.SelectedIndex - 1, lstItem.SelectedIndex, lstItem.SelectedIndex - 1);
            }
        }
        private void cmdMoveDown_Click(object sender, EventArgs e)
        {
            if (lstItem.SelectedIndex < lstItem.Items.Count - 1)
            {
                SwapItems(lstItem.SelectedIndex, lstItem.SelectedIndex + 1, lstItem.SelectedIndex + 1);
            }
        }
        #endregion

        #region Private methods
        private void SwapItems(int index1, int index2, int selectedIndex)
        {
            if (index1 < index2)
            {
                object tmp = lstItem.Items[index2];
                lstItem.Items.RemoveAt(index2);
                lstItem.Items.Insert(index1, tmp);
                lstItem.SelectedIndex = selectedIndex;

                cmdMoveUp.Enabled = lstItem.SelectedIndex > 0;
                cmdMoveDown.Enabled = lstItem.SelectedIndex < lstItem.Items.Count - 1;
            }
        } 
        #endregion       

    }
}
