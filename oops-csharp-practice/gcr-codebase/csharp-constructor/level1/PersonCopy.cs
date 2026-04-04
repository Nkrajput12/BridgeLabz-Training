using System;

class Person
{
    public string name;
    public int age;

    public Person(string name, int age) // Parameterized constructor
    {
        this.name = name;
        this.age = age;
    }

    public Person(Person other) // Copy constructor
    {
        this.name = other.name;
        this.age = other.age;
    }

    public void Display() => Console.WriteLine($"Name: {name}, Age: {age}");
}

class Application
{
    public static void Main(string[] args)
    {
        Person p1 = new Person("Raj", 25);
        Person p2 = new Person(p1); // Cloning p1 into p2

        Console.WriteLine("Original Object:");
        p1.Display();
        Console.WriteLine("Copied Object:");
        p2.Display();
    }
}