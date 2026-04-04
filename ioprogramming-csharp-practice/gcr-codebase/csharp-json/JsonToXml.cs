using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BridgeLabzTraining.csharp_json
{
    internal class JsonToXml
    {
        public static void Main()
        {
            string json = "{ 'Employee': { 'Name': 'James', 'Role': 'Dev' } }";

            // Note: JSON must have a single root object to convert to XML
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "Root");
            Console.WriteLine(doc.OuterXml);
        }
    }
}
