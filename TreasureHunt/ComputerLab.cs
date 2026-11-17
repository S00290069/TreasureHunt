using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class ComputerLab : Location
    {
        public ComputerLab(Clue clue, Treasure treasure) : base("Computer Lab", clue, treasure)
        {
        }

        public override string Describe()
        {
            return "You are in the Computer Lab. Desks filled with computers line the room.";
        }

        public override string OnArrive()
        {
            return "You enter the computer lab. The sound of typing fills the room";
        }
    }
}
