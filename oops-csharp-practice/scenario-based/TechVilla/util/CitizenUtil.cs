using System;

class CitizenUtil
{
    Citizen[] citizen = new Citizen[100];
    int citizenCount = 0;

    HealthcareService health = new HealthcareService();
    public void register()
    {
        try
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
        catch(InvalidAgeException ex){
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
    }


    public void Display()
    {
        for(int i = 0; i<citizenCount ;i++)
        {
        citizen[i].Display();
        }
    }
    public string NameFormat(string name)
    {
        return name.Trim();
    }

    public bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }


    public void SearchCitizen()
    {

        Console.Write($"Enter Name: ");
        string nameToFind = Console.ReadLine() ?? "";
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


    public void UpdateIncome()
    {
        Console.Write("Enter Id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter New Income: ");
        double newIncome = Convert.ToDouble(Console.ReadLine());

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

    public Citizen GetFirst()
    {
        return citizen[0];
    }

    public void BookHealthCare()
    {
        if(GetFirst() != null){
            Citizen c = GetFirst();

            health.BookService(c);

            health.PerformService();
        }
        else{
            Console.WriteLine("There is no citizen");
        }
    }

    public void CityStats(){
        health.TotalService();
    }
}