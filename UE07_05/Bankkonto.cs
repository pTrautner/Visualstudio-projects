namespace UE07_05_Bankkonto;

internal class Bankkonto
{
    //constructor
    public Bankkonto(string kontoinhaber, int kontonummer, decimal kontostand, int pin)
    {
        this.Kontoinhaber = kontoinhaber;
        this.Kontonummer = kontonummer;
        this.Kontostand = kontostand;
        this.Pin = pin;
    }
    //getters und setters
    public string Kontoinhaber { get; set; }
    public int Kontonummer { get; set; }
    public decimal Kontostand { get; set; }
    int Pin { get; set; }
    //Methode um login zu checken, returns bool
    public bool PinAndKontoCheck(int enteredPin, int enteredkontonummer)
    {
        while (true)
        {
            bool pinAndKontonummerMatches;
            
            if (enteredPin == Pin && enteredkontonummer == Kontonummer)
            {
                pinAndKontonummerMatches = true;
                Console.WriteLine("Succesful Login!");
            }
            else
            {
                pinAndKontonummerMatches = false;
                Console.WriteLine("Wrong Combination!");
            }
            return pinAndKontonummerMatches;
        }

    }
    //methode um einzahlungen durch zu fuehren ,checkt fuer punkt bei komma stellen
    public void Deposit()
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"enter deposit amount");
                string depositamountstring = Console.ReadLine();
                if ( depositamountstring.Contains('.') )
                {
                    Console.WriteLine("Your input contained dots [.] Please use comma to divide digits after the decimal!");
                    continue;
                }
                decimal depositamount = Convert.ToDecimal(depositamountstring);
                Kontostand += depositamount;
                Console.WriteLine($"you have deposited {depositamount} euros");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Error, Please only input decimal numbers!");
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

    }
    //methode zum abheben, vergleicht eingabe auch mit kontostand
    public void Withdraw()
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"enter withdraw amount");
                string withdrawamountstring = Console.ReadLine();
                if (withdrawamountstring.Contains('.'))
                {
                    Console.WriteLine("Your input contained dots [.] Please use comma to divide digits after the decimal!");
                    continue;
                }
                decimal withdrawamount = Convert.ToDecimal(withdrawamountstring);
                if (withdrawamount > Kontostand)
                {
                    Console.WriteLine("Insufficient Credit!");
                    break;
                }
                if (withdrawamount == 0)
                {
                    Console.WriteLine("You cannot withdraw an amount of 0 euros");
                }
                if(withdrawamount <= Kontostand)
                {
                    Kontostand -= withdrawamount;
                    Console.WriteLine($"you have withdrawn {withdrawamount} euros");
                    break;
                }
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Error, Please only input decimal numbers!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}

