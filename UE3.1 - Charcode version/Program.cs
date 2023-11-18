//UE3.1 Paul Trautner

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
            int charcode;
            // Loop with DO: requests and read input until the input length is a single character
            // with the IF condition: informing the user that the input is incorrect when the input is too long
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
            // Characters have a numerical value because?
            // A: storage is made of bits, these bits represent a number > the number represents characters
            
            // input gets converted to character "ch"
            ch = Convert.ToChar(inputSymbol);
            // character ch gets converted to the integer "charcode" which is the numerical representation
            charcode = Convert.ToChar(ch);
            // My wrong? interpretation of the assignment: retriving the numerical value, which is not the numeric representation,
            // Numbers have their own numeric value equal to themselves, while letters have a numerical value of -1
            int num = (int)Char.GetNumericValue(ch); 
            Console.WriteLine($"Inputcharacter: {ch} Converted Numeric value: {num} Character code: {charcode}");

            //VERSION 1:
            //double doublenum = Convert.ToDouble(num); (old)

            double doublenum = Convert.ToDouble(charcode);

            double multiplied = doublenum * 1.3;
            Console.WriteLine("multiplied by 1,3 = " + multiplied);
            float fl1 = 2.56f;

            //Which datatype should the following "added" variable have so no explicit conversion is required and why?
            //A: Double because the float gets implicitly converted to a double.
            double added = multiplied + fl1;
            Console.WriteLine("added to 2,56 = " + added);

            //What do you observe when you convert the above "added"?
            //A: Converting double to integer returns an integer that ignores the decimals after the comma.
            int convertedtoint = (int)added;
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
