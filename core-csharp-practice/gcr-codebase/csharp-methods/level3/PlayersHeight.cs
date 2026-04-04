using System;
class PlayersHeight
{
    //method for genrating random heights for 11 players
    public static int[] GenerateHeights()
    {
        Random rand = new Random();
        int[] heights = new int[11];
        for (int i = 0; i < 11; i++)
        {
            heights[i] = rand.Next(150, 250); // heights between 100 cm and 199 cm
        }
        return heights;
    }

    //method for sum the element present in the array
    public static double Sum(int[] height)
    {
        double sum = 0;
        for (int i = 0; i < height.Length; i++)
        {
            sum += height[i];
        }
        return sum;
    }

    //method for calculating mean height
    public static double MeanHeight(int[] heights)
    {
        double totalHeight = Sum(heights);
        return totalHeight / heights.Length;
    }

    //method for calculating shortest height
    public static int ShortestHeight(int[] heights)
    {
        int minHeight = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] < minHeight)
            {
                minHeight = heights[i];
            }
        }
        return minHeight;
    }

    //method for calculating tallest height
    public static int TallestHeight(int[] heights)
    {
        int maxHeight = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > maxHeight)
            {
                maxHeight = heights[i];
            }
        }
        return maxHeight;
    }

    public static void Main(string[] args)
    {
        //generate random heights for 11 players
        int[] heights = GenerateHeights();
        //display heights of players
        Console.WriteLine("Heights of players:");
        for (int i = 0; i < heights.Length; i++)
        {
            Console.WriteLine("Player " + (i + 1) + ": " + heights[i] + " cm");
        }
        //calculate and display mean, shortest and tallest heights
        double meanHeight = MeanHeight(heights);
        int shortestHeight = ShortestHeight(heights);
        int tallestHeight = TallestHeight(heights);

        //print results
        Console.WriteLine("Mean Height: " + meanHeight + " cm");
        Console.WriteLine("Shortest Height: " + shortestHeight + " cm");
        Console.WriteLine("Tallest Height: " + tallestHeight + " cm");
    }
}