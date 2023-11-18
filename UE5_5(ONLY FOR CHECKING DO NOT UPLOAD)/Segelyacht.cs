using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE5_5
{
    internal class Segelyacht:Schiff
    {
        private int passagiere;
        private static int _segelyachtcount = 0;

        public Segelyacht(string name, int anzahlBesatzung, int passagiere) : base(name,anzahlBesatzung)
        {
            this.passagiere=passagiere;
            _segelyachtcount++;
        }

        public static int SegelyachtCount()
        {
            return _segelyachtcount;
        }

        public override void GetSchiffInfo()
        {
            //base.GetSchiffInfo();
            Console.WriteLine($"Anzahl an Segelyachten: {SegelyachtCount()}");
        }
    }
}
