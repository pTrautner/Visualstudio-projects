using UE4_4_Book;

namespace UE4_4_Library
{
    internal class Library
    {
        private Book[] Bookarray; //Private attribute

        public Library(Book[] bookarray) //constructor
        {
            Bookarray = bookarray;
        }
        //~~~~~~~~~~~~~~~~~~Methods for handling objects~~~~~~~~~~~~~~~~~~//
        public Book[] GetArray()//Getter
        { return Bookarray; }
        public void SetArray(Book[] bookarray)//Setter
        { this.Bookarray = bookarray; }

        public void ShowBooks()
        {
            foreach (Book b in Bookarray)
            {
                Console.WriteLine(b.ToString());
            }
        }
        public void BorrowBook(int selectedISBN)
        {
            Book selectedBook = FindBuchByISBN(selectedISBN);
            Console.WriteLine($"You have selected {selectedBook.ToString()}");
            if (selectedBook.GetAvailable() == true ) 
            {
                selectedBook.SetAvailability(false);
                Console.WriteLine($"Book Borrowed");
            }
            else
            {
                Console.WriteLine($"Selected book not available");
            }
        }
        private Book FindBuchByISBN(int isbn)
        {
            Book searchedbook = null;
            foreach (Book b in Bookarray) 
            {
                if (b != null && b.GetISBN() == isbn)
                    searchedbook = b;
            }
            return searchedbook;
        }
        public void ReturnBook(int selectedISBN)
        {
            try
            {
                Book selectedBook = FindBuchByISBN(selectedISBN);
                Console.WriteLine($"You have selected {selectedBook.ToString()}");
                if (selectedBook.GetAvailable() == false)
                {
                    selectedBook.SetAvailability(true);
                    Console.WriteLine($"Book Returned");
                }
                else
                {
                    Console.WriteLine($"Selected book already in library");
                }
            }
            catch (Exception e) { Console.WriteLine("Invalid input"); }
        }
    }
}