using System;

class Vehicle
{
    // Instance Variables: These change from car to car
    public string ownerName;
    public string vehicleType;

    // Class Variable: The fee is the same for everyone
    public static double registrationFee = 1000.0;

    public Vehicle(string ownerName, string vehicleType)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
    }

    // Instance Method: Shows owner details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"Owner: {ownerName} | Type: {vehicleType} | Fee Paid: {registrationFee}");
    }

    // Class Method: Change the fee globally
    public static void UpdateRegistrationFee(double newFee)
    {
        registrationFee = newFee;
    }
}

class Application
{
    public static void Main()
    {
        Vehicle v1 = new Vehicle("Karan", "SUV");
        Vehicle v2 = new Vehicle("Sneha", "Bike");

        Console.WriteLine("Standard Registration:");
        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();

        // Updating the class variable via static method
        Vehicle.UpdateRegistrationFee(1500.0);

        Console.WriteLine("\nUpdated Registration (New Rates):");
        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();
    }
}