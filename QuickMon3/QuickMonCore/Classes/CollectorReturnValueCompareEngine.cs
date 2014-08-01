using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public enum CollectorReturnValueCheckSequenceType
    {
        GWE, //Test first for Good then Warning and then assume Error
        EWG  //Test first for Error then Warning and then assume good
    }
    public enum CollectorReturnValueCompareMatchType
    {
        Match,
        Contains,
        StartsWith,
        EndsWith,
        RegEx,
        IsNumber,
        LargerThan,
        SmallerThan,
        Between
    }
    public static class CollectorReturnValueCompareEngine
    {
        public static CollectorReturnValueCheckSequenceType CheckSequenceTypeFromString(string text)
        {
            if (text.ToLower() == "gwe")
                return CollectorReturnValueCheckSequenceType.GWE;
            else
                return CollectorReturnValueCheckSequenceType.EWG;
        }
        public static CollectorReturnValueCompareMatchType MatchTypeFromString(string text)
        {
            if (text.ToLower() == "match")
                return CollectorReturnValueCompareMatchType.Match;
            else if (text.ToLower() == "regex")
                return CollectorReturnValueCompareMatchType.RegEx;
            else if (text.ToLower() == "isnumber")
                return CollectorReturnValueCompareMatchType.IsNumber;
            else if (text.ToLower() == "largerthan")
                return CollectorReturnValueCompareMatchType.LargerThan;
            else if (text.ToLower() == "smallerthan")
                return CollectorReturnValueCompareMatchType.SmallerThan;
            else if (text.ToLower() == "startswith")
                return CollectorReturnValueCompareMatchType.StartsWith;
            else if (text.ToLower() == "endswith")
                return CollectorReturnValueCompareMatchType.EndsWith;
            else if (text.ToLower() == "between")
                return CollectorReturnValueCompareMatchType.Between;
            else
                return CollectorReturnValueCompareMatchType.Contains;
        }
        public static CollectorState GetState(CollectorReturnValueCheckSequenceType st,
            CollectorReturnValueCompareMatchType goodMatchType, string goodMatchFilter,
            CollectorReturnValueCompareMatchType warningMatchType, string warningMatchFilter,
            CollectorReturnValueCompareMatchType errorMatchType, string errorMatchFilter,
            object value)
        {
            CollectorState currentState = CollectorState.Good;
            if (st == CollectorReturnValueCheckSequenceType.GWE)
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
        public static bool TestResult(CollectorReturnValueCompareMatchType tcmt, string matchFilter, object resultToTest)
        {
            if (matchFilter.ToLower() == "[any]")
                return true;
            else if (matchFilter.ToLower() == "[null]" && (resultToTest == null || resultToTest == "[null]"))
                return true;
            switch (tcmt)
            {
                case CollectorReturnValueCompareMatchType.Match:
                    return matchFilter.ToLower() == resultToTest.ToString().ToLower();
                case CollectorReturnValueCompareMatchType.Contains:
                    return resultToTest.ToString().ToLower().Contains(matchFilter.ToLower());
                case CollectorReturnValueCompareMatchType.StartsWith:
                    return resultToTest.ToString().ToLower().StartsWith(matchFilter.ToLower());
                case CollectorReturnValueCompareMatchType.EndsWith:
                    return resultToTest.ToString().ToLower().EndsWith(matchFilter.ToLower());
                case CollectorReturnValueCompareMatchType.RegEx:
                    System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(resultToTest.ToString(), matchFilter, System.Text.RegularExpressions.RegexOptions.Multiline);
                    return match.Success;
                case CollectorReturnValueCompareMatchType.IsNumber:
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
                case CollectorReturnValueCompareMatchType.LargerThan:
                    if (!resultToTest.IsNumber() || !matchFilter.IsNumber())
                        throw new Exception("Test script or value is not a number!");
                    else
                        return double.Parse(resultToTest.ToString()) > double.Parse(matchFilter);
                case CollectorReturnValueCompareMatchType.SmallerThan:
                    if (!resultToTest.IsNumber() || !matchFilter.IsNumber())
                        throw new Exception("Test script or value is not a number!");
                    else
                        return double.Parse(resultToTest.ToString()) < double.Parse(matchFilter);
                case CollectorReturnValueCompareMatchType.Between:
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
