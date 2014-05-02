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
    public partial class IISAppPoolCollectorDetailView : SimpleDetailView, ICollectorDetailView
    {
        public IISAppPoolCollectorDetailView()
        {
            InitializeComponent();
        }
        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null && ((IISAppPoolCollectorConfig)Collector.AgentConfig).Entries != null)
            {
                IISAppPoolCollectorConfig ssc = (IISAppPoolCollectorConfig)Collector.AgentConfig;
                lvwEntries.Groups.Clear();
                lvwEntries.Items.Clear();
                foreach (IISAppPoolMachine serviceDefinition in (from IISAppPoolMachine s in ssc.Entries
                                                                      orderby s.MachineName
                                                                      select s))
                {
                    ListViewGroup group = new ListViewGroup(serviceDefinition.MachineName);
                    group.Tag = serviceDefinition;
                    lvwEntries.Groups.Add(group);
                    foreach (IISAppPoolEntry serviceEntry in (from s in serviceDefinition.SubItems
                                                                       orderby s.Description
                                                                       select s))
                    {
                        ListViewItem lvi = new ListViewItem(serviceEntry.Description);
                        lvi.Group = group;
                        lvi.ImageIndex = 0;
                        lvi.Tag = serviceEntry;
                        lvwEntries.Items.Add(lvi);
                    }
                }
            }
        }
        public override void RefreshDisplayData()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                lvwEntries.BeginUpdate();
                foreach (ListViewGroup lvgMachine in lvwEntries.Groups)
                {
                    IISAppPoolMachine serviceDefinition = (IISAppPoolMachine)lvgMachine.Tag;
                    try
                    {                        
                        List<IISAppPoolStateInfo> sourceList = serviceDefinition.GetIISAppPoolStates();
                        foreach (ListViewItem lviAppPool in lvgMachine.Items)
                        {
                            IISAppPoolEntry entry = (IISAppPoolEntry)lviAppPool.Tag;
                            IISAppPoolStateInfo currentAppPool = (from ap in sourceList
                                                                  where ap.DisplayName == entry.Description
                                                                  select ap).FirstOrDefault();
                            if (currentAppPool == null || currentAppPool.Status == AppPoolStatus.Unknown)
                            {
                                lviAppPool.ImageIndex = 0;
                            }
                            else if (currentAppPool.Status == AppPoolStatus.Started)
                            {
                                lviAppPool.ImageIndex = 1;
                            }
                            else if (currentAppPool.Status == AppPoolStatus.Stopped)
                            {
                                lviAppPool.ImageIndex = 2;
                            }
                            else
                                lviAppPool.ImageIndex = 3;
                        }
                    }
                    catch(UnauthorizedAccessException unauthEx)
                    {
                        MessageBox.Show(string.Format("Cannot update the application pool list for {0} due to 'Unauthorized Access' error. Please restart this application in 'Admin' mode.\r\nDetails: {1}", serviceDefinition.MachineName, unauthEx.Message), "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(string.Format("Error updating application pool states of {0}\r\n{1}", serviceDefinition.MachineName, ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lvwEntries.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        private void IISAppPoolCollectorDetailView_Load(object sender, EventArgs e)
        {
            lvwEntries.AutoResizeColumnEnabled = true;
        }
    }
}
