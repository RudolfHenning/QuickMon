using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
        private void EditServiceWindows_Load(object sender, EventArgs e)
        {
            dateTimePickerHoliday.MinDate = DateTime.Now.Date;
        }
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
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (!SelectedServiceWindows.Holidays.Contains(dateTimePickerHoliday.Value.Date))
            {
                SelectedServiceWindows.Holidays.Add(dateTimePickerHoliday.Value.Date);
            }
            LoadServiceWindowsTimes();
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            SelectedServiceWindows.Holidays.Clear();
            LoadServiceWindowsTimes();
        }
        private void cmdImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Open Holiday File";
                openFile.CheckFileExists = true;
                openFile.Filter = "Text Files|*.txt|All Files|*.*";
                if (openFile.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (var sr = File.OpenText(openFile.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            DateTime dt;

                            if (DateTime.TryParse(line.Trim(), out dt) && dt.Date >= DateTime.Now.Date && !SelectedServiceWindows.Holidays.Contains(dt))
                            {
                                SelectedServiceWindows.Holidays.Add(dt.Date);
                            }
                        }
                    }

                    LoadServiceWindowsTimes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Holiday list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            chkFri.Checked = false;
            chkMon.Checked = false;
            chkSat.Checked = false;
            chkSun.Checked = false;
            chkThur.Checked = false;
            chkTue.Checked = false;
            chkWed.Checked = false;

            foreach (var dow in SelectedServiceWindows.DaysOfWeek.ToArray())
            {
                switch (dow)
                {
                    case DayOfWeek.Friday:
                        chkFri.Checked = true;
                        break;
                    case DayOfWeek.Monday:
                        chkMon.Checked = true;
                        break;
                    case DayOfWeek.Saturday:
                        chkSat.Checked = true;
                        break;
                    case DayOfWeek.Sunday:
                        chkSun.Checked = true;
                        break;
                    case DayOfWeek.Thursday:
                        chkThur.Checked = true;
                        break;
                    case DayOfWeek.Tuesday:
                        chkTue.Checked = true;
                        break;
                    case DayOfWeek.Wednesday:
                        chkWed.Checked = true;
                        break;
                    default:
                        break;
                }

                listBoxHolidays.BeginUpdate();
                listBoxHolidays.Items.Clear();
                foreach (var holiday in (from h in SelectedServiceWindows.Holidays
                                         orderby h
                                         select h))
                {
                    if (!listBoxHolidays.Items.Contains(holiday))
                        listBoxHolidays.Items.Add(holiday);
                }
                listBoxHolidays.EndUpdate();
            }
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

        #region DayOfTheWeek
        private void chkDayOfWeek_CheckedChanged(object sender, EventArgs e)
        {
            var chk = ((CheckBox)sender);
            var dow = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), chk.Tag.ToString());
            if (!chk.Checked)
            {
                if (SelectedServiceWindows.DaysOfWeek.Contains(dow))
                    SelectedServiceWindows.DaysOfWeek.Remove(dow);
            }
            else
            {
                SelectedServiceWindows.DaysOfWeek.Add(dow);
            }

            LoadServiceWindowsTimes();
        } 
        #endregion

        #region Holidays
        private void listBoxHolidays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxHolidays.SelectedIndex > -1)
                {
                    SelectedServiceWindows.Holidays.Remove((DateTime)listBoxHolidays.SelectedItem);
                    listBoxHolidays.Items.Remove(listBoxHolidays.SelectedItem);
                }
            }
        } 
        #endregion
    }
}
