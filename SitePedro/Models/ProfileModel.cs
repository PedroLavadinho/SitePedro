using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SitePedro.Models
{
    public class ProfileModel
    {
        [Display(Name = "NameandSurname")]
        public string NameandSurname { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public string Birthday { get; set; }

        [Display(Name = "Weight")]
        public int? Weight { get; set; }

        [Display(Name = "Height")]
        public int? Height { get; set; }

        [Display(Name = "Hair Color")]
        public string HairColor { get; set; }

        [Display(Name = "Eye Color")]
        public string EyeColor { get; set; }

        [Display(Name = "ImagemParaCarregar")]
        public HttpPostedFileBase ImagemParaCarregar { get; set; }

        [Display(Name = "ImagemUrl")]
        public string ImagemUrl { get; set; }
    }
}