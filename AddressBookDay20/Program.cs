using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Program
    {
        static string AddDefaultValues(AddressBookCollection addressBookCollection)
        {
            addressBookCollection.addressBookDictionary.Add("Default", new AddressBook());
            Person person1 = new Person();
            person1.firstName = "Aipesh";
            person1.lastName = "Walte";
            person1.address = "Flat no 30-B";
            person1.city = "Pune";
            person1.state = "Maharashtra";
            person1.zip = "411033";
            person1.phoneNumber = "942241411";
            person1.email = "dipeshrwalte@gmail.com";
            Person person2 = new Person();
            person2.firstName = "Bhanesh";
            person2.lastName = "Walte";
            person2.address = "Flat no 30-B";
            person2.city = "Mumbai";
            person2.state = "Maharashtra";
            person2.zip = "411033";
            person2.phoneNumber = "942241411";
            person2.email = "dhaneshrwalte@gmail.com";
            addressBookCollection.addressBookDictionary["Default"].AddAddressBookEntry(person2, addressBookCollection);
            addressBookCollection.addressBookDictionary["Default"].AddAddressBookEntry(person1, addressBookCollection);
            return "Default";

        }
        static void PrintOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Choice:");
            Console.WriteLine("1) Display All Entries");
            Console.WriteLine("2) Insert new Entry");
            Console.WriteLine("3) Edit Entry");
            Console.WriteLine("4) Delete Entry");
            Console.WriteLine("5) Add New Address Book");
            Console.WriteLine("6) Switch To Different Address Book");
            Console.WriteLine("7) Search person in city or state");
            Console.WriteLine("8) List by state or city");
            Console.WriteLine("9) View Count by state or city");
            Console.WriteLine("10) Sort by First Name");
            Console.WriteLine("11) Sort by City,State or Zip");
            Console.WriteLine("12) Read From File");
            Console.WriteLine("13) Write to File");
            Console.WriteLine("14) Populate Default");
            Console.WriteLine("15) Exit");
            Console.WriteLine("------------------------------");
        }
        static void SortByCityStateorZip(AddressBookCollection addressBookCollection, string addressBookName)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Choice:");
            Console.WriteLine("1) Sort By City");
            Console.WriteLine("2) Sort By State");
            Console.WriteLine("3) Sort By Zip");
            Console.WriteLine("------------------------------");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    addressBookCollection.addressBookDictionary[addressBookName].SortByCity();
                    break;
                case 2:
                    addressBookCollection.addressBookDictionary[addressBookName].SortByState();
                    break;
                case 3:
                    addressBookCollection.addressBookDictionary[addressBookName].SortByZip();
                    break;
                default:
                    Console.WriteLine("Enter proper choice");
                    break;
            }

        }

        static void ReadFromFile(AddressBookCollection addressBookCollection)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter Choice:");
            Console.WriteLine("1) Read from Txt");
            Console.WriteLine("2) Read from CSV");
            Console.WriteLine("3) Read from Json");
            Console.WriteLine("------------------------------");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    addressBookCollection.addressBookDictionary[addressBookName].SortByCity();
                    break;
                case 2:
                    addressBookCollection.addressBookDictionary[addressBookName].SortByState();
                    break;
                case 3:
                    addressBookCollection.addressBookDictionary[addressBookName].SortByZip();
                    break;
                default:
                    Console.WriteLine("Enter proper choice");
                    break;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book!");
            Console.WriteLine("Enter Default Address Book Name");
            string addressBookName = Console.ReadLine();
            AddressBookCollection addressBookCollection = new AddressBookCollection();
            AddressBook addressBook = new AddressBook();
            addressBookCollection.addressBookDictionary.Add(addressBookName, addressBook);
            int choice;
            do
            {
                PrintOptions();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBookCollection.addressBookDictionary[addressBookName].DisplayNamesInAddresBook();
                        break;
                    case 2:
                        addressBookCollection.addressBookDictionary[addressBookName].AddAddressBookEntry(addressBookCollection);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        string lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].EditContact(firstName, lastName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary[addressBookName].DeleteContact(firstName, lastName);
                        break;
                    case 5:
                        Console.WriteLine("Enter New Address Book Name");
                        addressBookName = Console.ReadLine();
                        addressBookCollection.addressBookDictionary.Add(addressBookName, new AddressBook());
                        Console.WriteLine($"Address Book {addressBookName} selected!");
                        break;
                    case 6:
                        Console.WriteLine("Listing all Address Books");
                        foreach (var addressBookEntry in addressBookCollection.addressBookDictionary)
                        {
                            Console.WriteLine(addressBookEntry.Key);
                        }
                        Console.WriteLine("Select an Address Book");
                        addressBookName = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Enter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        lastName = Console.ReadLine();
                        addressBookCollection.SearchPersonInCityOrState(firstName, lastName);
                        break;
                    case 8:
                        Console.WriteLine("Enter City Name");
                        string cityName = Console.ReadLine();
                        Console.WriteLine("Enter State Name");
                        string stateName = Console.ReadLine();
                        addressBookCollection.ViewPersonsByCityOrState(cityName, stateName);
                        break;
                    case 9:
                        Console.WriteLine("Enter City Name");
                        cityName = Console.ReadLine();
                        Console.WriteLine("Enter State Name");
                        stateName = Console.ReadLine();
                        addressBookCollection.ViewCountByCityOrState(cityName, stateName);
                        break;
                    case 10:
                        addressBookCollection.addressBookDictionary[addressBookName].SortByFirstName();
                        break;
                    case 11:
                        SortByCityStateorZip(addressBookCollection, addressBookName);
                        break;
                    case 12:
                        addressBookCollection.ReadFilesToAddressBookCollection();
                        break;
                    case 13:
                        addressBookCollection.WriteAddressBookCollectionToFiles();
                        break;
                    case 14:
                        addressBookName = AddDefaultValues(addressBookCollection);
                        break;
                    default:
                        Console.WriteLine("Enter Proper Choice!");
                        break;
                }
            } while (choice != 15);
        }
    }
}
