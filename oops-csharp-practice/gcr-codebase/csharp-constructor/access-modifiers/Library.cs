using System;

class Book
{
    public string ISBN;          // Isbn ID
    protected string title;      // Shared with EBooks
    private string author;       // Secret/Internal to this class

    public Book(string isbn, string title, string author)
    {
        this.ISBN = isbn;
        this.title = title;
        this.author = author;
    }

    // Getter and Setter for the private author
    public string GetAuthor() => author;
    public void SetAuthor(string a) => author = a;
}

class EBook : Book
{
    public double fileSizeMB;

    public EBook(string isbn, string title, string author, double size) : base(isbn, title, author)
    {
        this.fileSizeMB = size;
    }

    public void DisplayEBook()
    {
        // Can see ISBN (public) and Title (protected)
        Console.WriteLine($"EBook: {title} | ISBN: {ISBN} | Size: {fileSizeMB}MB");
    }
}

class Application
{
    public static void Main()
    {
        EBook myEbook = new EBook("978-3", "C# Mastery", "John Smith", 1.5);
        myEbook.DisplayEBook();
        Console.WriteLine("Author: " + myEbook.GetAuthor());
    }
}