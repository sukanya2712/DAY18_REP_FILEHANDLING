namespace AddressBookFileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Addressbook addressBook = new Addressbook();
            Console.WriteLine("Welcome to AddressBook");

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1) Add contacts");
                Console.WriteLine("2) Display Contacts");
                Console.WriteLine("3) Delete Contacts");
                Console.WriteLine("4) Edit Contacts");
                Console.WriteLine("9) Exit");

                string OptionString = Console.ReadLine();
                int Choice;

                if (int.TryParse(OptionString, out Choice))
                {
                    try
                    {
                        switch (Choice)
                        {
                            case 1:
                                bool contactAdded = addressBook.AddContact();
                                if (contactAdded)
                                {
                                    Console.WriteLine("Contact added successfully.");
                                }
                                break;
                            case 2:
                                List<Contact> contacts = addressBook.Display();
                                if (contacts.Count > 0)
                                {
                                    foreach (Contact contact in contacts)
                                    {
                                        Console.WriteLine(contact);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Contact list is empty.");
                                }
                                break;
                            case 3:
                                bool contactDeleted = addressBook.Delete();
                                if (contactDeleted)
                                {
                                    Console.WriteLine("Contact deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Contact not found");
                                }
                                break;
                            case 4:
                                bool contactEdited = addressBook.Edit();
                                if (contactEdited)
                                {
                                    Console.WriteLine("Contact edited successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Contact not found");
                                }
                                break;
                            case 9:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                    }
                    catch (ContactAlreadyExistsException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    catch (EmptyContactListException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid integer choice.");
                }
            }
        }
    }
}