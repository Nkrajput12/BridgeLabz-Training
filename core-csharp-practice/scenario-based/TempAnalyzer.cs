using System;
class TempAnalyzer
{
    //main method
    public static void Main(string[] arge)
    {
        //declaring data of presvious 7 days
        float[,] temperatureData = new float[7, 24]
        {
        // Day 1
            { 10.2f, 8.9f, 7.9f, 7.2f, 7.0f, 7.2f, 7.9f, 8.9f, 10.2f, 11.8f, 13.5f, 15.2f, 16.8f, 18.1f, 19.1f, 19.8f, 20.0f, 19.8f, 19.1f, 18.1f, 16.8f, 15.2f, 13.5f, 11.8f },
    
        // Day 2:
             { 11.0f, 9.8f, 8.8f, 8.2f, 8.0f, 8.2f, 8.8f, 9.8f, 11.0f, 12.4f, 14.0f, 15.6f, 17.0f, 18.2f, 19.2f, 19.8f, 20.0f, 19.8f, 19.2f, 18.2f, 17.0f, 15.6f, 14.0f, 12.4f },
    
        // Day 3:
             { 13.5f, 12.5f, 11.7f, 11.2f, 11.0f, 11.2f, 11.7f, 12.5f, 13.5f, 14.7f, 16.0f, 17.3f, 18.5f, 19.5f, 20.3f, 20.8f, 21.0f, 20.8f, 20.3f, 19.5f, 18.5f, 17.3f, 16.0f, 14.7f },
    
         // Day 4:
             { 12.0f, 10.8f, 9.8f, 9.2f, 9.0f, 9.2f, 9.8f, 10.8f, 12.0f, 13.4f, 15.0f, 16.6f, 18.0f, 19.2f, 20.2f, 20.8f, 21.0f, 20.8f, 20.2f, 19.2f, 18.0f, 16.6f, 15.0f, 13.4f },
    
        // Day 5:
             { 10.8f, 9.6f, 8.7f, 8.2f, 8.0f, 8.2f, 8.7f, 9.6f, 10.8f, 12.1f, 13.5f, 14.9f, 16.2f, 17.4f, 18.3f, 18.8f, 19.0f, 18.8f, 18.3f, 17.4f, 16.2f, 14.9f, 13.5f, 12.1f },
    
        // Day 6:
            { 9.2f, 7.9f, 6.9f, 6.2f, 6.0f, 6.2f, 6.9f, 7.9f, 9.2f, 10.8f, 12.5f, 14.2f, 15.8f, 17.1f, 18.1f, 18.8f, 19.0f, 18.8f, 18.1f, 17.1f, 15.8f, 14.2f, 12.5f, 10.8f },
    
        // Day 7:
            { 10.0f, 8.8f, 7.8f, 7.2f, 7.0f, 7.2f, 7.8f, 8.8f, 10.0f, 11.4f, 13.0f, 14.6f, 16.0f, 17.2f, 18.2f, 18.8f, 19.0f, 18.8f, 18.2f, 17.2f, 16.0f, 14.6f, 13.0f, 11.4f }
        };

        TempAnalyzer obj = new TempAnalyzer(); //object 
        obj.Display(temperatureData); //call display method

    }


    //mehtod for display 
    void Display(float[,] temperatureData)
    {
        TempAnalyzer obj = new TempAnalyzer(); //object

        float[] average = obj.AverageTemp(temperatureData);
        while (true) //loop for choice (to make code menu driven)
        {
            Console.WriteLine("Press 1 to show Hottest day\tPress2 to show Coldest Day\tPress 3 to show average temperature per day\tPress 4 to Exit");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {

                case 1:
                   obj.HottestDay(average); //display the hottest day
                break;

                case 2:
                    obj.ColdestDay(average); //display the coldest day
                break;

                case 3:
                    for(int i  = 0; i < average.Length; i++)
                    {
                        Console.WriteLine("Average temperature of day "+(i+1)+" is = "+average[i]); //print the average temperature per day
                    }
                break;


                case 4:
                    Environment.Exit(0); //successfully terminate the code
                break;

                default:
                    Console.WriteLine("Invalid input"); // promt for user to show invalid input
                break;
            }
        }
    }
    //method for finding the average temperatue per day
    float[] AverageTemp(float[,] temperatureData)
    {
        float[] average = new float[7]; //delaclaring float array to store the average temperature per day
        for (int i = 0; i < temperatureData.GetLength(0); i++)
        {
            float sum = 0;
            for (int j = 0; j < temperatureData.GetLength(1); j++)
            {
               sum += temperatureData[i, j];   //sum tempratue day wise
            }
               average[i] = sum / 24; //store the average temperature day wise
        }
        return average;
    }

    //method to display the coldest day
    void ColdestDay(float[] average)
    {
        float minimum = average[0]; 
        int j = 0;
        for (int i = 0; i < average.Length; i++)
        {
            if (average[i] < minimum) //check for the minimum temperature
            {
               minimum = average[i]; //for minimum temperature
               j = i + 1; //for day
            }
        }

        Console.WriteLine("the coldest day is " + j + " with average temperature = " + minimum);
    }


    void HottestDay(float[] average)
    {
        float max = average[0];
        int j = 0;
        for (int i = 0; i < average.Length; i++)
        {
            if (average[i] > max) //check for the maximum temperature
            {
                max = average[i]; //store the maximum temperature
                j = i + 1; //day with the maximum temperature
            }
        }

        Console.WriteLine("the Hottest day is " + j + " with average temperature = " + max); //print results
    }
}

