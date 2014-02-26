using AdventurousContacts.Models;
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
            // Om en session av typen success finns skall ett meddelande med dess innehåll visas.
            if (Session["Success"] != null)
            {
                StatusLitteral.Text = Session["Success"].ToString();
                StatusMessage.Visible = true;
                Session.Remove("Success");
            }            
        }

        // Hämtar ut alla kontakter utan paginering.
        //public IEnumerable<Contact> ContactListView_GetData()
        //{
        //    return Service.GetContacts();
        //}

        // Hämtar ut alla kontakter med paginering.
        public IEnumerable<Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        // Lägger till en medlem i databasen.
        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lägger till kontakten i databasen, samt presenterar ett meddelande om att allt lyckats.
                    Service.SaveContact(contact);
                    Session["Success"] = "Kontakten lades till!";
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ett fel inträffade då kontakten skulle läggas till.");
                }   
            }              
        }

        // Uppdaterar en medlem i databasen.
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
                    Session["Success"] = "Kontakten har uppdaterats!";
                    Response.Redirect(Request.UrlReferrer.ToString());
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
                Session["Success"] = "Kontakten har raderats!";
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då kontakten skulle raderas.");
            }
        }
    }
}