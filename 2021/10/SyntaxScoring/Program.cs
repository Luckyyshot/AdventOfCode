using System;
using System.Collections.Generic;
using System.Linq;

namespace SyntaxScoring
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\10\input.txt").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            //Part 1
            int totalScore = 0;
            foreach (var str in input)
            {
                totalScore += SyntaxReader.CalcSyntaxErrorScore(str);
            }

            Console.WriteLine("Total syntax error score: " + totalScore);

            //Part 2
            List<double> scores = new();
            foreach (var str in input)
            {
                scores.Add(SyntaxReader.CalcSyntaxCompletionScore(str));
            }
            scores = scores.Where(i => i != 0).ToList();
            scores.Sort();

            Console.WriteLine("Middle score of the completion string scores: " + scores[scores.Count / 2]);
        }
    }
}
