using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Canteen : Location
    {
        public Canteen(Clue clue, Treasure treasure) : base("Canteen", clue, treasure)
        {
        }

        public override string Describe()
        {
            return "You are in the Canteen. Students sit around eating their lunch";
        }

        public override string OnArrive()
        {
            return "You enter the canteen. The smell of cooked food makes you hungry.";
        }
    }
}
