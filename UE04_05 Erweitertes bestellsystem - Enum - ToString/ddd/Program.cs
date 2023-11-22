using Gericht_UE45;
using Bestellung_UE45;
using System.Runtime.Intrinsics.X86;

namespace Main_Program_UE45;

internal class Main_Program
{
    static void RestaurantMain(string[] args)
    {

        Gericht g1 = new("Pljeskavica", 10.30M, 10);
        Gericht g2 = new("Cevapi", 4.50M, 15);
        Gericht g3 = new("Sarma", 5.50M, 20);
        Bestellung b1 = new Bestellung(0,0);

        string gN1 = g1.GetName(); decimal gP1 = g1.GetPreis();
        string gN2 = g2.GetName(); decimal gP2 = g2.GetPreis();
        string gN3 = g3.GetName(); decimal gP3 = g3.GetPreis();


        Console.WriteLine("Willkommen zu unserem Restaurant! Hier ist unsere Speisekarte:");
        Console.WriteLine($" Gericht 1: {gN1} Preis: {gP1}");
        Console.WriteLine($" Gericht 1: {gN2} Preis: {gP2}");
        Console.WriteLine($" Gericht 1: {gN3} Preis: {gP3}");

        string orderSummary;
        int bestellungAmount = 1;
        int extrazeit = 30;

        Console.WriteLine("Please select bestell art Restaurant: press [1] Takeaway: press [2] Lieferung: press [3)");
        int tool = Int32.Parse(Console.ReadLine());
        while (tool != 0)
        {
            
            switch(tool)
            {
                case 1:
                    b1.SetBestellArt(Bestellung.Bestellart.Restaurant);
                    break;
                case 2:
                    b1.SetBestellArt(Bestellung.Bestellart.Takeaway);
                    break;
                case 3:
                    b1.SetBestellArt(Bestellung.Bestellart.Lieferung);
                    break;
                default:
                    continue;

            }
            tool = 0;
        }

    Return:

        Console.WriteLine("Select an option and press [Enter] 1 for G1, 2 G2, 3 G3 and 4 to exit ");
        try
        {
            int userSelection = 0;
            userSelection = Int32.Parse(Console.ReadLine());
            while (userSelection != 4)
            {
                
                switch (userSelection)
                {
                    case 1:
                        Console.WriteLine("You have chosen G1" + gN1);
                        Gericht g1copy;
                        g1copy = g1.MakeCopy();
                        b1.AddBestellungToArray(g1copy, bestellungAmount);
                        bestellungAmount++;
                        Console.WriteLine("want a Sonderwunsch? Please type your sonderwunsch or press [Enter] to continue");
                        string sonderwunschName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(sonderwunschName))
                        {
                            g1copy.SonderWunsch(sonderwunschName);
                        }
                        break;
                    case 2:
                        Console.WriteLine("You have chosen: "+ gN2);
                        Gericht g2copy;
                        g2copy = g2.MakeCopy();
                        b1.AddBestellungToArray(g2copy, bestellungAmount);
                        bestellungAmount++;
                        Console.WriteLine("want a Sonderwunsch? Please type your sonderwunsch or press [Enter] to continue");
                        string sonderwunschName2 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(sonderwunschName2))
                        {
                            g2copy.SonderWunsch(sonderwunschName2);
                        }
                        break;
                    case 3:
                        Console.WriteLine("You have chosen: " + gN3);
                        Gericht g3copy;
                        g3copy = g3.MakeCopy();
                        b1.AddBestellungToArray(g3copy, bestellungAmount);
                        bestellungAmount++;
                        Console.WriteLine("want a Sonderwunsch? Please type your sonderwunsch or press [Enter] to continue");
                        string sonderwunschName3 = Console.ReadLine();
                        if (!string.IsNullOrEmpty(sonderwunschName3))
                        {
                            g3copy.SonderWunsch(sonderwunschName3);
                        }
                        
                        break;
                       
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
                Console.WriteLine("OVERVIEW:");
                b1.ShowGerichte();
                decimal m = b1.MaxPreis();
                Console.WriteLine($"Maxpreis: {m.ToString()}");
                int mzeit = b1.MaxZeit();
                Bestellung.Bestellart extratimeart = b1.GetBestellArt();
                if (extratimeart == Bestellung.Bestellart.Lieferung)
                {
                    mzeit = + extrazeit;
                }
                Console.WriteLine($" ZEIT: {mzeit.ToString()}");    
                goto Return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid input");
            goto Return;
        }
    }
}
