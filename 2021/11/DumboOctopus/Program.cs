using System;

namespace DumboOctopus
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\11\input.txt").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            //Part 1
            Octopi octopi1 = new(input);
            octopi1.SimulateSteps(100);
            Console.WriteLine("Flash count after 100 steps: " + octopi1.FlashCount);

            //Part 2
            Octopi octopi2 = new(input);
            Console.WriteLine("First step all octopi flashed: " + octopi2.FindFirstAllFlash());

        }
    }
}
