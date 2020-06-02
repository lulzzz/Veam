using System;
using System.ComponentModel.DataAnnotations;
using Veam.Common.Domain;

namespace Veam.Purchases.Domain
{
    public class Product: AggregateRoot
    {
       
        #region Property
        public string productCode { get; set; }
        public string productName { get; set; }  
        public string description { get; set; }
        public ProductCategory productCategory { get; set; } 
        public ProductType productType { get; set; }
        public UOM uom { get; set; }
        #endregion
        protected Product() { }

        public Product(string productCode, string productName, 
            string description, ProductCategory productCategory, ProductType productType, UOM uom, string user)
        {
            this.productCode = productCode ?? throw new ArgumentNullException(nameof(productCode));
            this.productName = productName ?? throw new ArgumentNullException(nameof(productName));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            this.productCategory = productCategory;
            this.productType = productType;
            this.uom = uom;
            EntityCreateInfo(user);
        }
        public void Update(Guid Id, string productCode, string productName,
           string description, ProductCategory productCategory, ProductType productType, UOM uom, string user)
        {
            this.Id = Id;
            this.productCode = productCode ?? throw new ArgumentNullException(nameof(productCode));
            this.productName = productName ?? throw new ArgumentNullException(nameof(productName));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            this.productCategory = productCategory;
            this.productType = productType;
            this.uom = uom;
            EntityCreateInfo(user);
        }
    }

    public class ProductCommand
    {
        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }


        [StringLength(50)]
        [Display(Name = "Product Code")]
        [Required]
        public string productCode { get; set; }


        [StringLength(50)]
        [Display(Name = "Product Name")]
        [Required]
        public string productName { get; set; }

        [StringLength(50)]
        [Display(Name = "Product Discription")]
        public string description { get; set; }

        [Display(Name = "Product Category")]
        public ProductCategory productCategory { get; set; }


        [Display(Name = "Product Type")]
        public ProductType productType { get; set; }


        [Display(Name = "Unit Of Measure")]
        public UOM uom { get; set; }
    }
}
