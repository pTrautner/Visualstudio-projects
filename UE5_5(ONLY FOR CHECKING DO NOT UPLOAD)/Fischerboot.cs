using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE5_5
{
    internal class Fischerboot:Schiff
    {
        private int fisch;
        private static int _fischerbootcount = 0;

        public Fischerboot(string name, int anzahlBesatzung, int fisch) : base(name, anzahlBesatzung)
        {
            this.fisch=fisch;
            _fischerbootcount++;
        }

        public static int FischerbootCount()
        {
            return _fischerbootcount;
        }

        public override void GetSchiffInfo()
        {
            //base.GetSchiffInfo();
            Console.WriteLine($"Anzahl an Segelyachten: {FischerbootCount()}");
        }
    }


}
