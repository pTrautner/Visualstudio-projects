using System.Globalization;

static class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter date format: ");
                string dataFormat = Console.ReadLine();
                Console.WriteLine("Enter date: ");
                string dateInput = Console.ReadLine();
                DateTime dateTime = DateTime.ParseExact(dateInput, dataFormat, null);
                Console.WriteLine($"{dateTime.Year} - {dateTime.Month} - {dateTime.Day}");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Error encountered while entering format or time");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}//16_03~1998