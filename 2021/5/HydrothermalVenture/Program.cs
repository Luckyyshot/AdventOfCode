using System;

namespace HydrothermalVenture
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\5\input.txt").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            Grid gridone = new Grid(1000);
            Grid gridtwo = new Grid(1000);


            foreach (var line in input)
            {
                var temp = line.Split(new string[] { " -> ", "," }, StringSplitOptions.None);

                gridone.addLinesegment((int.Parse(temp[0]), int.Parse(temp[1])), (int.Parse(temp[2]), int.Parse(temp[3])), true);
                gridtwo.addLinesegment((int.Parse(temp[0]), int.Parse(temp[1])), (int.Parse(temp[2]), int.Parse(temp[3])), false);
            }

            Console.WriteLine($"Result part one: {gridone.countOverlapingPoints()}");
            Console.WriteLine($"Result part two: {gridtwo.countOverlapingPoints()}");
        }
    }
}
