using System;
//using System.Linq;
using System.Collections.Generic;

namespace HenIT.IO
{
    public class CommandLineParser
    {
        private string[] arguments;

        public CommandLineParser()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 0 && args[0].ToLower().EndsWith(".exe"))
            {
                List<string> pargs = new List<string>();
                arguments = new string[args.Length - 1];
                for (int i = 1; i < args.Length; i++)
                {
                    pargs.Add(args[i]);
                }
                arguments = pargs.ToArray();
                //arguments = (from s in args select s).Skip(1).ToArray<string>();
            }
            else
            {
                arguments = new string[args.Length];
                for (int i = 1; i < args.Length; i++)
                {
                    arguments[i] = args[i];
                }
                //arguments = (from s in args select s).ToArray<string>();
            }
                
        }
        public CommandLineParser(string[] args)
        {
            arguments = args;
        }        

        #region GetDefaultValue
        /// <summary>
        /// Get the first command line value without a switch (like - or /)
        /// </summary>
        /// <param name="defaultValue">The default value in case no default command line value is found</param>
        /// <returns>The command line value</returns>
        public string GetDefaultValue(string defaultValue)
        {
            return GetDefaultValue(defaultValue, 1);
        }
        /// <summary>
        /// Get a fixed positioned command line value
        /// </summary>
        /// <param name="defaultValue">The default value in case no default command line value is found</param>
        /// <param name="position">The position of the default command line value</param>
        /// <returns>The command line value</returns>
        public string GetDefaultValue(string defaultValue, int position)
        {
            string commandValue = defaultValue;
            int nthValue = 1;
            foreach (string arg in arguments)
            {
                if (arg.StartsWith("-") || arg.StartsWith("/"))
                    continue;
                else
                {
                    if (nthValue <= position)
                    {
                        commandValue = arg;
                        break;
                    }
                    else
                        nthValue++;
                }
            }
            return commandValue;
        }
        #endregion

        #region GetCommandValue
        /// <summary>
        /// Get the value of a specified command line switch
        /// </summary>
        /// <param name="defaultValue">The default value in case no default command line value is found</param>
        /// <param name="commandSwitches">The command line switch to look for</param>
        /// <returns>The command line value after the switch</returns>
        public  string GetCommandValue(string defaultValue, params string[] commandSwitches)
        {
            string commandValue = defaultValue;
            bool foundValue = false;
            if ((commandSwitches.Length == 1) && (commandSwitches[0].Contains(",")))
            {
                commandValue = GetCommandValue(defaultValue, commandSwitches[0].Split(','));
            }
            else
            {
                foreach (string arg in arguments)
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
            }

            return commandValue;
        }
        #endregion

        #region IsCommand
        /// <summary>
        /// Test if command line parameters contains the specified switch
        /// </summary>
        /// <param name="commandSwitch">The command line switch to look for or comma separated list of values</param>
        /// <returns>True if found</returns>
        public  bool IsCommand(string commandSwitch)
        {
            string[] commandSwitches = commandSwitch.Split(',');
            return IsCommand(commandSwitches);
        }
        /// <summary>
        /// Test if command line parameters contains the specified switch
        /// </summary>
        /// <param name="commandSwitches">The command line switch to look for</param>
        /// <returns>True if found</returns>
        public  bool IsCommand(params string[] commandSwitches)
        {
            foreach (string arg in arguments)
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
