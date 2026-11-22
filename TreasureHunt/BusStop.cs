using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class BusStop : Location
    {
        public BusStop() : base("Bus Stop", null, null)
        {
        }

        public override string Describe()
        {
            return "You are at the ATU Bus Stop. The last bus is waiting to leave";
        }

        public override string OnArrive()
        {
            return "YOu arrive at the bus stop just in time!";
        }
    }
}
