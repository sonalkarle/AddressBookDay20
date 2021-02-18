using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBookException : Exception
    {
        public AddressBookException(string name) : base()
        {
            Console.WriteLine(name);
        }
    }
}