using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Location
    {
        public string Name { get; private set; }
        public Clue Clue { get; private set; }
        public Treasure Treasure { get; private set; }

        public Location(string name, Clue clue, Treasure treasure)
        {
            Name = name;
            Clue = clue;
            Treasure = treasure;
        }
    }
}
