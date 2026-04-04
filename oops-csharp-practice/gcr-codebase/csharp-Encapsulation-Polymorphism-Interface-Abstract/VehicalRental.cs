using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.access
{
    using System;

    // THE INTERFACE
    
    public interface IInsurable
    {
        double CalculateInsurance();
        string GetInsuranceDetails();
    }

    // 2. THE ABSTRACT CLASS
    // This is a "blueprint". You can't create a "Vehicle" object directly, 
    // but you can create Cars or Bikes based on it.
    public abstract class Vehicle
    {
        public string vehicleNumber;
        public string type;
        public double rentalRate;

        // A constructor to set up the vehicle
        public Vehicle(string vNum, string vType, double rate)
        {
            vehicleNumber = vNum;
            type = vType;
            rentalRate = rate;
        }

        // This is "Abstract" because every vehicle calculates cost differently
        public abstract double CalculateRentalCost(int days);
    }

    // 3. SUBCLASSES (Inheritance)
    public class Car : Vehicle, IInsurable
    {
        // ENCAPSULATION: We make the policy number private so it's hidden
        private string insurancePolicyNumber;

        public Car(string vNum, double rate, string policy) : base(vNum, "Car", rate)
        {
            insurancePolicyNumber = policy;
        }

        // Implementation of the rental cost
        public override double CalculateRentalCost(int days)
        {
            return rentalRate * days;
        }

        // Implementation of the insurance methods
        public double CalculateInsurance() => rentalRate * 0.1; // 10% of rate
        public string GetInsuranceDetails() => "Policy Number: " + insurancePolicyNumber;
    }

    public class Bike : Vehicle
    {
        public Bike(string vNum, double rate) : base(vNum, "Bike", rate) { }

        // Bikes are cheaper, maybe a flat rate?
        public override double CalculateRentalCost(int days)
        {
            return rentalRate * days;
        }
    }

    // 4. THE MAIN PROGRAM
    class Program
    {
        public static void Main(string[]args)
        {
            // Instead of a List, we use a simple Array
            Vehicle[] myVehicles = new Vehicle[3];

            myVehicles[0] = new Car("CAR-001", 50.0, "SECURE-123");
            myVehicles[1] = new Bike("BIKE-99", 15.0);
            myVehicles[2] = new Car("CAR-002", 60.0, "SAFE-456");

            int daysToRent = 5;

            Console.WriteLine("--- RENTAL REPORT ---");

            // POLYMORPHISM: We loop through the array. 
            // Even though they are different (Car/Bike), we treat them all as "Vehicles".
            for (int i = 0; i < myVehicles.Length; i++)
            {
                Vehicle v = myVehicles[i];
                double cost = v.CalculateRentalCost(daysToRent);

                Console.WriteLine("Vehicle: " + v.type + " (" + v.vehicleNumber + ")");
                Console.WriteLine("Rental Cost for " + daysToRent + " days: " + cost);

                // Check if this specific vehicle has insurance
                if (v is IInsurable insurableVehicle)
                {
                    Console.WriteLine("Insurance Cost: $" + insurableVehicle.CalculateInsurance());
                    Console.WriteLine("Details: " + insurableVehicle.GetInsuranceDetails());
                }
                else
                {
                    Console.WriteLine("No insurance needed for this vehicle.");
                }
                Console.WriteLine("-------------------------");
            }
        }
    }
}
