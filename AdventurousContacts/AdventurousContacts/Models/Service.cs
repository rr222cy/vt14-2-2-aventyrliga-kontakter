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

        // Hämtar specifik kontakt.
        public Contact GetContact(int contactID)
        {
            return ContactDAL.GetContactByID(contactID);
        }

        // Hämtar alla kontakter.
        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();
        }

        // Sparar en kontakt, endera ny eller med uppdaterad information.
        public void SaveContact(Contact contact)
        {
            // TODO validera indatan!
            if (contact.ContactID == 0)
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }           
        }
    }
}