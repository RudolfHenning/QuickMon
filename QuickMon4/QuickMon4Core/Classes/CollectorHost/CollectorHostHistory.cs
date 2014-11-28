using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost
    {   
        public void UpdateCurrentCollectorState(CollectorState newState)
        {
            currentState.State = newState;
        }
        public void SetCurrentState(MonitorState newState)
        {
            if (currentState != null)
            {
                LastStateUpdate = DateTime.Now;
                if (FirstStateUpdate < (new DateTime(2000, 1, 1)))
                    FirstStateUpdate = DateTime.Now;

                bool stateChanged = currentState.State != newState.State;
                if (stateChanged)
                    LastStateChange = DateTime.Now;

                bool raiseAlertNow = false;
                #region Check if alert should be raised now               
                if (stateChanged)
                {
                    if (newState.State == CollectorState.Good)
                        numberOfPollingsInErrWarn = 0;
                    if (DelayErrWarnAlertForXSec > 0 || DelayErrWarnAlertForXPolls > 0) // alert should be delayed
                    {
                        delayErrWarnAlertTime = DateTime.Now.AddSeconds(DelayErrWarnAlertForXSec);
                        numberOfPollingsInErrWarn = 0;
                        waitAlertTimeErrWarnInMinFlagged = true;
                    }
                    else
                    {
                        raiseAlertNow = true;
                    }
                }
                else
                {
                    if (waitAlertTimeErrWarnInMinFlagged) //waiting for delayed alert
                    {
                        if (DelayErrWarnAlertForXSec > 0 && DateTime.Now > delayErrWarnAlertTime)
                        {
                            raiseAlertNow = true;
                            waitAlertTimeErrWarnInMinFlagged = false;
                            numberOfPollingsInErrWarn = 0;
                            //handle further alerts as if it changed now again
                            LastStateChange = DateTime.Now;
                        }
                        else if (DelayErrWarnAlertForXPolls > 0 && DelayErrWarnAlertForXPolls <= numberOfPollingsInErrWarn)
                        {
                            raiseAlertNow = true;
                            waitAlertTimeErrWarnInMinFlagged = false;
                            numberOfPollingsInErrWarn = 0;
                            //handle further alerts as if it changed now again
                            LastStateChange = DateTime.Now;
                        }
                        else
                        {
                            raiseAlertNow = false;
                        }
                    }
                    else
                    {
                        if (
                                (RepeatAlertInXMin > 0 && (LastStateChange.AddMinutes(RepeatAlertInXMin) < DateTime.Now)) ||
                                (RepeatAlertInXPolls > 0 && RepeatAlertInXPolls <= numberOfPollingsInErrWarn)
                            )
                        {
                            raiseAlertNow = true;
                            numberOfPollingsInErrWarn = 0;
                            //handle further alerts as if it changed now again
                            LastStateChange = DateTime.Now;
                        }
                        else
                        {
                            raiseAlertNow = false;
                        }
                    }
                }
                if (raiseAlertNow)
                {
                    //only allow repeat alert after specified minutes
                    if (AlertOnceInXMin > 0 && LastAlertTime.AddMinutes(AlertOnceInXMin) > DateTime.Now)
                    {
                        raiseAlertNow = false; //cancel alert
                    }
                }
                else
                {
                    if (newState.State == CollectorState.Warning || newState.State == CollectorState.Error)
                        numberOfPollingsInErrWarn++;
                    else
                        numberOfPollingsInErrWarn = 0;
                } 
                #endregion

                #region Raise event for Alert to be handled by Monitorpack
                if (raiseAlertNow)
                {
                    LastAlertTime = DateTime.Now; //reset alert time
                    switch (newState.State)
                    {
                        case CollectorState.Good:
                            LastGoodState = newState;
                            GoodStateCount++;
                            RaiseAlertGoodState();
                            break;
                        case CollectorState.Warning:
                            LastWarningState = newState;
                            WarningStateCount++;
                            RaiseAlertWarningState();
                            break;
                        case CollectorState.Error:
                        case CollectorState.ConfigurationError:
                            LastErrorState = newState;
                            ErrorStateCount++;
                            RaiseAlertErrorState();
                            break;
                        default:
                            RaiseNoStateChanged();
                            break;
                    }
                }
                else
                    RaiseNoStateChanged(); 
                #endregion
                
                AddStateToHistory(currentState);
            }
            currentState = newState;
        }
        private void AddStateToHistory(MonitorState newState)
        {
            try
            {
                if (stateHistory == null)
                    stateHistory = new List<MonitorState>();
                if (stateHistory.Count > MaxStateHistorySize)
                {
                    DateTime? oldestDate = (from h in stateHistory
                                            orderby h.Timestamp descending
                                            select h.Timestamp).Take(MaxStateHistorySize - 1).Min();
                    if (oldestDate != null)
                    {
                        stateHistory.RemoveAll(h => h.Timestamp < oldestDate.Value);
                    }
                }
#if DEBUG
                if (AlertsPaused)
                    newState.RawDetails += "\r\n(Alerts are paused for this collector)";
#endif
                stateHistory.Add(newState);
            }
            catch { }
        }
        public void UpdateLatestHistoryWithAlertDetails(MonitorState currentState)
        {
            try
            {
                if (stateHistory.Count  > 0)
                {
                    stateHistory[stateHistory.Count - 1].AlertsRaised = new List<string>();
                    stateHistory[stateHistory.Count - 1].AlertsRaised.AddRange(currentState.AlertsRaised.ToArray());
                }
            }
            catch { }
        }
    }
}
