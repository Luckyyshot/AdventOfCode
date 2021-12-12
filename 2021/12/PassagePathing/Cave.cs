using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassagePathing
{
    class Cave
    {
        public string Name { get; private set; }

        public List<Cave> Neighbors { get; private set; }

        public Cave(string name)
        {
            this.Name = name;
            Neighbors = new();
        }

        public void AddNeighbor(Cave cave)
        {
            Neighbors.Add(cave);
        }

        public bool IsNeighbor(Cave cave)
        {
            foreach (var neighbor in Neighbors)
            {
                if (cave == neighbor)
                    return true;
            }
            //Didn't find a neighbor
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Cave cave && Name == cave.Name;
        }
    }
}
