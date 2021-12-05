using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVenture
{
    class Grid
    {
        int[][] grid { get; set; }

        public Grid(int size)
        {
            grid = new int[size][];
            for (int i = 0; i < size; i++)
            {
                grid[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    grid[i][j] = 0;
                }
            }
        }

        public void addLinesegment((int, int) start, (int, int) end, bool linearOnly)
        {
            if(start.Item1 == end.Item1)
            {
                for (int i = 0; i <= Math.Abs(end.Item2 - start.Item2); i++)
                {
                    grid[start.Item1][Math.Min(end.Item2, start.Item2) + i]++;
                }
            }
            else if (start.Item2 == end.Item2)
            {
                for (int i = 0; i <= Math.Abs(end.Item1 - start.Item1); i++)
                {
                    grid[Math.Min(end.Item1, start.Item1) + i][start.Item2]++;
                }
            }
            else if (!linearOnly)
            {
                for (int i = 0; i <= Math.Abs(end.Item1 - start.Item1); i++)
                {
                    if(start.Item1 < end.Item1)
                    {
                        if(start.Item2 < end.Item2)
                            grid[start.Item1 + i][start.Item2 + i]++;
                        else
                            grid[start.Item1 + i][start.Item2 - i]++;
                    }
                    else
                    {
                        if (start.Item2 < end.Item2)
                            grid[start.Item1 - i][start.Item2 + i]++;
                        else
                            grid[start.Item1 - i][start.Item2 - i]++;
                    }
                }
            }
        }

        public int countOverlapingPoints()
        {
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[i][j] >= 2)
                        result++;
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = " ";
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[i][j] == 0)
                        result += ". ";
                    else
                        result += $"{grid[i][j]} ";
                }
                result += "\r\n ";
            }
            return result;
        }
    }
}
