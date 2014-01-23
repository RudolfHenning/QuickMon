using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class RegistryQueryCollectorShowDetails : SimpleDetailView, ICollectorDetailView
    {
        public RegistryQueryCollectorShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members        
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null)
            {
                lvwEntries.Items.Clear();
                foreach (RegistryQueryInstance rq in ((RegistryQueryCollectorConfig)Collector.AgentConfig).Entries)
                {
                    ListViewItem lvi = new ListViewItem(rq.Name);
                    lvi.SubItems.Add((rq.UseRemoteServer ? "[" + rq.Server + "]\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(rq.RegistryHive.ToString()).ToString() + "\\" + rq.Path + "\\@[" + rq.KeyName + "]");
                    lvi.SubItems.Add("-");
                    lvi.Tag = rq;
                    lvwEntries.Items.Add(lvi);
                }
            }
        }
        public override void RefreshDisplayData()
        {
            try
            {
                lvwEntries.BeginUpdate();
                if (Collector != null && Collector.AgentConfig != null)
                {
                    foreach (ListViewItem lvi in lvwEntries.Items)
                    {
                        if (lvi.Tag is RegistryQueryInstance)
                        {
                            RegistryQueryInstance rq = (RegistryQueryInstance)lvi.Tag;

                            try
                            {
                                object value = rq.GetValue();
                                CollectorState currentState = rq.EvaluateValue(value);
                                if (value == null)
                                    lvi.SubItems[2].Text = "Null";
                                else
                                    lvi.SubItems[2].Text = value.ToString();
                                if (currentState == CollectorState.Good)
                                {
                                    lvi.ImageIndex = 0;
                                    lvi.BackColor = SystemColors.Window;
                                }
                                else if (currentState == CollectorState.Warning)
                                {
                                    lvi.ImageIndex = 1;
                                    lvi.BackColor = Color.SandyBrown;
                                }
                                else
                                {
                                    lvi.ImageIndex = 2;
                                    lvi.BackColor = Color.Salmon;
                                }
                            }
                            catch (Exception ex)
                            {
                                lvi.SubItems[2].Text = ex.Message;
                                lvi.ImageIndex = 2;
                                lvi.BackColor = Color.Salmon;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwEntries.EndUpdate();
                toolStripStatusLabelDetails.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        #endregion
    }
}
