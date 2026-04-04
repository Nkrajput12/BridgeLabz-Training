using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema; 
using System;

public class ValidateJson
{
    public static void Main()
    {
        string schemaJson = @"{
            'type': 'object',
            'properties': {
                'name': {'type': 'string'},
                'age': {'type': 'integer', 'minimum': 18}
            },
            'required': ['name', 'age']
        }";

        JSchema schema = JSchema.Parse(schemaJson);
        JObject user = JObject.Parse("{ 'name': 'Bob', 'age': 25 }");

        bool isValid = user.IsValid(schema, out IList<string> messages);
        Console.WriteLine("Is Valid: " + isValid);
    }
}