using System;

public class Menu{

    CitizenUtil util = new CitizenUtil();

    public void Run(){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Press 1: Register");
            Console.WriteLine("Press 2: Display All");
            Console.WriteLine("Press 3: Search citizen");
            Console.WriteLine("Press 4: update Income");
            Console.WriteLine("Press 5: Book Health care Service");
            Console.WriteLine("Press 6: View City Statistics");
            Console.WriteLine("Press 7: Exit");
            string choice = Console.ReadLine()??"";

            switch(choice){
                case "1": util.register(); break;
                case "2": util.Display(); break;
                case "3": util.SearchCitizen(); break;
                case "4": util.UpdateIncome(); break;
                case "5": util.BookHealthCare(); break;
                case "6": util.CityStats(); break;
                case "7": exit = true; break;
                default:
                Console.WriteLine("Invalid Input");
                break;
                
            }
            
        }
    }
}