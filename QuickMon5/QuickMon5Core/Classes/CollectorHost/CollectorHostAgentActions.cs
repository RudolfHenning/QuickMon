using System;
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
                if (!CurrentPollAborted)
                    LastStateUpdate = DateTime.Now;
                if (FirstStateUpdate < (new DateTime(2000, 1, 1)))
                    FirstStateUpdate = DateTime.Now;

                bool stateChanged = currentState.State != newState.State;

                #region Polling overide stuff
                if (stateChanged)
                {
                    LastStateChange = DateTime.Now;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                    if (EnabledPollingOverride && EnablePollFrequencySliding && CurrentState.State != CollectorState.NotAvailable)
                        RaiseLoggingPollingOverridesTriggeredEvent("Frequency sliding cancelled due to collector state value changed");
                }
                else if (EnabledPollingOverride && EnablePollFrequencySliding && CurrentState.State != CollectorState.NotAvailable)
                {
                    if (!StagnantStateFirstRepeat)
                    {
                        StagnantStateFirstRepeat = true;
                        StagnantStateSecondRepeat = false;
                        StagnantStateThirdRepeat = false;
                        RaiseLoggingPollingOverridesTriggeredEvent("Frequency sliding reached 1st stagnant stage");
                    }
                    else if (!StagnantStateSecondRepeat)
                    {
                        StagnantStateSecondRepeat = true;
                        StagnantStateThirdRepeat = false;
                        RaiseLoggingPollingOverridesTriggeredEvent("Frequency sliding reached 2nd stagnant stage");
                    }
                    else if (!StagnantStateThirdRepeat)
                    {
                        StagnantStateThirdRepeat = true;
                        RaiseLoggingPollingOverridesTriggeredEvent("Frequency sliding reached 3rd stagnant stage");
                    }
                } 
                #endregion

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

                if (currentState.RepeatCount == 0)
                    AddStateToHistory(currentState);

                #region Corrective scripts
                if (!CorrectiveScriptDisabled && (ParentMonitorPack == null || ParentMonitorPack.CorrectiveScriptsEnabled))
                {
                    if (newState.State == CollectorState.Good && stateChanged && (currentState.State == CollectorState.Error || currentState.State == CollectorState.Warning))
                    {
                        foreach (string scriptName in RunRestorationScripts())
                        {
                            newState.ScriptsRan.Add("Restoration script: " + scriptName);
                        }
                    }
                    else if (stateChanged || !CorrectiveScriptsOnlyOnStateChange)
                    {
                        if (newState.State == CollectorState.Error)
                        {
                            foreach (string scriptName in RunErrorCorrectiveScripts())
                            {
                                newState.ScriptsRan.Add("Error corrective script: " + scriptName);
                            }
                        }
                        else if (newState.State == CollectorState.Warning)
                        {
                            foreach (string scriptName in RunWarningCorrectiveScripts())
                            {
                                newState.ScriptsRan.Add("Warning corrective script: " + scriptName);
                            }
                        }
                    }
                } 
                #endregion
            }

            currentState = newState;

            #region Set Alert texts
            if (AlertHeaderText != null && AlertHeaderText.Trim().Length > 0)
            {
                currentState.AlertHeader = AlertHeaderText;
            }
            if (AlertFooterText != null && AlertFooterText.Trim().Length > 0)
            {
                currentState.AlertFooter = AlertFooterText;
            }
            if (currentState.State == CollectorState.Good && GoodAlertText != null && GoodAlertText.Trim().Length > 0)
            {
                currentState.AdditionalAlertText = GoodAlertText;
            }
            else if (currentState.State == CollectorState.Warning && WarningAlertText != null && WarningAlertText.Trim().Length > 0)
            {
                currentState.AdditionalAlertText = WarningAlertText;
            }
            else if (currentState.State == CollectorState.Error && ErrorAlertText != null && ErrorAlertText.Trim().Length > 0)
            {
                currentState.AdditionalAlertText = ErrorAlertText;
            }
            #endregion

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
            MonitorState resultMonitorState = new MonitorState() { State = CollectorState.NotAvailable, RepeatCount = 0 };
            if (AlertHeaderText != null && AlertHeaderText.Trim().Length > 0)
            {
                resultMonitorState.AlertHeader = AlertHeaderText;
            }
            if (AlertFooterText != null && AlertFooterText.Trim().Length > 0)
            {
                resultMonitorState.AlertFooter = AlertFooterText;
            }

            RefreshCount++;
            CurrentPollAborted = false;
            if (CurrentState.State != CollectorState.ConfigurationError)
            {
                if (InServiceWindow) //currently in Service window
                {
                    if (ServiceWindows.IsInTimeWindow()) //Service window expired
                    {
                        InServiceWindow = false;
                        RaiseEntereringServiceWindow();
                    }
                }
                else if (!ServiceWindows.IsInTimeWindow())
                {
                    InServiceWindow = true;
                    RaiseExitingServiceWindow();
                }

                if (!Enabled)
                {
                    resultMonitorState.State = CollectorState.Disabled;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                    resultMonitorState.RawDetails = "Collector host is disabled.";
                }
                else if (InServiceWindow)
                {
                    resultMonitorState.State = CollectorState.Disabled;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                    resultMonitorState.RawDetails = "Disabled due to 'out of service window' event.";
                }
                else if (CollectorAgents == null || CollectorAgents.Count == 0)//like old folder type collector
                {
                    resultMonitorState.State = CollectorState.None;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                    resultMonitorState.RawDetails = "There are no agents.";
                }
                else if (CollectorAgents != null && CollectorAgents.Count == CollectorAgents.Count(ca => !ca.Enabled))
                {
                    resultMonitorState.State = CollectorState.Disabled;
                    StagnantStateFirstRepeat = false;
                    StagnantStateSecondRepeat = false;
                    StagnantStateThirdRepeat = false;
                    resultMonitorState.RawDetails = "Disabled because all agents are disabled.";
                }
                else if (CurrentState.State != CollectorState.NotAvailable && !disablePollingOverrides && EnabledPollingOverride && !EnablePollFrequencySliding &&
                    (LastStateUpdate.AddSeconds(OnlyAllowUpdateOncePerXSec) > DateTime.Now))
                {
                    //Not time yet for update
                    CurrentPollAborted = true;
                    //repeat same State
                    resultMonitorState = null;
                    resultMonitorState = CurrentState;
                    resultMonitorState.RepeatCount++;
                    //if (resultMonitorState.RawDetails == null)
                    //    resultMonitorState.RawDetails = "";
                    //if (resultMonitorState.RawDetails.Length > 0)
                    //    resultMonitorState.RawDetails += "\r\n";
                    //resultMonitorState.RawDetails += "Due to polling override (OnlyAllowUpdateOncePerXSec) the previous state is repeated.";

                    //resultMonitorState.State = CurrentState.State;
                    //resultMonitorState.CurrentValue = CurrentState.ReadValues();
                    //resultMonitorState.RawDetails = "Due to polling override (OnlyAllowUpdateOncePerXSec) the previous state is repeated.";
                    RaiseLoggingPollingOverridesTriggeredEvent(string.Format("Polling override of {0} seconds not reached yet", OnlyAllowUpdateOncePerXSec));
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
                    //repeat same State
                    resultMonitorState = null;
                    resultMonitorState = CurrentState;
                    resultMonitorState.RepeatCount++;
                    //if (resultMonitorState.RawDetails == null)
                    //    resultMonitorState.RawDetails = "";
                    //if (resultMonitorState.RawDetails.Length > 0)
                    //    resultMonitorState.RawDetails += "\r\n";

                    //resultMonitorState.State = CurrentState.State;
                    //resultMonitorState.CurrentValue = CurrentState.ReadValues();
                    //if (StagnantStateThirdRepeat)
                    //    resultMonitorState.RawDetails += "Due to polling override (StagnantStateThirdRepeat) the previous state is repeated.";
                    //else if (StagnantStateSecondRepeat)
                    //    resultMonitorState.RawDetails += "Due to polling override (StagnantStateSecondRepeat) the previous state is repeated.";
                    //else if (StagnantStateFirstRepeat)
                    //    resultMonitorState.RawDetails += "Due to polling override (StagnantStateFirstRepeat) the previous state is repeated.";
                    //else
                    //    resultMonitorState.RawDetails += "Due to polling override (EnablePollFrequencySliding) the previous state is repeated.";
                }
                else
                {
                    //*********** Call actual collector GetState **********
                    LastStateCheckAttemptBegin = DateTime.Now;
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    //Applies config vars to Initial configs of agents (on the run)
                    ApplyConfigVarsNow();
                    sw.Start();

                    //first check if remote host exection is required
                    if (EnableRemoteExecute || (OverrideRemoteAgentHost && !BlockParentOverrideRemoteAgentHostSettings))
                    {
                        resultMonitorState = GetRemoteState();
                    }
                    else if (!RunAsEnabled || RunAs == null || RunAs.Length == 0 || RunTimeUserNameCacheFile == null || RunTimeUserNameCacheFile.Length == 0 || RunTimeMasterKey == null || RunTimeMasterKey.Length == 0)
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
            MonitorState resultMonitorState = new MonitorState()
            {
                State = CollectorState.UpdateInProgress,
                ExecutedOnHostComputer = System.Net.Dns.GetHostName(),
                RanAs = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            };
            try
            {
                //First set blank/NA state
                foreach (ICollector ca in CollectorAgents)
                {
                    ca.CurrentState = new MonitorState() { ForAgent = ca.Name, State = CollectorState.UpdateInProgress, RawDetails = "N/A", HtmlDetails = "<p>N/A</p>" };
                }
                int agentId = 0;
                foreach (ICollector ca in CollectorAgents)
                {
                    MonitorState caMs;
                    if (BlockedCollectorAgentTypes.Contains(ca.AgentClassName))
                    {
                        caMs = new MonitorState() { State = CollectorState.Disabled, RawDetails = "This agent is disabled by host process", HtmlDetails = "<p>This agent is disabled by host process</p>" };
                    }
                    else if (ca.Enabled)
                    {
                        caMs = ca.GetState();
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

        #region Run Corrective Scripts
        private List<string> RunRestorationScripts()
        {
            List<string> scriptsRan = new List<string>();
            if (RestorationScriptMinimumRepeatTimeMin > 0 && DateTime.Now < LastRestorationScriptRun.AddMinutes(RestorationScriptMinimumRepeatTimeMin))
                CorrectiveScriptMinRepeatTimeBlockedEvent?.Invoke(this, "Restoration script(s) blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
            else
            {
                foreach (var restorationScript in (from s in ActionScripts
                                                   where s.IsRestorationScript
                                                   select s))
                {
                    try
                    {
                        restorationScript.Run(false);
                        RestorationScriptExecuted?.Invoke(this, restorationScript.RunTimeLinkedActionScript.Name);
                        LastRestorationScriptRun = DateTime.Now;
                        scriptsRan.Add(restorationScript.RunTimeLinkedActionScript.Name);
                    }
                    catch (Exception ex)
                    {
                        RestorationScriptFailed?.Invoke(this, restorationScript.RunTimeLinkedActionScript.Name, ex.Message);
                    }
                }
                if (scriptsRan.Count > 0)
                    TimesRestorationScriptRan++;
            }
            return scriptsRan;
        }
        private List<string> RunWarningCorrectiveScripts()
        {
            List<string> scriptsRan = new List<string>();
            if (CorrectiveScriptOnWarningMinimumRepeatTimeMin > 0 && DateTime.Now < LastWarningCorrectiveScriptRun.AddMinutes(CorrectiveScriptOnWarningMinimumRepeatTimeMin))
                CorrectiveScriptMinRepeatTimeBlockedEvent?.Invoke(this, "Warning corrective script(s) blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
            else
            {
                foreach (var warningScript in (from s in ActionScripts
                                                   where s.IsWarningCorrectiveScript
                                                   select s))
                {
                    try
                    {
                        warningScript.Run(false);
                        WarningCorrectiveScriptExecuted?.Invoke(this, warningScript.RunTimeLinkedActionScript.Name);
                        LastWarningCorrectiveScriptRun = DateTime.Now;
                        scriptsRan.Add(warningScript.RunTimeLinkedActionScript.Name);
                    }
                    catch (Exception ex)
                    {
                        WarningCorrectiveScriptFailed?.Invoke(this, warningScript.RunTimeLinkedActionScript.Name, ex.Message);
                    }
                }
                if (scriptsRan.Count > 0)
                    TimesWarningCorrectiveScriptRan++;
            }
            return scriptsRan;
        }
        private List<string> RunErrorCorrectiveScripts()
        {
            List<string> scriptsRan = new List<string>();
            if (CorrectiveScriptOnErrorMinimumRepeatTimeMin > 0 && DateTime.Now < LastErrorCorrectiveScriptRun.AddMinutes(CorrectiveScriptOnErrorMinimumRepeatTimeMin))
                CorrectiveScriptMinRepeatTimeBlockedEvent?.Invoke(this, "Error corrective script(s) blocked from running. The specified minimum number of seconds have not passed since the last time the script ran!");
            else
            {
                foreach (var errorScript in (from s in ActionScripts
                                               where s.IsErrorCorrectiveScript
                                               select s))
                {
                    try
                    {
                        errorScript.Run(false);
                        ErrorCorrectiveScriptExecuted?.Invoke(this, errorScript.RunTimeLinkedActionScript.Name);
                        LastErrorCorrectiveScriptRun = DateTime.Now;
                        scriptsRan.Add(errorScript.RunTimeLinkedActionScript.Name);
                    }
                    catch (Exception ex)
                    {
                        ErrorCorrectiveScriptFailed?.Invoke(this, errorScript.RunTimeLinkedActionScript.Name,  ex.Message);
                    }
                }
                if (scriptsRan.Count > 0)
                    TimesErrorCorrectiveScriptRan++;
            }
            return scriptsRan;
        }
        #endregion
    }
}
