using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE06_05_Datenverwaltung_für_Olympia
{
    class Land : IComparable<Land>
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }

        // Die CompareTo-Methode vergleicht das aktuelle Land-Objekt mit einem anderen Land-Objekt
        public int CompareTo(Land other)
        {
            // Wenn das andere Objekt null ist, wird es als größer betrachtet.
            if (other == null) return 1;

            // Gesamtanzahl der Medaillen für das aktuelle Land und das andere Land berechnen
            int totalMedalsThis = Gold + Silver + Bronze;
            int totalMedalsOther = other.Gold + other.Silver + other.Bronze;

            // Vergleich nach der Gesamtanzahl der Medaillen und dann nach dem Ländern
            if (totalMedalsThis != totalMedalsOther)
                return totalMedalsOther.CompareTo(totalMedalsThis);

            return Name.CompareTo(other.Name);
        }
    }
}
