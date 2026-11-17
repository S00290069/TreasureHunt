using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class StudentUnion : Location
    {
        public StudentUnion(Clue clue, Treasure treasure) : base("Student Union", clue, treasure)
        {
        }

        public override string Describe()
        {
            return "You are in the Student Union. A pool table sits in the corner of the room";
        }

        public override string OnArrive()
        {
            return "You enter the student union. You hear pool balls clattering together.";
        }
    }
}
