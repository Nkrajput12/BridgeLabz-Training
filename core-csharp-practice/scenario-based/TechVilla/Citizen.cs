using System;

public class Citizen
{
    public string Name;
    public int Age;
    public double Income;
    public int ResidencyYears;

    public Citizen(string name,int age,double income,int years)
    {
        this.Name = name;
        this.Age = age;
        this.Income = income;
        this.ResidencyYears = years;
    }


    public double GetServiceEligibilityScore()
    {
        return (Age*2)+(Income/100)+(ResidencyYears*2);
    }

    public bool ValidForSubsidy()
    {
        return Income < 30000;
    }

    public void Display()
    {
        Console.WriteLine("---Citizen Profile---");
        Console.WriteLine("Name = "+Name);
        Console.WriteLine("Age = "+Age);
        Console.WriteLine("Income = "+Income);
        Console.WriteLine("Residency Years = "+ResidencyYears);
        Console.WriteLine("Eligibility Score = "+GetServiceEligibilityScore());
        Console.WriteLine($"Subsidy = {(ValidForSubsidy()? "Eligible" : "Not Eligible" )}");
                

    }
}