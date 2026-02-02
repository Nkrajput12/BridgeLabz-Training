using Newtonsoft.Json.Linq;
using System;
using System.Linq;

public class KeyValueAndFilter
{
    public static void Main()
    {
        string jsonArray = @"[
            {'name': 'Alice', 'age': 30},
            {'name': 'Bob', 'age': 20},
            {'name': 'Charlie', 'age': 35}
        ]";

        JArray people = JArray.Parse(jsonArray);

        // 2.1 Print all keys and values for the first person
        Console.WriteLine("Keys and Values for first entry:");
        foreach (var property in ((JObject)people[0]).Properties())
        {
            Console.WriteLine($"{property.Name}: {property.Value}");
        }

        // 2.2 Filter Age > 25
        var adults = people.Where(p => (int)p["age"] > 25);
        Console.WriteLine("\nUsers older than 25:");
        foreach (var person in adults)
        {
            Console.WriteLine(person["name"]);
        }
    }
}