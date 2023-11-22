namespace UE7_1;

class Program
{
    static void Main()
    {
        int[] zahlenarray = new int[] { 9, 2, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        while (true)
        {
            try
            {
                Console.Write($"enter index in array (ranging from 0 to {zahlenarray.Length}):    ");
                int userchoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"your number: {zahlenarray[userchoice]}");
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("wrong input: (INDEX OUT OF RANGE)");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("wrong input: (WRONG FORMAT)");
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("wrong input: (VALUE TOO LARGE OR TOO SMALL FOR AN 32 BIT INTEGER)");
            }
        }
        
    }
}