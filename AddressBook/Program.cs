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

    public void UpdateContactDetails(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
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

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}\n" +
               $"Address: {Address}\n" +
               $"City: {City}\n" +
               $"State: {State}\n" +
               $"ZIP Code: {Zip}\n" +
               $"Phone Number: {PhoneNumber}\n" +
               $"Email: {Email}\n";
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
            // Update the contact details, including first and last name
            contactToUpdate.UpdateContactDetails(newFirstName, newLastName, newAddress, newCity, newState, newZip, newPhoneNumber, newEmail);
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
}

class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        while (true)
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Search for a contact");
            Console.WriteLine("3. Edit a contact");
            Console.WriteLine("4. Delete a contact");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1, 2, 3, 4, or 5): ");
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
                Console.Write("\nEnter the first name of the contact to edit: ");
                string firstNameToEdit = Console.ReadLine();
                Console.Write("Enter the last name of the contact to edit: ");
                string lastNameToEdit = Console.ReadLine();

                Console.Write("Enter the new first name: ");
                string newFirstName = Console.ReadLine();
                Console.Write("Enter the new last name: ");
                string newLastName = Console.ReadLine();
                Console.Write("Enter the new address: ");
                string newAddress = Console.ReadLine();
                Console.Write("Enter the new city: ");
                string newCity = Console.ReadLine();
                Console.Write("Enter the new state: ");
                string newState = Console.ReadLine();
                Console.Write("Enter the new ZIP: ");
                string newZip = Console.ReadLine();
                Console.Write("Enter the new phone number: ");
                string newPhoneNumber = Console.ReadLine();
                Console.Write("Enter the new email: ");
                string newEmail = Console.ReadLine();

                addressBook.UpdateContact(firstNameToEdit, lastNameToEdit, newFirstName, newLastName, newAddress, newCity, newState, newZip, newPhoneNumber, newEmail);
            }
            else if (choice == "4")
            {
                Console.Write("\nEnter the first name of the contact to delete: ");
                string firstNameToDelete = Console.ReadLine();
                Console.Write("Enter the last name of the contact to delete: ");
                string lastNameToDelete = Console.ReadLine();

                addressBook.DeleteContact(firstNameToDelete, lastNameToDelete);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please try again.");
            }
        }
    }
}
