// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace Uebung_25
{
    class Program
    {
        static void Main(string[] args)
        {
            bool incorrects = true; //Boolean fuer invalide eingabe, die eingabe wird vorlaufig als inkorrekt betrachtet
            Double s0 = 0; // Hier Declare ich die anfangs distanz als floating point nummer (pos/neg mit decimalen)
            while (incorrects) // eine while loop die aktiv ist solange die eingabe inkorrekt ist
            {
                Console.WriteLine("Enter positive Starting distance [m]"); //frage nach input
                s0 = Convert.ToDouble(Console.ReadLine()); //konvertierung der eingabe in float
                if (s0 >= 0) //if statement check ob die nummer positiv ist
                {
                    Console.WriteLine("Starting distance is " + s0 + " meters"); // bestatigung der eingefuerten nummer
                    incorrects = false; // der boolean ist jetzt false und die loop stoppt
                }
                else
                {
                    Console.WriteLine("Invalid input"); //else statement falls die nummer negativ ist
                    incorrects = true; // boolean ist true, deswegen wiederholt die schleife sich und der user wird erneut gefragt
                }
            }
            bool incorrectv = true;
            Double v0 = 0;
            while (incorrectv)
            {
                Console.WriteLine("Enter positive starting velocity [m/s]");
                v0 = Convert.ToDouble(Console.ReadLine());
                if (v0 >= 0)
                {
                    Console.WriteLine("Starting velocity is " + v0 + " meters");
                    incorrectv = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    incorrectv = true;
                }
            }
            bool incorrecta = true;
            Double a0 = 0;
            while (incorrecta)
            {
                Console.WriteLine("Enter constant accel [m/s^2]");
                a0 = Convert.ToDouble(Console.ReadLine());
                if (a0 >= 0)
                {
                    Console.WriteLine("Starting velocity is " + a0 + " meters");
                    incorrecta = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    incorrecta = true;
                }
            }
            bool incorrectt = true;
            Double t = 0;
            while (incorrectt)
            {
                Console.WriteLine("Enter time interval in seconds");
                t = Convert.ToDouble(Console.ReadLine());
                if (t%1==0 & t > 0 ) //if statement check ob der modulo der eingabe durch 1 eine 0 ergibt, und positiv ist
                {
                    Console.WriteLine("Timestep = " + t + " seconds");
                    incorrectt = false;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    incorrectt = true;
                }
            }
            Double dist = s0 + v0 * t + (a0 * t * t) / 2; //deklarieren von avstand variabel und berechnung vom abgelegten abstand
            Console.WriteLine(dist); //display output
            Double v1 = v0 + a0 * t; //deklarieren der end-geschwindichkeit
            Double vAvg = (v0 + v1) / 2; //deklarieren und berechnung der durchschnittsgeschwindichkeit
            Console.WriteLine(vAvg); //display 
            Double v = v0; //
            Double s = s0; //
            Double t0 = t; //deklarieren von neuen input variablen fuer die inputs um in der for schleife zu verwenden
            t = 0; //zeit variable fuer die schleife
            for (int i = 0; i < (t0 + 1) ; i++ , t++)
                //For - schleife wo i anfangt null ist, mit der condition dass i kleiner als die eingegebene zeit ist
                //jede iteration erfolgt i plus 1 und ein + 1 zeitschritt
            {

                s = s0 + v0 * t + ( ( a0 * t * t ) / 2 ); //formel fuer abgelegten abstand basiert auf anfangskonditionen und jetzigen zeitschritt 
                v = v0 + a0 * t; //formel fuer geschwindichkeit

                Console.WriteLine("Current time " + t + " s   | Current Position " + s + " m   | Current Velocity " + v + " m/s   | ");
                //abbildung der outputs
              
            }

        }

    }
}
