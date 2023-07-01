using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    public class ContactAlreadyExistsException : Exception
    {
        public ContactAlreadyExistsException(string message) : base(message) { }

    }
}
