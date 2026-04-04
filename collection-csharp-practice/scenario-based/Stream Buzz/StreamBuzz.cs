using System;
using System.Collections.Generic;

namespace BridgeLabzTraining.Stream_Buzz
{
    internal class StreamBuzz
    {
        public static void Main(string[] args)
        {
            // Initializing: Load existing data from file
            Creator.LoadFromJson();
            Creator manager = new Creator();
            bool running = true;

            Console.WriteLine("Welcome to StreamBuzz Engagement Tracker!");

            while (running)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Posts (Threshold)");
                Console.WriteLine("3. Calculate Overall Average Likes");
                Console.WriteLine("4. Export Report to CSV");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                switch (choice)
                {
                    case 1:
                        Creator newCreator = new Creator();
                        Console.Write("Enter Creator Name: ");
                        newCreator.CreatorName = Console.ReadLine();
                        newCreator.WeeklyLikes = new double[4];

                        for (int i = 0; i < 4; i++)
                        {
                            Console.Write($"Enter likes for Week {i + 1}: ");
                            newCreator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                        }

                        manager.RegisterCreator(newCreator);
                        Console.WriteLine("Successfully registered and saved to JSON!");
                        break;

                    case 2:
                        Console.Write("Enter like threshold: ");
                        double threshold = Convert.ToDouble(Console.ReadLine());
                        var topPosts = manager.GetTopPostCounts(threshold);

                        if (topPosts.Count == 0)
                            Console.WriteLine("No posts met the threshold.");
                        else
                            foreach (var item in topPosts) Console.WriteLine($"{item.Key}: {item.Value} top posts");
                        break;

                    case 3:
                        Console.WriteLine($"Overall Average: {manager.CalculateAverageLikes():F2}");
                        break;

                    case 4:
                        Creator.ExportToCsv("EngagementReport.csv");
                        Console.WriteLine("Report exported to 'EngagementReport.csv'");
                        break;

                    case 5:
                        Console.WriteLine("Saving data... Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}