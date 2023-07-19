using System;
using System.Collections;

namespace AddressBook
{
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
    }

    class Program
    {
        static void Main()
        {
            List<Contact> addressBook = new List<Contact>();

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

                Contact newContact = new Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city,
                    State = state,
                    ZipCode = zipCode,
                    PhoneNumber = phoneNumber,
                    Email = email
                };

                addressBook.Add(newContact);
                Console.WriteLine("Contact added successfully!\n");
            }

            Console.WriteLine("Contacts in the Address Book:");
            foreach (var contact in addressBook)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine($"State: {contact.State}");
                Console.WriteLine($"Zip Code: {contact.ZipCode}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}\n");
            }

            Console.WriteLine("Exiting the program. Goodbye!");
        }
    }
}
