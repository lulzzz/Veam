using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Veam.EAM.ViewModels
{
    public class AssetPurchaseSaveVM
    {
        public string user { get; set; }
        public int assetpurchaseId { get; set; }
        //bill
        public string notes { get; set; }
        public string billNo { get; set; }
        public DateTime billedDate { get; set; }
        public List<AssetDetailsVM> assets { get; set; }
        // nav
        public long vendorId { get; set; }
        public long? centerId { get; set; }
        public long? hallid { get; set; }
        public long? assetId { get; set; }
        //to Store data
       
        public   List<AttachBillVM> purchaseFiles { get; set; }
        //dropDown
        public IEnumerable<SelectListItem> VendorList { get; set; }
        public IEnumerable<SelectListItem> CenterList { get; set; }
        public IEnumerable<SelectListItem> HallList { get; set; }
        public IEnumerable<SelectListItem> AssetCategoriesList { get; set; }
        public IEnumerable<SelectListItem> AssetList { get; set; }
       
    }
    public class AssetDetailsVM
    {
        public long assetId { get; set; }
        //public long AssetpurchaseId { get; set; } 
        //public string assetName { get; set; }

        //public string assetTag { get; set; }

        //public string serialNo { get; set; }

        //public long CenterId { get; set; }
        //public long HallId { get; set; }
    }
}