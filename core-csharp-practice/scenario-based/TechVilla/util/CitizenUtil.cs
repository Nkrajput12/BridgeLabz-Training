using System;

class CitizenUtil
{
    Citizen[] citizen = new Citizen[5];
    int citizenCount = 0;

    public void register()
    {
        Console.WriteLine("How many people you want to Register");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 0;i<n;i++)
        {
            Console.Write("Enter Name: ");
            string rawname = Console.ReadLine() ?? "";
            string name = NameFormat(rawname);
            
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if(age < 1){
                Console.WriteLine("Invalid Age");
                i--;
                continue;
            }
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            
            if(!(IsValidEmail(email)))
            {
                Console.WriteLine("Invalid Email");
                i--;
                continue;
            }

            Console.Write("Income: ");
            double income = Convert.ToDouble(Console.ReadLine());
            Console.Write("Residency years: ");
            int year = Convert.ToInt32(Console.ReadLine());

            int id = citizenCount++;

            citizen[id] = new Citizen(id,name,email,age,income,year);

            Console.WriteLine("Citizen Added successfully");
        }
        Console.WriteLine(" ALL Citizens added successfully");

        int[,] cityMap = new int[5,3];
        cityMap[0,0] = citizenCount;
        Console.WriteLine("Citizen Mapped");
    }

    public string NameFormat(string name)
    {
        return name.Trim();
    }

    public bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }


public void SearchCitizen(string nameToFind)
{
    Console.WriteLine($"\nSearching for: {nameToFind}...");
    bool found = false;
    for (int i = 0; i < citizenCount; i++)
    {
        
        if (citizen[i].Name.Contains(nameToFind, StringComparison.OrdinalIgnoreCase))
        {
            citizen[i].Display();
            found = true;
        }
    }
    if (!found) Console.WriteLine("Citizen not found.");
}


public void UpdateIncome(int id, double newIncome)
{
    if (id >= 0 && id <= citizenCount)
    {
        
        citizen[id].Income = newIncome;
        Console.WriteLine($"Profile {id} updated successfully.");
    }
    else
    {
        Console.WriteLine("Invalid Citizen ID.");
    }
}
}