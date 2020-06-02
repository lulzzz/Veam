using System.ComponentModel.DataAnnotations;

namespace Veam.Centers.ViewModels
{
    public class HallSaveVM 
    {
        public int HallId { get; set; }

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


        [Display(Name = "Center")]
        public int CenterId { get; set; }

        [StringLength(250)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string user { get; set; }

    }
}
