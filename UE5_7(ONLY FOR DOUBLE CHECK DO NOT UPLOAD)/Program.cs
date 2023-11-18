using System;

namespace UE5_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int location;
            int ziel;
            int zwergebnis = 100;

            Console.WriteLine("Welcome to the Taxi-ServiceHello");

            Console.WriteLine("1. Welcome District");
            Console.WriteLine("2. Living District");
            Console.WriteLine("3. Working District");
            Console.WriteLine("4. Outer Town");
            Console.WriteLine("5. Even Outer Town");
            Console.WriteLine("6. Even Further Outer Town ");
            Console.WriteLine("7. Outside Town");


            Fahrer[] taxis = new Fahrer[3];
            taxis[0] = new Fahrer("TAXI1", 1, 99,false);
            taxis[1] = new Fahrer("TAXI2", 2, 76,true);
            taxis[2] = new Fahrer("TAXI3", 4, 88,false);


            do
            {
                Console.WriteLine("Please enter the districts number, you are currently in: ");
            } while (!(int.TryParse(Console.ReadLine(), out location) && location > 0 && location < 8));

            do
            {
                Console.WriteLine("Which district do you want to go to: ");
            } while (!(int.TryParse(Console.ReadLine(), out ziel) && ziel > 0 && ziel < 8));

            int laufvariable = Fahrer.FindNearestDriver(location,taxis); //Berechnung einer Laufvariable, die den nähersten Fahrer anzeigt

            Console.WriteLine(taxis[laufvariable].ToString()); //Anzeige des Fahrers
            bool tank;

            tank = taxis[laufvariable].TankRechner(location, ziel);

            if (tank == true)
            {
                taxis[laufvariable].AbholRechner(location);

                Console.WriteLine("The taxi has reached its destination.");
                string? antwort;
                do
                {
                    Console.WriteLine("Do you want to get in? (y/n)");
                    antwort = Console.ReadLine();
                } while (!(antwort == "y") && !(antwort == "n"));

                if (antwort == "y") { taxis[laufvariable].ZumZielRechner(location, ziel); taxis[laufvariable].Zahlung(location, ziel); }
                else if (antwort == "n") { Console.WriteLine("Fahrer fährt weg"); }
            }

            else if (tank == false)
            {
                Console.WriteLine("Fahrer hat nicht genug Kraftstoff. Versuche später noch einmal.");
            }
            


        }
    }
}