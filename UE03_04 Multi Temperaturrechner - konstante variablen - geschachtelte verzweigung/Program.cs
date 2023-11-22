using System;

namespace UE03_04
{
    internal class Program
    {
        // Allg. Konstante definieren, gelten für alle Programme, auch außerhalb der static void Main()
        const char Celsius = 'C';
        const char Fahrenheit = 'F';
        const char Kelvin = 'K';

        const double AbsoluteZeroCelsius = -273.15;
        const double AbsoluteZeroFahrenheit = -459.67;
        const double AbsoluteZeroKelvin = 0.00;

        static void Main(string[] args)
        {
            while (true) // Damit sich das Programm wiederholen kann
            {
                double temp;
                char skala;

                // Um Input bitten
                Console.WriteLine("Willkommen zum Temperaturkonverter! \n Wählen Sie eine Temperaturskala aus:\n 1. Celsius\n 2. Fahrenheit\n 3. Kelvin");
                Console.Write("Ihre Auswahl (1/2/3): ");
                int auswahl = Convert.ToInt32(Console.ReadLine());

                Console.Write("Geben Sie die Temperatur in der ausgewählten Einheit ein: ");
                temp = Convert.ToDouble(Console.ReadLine());

                switch (auswahl) // Einfacher als If-Else Loop, vergleichet eingegebenen "auswahl" mit passendem case
                {
                    case 1:
                        skala = Celsius;
                        break;
                    case 2:
                        skala = Fahrenheit;
                        break;
                    case 3:
                        skala = Kelvin;
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl! Bitte versuchen Sie es erneut.");
                        continue; // Use 'continue' to start the loop again in case of invalid selection.
                }

                // Überprüfen, ob es großer als Absolute Zero Temp ist (für Methode sieh unter):
                if (temp < GetAbsoluteZero(skala))
                {
                    Console.WriteLine("Das ist zu kalt! Bitte geben Sie eine gültige Temperatur ein.");
                    continue; // Startet das Programm wieder, falls was falsche Temperatur eingegeben ist
                }

                double celsius, fahrenheit, kelvin;

                // Konverter erstellen
                switch (auswahl)
                {
                    case 1:
                        celsius = temp;
                        fahrenheit = temp * 9 / 5 + 32;
                        kelvin = temp + 273.15;
                        break;
                    case 2:
                        fahrenheit = temp;
                        celsius = (temp - 32) * 5 / 9;
                        kelvin = (temp - 32) * 5 / 9 + 273.15;
                        break;
                    case 3:
                        kelvin = temp;
                        celsius = temp - 273.15;
                        fahrenheit = (temp - 273.15) * 9 / 5 + 32;
                        break;
                    default:
                        continue; // Startet das Loop wieder in dem Fall einem falschen Eintrags
                }

                Console.WriteLine($"Die Temperatur in den anderen Einheiten:\n Celsius: {celsius}\n Fahrenheit: {fahrenheit}\n Kelvin: {kelvin}");

                // Fragen, ob das Programm neu startet werden soll
                Console.Write("Möchten Sie das Programm erneut ausführen? (Ja/Nein): ");
                string wiederholen = Console.ReadLine();

                if (wiederholen != "Ja")
                {
                    break;
                }
            }
        }

        // Methode für Überprüfung, ob die Temperatur zu niedrig ist
        static double GetAbsoluteZero(char scale)
        {
            switch (scale)
            {
                case Celsius:
                    return AbsoluteZeroCelsius;
                case Fahrenheit:
                    return AbsoluteZeroFahrenheit;
                case Kelvin:
                    return AbsoluteZeroKelvin;
                default:
                    throw new ArgumentException("Ungültige Skala");
            }
        }
    }
}
