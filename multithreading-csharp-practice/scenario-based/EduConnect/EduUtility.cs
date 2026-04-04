using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EduConnect
{
    internal class EduUtility
    {
        List<Applicant> allapplicants = new List<Applicant>();

        public void Add()
        {
            Applicant ap = new Applicant();
            Console.Write("Enter Name: ");
            ap.Name = Console.ReadLine();

            Console.Write("Enter Email: ");
            ap.Email = Console.ReadLine();

            ap.ApplicationId = allapplicants.Count+1;
            Console.WriteLine("Your application Id = " + ap.ApplicationId);
            
            allapplicants.Add(ap);
            if (Validate(ap))
            {
                Task.Delay(10000);
                Task.Run(() => ProcessApplication(ap));
            }
            Console.WriteLine("Your application is submit");                 
        }

        public bool Validate(Applicant ap)
        {
            ap.ApplicationStatus = "Under Review";
            var allproperty = ap.GetType().GetProperties();

            foreach(var property in allproperty)
            {
                if (property.IsDefined(typeof(ValidEmailAttribute), false))
                {
                    string email = (string)property.GetValue(ap);

                    string regex = "^[0-9a-zA-Z+-_%]+@[a-zA-Z0-9.-]+\\.[A-Za-z]{2,6}$";

                    if (!(Regex.IsMatch(email, regex)))
                    {
                        ap.ApplicationStatus = "Reject: Invalid Email";

                        //Console.WriteLine($"{property.Name} is not in valid format");
                        return false;
                    }
                    
                }

                if (property.IsDefined(typeof(RequiredAttribute), false))
                {
                    string name = (string)property.GetValue(ap);

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        ap.ApplicationStatus = "Rejected: Empty Name";
                        
                        return false;


                    }
                }
            }
            return true;
        }


        public async Task ProcessApplication(Applicant ap)
        {
            ap.ApplicationStatus = "Processing.....";
            await Task.Delay(20000);
            ap.ApplicationStatus = "Approved.......";
     
        }

        public void Display(int id)
        {
            if(allapplicants.Count < id)
            {
                Console.WriteLine("Id does not exist");
                return;
            }

            Console.WriteLine($"Name: {allapplicants[id-1].Name} | Status: {allapplicants[id-1].ApplicationStatus}");

        }
    }
}
