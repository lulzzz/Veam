using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veam.EAM.Domain
{
    public class Accessory
    {
        public string name { get; set; }

        [Display(Name = "Model Number")]
        public string modelNumber { get; set; }
        public string productId { get; set; }
        public Product product { get; set; }

        [Display(Name = "Manufacturer")]
        public int manufacturerId { get; set; }
        public Manufacturer manufacturer { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }


        [Display(Name = "Min Qty.")]
        public int minAmt { get; set; }
        public int qty { get; set; }

        public bool requestable { get; set; }

        public string locatonId { get; set; }
        public Location location { get; set; }

      

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

        [Display(Name = "Warrenty in Months")]
        public int warrantyMonths { get; set; }
        [Display(Name = "Warrenty Start Date")]
        public DateTime warrantyStartDate { get; set; }

        [Display(Name = "Warrenty End Date")]
        public DateTime warrantyEndDate { get; set; }

        [Display(Name = "Warrenty Covered By")]
        public string warrantyBy { get; set; }

        [Display(Name = "Note")]
        [DataType(DataType.Text)]
        public string notes { get; set; }

        #endregion

    }
}
