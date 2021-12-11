using System;
using System.Collections.Generic;
using System.Linq;

namespace SmokeBasin
{
    public class Pair<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public Pair(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }

    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\9\input.txt").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            
            //TODO: Refactor to avoid this stupid initialization.
            _ = new Heightmap(input);
        }
    }
}
