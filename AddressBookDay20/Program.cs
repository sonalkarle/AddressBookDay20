using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        //List genrated to store result
        public List<PersonInfo> addressBook;
        public AddressBook()
        {
            addressBook = new List<PersonInfo>();
        }
        private void AddPersonToDictionary(Dictionary<string, List<PersonInfo>> DicForPerson, PersonInfo person, string placeObject)
        {
            if (DicForPerson.ContainsKey(placeObject))
            {
                DicForPerson[placeObject].Add(person);
            }
            else
            {
                List<PersonInfo> newList = new List<PersonInfo>();
                newList.Add(person);
                DicForPerson.Add(placeObject, newList);
            }
        }
        private void AddPersonToCityAndState(Collection addressBookCollection, PersonInfo person)
        {
            AddPersonToDictionary(addressBookCollection.cityDictionary, person, person.city);
            AddPersonToDictionary(addressBookCollection.stateDictionary, person, person.state);
        }
        public void AddAddressBookEntry(PersonInfo person, Collection addressBookCollection)
        {
            //Check wheather the person is exist or not
            if (addressBook.Find(i => person.Equals(i)) != null)
            {                
                

                throw new AddressBookException("Person already Exists, enter new person!");
               
            }
            AddPersonToCityAndState(addressBookCollection, person);
            addressBook.Add(person);


        }
        public void AddContactEntry(Collection addressBookCollection)
        {
            //Add details of person
            PersonInfo personEntered = new PersonInfo();
            Console.WriteLine("Enter First name");
            personEntered.first_Name = Console.ReadLine();
            Console.WriteLine("Enter Last name");
            personEntered.last_Name = Console.ReadLine();
            if (addressBook.Find(i => personEntered.Equals(i)) != null)
            {
                Console.WriteLine("Person already Exists, enter new person!");
                return;
            }
            Console.WriteLine("Enter Address");
            personEntered.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            personEntered.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            personEntered.state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            personEntered.zip = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber");
            personEntered.phone_Number = Console.ReadLine();
            Console.WriteLine("Enter Email");
            personEntered.email = Console.ReadLine();
            addressBookCollection.cityDictionary[personEntered.city].Add(personEntered);
            addressBookCollection.stateDictionary[personEntered.state].Add(personEntered);
            addressBook.Add(personEntered);
        }
        public void DisplayContactInAddresBook()
        {
            //Display the details
            if (addressBook.Count == 0)
            {
                Console.WriteLine("No Names to Display");
            }
            foreach (PersonInfo person in addressBook)
            {
                Console.WriteLine("Details of person");
                person.DisplayPerson();
            }
        }

        
        public void EditContactformaddressBook(string first_Name, string last_Name)
        {
            //Search person by the name
            int index = 0;
            bool found = false;
            foreach (PersonInfo person in addressBook)
            {
                if (person.first_Name == first_Name && person.last_Name == last_Name)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
            {
                Console.WriteLine("Enter First name");
                addressBook[index].first_Name = Console.ReadLine();
                Console.WriteLine("Enter Last name");
                addressBook[index].last_Name = Console.ReadLine();
                Console.WriteLine("Enter Address");
                addressBook[index].address = Console.ReadLine();
                Console.WriteLine("Enter City");
                addressBook[index].city = Console.ReadLine();
                Console.WriteLine("Enter State");
                addressBook[index].state = Console.ReadLine();
                Console.WriteLine("Enter Zip");
                addressBook[index].zip = Console.ReadLine();
                Console.WriteLine("Enter phoneNumber");
                addressBook[index].phone_Number = Console.ReadLine();
                Console.WriteLine("Enter Email");
                addressBook[index].email = Console.ReadLine();
            }
            else
                Console.WriteLine("Entry Not found for the name");
        }

        public void DeleteContactfromAddressBook(string first_Name, string last_Name)
        { //Delete the contact from the list
            int index = 0;
            bool found = false;
            foreach (PersonInfo person in addressBook)
            {
                //Check person in list by name
                if (person.first_Name == first_Name && person.last_Name == last_Name)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
                addressBook.Remove(addressBook[index]);
            else
                Console.WriteLine("Entry Not found");
        }
        public void SortByfirst_Name()
        {
            addressBook.Sort((x, y) => x.first_Name.CompareTo(y.first_Name));
        }
        public void SortByZip()
        {
            addressBook.Sort((x, y) => x.zip.CompareTo(y.zip));
        }
        public void SortByCity()
        {
            addressBook.Sort((x, y) => x.city.CompareTo(y.city));
        }
        public void SortByState()
        {
            addressBook.Sort((x, y) => x.state.CompareTo(y.state));
        }


    }
    class Program
    {
        static void SortByCityStateorZip(Collection addressBookCollection, string addressBookName)
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
        
            static void Main(string[] args)
            {


                Console.WriteLine("Welcome to Address Book!");
                Console.WriteLine("Enter  Address Book Name");
                string addressBookName = Console.ReadLine();
                Collection addressBookCollection = new Collection();
                AddressBook addressBook = new AddressBook();
                addressBookCollection.addressBookDictionary.Add(addressBookName, addressBook);
                int choice;
                do
                {

                    Console.WriteLine("Welcome to the" + addressBookName);
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
                    Console.WriteLine("12) Exit");

                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            addressBookCollection.addressBookDictionary[addressBookName].DisplayContactInAddresBook();
                            break;
                        case 2:
                            addressBookCollection.addressBookDictionary[addressBookName].AddContactEntry(addressBookCollection);
                            break;
                        case 3:
                            Console.WriteLine("Enter First Name");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name");
                            string lastName = Console.ReadLine();
                            addressBookCollection.addressBookDictionary[addressBookName].EditContactformaddressBook(firstName, lastName);
                            break;
                        case 4:
                            Console.WriteLine("Enter First Name");
                            firstName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name");
                            lastName = Console.ReadLine();
                            addressBookCollection.addressBookDictionary[addressBookName].DeleteContactfromAddressBook(firstName, lastName);
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
                            addressBookCollection.SearchContactInCityOrState(firstName, lastName);
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
                            addressBookCollection.addressBookDictionary[addressBookName].SortByfirst_Name();
                            break;
                        case 11:
                            addressBookCollection.addressBookDictionary.Add("Default", new AddressBook());
                            PersonInfo person1 = new PersonInfo();
                            person1.first_Name = "Sonal";
                            person1.last_Name = "Karle";
                            person1.address = "flat no 404/5";
                            person1.city = "Mumbai";
                            person1.state = "Maharashtra";
                            person1.zip = "40075";
                            person1.phone_Number = "9702420754";
                            person1.email = "sonalkarle01@gmail.com";
                            PersonInfo person2 = new PersonInfo();
                            person2.first_Name = "Sona";
                            person2.last_Name = "Karle";
                            person2.address = "flat no 404/5";
                            person2.city = "Pune";
                            person2.state = "Maharashtra";
                            person2.zip = "411016";
                            person2.phone_Number = "8806184089";
                            person2.email = "sonalkarle06@gmail.com";
                            addressBookCollection.addressBookDictionary["Default"].AddAddressBookEntry(person2, addressBookCollection);
                            addressBookCollection.addressBookDictionary["Default"].AddAddressBookEntry(person1, addressBookCollection);
                            addressBookName = "Default";
                            break;
                        default:
                            Console.WriteLine("Enter Proper Choice!");
                            break;
                    }
                } while (choice != 12);
            
            }
        }
    }
