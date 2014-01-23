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
    public partial class SqlTableSizeCollectorViewDetails : SimpleDetailView, ICollectorDetailView
    {
        public SqlTableSizeCollectorViewDetails()
        {
            InitializeComponent();
        }

        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null)
            {
                SqlTableSizeCollectorConfig sqlTableSizeCollectorConfig = (SqlTableSizeCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                lvwEntries.Groups.Clear();
                foreach (SqlTableSizeCollectorEntry tableSizeEntry in sqlTableSizeCollectorConfig.Entries)
                {                    
                    ListViewGroup group = new ListViewGroup(tableSizeEntry.ToString(), tableSizeEntry.ToString());
                    group.Tag = tableSizeEntry;
                    lvwEntries.Groups.Add(group);
                    foreach (var tableEntry in tableSizeEntry.Tables)
                    {
                        ListViewItem lvi = new ListViewItem(tableEntry.TableName);
                        lvi.Group = group;
                        lvi.ImageIndex = 0;
                        lvi.SubItems.Add("-");
                        lvi.Tag = tableEntry;
                        lvwEntries.Items.Add(lvi);
                    }

                    
                }
            }
            base.LoadDisplayData();
        }
        public override void RefreshDisplayData()
        {
            foreach (ListViewGroup lvg in lvwEntries.Groups)
            {
                SqlTableSizeCollectorEntry tableSizeEntry = (SqlTableSizeCollectorEntry)lvg.Tag;
                List<Tuple<TableSizeEntry, CollectorState>> states = new List<Tuple<TableSizeEntry, CollectorState>>();
                try
                {
                    tableSizeEntry.RefreshRowCounts();
                    states = tableSizeEntry.GetStates();
                }
                catch { }
                foreach (ListViewItem lvi in lvg.Items)
                {
                    TableSizeEntry tableEntry = (TableSizeEntry)lvi.Tag;
                    if (tableEntry.RowCount > -1)
                        lvi.SubItems[1].Text = tableEntry.RowCount.ToString();
                    else
                        lvi.SubItems[1].Text = tableEntry.ErrorStr;
                    CollectorState currentState = (from s in states
                                                   where s.Item1.TableName == tableEntry.TableName
                                                   select s.Item2).FirstOrDefault();
                    if (currentState == CollectorState.Good)
                        lvi.ImageIndex = 0;
                    else if (currentState == CollectorState.Warning)
                        lvi.ImageIndex = 1;
                    else
                        lvi.ImageIndex = 2;
                }
            }
        }
    }
}
