
using System.ComponentModel.DataAnnotations;
using Veam.Common.ViewModels;

namespace Veam.Suppliers.ViewModels
{
    public class VendorVM
    {
        public int vendorId { get; set; }

        public CompanyVM Company { get; set; }
        public CommunicationVM OfficeContact { get; set; }
        public AddressVM BillAddress { get; set; }

        [StringLength(255)]
        [Display(Name = "Description")]
        public string description { get; set; }

    }
    public class VendorSaveVM
    {
        public int vendorId { get; set; }

        [Required]
        [Display(Name = "Comapny")]
        public string RegisterCompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = " Gst Is Of 15 Digits")
            , MinLength(15, ErrorMessage = " Gst is Of 15 Digits")]
        public string GstNo { get; set; }

        public CommunicationVM OfficeContact { get; set; }
        public AddressVM BillAddress { get; set; }

        [StringLength(255)]
        [Display(Name = "Description")]
        public string description { get; set; }


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
    public class CommunicationVM
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
