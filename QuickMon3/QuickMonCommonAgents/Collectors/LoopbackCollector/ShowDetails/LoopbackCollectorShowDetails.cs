using System;
using System.Drawing;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class LoopbackCollectorShowDetails : SimpleDetailView, ICollectorDetailView
    {
        public LoopbackCollectorShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
        }
        public override void RefreshDisplayData()
        {
            try
            {
                CollectorState currentState = ((LoopbackCollector)Collector).GetState().State;
                lblDisplayedState.Text = currentState.ToString() + " - " + DateTime.Now.ToString("HH:mm:ss");
                if (currentState == CollectorState.Error)
                {
                    lblDisplayedState.BackColor = Color.LightSalmon;
                }
                else if (currentState == CollectorState.Warning)
                {
                    lblDisplayedState.BackColor = Color.Yellow;
                }
                else if (currentState == CollectorState.Good)
                {
                    lblDisplayedState.BackColor = Color.LightGreen;
                }
                else
                {
                    lblDisplayedState.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                lblDisplayedState.BackColor = Color.LightSalmon;
                lblDisplayedState.Text = ex.Message + " - " + DateTime.Now.ToString("HH:mm:ss");
            }
        }
        #endregion

    }
}
