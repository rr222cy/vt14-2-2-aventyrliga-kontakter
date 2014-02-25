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

        public Contact GetContactByID(int contactID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactID;

                    conn.Open();

                    // Skapar referens till data utläst från databasen.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar här reda på vilket index min databas olika kolumner har.
                        var contactIdIndex = reader.GetOrdinal("ContactID");
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");
                        var emailAddressIndex = reader.GetOrdinal("EmailAddress");

                        // Eftersom jag bara vill läsa ut en post, körs en if-sats om något finns att läsas ur databasen.
                        if (reader.Read())
                        {
                            return new Contact
                            {
                                ContactID = reader.GetInt32(contactIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                EmailAddress = reader.GetString(emailAddressIndex)
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch
                {
                    throw new ApplicationException("An error occured when trying to access and get data from database.");
                }
            }
        }

        public void InsertContact(Contact contact)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Skapar här de parametrar som måste skickas med för att lägga till en ny kontakt i databasen.
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

                    // Denna parameter hämtar ut det ID kontakten som just lades till fick, dvs. ContactID.
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    // Exekverar den lagrade proceduren - dvs. skjuter in parametrarna i en ny rad i tabellen Contact.
                    cmd.ExecuteNonQuery();

                    // Hämtar ID:t och tilldelar detta till använt Contactobjekt.
                    contact.ContactID = (int)cmd.Parameters["@ContactID"].Value;    
                }
                catch
                {
                    throw new ApplicationException("An error occured when trying to add data to the database.");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int contactID)
        {
            throw new NotImplementedException();
        }
    }
}