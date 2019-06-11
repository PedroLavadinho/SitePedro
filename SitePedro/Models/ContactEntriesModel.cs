using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitePedro.Models
{
    public class ContactEntriesModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Display(Name = "Budget Level")]
        public BudgetLevel Budget { get; set; }

        [Display(Name = "Requirements")]
        public string Requirements { get; set; }
    }
}