using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost
    {

        //http://stackoverflow.com/questions/937181/c-sharp-pattern-to-prevent-an-event-handler-hooked-twice
        public CollectorHostDelegate alertGoodState;
        public event CollectorHostDelegate AlertGoodState;
        private void RaiseAlertGoodState()
        {
            if (alertGoodState != null)
            {
                alertGoodState(this);
            }
        }
        public event CollectorHostDelegate AlertWarningState;
        private void RaiseAlertWarningState()
        {
            if (AlertWarningState != null)
            {
                AlertWarningState(this);
                LastWarningAlertTime = DateTime.Now;
            }
        }
        public event CollectorHostDelegate AlertErrorState;
        private void RaiseAlertErrorState()
        {
            if (AlertErrorState != null)
            {
                AlertErrorState(this);
                LastErrorAlertTime = DateTime.Now;
            }
        }
        public event CollectorHostDelegate NoStateChanged;
        private void RaiseNoStateChanged()
        {
            if (NoStateChanged != null)
            {
                NoStateChanged(this);
            }
        }
    }
}
