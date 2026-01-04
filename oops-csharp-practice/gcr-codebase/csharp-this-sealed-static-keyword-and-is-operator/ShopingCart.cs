using System;

public class Product
{
    // Static variable to store the discount percentage
    public static double Discount { get; private set; } = 0.0;
    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }
    public readonly int ProductID;
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    // Constructor to initialize product details
    public Product(int id, string name, double price, int quantity)
    {
        this.ProductID = id;
        this.ProductName = name;
        this.Price = price;
        this.Quantity = quantity;
    }

    // Method to calculate the total price with discount
    public double TotalPrice()
    {
        double discounted = Price * (1 - Discount / 100);
        return discounted * Quantity;
    }
}
public class ShoppingCartSystem
{
    public static void Main(string[] args)
    {
        // Update the discount percentage
        Product.UpdateDiscount(10.0);

        // Create product instances
        Product product1 = new Product(1, "Laptop", 1000.0, 2); //1st object
        Product product2 = new Product(2, "Smartphone", 500.0, 3);//2nd object

        // Check if an object is an instance of Product
        if (product1 is Product)
        {
            Console.WriteLine($"Product 1 Price after discount: ${product1.TotalPrice()}");
        }

        if (product2 is Product)
        {
            Console.WriteLine($"Product 2 Price after discount: ${product2.TotalPrice()}");
        }
    }
}