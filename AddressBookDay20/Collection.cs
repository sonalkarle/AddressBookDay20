using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class Collection
    {
        //City dictionay and statedictionary are generated to get count and sort as per use case
        public Dictionary<string, AddressBook> addressBookDictionary;
        public Dictionary<string, List<PersonInfo>> cityDictionary;
        public Dictionary<string, List<PersonInfo>> stateDictionary;
        public Collection()
        {
            addressBookDictionary = new Dictionary<string, AddressBook>();
            cityDictionary = new Dictionary<string, List<PersonInfo>>();
            stateDictionary = new Dictionary<string, List<PersonInfo>>();
        }
        public void PrintAllAddressBookNames()
        {
            foreach (var AddressBookItem in addressBookDictionary)
            {
                Console.WriteLine(AddressBookItem.Key);
            }
        }
        public ArrayList SearchContactInCityOrState(string first_Name, string last_Name)
        {
            //Searching conatct by the city or state
            ArrayList outputLines = new ArrayList();
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<PersonInfo> PersonInCitiesOrStates = addressBookEntry.Value.addressBook.FindAll(i => (i.first_Name == first_Name) && (i.last_Name == last_Name));
                foreach (PersonInfo person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.first_Name} {person.last_Name} is in {person.city} {person.state}");
                    outputLines.Add($" {person.first_Name} {person.last_Name} is in {person.city} {person.state}");
                }
            }
            return outputLines;
        }
        public ArrayList ViewPersonsByCityOrState(string city, string state)
        {
            ArrayList outputLines = new ArrayList();
            Console.WriteLine($"People in {city} city:");
            outputLines.Add($"People in {city} city:");
            foreach (PersonInfo person in cityDictionary[city])
            {
                Console.WriteLine(person.first_Name + " " + person.last_Name);
                outputLines.Add(person.first_Name + " " + person.last_Name);
            }

            Console.WriteLine($"People in {state} state:");
            outputLines.Add($"People in {state} state:");
            foreach (PersonInfo person in stateDictionary[state])
            {
                Console.WriteLine(person.first_Name + " " + person.last_Name);
                outputLines.Add(person.first_Name + " " + person.last_Name);
            }
            return outputLines;
        }
        public ArrayList ViewCountByCityOrState(string city, string state)
        {
            ArrayList outputLines = new ArrayList();
            outputLines.Add($"Count of {city} is {cityDictionary[city].Count}");
            outputLines.Add($"Count of {state} is {stateDictionary[state].Count}");
            Console.WriteLine($"Count of {city} is {cityDictionary[city].Count}");
            Console.WriteLine($"Count of {state} is {stateDictionary[state].Count}");
            return outputLines;
        }
    }

}