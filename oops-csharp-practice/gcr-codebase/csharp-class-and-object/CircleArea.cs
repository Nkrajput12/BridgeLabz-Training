using System;
class CircleArea
{
    private double radius;

    public void SetRadius(double radius) //set the radius of the circle
    {
        this.radius = radius;
    }
    public double ComputeArea(double radius) //method for calculating the area of the circle
    {
        return 3.14*radius*radius; 
    }
    public void Display(double area) //method to display the area of the circle
    {
        Console.WriteLine("the area of the circle is = "+area);
    }


}
class program
{
    public static void Main(string[] args)
    {
        CircleArea obj = new CircleArea(); //declare object of CircleArea class
        // taking input from user for radius
        Console.Write("Enter the radius: ");
        double radius = Convert.ToDouble(Console.ReadLine()); //assign user input to radius variable

        obj.SetRadius(radius); //pass the radius to  set the radius
        double area = obj.ComputeArea(radius);

        obj.Display(area); //method to display the area        

    }
}

