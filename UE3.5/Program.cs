using System;

namespace UE03_05
{
    internal class Program
    {
        const double Preiserhoehung = 1.1;
        const int Zeiterhoehung = 5;

        const double PljeskavicaPreis = 8.99;
        const double CevapiPreis = 6.99;
        const double SarmaPreis = 4.99;

        static void Main()
        {
            double total = 0;
            int longestPreparationTime = 0;

            Console.WriteLine("Willkommen zu unserem Restaurant! Hier ist unsere Speisekarte:");
            Console.WriteLine($"1. Pljeskavica - {PljeskavicaPreis} EUR\n2. Cevapi - {CevapiPreis} EUR\n3. Sarma - {SarmaPreis} EUR");

            string orderSummary = "";

            while (true)
            {
                Console.Write("\nBitte wählen Sie Ihr Gericht (1/2/3) oder 0, um die Bestellung abzuschließen: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                // Sonderfall
                if (choice == 0)
                {
                    break;
                }

                // Variablen für nächster Schritt definieren
                double dishPrice = 0;
                int preparationTime = 0;
                string dishName = "";

                switch (choice) // Effektiver als If-Else Loop, ein Case definieren, um weiterzufahren
                {
                    case 1:
                        dishName = "Pljeskavica";
                        dishPrice = PljeskavicaPreis;
                        preparationTime = 15;
                        break;
                    case 2:
                        dishName = "Cevapi";
                        dishPrice = CevapiPreis;
                        preparationTime = 10;
                        break;
                    case 3:
                        dishName = "Sarma";
                        dishPrice = SarmaPreis;
                        preparationTime = 20;
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        continue;
                }

                // Um Sonderwunsch bitten
                Console.Write("Haben Sie einen Sonderwunsch? (Geben Sie Ihren Wunsch ein oder drücken Sie Enter um fortzufahren): ");
                string sonderwunsch = Console.ReadLine();

                // Sonderfall oder gültige Eingabe
                if (!string.IsNullOrEmpty(sonderwunsch))
                {
                    orderSummary += $"{dishName} ({sonderwunsch})\n"; // In order Summary addieren, damit es später in Zusammenfassung gespeichert ist
                }
                else
                {
                    orderSummary += $"{dishName}\n";
                }

                // Neue Preis und Zeit 
                dishPrice *= Preiserhoehung;
                preparationTime += Zeiterhoehung;

                // Gesamtsumme und lägste Zubereitunszeit finden
                total += dishPrice;
                longestPreparationTime = Math.Max(longestPreparationTime, preparationTime);
            }

            // Bestellzusammenfassung
            Console.WriteLine("\nBestellzusammenfassung:");
            Console.WriteLine(orderSummary);
            Console.WriteLine($"Gesamtpreis: {total:0.00} EUR"); // total:0.00 ist ein Format, damit wir nicht mehr Nachkommastellen haben
            Console.WriteLine($"Längste Zubereitungszeit: {longestPreparationTime} Minuten");
        }
    }
}
