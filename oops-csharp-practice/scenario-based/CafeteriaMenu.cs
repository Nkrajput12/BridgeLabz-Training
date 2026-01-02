using System;
class CafeteriaMenu
{
    static void Main(string[] args)
    {
        CafeteriaMenu obj = new CafeteriaMenu(); //declaring object
        string[,] items = //intial menu
        {
            { "Tea" ,"10 INR" },
            { "Coffee","25 INR" },
            { "Sandwich","50 INR" },
            { "Burger", "250 INR" },    //2d string 0 col for item and 1 col for price 
            { "Pizza", "750 INR" },
            { "Pasta", "500 INR" },
            { "Noodles", "500 INR" },
            { "Samosa", "60 INR" },
            { "Juice", "100 INR" },
            { "Ice Cream", "250 INR"}
        };

        

        obj.DisplayMenu(items); //method for display menu


        Console.WriteLine("  ");
        Console.WriteLine("Enter item you want to order");
        int index = Convert.ToInt32(Console.ReadLine()); //taking input for user choice

        obj.OrderItem(items, index); // call tho order the item

    }

    void DisplayMenu(string[,] items) //method to display the menu
    {
        Console.WriteLine("-------------Cafeteria Menu---------------");

        for (int i = 0; i < items.GetLength(0); i++)
        {
            Console.WriteLine((i + 1) + ". " + items[i,0] + " ----> " + items[i,1]); //display menu along 
        }
    }

    void OrderItem(string[,] items, int index) //method to take order
    {
        if (index < items.GetLength(0)) 
        {
            Console.WriteLine("You ordered for " + items[(index - 1),0]+" is successfull "); //acknowledgement for order
        }
        else
        {
            Console.WriteLine("Please Enter valid input");
        }
    }
}





