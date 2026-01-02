using System;
class DistanceTracker
{
    //method to return the details of bus stop with km
    private string[,] Route() 
    {
        string[,] route =
        {
            {"Jhansi", "0" },
            {"Moth", "28" },
            {"Dabra" , "53"},
            {"Gwalior", "83" },
            {"Morena" , "133"},
            {"Dhaulpur" , "161"},
            {"kheragarh", "191" },   // Route for bus service
            {"Agra", "289" },
            {"Mathura", "347" },
            {"Vrindava", "359" },
            {"Baldev", "374" },
            {"Aligarh" , "399"},
            {"Gabhana", "447" },
            {"Meerut", "526" },
            {"Roorkee", "565" }

        };
        return route;
    }
    
    //method to ask details from passenger
    int Boarding(string[,] Route)
    {
        Console.WriteLine("Please enter your Boarding Location :"); //prompt user to write the boarding location
         string boarding = Console.ReadLine().ToLower(); // store user input after convert to lower case 


        
        for (int i = 0; i < Route.GetLength(0); i++) //loop to iterate the route
        {
            if (Route[i, 0].ToLower() == boarding) //check for the index number of the route
            {
                Console.WriteLine("Your input is successfully submit:");
               return i; // return i 
            }
            else //if user enter wrong input
            {
                Console.WriteLine("Wrong Location");
                Environment.Exit(1); // terminate the programme
            }
        }
        Console.WriteLine("Your input is successfully submit:");

        return 0;
      
    }

    //Method to return the destination index value
    int Destination(string[,] Route, int boarding)
    {

        for (int i = (boarding + 1); i < Route.GetLength(0); i++) //loop start form the next index of bording index
        {
            Console.WriteLine("Type yes if you want to Deboard at " + Route[i, 0]+" otherwise type No"); // promt user to ask if you want to deboard or not
            string response = Console.ReadLine().ToLower(); // user response yes or no
            if (response == "yes") // if user type yes
            {
                return i; // return the index value
            }
            else
            {
                Console.WriteLine("OK"); // if no simple say ok
            }


        }
        return Route.GetLength(0) - 1; // if user did not say yes att any location return the last stop
    }

    //method to calculate the distance
    int Distance(string[,] Route, int Boarding, int Destination)
    {
        int desti = Convert.ToInt32(Route[Destination, 1]); // convert string to integer and assign to veriable for destination

        int board = Convert.ToInt32(Route[Boarding, 1]); // same as above but for boading

        return desti - board; // subtract the boardingkm form destination and return it
    }

    //method to calculate the price 
    private double Price(int distance)
    {
        return distance * 5.5;
    }

    //method to display the full Routes
    void DisplayRoute(string[,] Route)
    {
        Console.WriteLine("-----------Route Details-----------");  
        Console.WriteLine("  Stop\tdistance");
        for(int i = 0; i < Route.GetLength(0)-1; i++)
        {
            Console.WriteLine((i+1)+". " + Route[i,0]+" " + Route[i,1]); // display stop and km from the intial location
        }
    }

    //Method to Display
    public void Display()
    {
        DistanceTracker ob = new DistanceTracker(); // creating object
        Console.WriteLine("-*-*-*-* Welcome to Bhanu Pratap Bus Service *-*-*-*-");
        string[,] route = ob.Route(); // get the route details
        ob.DisplayRoute(route);  // call method to display the route details
        int boarding = ob.Boarding(route); // call method to find the boarding index
        int destination = ob.Destination(route,boarding); //method to find the destination index
        int distance =  ob.Distance(route,boarding,destination); // calculate distance
        double price  = Price(distance); //calculate price

        Console.WriteLine("Total distance travel " + distance + "km and total ticket price = " + price + " INR");

    }

}
class User : DistanceTracker //subclass
{
    public static void Main(string[] args)
    {
        
        DistanceTracker obj = new DistanceTracker(); //creating object
        obj.Display(); //call display method

    }

}

