namespace UE07_05_Bankkonto;

internal class Bankkonto
{
    public Bankkonto(string kontoinhaber, int kontonummer, decimal kontostand, int pin)
    {
        this.Kontoinhaber = kontoinhaber;
        this.Kontonummer = kontonummer;
        this.Kontostand = kontostand;
        this.Pin = pin;
    }
    public string Kontoinhaber { get; set; }
    public int Kontonummer { get; set; }
    public decimal Kontostand { get; set; }
    int Pin { get; set; }
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
    public void Deposit()
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"enter deposit amount");
                decimal depositamount = Convert.ToDecimal(Console.ReadLine());
                Kontostand += depositamount;
                Console.WriteLine($"you have deposited {depositamount} euros");
                break;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

    }
    public void Withdraw()
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"enter withdraw amount");
                decimal withdrawamount = Convert.ToDecimal(Console.ReadLine());
                if(withdrawamount > Kontostand)
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

