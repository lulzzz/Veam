using System.ComponentModel.DataAnnotations;

namespace Veam.Centers.ViewModels
{
    public class CenterVM
    {
        public long CenterId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Center Name")]
        public string CenterName { get; set; }
    }
    public class CenterQueryVm : CenterVM
    {
        public string buildingName { get; set; }

        public string buildingNo { get; set; }
        public string Addressfull { get; set; }

        [Display(Name = "Center Type")]
        public string CenterType { get; set; }

        [Display(Name = "Subsidery")]
        public string Subsidery { get; set; }

        [StringLength(50)]
        [Display(Name = "Information")]
        public string description { get; set; }

        [Display(Name = "Head Office")]
        public bool isHO { get; set; }
    }

    public class BuildingLookUP
    {
        public long Id { get; set; }
        public string BuildingName { get; set; }
    }
}
