using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class CollectorAgentReturnValueCompareEngine
    {
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
            else
                return CollectorAgentReturnValueCheckSequence.EWG;
        }
        public static CollectorAgentReturnValueCompareMatchType MatchTypeFromString(string text)
        {
            if (text.ToLower() == "match")
                return CollectorAgentReturnValueCompareMatchType.Match;
            else if (text.ToLower() == "regex")
                return CollectorAgentReturnValueCompareMatchType.RegEx;
            else if (text.ToLower() == "isnumber")
                return CollectorAgentReturnValueCompareMatchType.IsNumber;
            else if (text.ToLower() == "largerthan")
                return CollectorAgentReturnValueCompareMatchType.LargerThan;
            else if (text.ToLower() == "smallerthan")
                return CollectorAgentReturnValueCompareMatchType.SmallerThan;
            else if (text.ToLower() == "startswith")
                return CollectorAgentReturnValueCompareMatchType.StartsWith;
            else if (text.ToLower() == "endswith")
                return CollectorAgentReturnValueCompareMatchType.EndsWith;
            else if (text.ToLower() == "between")
                return CollectorAgentReturnValueCompareMatchType.Between;
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
            else
            {
                if (TestResult(errorMatchType, errorMatchFilter, value))
                    currentState = CollectorState.Error;
                else if (TestResult(warningMatchType, warningMatchFilter, value))
                    currentState = CollectorState.Warning;
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
                    return matchFilter.ToLower() == resultToTest.ToString().ToLower();
                case CollectorAgentReturnValueCompareMatchType.Contains:
                    return resultToTest.ToString().ToLower().Contains(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.StartsWith:
                    return resultToTest.ToString().ToLower().StartsWith(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.EndsWith:
                    return resultToTest.ToString().ToLower().EndsWith(matchFilter.ToLower());
                case CollectorAgentReturnValueCompareMatchType.RegEx:
                    System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(resultToTest.ToString(), matchFilter, System.Text.RegularExpressions.RegexOptions.Multiline);
                    return match.Success;
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
                default:
                    return matchFilter.ToLower() == resultToTest.ToString().ToLower();
            }
        }
    }
}
