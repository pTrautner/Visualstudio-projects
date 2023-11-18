namespace UE4_4_Book
{
    internal class Book
    {
        //Attributes (Private values can only be initialized in Bibliothek.cs)
        private string Title;
        private int Isbn;
        private bool Isavailable;
        //~~~~~~~~~~~~~~~~~~Constructor~~~~~~~~~~~~~~~~~~//
        public Book(string title, int isbn, bool isavailable = true)
        {
            this.Title = title;
            this.Isbn = isbn;
            this.Isavailable = isavailable;
        }
        //Methods for handling objects
        public string GetTitle() //Getter 
        { return Title; }
        public void SetTitle(string title) //Setter
        { this.Title = title; }
        public int GetISBN() //Getter:
        { return Isbn; }
        public void SetISBN(int isbn) //Setter
        { this.Isbn = isbn; }
        public bool GetAvailable() //Getter
        { return Isavailable; }
        public void SetAvailability(bool isavailable) //Setter
        { this.Isavailable = isavailable; }
        public override string ToString()
        {
            return $"Title: {Title} , ISBN: {Isbn} available: {Isavailable}";
        }
}
}
