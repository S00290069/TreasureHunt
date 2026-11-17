using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Library : Location
    {
        public Library(Clue clue, Treasure treasure) : base("Library", clue, treasure)
        {
        }

        public override string Describe()
        {
            return "You are in the ATU Library. Rows and rows of bookshelves surround you.";
        }

        public override string OnArrive()
        {
            return "You enter the library. Remember to keep quiet!";
        }
    }
}
