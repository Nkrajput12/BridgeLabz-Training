using System;
class CallLogs
{
    //declare the variable
    public string PhoneNumber;
    public string Messsage;
    public DateTime TimeStamp;

    //intiallize the value of the variables
    public CallLogs(string phoneNumber, string messsage, DateTime timeStamp)
    {
        this.PhoneNumber = phoneNumber;
        this.Messsage = messsage;
        this.TimeStamp = timeStamp;
    }

    //display method to display the log details
    public void Display()
    {
        Console.WriteLine("Message = "+Messsage+"\nPhone Number = "+PhoneNumber+"\nTime = "+TimeStamp);
    }
}

//class for manage the log
public class CallLogManager
{
    private CallLogs[] logs; //intiallize the array for store the object of call logs
    private int Counter = 0; //track the number of call logs 

    public CallLogManager(int size)
    {
        logs = new CallLogs[size]; //declaring the size of the call log manager
    }

    //method to add call logs
    public void AddLog(string phoneNumber, string message,DateTime TimeStamp)
    {
        if (Counter < logs.Length) //check for the log length 
        {
            logs[Counter] = new CallLogs(phoneNumber, message, TimeStamp); //create a object of that log and store in logs array
            Counter++;
        }
        else
        {
            Console.WriteLine("Call manager storage full"); //display this msg if the log is full
        }
    }

    //method to search the log by the keywords
    public void Search(string str)
    {
        Console.WriteLine("--------Searching for the Log--------");
        for(int i = 0; i < Counter; i++)
        {
            if (logs[i].Messsage.Contains(str)) //check if message contains the str
            {
                logs[i].Display();
            }
            
        }
    }

    //method to fiter log by time
    public void Filter(DateTime start, DateTime end)
    {
        Console.WriteLine("--------Filter the Log by time---------");
        for(int i = 0; i < Counter; i++) //loop run till counter
        {
            if (logs[i].TimeStamp >= start && logs[i].TimeStamp <= end) //filter the timestamp between start and end
            {
                logs[i].Display();
            }
        }
    }

    
}

class User
{
    public static void Main(string[] args)
    {
        CallLogManager log = new CallLogManager(10); //creating object for call log manager class

        // Add logs
        log.AddLog("99717584580","Internet slow speed",DateTime.Now);
        log.AddLog("7548963215", "Sab badiya bhai", DateTime.Now);
        log.AddLog("7842153698","Ram Ram bhai kya hal chal", DateTime.Now);
        log.AddLog("7415236485", "sab thik thak", DateTime.Now);

        log.Search("Ram"); //call method to search the log by keyword

        DateTime start = DateTime.Now.AddSeconds(-5); //in start date assign the time -5 second
        DateTime end = DateTime.Now; //assign the current time
        log.Filter(start, end); //display log details from start to end


    }
}
