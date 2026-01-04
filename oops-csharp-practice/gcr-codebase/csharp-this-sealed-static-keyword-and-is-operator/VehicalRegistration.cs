using System;

class Vehicle
{
    static double RegistrationFee = 500.0; // static variable common for all vehicles
    public string OwnerName;
    public string VehicleType;
    public readonly string RegistrationNumber; // readonly to uniquely identify and prevent changes

    public Vehicle(string OwnerName, string VehicleType, string RegistrationNumber) // constructor to initialize values
    {
        this.OwnerName = OwnerName; // using 'this' to refer to class field
        this.VehicleType = VehicleType;
        this.RegistrationNumber = RegistrationNumber;
    }

    public static void UpdateRegistrationFee(double newFee) // static method to modify the shared fee
    {
        RegistrationFee = newFee;
        Console.WriteLine("System Update: New Registration Fee is " + RegistrationFee);
    }

    public void DisplayDetails() // method to display vehicle info
    {
        Console.WriteLine("Registration Number = " + RegistrationNumber);
        Console.WriteLine("Owner Name          = " + OwnerName);
        Console.WriteLine("Vehicle Type        = " + VehicleType);
        Console.WriteLine("Current Fee         = " + RegistrationFee);
        
    }
}

class Registration // application class
{
    public static void Main(string[] args)
    {
        Vehicle v1 = new Vehicle("Karan", "SUV", "IND12345"); // create first vehicle object
        Vehicle v2 = new Vehicle("Sonia", "Sedan", "IND67890"); // create second vehicle object

        // 1. Check if objects belong to the Vehicle class using 'is' operator
        if (v1 is Vehicle && v2 is Vehicle)
        {
            Console.WriteLine("Verification: Valid Vehicle objects detected.");
            v1.DisplayDetails();
            v2.DisplayDetails();
        }

        // 2. Modify the static fee using the static method
        Vehicle.UpdateRegistrationFee(750.0);

        // 3. Display again to show that the static fee changed for all instances
        Console.WriteLine("\nAfter Fee Update:");
        v1.DisplayDetails();
    }
}