using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Veam.Common.Domain;

namespace Veam.Purchases.Domain
{
    public class PurchaseOrder : AggregateRoot
    {
        public PurchaseOrder()
        {
          
            //this.IsActive = true;
            //this.createdAt = DateTime.UtcNow;
            //this.purchaseOrderNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#PO";
            //this.poDate = DateTime.UtcNow.Date;
            //this.deliveryDate = this.poDate.AddDays(5);
            //this.purchaseOrderStatus = PurchaseOrderStatus.Draft;
            //this.totalDiscountAmount = 0m;
            //this.totalOrderAmount = 0m;
        }

       
      
        public PONo poNo { get; set; }
        public DateTime poDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string deliveryAddress { get; set; }
        public string referenceNumberInternal { get; set; }
        public string referenceNumberExternal { get; set; }
        public string description { get; set; }
        public string picInternal { get; set; }
        public string picVendor { get; set; }
        public decimal totalDiscountAmount { get; set; }
        public decimal totalOrderAmount { get; set; }
        public string purchaseReceiveNumber { get; set; }

        public TOP top { get; set; }
        public PurchaseOrderStatus Status { get; set; }

        public string branchId { get; set; }
        public string vendorId { get; set; }
        //Nav And List

        //public Branch branch { get; set; }
        //public Vendor vendor { get; set; }
        public List<PurchaseOrderLine> purchaseOrderLine { get; set; } = new List<PurchaseOrderLine>();

        #region Status Checks
        public bool CanBeDeleted => Status.CurrentState != PurchaseOrderStatus.State.Shipped
                               && Status.CurrentState != PurchaseOrderStatus.State.Delivered;

        public bool IsApprovedOrLaterStatus => IsApproved || IsDelivered || IsShipped;
        public bool IsApproved => Status.CurrentState == PurchaseOrderStatus.State.Approved;
        public bool IsDelivered => Status.CurrentState == PurchaseOrderStatus.State.Delivered;
        public bool IsShipped => Status.CurrentState == PurchaseOrderStatus.State.Shipped;
        public bool IsCancelled => Status.CurrentState == PurchaseOrderStatus.State.Cancelled;
        public bool IsOpen => !IsCancelled && !IsDelivered;

        //public bool CanShipmentBeUpdated => Shipment == null ||
        //                                    (Shipment.Status.CurrentState != ShipmentStatus.State.Shipped &&
        //                                     Shipment.Status.CurrentState != ShipmentStatus.State.Delivered);

        public bool CanTransitionToPendingApproval => Status.PermittedTriggers.Contains(PurchaseOrderStatus.Trigger
            .PendingApproval);

        public bool CanTransitionToApproved => Status.PermittedTriggers.Contains(PurchaseOrderStatus.Trigger
            .Approved);

        public bool CanTransitionToCancelled => Status.PermittedTriggers.Contains(PurchaseOrderStatus.Trigger
            .Cancelled);

        #endregion
    }


    public class PurchaseOrderCommand
    {
        [StringLength(38)]
        [Display(Name = "Purchase Order Id")]
        public string purchaseOrderId { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "PO No")]
        public string purchaseOrderNumber { get; set; }

        [Display(Name = "Terms Of Payment")]
        public TOP top { get; set; }

        [Display(Name = "Po Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime poDate { get; set; }

        [Display(Name = "Delivery Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime deliveryDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Delivery Address")]
        public string deliveryAddress { get; set; }

        [StringLength(30)]
        [Display(Name = "Reference Documents (Internal)")]
        public string referenceNumberInternal { get; set; }

        [StringLength(30)]
        [Display(Name = "Reference Documents (External, Quote, PI)")]
        public string referenceNumberExternal { get; set; }

        [StringLength(100)]
        [Display(Name = "Discription")]
        public string description { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Center Name")]
        public string branchId { get; set; }

        [Display(Name = "Center")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Supplier")]
        public string vendorId { get; set; }

        [Display(Name = "Supplier")]
        public Vendor vendor { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Products(Internal)")]
        public string picInternal { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Venor Pic")]
        public string picVendor { get; set; }

        [Display(Name = " PO Status")]
        public PurchaseOrderStatus purchaseOrderStatus { get; set; }

        [Display(Name = "Total Discount Amount")]
        public decimal totalDiscountAmount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal totalOrderAmount { get; set; }

        [Display(Name = "Purchase Receive No")]
        public string purchaseReceiveNumber { get; set; }

        [Display(Name = "Purchase Order Lines")]
        public List<PurchaseOrderLine> purchaseOrderLine { get; set; } = new List<PurchaseOrderLine>();
    }
}
