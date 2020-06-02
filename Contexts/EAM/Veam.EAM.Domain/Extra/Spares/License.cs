using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veam.EAM.Domain
{
    public class License 
    {
        [Display(Name = "Software Name")]
        public string name { get; set; }

        public string licenseName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string licenseEmail { get; set; }

        [Display(Name = "Category Name")]
        [ForeignKey("Category")]
        public string productId { get; set; }
        public Product product { get; set; }

        [Display(Name = "Product Key")]
        public string serial { get; set; }

        [Display(Name = "Manufacturer")]
        public int manufacturerId { get; set; }
        public Manufacturer manufacturer { get; set; }

        [Display(Name = "Seats")]
        public int seats { get; set; }

        [Display(Name = "Note")]
        [DataType(DataType.Text)]
        public string notes { get; set; }

        [Display(Name = "Maintained")]
        public bool maintained { get; set; }

        [Display(Name = "Reassignable")]
        public bool reassignable { get; set; }

        #region Purchase and Warranty
        //Bill Details
        [Display(Name = "Po No")]
        public string purchaseOrderNo { get; set; }

        [Display(Name = "Billed Date")]
        [DataType(DataType.Date)]
        public DateTime billedDate { get; set; }

        [Display(Name = "Billed Cost")]
        [DataType(DataType.Currency)]
        public decimal billedCost { get; set; }

        [Display(Name = "Bill Coppy")]
        public string billCopy { get; set; }

        [ForeignKey("Vendor")]
        public string vendorId { get; set; }
        public virtual Supplier vendor { get; set; }

        //Warranty

        [Display(Name = "Validity in Months")]
        public int validityMonths { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Termination Date")]
        [DataType(DataType.Date)]
        public DateTime TerminationDate { get; set; }

       
        

        #endregion


    }
}
