using System.ComponentModel.DataAnnotations;

namespace SitePedro.Models
{
    public class ChangeUsernameModel
    {
        [Display(Name = "New Username")]
        [Required]
        public string NewUsername { get; set; }

        [Display(Name = "Confirm Username")]
        [Required]
        public string ConfirmUsername { get; set; }
    }
}