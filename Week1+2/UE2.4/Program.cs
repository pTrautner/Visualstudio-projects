// See https://aka.ms/new-console-template for more information
namespace Uebung_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter var 1"); // auffordering startwert eingeben
            Int32 x = Convert.ToInt32(Console.ReadLine()); //declariert variable als integer und gleicht diese variable and konvertierte eingabe
            Console.WriteLine("Enter var 2");
            Int32 y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter repetition amount");
            Int32 z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your FIbby sequence:");
            Console.WriteLine(x);
            Console.WriteLine(y);
            int t = 0; //deklarieren variable fuer die kombination der letzenzwei zahlen in der schleiffe
            for (int i = 2; i < z; i++)
                //for- schleiffe mit i = 2 als anfangs exekution weil wir 2 iterationen uberschpringen da die ersten 2 ziffern bekannt sind
                //zweites statement sagt das die schleiffe stoppt wenn die eingefuehrte anzahl iterationen grosser ist als die der ausgefuhrten iterationen
                //und das dritte statement ist i++ das jede iteration 1 groesser wird
            {
                t = x + y;//rechnet die letzten zwei variablen zusammen
                Console.WriteLine(t); //ausgabe fuer die zusammengerechnete zahl
                x = y; //gleicht die letzte zahl and was die vohrletzte zahl wahr
                y = t; //gleicht die jetzige output zahl and die letzte zahl
            }
        }

    }
}
