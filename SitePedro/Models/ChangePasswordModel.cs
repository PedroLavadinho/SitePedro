using System.ComponentModel.DataAnnotations;

namespace SitePedro.Models
{
    public class ChangePasswordModel
    {
        [Display(Name = "Old Password")]
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "New Password")]
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}