using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public string SelectedCategory { get; set; }

        private void EditConfig_Shown(object sender, EventArgs e)
        {
            if (SelectedCategory != null && SelectedCategory.Length > 0)
                txtCategory.Text = SelectedCategory;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedCategory = txtCategory.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void llblInitialize_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCategory.Text.Length > 0)
            {
                try
                {
                    if (PerformanceCounterCategory.Exists(txtCategory.Text)) //Does performance counter category exists?
                    {
                        if (MessageBox.Show("The Performance counter Category already exist!\r\nDo you want to reinitialize it?\r\nWarning! This will delete any existing instances!", "Reinitialize", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                        PerformanceCounterCategory.Delete(txtCategory.Text);
                    }
                    CounterCreationDataCollection ccdc = new CounterCreationDataCollection(
                        new CounterCreationData[] 
                        {
                            new CounterCreationData("Value", "Raw Value", PerformanceCounterType.NumberOfItems32)
                        }
                        );
                    PerformanceCounterCategory.Create(txtCategory.Text, txtCategory.Text, PerformanceCounterCategoryType.MultiInstance, ccdc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
