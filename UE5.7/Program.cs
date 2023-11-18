namespace UE55;
using UE55_Taxi;

internal class Program
{
    static void Main(string[] args)
    {
        Taxi t1 = new("pani ",  4, 100, false, 0, true);
        Taxi t2 = new("andi ",  1, 100, true,  0, true);
        Taxi t3 = new("eric ",  2, 100, true, 0, true);
        Taxi t4 = new("phold", 20,   1, false, 0, true);
        Taxi[] taxiarray = { t1, t2, t3, t4};
        int userselection = 0;
        decimal currentdistrict;
        decimal destinationdistrict;
        decimal mindistance = 0;
        decimal maxdistancoTolocation;
        const decimal fuelperdistance = 2M;
        //variables
        Console.WriteLine($"WELCOME \n1) \n2) \n3) \n4) \n5) \n6) \n7) ");
        try
        {
            Console.Write("Enter current district:  ");
            currentdistrict = ReadNumberInput();
            Console.Write("Enter destination district:  ");
            destinationdistrict = ReadNumberInput();
            //find nearest driver: foreach driver calculate distance, nearestdriver is minimum distance
            //calculate distance after driving
            maxdistancoTolocation = Math.Abs(destinationdistrict - currentdistrict);
            
            foreach (Taxi t in taxiarray)
            {
                t.Setdistancetocustomer(Math.Abs(currentdistrict - t.GetCurrentLocation()));
            }
            foreach (Taxi t in taxiarray)
                //set driver to unavailable if fuel is not enough
            {
                if (t.GetFuel() < fuelperdistance * maxdistancoTolocation)
                {
                    t.SetEnoughFuel(false);
                    Console.WriteLine(t.GetName() + t.GetEnoughFuel());
                }
                else { break; }
            }
            //select closest available driver
            foreach (Taxi t in taxiarray)
            {
                if (t.GetAcceptsCard() == false)
                { continue;}
                if (t.GetEnoughFuel() == false)
                { continue; }
                if (mindistance >= t.GetDistanceToCustomer())
                {
                    mindistance = t.GetDistanceToCustomer();
                }
                else
                t4 = t;
                break;
            }
            Console.WriteLine($"your drivers name: {t4.GetName()}");
            Console.WriteLine($"your driver is currently at: {t4.GetCurrentLocation()}");
            Console.WriteLine($"your drivers fuel amount: {t4.GetFuel()} %");


            //check nearest driver fuel: check (distance driver to customer + distance driver to destination)

            //display nearest driver details

            //calculate drive time:
            //HINWEIS Timetodrive = 3+5*districtsCrossed
            //use array for districts or compare district numbers such as district1 = 1 so district 7 to 1 = 6 distance

            //static method display: consolewrite 1 dot per minute
            //static void Timer()

            //
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Invalid input");
            return;
        }




        static decimal ReadNumberInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) return -1;

                try
                {
                    
                    return Convert.ToDecimal(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input! Please try again.");
                }
            }
        }
    }
}