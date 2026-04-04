using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_json
{
    internal class CsvToJson
    {
        public static void Main()
        {
            // Mock CSV data: ID,Name,Dept
            string csvData = "ID,Name,Dept\n1,Alice,IT\n2,Bob,HR";

            var lines = csvData.Split('\n');
            var headers = lines[0].Split(',');
            var list = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var entry = new Dictionary<string, string>();
                for (int j = 0; j < headers.Length; j++)
                {
                    entry[headers[j]] = values[j];
                }
                list.Add(entry);
            }

            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
