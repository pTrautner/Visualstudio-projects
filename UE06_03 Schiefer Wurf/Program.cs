using System.ComponentModel;

namespace UE06_03_Schiefer_Wurf
{
    internal class Program
    {
        static void Main()
        {
            // Arrays erstellen
            SchieferWurf W1 = new SchieferWurf(20, 30);
            SchieferWurf W2 = new SchieferWurf(28, 45);
            SchieferWurf W3 = new SchieferWurf(30, 80);
            SchieferWurf W4 = new SchieferWurf(25, 25);
            SchieferWurf W5 = new SchieferWurf(45, 88);

            SchieferWurf[] projekt = { W1, W2, W3, W4, W5 };

            // Konvertiere das Array in eine Liste (da Sort Methode nicht mit Array funktioniert) für dynamische Größenanpassung und zusätzliche Methoden (add, remove, clear)
            List<SchieferWurf> projektListe = new List<SchieferWurf>(projekt);

            // Verwende List, um die Sort-Methode zu nutzen und die Liste nach Wurfweite zu sortieren
            projektListe.Sort(new WurfweiteComparer());
            Ausgabe("Sortierung nach Wurfweite", projektListe);

            // nach Flugzeit sortieren
            projektListe.Sort(new FlugzeitComparer());
            Ausgabe("Sortierung nach Flugzeit", projektListe);
        }

        // Methode Ausgabe
        static void Ausgabe(string titel, List<SchieferWurf> projekt) // Akzeptiert einen Titel und eine Liste von SchieferWurf-Objekten als Parameter
        {// z.B. von oben Ausgabe("Sortierung nach Wurfweite", projektListe)
            Console.WriteLine($"{titel}:");
            foreach (var wurf in projekt)
            {
                Console.WriteLine($"Wurf Nr. {wurf.WurfNummer} | Flugzeit: {wurf.BerechneFlugzeit()} | Wurfweite: {wurf.BerechneWurfweite()}");
            }                           // schreibt den Wurfnummer ...    ruft die 
            Console.WriteLine();
        }
    }
}