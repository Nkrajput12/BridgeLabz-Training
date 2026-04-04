using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.AddressBookSystem
{
    internal interface IAddressBook
    {
        public void AddContact();
        public void EditContact();

        public void DeleteContact();
    }
}
