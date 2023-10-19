using System;
using static System.Console;

namespace Hello
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("사용법: Hello.exe <서보경>");
                return;
            }
            WriteLine("Hello, {0}!", args[0]);
        }
    }
}