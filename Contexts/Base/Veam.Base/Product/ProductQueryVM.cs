using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Veam.Base.Domain;

namespace Veam.Base.ViewModels
{

    public class ProductQueryVM
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

        [Display(Name = "Product Type")]
        public ProductTypeVM productType { get; set; }

        [Display(Name = "Product Category")]
        public string productCategory { get; set; }


        public static Expression<Func<Product, ProductQueryVM>> Projection
        {
            get
            {
                return c => new ProductQueryVM
                {
                    productId =(int) c.Id,
                    CategoryId = c.CategoryId,
                    productCode=c.productCode,
                    productName=c.productName,
                    productCategory = c.productCategory.Category,
                   // productType.TypeName.ToString() = c.productType.TypeName.ToString(),
                        
                    //   Description = c.Description,
                    //Products = c.Products.AsQueryable()
                    //    .Select(ProductPreviewDto.Projection)
                    //    .Take(5)
                    //    .OrderBy(p => p.ProductName)
                    //    .ToList()
                };
            }
        }
    }


    public enum UOM
    {
        Pcs = 1,
        EA = 2,
        Kgs = 3,
        Liters = 4,
        Boxs = 5,
        Drums = 6,
        Unit = 7
    }

}
