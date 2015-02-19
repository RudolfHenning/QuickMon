using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HenIT.Controls
{
    public partial class DateTimeChooser : UserControl
    {
        public DateTimeChooser()
        {
            InitializeComponent();
        }

        #region Properties
        private DateTime selectedDateTime;
        public DateTime SelectedDateTime
        {
            get
            {
                selectedDateTime = DateTime.Parse(dtDate.Value.ToString("yyyy-MM-dd") + " " + txtHour.Text + ":" + txtMinute.Text);
                return selectedDateTime;
            }
            set
            {
                selectedDateTime = value;
                dtDate.Value = selectedDateTime;
                txtHour.Text = int.Parse(selectedDateTime.Hour.ToString()).ToString("00");
                txtMinute.Text = int.Parse(selectedDateTime.Minute.ToString()).ToString("00");
            }
        }
        #endregion

        public event System.EventHandler ValueChanged;
        public event System.EventHandler ValueAccepted;

        #region Time text box events

        private void txtHour_KeyDown(object sender, KeyEventArgs e)
        {
            int tmpHour;
            bool change = false;
            if (int.TryParse(txtHour.Text, out tmpHour))
            {
                if (e.KeyCode == Keys.Up)
                {
                    tmpHour++;
                    if (tmpHour >= 24)
                    {
                        tmpHour = 0;
                    }
                    change = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    tmpHour--;
                    if (tmpHour < 0)
                    {
                        tmpHour = 23;
                    }
                    change = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (txtHour.SelectionStart == txtHour.Text.Length)
                    {
                        txtMinute.Focus();
                        change = true;
                    }
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    DoValueAccepted(sender, e);
                }
                else if (e.KeyCode == Keys.Left)
                {
                }
                else if ((e.KeyValue < 48) || (e.KeyValue > 57))
                {
                    change = true;
                    e.SuppressKeyPress = true;
                }
            }
            if (change)
            {
                Math.DivRem(tmpHour, 24, out tmpHour);
                txtHour.Text = tmpHour.ToString("00");
                e.Handled = true;
            }
        }
        private void txtHour_Leave(object sender, EventArgs e)
        {
            int tmpHour;
            if (int.TryParse(txtHour.Text, out tmpHour))
            {
                Math.DivRem(tmpHour, 24, out tmpHour);
                txtHour.Text = tmpHour.ToString("00");
            }
        }
        private void txtMinute_KeyDown(object sender, KeyEventArgs e)
        {
            int tmpMinute;
            bool change = false;
            if (int.TryParse(txtMinute.Text, out tmpMinute))
            {
                if (e.KeyCode == Keys.Up)
                {
                    tmpMinute++;
                    if (tmpMinute >= 60)
                    {
                        tmpMinute = 0;
                    }
                    change = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    tmpMinute--;
                    if (tmpMinute < 0)
                    {
                        tmpMinute = 59;
                    }
                    change = true;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (txtMinute.SelectionStart == 0)
                    {
                        txtHour.Focus();
                        change = true;
                    }
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    DoValueAccepted(sender, e);
                }
                else if (e.KeyCode == Keys.Right)
                {
                }
                else if ((e.KeyValue < 48) || (e.KeyValue > 57))
                {
                    change = true;
                    e.SuppressKeyPress = true;
                }
            }
            if (change)
            {
                Math.DivRem(tmpMinute, 60, out tmpMinute);
                txtMinute.Text = tmpMinute.ToString("00");
                e.Handled = true;
            }
        }
        private void txtMinute_Leave(object sender, EventArgs e)
        {
            int tmpMinute;
            if (int.TryParse(txtMinute.Text, out tmpMinute))
            {
                Math.DivRem(tmpMinute, 60, out tmpMinute);
                txtMinute.Text = tmpMinute.ToString("00");
            }
        }
        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            int tmpHour;
            if (int.TryParse(txtHour.Text, out tmpHour))
            {
                DoValueChanged(sender, e);
            }
        }
        private void txtMinute_TextChanged(object sender, EventArgs e)
        {
            int tmpHour;
            if (int.TryParse(txtHour.Text, out tmpHour))
            {
                DoValueChanged(sender, e);
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }
        private void DoValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }
        private void DoValueAccepted(object sender, EventArgs e)
        {
            if (ValueAccepted != null)
                ValueAccepted(sender, e);
        }

        #endregion

        private void dtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoValueAccepted(sender, e);
            }
        }

        private void cmdTimePicker_Click(object sender, EventArgs e)
        {
            ChooseTimeDialog chooseTimeDialog = new ChooseTimeDialog();
            chooseTimeDialog.SelectedHour = int.Parse(txtHour.Text);
            chooseTimeDialog.SelectedMinute = int.Parse(txtMinute.Text);
            if (chooseTimeDialog.ShowDialog(Cursor.Position.X, Cursor.Position.Y + 15) == DialogResult.OK)
            {
                txtHour.Text = chooseTimeDialog.SelectedHour.ToString("00");
                txtMinute.Text = chooseTimeDialog.SelectedMinute.ToString("00");
                DoValueAccepted(sender, e);
            }

            //TimePicker timePicker = new TimePicker();
            //timePicker.SelectedTime = new DateTime(2000, 1, 1, int.Parse(txtHour.Text), int.Parse(txtMinute.Text), 0);
            //if (timePicker.ShowTimePicker(Cursor.Position.X, Cursor.Position.Y) == DialogResult.OK)
            //{
            //    txtHour.Text = timePicker.SelectedTime.Hour.ToString("00");
            //    txtMinute.Text = timePicker.SelectedTime.Minute.ToString("00");
            //    DoValueAccepted(sender, e);
            //}
        }

    }
}
