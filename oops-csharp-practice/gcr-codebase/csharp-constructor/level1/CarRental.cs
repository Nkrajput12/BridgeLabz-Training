using System;

class CarRental
{
    //declaring global variables
    public string customerName;
    public string carModel;
    public int rentalDays;
    public double ratePerDay = 1200.0;

    //constructor
    public CarRental(string customerName, string carModel, int rentalDays)
    {
        this.customerName = customerName;
        this.carModel = carModel;
        this.rentalDays = rentalDays;
    }

    //method to show Invoice 
    public void ShowInvoice()
    {
        double total = rentalDays * ratePerDay;
        Console.WriteLine($"--- INVOICE ---");
        Console.WriteLine($"Customer : {customerName}");
        Console.WriteLine($"Car Model: {carModel}");
        Console.WriteLine($"Total Cost: {total} for {rentalDays} days.");
    }
}

class Application
{
    public static void Main(string[] args)
    {
        CarRental rental = new CarRental("Raj", "Tesla Model 3", 5);
        rental.ShowInvoice();
    }
}