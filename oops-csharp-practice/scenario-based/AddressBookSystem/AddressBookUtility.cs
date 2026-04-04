using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BridgeLabzTraining.AddressBookSystem
{
    public class AddressBookUtility : IAddressBook
    {
        Contacts[] contact = new Contacts[50]; //contact array with size 50
        int contactCount = 0; //track the number of contact


        //method use to add Books-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void AddContact()
        {
            if (contactCount >= contact.Length) //if contact count is equal to 50 or not
            {
                Console.WriteLine("Size Full");
            }
            else
            {
                //takig inputs
                Console.Write("Enter First Name: ");
                string fName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lName = Console.ReadLine();

                Contacts person = new Contacts { FirstName = fName, LastName = lName }; //temporary object to check for duplicate

                //  Use the Equals method to check the array
                for (int i = 0; i < contactCount; i++)
                {
                    if (contact[i].Equals(person)) //ensure there is no duplicate
                    {
                        Console.WriteLine("\n--- Error: This person already exists in this Address Book! ---");
                        return;
                    }
                }
                
                //if there is no duplicate countinue taking inputs
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

                contact[contactCount++] = person; //save the object to the array
                Console.WriteLine("\n--------New Contact Added Successfully---------");
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
                    //give choice to user what it want to edit
                    Console.WriteLine("Press 1 to edit Name");
                    Console.WriteLine("Press 2 to edit Email");
                    Console.WriteLine("Press 3 to edit Phone Number");
                    Console.WriteLine("Press 4 to edit address");
                    Console.WriteLine("Press 5 to exit");
                    Console.Write("Input here: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        //edit name
                        case 1:
                            Console.Write("Enter First Name: ");
                            contact[editIndex].FirstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            contact[editIndex].LastName = Console.ReadLine();
                            break;
                            //edit email
                        case 2:
                            Console.Write("Enter Email: ");
                            contact[editIndex].Email = Console.ReadLine();
                            break;
                            //edit phone number
                        case 3:
                            Console.Write("Enter Phone Number: ");
                            contact[editIndex].PhoneNumber = Console.ReadLine();
                            break;
                            //edit address
                        case 4:
                            Console.Write("Enter City: ");
                            contact[editIndex].City = Console.ReadLine();
                            Console.Write("Enter State: ");
                            contact[editIndex].State = Console.ReadLine();
                            Console.Write("Enter Zip Code: ");
                            contact[editIndex].ZipCode = int.Parse(Console.ReadLine());
                            break;
                            //for exit
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
            else // if contact does't exist
            {
                Console.WriteLine("---------Contact Not found-----------");
            }

        }

        //this method is to delete the contact details--------------------------------------------------------------------------------------------------------
        public void DeleteContact()
        {
            if (contactCount == 0) //check for address book is empty or not
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
            if (deleteIndex == -1) //if contact not found
            {
                Console.WriteLine("!!!Contact Not Found!!!");

                return;
            }
            if (contactCount == 1) //ther is only one contact contact exist
            {
                contact[0] = null;
                contactCount--;
                Console.WriteLine("-------Contact Delete Successfully-------");
                return;
            }
            for (int i = deleteIndex; i < contactCount - 1; i++) //loop for shifting the contact upword
            {
                contact[i] = contact[i + 1];

            }
            contact[contactCount - 1] = null; //delete the last contact
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

        // Inside AddressBookUtility.cs
        public bool SearchAndDisplayByLocation(string location, bool isCity)
        {
            bool foundInThisBook = false;
            for (int i = 0; i < contactCount; i++)
            {
                // Determine if we are checking the City or State property
                string checkValue = isCity ? contact[i].City : contact[i].State;

                // Check if value matches
                if (checkValue != null && checkValue.ToLower() == location.ToLower())
                {
                    if (!foundInThisBook)
                    {
                        // Print this only once when the first match in a book is found
                        foundInThisBook = true;
                    }
                    Console.WriteLine($"- {contact[i].FirstName} {contact[i].LastName}");
                }
            }
            return foundInThisBook;
        }


    }
}
