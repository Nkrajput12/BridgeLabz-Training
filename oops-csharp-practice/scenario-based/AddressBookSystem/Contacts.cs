using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    public class Contacts
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string Email { get; set; }
        internal string PhoneNumber { get; set; }
        internal string City { get; set; }
        internal string State { get; set; }
        internal int ZipCode { get; set; }

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
