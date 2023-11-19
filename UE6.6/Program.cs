using UE6._6;
using UE66_ship;
namespace UE66_Main;

class Program
{
    static public void Main(string[] args)
    {
        //creating 5 ships.
        Ship s1 = new Ship("skipper1", 2005, 12);
        Ship s2 = new Ship("flipper2", 1999, 20);
        Ship s3 = new Ship("shipper3", 2000, 15);
        Ship s4 = new Ship("tripper4", 2001, 19);
        Ship s5 = new Ship("clipper5", 2002, 10);

        //creating list with ship objects.
        List<Ship> shiplist = new List<Ship>() { s1, s2, s3, s4, s5 };

        //deleting one ship using the method below.
        DeleteShip("skipper1", shiplist);

        //using ToString method for each ship which returns string of attributes.
        foreach (Ship ship in shiplist)
        { Console.WriteLine(ship.ToString()); }

        //using CompareTO method in class ship, followed by another ToString.
        shiplist.Sort();
        Console.WriteLine("sorted list by length:");
        foreach (Ship ship in shiplist)
        { Console.WriteLine(ship.ToString()); }

        //using Icomparer in class Shipcomparer, followed by another ToString.
        shiplist.Sort(new ShipComparer());
        Console.WriteLine("sorted list by age:");
        foreach (Ship ship in shiplist)
        { Console.WriteLine(ship.ToString()); }
    }
    //This method takes a name to be deleted and a list to delete it from:
    //Every object in the list is checked for its Name. when the if condition is met the ship is removed and the method returns void.
    static void DeleteShip(string shipname, List<Ship> shiplist)
    {
        foreach (Ship ship in shiplist)
        {
            if (ship.Name == shipname)
            {
                shiplist.Remove(ship);
                return;
            }
        }
    }

}
/* 
Output:
Name: flipper2, Year built: 1999, Length: 20
Name: shipper3, Year built: 2000, Length: 15
Name: tripper4, Year built: 2001, Length: 19
Name: clipper5, Year built: 2002, Length: 10
sorted list by length:
Name: clipper5, Year built: 2002, Length: 10
Name: shipper3, Year built: 2000, Length: 15
Name: tripper4, Year built: 2001, Length: 19
Name: flipper2, Year built: 1999, Length: 20
sorted list by age:
Name: flipper2, Year built: 1999, Length: 20
Name: shipper3, Year built: 2000, Length: 15
Name: tripper4, Year built: 2001, Length: 19
Name: clipper5, Year built: 2002, Length: 10
*/

