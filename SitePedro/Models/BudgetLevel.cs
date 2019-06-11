using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitePedro.Models
{
    public enum BudgetLevel
    {
        [Display(Name = "Your Budget Level")]
        BudgetPlaceholder,

        [Display(Name = "100€ to 1,000€")]
        BudgetOne,

        [Display(Name = "1,000€ to 2,500€")]
        BudgetTwo,

        [Display(Name = "2,500€ to 5,000€")]
        BudgetThree,

        [Display(Name = "5,000€ to 10,000€")]
        BudgetFour,

        [Display(Name = "10,000€ or more")]
        BudgetFive
    }
}