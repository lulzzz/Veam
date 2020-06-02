using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Veam.EAM.Application;

namespace Veam.EAM.ViewModels
{
    public class AssetSaveVM : Profile
    {
        public AssetSaveVM()
        {
            CreateMap<AssetSaveVM, AddNewAssetCommand>()
            .ForMember(d => d.modalnumber, o => o.MapFrom(s => s.modelNo))
                           ;
        }

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
    }

}
