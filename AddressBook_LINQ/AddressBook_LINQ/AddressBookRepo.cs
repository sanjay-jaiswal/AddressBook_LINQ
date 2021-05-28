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
            dataTable.Columns.Add("AddressBookName", typeof(string));
            dataTable.Columns.Add("AddressBookType", typeof(string));

            dataTable.Rows.Add("Sanju", "Jaiswal", "Madgaon", "Margao", "Goa", 403701, 7020665544, "sanju22@gmail.com","FamilyAddressBook","Family");
            dataTable.Rows.Add("Vivek", "Singh", "Pune", "Pune", "Maharashtra", 411044, 8877665566, "viv12@gmail.com", "FamilyAddressBook", "Family");
            dataTable.Rows.Add("Mahesh", "Patil", "Nanded", "Pune", "Maharashtra", 411043, 9988991660, "mahi11@gmail.com", "FriendsAddressBook", "Friends");
            dataTable.Rows.Add("Noman", "Zaheer", "Aligarh", "Aligarh", "Uttar Pradesh", 271233, 7778866554, "noman123@gmail.com", "PersonalAddressBook", "Personal");
            dataTable.Rows.Add("Rahul", "Verma", "Hazaratganj", "Lucknow", "Uttar Pradesh", 413555, 8886673344, "rahul22@gmail.com", "FriendsAddressBook", "Friends");           
        }

        public void AddContactDetails(ContactModel contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City,
            contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email, contact.AddressBookName, contact.AddressBookType);
            Console.WriteLine("Added contact successfully");
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
                Console.WriteLine("AddressBookName:-" + table.Field<string>("AddressBookName"));
                Console.WriteLine("AddressBookType:-" + table.Field<string>("AddressBookType"));
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
                Console.WriteLine("AddressBookName", contact.AddressBookName);
                Console.WriteLine("AddressBookType", contact.AddressBookType);
            }
        }

        public void DeleteContactByName(ContactModel contact)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("FirstName") == contact.FirstName).First();
            if (recordData != null)
            {
                recordData.Delete();
                Console.WriteLine("Contact deleted successfully!!");
            }
        }

        public void RetrieveContactsByCity(string city)
        {
            var cityResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("City") == city);
            foreach (DataRow row in cityResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + " ");
                }
                Console.WriteLine();
            }
        }
        public void RetrieveContactsByState(string state)
        {
            var stateResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("State") == state);
            foreach (DataRow row in stateResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + " ");
                }
                Console.WriteLine();
            }
        }

        public void CountByCityAndState()
        {
            var countByCityAndState = from row in dataTable.AsEnumerable()
                                      group row by new { City = row.Field<string>("City"), State = row.Field<string>("State") } into grp
                                      select new
                                      {
                                          City = grp.Key.City,
                                          State = grp.Key.State,
                                          Count = grp.Count()
                                      };
            foreach (var row in countByCityAndState)
            {
                Console.WriteLine(row.City + "\t" + row.State + "\t" + row.Count);
            }
        }

        public void SortByAlphabeticallyForGivenCity(ContactModel contact)
        {
            var records = dataTable.AsEnumerable().Where(x => x.Field<string>("City") == contact.City).OrderBy(x => x.Field<string>("FirstName")).ThenBy(x => x.Field<string>("LastName"));
            foreach (var table in records)
            {
                Console.WriteLine("\nFirstName:-" + table.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + table.Field<string>("LastName"));
                Console.WriteLine("Address:-" + table.Field<string>("Address"));
                Console.WriteLine("City:-" + table.Field<string>("City"));
                Console.WriteLine("State:-" + table.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + table.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + table.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + table.Field<string>("Email"));
                Console.WriteLine("AddressBookName:-" + table.Field<string>("AddressBookName"));
                Console.WriteLine("AddressBookType:-" + table.Field<string>("AddressBookType"));
            }
        }

        public void CountByAddressBookType()
        {
            var countData = dataTable.AsEnumerable().GroupBy(BookType => BookType.Field<string>("AddressBookType")).
                Select(BookType => new
                {
                    BookType = BookType.Key,
                    BookTypeCount = BookType.Count()
                });
            foreach (var list in countData)
            {
                Console.WriteLine("AddressBookType =" + list.BookType + " , " + "AddressBookCount = " + list.BookTypeCount);
            }
        }
    }
}
