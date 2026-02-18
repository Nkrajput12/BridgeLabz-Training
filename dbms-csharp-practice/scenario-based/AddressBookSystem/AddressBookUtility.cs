using Newtonsoft.Json;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BridgeLabzTraining.AddressBookSystem
{
    public class AddressBookUtility : IAddressBook
    {
        
        private List<Contacts> contactList = new List<Contacts>();
        string txtfilepath = @"F:\BridgeLabzTraining\BridgeLabzTraining\AddressBookSystem\Contacts.txt";
        string csvfilepath = @"F:\BridgeLabzTraining\BridgeLabzTraining\AddressBookSystem\Contacts.csv";
        string jsonPath = @"F:\BridgeLabzTraining\BridgeLabzTraining\AddressBookSystem\db.json";

        private SqlRepo sql = new SqlRepo();
        private JsonServerRepository apiRepo = new JsonServerRepository();


        //Method to save data to the sql database------------------UC18----------------------------------------

        public async Task SaveToDb()
        {
            await sql.SaveToDB(contactList);
        }

        //Method to Sync with the json Server ------------------------UC16 & 17--------------------------------
        public async Task SyncWithJsonServer()
        {
            Console.WriteLine("\n--- Starting Remote Sync ---");
            
            await apiRepo.SaveToRemoteAsync(contactList);
            Console.WriteLine("--- Sync Completed ---");
        }

        public async Task WriteToJSONAsync()
        {
            await Task.Run(() =>
            {
                string json = JsonConvert.SerializeObject(contactList, Formatting.Indented);
                File.WriteAllText(jsonPath, json);
            });
            Console.WriteLine("JSON saved ");
        }

        //Method to write to json ------------------------------UC15--------------------------------------------
        //public void WriteToJSON()
        //{
        //    try
        //    {

        //        string jsonString = JsonConvert.SerializeObject(contactList, Formatting.Indented);


        //        File.WriteAllText("F:\\BridgeLabzTraining\\BridgeLabzTraining\\AddressBookSystem\\Contacts.json", jsonString);
        //        Console.WriteLine($"JSON Exported successfully ");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error writing JSON: " + ex.Message);
        //    }
        //}

        //Method to ReadFromJson --------------------------------UC15-------------------------------------------------
        public void ReadFromJSON()
        {
            try
            {
                if (!File.Exists(jsonPath))
                {
                    Console.WriteLine("JSON file not found.");
                    return;
                }

                string jsoninput = (string)File.ReadAllText(jsonPath);

                contactList = JsonConvert.DeserializeObject<List<Contacts>>(jsonPath) ?? contactList;

                Console.WriteLine("json added successfully");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading JSON: " + ex.Message);
            }
        }

        //Method to Write the contacts to csv----------------------------UC14-------------------------------------------

        public void WriteToCsv()
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(csvfilepath))
                {
                    foreach(var c in contactList)
                    {
                        sw.WriteLine($"{c.FirstName},{c.LastName},{c.Email},{c.PhoneNumber},{c.City},{c.State},{c.ZipCode}");
                    }
                }
                Console.WriteLine($"CSV Exported!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        //Method to Read the contacts from Csv file-------------------------------UC14-------------------------------------
        public void ReadFromCsv()
        {
            try
            {
                if (File.Exists(csvfilepath))
                {
                    contactList.Clear();
                    using(StreamReader sr = new StreamReader(csvfilepath))
                    {
                        string line;
                        while((line = sr.ReadLine()) != null)
                        {
                            string[] v = line.Split(',');
                            Contacts contact = new Contacts
                            {
                                FirstName = v[0],
                                LastName = v[1],
                                Email = v[2],
                                PhoneNumber = v[3],
                                City = v[4],
                                State = v[5],
                                ZipCode = int.Parse(v[6])
                            };
                            contactList.Add(contact);
                        }
                    }
                    Console.Write("Csv Imported");
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        //Method to Write the contacts to txt file-----------------------------UC13--------------------------------------
        public void WriteToFile()
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(txtfilepath))
                {
                    foreach(var contact in contactList)
                    {
                        sw.WriteLine($"{contact.FirstName},{contact.LastName},{contact.Email},{contact.PhoneNumber},{contact.City},{contact.State},{contact.ZipCode}");

                    }
                }
                Console.WriteLine("Data saved!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Method to Read from File-----------------------------------UC13------------------------------------------
        public void ReadFromFile()
        {
            try
            {
                if (File.Exists(txtfilepath))
                {
                    contactList.Clear();
                    string[] lines = File.ReadAllLines(txtfilepath);
                    foreach(string line in lines)
                    {
                        string[] data = line.Split(',');
                        Contacts contact = new Contacts
                        {
                            FirstName = data[0],
                            LastName = data[1],
                            Email = data[2],
                            PhoneNumber = data[3],
                            City = data[4],
                            State = data[5],
                            ZipCode = int.Parse(data[6])
                        };
                        contactList.Add(contact);
                    }
                    Console.WriteLine("Data read successfully");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Method to add Contact ----------------------------------------------------------------------------------
        public void AddContact()
        {
            // Taking inputs
            Console.Write("Enter First Name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lName = Console.ReadLine();

            // UC 7: Duplicate Check using Collection Method 
            
            if (contactList.Any(c => c.FirstName.ToLower() == fName.ToLower() && c.LastName.ToLower() == lName.ToLower()))
            {
                Console.WriteLine("\n--- Error: This person already exists in this Address Book! ---");
                return;
            }

            Contacts person = new Contacts { FirstName = fName, LastName = lName };

            Console.Write("Enter Email: ");
            person.Email = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            person.PhoneNumber = Console.ReadLine();
            Console.Write("Enter City: ");
            person.City = Console.ReadLine();
            Console.Write("Enter State: ");
            person.State = Console.ReadLine();
            Console.Write("Enter Zip Code: ");
            if (int.TryParse(Console.ReadLine(), out int zip)) person.ZipCode = zip;

            // UC 9: Map person to Global Dictionaries via Manager
            AddressBookManager manager = new AddressBookManager();
            manager.MapPersonToLocation(person);

            // Save to the list
            contactList.Add(person);
            Console.WriteLine("\n--------New Contact Added Successfully---------");
        }

        // Method to edit contact details -------------------------------------------------------------------------
        public void EditContact()
        {
            
            if (contactList.Count == 0)
            {
                Console.WriteLine("!!Address book is empty!!");
                return;
            }

            Console.WriteLine("---------------Update Details Module----------------");
            Console.WriteLine("\nEnter Name of the person whose details you want to edit");
            Console.Write("Enter First Name: ");
            string first = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string last = Console.ReadLine();

            int editIndex = -1;

            
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].FirstName.ToLower() == first.ToLower() &&
                    contactList[i].LastName.ToLower() == last.ToLower())
                {
                    editIndex = i;
                    break;
                }
            }

            if (editIndex != -1)
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n1. Edit Name | 2. Edit Email | 3. Edit Phone | 4. Edit Address | 5. Exit");
                    Console.Write("Input here: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter First Name: ");
                            contactList[editIndex].FirstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            contactList[editIndex].LastName = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter Email: ");
                            contactList[editIndex].Email = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter Phone: ");
                            contactList[editIndex].PhoneNumber = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Enter City: ");
                            contactList[editIndex].City = Console.ReadLine();
                            Console.Write("Enter State: ");
                            contactList[editIndex].State = Console.ReadLine();
                            Console.Write("Enter Zip Code: ");
                            contactList[editIndex].ZipCode = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            exit = true;
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

        // Method to delete contact details -----------------------------------------------------------------------
        public void DeleteContact()
        {
            if (contactList.Count == 0) return;

            Console.Write("First Name: ");
            string first = Console.ReadLine();
            Console.Write("Last Name: ");
            string last = Console.ReadLine();

            int deleteIndex = -1;
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].FirstName.ToLower() == first.ToLower() &&
                    contactList[i].LastName.ToLower() == last.ToLower())
                {
                    deleteIndex = i;
                    break;
                }
            }

            if (deleteIndex != -1)
            {
                // List handles the "shifting" automatically when we call RemoveAt
                contactList.RemoveAt(deleteIndex);
                Console.WriteLine("-------Contact Delete Successfully-------");
            }
            else
            {
                Console.WriteLine("!!!Contact Not Found!!!");
            }
        }

        // Method to display all contact details ------------------------------------------------------------------
        public void Display()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("No Contact found");
                return;
            }
            int i = 1;
            foreach (var contact in contactList)
            {
                Console.WriteLine($"-------Contact no {i++}-------");
                Console.WriteLine(contact.ToString());
                Console.WriteLine("------------------------------------------");
            }
        }

        // Method to search by location ---------------------------------------------------------------------------
        public bool SearchAndDisplayByLocation(string location, bool isCity)
        {
            bool found = false;
            for (int i = 0; i < contactList.Count; i++)
            {
                string check = isCity ? contactList[i].City : contactList[i].State;
                if (check != null && check.ToLower() == location.ToLower())
                {
                    Console.WriteLine($"- {contactList[i].FirstName} {contactList[i].LastName}");
                    found = true;
                }
            }
            return found;
        }

        //Method to Sort Contact by Name ------------------------------UC11-----------------------------------------
        public void SortByName()
        {
            if (contactList.Count == 0) return;

            
            contactList = contactList.OrderBy(c => c.FirstName)
                                     .ThenBy(c => c.LastName)
                                     .ToList();

            Console.WriteLine("\n--- Sorted Alphabetically by Name ---");
            Display();
        }

        //Method to sort by Location ---------------------------------UC12-------------------------------------------
        public void SortByLocation()
        {
            if (contactList.Count == 0)
            {
                Console.WriteLine("Address Book is empty.");
                return;
            }

            Console.WriteLine("\n--- Sort Entries By ---");
            Console.WriteLine("1. City\n2. State\n3. Zip Code");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Sort by City Alphabetically
                    contactList = contactList.OrderBy(c => c.City).ToList();
                    Console.WriteLine("\nSorted by City:");
                    break;
                case "2":
                    // Sort by State Alphabetically
                    contactList = contactList.OrderBy(c => c.State).ToList();
                    Console.WriteLine("\nSorted by State:");
                    break;
                case "3":
                    // Sort by Zip Code Numerically
                    contactList = contactList.OrderBy(c => c.ZipCode).ToList();
                    Console.WriteLine("\nSorted by Zip Code:");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to menu.");
                    return;
            }

            
            Display();
        }


    }
}