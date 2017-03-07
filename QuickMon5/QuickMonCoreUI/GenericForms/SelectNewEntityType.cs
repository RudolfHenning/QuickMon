using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class SelectNewEntityType : Form
    {
        public SelectNewEntityType()
        {
            InitializeComponent();
        }

        private bool selectingCollectors = false;
        private bool selectingCollectorHosts = false;

        #region Properties
        public IAgent SelectedAgent { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }
        #endregion

        public DialogResult ShowCollectorHostSelection()
        {
            this.Text = "Select Collector Host type";
            selectingCollectorHosts = true;
            //SetDetailColumnSizing();
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
            ListViewItem lviEmptyCollector = new ListViewItem("Folder");
            lviEmptyCollector.SubItems.Add("Creates a new blank Collector with no Agents");
            lviEmptyCollector.Group = generalGroup;
            lviEmptyCollector.Tag = new CollectorHost() { Name = "Folder" };
            lvwAgentType.Items.Add(lviEmptyCollector);

            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);

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

        public DialogResult ShowCollectorSelection()
        {
            this.Text = "Select Collector type";
            selectingCollectors = true;
            //SetDetailColumnSizing();
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
            ListViewItem lviEmptyCollector = new ListViewItem("Folder");
            lviEmptyCollector.SubItems.Add("Creates a new blank Collector with no Agents");
            lviEmptyCollector.Group = generalGroup;
            lvwAgentType.Items.Add(lviEmptyCollector);

            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);

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

        private void lvwAgentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1 && lvwAgentType.SelectedItems[0].Tag != null;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgentType.SelectedItems.Count == 1)
            {
                if (selectingCollectorHosts)
                {
                    SelectedCollectorHost = (CollectorHost)lvwAgentType.SelectedItems[0].Tag;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
