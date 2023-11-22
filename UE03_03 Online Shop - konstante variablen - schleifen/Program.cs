//UEBUNG 3.3 Paul Trautner
namespace MyApplication
{
    class Program
    {
        //declared static values for product prices and their respective codes
        static decimal ApplePrice = 0.35M;
        static int AppleN = 1;
        static decimal PearPrice = 0.50M;
        static int PearN = 2;
        static decimal SnusPrice = 5.85M;
        static int SnusN = 3;

        static void Main(string[] args)
        {
            //bool representing if user is finished
            bool userisdone = false;
            // string representing users input to choose product
            string answer;
            // assigns values to total price per product, and combined total
            decimal appletotal = 0;
            decimal peartotal = 0;
            decimal snustotal = 0;
            decimal combinedtotal = 0;
            Console.WriteLine($"Welcome to the online shop! ");
            Console.WriteLine($"Product list:");
            Console.WriteLine($"Apples. Price: {ApplePrice} EUR per unit");
            Console.WriteLine($"Pears.  Price: {PearPrice} EUR per unit");
            Console.WriteLine($"Snus.   Price: {SnusPrice} EUR per can");
            // WHILE condition: loop repeats while user is not done
            while (userisdone == false)
            {
                //three if statements for each user input
                Console.WriteLine($"Please select a product by entering its number [1-3]");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine($"How many apples?");
                    string appleamount = Console.ReadLine();
                    // read input string
                    decimal appledec = Convert.ToDecimal(appleamount);
                    // convert string to decimal
                    appletotal = appletotal + ApplePrice * appledec;
                    // update total product price with added product price multiplied by entered amount
                    Console.WriteLine($"Total cost for apples: {appletotal} EUR");
                }
                if (answer == "2")
                {
                    Console.WriteLine($"How many pears?");
                    string pearamount = Console.ReadLine();
                    decimal peardec = Convert.ToDecimal(pearamount);
                    peartotal = peartotal + PearPrice * peardec;
                    Console.WriteLine($"Total cost for pears: {peartotal} EUR");
                }
                if (answer == "3")
                {
                    Console.WriteLine($"How many snus cans?");
                    string snusamount = Console.ReadLine();
                    decimal snusdec = Convert.ToDecimal(snusamount);
                    snustotal = snustotal + SnusPrice * snusdec;
                    Console.WriteLine($"Total cost for snus: {snustotal} EUR");
                }

                //check if user is done shopping, y input results in calculation+display of combined total, any other input restarts loop
                Console.WriteLine($"Are you done shopping? press [y] and [enter] for yes. Enter any other key to continue shopping");
                answer = Console.ReadLine();
                if (answer == "y") 
                {
                    userisdone = true;
                    combinedtotal = appletotal + peartotal + snustotal;

                }

            }
            Console.WriteLine($"Price overview: Apples: {appletotal} , Pears: {peartotal} ,Snus: {snustotal} ,");
            Console.WriteLine($"total amount: {combinedtotal} ");
            Console.WriteLine($"thanks for shopping.");
        }
    }
}