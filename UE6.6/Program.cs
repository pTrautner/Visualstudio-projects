using UE66_ship;
namespace UE66_Main;

class Program
{
    static public void Main(string[] args)
    {
        Ship s1 = new Ship("skipper1", 2005, 12);
        Ship s2 = new Ship("flipper2", 1999, 17);
        Ship s3 = new Ship("shipper3", 2000, 15);
        Ship s4 = new Ship("tripper4", 2001, 17);
        Ship s5 = new Ship("clipper5", 2002, 15);
        List<Ship> shiplist = new List<Ship>() { s1, s2, s3, s4, s5 };
        DeleteShip("shipper3", shiplist);


    }
    static void DeleteShip(string shipname, List<Ship> shiplist)
    {
        int indexofdeletion = 0;
        foreach (Ship ship in shiplist) { Console.WriteLine(ship._name); }
        foreach (Ship s in shiplist)
        {
            if (s._name == "shipper3")
            {
                break;
            }
            indexofdeletion++;
        }
        shiplist.RemoveAt(indexofdeletion);
        Console.WriteLine("new list:");
        foreach (Ship ship in shiplist) { Console.WriteLine(ship._name); }
    }
}
