using System.Collections;

namespace UE_62main;

class Program
{
    static void Main(string[] args)
    {
        var arlist1 = new ArrayList() //Creating the arraylist with names, ages
        {
            "Paul", 25, "Andreja", 21, "Helena", 23, "Andi", 27, "Markus", 22
        };
        List<string> names = new List<string>(); //creating an empty list for names
        List<int> ages = new List<int>(); //same for ages (not neccesary here)
        foreach (var item in arlist1)
        {
            //Console.WriteLine(item);
            Type tp = item.GetType(); //Get type of every item in arlist1, as Type tp
            if (tp == typeof(string) && item != null) //Compare Type tp to Type string
            {
                names.Add(item.ToString()); //if it is a string, gets added to names list
            }
            if (tp == typeof(int))
            {
                int iteminteger;
                iteminteger = Convert.ToInt32(item);
                ages.Add(iteminteger);
            }
        }
        Console.WriteLine("Names:"); 
        foreach (var item in names) //writes list of names
        {
            Console.WriteLine(item);
        }
        names.Sort(); //sorts list of names (alphabetically by default)
        Console.WriteLine("Sorted Names:"); 
        foreach (var item in names) //writes list of sorted names
        {
            Console.WriteLine(item);
        }
        /*Q1) Wie unterscheiden sich Arrays, Arraylisten und Listen?
        Laenge:
        Arrays haben eine fixierte Laenge, waerend Arraylisten und Listen dynamisch sind: Sie wachsen oder Schrumpfen wenn items zugefuegt/herausgenommen werden.
        Datentyp:
        Arrays und lists koennen nur einen datatypen haben waerend Arraylists verschiedene datatypen koennen haben.
        Dimensionen:
        Arrays koennen multidimensional, Arraylists/Lists sind ein-dimensional.
        
        Q2) Was glauben Sie, ist fehleranfälliger bezüglich der Syntax bzw. Lesbarkeit des Codes?
        Arraylisten speichern objekte nur als referenzen. dadurch kann zb ein string in einerarrayliste compiled werden und dann zu fehler fueren wenn das objekt als integer aufgerufen wird.
        Dadurch sind listen/arrays auch vorteiliger fuer lesbarkeit des syntax weil es sofort deutlich ist um welche datentypen es sich handelt

        Q3) Können Arraylisten sortiert werden? Falls ja, unter welchen Bedingungen?
        Ja, allerdings hat arraylist keine integrierte sortier funktion.
        Man braucht statdessen die methoden: .Sort() oder /Sort.IComparer() oder Sort.IComparer(int32, int32, Icomparer impl.)

        */
    }
}