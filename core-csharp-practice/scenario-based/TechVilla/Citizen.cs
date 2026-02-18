using System;

public class Citizen
{
    public int id;
    public string Name;
    public int Age;
    public double Income;
    public int ResidencyYears;

    public Citizen(int id,string name,int age,double income,int years)
    {
        this.id = id;
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

    public string GetServicePackage()
    {
        double score = GetServiceEligibilityScore();
        int tier;
        
        if(score > 500) tier =4;
        else if(score > 300) tier = 3;
        else if(score > 100) tier = 2;
        else tier = 1;

        switch(tier)
        {
            case 4: return "Platinum";
            case 3: return "Gold";
            case 2: return "Silver";
            default: return "Basic";
        }
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
        Console.WriteLine("Service Package = "+GetServicePackage());
                

    }
}