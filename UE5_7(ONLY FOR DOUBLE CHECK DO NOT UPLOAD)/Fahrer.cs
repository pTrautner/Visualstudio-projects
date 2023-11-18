using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE5_7
{
    internal class Fahrer
    {
        private string name;
        private int ort;
        private int treibsotffstand;
        private bool karte;

        private int ergebnis;
        private int minuten = 5;
 

        public Fahrer(string name, int ort, int treibsotffstand,bool karte)
        {
            this.name = name;
            this.ort = ort;
            this.treibsotffstand = treibsotffstand;
            this.karte = karte;
        }
        public string GetName() { return name; }
        public int GetOrt() { return ort; }
        public int GetTreibstoff() { return treibsotffstand; }
        public bool GetKarte() {  return karte; }

        public static int FindNearestDriver(int location, Fahrer[] taxis) //Berechnung einer Laufvariable des nähersten Fahrers
        {
            int yada = Math.Abs(taxis[0].GetOrt() - location);  // Yada repräsentiert den absoluten Unterschied zwischen dem Standort des ersten Taxis im Array und dem Zielstandort (location).
            int laufvariable = 0;

            for (int i = 0; i < taxis.Length; i++)
            {
                if (yada > Math.Abs(taxis[i].GetOrt() - location))
                {
                    yada = Math.Abs(taxis[i].GetOrt() - location);
                    laufvariable = i;
                }
            }
            return laufvariable;
        }
        public bool TankRechner(int location, int ziel) //Tankberechnung der ganzen Fahrt + Fahrt zur Abholung ("geht es sich aus für den Fahrer?")
        {
            bool tank=false;
            int ergebnis2;
            int fuel = 3;
            ergebnis = Math.Abs(location - GetOrt()) * fuel;
            ergebnis = treibsotffstand - ergebnis;
            ergebnis2 = Math.Abs(location - ziel) * fuel;
            ergebnis = ergebnis - ergebnis2;

            if (ergebnis < 0) { Console.WriteLine("Driver does not have enough fuel"); }
            if (ergebnis > 0) { Console.WriteLine("Driver has enough fuel"); tank = true; }

            return tank;
        }
        public void AbholRechner(int abhol)
        {
            int ergebnis;
            ergebnis = Math.Abs(abhol - GetOrt());
            ergebnis = ergebnis * minuten+3;

            Console.WriteLine($"The estimated time for the taxi driver to reach your pickup-destionation is: {ergebnis} minutes");

            for (int i = 0; i < ergebnis; i++)
            {
                Console.Write(".");
                Thread.Sleep(700);
            }
            Console.WriteLine();
            //return String.Format($"The estimated time for the taxi driver to reach your pickup-destionation is: {ergebnis} minutes");
        }
        public void ZumZielRechner(int location, int ziel)
        {
            int ergebnisMINUTEN;
            ergebnisMINUTEN = Math.Abs(location - ziel); //Abstand ausgerechnet
            ergebnisMINUTEN *= minuten + 3;

            Console.WriteLine($"Fuel capacity after we reach the destination: {ergebnis}%");
            Console.WriteLine($"The estimated time to reach your destionation is: {ergebnisMINUTEN} minutes");

            for (int i = 0; i < ergebnisMINUTEN; i++)
            {
                Console.Write(".");
                Thread.Sleep(700);
            }
            Console.WriteLine();
        }

        public void Zahlung(int location, int ziel)
        {
            double preis = 7.45;
            preis *= Math.Abs(location - ziel);
            Console.WriteLine($"That will be {preis} Euros, please.");
            if (GetKarte() == true) { Console.WriteLine("You have the option to pay with card."); }
        }

        public override string ToString()
        {
            return String.Format(
                $"Your nearest driver is: {GetName()}\n" +
                $"Taxi driver is at district {GetOrt()}\n" +
                $"Current fuel capacity for the chosen vehicle {GetTreibstoff()}%"
                );
        }
    }
}
