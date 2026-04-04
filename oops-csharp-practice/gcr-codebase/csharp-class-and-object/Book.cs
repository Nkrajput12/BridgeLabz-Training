using System;
class Book
{
    private string title;
    private string author;
    private double price;

    //method to set the book details
    public void SetDetails(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    //method to display book details
    public void Display()
    {
        Console.WriteLine("Book name : " + title);
        Console.WriteLine("Author    : " + author);
        Console.WriteLine("Price     : " + price);
    }
}

class ShowBook
{
    static void Main()
    {
        //make object of book 
        Book b = new Book();
        //take the input from user
        Console.Write("Enter the book title ");
        string title = Console.ReadLine() ?? ""; // store the title of the book in this 
        Console.Write("Enter the  author name ");
        string author = Console.ReadLine() ?? ""; //store the author name
        Console.Write("Enter Book Price: ");
        double price = Convert.ToDouble(Console.ReadLine()); //store the price of the book

        b.SetDetails(title, author, price);  // calling the function to set details
        b.Display(); //call the dispaly method to show the details
    }
}