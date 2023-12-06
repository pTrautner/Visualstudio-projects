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
                Console.WriteLine($"enter index in array (ranging from 0 to {zahlenarray.Length}):    ");
                //This part is where errors may happen
                int userchoice = Convert.ToInt32(Console.ReadLine());
                //Error 1: Index ist ausserhalb dem Array
                //Error 2: Falsches format/nicht zu konvertieren in einen integer
                //Error 3: Input ist zu Gross fuer einen 32 bit Integer
                Console.WriteLine($"your number: {zahlenarray[userchoice]}");
            }
            //Drei spezifische error messages
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("wrong input: (INDEX OUT OF RANGE) please enter value within range of the array");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("wrong input: (WRONG FORMAT) please enter integers");
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("wrong input: (VALUE TOO LARGE OR TOO SMALL FOR AN 32 BIT INTEGER)");
            }
            //Extra genereller catch um unverhergesehene errors abzufangen
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
    }
}