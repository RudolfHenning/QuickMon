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
                string sourceFile = args[args.Length - 2];
                string destinationFile = args[args.Length - 1];

                if (!sourceFile.Contains("\\"))
                {
                    sourceFile = System.IO.Path.Combine(Environment.CurrentDirectory, sourceFile);
                }

                try
                {
                    if (System.IO.File.Exists(sourceFile))
                    {
                        System.IO.File.Copy(sourceFile, destinationFile, overwrite);
                        Console.WriteLine("File copied.");
                    }
                    else
                        Console.WriteLine("Source file could not be found!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                }
                if (waitOnExit)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage: CopyAsdmin.exe [-Y] [-E] <sourceFile> <destinationFile>");
            Console.WriteLine("   where");
            Console.WriteLine("  -Y     : Do not prompt to overwrite");
            Console.WriteLine("  -W     : Wait on exit");
        }
    }
}
