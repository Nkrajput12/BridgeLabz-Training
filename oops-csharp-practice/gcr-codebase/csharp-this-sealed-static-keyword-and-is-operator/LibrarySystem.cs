using System;

class LibrarySystem
{
    public static string LibraryName = "Vidya Library";
    private string title;
    private string author;
    private readonly long isbn;

    //method to display the library name
    public void GetLibraryName()
    {
        Console.WriteLine("Library name = "+LibraryName);
    }

    //perimeterized Constructor intialize the value of title,author and isbn
    public LibrarySystem(string title, string author, long isbn)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
    }

    //method to display the details
    public void Display()
    {
        Console.WriteLine("Book name = " + title);
        Console.WriteLine("author name = " + author);
        Console.WriteLine("ISBN number = "+isbn);
    }
}
class Library
{
    public static void Main(string[] args)
    {
        //Creating objects
        LibrarySystem book1 = new LibrarySystem("Jungle", "Kartik" , 1475963845247); 
        LibrarySystem book2 = new LibrarySystem("Alakh Nanda", "ayush", 1485963845947);
        //method to get the library name
        book1.GetLibraryName();

        if(book1 is LibrarySystem && book2 is LibrarySystem) //check if the object is the instance of class by is operator
        {
            Console.WriteLine("Yes the object is the instance of class");
            //display the object details
            book1.Display(); 
            book2.Display();
        }

    }
}

