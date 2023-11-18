// See https://aka.ms/new-console-template for more information
//int t = 1;
//char x = 'K';
//char y = 'C';
//UEBUNG 2.1
    Console.WriteLine("*Temperature conversion");
    Console.WriteLine("Please enter type C or K");
string tempType = Console.ReadLine();

    Console.WriteLine("Please enter temp");
Double tempValue = Convert.ToDouble(Console.ReadLine());

if (String.Equals(tempType,"C")) //vergleicht den eingegebenen string with den buchstaben C, if loop wird uebersprungen wenn kein C eingegeben ist
{
    //Convert and display ans 1
    tempValue = tempValue + 293;
    Console.WriteLine(tempValue);
}
if (String.Equals(tempType, "K"))// dasselbe mit K
{
    tempValue = tempValue - 293;
    Console.WriteLine(tempValue);
    //Convert and display ans 1
}
//Convert and display ans 2

//   Console.WriteLine(t);