using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Veam.Common.Domain;

namespace Veam.Purchases.Domain
{
    public class PurchaseOrderLine : EntityBase
    {
        public PurchaseOrderLine()
        {
            this.createdAt = DateTime.UtcNow;
            this.discountAmount = 0m;
            this.totalAmount = 0m;
        }

        public string purchaseOrderLineId { get; set; } 
        public float qty { get; set; } 
        public decimal price { get; set; } 
        public decimal discountAmount { get; set; } 
        public decimal totalAmount { get; set; }

        public string purchaseOrderId { get; set; }
        public string productId { get; set; }
        //Nav Property

        public Product product { get; set; }
        public PurchaseOrder purchaseOrder { get; set; }
    }

    public class PurchaseOrderLineCommand
    {
        [StringLength(38)]
        [Display(Name = "Purchase Order Line Id")]
        public string purchaseOrderLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Purchase Order Id")]
        public string purchaseOrderId { get; set; }

        [Display(Name = "Purchase Order")]
        public PurchaseOrder purchaseOrder { get; set; }

        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Quantity")]
        public float qty { get; set; }

        [Display(Name = "Price")]
        public decimal price { get; set; }

        [Display(Name = "Discount Amount")]
        public decimal discountAmount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal totalAmount { get; set; }
    }
}
