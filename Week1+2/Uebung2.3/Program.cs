// See https://aka.ms/new-console-template for more information
using System;

namespace Uebung_23;

    class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("the number of which to calculate the factorial");
        Int32 p = -1;//Convert.ToInt32(Console.ReadLine());

        bool incorrectF = true;
        //intp = -1;
        while (incorrectF)
        {
            //Console.WriteLine("Enter time interval in seconds");
            p = Convert.ToInt32(Console.ReadLine());
            if (p % 1 == 0 & p > 0) //if statement check ob der modulo der eingabe durch 1 eine 0 ergibt, und positiv ist
            {
                Console.WriteLine("Your answer is  " + p );
                incorrectF = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
                incorrectF = true;
            }
        }
        int x = 0; //deklarieren von integer x fuer die FOR loop
        //int y = 0;
       

            x = p;
            for (int i = x - 1; i >= 1; i--)
            //For Loop wo der anfang i = x -1 ausgefuert wird als erstes statement
            //zweiter statement: i ist gleich oder groesser als 1: das heisst wenn der factorial beim letzten schrit 1 ist, die loop stoppt
            //der dritte statement sagt das i jedes mal 1 kleiner wird sodas die variable x jeder mal mit einer nummer niedriger multipliziert wird
            {
                x = x * i; //x wird jedes mal mit der iteration multipliziert die jede loop 1 kleiner wird
            }
            Console.WriteLine(x); //display der variable x nach der letzten loop
        //IGNORE BELOW ////////////////////////////////////////////////////////////////////////////
            //Console.WriteLine("Input your own calculated factorial");
            //Int32 k = Convert.ToInt32(Console.ReadLine());
            //y = k;
            //Console.WriteLine("if the next line does not say *correct* please try again");
      
    }







}



