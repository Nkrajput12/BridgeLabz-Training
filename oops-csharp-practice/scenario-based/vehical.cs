using System;

// interface to declare calculate Rent method
interface IRentable
{
    void CalRent(int days);
}

//super class inherit interface
public abstract class Vehical : IRentable
{
    protected string modal;
    protected double dailyRate;

    public Vehical(string modal, double dailyRate)
    {
        this.modal = modal;
        this.dailyRate = dailyRate;
    }
    public void CalRent(int days) //method to calculate and display the rent 
    {
        double rate = dailyRate * days; //formula to calculate rent
        Console.WriteLine("daily rate = " + dailyRate + "\nNumber of days = " + days);


        Console.WriteLine("Total Rent = " + rate);
    }

    //method to display the modal
    public virtual void Display()
    {
        Console.WriteLine("Modal = " + modal);
    }
}

class Car : Vehical //car class 
{
    //use base keyword to pass value to parent constructor
    public Car(string modal) : base(modal, 2000) { }
}
class Bike : Vehical //bike class
{
    //use base keyword to pass value to parent constructor
    public Bike(string modal) : base(modal, 700) { }
}
class Truck : Vehical
{
    //use base keyword to pass value to parent constructor
    public Truck(string modal) : base(modal, 5000) { }
}
class Boat : Vehical
{
    //use base keyword to pass value to parent constructor
    public Boat(string modal) : base(modal, 1500) { }
}

class Costumer //costumer class 
{
    String name;
    int days;
    public Costumer(string name, int days)
    {
        this.name = name;
        this.days = days; //constructor to initialize the name and days
    }

    //creating vehical class array 
    Vehical[] type = new Vehical[]
    {
        new Car("car"), // create object for car
        new Bike("Bike"), // create object for bike
        new Truck("Truck"), // create object for truck
        new Boat("Boat") //create object for boat
    };

    public void Displaydetails() //method to display details of costumer and vehical to rent
    {
        Console.WriteLine("-------details-------");
        Console.WriteLine("Costumer name = " + name);
        Console.WriteLine("number of days = " + days);
        for(int i = 0; i < type.Length; i++)
        {
            Console.WriteLine("----------------------");
            type[i].Display();
            type[i].CalRent(days);

        }

        Console.WriteLine("-------------------------------------------------");
    }
}
class Rental
{
    public static void Main(string[] args)
    {
        //creating object of costumer class
        Costumer mohan = new Costumer("Mohan", 10);
        Costumer Sohan = new Costumer("Sohan", 5);
        Costumer sonu = new Costumer("sonu", 2);

        mohan.Displaydetails(); //call method to display details
        Sohan.Displaydetails();

    }
}

