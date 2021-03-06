﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class CollectorAgentReturnValueCompareEngine
    {
        /* expecting config like this
        <config>
          <carvcesEntries>
            <carvceEntry name="">
              <dataSource></dataSource>
              <testCondition testSequence="GWE">
                <success testType="matchType"></success>
                <warning testType="matchType"></warning>
                <error testType="matchType"></error>
              </testCondition>
            </carvceEntry>
          </carvcesEntries>		
        </config>
        */

        #region Casting Enums to usable formats
        public static List<string> ReturnValueCompareMatchTypesToList()
        {
            List<string> list = new List<string>();
            foreach (var e in Enum.GetNames(typeof(CollectorAgentReturnValueCompareMatchType)))
            {
                list.Add(e);
            }
            return list;
        }
        public static CollectorAgentReturnValueCheckSequence CheckSequenceTypeFromString(string text)
        {
            if (text.ToLower() == "gwe")
                return CollectorAgentReturnValueCheckSequence.GWE;
            else if (text.ToLower() == "ewg")
                return CollectorAgentReturnValueCheckSequence.EWG;
            else if (text.ToLower() == "gew")
                return CollectorAgentReturnValueCheckSequence.GEW;
            else if (text.ToLower() == "egw")
                return CollectorAgentReturnValueCheckSequence.EGW;
            else if (text.ToLower() == "wge")
                return CollectorAgentReturnValueCheckSequence.WGE;
            else if (text.ToLower() == "weg")
                return CollectorAgentReturnValueCheckSequence.WEG;
            else 
                return CollectorAgentReturnValueCheckSequence.GWE;
        }
        public static CollectorAgentReturnValueCompareMatchType MatchTypeFromString(string text)
        {
            if (text.ToLower() == "match")
                return CollectorAgentReturnValueCompareMatchType.Match;
            if (text.ToLower() == "doesnotmatch" || text.ToLower() == "notmatch")
                return CollectorAgentReturnValueCompareMatchType.DoesNotMatch;
            else if (text.ToLower() == "regex")
                return CollectorAgentReturnValueCompareMatchType.RegEx;
            else if (text.ToLower() == "isnumber")
                return CollectorAgentReturnValueCompareMatchType.IsNumber;
            else if (text.ToLower() == "isnotanumber" || text.ToLower() == "notanumber")
                return CollectorAgentReturnValueCompareMatchType.IsNotANumber;
            else if (text.ToLower() == "largerthan")
                return CollectorAgentReturnValueCompareMatchType.LargerThan;
            else if (text.ToLower() == "smallerthan")
                return CollectorAgentReturnValueCompareMatchType.SmallerThan;
            else if (text.ToLower() == "startswith")
                return CollectorAgentReturnValueCompareMatchType.StartsWith;
            else if (text.ToLower() == "doesnotstartwith" || text.ToLower() == "notstartwith")
                return CollectorAgentReturnValueCompareMatchType.DoesNotStartWith;
            else if (text.ToLower() == "endswith")
                return CollectorAgentReturnValueCompareMatchType.EndsWith;
            else if (text.ToLower() == "doesnotendwith" || text.ToLower() == "notendwith")
                return CollectorAgentReturnValueCompareMatchType.DoesNotEndWith;
            else if (text.ToLower() == "between")
                return CollectorAgentReturnValueCompareMatchType.Between;
            else if (text.ToLower() == "notbetween")
                return CollectorAgentReturnValueCompareMatchType.NotBetween;
            else if (text.ToLower() == "doesnotcontain" || text.ToLower() == "notcontain")
                return CollectorAgentReturnValueCompareMatchType.DoesNotContain;
            else
                return CollectorAgentReturnValueCompareMatchType.Contains;
        } 
        #endregion

        public static CollectorState GetState(CollectorAgentReturnValueCheckSequence st,
            CollectorAgentReturnValueCompareMatchType goodMatchType, string goodMatchFilter,
            CollectorAgentReturnValueCompareMatchType warningMatchType, string warningMatchFilter,
            CollectorAgentReturnValueCompareMatchType errorMatchType, string errorMatchFilter,
            object value)
        {
            CollectorState currentState = CollectorState.Good;
            if (st == CollectorAgentReturnValueCheckSequence.GWE)
            {
                if (TestResult(goodMatchType, goodMatchFilter, value))
                    currentState = CollectorState.Good;
                else if (TestResult(warningMatchType, warningMatchFilter, value))
                    currentState = CollectorState.Warning;
                else
                    currentState = CollectorState.Error;
            }
            else if (st == CollectorAgentReturnValueCheckSequence.EWG)
            {
                if (TestResult(errorMatchType, errorMatchFilter, value))
                    currentState = CollectorState.Error;
                else if (TestResult(warningMatchType, warningMatchFilter, value))
                    currentState = CollectorState.Warning;
                else
                    currentState = CollectorState.Good;
            }
            else if (st == CollectorAgentReturnValueCheckSequence.GEW)
            {
                if (TestResult(goodMatchType, goodMatchFilter, value))
                    currentState = CollectorState.Good;
                else if (TestResult(errorMatchType, errorMatchFilter, value))
                    currentState = CollectorState.Error;
                else
                    currentState = CollectorState.Warning;
            }
            else if (st == CollectorAgentReturnValueCheckSequence.EGW)
            {
                if (TestResult(errorMatchType, errorMatchFilter, value))
                    currentState = CollectorState.Error;
                else if (TestResult(goodMatchType, goodMatchFilter, value))
                    currentState = CollectorState.Good;
                else
                    currentState = CollectorState.Warning;
            }
            else if (st == CollectorAgentReturnValueCheckSequence.WGE)
            {
                if (TestResult(warningMatchType, warningMatchFilter, value))
                    currentState = CollectorState.Warning;
                else if (TestResult(goodMatchType, goodMatchFilter, value))
                    currentState = CollectorState.Good;
                else
                    currentState = CollectorState.Error;
            }
            else if (st == CollectorAgentReturnValueCheckSequence.WEG)
            {
                if (TestResult(warningMatchType, warningMatchFilter, value))
                    currentState = CollectorState.Warning;
                else if (TestResult(errorMatchType, errorMatchFilter, value))
                    currentState = CollectorState.Error;
                else
                    currentState = CollectorState.Good;
            }
            return currentState;
        }
        public static bool TestResult(CollectorAgentReturnValueCompareMatchType tcmt, string matchFilter, object resultToTest)
        {
            if (matchFilter.ToLower() == "[any]")
                return true;
            else if (matchFilter.ToLower() == "[null]" && (resultToTest == null || resultToTest.ToString() == "[null]"))
                return true;
            switch (tcmt)
            {
                case CollectorAgentReturnValueCompareMatchType.Match:
                    return matchFilter.ToLower() == resultToTest.ToString().Trim('\r', '\n').ToLower();
                case CollectorAgentReturnValueCompareMatchType.DoesNotMatch:
                    return matchFilter.ToLower() != resultToTest.ToString().Trim('\r', '\n').ToLower();
                case CollectorAgentReturnValueCompareMatchType.Contains:
                    return resultToTest.ToString().ToLower().Contains(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.DoesNotContain:
                    return !resultToTest.ToString().ToLower().Contains(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.StartsWith:
                    return resultToTest.ToString().Trim('\r', '\n').ToLower().StartsWith(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.DoesNotStartWith:
                    return !resultToTest.ToString().Trim('\r', '\n').ToLower().StartsWith(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.EndsWith:
                    return resultToTest.ToString().Trim('\r', '\n').ToLower().EndsWith(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.DoesNotEndWith:
                    return !resultToTest.ToString().Trim('\r', '\n').ToLower().EndsWith(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.RegEx:
                    System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(resultToTest.ToString().Trim('\r', '\n'), matchFilter, System.Text.RegularExpressions.RegexOptions.Multiline);
                    return match.Success;
                case CollectorAgentReturnValueCompareMatchType.IsNotANumber:
                    if (!resultToTest.IsNumber())
                        return true;
                    else
                        return false;
                case CollectorAgentReturnValueCompareMatchType.IsNumber:
                    if (!resultToTest.IsNumber())
                        return false;
                    else if (matchFilter.StartsWith("["))
                    {
                        if (matchFilter.ToLower().StartsWith("[between]") && matchFilter.ToLower().Contains("[and]"))
                        {
                            string[] queryItems = matchFilter.Split(' ');
                            if (resultToTest.IsNumber() && queryItems.Length == 4 && queryItems[1].IsNumber() && queryItems[3].IsNumber())
                                return (double.Parse(queryItems[1]) < double.Parse(resultToTest.ToString()))
                                    && (double.Parse(resultToTest.ToString()) < double.Parse(queryItems[3]));
                            else
                                throw new Exception("Value is not a number or macro syntax invalid!");
                        }
                        else
                            throw new Exception("Unknown or invalid macro syntax!");
                    }
                    else
                    {
                        if (!matchFilter.IsNumber())
                            throw new Exception("Test script is not a number or macro syntax invalid!");
                        else
                            return double.Parse(matchFilter) == double.Parse(resultToTest.ToString());
                    }
                case CollectorAgentReturnValueCompareMatchType.LargerThan:
                    if (!resultToTest.IsNumber() || !matchFilter.IsNumber())
                        throw new Exception("Test script or value is not a number!");
                    else
                        return double.Parse(resultToTest.ToString()) > double.Parse(matchFilter);
                case CollectorAgentReturnValueCompareMatchType.SmallerThan:
                    if (!resultToTest.IsNumber() || !matchFilter.IsNumber())
                        throw new Exception("Test script or value is not a number!");
                    else
                        return double.Parse(resultToTest.ToString()) < double.Parse(matchFilter);
                case CollectorAgentReturnValueCompareMatchType.Between:
                    if (!resultToTest.IsNumber())
                        throw new Exception("Value is not a number!");
                    else
                    {
                        string[] betweenMatchParts = matchFilter.Split(new string[] { " ", ",", "and" }, StringSplitOptions.RemoveEmptyEntries);
                        if (betweenMatchParts.Length < 2)
                            throw new Exception("Test script format invalid!");
                        else
                            return
                                double.Parse(betweenMatchParts[0]) < double.Parse(resultToTest.ToString()) &&
                                double.Parse(resultToTest.ToString()) < double.Parse(betweenMatchParts[betweenMatchParts.Length - 1]);
                    }
                case CollectorAgentReturnValueCompareMatchType.NotBetween:
                    if (!resultToTest.IsNumber())
                        throw new Exception("Value is not a number!");
                    else
                    {
                        string[] betweenMatchParts = matchFilter.Split(new string[] { " ", ",", "and" }, StringSplitOptions.RemoveEmptyEntries);
                        if (betweenMatchParts.Length < 2)
                            throw new Exception("Test script format invalid!");
                        else
                            return !(
                                double.Parse(betweenMatchParts[0]) < double.Parse(resultToTest.ToString()) &&
                                double.Parse(resultToTest.ToString()) < double.Parse(betweenMatchParts[betweenMatchParts.Length - 1])
                                );
                    }
                default:
                    return matchFilter.ToLower() == resultToTest.ToString().ToLower();
            }
        }
    }
}
