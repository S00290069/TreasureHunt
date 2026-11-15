using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Clue
    {
        public string Question { get; private set; }
        public string Hint { get; private set; }

        private string answer;

        public Clue(string question, string hint, string answer)
        {
            Question = question;
            Hint = hint;
            this.answer = answer;
        }

        public bool TryAnswer(string answer)
        {
            //ignores capitals and spaces at beginning/end
            if (answer.Trim().ToLower() == this.answer.Trim().ToLower())
            {
                return true;
            }
            return false;
        }
    }
}
