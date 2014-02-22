using AdventurousContacts.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    public class Service
    {
        private ContactDAL _contactDAL;

        private ContactDAL ContactDAL
        {
            get { return _contactDAL ?? (_contactDAL = new ContactDAL()); }
        }

        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();
        }
    }
}