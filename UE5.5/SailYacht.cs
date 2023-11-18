using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE55_BasedShip;

namespace UE55_SailYacht
{
    internal class SailYacht : Ship
    {
        private int _fishAmount;
        static int allSailYachts;
        public SailYacht(string name, int crew, int fishAmount) : base(name, crew)
        {
            this._fishAmount = fishAmount;
            allSailYachts++;
        }
        public static int GetAllSailYachts()
        {
            return allSailYachts;
        }
    }
}
