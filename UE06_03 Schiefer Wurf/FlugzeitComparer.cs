using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE06_03_Schiefer_Wurf
{
    class FlugzeitComparer : IComparer<SchieferWurf> // Klasse FlugzeitComparer implementiert die IComparer<T>-Schnittstelle für den Typ SchieferWurf
                                                    // as ermöglicht das Festlegen einer benutzerdefinierten Logik zum Vergleichen von SchieferWurf-Objekten.
    {
        public int Compare(SchieferWurf x, SchieferWurf y)     // Die Methode Compare vergleicht zwei SchieferWurf-Objekte basierend auf ihrer Flugzeit.
        {                                                     // Sie ruft die Methode BerechneFlugzeit für jedes Objekt auf und vergleicht die Ergebnisse.
            return x.BerechneFlugzeit().CompareTo(y.BerechneFlugzeit());       // Das Ergebnis ist ein Wert, der den Vergleich darstellt:
        }                                                                     // - Wenn x.BerechneFlugzeit() < y.BerechneFlugzeit(), gibt es einen negativen Wert zurück.
    }                                                                        // - Wenn x.BerechneFlugzeit() == y.BerechneFlugzeit(), gibt es 0 zurück.
}                                                                           // - Wenn x.BerechneFlugzeit() > y.BerechneFlugzeit(), gibt es einen positiven Wert zurück.
