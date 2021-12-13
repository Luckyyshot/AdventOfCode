using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparentOrigami
{
    class Paper
    {
        readonly char[,] paper;

        public Paper(string[] input, int x, int y)
        {
            paper = new char[x+1, y+1];
            for (int i = 0; i <= x; i++)
                for (int j = 0; j <= y; j++)
                    paper[i, j] = '.';

            foreach (var coord in input)
            {
                string[] temp = coord.Split(",");
                paper[int.Parse(temp[0]), int.Parse(temp[1])] = '#';
            }
        }

        public Paper(char[,] input)
        {
            paper = input;
        }

        public int CountDots()
        {
            int result = 0;
            for (int i = 0; i < paper.GetLength(0); i++)
                for (int j = 0; j < paper.GetLength(1); j++)
                    if (paper[i, j] == '#')
                        result++;
            return result;
        }

        public char[,] Fold(bool x)
        {
            char[,] result;
            if (x)
            {
                result = new char[(paper.GetLength(0) - 1) / 2, paper.GetLength(1)];

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = paper[i, j];
                        if (paper[paper.GetLength(0) - i - 1, j] == '#')
                            result[i, j] = '#';
                    }
                }
            }
            else
            {
                result = new char[paper.GetLength(0), (paper.GetLength(1) - 1) / 2];

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = paper[i, j];
                        if (paper[i, paper.GetLength(1) - j - 1] == '#')
                            result[i, j] = '#';
                    }
                }
            }

            return result;
        }


        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < paper.GetLength(1); i++)
            {
                for (int j = 0; j < paper.GetLength(0); j++)
                {
                    result += paper[j, i];
                }
                result += "\r\n";
            }
            return result;
        }
    }
}
