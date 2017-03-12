using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class PerfCounterEdit : Form
    {
        public PerfCounterEdit()
        {
            InitializeComponent();
            InitialMachine = ".";
        }

        #region Properties
        public PerfCounterCollectorEntry SelectedPCInstance { get; set; }
        public string InitialMachine { get; set; }
        public string InitialCategory { get; set; }
        public string InitialCounter { get; set; }
        public string InitialInstance { get; set; }
        #endregion

        #region Form events
        private void EditPerfCounter_Load(object sender, EventArgs e)
        {
            txtComputer.Text = InitialMachine;
            lvwCategories.AutoResizeColumnIndex = 0;
            lvwCategories.AutoResizeColumnEnabled = true;
            lvwCounters.AutoResizeColumnIndex = 0;
            lvwCounters.AutoResizeColumnEnabled = true;
            lvwInstances.AutoResizeColumnIndex = 0;
            lvwInstances.AutoResizeColumnEnabled = true;
        }

        private void EditPerfCounter_Shown(object sender, EventArgs e)
        {
            if (txtComputer.Text.Length > 0)
                LoadCategories(txtComputer.Text);
        }
        #endregion

        #region ListView events
        private void lvwCategories_Resize(object sender, EventArgs e)
        {
            ((ListView)sender).Columns[0].Width = ((ListView)sender).ClientSize.Width;
        }
        private void lvwCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwCategories.SelectedItems.Count > 0)
            {
                try
                {
                    PerformanceCounter[] pcs;
                    lvwCounters.Items.Clear();
                    lvwInstances.Items.Clear();
                    string category = lvwCategories.SelectedItems[0].Text;

                    PerformanceCounterCategory pcCat = new PerformanceCounterCategory(category, txtComputer.Text);
                    string instanceName = "";
                    if (pcCat.CategoryType == PerformanceCounterCategoryType.MultiInstance)
                    {
                        string[] instances = pcCat.GetInstanceNames();
                        foreach (string instanceNameItem in (from string s in instances
                                                             orderby s
                                                             select s))
                        {
                            ListViewItem lvi = new ListViewItem(instanceNameItem);
                            if (instanceNameItem.ToLower() == InitialInstance.ToLower())
                                lvi.Selected = true;
                            lvwInstances.Items.Add(lvi);
                        }
                        if (instances.Length > 0)
                            instanceName = pcCat.GetInstanceNames()[0];
                        pcs = pcCat.GetCounters(instanceName);
                    }
                    else
                        pcs = pcCat.GetCounters();
                    foreach (PerformanceCounter pc in (from p in pcs
                                                       orderby p.CounterName
                                                       select p))
                    {
                        ListViewItem lvi = new ListViewItem(pc.CounterName);
                        if (pc.CounterName.ToLower() == InitialCounter.ToLower())
                            lvi.Selected = true;
                        lvwCounters.Items.Add(lvi);
                    }
                    if (lvwInstances.SelectedItems.Count > 0)
                        lvwInstances.SelectedItems[0].EnsureVisible();
                    if (lvwCounters.SelectedItems.Count > 0)
                        lvwCounters.SelectedItems[0].EnsureVisible();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CheckForValidCounter();
        }
        private void lvwCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForValidCounter();
        }
        private void lvwInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForValidCounter();
        }
        #endregion

        #region Button events
        private void cmdLoadCategories_Click(object sender, EventArgs e)
        {
            LoadCategories(txtComputer.Text);
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckForValidCounter())
            {
                SelectedPCInstance = new PerfCounterCollectorEntry()
                {
                    Computer = txtComputer.Text,
                    Category = lvwCategories.SelectedItems[0].Text,
                    Counter = lvwCounters.SelectedItems[0].Text

                };
                if (lvwInstances.SelectedItems.Count > 0)
                    SelectedPCInstance.Instance = lvwInstances.SelectedItems[0].Text;
                else
                    SelectedPCInstance.Instance = "";
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Private methods
        private void LoadCategories(string machineName)
        {
            Cursor.Current = Cursors.WaitCursor;
            lvwCategories.Items.Clear();
            try
            {
                foreach (PerformanceCounterCategory performanceCounterCategory in (from p in PerformanceCounterCategory.GetCategories(machineName)
                                                                                   orderby p.CategoryName
                                                                                   select p))
                {
                    ListViewItem lvi = new ListViewItem(performanceCounterCategory.CategoryName);
                    if (InitialCategory != null && InitialCategory.Length > 0 && InitialCategory.ToLower() == performanceCounterCategory.CategoryName.ToLower())
                        lvi.Selected = true;
                    lvwCategories.Items.Add(lvi);
                }
                if (lvwCategories.SelectedItems.Count == 0)
                {
                    ListViewItem lviProc = (from ListViewItem lvi in lvwCategories.Items
                                            where lvi.Text == "Processor"
                                            select lvi).FirstOrDefault();
                    if (lviProc != null)
                        lviProc.Selected = true;
                }
                if (lvwCategories.SelectedItems.Count > 0)
                    lvwCategories.SelectedItems[0].EnsureVisible();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private bool CheckForValidCounter()
        {
            bool result = true;
            lblWarning.Text = "";
            if (txtComputer.Text.Length == 0)
            {
                result = false;
                lblWarning.Text = "Specify computer!";
            }
            else if (lvwCategories.SelectedItems.Count == 0)
            {
                result = false;
                lblWarning.Text = "Specify category!";
            }
            else if (lvwCounters.SelectedItems.Count == 0)
            {
                result = false;
                lblWarning.Text = "Specify counter!";
            }
            else if (lvwInstances.Items.Count > 0 && lvwInstances.SelectedItems.Count == 0)
            {
                result = false;
                lblWarning.Text = "Specify instance!";
            }
            else
            {
                result = true;
            }
            cmdOK.Enabled = result;
            return result;
        }
        #endregion


    }
}
