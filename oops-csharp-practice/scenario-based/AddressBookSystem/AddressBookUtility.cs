using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    public class AddressBookUtility : IAddressBook
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
        //this method is to edit the contact details---------------------------------------------------------------------------------------------------------
        public void EditContact()
        {
            if (contactCount == 0) //check is their is a contact in contact book or not
            {
                Console.WriteLine("!!Address book is empty!!");
                return;
            }
            Console.WriteLine("---------------Update Details Module----------------");
            Console.WriteLine("\nEnter Name of the person whose details you want to edit");
            //taking input for first and last name
            Console.WriteLine("Enter First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string last = Console.ReadLine();
            int editIndex = -1; //the is use to store the index value of the contact we want to edit
            for (int i = 0; i < contactCount; i++) //loop run until the number of contacts
            {
                if (contact[i].FirstName.ToLower() == first.ToLower() && contact[i].LastName.ToLower() == last.ToLower()) //check for the input name match to other contact
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

        //this method is to delete the contact details--------------------------------------------------------------------------------------------------------
        public void DeleteContact()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("Address book is empty");
                return;
            }
            Console.WriteLine("------------Delete Details Module-------------");
            Console.WriteLine("Enter the Name of the person whose details you want to delete");
            Console.Write("First Name: ");
            string first = Console.ReadLine();
            Console.Write("Last Name :");
            string last = Console.ReadLine();

            int deleteIndex = -1; //the is use to store the index value of the contact we want to delete
            for (int i = 0; i < contactCount; i++) //loop run until the number of contacts
            {
                if (contact[i].FirstName.ToLower() == first.ToLower() && contact[i].LastName.ToLower() == last.ToLower()) //check for the input name match to other contact
                {
                    deleteIndex = i;
                }
            }
            if (deleteIndex == -1)
            {
                Console.WriteLine("!!!Contact Not Found!!!");

                return;
            }
            if (contactCount == 1)
            {
                contact[0] = null;
                contactCount--;
                Console.WriteLine("-------Contact Delete Successfully-------");
                return;
            }
            for (int i = deleteIndex; i < contactCount - 1; i++)
            {
                contact[i] = contact[i + 1];

            }
            contact[contactCount - 1] = null;
            contactCount--;

            Console.WriteLine("---------Contact Delete Successfully---------");


        }

        //method is to display the all contact details--------------------------------------------------------------------------------------------------------
        public void Display()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No Contact found");
                return;
            }
            for (int i = 0; i < contactCount; i++)
            {
                Console.WriteLine("-------Contact no " + (i + 1) + "-------");
                Console.WriteLine(contact[i].ToString());
                Console.WriteLine("------------------------------------------");
            }
        }


    }
}
