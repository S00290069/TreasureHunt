using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal abstract class Location
    {
        public string Name { get; private set; }
        public Clue Clue { get; private set; }
        public Treasure Treasure { get; private set; }

        private Dictionary<string, Location> exits = new Dictionary<string, Location>();

        public Location(string name, Clue clue, Treasure treasure)
        {
            Name = name;
            Clue = clue;
            Treasure = treasure;
        }

        public abstract string Describe();

        public virtual string OnArrive()
        {
            return $"You have arrived at {Name}.";
        }

        public void AddExit(string direction, Location location)
        {
            exits.Add(direction.ToLower(), location);
        }

        //Find the location in a chosen direction
        public Location FindExit(string direction)
        {
            Location location;

            if (exits.TryGetValue(direction.ToLower(), out location))
            {
                return location;
            }
            return null;
        }

        public void ShowExits()
        {
            Console.Write("Exits - ");

            string[] directions = { "north", "south", "east", "west" };

            foreach (string direction in directions)
            {
                Location location = FindExit(direction);

                if (location != null)
                {
                    Console.Write($"{direction}: {location.Name}    ");
                }
            }
            Console.WriteLine();
        }
    }
}
