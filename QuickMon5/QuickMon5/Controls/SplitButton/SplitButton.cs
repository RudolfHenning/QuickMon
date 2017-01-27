using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon5.Controls.SplitButton
{
    public partial class SplitButton : UserControl
    {
        public SplitButton()
        {
            InitializeComponent();
        }

        public Image ButtonImage
        {
            get
            {
                return cmdMainButton.BackgroundImage;
            }
            set
            {
                cmdMainButton.BackgroundImage = value;
            }
        }
        public ImageLayout ButtonImageLayOut
        {
            get
            {
                return cmdMainButton.BackgroundImageLayout;
            }
            set
            {
                cmdMainButton.BackgroundImageLayout = value;
            }
        }

        public event EventHandler ButtonClicked;
        public event EventHandler SplitButtonClicked;

        private void cmdMainButton_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(sender, e);
        }

        private void cmdSideButton_Click(object sender, EventArgs e)
        {
            SplitButtonClicked?.Invoke(sender, e);
        }
    }
}
