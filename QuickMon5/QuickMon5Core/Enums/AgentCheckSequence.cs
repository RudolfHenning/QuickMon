using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum AgentCheckSequence
    {
        /// <summary>
        /// All agent states are evaluated. For good state all agent states must be 'Good'. Same for error. Everything else is warning.
        /// </summary>
        All,
        /// <summary>
        /// Check until first 'Good' state is found. If not, test for first warning (from already returned results), then return error
        /// </summary>
        FirstSuccess,
        /// <summary>
        /// Check until first 'Error' state is found. If not, test for first warning (from already returned results), then return good
        /// </summary>
        FirstError
    }
    public static class AgentCheckSequenceConverter
    {
        public static AgentCheckSequence FromString(string s)
        {
            if (s.ToLower() == "firstsuccess")
                return AgentCheckSequence.FirstSuccess;
            else if (s.ToLower() == "firsterror")
                return AgentCheckSequence.FirstError;
            else
                return AgentCheckSequence.All;
        }
    }
}
