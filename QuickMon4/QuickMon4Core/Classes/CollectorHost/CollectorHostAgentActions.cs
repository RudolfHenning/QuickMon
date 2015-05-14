﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public partial class CollectorHost
    {
        #region MonitorState
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
                        else if (newState.State == CollectorState.Good && RunCollectorHostRestorationScript != null)
                            RunCollectorHostRestorationScript(this);
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
                else if (CollectorAgents != null && CollectorAgents.Count == CollectorAgents.Count(ca => !ca.Enabled))
                {
                    resultMonitorState.State = CollectorState.Disabled;
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
                        resultMonitorState = GetRemoteState();
                    }
                    else if (!RunAsEnabled || RunAs == null || RunAs.Length == 0 || RunTimeUserNameCacheFile == null || RunTimeUserNameCacheFile.Length ==0 || RunTimeMasterKey == null || RunTimeMasterKey.Length ==0)
                    {
                        resultMonitorState = GetStateFromLocalCurrentUser();
                    }
                    else
                    {
                        resultMonitorState = GetStateFromLocal();
                    }
                    sw.Stop();
                    resultMonitorState.CallDurationMS = (int)sw.ElapsedMilliseconds;
                    RaiseAllAgentsExecutionTime(sw.ElapsedMilliseconds);

                    #region Calculate summarized state
                    if (resultMonitorState.ChildStates != null && resultMonitorState.ChildStates.Count > 0)
                    {
                        int allCount = resultMonitorState.ChildStates.Count;
                        int disabledCount = (from cs in resultMonitorState.ChildStates
                                             where cs.State == CollectorState.Disabled
                                             select cs).Count();
                        int goodCount = (from cs in resultMonitorState.ChildStates
                                         where cs.State == CollectorState.Good
                                         select cs).Count();
                        int warningCount = (from cs in resultMonitorState.ChildStates
                                            where cs.State == CollectorState.Warning
                                            select cs).Count();
                        int errorCount = (from cs in resultMonitorState.ChildStates
                                          where cs.State == CollectorState.Error
                                          select cs).Count();

                        if (allCount == disabledCount)
                            resultMonitorState.State = CollectorState.Disabled;
                        else if (AgentCheckSequence == QuickMon.AgentCheckSequence.All)
                        {
                            if (allCount - disabledCount == goodCount)
                                resultMonitorState.State = CollectorState.Good;
                            else if (allCount - disabledCount == errorCount)
                                resultMonitorState.State = CollectorState.Error;
                            else
                                resultMonitorState.State = CollectorState.Warning;
                        }
                        else if (AgentCheckSequence == QuickMon.AgentCheckSequence.FirstSuccess)
                        {
                            if (goodCount > 0)
                                resultMonitorState.State = CollectorState.Good;
                            else if (warningCount > 0)
                                resultMonitorState.State = CollectorState.Warning;
                            else
                                resultMonitorState.State = CollectorState.Error;
                        }
                        else
                        {
                            if (errorCount > 0)
                                resultMonitorState.State = CollectorState.Error;
                            else if (warningCount > 0)
                                resultMonitorState.State = CollectorState.Warning;
                            else
                                resultMonitorState.State = CollectorState.Good;
                        }
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
        private MonitorState GetRemoteState()
        {
            MonitorState resultMonitorState = new MonitorState() { State = CollectorState.NotAvailable };
            string currentHostAddress = EnableRemoteExecute ? this.RemoteAgentHostAddress : OverrideRemoteAgentHostAddress;
            int currentHostPort = EnableRemoteExecute ? this.RemoteAgentHostPort : OverrideRemoteAgentHostPort;

            try
            {
                //First set blank/NA state
                foreach (ICollector ca in CollectorAgents)
                {
                    ca.CurrentState = new MonitorState() { ForAgent = ca.Name, State = CollectorState.NotAvailable, RawDetails = "Remote agent used", HtmlDetails = "<p>Remote agent used</p>" };
                }
                resultMonitorState = RemoteCollectorHostService.GetCollectorHostState(this, currentHostAddress, currentHostPort);
                foreach (var agentState in resultMonitorState.ChildStates)
                {
                    if (agentState.ForAgentId > -1 && agentState.ForAgentId < CollectorAgents.Count)
                    {
                        CollectorAgents[agentState.ForAgentId].CurrentState.FromXml(agentState.ToXml());
                    }
                }
            }
            catch (Exception ex)
            {
                resultMonitorState.Timestamp = DateTime.Now;
                if (RunLocalOnRemoteHostConnectionFailure && ex.Message.Contains("There was no endpoint listening"))
                {
                    //attempting to run locally
                    resultMonitorState = GetStateFromLocal();
                    resultMonitorState.RawDetails = string.Format("Remote excution failed. Attempting to run locally. {0}", resultMonitorState.RawDetails);
                }
                else
                {
                    resultMonitorState.State = CollectorState.Error;
                    resultMonitorState.RawDetails = ex.ToString();
                    resultMonitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
                }
            }
            return resultMonitorState;
        }
        private MonitorState GetStateFromLocal()
        {
            MonitorState resultMonitorState = new MonitorState() { State = CollectorState.NotAvailable };
            if (!RunAsEnabled || RunAs == null || RunAs.Length == 0)
            {
                resultMonitorState = GetStateFromLocalCurrentUser();
            }
            else
            {
                //Getting username, Password and domain
                string password = QuickMon.Security.CredentialManager.GetAccountPassword(RunTimeUserNameCacheFile, RunTimeMasterKey, RunAs);
                string userName = RunAs;
                string domainName = System.Net.Dns.GetHostName();
                if (userName.Contains('\\'))
                {
                    domainName = userName.Substring(0, userName.IndexOf('\\'));
                    userName = userName.Substring(domainName.Length + 1);
                }
                bool impersonated = false;
                try
                {
                    impersonated = QuickMon.Security.Impersonator.Impersonate(userName, password, domainName);
                }
                catch { }
                resultMonitorState = GetStateFromLocalCurrentUser();
                if (impersonated)
                {
                    try
                    {
                        QuickMon.Security.Impersonator.UnImpersonate();
                    }
                    catch { }                
                }            
            }
            return resultMonitorState;
        }
        private MonitorState GetStateFromLocalCurrentUser()
        {
            MonitorState resultMonitorState = new MonitorState() { State = CollectorState.NotAvailable, 
                ExecutedOnHostComputer = System.Net.Dns.GetHostName(),
                RanAs = System.Security.Principal.WindowsIdentity.GetCurrent().Name };
            try
            {
                //First set blank/NA state
                foreach (ICollector ca in CollectorAgents)
                {
                    ca.CurrentState = new MonitorState() { ForAgent = ca.Name, State = CollectorState.NotAvailable, RawDetails = "N/A", HtmlDetails = "<p>N/A</p>" };
                }
                int agentId = 0;
                foreach (ICollector ca in CollectorAgents)
                {
                    MonitorState caMs;
                    if (ca.Enabled)
                    {
                        caMs = ca.GetState();
                        //if (!RunAsEnabled || RunAs == null || RunAs.Length == 0)
                        //{
                        //    caMs = ca.GetState();
                        //    caMs.RanAs = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        //}
                        //else
                        //{
                        //    string password = QuickMon.Security.CredentialManager.GetAccountPassword(RunTimeUserNameCacheFile, RunTimeMasterKey, RunAs);
                        //    string userName = RunAs;
                        //    string domainName = System.Net.Dns.GetHostName();
                        //    if (userName.Contains('\\'))
                        //    {
                        //        domainName = userName.Substring(0, userName.IndexOf('\\'));
                        //        userName = userName.Substring(domainName.Length + 1);
                        //    }
                        //    if (!QuickMon.Security.Impersonator.Impersonate(userName, password, domainName))
                        //    {
                        //        caMs = ca.GetState();
                        //        caMs.RanAs = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        //    }
                        //    else
                        //    {
                        //        caMs = ca.GetState();
                        //        caMs.RanAs = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        //        QuickMon.Security.Impersonator.UnImpersonate();
                        //    }
                        //}
                    }
                    else
                    {
                        caMs = new MonitorState() { State = CollectorState.Disabled, RawDetails = "This agent is disabled", HtmlDetails = "<p>This agent is disabled</p>" };
                        //caMs.RanAs = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    }
                    caMs.ForAgent = ca.Name;
                    caMs.ForAgentId = agentId;
                    agentId++;

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
            //resultMonitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
            return resultMonitorState;
        } 
        #endregion

        #region Agent details
        public System.Data.DataSet GetAllAgentDetails(bool forceLocal = false)
        {
            System.Data.DataSet result = new System.Data.DataSet();
            if ((EnableRemoteExecute || (OverrideRemoteAgentHost && !BlockParentOverrideRemoteAgentHostSettings)) && !forceLocal)
            {
                result = GetAllAgentDetailsRemote();
            }
            else
            {
                result = GetAllAgentDetailsLocal();
            }
            return result;
        }

        private System.Data.DataSet GetAllAgentDetailsLocal()
        {
             System.Data.DataSet result = new System.Data.DataSet();
            foreach (ICollector ca in CollectorAgents)
            {
                int tableNo = 1;
                List<System.Data.DataTable> dts = ca.GetDetailDataTables();
                foreach (System.Data.DataTable dt in dts)
                {
                    if (dt.TableName.Length == 0)
                        dt.TableName = ca.Name;
                    while ((from System.Data.DataTable t in result.Tables
                            where t.TableName == dt.TableName
                            select t).Count() > 0)
                    {
                        dt.TableName = "Table " + tableNo.ToString();
                        tableNo++;
                    }
                    result.Tables.Add(dt);
                }
            }
            return result;
        }

        private System.Data.DataSet GetAllAgentDetailsRemote()
        {
            System.Data.DataSet result = new System.Data.DataSet();
            string currentHostAddress = EnableRemoteExecute ? this.RemoteAgentHostAddress : OverrideRemoteAgentHostAddress;
            int currentHostPort = EnableRemoteExecute ? this.RemoteAgentHostPort : OverrideRemoteAgentHostPort;

            try
            {
                result = RemoteCollectorHostService.GetRemoteHostAllAgentDetails(this, currentHostAddress, currentHostPort);
            }
            catch (Exception ex)
            {
                if (RunLocalOnRemoteHostConnectionFailure && ex.ToString().Contains("There was no endpoint listening"))
                {
                    //attempting to run locally
                    result = GetAllAgentDetailsLocal();
                }
                else
                {
                    throw;
                }
            }
            return result;
        }
        public System.Data.DataSet GetAllAgentDetailsRemote(string hostAddress, int hostPort)
        {
            System.Data.DataSet result = new System.Data.DataSet();
            result = RemoteCollectorHostService.GetRemoteHostAllAgentDetails(this, hostAddress, hostPort);
            return result;
        }
        #endregion
    }
}
