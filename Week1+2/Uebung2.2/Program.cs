// See https://aka.ms/new-console-template for more information

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
      
            Console.WriteLine("Amount of loops?"); //console fragt nach input loops
            int iterationAmount = Convert.ToInt32(Console.ReadLine());
            //user input wird in einen integer convertiert und die variable wierd hieran gleichzeitig gleichgestellt und deklariert
            Console.WriteLine("For Loop");
            for (int i = 0; i < iterationAmount; i++) //FOR schleiffe mit statements:  initial execution; end condition(i nicht mer kleiner); wiederholende operation
            {
                Console.WriteLine(i); //die wiederholte iteration schreibt den aktuallen iteration namen
            }
            Console.WriteLine("While Loop");
            int j = 0; //deklarieren vom neuen integer 
            while (j < iterationAmount) //WHILE loop mit end kondition in klammern
            {
                Console.WriteLine(j);
                j++; //wiederholende operation
            }
            Console.WriteLine("Do While Loop");
            int k = 0;
            do
            {
                Console.WriteLine(k); 
                k++;
            }
            while (k < iterationAmount);//gleich wie while loop allerding fuehrt die schleife einmal durch auch wenn dass statement inkorrekt ist
        }
    }
}
//DIe for loop scheint am saubersten wegen minimalen code lines
// der integer wird deklariert, die anzahl loops wird bestimmt und die exekution bei jedem durchgang wird bestimmt in einer zeile.