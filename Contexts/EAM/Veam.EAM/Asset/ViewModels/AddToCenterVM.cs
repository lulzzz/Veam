using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veam.EAM.ViewModels
{
    public class AddToCenterVM
    {
        public long assetId { get; set; }

        [Required]
        [Display(Name = "Asset Discription")]
        public string assetName { get; set; }

        [Display(Name = "Asset Tag")]
        public string assetTag { get; set; }

        [Display(Name = "Serial")]
        public string serialNo { get; set; }

        [Display(Name = "Qrcode")]
        public string qrcode { get; set; }

        //modal
        public string modalname { get; set; }

        [Display(Name = " ModelNo")]
        public string modelNo { get; set; }

        [Display(Name = " Brand")]
        public string brand { get; set; }

        public string product { get; set; }

        //nav
        public int statusId { get; set; }

        [Required]
        [Display(Name = "Bills Details")]
        public int assetPurchaseId { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public string user { get; set; }

        public long centerId { get; set; }
        public IEnumerable<SelectListItem> center { get; set; }

        public long hallId { get; set; }
        public IEnumerable<SelectListItem> Hall { get; set; }
    }
}
