namespace Main;
using UE07_05_Bankkonto;
public class Program
{
    static void Main(string[] args)
    {
        Bankkonto b1 = new Bankkonto("Paul", 123, 100.2M, 1234);
        while (true)
        {

            try
            {
                Console.WriteLine("Hello! Please enter kontonummer");
                int enteredKontoNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter pin");
                int enteredpin = Convert.ToInt32(Console.ReadLine());
                bool userloggedin;
                userloggedin = b1.PinAndKontoCheck(enteredpin, enteredKontoNumber);
                while (userloggedin == true)
                {
                    Console.WriteLine($"Hi {b1.Kontoinhaber}! Current Balance: {b1.Kontostand}");
                    Console.WriteLine("What would you like to do? Deposit [1] Withdraw [2] Logout [3] Exit App [4]");
                    int userchoice = Convert.ToInt32(Console.ReadLine());
                    if (userchoice < 1 || userchoice > 4)
                    {
                        Console.WriteLine("invalid selection!");
                    }
                    switch (userchoice)
                    {
                        case 1:
                            b1.Deposit();
                            continue;
                        case 2:
                            b1.Withdraw();
                            continue;
                        case 3:
                            userloggedin = false;
                            break;
                        case 4:
                            Environment.Exit(0);
                            return;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Error, Please only input numbers!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
