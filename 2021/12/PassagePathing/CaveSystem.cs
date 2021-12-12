using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassagePathing
{
    class CaveSystem
    {
        readonly Cave Start = new("start");

        readonly Cave End = new("end");

        readonly List<Cave> System = new();

        public CaveSystem(string[] input)
        {
            System.Add(Start);
            System.Add(End);

            foreach (var caveLink in input)
            {
                string[] link = caveLink.Split("-");

                if (!CaveExists(link[0]))
                    System.Add(new Cave(link[0]));
                if (!CaveExists(link[1]))
                    System.Add(new Cave(link[1]));


                Cave cave1 = new(""), cave2 = new("");
                foreach (var cave in System)
                {
                    if (cave.Name == link[0])
                        cave1 = cave;
                    if (cave.Name == link[1])
                        cave2 = cave;
                }
                cave1.AddNeighbor(cave2);
                cave2.AddNeighbor(cave1);
            }
        }

        public List<Path> FindAllPaths(bool part1)
        {
            List<Path> paths = new();
            List<Path> searchList = new();
            foreach (var cave in Start.Neighbors)
            {
                Path temp = new(Start);
                temp.AddCave(cave);
                paths.Add(temp);
                if (cave.Name != "end")
                    searchList.Add(temp);
            }

            while(searchList.Count != 0)
            {
                Console.WriteLine("Search list:" + searchList.Count);
                foreach (var path in new List<Path>(searchList))
                {
                    searchList.Remove(path);
                    paths.Remove(path);
                    foreach (var cave in path.GetLastEntry().Neighbors)
                    {
                        if (part1)
                        {
                            if (char.IsLower(cave.Name[0]) && path.CaveExists(cave))
                                continue;
                        }
                        else
                        {
                            if (cave.Name == "start")
                                continue;
                            if (char.IsLower(cave.Name[0]) && path.SmallCaveExistsMoreThanOnce() && cave.Name != "end" && path.CaveExists(cave))
                                continue;
                        }

                        Path temp = new(path);
                        temp.AddCave(cave);
                        paths.Add(temp);
                        if (cave.Name != "end")
                            searchList.Add(temp);
                    }
                }
            }
            return paths;
        }

        bool CaveExists(string name)
        {
            foreach (var cave in System)
            {
                if (cave.Name == name)
                    return true;
            }
            return false;
        }
    }
}
