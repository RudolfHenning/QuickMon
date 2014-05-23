using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorEntry
    {
        /// <summary>
        /// Check if an Alert must be raised or not.
        /// </summary>
        /// <returns>True or False, you decide</returns>
        public bool RaiseAlert()
        {
            bool raiseAlert = false;
            if (IsFolder || !Enabled || //don't bother raising events for folders, disabled, N/A or collectors
                //CurrentState.State == CollectorState.Good || //No alerts for Good state
                CurrentState.State == CollectorState.NotAvailable ||
                CurrentState.State == CollectorState.Disabled)
            {
                raiseAlert = false;
                LastStateChange = DateTime.Now;                
                waitAlertTimeErrWarnInMinFlagged = false;
            }
            else
            {
                bool stateChanged = (LastMonitorState.State != CurrentState.State);

                if (stateChanged)
                {
                    if (LastMonitorState.State == CollectorState.Good)
                        numberOfPollingsInErrWarn = 0;

                    if (DelayErrWarnAlertForXSec > 0 || DelayErrWarnAlertForXPolls > 0) // alert should be delayed
                    {
                        delayErrWarnAlertTime = DateTime.Now.AddSeconds(DelayErrWarnAlertForXSec);
                        numberOfPollingsInErrWarn = 0;
                        waitAlertTimeErrWarnInMinFlagged = true;
                    }                    
                    else
                    {
                        raiseAlert = true;
                    }
                }
                else
                {
                    if (waitAlertTimeErrWarnInMinFlagged) //waiting for delayed alert
                    {
                        if (DelayErrWarnAlertForXSec > 0 && DateTime.Now > delayErrWarnAlertTime)
                        {
                            raiseAlert = true;
                            waitAlertTimeErrWarnInMinFlagged = false;
                            numberOfPollingsInErrWarn = 0;
                            //handle further alerts as if it changed now again
                            LastStateChange = DateTime.Now;
                        }
                        else if (DelayErrWarnAlertForXPolls > 0 && DelayErrWarnAlertForXPolls <= numberOfPollingsInErrWarn)
                        {
                            raiseAlert = true;
                            waitAlertTimeErrWarnInMinFlagged = false;
                            numberOfPollingsInErrWarn = 0;
                            //handle further alerts as if it changed now again
                            LastStateChange = DateTime.Now;
                        }
                        else
                        {
                            raiseAlert = false;
                        }
                    }
                    else
                    {

                        if (
                                (RepeatAlertInXMin > 0 && (LastStateChange.AddMinutes(RepeatAlertInXMin) < DateTime.Now)) ||
                                (RepeatAlertInXPolls > 0 && RepeatAlertInXPolls <= numberOfPollingsInErrWarn)
                            )
                        {
                            raiseAlert = true;
                            numberOfPollingsInErrWarn = 0;
                            //handle further alerts as if it changed now again
                            LastStateChange = DateTime.Now;
                        }
                        else
                        {
                            raiseAlert = false;
                        }
                    }
                }
                if (raiseAlert)
                {
                    //only allow repeat alert after specified minutes
                    if (AlertOnceInXMin > 0 && LastAlertTime.AddMinutes(AlertOnceInXMin) > DateTime.Now)
                    {
                        raiseAlert = false; //cancel alert
                    }
                }
                else
                {
                    if ( //(LastMonitorState.State == CollectorState.Warning || LastMonitorState.State == CollectorState.Error) &&
                            (CurrentState.State == CollectorState.Warning || CurrentState.State == CollectorState.Error))
                        numberOfPollingsInErrWarn++;
                    else
                        numberOfPollingsInErrWarn = 0;
                }
                if (raiseAlert)
                {
                    LastAlertTime = DateTime.Now; //reset alert time
                    if (CurrentState.State == CollectorState.Warning)
                        LastWarningAlertTime = DateTime.Now;
                    if (CurrentState.State == CollectorState.Error)
                        LastErrorAlertTime = DateTime.Now;
                }
            }
            return raiseAlert;
        }
    }
}
