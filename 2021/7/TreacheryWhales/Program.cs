using System;
using System.Collections.Generic;
using System.Linq;

namespace TreacheryWhales
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\7\input.txt").Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            //Part 1
            int[] result = Enumerable.Repeat(0, input.Max() - input.Min()).ToArray();
            foreach (var crab in input)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] += Math.Abs(crab - i);
                }
            }

            Console.WriteLine(result.Min());

            //Part 2
            int[] result2 = Enumerable.Repeat(0, input.Max() - input.Min()).ToArray();
            foreach (var crab in input)
            {
                for (int i = 0; i < result2.Length; i++)
                {
                    var n = Math.Abs(crab - i);
                    result2[i] += n * (n + 1) / 2;
                }
            }

            Console.WriteLine(result2.Min());
        }
    }
}
