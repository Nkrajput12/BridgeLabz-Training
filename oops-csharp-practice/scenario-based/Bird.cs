using System;

//declare interface for fly
public interface IFlyable
{
    bool Fly();

}
//declare interface for swim
public interface ISwimmable
{
    bool Swim();
}

//this is absract class inherit the property of IFlyable and ISwimmable interface
abstract class Bird : IFlyable , ISwimmable
{
    public string name; //name of the bird
    public Bird(string name) //constructor to intiallize the name
    {
        this.name = name;
    }


    public abstract bool Fly(); //abstract method
    public abstract bool Swim(); //abstract method

    //method to display the details 
    public void Display()
    { 
        if(Fly() == true && Swim()== false) //check for fly
        {
            Console.WriteLine(name + " Can Fly");
        }
        else if(Swim() == true && Fly()== false) //check for swim
        {
            Console.WriteLine(name+" can swim");
        }
        else if(Swim() == true && Fly() == true) //check for both
        {
            Console.WriteLine(name+" can fly and swim both");
        }

    }

}
class Eagle : Bird //the eagle class inherit the property of bird
{
    //constructor for eagle class 
    public Eagle() : base("Eagle") { }

    public override bool Fly()//fly method override 
    {
        return true;    
    }

    public override bool Swim()//swim method override
    {
        return false;
    }
}

class Sparrow : Bird
{
    public Sparrow() : base("Sparrow") { }

    public override bool Fly()
    {
        return true;
    }

    public override bool Swim()
    {
        return false;
    }
}

class Duck : Bird
{
    public Duck() : base("Duck") { }

    public override bool Fly()
    {
        return false;
    }

    public override bool Swim()
    {
        return true;
    }

}

class Penguin : Bird
{
    public Penguin() : base("Penguin") { }

    public override bool Fly()
    {
        return false;
    }

    public override bool Swim()
    {
        return true;
    }
}

class Seagull : Bird
{
    public Seagull() : base("Seagull") { }

    public override bool Fly()
    {
        return true;
    }

    public override bool Swim()
    {
        return true;
    }
}

//class with main method
class Sanctuary
{
    public static void Main(string[] args)
    {
        //declacring the array for class objects
        Bird[] sanctuary = new Bird[]
        {
        new Eagle(),
        new Sparrow(),
        new Duck(),
        new Penguin(),
        new Seagull()
        };

        //for each loop to accessing object one by one
        foreach (Bird b in sanctuary)
        {
            //Console.WriteLine(b.name);
            b.Display();
        }
    }
}


