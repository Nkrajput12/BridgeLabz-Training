using System;

namespace BridgeLabzTraining.ECommercePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many products do you want to add? ");
            int count = int.Parse(Console.ReadLine());

            // Using Array as requested instead of List
            Product[] cart = new Product[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\n--- Product " + (i + 1) + " ---");

                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());

                Console.WriteLine("Select Category: 1. Electronics, 2. Clothing, 3. Groceries");
                int choice = int.Parse(Console.ReadLine());

                // Polymorphism: Instantiating specific subclasses into the Product array
                if (choice == 1)
                {
                    cart[i] = new Electronics(id, name, price);
                }
                else if (choice == 2)
                {
                    cart[i] = new Clothing(id, name, price);
                }
                else
                {
                    cart[i] = new Groceries(id, name, price);
                }
            }

            // Call the method to display results
            PrintInvoice(cart);
        }

        static void PrintInvoice(Product[] products)
        {
            Console.WriteLine("\n=========================================");
            Console.WriteLine("           E-COMMERCE INVOICE            ");
            Console.WriteLine("=========================================");

            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null)
                {
                    Product p = products[i];

                    // Call abstract methods defined in Product class
                    double discount = p.CalculateDiscount();
                    double tax = p.CalculateTax();

                    // Default info for non-taxable items
                    string taxInfo = "Tax Exempt";

                    // Check if the product implements ITaxable to get TaxDetails
                    if (p is ITaxable)
                    {
                        ITaxable taxableItem = (ITaxable)p;
                        taxInfo = taxableItem.TaxDetails();
                    }

                    // Formula: price + tax - discount
                    double finalPrice = p.Price + tax - discount;

                    Console.WriteLine("Product  : " + p.Name + " (ID: " + p.ProductId + ")");
                    Console.WriteLine("Base Price: $" + p.Price.ToString("N2"));
                    Console.WriteLine("Tax      : +$" + tax.ToString("N2") + " [" + taxInfo + "]");
                    Console.WriteLine("Discount : -$" + discount.ToString("N2"));
                    Console.WriteLine("FINAL    : $" + finalPrice.ToString("N2"));
                    Console.WriteLine("-----------------------------------------");
                }
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}