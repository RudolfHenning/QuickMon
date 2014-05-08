using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenIT.IO;

namespace CopyAsAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineParser cmdParser = new CommandLineParser(args);
            if (args.Length < 2 || cmdParser.IsCommand("-?", "/?", "-h", "/h"))
            {
                ShowHelp();
            }
            else
            {
                bool overwrite = cmdParser.IsCommand("-Y", "/Y");
                bool waitOnExit = cmdParser.IsCommand("-W", "/W");
                bool delayOnExit = cmdParser.IsCommand("-D", "/D");
                string sourceFile = "";
                string destinationFile = "";
                int startIndex = -1;

                for (int i = 0; i < args.Length; i++)
                {
                    if (!(args[i].StartsWith("/") || args[i].StartsWith("-")))
                    {
                        startIndex = i;
                        break;
                    }
                }
                if (startIndex > -1)
                {
                    for (int i = startIndex; i < args.Length - 1; i = i + 2)
                    {
                        sourceFile = args[i];
                        destinationFile = args[i + 1];
                        if (CopyFile(sourceFile, destinationFile, overwrite))
                        {
                            Console.WriteLine("  File copied successfully");
                        }
                        else
                            Console.WriteLine("  File copy failed!");
                        Console.WriteLine("  -----------------------------------"); //creates empty line
                    }
                }
                if (delayOnExit)
                {
                    System.Threading.Thread.Sleep(3000);
                }              
                if (waitOnExit)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }

        private static bool CopyFile(string sourceFile, string destinationFile, bool overwrite)
        {
            bool success = false;
            if (!sourceFile.Contains("\\"))
            {
                sourceFile = System.IO.Path.Combine(Environment.CurrentDirectory, sourceFile);
            }
            Console.WriteLine("Copying '{0}' to '{1}'", sourceFile, destinationFile);
            try
            {
                if (System.IO.File.Exists(sourceFile))
                {
                    System.IO.File.Copy(sourceFile, destinationFile, overwrite);
                    success = true;
                }
                else
                    Console.WriteLine("Source file could not be found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage: CopyAsdmin.exe [-Y] [-E] <sourceFile> <destinationFile> [<sourceFile2> <destinationFile2>...]");
            Console.WriteLine("   where");
            Console.WriteLine("  -Y     : Do not prompt to overwrite");
            Console.WriteLine("  -W     : Wait on exit");
        }
    }
}
