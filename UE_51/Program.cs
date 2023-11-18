
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace UE_51_MAIN;

class Program
{
    static void Main(string[] args)     //Main program
    {

        Console.WriteLine("To exit at any time press [e]");
       while (true) 
            {
            try   //try/catch fuer input errors
            {
                Console.Write("Please enter sequential number of the Frappucino Sequence you would like to calculate: "); //Input parse und exit option
                string sequentialNumberstring = Console.ReadLine();
                if (sequentialNumberstring == "e") 
                { 
                    Environment.Exit(0); 
                }
                if (sequentialNumberstring != "0")
                {
                    int sequentialNumber = Int32.Parse(sequentialNumberstring);
                    //convert string to int fuer Fibby method
                    Console.WriteLine("Your Number: " + Convert.ToString(Fibonacci(sequentialNumber)));
                    //Fibonacci() method call
                    continue;
                }


            }
            catch (Exception ex) 
            //catch mit writeline der error message
            {
                Console.WriteLine(ex.Message); 
                continue;
            }
       }
    }
    public static int Fibonacci(int sequentialNumber) //static Fibonacci array mit seq. num. input
    {
        //sequentialNumber = Fibonacci(sequentialNumber - 1) + (Fibonacci(sequentialNumber - 2));

        if (sequentialNumber == 1)
        {
            return 1;
        }
        //base case Fib(1): gibt erste nummer der sequence = 1
        if (sequentialNumber == 2)
        {
            return 1;
        }
        //base case FIb(2): gibt 2. nummer = 1, Nummer 3 und groesser werder hieraus erzeugt

        else
        {
        return Fibonacci(sequentialNumber -1 ) + Fibonacci(sequentialNumber -2);
        }
        //FIbonacci formel in code form

    }
}
