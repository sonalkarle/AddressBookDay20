using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class PersonInfo
    {
        public string first_Name;
        public string last_Name;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string phone_Number;
        public string email;
        
        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is PersonInfo))
            {
                return false;
            }
            return (this.first_Name == ((PersonInfo)obj).first_Name)
                && (this.last_Name == ((PersonInfo)obj).last_Name);
        }
        public void DisplayPerson()
        {
            Console.WriteLine($"First Name : {first_Name}");
            Console.WriteLine($"Last Name : {last_Name}");
            Console.WriteLine($"Address : {address}");
            Console.WriteLine($"City : {city}");
            Console.WriteLine($"State : {state}");
            Console.WriteLine($"Zip : {zip}");
            Console.WriteLine($"PhoneNumber : {phone_Number}");
            Console.WriteLine($"Email : {email}");
        }
    }
}
