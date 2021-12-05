using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\4\input.txt").Split("\r\n\r\n");

            List<BingoBoard> playersPart1 = new();
            List<BingoBoard> playersPart2 = new();

            for (int i = 1; i < input.Length; i++)
            {
                playersPart1.Add(new BingoBoard(input[i]));
                playersPart2.Add(new BingoBoard(input[i]));
            }

            //Part1
            foreach (var num in input[0].Split(','))
            {
                foreach (var player in playersPart1)
                {
                    player.MarkNumber(int.Parse(num));
                }

                IEnumerable<BingoBoard> winner = from player in playersPart1 where player.ValidateWinner() select player;
                if(winner.Any())
                {
                    Console.WriteLine($"Final score part 1: {winner.First().GetUnmarkedNumbers().Sum() * int.Parse(num)}");
                    goto Part2;
                }
            }

            //Part2
            Part2:
            BingoBoard lastWinner = new();
            foreach (var num in input[0].Split(','))
            {
                foreach (var player in playersPart2)
                {
                    player.MarkNumber(int.Parse(num));
                }

                if(!lastWinner.Empty && lastWinner.ValidateWinner())
                {
                    Console.WriteLine($"Final score part 2: {lastWinner.GetUnmarkedNumbers().Sum() * int.Parse(num)}");
                    goto Finish;
                }

                IEnumerable<BingoBoard> winners = from player in playersPart2 where player.ValidateWinner() select player;

                if(winners.Count() == playersPart2.Count - 1)
                {
                    lastWinner = (from player in playersPart2 where !player.ValidateWinner() select player).First();
                }
            }
        Finish:;
        }
    }
}
