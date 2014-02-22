using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models.DAL
{
    public class ContactDAL : DALBase
    {
        // Samlingsobjekt för att loopa ut referenser till Customerobjekt (kunder i databasen).
        public IEnumerable<Contact> GetContacts()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var contacts = new List<Contact>(100);

                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    // Skapar referens till data utläst från databasen.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar här reda på vilket index min databas olika kolumner har.
                        var contactIdIndex = reader.GetOrdinal("ContactID");
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");
                        var emailAddressIndex = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                                {
                                    ContactID = reader.GetInt32(contactIdIndex),
                                    FirstName = reader.GetString(firstNameIndex),
                                    LastName = reader.GetString(lastNameIndex),
                                    EmailAddress = reader.GetString(emailAddressIndex)
                                });
                        }
                    }

                    contacts.TrimExcess();
                    return contacts;
                }
                catch
                {
                    throw new ApplicationException("An error occured when trying to access and get data from database.");
                }
            }
        }
    }
}