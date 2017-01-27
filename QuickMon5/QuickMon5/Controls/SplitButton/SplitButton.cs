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
                return cmdMainButton.Image;
            }
            set
            {
                cmdMainButton.Image = value;
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

        public ContentAlignment ButtonImageAlignment
        {
            get
            {
                return cmdMainButton.ImageAlign;
            }
            set
            {
                cmdMainButton.ImageAlign = value;
            }
        }

        public Padding ButtonPadding
        {
            get
            {
                return cmdMainButton.Padding;
            }
            set
            {
                cmdMainButton.Padding = value;
            }
        }
        public Padding ButtonMargin
        {
            get
            {
                return cmdMainButton.Margin;
            }
            set
            {
                cmdMainButton.Margin = value;
            }
        }
        public string ButtonText
        {
            get
            {
                return cmdMainButton.Text;
            }
            set
            {
                cmdMainButton.Text = value;
            }
        }
        public ContentAlignment ButtonTextAlign
        {
            get
            {
                return cmdMainButton.TextAlign ;
            }
            set
            {
                cmdMainButton.TextAlign = value;
            }
        }
        public Font ButtonFont
        {
            get
            {
                return cmdMainButton.Font;
            }
            set
            {
                cmdMainButton.Font = value;
            }
        }

        public string ButtonToolTip
        {
            get
            {
                return toolTip1.GetToolTip(cmdMainButton);
            }
            set
            {
                toolTip1.SetToolTip(cmdMainButton, value);
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
