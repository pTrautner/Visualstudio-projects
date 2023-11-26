namespace Main;
using UE07_05_Bankkonto;
public class Program
{
    static void Main(string[] args)
    {
        //konto erstellen
        Bankkonto b1 = new Bankkonto("Paul", 123, 100.2M, 1234);
        while (true)
        {

            try
            {
                //fragen und kovertieren der kontonummer
                Console.WriteLine("Hello! Please enter kontonummer");
                int enteredKontoNumber = Convert.ToInt32(Console.ReadLine());
                //pin eingape
                Console.WriteLine("enter pin");
                int enteredpin = Convert.ToInt32(Console.ReadLine());
                //aufrufen der methode die die kombination ueberprueft
                bool userloggedin = b1.PinAndKontoCheck(enteredpin, enteredKontoNumber);
                //while schleife die nur lauft solange der bool true ist
                //bei falscher eingabe faeght die haupt- while true schleife an
                while (userloggedin == true)
                {
                    Console.WriteLine($"Hi {b1.Kontoinhaber}! Current Balance: {b1.Kontostand}");
                    Console.WriteLine("What would you like to do? Deposit [1] Withdraw [2] Logout [3] Exit App [4]");
                    //user optionen
                    int userchoice = Convert.ToInt32(Console.ReadLine());
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
                        default: Console.WriteLine("invalid selection!");
                            continue;
                    }
                }
            }
            //catch fuer format und generelles catch
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
