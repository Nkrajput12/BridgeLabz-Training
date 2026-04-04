using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BridgeLabzTraining.Stream_Buzz
{
    public class Creator
    {
        // Properties
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }

        // Static board to hold all data in memory
        public static List<Creator> EngagementBoard = new List<Creator>();
        private static string jsonPath = "engagement_data.json";

        // Register creator and save to JSON
        public void RegisterCreator(Creator record)
        {
            EngagementBoard.Add(record);
            SaveToJson();
        }

        // Save current board to JSON file
        public static void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(EngagementBoard, Formatting.Indented);
            File.WriteAllText(jsonPath, json);
        }

        // Load board from JSON file
        public static void LoadFromJson()
        {
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                EngagementBoard = JsonConvert.DeserializeObject<List<Creator>>(json) ?? new List<Creator>();
            }
        }

        // Logic for Top Posts
        public Dictionary<string, int> GetTopPostCounts(double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var creator in EngagementBoard)
            {
                int count = creator.WeeklyLikes.Count(likes => likes >= likeThreshold);
                if (count > 0)
                {
                    // Handle potential duplicate names by checking key existence
                    if (!result.ContainsKey(creator.CreatorName))
                        result.Add(creator.CreatorName, count);
                }
            }
            return result;
        }

        // Logic for Average
        public double CalculateAverageLikes()
        {
            double sum = EngagementBoard.Sum(c => c.WeeklyLikes.Sum());
            int totalWeeks = EngagementBoard.Count * 4;
            return totalWeeks == 0 ? 0 : sum / totalWeeks;
        }

        // Export data to CSV format
        public static void ExportToCsv(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("CreatorName,Week1,Week2,Week3,Week4");
                foreach (var c in EngagementBoard)
                {
                    writer.WriteLine($"{c.CreatorName},{string.Join(",", c.WeeklyLikes)}");
                }
            }
        }
    }
}