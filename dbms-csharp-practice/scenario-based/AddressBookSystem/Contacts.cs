using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    public class Contacts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        // UC 7 Override Equals 
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contacts)) return false;
            Contacts other = (Contacts)obj;
            return this.FirstName.ToLower() == other.FirstName.ToLower() &&
                   this.LastName.ToLower() == other.LastName.ToLower();
        }

        // Always override GetHashCode when overriding Equals
        public override int GetHashCode()
        {
            return (FirstName.ToLower() + LastName.ToLower()).GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} \nEmail: {Email}\nPhoneNumber: {PhoneNumber}\nCity: {City}\nState: {State}\nZip Code: {ZipCode}";
        }


    }
}
