using System;

// Superclass (Parent)
class Animal
{
    public string Name;
    public int Age;

    //constructor to intiallize the value
    public Animal(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }

    // 'virtual' tells C# that children are allowed to override this method
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a generic sound.");
    }
}

// Subclass: Dog
class Dog : Animal
{
    // Passing data to the parent constructor using 'base'

    //constructor for dog class 
    public Dog(string name, int age) : base(name, age) { }

    // 'override' replaces the parent's generic sound with a specific one
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the Dog barks");
    }
}

// Subclass: Cat
class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the Cat says: Meow!");
    }
}

// Subclass: Bird
class Bird : Animal
{
    public Bird(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the Bird says: Chirp! Chirp!sssssss");
    }
}

class Application
{
    public static void Main(string[] args)
    {
        // Creating different animal objects
        Animal myDog = new Dog("tommy", 3);
        Animal myCat = new Cat("meow", 2);
        Animal myBird = new Bird("rocky", 1);

        Console.WriteLine("--- Animal Sound Check ---");

        // Polymorphism in action: 
        // Even though these are stored as 'Animal' types, 
        // they call their specific overridden sounds.
        myDog.MakeSound();
        myCat.MakeSound();
        myBird.MakeSound();
    }
}