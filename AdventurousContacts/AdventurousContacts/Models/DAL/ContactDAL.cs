using System;
using System.Collections.Generic;
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
            using (CreateConnection())
            {

            }

            throw new NotImplementedException();
        }
    }
}