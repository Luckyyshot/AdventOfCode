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
            int xDirection = (end.Item1 - start.Item1) == 0 ? 0 : (end.Item1 - start.Item1) / Math.Abs(end.Item1 - start.Item1);
            int yDirection = (end.Item2 - start.Item2) == 0 ? 0 : (end.Item2 - start.Item2) / Math.Abs(end.Item2 - start.Item2);

            for (int i = 0; i <= Math.Max(Math.Abs(end.Item1 - start.Item1), Math.Abs(end.Item2 - start.Item2)); i++)
            {
                if (linearOnly && !(xDirection == 0 || yDirection == 0))
                    break;
                grid[start.Item1 + i * xDirection][start.Item2 + i * yDirection]++;
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
