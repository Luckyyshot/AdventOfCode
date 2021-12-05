using System;
using System.Collections.Generic;

namespace Bingo
{
    class BingoBoard
    {
        public bool Empty = false;

        public (int, bool)[][] Board { get; set; }

        public BingoBoard()
        {
            Empty = true;
        }

        public BingoBoard(string board)
        {
            var boardarr = board.Replace("/n", "").Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            (int, bool)[][] result = new (int, bool)[5][];
            for (int i = 0; i < 5; i++)
            {
                result[i] = new (int, bool)[5];
                for (int j = 0; j < 5; j++)
                {
                    result[i][j] = (Int32.Parse(boardarr[i * 5 + j]), false);
                }
            }
            this.Board = result;
        }

        public void MarkNumber(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Board[i][j].Item1 == num)
                        Board[i][j].Item2 = true;
                }
            }
        }

        public bool ValidateWinner()
        {
            bool result = false;
            for (int i = 0; i < 5; i++)
            {
                result = result || (Board[i][0].Item2 && Board[i][1].Item2 && Board[i][2].Item2 && Board[i][3].Item2 && Board[i][4].Item2)
                                || (Board[0][i].Item2 && Board[1][i].Item2 && Board[2][i].Item2 && Board[3][i].Item2 && Board[4][i].Item2);
            }
            return result;
        }

        public int[] GetWinningNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                if(Board[i][0].Item2 && Board[i][1].Item2 && Board[i][2].Item2 && Board[i][3].Item2 && Board[i][4].Item2)
                {
                    return new int[] {Board[i][0].Item1, Board[i][1].Item1, Board[i][2].Item1, Board[i][3].Item1, Board[i][4].Item1};
                }
                if(Board[0][i].Item2 && Board[1][i].Item2 && Board[2][i].Item2 && Board[3][i].Item2 && Board[4][i].Item2)
                {
                    return new int[] { Board[0][i].Item1, Board[1][i].Item1, Board[2][i].Item1, Board[3][i].Item1, Board[4][i].Item1 };
                }
            }
            return null;
        }

        public List<int> GetUnmarkedNumbers()
        {
            List<int> unmarkednums = new();
            foreach (var arr in Board)
            {
                foreach (var num in arr)
                {
                    if (!num.Item2)
                        unmarkednums.Add(num.Item1);
                }
            }
            return unmarkednums;
        }
    }
}
