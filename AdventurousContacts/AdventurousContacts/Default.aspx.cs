﻿using AdventurousContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdventurousContacts
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Contact> ContactListView_GetData()
        {
            return Service.GetContacts();
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            try
            {
                // Lägger till kontakten i databasen, samt presenterar ett meddelande om att allt lyckats.
                Service.SaveContact(contact);
                StatusLitteral.Text = "Kontakten lades till!";
                StatusMessage.Visible = true;
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ett fel inträffade då kontakten skulle läggas till.");
            }       
        }

        public void ContactListView_UpdateItem(int contactID)
        {
            try
            {
                var contact = Service.GetContact(contactID);
                if (contact == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", contactID));
                    return;
                }
            
                if(TryUpdateModel(contact))
                {
                    // Uppdaterar kontakten samt presenterar ett meddelande om att allt lyckats.
                    Service.SaveContact(contact);
                    StatusLitteral.Text = "Kontakten har uppdaterats!";
                    StatusMessage.Visible = true;
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ett fel inträffade då kontakten skulle uppdateras.");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_DeleteItem(int contactID)
        {
            try
            {
                // Raderar kontakten samt presenterar ett meddelande om att allt lyckats.
                Service.DeleteContact(contactID);
                StatusLitteral.Text = "Kontakten raderades!";
                StatusMessage.Visible = true;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då kontakten skulle raderas.");
            }
        }
    }
}