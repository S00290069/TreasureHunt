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

        //Add up the total points for the collected treasures
        public int Score
        {
            get
            {
                int score = 0;

                foreach (Treasure treasure in treasures)
                {
                    score += treasure.Points;
                }
                return score;
            }
        }

        public Player(string name)
        {
            Name = name;
        }

        public void AddTreasure(Treasure treasure, bool hintUsed)
        {
            treasures.Add(treasure);

            if (hintUsed)
            {
                treasure.UseHintPenalty();
            }
        }

        public bool HasTreasure(Treasure treasure)
        {
            return treasures.Contains(treasure);
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
