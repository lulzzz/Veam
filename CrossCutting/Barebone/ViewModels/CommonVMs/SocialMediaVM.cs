using System.ComponentModel.DataAnnotations;

namespace Barebone.ViewModels
{
    public class SocialMedia2VM
    {
        [Display(Name = "Blog")]
        [StringLength(100)]
        public string blog { get; set; }

        [Display(Name = "Website")]
        [StringLength(100)]
        public string website { get; set; }

        [Display(Name = "Linkedin")]
        [StringLength(100)]
        public string linkedin { get; set; }
    }
}
