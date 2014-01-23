using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenIT.Console
{
    public static class CommandLineUtils
    {
        #region GetDefault
        public static string GetDefault(string[] args, string defaultValue)
        {
            string commandValue = defaultValue;
            foreach (string arg in args)
            {
                if (arg.StartsWith("-") || arg.StartsWith("/"))
                    continue;
                else
                {
                    commandValue = arg;
                    break;
                }
            }
            return commandValue;
        }
        #endregion

        #region GetCommand
        public static string GetCommand(string[] args, string defaultValue, string commandSwitch)
        {
            string[] commandSwitches = commandSwitch.Split(',');
            return GetCommand(args, defaultValue, commandSwitches);
        }
        public static string GetCommand(string[] args, string commandSwitch)
        {
            return GetCommand(args, "", commandSwitch);
        }
        public static string GetCommandValue(string[] args, string[] commandSwitches)
        {
            return GetCommand(args, "", commandSwitches);
        }
        public static string GetCommand(string[] args, string defaultValue, params string[] commandSwitches)
        {
            string commandValue = defaultValue;
            bool foundValue = false;
            foreach (string arg in args)
            {
                foreach (string commandSwitch in commandSwitches)
                {
                    if (arg.ToUpper().StartsWith(commandSwitch.ToUpper()))
                    {
                        commandValue = arg.Substring(commandSwitch.Length);
                        foundValue = true;
                        break;
                    }
                }
                if (foundValue)
                    break;
            }
            return commandValue;
        }

        #endregion

        #region IsCommand
        public static bool IsCommand(string[] args, string commandSwitch)
        {
            string[] commandSwitches = commandSwitch.Split(',');
            return IsCommand(args, commandSwitches);
        }
        public static bool IsCommand(string[] args, params string[] commandSwitches)
        {
            foreach (string arg in args)
            {
                foreach (string commandSwitch in commandSwitches)
                {
                    if (arg.ToUpper() == commandSwitch.ToUpper())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
