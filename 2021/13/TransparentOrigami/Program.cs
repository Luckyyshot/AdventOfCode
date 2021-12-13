using System;

namespace TransparentOrigami
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\13\input.txt").Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
            string[] foldInstructions = input[1].Split("\r\n");
            input = input[0].Split("\r\n");

            int x = 0, y = 0;
            if (foldInstructions[0][11] == 'x')
            {
                x = int.Parse(foldInstructions[0][13..]) * 2;
                y = int.Parse(foldInstructions[1][13..]) * 2;
            }
            else
            {
                x = int.Parse(foldInstructions[1][13..]) * 2;
                y = int.Parse(foldInstructions[0][13..]) * 2;
            }

            //Part 1
            Paper paper = new(input, x, y);

            paper = new Paper(paper.Fold(foldInstructions[0][11] == 'x'));

            //Console.WriteLine(test.ToString());  //Run at own risk.
            Console.WriteLine("Empty spaces: " + paper.CountDots());

            //Part 2
            paper = new(input, x, y);
            foreach (var instruction in foldInstructions)
            {
                if (instruction[11] == 'x')
                    paper = new Paper(paper.Fold(true));
                else
                    paper = new Paper(paper.Fold(false));
            }

            Console.WriteLine(paper.ToString());
        }
    }
}
