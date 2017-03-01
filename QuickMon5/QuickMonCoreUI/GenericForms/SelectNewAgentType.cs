using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class SelectNewAgentType : Form
    {
        public SelectNewAgentType()
        {
            InitializeComponent();
        }

        private bool selectingCollectors = true;

        #region Properties
        public IAgent SelectedAgent { get; set; }
        #endregion

        public DialogResult ShowCollectorSelection()
        {
            this.Text = "Select Collector type";
            selectingCollectors = true;
            //SetDetailColumnSizing();
            //lvwAgentType.Items.Clear();
            //lvwAgentType.Groups.Clear();

            //ListViewGroup generalGroup = new ListViewGroup("General");
            //lvwAgentType.Groups.Add(generalGroup);
            //foreach (string categoryName in (from a in RegisteredAgentCache.Agents
            //                                 where a.IsCollector && a.CategoryName != "Test" && a.CategoryName != "General"
            //                                 group a by a.CategoryName into g
            //                                 orderby g.Key
            //                                 select g.Key))
            //{
            //    lvwAgentType.Groups.Add(new ListViewGroup(categoryName));
            //}
            //ListViewGroup testGroup = new ListViewGroup("Test");
            //lvwAgentType.Groups.Add(testGroup);
            //LoadTemplates();
            return this.ShowDialog();
        }
    }
}
