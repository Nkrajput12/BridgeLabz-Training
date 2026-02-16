using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.ResumeAnalyzer
{
    internal class Resume
    {
        public string Email;
        public int Score;
        public string Name;
        public string PhoneNo;
        public Resume(string email,int score,string name,string phone)
        {
            this.Email = email;
            this.Score = score;
            this.Name = name;
            this.PhoneNo = phone;
        }
        public override string ToString()
        {
            return $"Name: {Name} | Email: {Email} \nPhone no: {PhoneNo} | Score: {Score}";        
        }
    }
}
