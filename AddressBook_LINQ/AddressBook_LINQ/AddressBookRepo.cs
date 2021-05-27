using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBook_LINQ
{
    public class AddressBookRepo
    {
        private readonly DataTable dataTable = new DataTable();
        public void CreateTable()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("Email", typeof(string));

            dataTable.Rows.Add("Sanju", "Jaiswal", "Madgaon", "Margao", "Goa", 403701, 7020665544, "sanju22@gmail.com");
            dataTable.Rows.Add("Vivek", "Singh", "Pune", "Pune", "Maharashtra", 411044, 8877665566, "viv12@gmail.com");
            dataTable.Rows.Add("Mahesh", "Patil", "Nanded", "Pune", "Maharashtra", 411043, 9988991660, "mahi11@gmail.com");
            dataTable.Rows.Add("Noman", "Zaheer", "Aligarh", "Aligarh", "Uttar Pradesh", 271233, 7778866554, "noman123@gmail.com");
            dataTable.Rows.Add("Rahul", "Verma", "Hazaratganj", "Lucknow", "Uttar Pradesh", 413555, 8886673344, "rahul22@gmail.com");           
        }

        public void AddContactDetails(ContactModel contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City,
            contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email);
            Console.WriteLine("Contact added successfully!!");
        }

        public void DisplayDetails()
        {
            foreach (var table in dataTable.AsEnumerable())
            {
                Console.WriteLine("\nFirstName:-" + table.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + table.Field<string>("LastName"));
                Console.WriteLine("Address:-" + table.Field<string>("Address"));
                Console.WriteLine("City:-" + table.Field<string>("City"));
                Console.WriteLine("State:-" + table.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + table.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + table.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + table.Field<string>("Email"));
            }
        }

        public void EditContactByName(ContactModel contact)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("FirstName") == contact.FirstName).First();
            if (recordData != null)
            {
                recordData.SetField("LastName", contact.LastName);
                recordData.SetField("Address", contact.Address);
                recordData.SetField("City", contact.City);
                recordData.SetField("State", contact.State);
                recordData.SetField("ZipCode", contact.ZipCode);
                recordData.SetField("PhoneNumber", contact.PhoneNumber);
                recordData.SetField("Email", contact.Email);
            }
        }
    }
}
