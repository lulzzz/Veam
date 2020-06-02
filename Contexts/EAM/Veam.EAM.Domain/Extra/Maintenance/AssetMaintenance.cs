using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Veam.EAM.Domain
{
    public class AssetMaintenance 
    {
        public string Title { get; set; }

        public string AssetMaintanceType { get; set; }
        public bool isInWarranty { get; set; }


        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }
        public int assetMaintanceTime { get; set; }

        [DataType(DataType.Text)]
        public string discription { get; set; }

        #region Purchase and Warranty
        //Bill Details
        [Display(Name = "Po No")]
        public string PurchaseOrderNo { get; set; }

        [Display(Name = "Billed Date")]
        [DataType(DataType.Date)]
        public DateTime billedDate { get; set; }

        [Display(Name = "Billed Cost")]
        [DataType(DataType.Currency)]
        public decimal billedCost { get; set; }

        [Display(Name = "Bill Coppy")]
        public string billCopy { get; set; }

        //Warranty

        [Display(Name = "Warrenty in Months")]
        public int WarrantyMonths { get; set; }
        [Display(Name = "Warrenty Start Date")]
        public DateTime warrantyStartDate { get; set; }

        [Display(Name = "Warrenty End Date")]
        public DateTime warrantyEndDate { get; set; }

        [Display(Name = "Warrenty Covered By")]
        public string warrantyBy { get; set; }

        [Display(Name = "Note")]
        [DataType(DataType.Text)]
        public string Notes { get; set; }

        #endregion}

        // der
        public string UserId { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        public string servicevendorId { get; set; }
        public Supplier servicevendor { get; set; }
        public IEnumerable<Components> assetComponents { get; set; }
    }

}

