using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HenIT.Controls
{
    public partial class ChooseTimeDialog : Form
    {
        public ChooseTimeDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(int x, int y)
        {
            this.Top = y;
            if (x + this.Width > Screen.FromControl(this).WorkingArea.Width)
            {
                x = Screen.FromControl(this).WorkingArea.Width - this.Width;
            }
            if (y + this.Height > Screen.FromControl(this).WorkingArea.Height)
            {
                y = Screen.FromControl(this).WorkingArea.Height - this.Height;
            }

            this.Left = x;
            return this.ShowDialog();
        }

        public int SelectedHour
        {
            get { return clockControl1.SelectedHour; }
            set { clockControl1.SelectedHour = value; }
        }
        public int SelectedMinute
        {
            get { return clockControl1.SelectedMinute; }
            set { clockControl1.SelectedMinute = value; }
        }


        private void chkPM_CheckedChanged(object sender, EventArgs e)
        {
            clockControl1.IsAM = !chkPM.Checked;
        }

        private void clockControl1_AMPMChanged(bool isAM)
        {
            chkPM.Checked = !clockControl1.IsAM;
        }

        private void ChooseTimeDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                DateTime tm = new DateTime(2000, 1, 1, clockControl1.SelectedHour, clockControl1.SelectedMinute, 0).AddMinutes(1);
                clockControl1.SelectedMinute = tm.Minute;
                clockControl1.SelectedHour = tm.Hour;
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                DateTime tm = new DateTime(2000, 1, 1, clockControl1.SelectedHour, clockControl1.SelectedMinute, 0).AddMinutes(-1);
                clockControl1.SelectedMinute = tm.Minute;
                clockControl1.SelectedHour = tm.Hour;
            }
        }

        private void clockControl1_TimeChanged(DateTime time)
        {
            cmdOK.Enabled = true;
        }

        private void ChooseTimeDialog_Load(object sender, EventArgs e)
        {

        }

        private void cmdNow_Click(object sender, EventArgs e)
        {
            clockControl1.SelectedHour = DateTime.Now.Hour;
            clockControl1.SelectedMinute = DateTime.Now.Minute;
        }
    }
}
