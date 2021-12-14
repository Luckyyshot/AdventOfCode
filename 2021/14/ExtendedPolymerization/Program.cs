using System;

namespace ExtendedPolymerization
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\14\input.txt").Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
            string[] rules = input[1].Split("\r\n");

            PolymerTemplate part1 = new(input[0], rules);

            part1.RunInsertionRules(10);

            Console.WriteLine("Most common element minus least common element after 10 passes: " + part1.LeastCommonSubtractedMostCommon());

            PolymerTemplate part2 = new(input[0], rules);

            part2.RunInsertionRules(40);

            Console.WriteLine("Most common element minus least common element after 40 passes: " + part2.LeastCommonSubtractedMostCommon());
        }
    }
}
