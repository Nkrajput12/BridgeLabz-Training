using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.PasswordCracker
{
    internal class Password
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Password Cracker Program");
            //taking user input for password
            Console.WriteLine("Enter the password of 5 character  to crack:");
            string password = Console.ReadLine();
            if(password.Length != 5)
            {
                Console.WriteLine("Please enter a valid password of exactly 5 characters.");
                return;
            }
            char[] passwordArray = password.ToCharArray();
            char[] guess = new char[5]; 
            int attempts = 0; //to visualize the  time complexity
            for (char i = 'a'; i <= 'z'; i++)
            {
                for (char j = 'a'; j <= 'z'; j++)
                {
                    for (char k = 'a'; k <= 'z'; k++)
                    {
                        for (char l = 'a'; l <= 'z'; l++)
                        {
                            for (char m = 'a'; m <= 'z'; m++)
                            {
                                guess[0] = i;
                                guess[1] = j;
                                guess[2] = k;
                                guess[3] = l;
                                guess[4] = m;
                                attempts++;
                                if (guess.SequenceEqual(passwordArray))
                                {
                                    Console.WriteLine($"Password cracked! The password is: {new string(guess)}");
                                    Console.WriteLine($"Total attempts: {attempts}");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
