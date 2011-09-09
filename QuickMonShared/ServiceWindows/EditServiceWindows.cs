using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditServiceWindows : Form
    {
        public EditServiceWindows()
        {
            InitializeComponent();
        }

        public ServiceWindows SelectedServiceWindows { get; set; }

        #region Form events
        private void EditServiceWindows_Shown(object sender, EventArgs e)
        {
            if (SelectedServiceWindows == null)
                SelectedServiceWindows = new ServiceWindows();
            LoadServiceWindowsTimes();
        } 
        #endregion

        #region Button events
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            DateTime testFromTm;
            if (!DateTime.TryParse(fromTimeMaskedTextBox.Text, out testFromTm))
            {
                MessageBox.Show("Invalid 'From' time specified!", "From time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fromTimeMaskedTextBox.Focus();
                return;
            }
            DateTime testToTm;
            if (!DateTime.TryParse(toTimeMaskedTextBox.Text, out testToTm))
            {
                MessageBox.Show("Invalid 'To' time specified!", "To time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toTimeMaskedTextBox.Focus();
                return;
            }
            if (testFromTm >= testToTm)
            {
                MessageBox.Show("'From' must be before 'To' time!", "Time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fromTimeMaskedTextBox.Focus();
                return;
            }

            ServiceWindow newTimeWindow = new ServiceWindow(DateTime.Parse(fromTimeMaskedTextBox.Text), DateTime.Parse(toTimeMaskedTextBox.Text));
            if (lvwTimes.SelectedItems.Count > 0)
            {
                ServiceWindow timeWindow = (ServiceWindow)lvwTimes.SelectedItems[0].Tag;
                SelectedServiceWindows.Times.Remove(timeWindow);
            }
            SelectedServiceWindows.Times.Add(newTimeWindow);
            LoadServiceWindowsTimes();
            fromTimeMaskedTextBox.Text = "";
            toTimeMaskedTextBox.Text = "";
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            RemoveItems();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region ListView events
        private void lvwTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTimes.SelectedItems.Count > 0)
            {
                cmdRemove.Enabled = true;
                ServiceWindow timeWindow = (ServiceWindow)lvwTimes.SelectedItems[0].Tag;
                fromTimeMaskedTextBox.Text = timeWindow.From.ToString("HH:mm:ss");
                toTimeMaskedTextBox.Text = timeWindow.To.ToString("HH:mm:ss");
            }
            else
            {
                cmdRemove.Enabled = false;
                fromTimeMaskedTextBox.Text = "";
                toTimeMaskedTextBox.Text = "";
            }
        }
        private void lvwTimes_DeleteKeyPressed()
        {
            RemoveItems();
        }
        #endregion

        #region Private methods
        private void LoadServiceWindowsTimes()
        {
            lvwTimes.BeginUpdate();
            lvwTimes.Items.Clear();
            foreach (var timeWindow in (from t in SelectedServiceWindows.Times
                                        orderby t.From
                                        select t))
            {
                ListViewItem lvi = new ListViewItem(timeWindow.From.ToString("HH:mm:ss"));
                lvi.SubItems.Add(timeWindow.To.ToString("HH:mm:ss"));
                lvi.Tag = timeWindow;
                lvwTimes.Items.Add(lvi);
            }

            lvwTimes.EndUpdate();
        } 
        private void RemoveItems()
        {
            if (MessageBox.Show("Are you sure you want to remove the selected entries?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lvwTimes.SelectedItems)
                {
                    ServiceWindow timeWindow = (ServiceWindow)lvi.Tag;
                    SelectedServiceWindows.Times.Remove(timeWindow);
                    lvwTimes.Items.Remove(lvi);
                }
            }
        }
        #endregion
    }
}
