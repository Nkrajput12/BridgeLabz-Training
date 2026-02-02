using Newtonsoft.Json.Linq;
using System;

public class ExtractAndMerge
{
    public static void Main()
    {
        // 1.3 Extract specific fields
        string rawJson = "{ 'name': 'John Doe', 'email': 'john@example.com', 'age': 30 }";
        JObject player = JObject.Parse(rawJson);
        Console.WriteLine($"Name: {player["name"]}, Email: {player["email"]}");

        // 1.4 Merge Two JSON Objects
        JObject settings = JObject.Parse("{ 'Theme': 'Dark', 'Notifications': true }");
        JObject userProfile = JObject.Parse("{ 'Username': 'Ghost', 'Theme': 'Light' }");

        settings.Merge(userProfile, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
        Console.WriteLine("\nMerged Settings (User overrides): " + settings.ToString(Newtonsoft.Json.Formatting.None));
    }
}