using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    internal class Addressbook
    {
        private const string FilePath = "C:\\Users\\Sukanay\\Desktop\\addressbookfileio.txt";

        List<Contact> contactList = new List<Contact>();

        public Addressbook()
        {
            contactList = LoadContactsFromFile();
        }

        public bool AddContact()
        {
            Console.WriteLine("Enter name");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter email");
            string? email = Console.ReadLine();
            Console.WriteLine("Enter phone");
            string? phone = Console.ReadLine();
            Console.WriteLine("Enter state");
            string? state = Console.ReadLine();
            Console.WriteLine("Enter city");
            string? city = Console.ReadLine();
            Console.WriteLine("Enter zip");
            string? zip = Console.ReadLine();
            Contact contact = new Contact(name, email, phone, state, city, zip);

            bool isDuplicate = contactList.Any(existingContact => existingContact.Phone == phone);

            if (!isDuplicate)
            {
                contactList.Add(contact);
                SaveContactsToFile();
                return true;
            }
            else
            {
                throw new ContactAlreadyExistsException("Duplicate contact");
            }
        }




        public List<Contact> Display()
        {
            contactList = LoadContactsFromFile();
            if (contactList.Count == 0)
            {
                throw new EmptyContactListException("Contact list is empty.");
            }
            return contactList;
        }

        public bool Delete()
        {
            Console.WriteLine("Enter name of the contact to be deleted : ");
            string? inputString = Console.ReadLine();

            Contact contactToRemove = contactList.FirstOrDefault(contact => contact.Name == inputString);

            if (contactToRemove != null)
            {
                contactList.Remove(contactToRemove);
                SaveContactsToFile();
                return true;
            }

            return false;
        }


        public bool Edit()
        {
            Console.WriteLine("Enter name of the contact:");
            string? input = Console.ReadLine();

            for (int i = 0; i < contactList.Count; i++)
            {
                Contact contact = contactList[i];

                if (input == contact.Name)
                {
                    Console.WriteLine("Enter name:");
                    string? name = Console.ReadLine();

                    Console.WriteLine("Enter email:");
                    string? email = Console.ReadLine();

                    Console.WriteLine("Enter phone:");
                    string? phone = Console.ReadLine();

                    Console.WriteLine("Enter state:");
                    string? state = Console.ReadLine();

                    Console.WriteLine("Enter city:");
                    string? city = Console.ReadLine();

                    Console.WriteLine("Enter zip:");
                    string? zip = Console.ReadLine();

                    Contact updatedContact = new Contact(name, email, phone, state, city, zip);

                    if (contactList.Contains(updatedContact))
                    {
                        throw new ContactAlreadyExistsException("Contact already exists.");
                    }
                    else
                    {
                        contact.Name = name;
                        contact.Email = email;
                        contact.Phone = phone;
                        contact.State = state;
                        contact.City = city;
                        contact.ZipCode = zip;
                        SaveContactsToFile();
                        return true;
                    }


                }
            }

            return false;
        }


        private void SaveContactsToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Contact contact in contactList)
                {
                    writer.WriteLine($"{contact.Name},{contact.Email},{contact.Phone},{contact.State},{contact.City},{contact.ZipCode}");
                }
            }
        }

        private List<Contact> LoadContactsFromFile()
        {
            List<Contact> contacts = new List<Contact>();

            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        if (values.Length == 6)
                        {
                            string name = values[0];
                            string email = values[1];
                            string phone = values[2];
                            string state = values[3];
                            string city = values[4];
                            string zip = values[5];

                            contacts.Add(new Contact(name, email, phone, state, city, zip));
                        }
                    }
                }
            }

            return contacts;
        }
    }
}
