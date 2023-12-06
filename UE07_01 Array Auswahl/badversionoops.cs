using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//BAD VERSION

/*namespace UE07_01;
class Program
{
    static void notMain(string[] args)
    {
        int[] zahlenarray = new int[] { 3, 2, 7, 4, 5, 6, 7, 8, 9, 5, 11, 12 };
        string? userinput;
        int userchoice, result;
        while (true)
        {
            Console.Write($"enter index in array (ranging from 0 to {zahlenarray.Length}):    ");
            bool succes = Int32.TryParse(userinput = Console.ReadLine(), out result);
            if (succes == true)
            {
                userchoice = Convert.ToInt32(userinput);
                    if (userchoice < 0 || userchoice > zahlenarray.Length)
                    {
                        Console.WriteLine("wrong input: (INDEX OUT OF RANGE)");
                    }
                    else
                        Console.WriteLine($"your number: {zahlenarray[userchoice]}");
            }
            else if (succes == false)
            {
                Console.WriteLine("wrong input: (NOT AN INTEGER)");
            }
        }
    }
}*/
