using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassagePathing
{
    class Path
    {
        private readonly List<Cave> path = new();

        public Path(Cave cave)
        {
            path.Add(cave);
        }

        public Path(Path clone)
        {
            path = new(clone.path);
        }

        public bool SmallCaveExistsMoreThanOnce()
        {
            foreach (var test in path)
            {
                if (char.IsUpper(test.Name[0]))
                    continue;

                int existCount = 0;
                foreach (var cave in path)
                    if (cave == test)
                        existCount++;
                if (existCount >= 2)
                    return true;
            }
            return false;
        }

        public bool CaveExists(Cave exist)
        {
            foreach (var cave in path)
                if (cave == exist)
                    return true;
            //Cave wasn't found
            return false;
        }

        public void AddCave(Cave cave)
        {
            if (path[^1].IsNeighbor(cave))
                path.Add(cave);
            else
                throw new Exception();
        }

        public Cave GetLastEntry()
        {
            return path[^1];
        }

        public override string ToString()
        {
            string result = "";
            foreach (var cave in path)
            {
                result += cave.Name + ",";
            }
            return result;
        }
    }
}
