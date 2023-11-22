using UE4_4_Book;
using UE4_4_Library; //Dependencies, Main programm greift zu auf Book und Libr.

namespace UE4_4_Main
{
    internal class Main_Program
    {
        static void Main(string[] args) 
        {
            //kreieren von buechern
            Book b1 = new ("Dune", 13, false);
            Book b2 = new ("uneD", 34 );
            Book b3 = new ("Doon", 94 );
            Book b4 = new ("Nood", 22);
            //arrays mit buechers (collection2 ist nicht noetig, demonstriert nur)
            Book[] collection1 = { b1 , b2 , b3 , b4 };
            Book[] collection2 = { b1 , b3 };

            //nochmal, unnoetige library lib 2 
            Library lib1 = new Library(collection1);
            Library lib2 = new Library(collection2);

            Return:
            //books getter
                Console.WriteLine("Current inventory of books:");
                lib1.ShowBooks();

                Console.WriteLine("Select an option and press [Enter] 1 for Borrow, 2 for Return, 3 to exit ");
                try
                {
                    int userSelection = Int32.Parse(Console.ReadLine());
                    while (userSelection != 3)
                    {
                    //switch mit cases fuer ausborgen und zurueckgeben und exit
                        switch (userSelection)
                        {
                            case 1:
                                Console.WriteLine("You have chosen to borrow a book, enter ISBN");
                            //abfrgen der ISBN mit int32.parse
                                int selectedborrowISBN = Int32.Parse(Console.ReadLine());
                            //borrowbook aufrufen (siehe bibliothek.cs)
                                lib1.BorrowBook(selectedborrowISBN);
                            // aus schleife brechen > Return
                                break;
                            case 2:
                            //gleich wie case 1
                                Console.WriteLine("You have chosen to return a book, enter ISBN");
                                int selectedreturnISBN = Int32.Parse(Console.ReadLine());
                                lib1.ReturnBook(selectedreturnISBN);
                                break;
                            case 3:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;

                        }
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
}
