using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeBasin
{
    class Heightmap
    {
        //TODO: Refactor using two dimentional arrays that is two bigger on each side to avoid out index exception.
        readonly List<List<Pair<int, bool>>> heightmap;
        readonly List<List<Tuple<int, int>>> basins = new();

        public Heightmap(string[] input)
        {
            List<List<Pair<int, bool>>> temp = new();
            for (int i = 0; i < input.Length; i++)
            {
                temp.Add(new List<Pair<int, bool>>());
                for (int j = 0; j < input[i].Length; j++)
                {
                    temp[i].Add(new Pair<int, bool>(int.Parse(input[i][j].ToString()), false));
                }
            }

            heightmap = temp;

            SetLowPoints();
            CalcRiskPart1();

            foreach (var basin in GetLowPoints())
            {
                basins.Add(new Tuple<int, int>[] { basin }.ToList() );
            }

            basins = ExpandBasins(basins);

            CalcBasinsSizeScorePart2();
        }

        void CalcBasinsSizeScorePart2()
        {
            int[] basinCount = (from basin in basins where true select basin.Count).OrderByDescending(x => x).ToArray();

            Console.WriteLine("Total score part2: " + basinCount[0] * basinCount[1] * basinCount[2]);
        }

        List<List<Tuple<int, int>>> ExpandBasins(List<List<Tuple<int, int>>> basins)
        {
            List<List<Tuple<int, int>>> result = new(basins);
            foreach (var basin in new List<List<Tuple<int, int>>>(basins))
            {
                if (basin.Count != 1)
                    throw new Exception();
                result[result.IndexOf(basin)] = ExpandBasin(basin[0]).Distinct().ToList();
            }

            return result;
        }

        List<Tuple<int, int>> ExpandBasin(Tuple<int, int> basin)
        {
            List<Tuple<int, int>> finishedBasin = new();
            finishedBasin.Add(basin);
            List<Tuple<int, int>> searchList = new(new Tuple<int, int>[] { basin }.ToList());
            while (AnyAdjacentsExpandable(searchList))
            {
                var tempList = new List<Tuple<int, int>>(searchList);
                searchList = new List<Tuple<int, int>>();
                foreach (var searchItem in tempList)
                {
                    var adjacents = FindAdjacent(searchItem.Item1, searchItem.Item2);
                    foreach (var adjacent in adjacents)
                    {
                        if (heightmap[searchItem.Item1][searchItem.Item2].Item1 < heightmap[adjacent.Item1][adjacent.Item2].Item1 && heightmap[adjacent.Item1][adjacent.Item2].Item1 != 9)
                        {
                            searchList.Add(new Tuple<int, int>(adjacent.Item1, adjacent.Item2));
                            finishedBasin.Add(new Tuple<int, int>(adjacent.Item1, adjacent.Item2));
                        }
                    }
                }
            }
            return finishedBasin;
        }

        bool AnyAdjacentsExpandable(List<Tuple<int, int>> points)
        {
            bool result = false;
            foreach (var point in points)
            {
                result = result || AdjacentsExpandable(point);
            }
            return result;
        }

        bool AdjacentsExpandable(Tuple<int, int> point)
        {
            var adjacents = FindAdjacent(point.Item1, point.Item2);
            bool expandable = false;
            foreach (var adjacent in adjacents)
            {
                if (heightmap[point.Item1][point.Item2].Item1 < heightmap[adjacent.Item1][adjacent.Item2].Item1 && heightmap[adjacent.Item1][adjacent.Item2].Item1 != 9)
                    expandable = true;
            }
            return expandable;
        }

        List<Tuple<int, int>> GetLowPoints()
        {
            List<Tuple<int, int>> lowPoints = new();
            for (int i = 0; i < heightmap.Count; i++)
            {
                for (int j = 0; j < heightmap[i].Count; j++)
                {
                    if (heightmap[i][j].Item2)
                        lowPoints.Add(new Tuple<int, int>(i, j));
                }
            }
            return lowPoints;
        }

        void CalcRiskPart1()
        {
            int totalRisk = 0;
            for (int i = 0; i < heightmap.Count; i++)
            {
                for (int j = 0; j < heightmap[i].Count; j++)
                {
                    if (heightmap[i][j].Item2)
                        totalRisk += heightmap[i][j].Item1 + 1;
                }
            }
            Console.WriteLine("Total risk: " + totalRisk);
        }

        void SetLowPoints()
        {
            for (int i = 0; i < heightmap.Count; i++)
            {
                for (int j = 0; j < heightmap[i].Count; j++)
                {
                    Tuple<int, int>[] adjacents = FindAdjacent(i, j);
                    bool smallerThanAll = true;
                    foreach (var adjacent in adjacents)
                        smallerThanAll = smallerThanAll && heightmap[i][j].Item1 < heightmap[adjacent.Item1][adjacent.Item2].Item1;
                    heightmap[i][j].Item2 = smallerThanAll;
                }
            }
        }

        Tuple<int, int>[] FindAdjacent(int x, int y)
        {
            if (x > 0 && x < heightmap.Count - 1)
            {
                if (y > 0 && y < heightmap[x].Count - 1)
                    return new Tuple<int, int>[] { new Tuple<int, int>(x - 1, y), new Tuple<int, int>(x + 1, y), new Tuple<int, int>(x, y - 1), new Tuple<int, int>(x, y + 1) };
                else if (y == 0)
                    return new Tuple<int, int>[] { new Tuple<int, int>(x - 1, y), new Tuple<int, int>(x + 1, y), new Tuple<int, int>(x, y + 1) };
                else //y == heightmap[x].Count - 1
                    return new Tuple<int, int>[] { new Tuple<int, int>(x - 1, y), new Tuple<int, int>(x + 1, y), new Tuple<int, int>(x, y - 1) };
            }
            else if (x == 0)
            {
                if (y > 0 && y < heightmap[x].Count - 1)
                    return new Tuple<int, int>[] { new Tuple<int, int>(x + 1, y), new Tuple<int, int>(x, y - 1), new Tuple<int, int>(x, y + 1) };
                else if (y == 0)
                    return new Tuple<int, int>[] { new Tuple<int, int>(x + 1, y), new Tuple<int, int>(x, y + 1) };
                else //y == heightmap[x].Count - 1
                    return new Tuple<int, int>[] { new Tuple<int, int>(x + 1, y), new Tuple<int, int>(x, y - 1) };
            }
            else //x == heightmap.Count - 1
            {
                if (y > 0 && y < heightmap[x].Count - 1)
                    return new Tuple<int, int>[] { new Tuple<int, int>(x - 1, y), new Tuple<int, int>(x, y - 1), new Tuple<int, int>(x, y + 1) };
                else if (y == 0)
                    return new Tuple<int, int>[] { new Tuple<int, int>(x - 1, y), new Tuple<int, int>(x, y + 1) };
                else //y == heightmap[x].Count - 1
                    return new Tuple<int, int>[] { new Tuple<int, int>(x - 1, y), new Tuple<int, int>(x, y - 1) };
            }
        }
    }
}
