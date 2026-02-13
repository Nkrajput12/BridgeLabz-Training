using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MustNotBeEmptyAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class ValidRangeAttribute : Attribute
    {
        public int Min { get; } = 1;
        public int Max { get; } = 3;
    }

    public abstract class Notification
    {
        [Required]
        public string Id { get; set; }

        [MustNotBeEmpty]
        public string Recipient { get; set; }

        [MustNotBeEmpty]
        public string Message { get; set; }

        [ValidRange]
        public int Priority { get; set; }

        public DateTime CreationTime { get; set; }

        public abstract string Type { get; }

        public string status { get; set; } = "Pending";

    }


    public class Email : Notification
    {
        public override string Type => "Email";
        public Email()
        {
            base.CreationTime = DateTime.Now;
        }
    }

    public class Sms : Notification
    {
        public override string Type => "SMS";
        public Sms()
        {
            base.CreationTime = DateTime.Now;
        }
    }

    public class NotificationManager
    {
        public void Validate(Notification n)
        {
            var allProperty = n.GetType().GetProperties();

            foreach (var property in allProperty)
            {
                if (property.IsDefined(typeof(MustNotBeEmptyAttribute), false))
                {
                    string content = (string)property.GetValue(n);

                    //var attribute = property.GetCustomAttributes<ValidRangeAttribute>();

                    if (string.IsNullOrWhiteSpace(content))
                    {
                        throw new Exception($"{property.Name} is Empty! pls fill it");
                    }

                }
                if (property.IsDefined(typeof(ValidRangeAttribute), false))
                {
                    var attribute = property.GetCustomAttribute<ValidRangeAttribute>();
                    int val = (int)property.GetValue(n);

                    if (val > attribute.Max || val < attribute.Min)
                    {
                        throw new Exception($"{property.Name} must be in valid Range 1 - 3");
                    }
                }
                if (property.IsDefined(typeof(RequiredAttribute), false)) 
                {
                    string content = (string)property.GetValue(n);

                    if (string.IsNullOrWhiteSpace(content))
                    {
                        throw new Exception($"{property.Name} is Empty! pls fill it");
                    }
                }

            }

        }

        public async Task ProcessTask(Notification n)
        {
            n.status = "Processing....";
            await Task.Delay(30000);
            n.status = "Sent";
            Console.WriteLine($"{n.Type} with ID {n.Id} is delivered successfully.....");

        }
    }

    public class Menu
    {
        List<Notification> list = new List<Notification>();
        NotificationManager manager = new NotificationManager();
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Send email | 2. Send SMS | 3. Check ALl Status | 4. exit");
                string choice = Console.ReadLine();

                if (choice == "4") exit = true;
                else if (choice == "3") DisplayLog();
                else
                    try
                    {
                        Notification create = (choice == "1") ? new Email() : new Sms();

                        Console.Write("Enter Id: ");
                        create.Id = Console.ReadLine();

                        Console.Write("Enter Recipent: ");
                        create.Recipient = Console.ReadLine();

                        Console.WriteLine("Enter Message: ");
                        create.Message = Console.ReadLine();

                        Console.Write("Assign Priority(1 - 3): ");
                        create.Priority = Convert.ToInt32(Console.ReadLine());

                        manager.Validate(create);
                        list.Add(create);
                        Task.Run(() => manager.ProcessTask(create));

                        Console.WriteLine("Notification accept and in processing");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

            }

        }

        public void DisplayLog()
        {
            Console.WriteLine("   ID   |   Recipient  | Status  |  Type   ");
            foreach (Notification n in list)
            {
                Console.WriteLine($" {n.Id}  |   {n.Recipient}  | {n.status}  |   {n.Type}");
            }
        }
    }

    public class Programme
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
