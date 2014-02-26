using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    // Klass för mitt kontaktobjekt, använder dataannotations för att validera indata.
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "En epostadress måste anges.")]
        [StringLength(50)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage="Ett förnamn måste anges.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Ett efternamn måste anges.")]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}