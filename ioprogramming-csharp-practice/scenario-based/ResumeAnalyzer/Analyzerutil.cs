using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ResumeAnalyzer
{
    internal class Analyzerutil
    {
        string folderpath = "C:\\Users\\nkr88\\OneDrive\\Desktop\\resume";
        FileInfo[] files;
        Dictionary<string, Resume> records = new Dictionary<string, Resume>();

        public Analyzerutil()
        {
            var directory = new DirectoryInfo(folderpath);

            this.files = directory.GetFiles();

        }

        public void StartAnalyse()
        {
            foreach (var file in files)
            {
                try
                {
                    string resume = File.ReadAllText(file.FullName);
                    string emailrex = @"[A-Za-z0-9._\-%]+@[A-Za-z0-9._\-+]+\.[A-Za-z]{2,}";
                    string phonerex = @"[0-9]{10}";

                    Match matchemail = Regex.Match(resume, emailrex);
                    Match matchphone = Regex.Match(resume, phonerex);
                    if (!matchemail.Success)
                    {
                        throw new Exception("Invalid Format: No email Found ");
                    }
                    if (!matchphone.Success)
                    {
                        throw new Exception("Invalid Format: No phone number found");
                    }
                    string email = (string)matchemail.Value;
                    string phone = (string)matchphone.Value;

                    string name = file.Name;

                    int score = Regex.Matches(resume, @"(?i)(Java|Python)").Count;

                    records[email] = new Resume(email, score, name, phone);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Analyzing Complete");
        }

        public void Display()
        {
            foreach(Resume r in records.Values)
            {
                Console.WriteLine(r);
            }
        }
    }
}
