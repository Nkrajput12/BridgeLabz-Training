using System;

// Superclass
class Vehicle
{
    //declaring maxspeed and fuelType variable
    public int MaxSpeed;
    public string FuelType;

    //default constructor
    public Vehicle(int maxSpeed, string fuelType)
    {
        this.MaxSpeed = maxSpeed;
        this.FuelType = fuelType;
    }

    // 'virtual' allows subclasses to override this method 
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Speed: {MaxSpeed} km/h | Fuel: {FuelType}");
    }
}

// Subclass: Car
class Car : Vehicle
{
    public int SeatCapacity;

    //constructor of car class with base keyword to access vehicle cons.
    public Car(int speed, string fuel, int seats) : base(speed, fuel)
    {
        this.SeatCapacity = seats; //assign seats
    }

    public override void DisplayInfo()
    {
        // Calling base.DisplayInfo() to show shared traits first
        base.DisplayInfo();
        Console.WriteLine($"Type: Car | Seats: {SeatCapacity}");
    }
}

// Subclass: Truck
class Truck : Vehicle
{
    public int PayloadCapacity;

    public Truck(int speed, string fuel, int payload) : base(speed, fuel)
    {
        this.PayloadCapacity = payload;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Type: Truck | Payload: {PayloadCapacity} kg");
    }
}

// Subclass: Motorcycle
class Motorcycle : Vehicle
{
    public bool HasSidecar;

    public Motorcycle(int speed, string fuel, bool sidecar) : base(speed, fuel)
    {
        this.HasSidecar = sidecar;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Type: Motorcycle | Has Sidecar: {HasSidecar}");
    }
}

class App
{
    public static void Main(string[] args)
    {
        //creating object for all the class
        Vehicle car = new Car(180, "petrol", 4);
        Vehicle truck = new Truck(120, "CNG", 10000);
        Vehicle motorcycle = new Motorcycle(120, "petrol",false);


        //callig display method to all the object
        Console.WriteLine("--------Display method---------");
        car.DisplayInfo();
        Console.WriteLine("--------------------------------");
        truck.DisplayInfo();
        Console.WriteLine("--------------------------------");
        motorcycle.DisplayInfo();
    
    }
}