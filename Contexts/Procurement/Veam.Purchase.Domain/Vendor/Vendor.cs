using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veam.Core.Domain
{
    public class Vendor 
    {
        public Vendor()
        {
          
        }

        [StringLength(38)]
        [Display(Name = "Supplier Id")]
        public string vendorId { get; set; }

        [StringLength(50)]
        [Display(Name = "Company Name")]
        [Required]
        public string vendorName { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string description { get; set; }
        
        [Display(Name = "Business Size")]
        public BusinessSize size { get; set; }
        
        //IbaseAddress
        [Display(Name = "Plot No")]
        [Required]
        [StringLength(50)]
        public string street1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(50)]
        public string street2 { get; set; }

        [Display(Name = "city")]
        [StringLength(30)]
        public string city { get; set; }

        [Display(Name = "State")]
        [StringLength(30)]
        public string province { get; set; }

        [Display(Name = "country")]
        [StringLength(30)]
        public string country { get; set; }
        //IBaseAddress
        [StringLength(30)]
        public string Zip { get; set; }

        private string Add;
        [Display(Name = "Address")]
        public string Addressfull
        {
            get
            {

                Add = street1 + " " + street2 + "," + city + "," + province + "-" + Zip;
                return Add;
            }

        }

        [Display(Name = "Company Contacts")]
        public List<VendorLine> vendorLine { get; set; } = new List<VendorLine>();
    }
}
