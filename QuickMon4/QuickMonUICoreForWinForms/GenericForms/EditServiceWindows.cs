using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class EditServiceWindows : Form
    {
        public EditServiceWindows()
        {
            InitializeComponent();
        }

        public ServiceWindows SelectedServiceWindows { get; set; }

        private void EditServiceWindows_Load(object sender, EventArgs e)
        {
            dateTimePickerHoliday.MinDate = DateTime.Now.Date;
        }

        private void EditServiceWindows_Shown(object sender, EventArgs e)
        {
            if (SelectedServiceWindows == null)
                SelectedServiceWindows = new ServiceWindows();
            LoadServiceWindowsTimes();
            LoadHolidays();
        }

        private void LoadServiceWindowsTimes()
        {
            lvwTimes.BeginUpdate();
            lvwTimes.Items.Clear();
            foreach (var timeWindow in (from t in SelectedServiceWindows.Entries
                                        orderby t.From
                                        select t))
            {
                ListViewItem lvi = new ListViewItem(timeWindow.From.ToString("HH:mm:ss"));
                lvi.SubItems.Add(timeWindow.To.ToString("HH:mm:ss"));
                if (timeWindow.AllWeekDays)
                    lvi.SubItems.Add("All");
                else
                {
                    string days = "";
                    timeWindow.Days.ForEach(d => days += d.ToString().Substring(0, 2).ToLower() + ",");
                    lvi.SubItems.Add(days.Trim(','));
                }
                lvi.Tag = timeWindow;
                lvwTimes.Items.Add(lvi);
            }

            lvwTimes.EndUpdate();
            chkAll.Checked = true;            
        }
        private void LoadHolidays()
        {
            listBoxHolidays.BeginUpdate();
            listBoxHolidays.Items.Clear();
            foreach (var holiday in (from h in SelectedServiceWindows.Holidays
                                     orderby h
                                     select h))
            {
                if (!listBoxHolidays.Items.Contains(holiday.ToString("yyyy-MM-dd")))
                    listBoxHolidays.Items.Add(holiday.ToString("yyyy-MM-dd"));
            }
            listBoxHolidays.EndUpdate();
        }

        bool checkChecking = false;
        private void chkSun_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChecking)
                CheckChecking();
        }        
        private void CheckChecking()
        {
            checkChecking = true;
            if ((chkSun.Checked && chkMon.Checked && chkTue.Checked && chkWed.Checked && chkThur.Checked && chkFri.Checked && chkSat.Checked) ||
                !(chkSun.Checked || chkMon.Checked || chkTue.Checked || chkWed.Checked || chkThur.Checked || chkFri.Checked || chkSat.Checked))
            {
                chkAll.Checked = true;
            }
            else
                chkAll.Checked = false;
            
            cmdUpdate.Enabled = chkSun.Checked || chkMon.Checked || chkTue.Checked || chkWed.Checked || chkThur.Checked || chkFri.Checked || chkSat.Checked;
            //if (cmdUpdate.Enabled && (lvwTimes.SelectedItems.Count == 1))
            //    cmdUpdate_Click(null, null);
            checkChecking = false;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkChecking)
            {
                checkChecking = true;

                chkSun.Checked = chkAll.Checked;
                chkMon.Checked = chkAll.Checked;
                chkTue.Checked = chkAll.Checked;
                chkWed.Checked = chkAll.Checked;
                chkThur.Checked = chkAll.Checked;
                chkFri.Checked = chkAll.Checked;
                chkSat.Checked = chkAll.Checked;                
                cmdUpdate.Enabled = chkAll.Checked;
                //if (cmdUpdate.Enabled && (lvwTimes.SelectedItems.Count == 1))
                //    cmdUpdate_Click(null, null);
                checkChecking = false;
            }
        }

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

            ServiceWindow editSW;
            ListViewItem lvi;
            string days = "";

            if (lvwTimes.SelectedItems.Count == 1)
            {
                lvi = lvwTimes.SelectedItems[0];
                editSW = (ServiceWindow)lvwTimes.SelectedItems[0].Tag;
            }
            else
            {
                lvi = new ListViewItem();
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");                
                editSW = new ServiceWindow();                
            }

            editSW.From = testFromTm;
            editSW.To = testToTm;
            editSW.Days.Clear();
            editSW.AllWeekDays = chkAll.Checked;
            if (chkSun.Checked) editSW.Days.Add(DayOfWeek.Sunday);
            if (chkMon.Checked) editSW.Days.Add(DayOfWeek.Monday);
            if (chkTue.Checked) editSW.Days.Add(DayOfWeek.Tuesday);
            if (chkWed.Checked) editSW.Days.Add(DayOfWeek.Wednesday);
            if (chkThur.Checked) editSW.Days.Add(DayOfWeek.Thursday);
            if (chkFri.Checked) editSW.Days.Add(DayOfWeek.Friday);
            if (chkSat.Checked) editSW.Days.Add(DayOfWeek.Saturday);

            lvi.Text = editSW.From.ToString("HH:mm:ss");
            lvi.SubItems[1].Text = editSW.To.ToString("HH:mm:ss");
            if (editSW.AllWeekDays)
                
                days = "All";
            else
            {                
                editSW.Days.ForEach(d => days += d.ToString().Substring(0, 2).ToLower() + ",");
                days = days.Trim(',');             
            }
            lvi.SubItems[2].Text = days;
            lvi.Tag = editSW;

            if (!lvi.Selected)
            {
                foreach (ListViewItem curlvi in lvwTimes.Items)
                {
                    if (curlvi.Text == testFromTm.ToString("HH:mm:ss") && curlvi.SubItems[1].Text == testToTm.ToString("HH:mm:ss") && curlvi.SubItems[2].Text == days)
                        return;
                }
                lvwTimes.Items.Add(lvi);
            }
            else
                lvi.Selected = true;
        }

        private void lvwTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTimes.SelectedItems.Count == 1)
            {
                ListViewItem lvi = lvwTimes.SelectedItems[0];
                fromTimeMaskedTextBox.Text = lvi.Text;
                toTimeMaskedTextBox.Text = lvi.SubItems[1].Text;
                if (lvi.SubItems[2].Text == "All")
                    chkAll.Checked = true;
                else
                {
                    ServiceWindow currentSW = (ServiceWindow)lvi.Tag;
                    chkSun.Checked = currentSW.Days.Contains(DayOfWeek.Sunday);
                    chkMon.Checked = currentSW.Days.Contains(DayOfWeek.Monday);
                    chkTue.Checked = currentSW.Days.Contains(DayOfWeek.Tuesday);
                    chkWed.Checked = currentSW.Days.Contains(DayOfWeek.Wednesday);
                    chkThur.Checked = currentSW.Days.Contains(DayOfWeek.Thursday);
                    chkFri.Checked = currentSW.Days.Contains(DayOfWeek.Friday);
                    chkSat.Checked = currentSW.Days.Contains(DayOfWeek.Saturday);                    
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedServiceWindows == null)
                SelectedServiceWindows = new ServiceWindows();
            SelectedServiceWindows.Entries.Clear();
            foreach(ListViewItem lvi in lvwTimes.Items)
            {
                SelectedServiceWindows.Entries.Add((ServiceWindow)lvi.Tag);
            }
            SelectedServiceWindows.Holidays.Clear();
            foreach(string ho in listBoxHolidays.Items)
            {
                SelectedServiceWindows.Holidays.Add(DateTime.Parse(ho));
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void lvwTimes_DeleteKeyPressed()
        {
            deleteToolStripMenuItem_Click(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvwTimes.SelectedItems.Count > 0 && MessageBox.Show("Are you sure you want to remove the selected entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach(int index in (from int i in lvwTimes.SelectedIndices
                                          orderby i descending
                                          select i))
                {
                    lvwTimes.Items.RemoveAt(index);
                }
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (!listBoxHolidays.Items.Contains(dateTimePickerHoliday.Value.Date.ToString("yyyy-MM-dd")))
            {
                listBoxHolidays.Items.Add(dateTimePickerHoliday.Value.Date.ToString("yyyy-MM-dd"));
            }            
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

                            if (DateTime.TryParse(line.Trim(), out dt) && dt.Date >= DateTime.Now.Date)
                            {
                                if (!listBoxHolidays.Items.Contains(dt.Date.ToString("yyyy-MM-dd")))
                                {
                                    listBoxHolidays.Items.Add(dt.Date.ToString("yyyy-MM-dd"));
                                }  
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Holiday list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the holiday list?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                listBoxHolidays.Items.Clear();
            }
        }

    }
}
