using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Treasure
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        //For scoring
        public int Points { get; private set; }

        public Treasure(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
        }

        public override string ToString()
        {
            return $"{Name}: {Description} ({Points} points)";
        }
    }
}
