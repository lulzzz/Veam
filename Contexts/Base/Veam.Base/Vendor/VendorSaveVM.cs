using System.ComponentModel.DataAnnotations;

namespace Veam.Base.ViewModels
{
    public class VendorSaveVM
    {
        public int vendorId { get; set; }

        public string RegisterCompanyName { get; set; }
   

        [Required]
        [MaxLength(15, ErrorMessage = " Gst Is Of 15 Digits")
           , MinLength(15, ErrorMessage = " Gst is Of 15 Digits")]
        public string GstNo { get; set; }
        public string description { get; set; }
        //communication
        public string mobilePhone { get; set; }
        public string officePhone { get; set; }
        public string personalEmail { get; set; }
        public string workEmail { get; set; }
        //bill Address
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        //
        public string country { get; set; } 
        public string user { get; set; }
    }
}