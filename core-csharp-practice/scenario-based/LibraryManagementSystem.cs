using System;
using System.Reflection.Metadata.Ecma335;
class LibraryManagementSystem
{
    //main method
    public static void Main(string[] args)
    {
        //Define the initial 30 books
        string[,] initialBooks = new string[30, 3]
        {
    { "The Alchemist", "Paulo Coelho", "Available" },
    { "1984", "George Orwell", "Borrowed" },
    { "The Great Gatsby", "F. Scott Fitzgerald", "Available" },
    { "To Kill a Mockingbird", "Harper Lee", "Available" },
    { "The Hobbit", "J.R.R. Tolkien", "Borrowed" },
    { "Mathura: A District Memoir", "F.S. Growse", "Available" },
    { "The Gita", "Vyasa", "Available" },
    { "War and Peace", "Leo Tolstoy", "Borrowed" },
    { "Ulysses", "James Joyce", "Available" },
    { "The Catcher in the Rye", "J.D. Salinger", "Available" },
    { "Pride and Prejudice", "Jane Austen", "Borrowed" },
    { "Brave New World", "Aldous Huxley", "Available" },
    { "The Little Prince", "Antoine de Saint-Exupéry", "Available" },
    { "The Odyssey", "Homer", "Borrowed" },
    { "Crime and Punishment", "Fyodor Dostoevsky", "Available" },
    { "The Divine Comedy", "Dante Alighieri", "Available" },
    { "Moby Dick", "Herman Melville", "Borrowed" },
    { "Gulliver's Travels", "Jonathan Swift", "Available" },
    { "The Iliad", "Homer", "Available" },
    { "One Hundred Years of Solitude", "Gabriel García Márquez", "Borrowed" },
    { "The Brothers Karamazov", "Fyodor Dostoevsky", "Available" },
    { "The Stranger", "Albert Camus", "Available" },
    { "Madam Bovary", "Gustave Flaubert", "Borrowed" },
    { "Old Man and the Sea", "Ernest Hemingway", "Available" },
    { "The Trial", "Franz Kafka", "Available" },
    { "The Castle", "Franz Kafka", "Borrowed" },
    { "Waiting for Godot", "Samuel Beckett", "Available" },
    { "The Metamorphosis", "Franz Kafka", "Available" },
    { "Faust", "Johann Wolfgang von Goethe", "Borrowed" },
    { "A Tale of Two Cities", "Charles Dickens", "Available" }
        };

        //  Declare 50-slot inventory
        string[,] inventory = new string[50, 3];
        int bookcount = initialBooks.GetLength(0); // This is 30

        //  Copy the 30 books into the first 30 slots of the 50-slot inventory
        for (int i = 0; i < bookcount; i++)
        {
            inventory[i, 0] = initialBooks[i, 0]; // adding Title
            inventory[i, 1] = initialBooks[i, 1]; // adding Author
            inventory[i, 2] = initialBooks[i, 2]; // adding Status
        }


        Console.WriteLine("\t-------------------------Library Managment System-----------------------------"); //acknowlegment to user
        Console.WriteLine("Press 1 if you are Admin\tPress 2 if you are a User");
        int n = Convert.ToInt32(Console.ReadLine()); //taking user input 
        string setpass = "admin123"; //this is admin password

        //making object of the class
        LibraryManagementSystem obj = new LibraryManagementSystem();

        if(n == 1)
        {  
            int try1 = 0; //declare try to track how many times user enter wrong password
            while (true)
            {
                Console.Write("Please Enter Password: ");
                string pass = Console.ReadLine() ?? ""; //taking password input from the admin
                if (setpass.Equals(pass))
                {
                    obj.Admin(inventory,bookcount); 
                }
                else //if user enter wrong pass this block of code execute
                {
                    Console.WriteLine("Invalid input");
                    try1++; //increment try if user enter wrong pass
                    if(try1 > 3){ //check if user enter wrong pass more than 3 times or not
                        Console.Error.WriteLine("you enter wrong password more than 3 times");
                        Console.Error.WriteLine("\t\t!!!!!!!!!!!Access Denied!!!!!!!!!!!");
                        Environment.Exit(1); //if user enter the wrong pass more than 3 times terminate the programme
                    }
                }
            }
           
        }
        else if (n == 2)
        {
            obj.User(inventory, bookcount); //if user choose the 2 option call method user
        }
        else
        {
            Console.WriteLine("please enter valid input");
        }
       
    }


    //this method is only access by admin------------------------(Method For Admin)---------------------------------------------------------
    void Admin(string[,] inventory,int bookcount)
    {
        //making object of the class
        LibraryManagementSystem obj = new LibraryManagementSystem();

        while (true) //this loop is run until user press for logout
        {
            Console.WriteLine("\nPress 1 to display all the Books:"); //prompt user to enter choice
            Console.WriteLine("Press 2 to search a Book:");
            Console.WriteLine("press 3 to Add a Book:");
            Console.WriteLine("press 4 to remove a book");
            Console.WriteLine("press 5 to Logout");
            Console.Write("Input Here: ");
            int n = Convert.ToInt32(Console.ReadLine()); //choice store in n

            switch (n) //switch is use to call method according to user input
            {
                case 1:
                    obj.DisplayAll(inventory,bookcount); //method for Display all the books
                    break;

                case 2:
                    obj.Search(inventory, bookcount); //method for search the book by book name 
                    break;

                case 3:
                    inventory = obj.AddBook(inventory,ref bookcount); //method for add book to the inventory
                    break;

                case 4:
                    inventory = obj.RemoveBook(inventory, ref bookcount); //method for remove book from the inventory
                    break;
                case 5:
                    Console.WriteLine("--------------logout successfull--------------");
                    Environment.Exit(0); //if user choose for logout or press5 code terminatte successfully
                    break;
                default:
                    Console.WriteLine("Invalid Input/n"); //if user enter input other than choices
                    break;
            }
            
            

        }
    }

