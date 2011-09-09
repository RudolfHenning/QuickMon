using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class ConsoleHelper
    {
        public static ConsoleKeyInfo ReadKeyWithTimeOut(int timeOutMS)
        {
            DateTime timeoutvalue = DateTime.Now.AddMilliseconds(timeOutMS);

            while (DateTime.Now < timeoutvalue)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();
                    return cki;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            return new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false); // false; //if no any keypress within 10 sec, return false
        }
    }
}
