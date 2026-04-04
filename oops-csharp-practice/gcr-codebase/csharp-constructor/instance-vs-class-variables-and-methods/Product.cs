using System;

class Product
{
    // Instance Variables: Every product has its own name and price
    public string productName;
    public double price;

    // Class Variable: Shared by all products to keep track of count
    public static int totalProducts = 0;

    public Product(string productName, double price)
    {
        this.productName = productName;
        this.price = price;

        // Every time a new product is "born", we increment the global counter
        totalProducts++;
    }

    // Instance Method: Displays details of a SPECIFIC product
    public void DisplayDetails()
    {
        Console.WriteLine($"Product: {productName} | Price: {price}");
    }

    // Class Method: Displays the count for the WHOLE factory
    public static void DisplayProducts()
    {
        Console.WriteLine("\n--- Inventory Report ---");
        Console.WriteLine("Total products in stock: " + totalProducts);
        
    }
}

class Application
{
    public static void Main()
    {
        // Creating individual products
        Product p1 = new Product("Laptop", 45000);
        Product p2 = new Product("Smartphone", 15000);

        // Showing specific details
        p1.DisplayDetails();
        p2.DisplayDetails();

        // Calling the static method using the Class Name
        Product.DisplayProducts();
    }
}