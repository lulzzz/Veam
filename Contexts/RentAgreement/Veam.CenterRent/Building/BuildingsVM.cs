
using System.ComponentModel.DataAnnotations;

namespace Veam.CenterRent.ViewModels
{
    /// <summary>
    /// A Building can have Many permises or Centers
    /// like Apsara arcade have many permises on rent and Iapl have two floors as center
    /// </summary>
    public class BuildingQueryVM 
    {
        public long buildingId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Building Name")]
        public string buildingName { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Building No must be of 2 digit")]
        [Display(Name = "Building No")]
        public string buildingNo { get; set; }

        [Display(Name = "Address")]
        public string Addressfull { get; set; }

    }

    public class BuildingSaveVM : BuildingQueryVM
    {
        public string user { get; set; }
        public AddressVM address { get; set; }

    }
    public class AddressVM
    {
        [Required]
        [StringLength(75)]
        [Display(Name = "Plot No")]
        public string Line1 { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "city")]
        public string City { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Please Enter 6 Digit Zip")]
        [Display(Name = "Zip")]
        public string Zip { get; set; }


    }

}
