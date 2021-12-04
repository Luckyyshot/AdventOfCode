using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            BingoBoard lastWinner = new BingoBoard();
            string[] input = System.IO.File.ReadAllText(@"D:\Repositories\AdventOfCode\2021\4\input.txt").Split("\r\n\r\n");
            List<BingoBoard> players = new List<BingoBoard>();
            for (int i = 1; i < input.Length; i++)
            {
                players.Add(new BingoBoard(input[i]));
            }
            foreach (var num in input[0].Split(','))
            {
                foreach (var player in players)
                {
                    player.markNumber(int.Parse(num));
                }
                foreach (var player in players)
                {
                    if (player.validateWinner())
                    {
                        player.winner = true;
                    }
                    if (!lastWinner.Empty && lastWinner.winner)
                    {
                        Console.WriteLine(num);
                        Console.WriteLine(lastWinner.getUnmarkedNumbers().Sum());
                        Console.WriteLine($"Final score: {lastWinner.getUnmarkedNumbers().Sum() * int.Parse(num)}");
                        goto Finish;
                    }
                }
                int winnerCount = 0;
                foreach (var player in players)
                {
                    if (player.winner)
                        winnerCount++;
                }
                if(winnerCount == players.Count - 1)
                {
                    foreach (var player in players)
                    {
                        if (!player.winner)
                            lastWinner = player;
                    }
                }
            }
            Finish:
            Console.WriteLine("search done");
        }
    }
}
