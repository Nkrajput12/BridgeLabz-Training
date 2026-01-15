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

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} \nEmail: {Email}\nPhoneNumber: {PhoneNumber}\nCity: {City}\nState: {State}\nZip Code: {ZipCode}";
        }


    }
}
