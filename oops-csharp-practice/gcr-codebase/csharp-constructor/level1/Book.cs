using System;

class Book
{
    //declare the global variables
    public string title;
    public string author;
    public double price;

    public Book() // Default constructor
    {
        title = "unknown";   
        author = "Unknown";
        price = 0.0;
    }

    public Book(string title, string author, double price) // Parameterized constructor
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void Display()
    {
        Console.WriteLine($"Book: {title} | Author: {author} | Price: {price}");
    }
}

class Application
{
    public static void Main(string[] args)
    {
        Book b1 = new Book(); // Uses default
        Book b2 = new Book("C#", "Microsoft", 500.0); // Uses parameterized

        b1.Display(); //display details
        b2.Display(); //display details
    }
}