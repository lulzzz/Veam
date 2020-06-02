using System.ComponentModel.DataAnnotations;

namespace Veam.Base.ViewModels
{
    public class ProductSaveVM
    {

        public int productId { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Product Code")]
        public string productCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [StringLength(50)]
        [Display(Name = "Product Discription")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public int TypeId { get; set; }

        [Required]
        [Display(Name = "Unit Of Measure")]
        public UOM uom { get; set; }
        public string user { get; set; }
    }

}
