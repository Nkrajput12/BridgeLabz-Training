using System;

class LibraryBook
{ 
    //global veriables
    public string title;
    public bool isAvailable = true;

    public LibraryBook(string title) //constructor
    {
        this.title = title;
    }

    public void BorrowBook() //method to borrow if available
    {
        if (isAvailable)
        {
            isAvailable = false;
            Console.WriteLine($"Success: You have borrowed '{title}'.");
        }
        else
        {
            Console.WriteLine($"Error: '{title}' is already borrowed by someone else.");
        }
    }
}

class Library
{
    public static void Main(string[] args)
    {
        LibraryBook myBook = new LibraryBook("Ramayan");

        myBook.BorrowBook(); // First time: Success
        myBook.BorrowBook(); // Second time: Error
    }
}