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

        public void EditContact()
        {
            if(contactCount == 0)
            {
                Console.WriteLine("!!Address book is empty!!");
                return;
            }
            Console.WriteLine("---------------Update Details----------------");
            Console.WriteLine("\nEnter Name of the person whose details you want to edit");
            Console.WriteLine("Enter First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string last = Console.ReadLine();
            int editIndex = -1;
            for(int i =  0; i < contactCount; i++)
            {
                if(contact[i].FirstName == first && contact[i].LastName == last)
                {
                    editIndex = i;
                }
            }

            if (editIndex != -1)
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Press 1 to edit Name");
                    Console.WriteLine("Press 2 to edit Email");
                    Console.WriteLine("Press 3 to edit Phone Number");
                    Console.WriteLine("Press 4 to edit address");
                    Console.WriteLine("Press 5 to exit");
                    Console.Write("Input here: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter First Name: ");
                            contact[editIndex].FirstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            contact[editIndex].LastName = Console.ReadLine();
                            break;

                        case 2:
                            Console.Write("Enter Email: ");
                            contact[editIndex].Email = Console.ReadLine();
                            break;

                        case 3:
                            Console.Write("Enter Phone Number: ");
                            contact[editIndex].PhoneNumber = Console.ReadLine();
                            break;

                        case 4:
                            Console.Write("Enter City: ");
                            contact[editIndex].City = Console.ReadLine();
                            Console.Write("Enter State: ");
                            contact[editIndex].State = Console.ReadLine();
                            Console.Write("Enter Zip Code: ");
                            contact[editIndex].ZipCode = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                Console.WriteLine("---------Contact Successfully Updated----------");
            }
            else
            {
                Console.WriteLine("---------Contact Not found-----------");
            }
                
        }


    }
}
