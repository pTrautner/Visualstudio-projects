using System.Reflection.PortableExecutable;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Repeat ?? for restarting program
            Repeat:
            //Declared integers, string and character to validate user input
            int desiredlength = 1;
            int inputlength = 0;
            string inputSymbol;
            char ch;
            // Loop with DO ........
            do
            {
                Console.WriteLine("Please write a single character");
                inputSymbol = Console.ReadLine();
                inputlength = inputSymbol.Length;

                if (inputlength != desiredlength)
                {
                    Console.WriteLine("Incorrect input!");
                }
            } while (inputlength != desiredlength);
            ch = Convert.ToChar(inputSymbol);

            // Characters have a numerical value because??
            int num = (int)Char.GetNumericValue(ch);
            Console.WriteLine($"Inputcharacter: {ch} Converted Numeric value: {num} ");

            double doublenum = Convert.ToDouble(num);
            double multiplied = doublenum * 1.3;
            Console.WriteLine("multiplied by 1,3 = " + multiplied);
            float fl1 = 2.56f;

            //Which datatype should the following "added" variable have so no explicit conversion is required and why?
            double added = multiplied + fl1;
            Console.WriteLine("added to 2,56 = " + added);

            //
            int convertedtoint = (int)added;

            //Converting to integer returns an integer that ignores the decimals after the comma.**
            Console.WriteLine("Returned value after converting to integer: " + convertedtoint);

            //Check if the user wants to restart the program
            Console.WriteLine("Press [y] and press [Enter] to restart");

            //if (Console.ReadKey().Key = ConsoleKey.Y) { } ;
            string response = Console.ReadLine();
            if (response == "y") 
            { 
                goto Repeat ; 
            }
          
                    

        }
    }

}
