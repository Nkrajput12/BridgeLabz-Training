using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_annotations_and_reflection.csharp_reflection
{


    // 1. Define a custom attribute

    public class AuthorAttribute : Attribute
    {
        public string Name { get; }
        public AuthorAttribute(string name) { Name = name; }
    }

    // 2. Apply the attribute to a class

    public class DataProcessor
    {
        public void Process() => Console.WriteLine("Processing...");
    }

    class Retriveattribute
    {
        static void Main()
        {
            Type t = typeof(DataProcessor);

            // 3. Retrieve the attribute using Reflection
            var authAttr = (AuthorAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorAttribute));

            if (authAttr != null)
            {
                Console.WriteLine($"Class: {t.Name}");
                Console.WriteLine($"Author: {authAttr.Name}");
            }
        }
    }
}
