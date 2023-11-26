using System.Globalization;

static class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                //Abfragen der inputs: diese werden also strings gespeichert, also sollten keine fehlermeldung geben
                Console.WriteLine("Enter date format: (such as yyyy;dd;MM");
                string dataFormat = Console.ReadLine();
                Console.WriteLine("Enter date: ");
                string dateInput = Console.ReadLine();
                //Program versucht die inputs zu parsen, falls moeglich wird der dateTime string danach auf der Konsole ausgegeben
                DateTime dateTime = DateTime.ParseExact(dateInput, dataFormat, null);
                //Console.WriteLine($"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}");
                string dateISOformat = dateTime.ToString("yyyy-MM-dd");
                Console.WriteLine(dateISOformat);
            }
            //catch mit fehlermeldung fuer formatexceptions
            catch (System.FormatException)
            {
                Console.WriteLine("Error encountered while entering format or time:");
            }
            //Generelle exception fuer ausfaelle
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}//16_03~1998