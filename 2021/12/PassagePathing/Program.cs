using System;
using System.Collections.Generic;

namespace PassagePathing
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\12\input.txt").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            CaveSystem test = new(input);

            List<Path> result1 = test.FindAllPaths(true);
            Console.BackgroundColor = ConsoleColor.Green;
            WriteResult("All paths where max one visit on small caves: " + result1.Count);

            List<Path> result2 = test.FindAllPaths(false);
            Console.BackgroundColor = ConsoleColor.Green;
            WriteResult("All paths where max two visits on one small cave and max one visit on the rest: " + result2.Count);
        }

        static void WriteResult(string str)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
