//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Reflection;
//using System.Dynamic;
//namespace BridgeLabzTraining.csharp_annotations_and_reflection.csharp_reflection
//{
//    public class Configuration
//    {
//        public static string AppName = "MyApplication";
//        public static void PrintApp() => Console.WriteLine($"Application Name: {AppName}");
//    }
//    internal class ModifyStaticField
//    {
//        public static void Main()
//        {
//            Type config = typeof(Configuration);

//            FieldInfo fieldInfo = config.GetField("AppName", BindingFlags.Public | BindingFlags.Static);

//            Configuration.PrintApp(); //before modification
//            if (fieldInfo != null)
//            {
//                Console.WriteLine("Modifing");
//                // Modify the static field value
//                Console.WriteLine("Enter name");
//                string name = Console.ReadLine();
//                fieldInfo.SetValue(null,name);
//            }

//            // Call the PrintApp method to see the change
//            Configuration.PrintApp(); //after modification
//        }
//    }
//}
