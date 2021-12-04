using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class BingoBoard
    {
        public bool Empty = false;

        public (int, bool)[][] board { get; set; }

        public bool winner = false;

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
            this.board = result;
        }

        public void markNumber(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i][j].Item1 == num)
                        board[i][j].Item2 = true;
                }
            }
        }

        public bool validateWinner()
        {
            bool result = false;
            for (int i = 0; i < 5; i++)
            {
                result = result || (board[i][0].Item2 && board[i][1].Item2 && board[i][2].Item2 && board[i][3].Item2 && board[i][4].Item2)
                                || (board[0][i].Item2 && board[1][i].Item2 && board[2][i].Item2 && board[3][i].Item2 && board[4][i].Item2);
            }
            return result;
        }

        public int[] getWinningNumbers()
        {
            List<int> winningnums = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                if(board[i][0].Item2 && board[i][1].Item2 && board[i][2].Item2 && board[i][3].Item2 && board[i][4].Item2)
                {
                    return new int[] {board[i][0].Item1, board[i][1].Item1, board[i][2].Item1, board[i][3].Item1, board[i][4].Item1};
                }
                if(board[0][i].Item2 && board[1][i].Item2 && board[2][i].Item2 && board[3][i].Item2 && board[4][i].Item2)
                {
                    return new int[] { board[0][i].Item1, board[1][i].Item1, board[2][i].Item1, board[3][i].Item1, board[4][i].Item1 };
                }
            }
            return null;
        }

        public List<int> getMarkedNumbers()
        {
            List<int> markednums = new List<int>();
            foreach (var arr in board)
            {
                foreach (var num in arr)
                {
                    if (num.Item2)
                        markednums.Add(num.Item1);
                }
            }
            return markednums;
        }

        public List<int> getUnmarkedNumbers()
        {
            List<int> unmarkednums = new List<int>();
            foreach (var arr in board)
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
