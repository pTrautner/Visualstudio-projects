using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE55_BasedShip;

namespace UE55_FishingBoat
{
    internal class FishingBoat : Ship
    {
        private int _passengers;
        static int allFishingBoats;
        public FishingBoat(string name, int crew, int passengers) : base(name, crew)
        {
            this._passengers = passengers;
            allFishingBoats++;
        }
        public static int GetAllFishingBoats()
        {
            return allFishingBoats;
        }
    }
}
