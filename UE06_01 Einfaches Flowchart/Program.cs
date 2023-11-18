using System.ComponentModel.Design;
using System.Numerics;

namespace UE06_01_Einfaches_Flowchart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen definieren
            double a;
            double b;

            // 1.er Teil
            do // Check, ob a ein Integer ist (nicht unbedingt notwendig)
            {
                Console.WriteLine("Bitte geben Sie einen Integer a ein:");

            } while (!double.TryParse(Console.ReadLine(), out a));

            switch (a) // Loop für 1.er Teil
            {
                case 1:
                    a += 1;
                    break;
                case 2:
                    a %= 2;
                    break;
                case 3:
                    a /= 2;
                    break;
                case 5: // Hab nur mit dem Loop gelungen
                    int exponent = 32;
                    BigInteger result = 1;

                    for (int i = 0; i < exponent; i++)
                    {
                        result *= (int)a;
                    }

                    a = (double)result;
                    break;
                default:
                    Console.Write("Nicht definiert\n");
                    break;
            }

            Console.WriteLine($"Gutes Wahl, neue Wert von Int a: {a}");

            // 2.er Teil
            do // Check, ob b ein Integer ist (nicht unbedingt notwendig)
            {
                Console.WriteLine("Bitte geben Sie einen Integer b ein:");

            } while (!double.TryParse(Console.ReadLine(), out b));

            if (a % 2 == 0) // Erster Fall
            {
                Console.Write("a ist gerade\n");
                //Console.WriteLine($"Das wäre alles, Int b: {b}");
            }

            else // Zweiter Fall
            {
                Console.Write("a ist ungerade\n");
                if (a < b) // Extra Loop innerhalb
                {
                    Console.Write("Das bedeutet: a < b\n");
                }

                else
                {
                    Console.Write("Logisch richtige Ausgabe\n");
                }
            }
            Console.WriteLine($"Das wäre alles, Int b: {b}");
        }
    }
}