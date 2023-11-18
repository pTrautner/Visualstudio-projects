using System.Globalization;

namespace UE5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Schiff[] schiffe = new Schiff[1];
            int count = 0;
            int auswahl;
            string weiter;

            while(true) 
            { 

                do
                {
                    Console.WriteLine("Welches Schiff möchte einfahren? [1] Segelyacht [2] Fischerboot [3] Generelles Schiff");
                } while (!(int.TryParse(Console.ReadLine(), out auswahl) && auswahl > 0 && auswahl < 4));

                Schiff neuesSchiff;     // neue Variable vom Typ "Schiff" definieren

                if (auswahl == 1)
                {
                    neuesSchiff = ErstelleSegelyacht();
                }
                else if (auswahl == 2)
                {
                    neuesSchiff = ErstelleFischerboot();
                }
                else
                {
                    neuesSchiff = ErstelleAllgemeinesSchiff();
                }
            
                if(count >= schiffe.Length)
                {
                    Array.Resize(ref schiffe, schiffe.Length * 2);      // Die Kapazität des Arrays wird verdoppelt
                }

                schiffe[count]= neuesSchiff;
                schiffe[count].GetSchiffInfo();
                count++;

                Console.WriteLine("Möchten Sie weitere Schiffe hinzufügen? (ja/nein): ");
                weiter = Console.ReadLine();
                    
                while (!(weiter == "ja" || weiter == "nein"))
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Eingabe ein: ");
                    weiter = Console.ReadLine();
                }

                if(weiter == "nein") { break; }

            }

            Zusammenfassung(schiffe);


            static Segelyacht ErstelleSegelyacht()
            {
                string? name;
                int crewCount;
                int passagiereCount;


                Console.WriteLine("Name der Segelyacht: ");
                name = Console.ReadLine();

                Console.WriteLine("Anzahl der Besatzung: ");
                while(!int.TryParse(Console.ReadLine(),out crewCount))
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Ganzzahl ein: ");
                }

                Console.WriteLine("Anzahl der Passagiere: ");
                while (!int.TryParse(Console.ReadLine(), out passagiereCount))
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Ganzzahl ein: ");
                }
                return new Segelyacht(name,crewCount, passagiereCount);
            }

            static Fischerboot ErstelleFischerboot()
            {
                string? name;
                int crewCount;
                int fischCount;


                Console.WriteLine("Name des Fischboots: ");
                name = Console.ReadLine();

                Console.WriteLine("Anzahl der Besatzung: ");
                while (!int.TryParse(Console.ReadLine(), out crewCount))
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Ganzzahl ein: ");
                }

                Console.WriteLine("Anzahl der Fischen: ");
                while (!int.TryParse(Console.ReadLine(), out fischCount))
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Ganzzahl ein: ");
                }
                return new Fischerboot(name, crewCount, fischCount);
            }

            static Schiff ErstelleAllgemeinesSchiff()
            {
                string? name;
                int crewCount;


                Console.WriteLine("Name des allgemeinen Schiffs ");
                name = Console.ReadLine();

                Console.WriteLine("Anzahl der Besatzung: ");
                while (!int.TryParse(Console.ReadLine(), out crewCount))
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Ganzzahl ein: ");
                }
                return new Schiff(name, crewCount);
            }

            static void Zusammenfassung(Schiff[] schiffe)
            {
                int gesamtSchiffe = Schiff.alleSchiffe();
                int segelyachten = Segelyacht.SegelyachtCount();
                int fischerboote = Fischerboot.FischerbootCount();

                Console.WriteLine("Zusammenfassung: ");
                Console.WriteLine($"Anzahl aller eingefahrenen Schiffe: {gesamtSchiffe}");
                Console.WriteLine($"Anzahl Segelyachten: {segelyachten}");
                Console.WriteLine($"Anzahl Fischerboote: {fischerboote}");
            }

        }
    }
}