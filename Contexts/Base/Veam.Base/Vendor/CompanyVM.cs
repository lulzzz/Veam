using Barebone.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Veam.Common.ViewModels
{
    /// <summary>
    /// VM for Comapny Details,
    /// contact person Details Excluded
    /// </summary>
    public class CompanyVM
    {

        [Required]
        [Display(Name ="Comapny")]
        public string RegisterCompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = " Gst Is Of 15 Digits")
            , MinLength(15, ErrorMessage = " Gst is Of 15 Digits")]
        public string GstNo { get; set; }

      
    }
   
}
