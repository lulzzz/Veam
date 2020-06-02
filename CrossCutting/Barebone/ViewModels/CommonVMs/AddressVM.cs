using System.ComponentModel.DataAnnotations;


namespace Barebone.ViewModels
{
    // /// <summary>
    /// Country should be implemented in only required class!
    ///Properties  Line1, Line2, city, State, Zip(6 digit)
    /// </summary>
    public class Address2VM
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
