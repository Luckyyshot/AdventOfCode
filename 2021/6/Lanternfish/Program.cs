using System;
using System.Collections.Generic;
using System.Linq;

namespace Lanternfish
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\6\input.txt").Split(",", StringSplitOptions.RemoveEmptyEntries);
            List<int> result2 = input.Select(int.Parse).ToList();

            double[] stateCount = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            FishPopulation(80);
            FishPopulation(256);
        }

        static void FishPopulation(int days)
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\6\input.txt").Split(",", StringSplitOptions.RemoveEmptyEntries);
            List<int> result = input.Select(int.Parse).ToList();

            double[] stateCount = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            double fishCount = result.Count;
            int birthdate = 0;

            foreach (var fish in result)
            {
                stateCount[fish]++;
            }

            for (int i = 0; i < days; i++)
            {
                fishCount += stateCount[birthdate];
                stateCount[(birthdate + 7) % 9] += stateCount[birthdate];

                birthdate++;
                if (birthdate == 9)
                {
                    birthdate = 0;
                }
            }

            Console.WriteLine($"Total fish after {days}: {fishCount}");
        }
    }
}
