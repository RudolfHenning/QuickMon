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
    public partial class GraphColorSettings : Form
    {
        public GraphColorSettings()
        {
            InitializeComponent();
        }

        private void GraphColorSettings_Load(object sender, EventArgs e)
        {
            LoadColors();
        }

        private void LoadColors()
        {
            List<ListViewItem> lvis = new List<ListViewItem>();
            int seriesNo = 1;
            foreach(string colorName in Properties.Settings.Default.GraphLineColors)
            {
                ListViewItem lvi = new ListViewItem($"Series {seriesNo}");
                lvi.SubItems.Add(colorName);
                lvi.Tag = colorName;
                lvis.Add(lvi);
                seriesNo++;
            }
            lvwSeriesColors.Items.AddRange(lvis.ToArray());
        }
    }
}
