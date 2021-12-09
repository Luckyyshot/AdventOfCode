using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenSegmentSearch
{
    class Program
    {


        static void Main()
        {
            string[] seperators = { "\r\n", "|" };
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\8\input.txt").Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            //Part 1
            int unique1478Count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 1)
                {
                    foreach (var number in input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (number.Length == 2 || number.Length == 3 || number.Length == 4 || number.Length == 7)
                        {
                            unique1478Count++;
                        }
                    }
                }
            }
            Console.WriteLine("Total occurances of 1, 4, 7 and 8: " + unique1478Count);

            //Part 2
            int total = 0;
            Cipher temp = null;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    temp = new Cipher(input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries));
                }
                if (i % 2 == 1)
                {
                    total += temp.DetermineNumber(input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries));
                }
            }
            Console.WriteLine("Total sum of resulting numbers: " + total);
        }
    }
}
