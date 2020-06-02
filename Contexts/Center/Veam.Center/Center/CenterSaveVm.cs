using System;
using System.ComponentModel.DataAnnotations;

namespace Veam.Centers.ViewModels
{
    public class CenterSaveVm : CenterVM
    {
        public int buildingId { get; set; }
       // public SelectList buildingSelectList { get; set; }

        [Required]
        [Display(Name = "Center Type")]
        public int CenterTypeId { get; set; }

        [Required]
        [Display(Name = "Subsidery")]
        public int SubsideryId { get; set; }

        [StringLength(250)]
        [Display(Name = "Company Information")]
        public string description { get; set; }

        [Display(Name = "Tick If Head office?")]
        public bool isHO { get; set; } = false;

        [Display(Name = "Date Temp")]
        public DateTime TryDate { get; set; }

        public string user { get; set; }
    }
}
