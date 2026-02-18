using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal class SqlRepo
    {
        private string conncetionString = "Server = localhost; Database = AddressBookDB; Integrated Security = True; TrustServerCertificate = True;";

        public async Task SaveToDB(List<Contacts> contacts)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (SqlConnection Connect = new SqlConnection(conncetionString))
                    {
                        Connect.Open();
                        foreach (var contact in contacts)
                        {
                            string query = "INSERT INTO AddressBookTable (FirstName, LastName, Email, PhoneNumber, City, State, ZipCode) " +
                                               "VALUES (@First, @Last, @Email, @Phone, @City, @State, @Zip)";
                            using (SqlCommand cmd = new SqlCommand(query, Connect))
                            {
                                cmd.Parameters.AddWithValue("@First", contact.FirstName);
                                cmd.Parameters.AddWithValue("@Last", contact.LastName);
                                cmd.Parameters.AddWithValue("@Email", contact.Email);
                                cmd.Parameters.AddWithValue("@Phone", contact.PhoneNumber);
                                cmd.Parameters.AddWithValue("@City", contact.City);
                                cmd.Parameters.AddWithValue("@State", contact.State);
                                cmd.Parameters.AddWithValue("@Zip", contact.ZipCode);

                                cmd.ExecuteNonQuery();

                            }
                        }
                        Console.WriteLine("Data saved to DB");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error = " + ex.Message);
                }

            });
        }
    }
}
