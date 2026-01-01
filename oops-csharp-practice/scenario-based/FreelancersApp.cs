using System;
class FreelancersApp
{
    //main method
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the details");
        string details = Console.ReadLine();  //taking user input in format task - xxxx INR,task2...............

        //declare string array to store a particulat task with details
        string[] task = details.Split(','); //split details from ','
        Console.WriteLine("--Invoice Details--");
        
        FreelancersApp obj = new FreelancersApp(); //object declaration
        obj.ShowDetails(task); //call method to show task details
        obj.Total(task); // method to display total amount

    }
    
    //method to show invoice details
    void ShowDetails(string[] task)
    {
        for(int i = 0; i < task.Length; i++)
        {
            Console.WriteLine((i+1) + ": " + task[i].Trim()); //trim space and print each task with serial number
        }
    }


    //method to split the amount and calculate & return the total amount
    void Total(string[] task)
    {
        
        double sum = 0; 
        double totalAmount = 0;
        for(int i =0; i < task.Length; i++) //loop run until task
        {
            string[] part = task[i].Split('-'); //split the text by '-' and store in part string array
           
            sum = Convert.ToDouble(part[1].Replace("INR" , "" ).Trim()); //replace INR with null and trim spaces from part[1] and convert to double

            totalAmount += sum; // totalamount increase by sum
        }

        Console.WriteLine("Total Amount = " + totalAmount+" INR"); //display details
    }
}
