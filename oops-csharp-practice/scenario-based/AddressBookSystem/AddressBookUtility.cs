using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    public class AddressBookUtility : Contacts
    {
        Contacts[] contact = new Contacts[50];
        int contactCount = 0;

        public void AddContact()
        {
            if (contactCount >= contact.Length - 1)
            {
                Console.WriteLine("Size Full");
            }
            else
            {
                Contacts person = new Contacts();
                Console.Write("Enter First Name: ");
                person.FirstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                person.LastName = Console.ReadLine();
                Console.Write("Enter Email: ");
                person.Email = Console.ReadLine();
                Console.Write("Enter Phone Number: ");
                person.PhoneNumber = Console.ReadLine();
                Console.Write("Enter City: ");
                person.City = Console.ReadLine();
                Console.Write("Enter State: ");
                person.State = Console.ReadLine();
                Console.Write("Enter Zip Code: ");
                person.ZipCode = int.Parse(Console.ReadLine());

                contact[contactCount++] = person;
                Console.WriteLine("--------New Contact Added Successfully---------");
            }
        }
    }
}
