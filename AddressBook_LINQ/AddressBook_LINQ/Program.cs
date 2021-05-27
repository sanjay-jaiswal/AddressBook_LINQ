using System;

namespace AddressBook_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============= Welcome To Address Book Using LINQ =================");

            AddressBookRepo addressBook = new AddressBookRepo();
            addressBook.CreateTable();
        }
    }
}
