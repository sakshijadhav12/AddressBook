using System;
using System.Collections.Generic;
namespace Addressbook;

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        State = state;
        ZipCode = zipCode;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}\n" +
               $"Address: {Address}\n" +
               $"City: {City}\n" +
               $"State: {State}\n" +
               $"Zip Code: {ZipCode}\n" +
               $"Phone Number: {PhoneNumber}\n" +
               $"Email: {Email}\n";
    }
}

class AddressBook
{
    private List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void DisplayContacts()
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }
}

class AddressBookMain
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        while (true)
        {
            Console.WriteLine("Add a new contact (type 'exit' to stop):");

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            if (firstName.ToLower() == "exit")
                break;

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            Console.Write("Enter Zip Code: ");
            string zipCode = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Contact newContact = new Contact(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
            addressBook.AddContact(newContact);
            Console.WriteLine("Contact added successfully!\n");
        }

        Console.WriteLine("Contacts in the Address Book:");
        addressBook.DisplayContacts();

        Console.WriteLine("Exiting the program. Goodbye!");
    }
}
