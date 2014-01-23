using System;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class ServiceStateCollectorDetailView : SimpleDetailView, ICollectorDetailView
    {
        public ServiceStateCollectorDetailView()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null && ((ServiceStateCollectorConfig)Collector.AgentConfig).Entries != null)
            {
                ServiceStateCollectorConfig ssc = (ServiceStateCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                foreach (ServiceStateDefinition serviceDefinition in (from ServiceStateDefinition s in ssc.Entries
                                                                      orderby s.MachineName
                                                                      select s))
                {
                    ListViewGroup group = new ListViewGroup(serviceDefinition.MachineName);
                    lvwEntries.Groups.Add(group);
                    foreach (ServiceStateServiceEntry serviceEntry in (from s in serviceDefinition.SubItems
                                                    orderby s.Description
                                                    select s))
                    {
                        ListViewItem lvi = new ListViewItem(serviceEntry.Description);
                        lvi.Group = group;
                        lvi.ImageIndex = 3;
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
                foreach (ListViewItem itmX in lvwEntries.Items)
                {
                    string machineName = itmX.Group.Header;
                    string serviceName = itmX.Text;
                    try
                    {
                        ServiceController srvc = new ServiceController(serviceName, machineName);
                        if (srvc.Status == ServiceControllerStatus.Running)
                        {
                            itmX.ImageIndex = 0;
                        }
                        else if (srvc.Status == ServiceControllerStatus.Stopped)
                        {
                            itmX.ImageIndex = 1;
                        }
                        else if (srvc.Status == ServiceControllerStatus.Paused)
                        {
                            itmX.ImageIndex = 4;
                        }
                        else if (srvc.Status == ServiceControllerStatus.StartPending || srvc.Status == ServiceControllerStatus.StopPending)
                        {
                            itmX.ImageIndex = 2;
                        }
                        else
                            itmX.ImageIndex = 3;
                    }
                    catch (Exception ex)
                    {
                        itmX.ImageIndex = 3;
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
