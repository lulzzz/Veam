using System.ComponentModel.DataAnnotations;

namespace Barebone.ViewModels
{
    public class Communication2VM
    {
       
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please Enter 10 Mobile No")]
        [Display(Name = "Mobile No")]
        public string mobilePhone { get; set; }
        
        [StringLength(15)]
        [Display(Name = "Office Phone")]
        public string officePhone { get; set; }
       
       
        [StringLength(75)]
        [EmailAddress]
        [Display(Name = "Personal Email")]
        public string personalEmail { get; set; }

       
        [StringLength(75)]
        [EmailAddress]
        [Display(Name = "Office Email")]
        public string workEmail { get; set; }

    }
}
