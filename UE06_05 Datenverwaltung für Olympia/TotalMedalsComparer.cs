using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE06_05_Datenverwaltung_für_Olympia
{
    class TotalMedalsComparer : IComparer<Land>
    {
        public int Compare(Land x, Land y)
        {
            // Wenn eines der beiden Objekte null ist, wird 0 zurückgegeben -> sie werden als gleich betrachtet werden.
            if (x == null || y == null) return 0;

            // Gesamtanzahl der Medaillen für jedes Land berechnen
            int totalMedalsX = x.Gold + x.Silver + x.Bronze;
            int totalMedalsY = y.Gold + y.Silver + y.Bronze;

            // Vergleich nach der Gesamtanzahl der Medaillen und dann nach dem Ländernamen.
            if (totalMedalsX != totalMedalsY)
                return totalMedalsY.CompareTo(totalMedalsX);

            return x.Name.CompareTo(y.Name);
        }
    }
}
