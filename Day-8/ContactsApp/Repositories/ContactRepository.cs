using ContactsApp.Models;
using Microsoft.Data.SqlClient;

namespace ContactsApp.Repositories;

// Repository talks directly to SQL Server using ADO.NET
public class ContactRepository
{
    private readonly string _connectionString;

    public ContactRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // ── GET ALL ───────────────────────────────────────────────────────────────
    public List<Contact> GetAll()
    {
        var contacts = new List<Contact>();

        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        var cmd = new SqlCommand("SELECT * FROM Contacts", conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            contacts.Add(MapContact(reader));
        }

        return contacts;
    }

    // ── GET BY ID ─────────────────────────────────────────────────────────────
    public Contact? GetById(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        var cmd = new SqlCommand("SELECT * FROM Contacts WHERE Id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);

        using var reader = cmd.ExecuteReader();

        return reader.Read() ? MapContact(reader) : null;
    }

    // ── ADD ───────────────────────────────────────────────────────────────────
    public int Add(Contact contact)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        var sql = @"INSERT INTO Contacts (FirstName, LastName, Email, PhoneNumber)
                    VALUES (@FirstName, @LastName, @Email, @PhoneNumber);
                    SELECT SCOPE_IDENTITY();";

        var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@FirstName",   contact.FirstName);
        cmd.Parameters.AddWithValue("@LastName",    contact.LastName);
        cmd.Parameters.AddWithValue("@Email",       contact.Email);
        cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);

        // Returns the new identity Id
        var newId = Convert.ToInt32(cmd.ExecuteScalar());
        return newId;
    }

    // ── UPDATE ────────────────────────────────────────────────────────────────
    public bool Update(Contact contact)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        var sql = @"UPDATE Contacts
                    SET FirstName   = @FirstName,
                        LastName    = @LastName,
                        Email       = @Email,
                        PhoneNumber = @PhoneNumber
                    WHERE Id = @Id";

        var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id",          contact.Id);
        cmd.Parameters.AddWithValue("@FirstName",   contact.FirstName);
        cmd.Parameters.AddWithValue("@LastName",    contact.LastName);
        cmd.Parameters.AddWithValue("@Email",       contact.Email);
        cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);

        int rowsAffected = cmd.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    // ── DELETE ────────────────────────────────────────────────────────────────
    public bool Delete(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        var cmd = new SqlCommand("DELETE FROM Contacts WHERE Id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        return rowsAffected > 0;
    }

    // ── HELPER ────────────────────────────────────────────────────────────────
    private static Contact MapContact(SqlDataReader reader)
    {
        return new Contact
        {
            Id          = (int)reader["Id"],
            FirstName   = (string)reader["FirstName"],
            LastName    = (string)reader["LastName"],
            Email       = (string)reader["Email"],
            PhoneNumber = (string)reader["PhoneNumber"],
            CreatedAt   = (DateTime)reader["CreatedAt"]
        };
    }
}
