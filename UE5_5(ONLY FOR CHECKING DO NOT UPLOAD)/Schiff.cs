using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UE5_5
{
    internal class Schiff
    {
        private string name;
        private int anzahlBesatzung;
        private static int _alleSchiffeCount = 0;

        public Schiff(string Name, int AnzahlBesatzung) 
        {
            this.name = Name;
            this.anzahlBesatzung= AnzahlBesatzung;
            _alleSchiffeCount++;
        }

        public Schiff(string Name) 
        {
            this.name = Name;
            _alleSchiffeCount++;    // Anzahl der Schiffe wird um 1 erhöht
        }


        public string GetName() { return name; }
        public int GetAnzahlBesatzung() { return anzahlBesatzung;}

        public void SetAnzahlBesatzung(int zahl)
        {
        this.anzahlBesatzung = zahl;        // Die Anzahl der Besatzungsmitglieder wird auf einen neuen Wert gesetzt
        }

        //Statische
        public static int alleSchiffe() 
        {
            return _alleSchiffeCount;
        }

        //Virtuelle
        public virtual void GetSchiffInfo()
        {
            Console.WriteLine($"Anzahl aller Schiffe: {alleSchiffe}");
        }
    }
}
