using System;
using System.Collections.Generic;

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}

class AddressBook
{
    private List<Contact> contacts = new List<Contact>();

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public Contact FindContactByName(string firstName, string lastName)
    {
        return contacts.Find(contact => contact.FirstName == firstName && contact.LastName == lastName);
    }

    public void UpdateContact(string firstName, string lastName, string newFirstName, string newLastName, string newAddress, string newCity, string newState, string newZip, string newPhoneNumber, string newEmail)
    {
        Contact contactToUpdate = FindContactByName(firstName, lastName);

        if (contactToUpdate != null)
        {
            contactToUpdate.FirstName = newFirstName;
            contactToUpdate.LastName = newLastName;
            contactToUpdate.Address = newAddress;
            contactToUpdate.City = newCity;
            contactToUpdate.State = newState;
            contactToUpdate.Zip = newZip;
            contactToUpdate.PhoneNumber = newPhoneNumber;
            contactToUpdate.Email = newEmail;
            Console.WriteLine("Contact updated successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found in the address book.");
        }
    }

    public void DeleteContact(string firstName, string lastName)
    {
        Contact contactToDelete = FindContactByName(firstName, lastName);

        if (contactToDelete != null)
        {
            contacts.Remove(contactToDelete);
            Console.WriteLine("Contact deleted successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found in the address book.");
        }
    }

    public void DisplayContacts()
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();

        while (true)
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Add a new Address Book");
            Console.WriteLine("2. Select Address Book");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1, 2, or 3): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("\nEnter a unique name for the new Address Book: ");
                string addressBookName = Console.ReadLine();

                if (addressBooks.ContainsKey(addressBookName))
                {
                    Console.WriteLine("An Address Book with the same name already exists.");
                }
                else
                {
                    AddressBook newAddressBook = new AddressBook();
                    addressBooks.Add(addressBookName, newAddressBook);
                    Console.WriteLine($"New Address Book '{addressBookName}' created successfully.");
                }
            }
            else if (choice == "2")
            {
                Console.Write("\nEnter the name of the Address Book to select: ");
                string selectedAddressBookName = Console.ReadLine();

                if (addressBooks.TryGetValue(selectedAddressBookName, out AddressBook selectedAddressBook))
                {
                    ManageAddressBook(selectedAddressBook);
                }
                else
                {
                    Console.WriteLine("Address Book not found.");
                }
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void ManageAddressBook(AddressBook addressBook)
    {
        while (true)
        {
            Console.WriteLine("\nWhat do you want to do with this Address Book?");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Search for a contact");
            Console.WriteLine("3. Edit a contact");
            Console.WriteLine("4. Delete a contact");
            Console.WriteLine("5. Display all contacts");
            Console.WriteLine("6. Back to main menu");
            Console.Write("Enter your choice (1, 2, 3, 4, 5, or 6): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("\nEnter the first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter the last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter the address: ");
                string address = Console.ReadLine();
                Console.Write("Enter the city: ");
                string city = Console.ReadLine();
                Console.Write("Enter the state: ");
                string state = Console.ReadLine();
                Console.Write("Enter the ZIP: ");
                string zip = Console.ReadLine();
                Console.Write("Enter the phone number: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Enter the email: ");
                string email = Console.ReadLine();

                addressBook.AddContact(new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email));
                Console.WriteLine("\nContact added successfully!");
            }
            else if (choice == "2")
            {
                Console.Write("\nEnter the first name of the contact: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter the last name of the contact: ");
                string lastName = Console.ReadLine();

                Contact contact = addressBook.FindContactByName(firstName, lastName);
                if (contact != null)
                {
                    Console.WriteLine("\nContact found:");
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                }
                else
                {
                    Console.WriteLine("\nContact not found in the address book.");
                }
            }
            else if (choice == "3")
            {
                // ... (Edit contact functionality, same as before)
            }
            else if (choice == "4")
            {
                // ... (Delete contact functionality, same as before)
            }
            else if (choice == "5")
            {
                Console.WriteLine($"\nContacts in the Address Book '{addressBook}' :");
                addressBook.DisplayContacts();
            }
            else if (choice == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please try again.");
            }
        }
    }
}
