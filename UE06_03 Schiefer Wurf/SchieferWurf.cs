using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace UE06_03_Schiefer_Wurf
{
    internal class SchieferWurf
    {
        // Atribute
        private static int wurfNummerCounter = 1; // nur innerhalb der aktuellen Klasse zugänglich, wird von allen Instanzen der Klassen benutzt, behählt ihren Wert zwischen den Instanzen bei
        public int WurfNummer { get; private set; } // private set kann nur innerhalb dieser Klasse verwendet werden
        public double v0 { get; }
        public double fi { get; }
        public const double g = 9.81; // Konstanten können nicht verändert werden

        // Konstruktor; initialisiert die Instanzvariablen beim Erstellen eines neuen SchieferWurf-Objekts
        public SchieferWurf(double anfangsgeschwindigkeit, double abwurfwinkel)
        {
            WurfNummer = wurfNummerCounter++;
            v0 = anfangsgeschwindigkeit;
            fi = abwurfwinkel;
        }

        public double BerechneFlugzeit() // Formel für Flugzeit
        {
            double abwurfwinkelInRadians = fi * Math.PI / 180.0;
            return (2 * v0 * Math.Sin(abwurfwinkelInRadians)) / g;
        }

        public double BerechneWurfweite() // Formel für Wurfweite
        {
            double abwurfwinkelInRadians = fi * Math.PI / 180.0;
            return Math.Pow(v0, 2) * Math.Sin(2 * abwurfwinkelInRadians) / g;
        }
    }
}
