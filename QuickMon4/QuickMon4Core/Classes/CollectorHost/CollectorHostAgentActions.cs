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
            RaiseStateUpdated();
        }
        public void SetCurrentState(MonitorState newState)
        {
            bool raiseAlertNow = false;
            if (currentState != null)
            {
                LastStateUpdate = DateTime.Now;
                if (FirstStateUpdate < (new DateTime(2000, 1, 1)))
                    FirstStateUpdate = DateTime.Now;

                bool stateChanged = currentState.State != newState.State;
                if (stateChanged)
                    LastStateChange = DateTime.Now;

                
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
                   
                AddStateToHistory(currentState);

                if (!CorrectiveScriptDisabled)
                {
                    if (!CorrectiveScriptsOnlyOnStateChange || stateChanged)
                    {
                        if (newState.State == CollectorState.Error && RunCollectorHostCorrectiveErrorScript != null)
                            RunCollectorHostCorrectiveErrorScript(this);
                        else if (newState.State == CollectorState.Warning && RunCollectorHostCorrectiveWarningScript != null)
                            RunCollectorHostCorrectiveWarningScript(this);
                        else if (newState.State == CollectorState.Good && RunCollectorHostCorrectiveWarningScript != null)
                            RunCollectorHostCorrectiveWarningScript(this);
                    }
                }
            }

            currentState = newState;
            RaiseStateUpdated();

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
        }
        public MonitorState RefreshCurrentState(bool disablePollingOverrides = false)
        {
            MonitorState resultMonitorState = new MonitorState() { State = CollectorState.NotAvailable };
            RefreshCount++;
            CurrentPollAborted = false;
            if (CurrentState.State != CollectorState.ConfigurationError)
            {
                if (!IsEnabledNow())
                {   
                    resultMonitorState.State = CollectorState.Disabled;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                }
                else if (CollectorAgents == null || CollectorAgents.Count == 0)//like old folder type collector
                {
                    resultMonitorState.State = CollectorState.None;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                }
                else if (CurrentState.State != CollectorState.NotAvailable && !disablePollingOverrides && EnabledPollingOverride && !EnablePollFrequencySliding && (LastStateUpdate.AddSeconds(OnlyAllowUpdateOncePerXSec) > DateTime.Now))
                {
                    //Not time yet for update
                    CurrentPollAborted = true;
                }
                else if (CurrentState.State != CollectorState.NotAvailable && !disablePollingOverrides && EnabledPollingOverride && EnablePollFrequencySliding &&
                    (
                        (StagnantStateThirdRepeat && (LastStateUpdate.AddSeconds(PollSlideFrequencyAfterThirdRepeatSec) > DateTime.Now)) ||
                        (!StagnantStateThirdRepeat && StagnantStateSecondRepeat && (LastStateUpdate.AddSeconds(PollSlideFrequencyAfterSecondRepeatSec) > DateTime.Now)) ||
                        (!StagnantStateThirdRepeat && !StagnantStateSecondRepeat && StagnantStateFirstRepeat && (LastStateUpdate.AddSeconds(PollSlideFrequencyAfterFirstRepeatSec) > DateTime.Now)) ||
                        (!StagnantStateFirstRepeat && !StagnantStateThirdRepeat && !StagnantStateSecondRepeat && (LastStateUpdate.AddSeconds(OnlyAllowUpdateOncePerXSec) > DateTime.Now))
                    )
                   )
                {
                    //Not time yet for update
                    CurrentPollAborted = true;
                }
                else
                {
                    //*********** Call actual collector GetState **********
                    LastStateCheckAttemptBegin = DateTime.Now;
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();

                    //first check if remote host exection is required
                    if (EnableRemoteExecute || (OverrideRemoteAgentHost && !BlockParentOverrideRemoteAgentHostSettings))
                    {
                        string currentHostAddress = EnableRemoteExecute ? this.RemoteAgentHostAddress : OverrideRemoteAgentHostAddress;
                        int currentHostPort = EnableRemoteExecute ? this.RemoteAgentHostPort : OverrideRemoteAgentHostPort;

                        try
                        {
                            resultMonitorState = RemoteCollectorHostService.GetCollectorHostState(this, currentHostAddress, currentHostPort);
                        }
                        catch (Exception ex)
                        {
                            resultMonitorState.Timestamp = DateTime.Now;
                            if (RunLocalOnRemoteHostConnectionFailure && ex.Message.Contains("There was no endpoint listening"))
                            {
                                resultMonitorState.RawDetails = "Remote excution failed. Attempting to run locally.";
                                //attempting to run locally
                                try
                                {
                                    foreach (var ca in CollectorAgents)
                                    {
                                        MonitorState caMs = ca.GetState();
                                        resultMonitorState.ChildStates.Add(caMs);
                                        //If we only care for the first success and find it don't look further
                                        if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstSuccess && caMs.State == CollectorState.Good)
                                            break;
                                        //If we only care for the first error and find it don't look further
                                        else if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstError && caMs.State == CollectorState.Error)
                                            break;
                                    }
                                }
                                catch (Exception exLocal)
                                {
                                    resultMonitorState.State = CollectorState.Error;
                                    resultMonitorState.RawDetails = exLocal.ToString();
                                }                                
                            }
                            else
                            {
                                resultMonitorState.State = CollectorState.Error;
                                resultMonitorState.RawDetails = ex.ToString();
                            }
                            resultMonitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                        }
                    }
                    else
                    {
                        foreach (var ca in CollectorAgents)
                        {
                            MonitorState caMs = ca.GetState();
                            resultMonitorState.ChildStates.Add(caMs);
                            //If we only care for the first success and find it don't look further
                            if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstSuccess && caMs.State== CollectorState.Good)
                                break;
                            //If we only care for the first error and find it don't look further
                            else if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstError && caMs.State== CollectorState.Error)
                                break;
                        }
                        resultMonitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                    }
                    sw.Stop();
                    resultMonitorState.CallDurationMS = (int)sw.ElapsedMilliseconds;
                    RaiseAllAgentsExecutionTime(sw.ElapsedMilliseconds);
                    
                    #region Calculate summarized state
                    if (AgentCheckSequence == QuickMon.AgentCheckSequence.All)
                    {
                        if (resultMonitorState.ChildStates.Count == (from cs in resultMonitorState.ChildStates
                                                                     where cs.State == CollectorState.Good
                                                                     select cs).Count())
                            resultMonitorState.State = CollectorState.Good;
                        else if (resultMonitorState.ChildStates.Count == (from cs in resultMonitorState.ChildStates
                                                                          where cs.State == CollectorState.Error
                                                                          select cs).Count())
                            resultMonitorState.State = CollectorState.Error;
                        else
                            resultMonitorState.State = CollectorState.Warning;
                    }
                    else if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstSuccess)
                    {
                        if ((from cs in resultMonitorState.ChildStates
                             where cs.State == CollectorState.Good
                             select cs).Count() > 0)
                            resultMonitorState.State = CollectorState.Good;
                        else if ((from cs in resultMonitorState.ChildStates
                                  where cs.State == CollectorState.Warning
                                  select cs).Count() > 0)
                            resultMonitorState.State = CollectorState.Warning;
                        else
                            resultMonitorState.State = CollectorState.Error;
                    }
                    else
                    {
                        if ((from cs in resultMonitorState.ChildStates
                             where cs.State == CollectorState.Error
                             select cs).Count() > 0)
                            resultMonitorState.State = CollectorState.Error;
                        else if ((from cs in resultMonitorState.ChildStates
                                  where cs.State == CollectorState.Warning
                                  select cs).Count() > 0)
                            resultMonitorState.State = CollectorState.Warning;
                        else
                            resultMonitorState.State = CollectorState.Good;
                    } 
                    #endregion

                    #region Check if stagnant settings should be (re)set
                    if (resultMonitorState.State != CurrentState.State)
                    {
                        StagnantStateFirstRepeat = false;
                        StagnantStateSecondRepeat = false;
                        StagnantStateThirdRepeat = false;
                    }
                    else if (!StagnantStateFirstRepeat)
                    {
                        StagnantStateFirstRepeat = true;
                        StagnantStateSecondRepeat = false;
                        StagnantStateThirdRepeat = false;
                    }
                    else if (!StagnantStateSecondRepeat)
                    {
                        StagnantStateSecondRepeat = true;
                        StagnantStateThirdRepeat = false;
                    }
                    else if (!StagnantStateThirdRepeat)
                    {
                        StagnantStateThirdRepeat = true;
                    } 
                    #endregion
                }
            }
            else
            {
                resultMonitorState.State = CollectorState.ConfigurationError;
            }
            //Set current CH state plus raise any alerts if required
            SetCurrentState(resultMonitorState);
            return resultMonitorState;
        }
    }
}
