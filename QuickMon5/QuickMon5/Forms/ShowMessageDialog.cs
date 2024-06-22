using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class ShowMessageDialog : Form
    {
        public ShowMessageDialog()
        {
            InitializeComponent();
        }

        public string MessageToShow
        {
            get { return lblMsg.Text; }
            set { lblMsg.Text = value; }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
