using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost
    {
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
                        throw new NotImplementedException("remote host exection not done yet");
                    }
                    else
                    {
                        foreach (var ca in CollectorAgents)
                        {
                            MonitorState caMs = ca.GetState();
                            resultMonitorState.ChildStates.Add(caMs);
                            if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstSuccess && caMs.State== CollectorState.Good)
                                break;
                            else if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstError && caMs.State== CollectorState.Error)
                                break;
                        }
                        resultMonitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                    }
                    sw.Stop();
                    resultMonitorState.CallDurationMS = (int)sw.ElapsedMilliseconds;

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
