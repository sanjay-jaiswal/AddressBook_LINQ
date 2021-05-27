using System;

namespace AddressBook_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============= Welcome To Address Book Using LINQ =================");

            AddressBookRepo addressBookRepo = new AddressBookRepo();
            addressBookRepo.CreateTable();
            addressBookRepo.DisplayDetails();
            ContactModel contact = new ContactModel();

            while (true)
            {
                Console.WriteLine("\n 1.Display \n 2.Add Contact \n 3.Edit Contact \n 4.Delete Contact  \n 5. Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (option)
                    {
                        case 1:
                            addressBookRepo.DisplayDetails();
                            break;
                        case 2:
                            Console.WriteLine("Please enter your first name : ");
                            contact.FirstName = Console.ReadLine();
                            Console.WriteLine("Please enter your last name : ");
                            contact.LastName = Console.ReadLine();
                            Console.WriteLine("Please enter your address : ");
                            contact.Address = Console.ReadLine();
                            Console.WriteLine("Please enter your city : ");
                            contact.City = Console.ReadLine();
                            Console.WriteLine("Please enter your state : ");
                            contact.State = Console.ReadLine();
                            Console.WriteLine("Please enter your zip code :");
                            contact.ZipCode = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter your mobile number : ");
                            contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Please enter your emil id : ");
                            contact.Email = Console.ReadLine();
                            addressBookRepo.AddContactDetails(contact);
                            break;
                        case 3:
                            Console.WriteLine("Please enter your first name : ");
                            contact.FirstName = Console.ReadLine();
                            Console.WriteLine("Please enter your last name : ");
                            contact.LastName = Console.ReadLine();
                            Console.WriteLine("Please enter your address : ");
                            contact.Address = Console.ReadLine();
                            Console.WriteLine("Please enter your city : ");
                            contact.City = Console.ReadLine();
                            Console.WriteLine("Please enter your state : ");
                            contact.State = Console.ReadLine();
                            Console.WriteLine("Please enter your zip code :");
                            contact.ZipCode = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter your mobile number : ");
                            contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Please enter your emil id : ");
                            contact.Email = Console.ReadLine();
                            addressBookRepo.EditContactByName(contact);
                            break;
                        case 4:
                            Console.WriteLine("Enter the first name = ");
                            contact.FirstName = Console.ReadLine();
                            addressBookRepo.DeleteContactByName(contact);
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please select valid option.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter integer value only");
                }
            }
        }
    }
}