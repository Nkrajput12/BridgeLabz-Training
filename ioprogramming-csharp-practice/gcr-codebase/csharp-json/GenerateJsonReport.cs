using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_json
{
    public class UserRecord
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
    internal class GenerateJsonReport
    {
        public static void Main()
        {
            // Assume this list comes from a DB query (e.g., via Entity Framework or Dapper)
            var dbRecords = new List<UserRecord> {
            new UserRecord { Id = 101, Status = "Active" },
            new UserRecord { Id = 102, Status = "Pending" }
        };

            string report = JsonConvert.SerializeObject(dbRecords, Formatting.Indented);
            File.WriteAllText("Report.json", report);
            Console.WriteLine("Report.json generated successfully.");
        }
    }
}
