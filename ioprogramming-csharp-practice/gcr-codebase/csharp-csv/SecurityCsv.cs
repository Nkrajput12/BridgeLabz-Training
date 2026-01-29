using System;
using System.IO;
using System.Text;

class SecurityCsv
{
    static string Encrypt(string text) => Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    static string Decrypt(string cipher) => Encoding.UTF8.GetString(Convert.FromBase64String(cipher));

    static void Main()
    {
        string path = "secure_data.csv";

        // Writing Encrypted
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine("ID,Email,Salary");
            sw.WriteLine($"1,{Encrypt("user@test.com")},{Encrypt("50000")}");
        }

        // Reading and Decrypting
        using (StreamReader sr = new StreamReader(path))
        {
            sr.ReadLine(); // Skip header
            var line = sr.ReadLine();
            var parts = line.Split(',');
            Console.WriteLine($"ID: {parts[0]}, Email: {Decrypt(parts[1])}, Salary: {Decrypt(parts[2])}");
        }
    }
}