using System;
using System.ComponentModel.DataAnnotations;

namespace Veam.EAM.ViewModels
{
    public class AssetQueryVM
    {

        public long assetId { get; set; }

        [Required]
        [Display(Name = "Asset Discription")]
        public string assetName { get; set; }

        [Display(Name = "Asset Tag")]
        public string assetTag { get; set; }

        [Display(Name = "Serial")]
        public string serialNo { get; set; } 

        //modal
        public string modalname { get; set; }

        [Display(Name = " ModelNo")]
        public string modelNo { get; set; }

        [Display(Name = " Brand")]
        public string brand { get; set; }

        public string product { get; set; }

        //nav
        public string status { get; set; }
    }
    public class AssetQr
    {
        public int assetId { get; set; }
        public string assetTag { get; set; }
        public string serialNo { get; set; }
        public string qrcode { get; set; }
    }
}
