using System;
using System.IO;
using System.Text.RegularExpressions;

class ValidateCSV
{
    static void Main()
    {
        string filePath = "contacts.csv";
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        foreach (var line in File.ReadLines(filePath).Skip(1))
        {
            var values = line.Split(',');
            string email = values[1].Trim();
            string phone = values[2].Trim();

            bool isEmailValid = Regex.IsMatch(email, emailPattern);
            bool isPhoneValid = phone.Length == 10 && long.TryParse(phone, out _);

            if (!isEmailValid || !isPhoneValid)
            {
                Console.WriteLine($"Invalid Row: {line} | Errors: {(isEmailValid ? "" : "Bad Email ")}{(isPhoneValid ? "" : "Bad Phone")}");
            }
        }
    }
}