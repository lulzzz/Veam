using System.ComponentModel.DataAnnotations;

namespace Veam.EAM.Domain
{
    public class LicenseSeat 
    {
        public int licenseId { get; set; }
        public License license { get; set; }

        [Display(Name = "Asset")]
        public int assetId { get; set; }
        public Asset asset { get; set; }

        public int assignTo { get; set; }
        public int userId { get; set; }

        [Display(Name = "Note")]
        [DataType(DataType.Text)]
        public string note { get; set; }

       
    }
}
