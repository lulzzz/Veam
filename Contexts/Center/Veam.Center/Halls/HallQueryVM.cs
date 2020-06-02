using System.ComponentModel.DataAnnotations;

namespace Veam.Centers.ViewModels
{
    public class HallQueryVM 
    {
        public long HallId { get; set; }

        [Required]
        [Display(Name = "Hall No")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "This field must be 3 characters")]
        public string HallNo { get; set; }

        [Required]
        [Display(Name = "Floor No")]
        public string FloorNo { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Class/office Name")]
        public string hallName { get; set; }

       
        public string CenterName { get; set; }

    }
}