    //method for user -----------------------------------------(This Method is only access by user)------------------------------------------------
    void User(string[,] inventory,int bookcount)
    {
        LibraryManagementSystem obj = new LibraryManagementSystem();
        while (true)
        {
            Console.WriteLine("\nPress 1 to display all the Books:"); //prompt user to enter choice
            Console.WriteLine("Press 2 to search a Book:");
            Console.WriteLine("press 3 to checkout:");
            Console.WriteLine("press 4 to Logout");
            Console.Write("Input Here: ");
            int n = Convert.ToInt32(Console.ReadLine()); //choice store in n
            switch (n) //switch is use to call method according to user input
            {
                case 1:
                    obj.DisplayAll(inventory, bookcount); //method to display the all book

                    break;

                case 2:
                    obj.Search(inventory, bookcount); //method to search a book by its name
                    break;
                case 3:
                    inventory = obj.CheckOut(inventory); //method for checkout the inventory
                    break;
                
                case 4:
                    Console.WriteLine("--------------logout successfull--------------");
                    Environment.Exit(0); //if user press for logout this will terminate code successfully
                    break;

                default:
                    Console.WriteLine("Invalid Input/n"); //if user enter wrong input
                    break;
            }

        }
    }

    //Method to display all the books----------------------------(This Method is access by both user and Admin)-------------------------------------
    void DisplayAll(string[,] inventory,int bookcount) //this method display all the books in the inventory
    {
        Console.WriteLine("  \tName\t\t Author\t\t Status"); 
        for(int i =0; i < bookcount; i++)
        {
            Console.WriteLine((i + 1) + ".>\t" + inventory[i,0]+"\t|"+ inventory[i, 1]+"\t|"+ inventory[i, 2]); //display all the books 
        }
    }


    //method to add book to the inventory-------------------------(This Method is only Access by Admin)---------------------------------------------
    string[,] AddBook(string[,] inventory,ref int bookcount)
    {
        Console.Write("Book Name  : ");
        inventory[bookcount, 0] = Console.ReadLine() ?? ""; //input book name
        Console.Write("author Name: ");
        inventory[bookcount, 1] = Console.ReadLine() ?? ""; // input author name
        inventory[bookcount, 2] = "Available"; //declaring status intiall when you add book it must available.


        Console.WriteLine("---------------Your Book is successfully Add---------------");

        bookcount++; //this also increment the book count in admin method too because i use ref:
        return inventory;
    }

    //Method to search book by book name -------------------------(This Method is Access by Both User and Admin)--------------------------------------
    void Search(string[,] inventory, int bookcount)
    {
        Console.Write("Plese enter the book name here: "); //prompt user to enter the name of the book 
        string book = Console.ReadLine() ?? "".ToLower(); //convert user input into lower case and store in book variable

        for (int i = 0; i < bookcount; i++)
        {
            string c = inventory[i, 0].ToLower(); //conver value into lower and store in c
            if (c.Contains(book)) //check if c contains the book substring or not
            {
                //display the book name, author name ,status along with index number
                Console.WriteLine("Book Name = " + inventory[i, 0] + "\tAuthor Name = " + inventory[i, 1]);
                Console.WriteLine("status = " + inventory[i, 2] + "\tslot number = " + (i + 1));

            }
        }
    }


        //Method to remove a book from inventory-------------------(This method is only access by Admin)------------------------------------------
    string[,] RemoveBook(string[,] inventory, ref int bookcount)
    {
        Console.Write("Enter the slot number of the book you want to remove: ");
        int slot = Convert.ToInt32(Console.ReadLine())-1; //taking the index number of the book you want to remove
        if (slot >= 0 && slot <= bookcount)
        {
            for (int i = slot; i < bookcount; i++) //loop is start from the index number of book admin want to remove
            {
                //logic to move every book one position up
                inventory[i, 0] = inventory[i + 1, 0]; //for book name
                inventory[i, 1] = inventory[i + 1, 1]; //for author name
                inventory[i, 2] = inventory[i + 1, 2]; //for status
            }
            //assign last index to null
            inventory[bookcount - 1, 0] = null ?? "";
            inventory[bookcount - 1, 1] = null ?? "";
            inventory[bookcount - 1, 2] = null ?? "";

            bookcount--; //decrement the bookcount
        }
        Console.WriteLine("----Book Removed Successfull----");
            return inventory;  
    }

    //method for checkout of books ----------------------------------------(This method is only access by user)---------------------------------------------------------
    string[,] CheckOut(string[,] inventory)
    {
        Console.Write("\nEnter the slot number of the book you want to checkout: ");
        int slot = Convert.ToInt32(Console.ReadLine()); //taking input the slot number of the book


        if (inventory[slot-1,2] == "Available") //check if the book available or not
        {
            inventory[slot - 1, 2] = "Borrowed"; //if book is not available then update the status

            Console.WriteLine("----------The book is successfully checkout---------- ");
        }
        else
        {
            Console.WriteLine("\nThis book is not available"); //if book is not available
        }
            return inventory;//return the inventory
    }

}
