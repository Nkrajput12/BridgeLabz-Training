using System;

class Circle
{
    public double radius;

    public Circle() : this(1.0) // Chaining: Default constructor calls parameterized with 1.0
    {
        Console.WriteLine("Default Circle Created (Radius 1.0)");
    }

    public Circle(double radius) // Main constructor
    {
        this.radius = radius;
    }

    public void GetArea()
    {
        Console.WriteLine("Area of Circle: " + (3.14 * radius * radius));
    }
}

class App
{
    public static void Main(string[] args)
    {
        Circle c1 = new Circle(); // Calls chained constructor
        Circle c2 = new Circle(5.0); // Calls parameterized constructor
        
        c1.GetArea(); //calling methods
        c2.GetArea();
    }
}