using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Player
    {
        private List<Treasure> treasures = new List<Treasure>();

        public string Name { get; private set; }
        public Location CurrentLocation { get; set; }

        public int TreasureCount
        {
            get
            {
                return treasures.Count;
            }
        }

        public Player(string name)
        {
            Name = name;
        }

        public void AddTreasure(Treasure treasure)
        {
            treasures.Add(treasure);
        }

        public void ShowTreasures()
        {
            Console.WriteLine($"{Name}'s Treasures ({treasures.Count})");

            foreach (Treasure treasure in treasures)
            {
                Console.WriteLine($"    {treasure}");
            }
        }
    }
}
