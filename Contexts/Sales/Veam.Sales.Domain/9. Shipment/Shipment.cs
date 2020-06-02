using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class Shipment : INetcoreMasterChild
    {
        public Shipment()
        {
            this.createdAt = DateTime.UtcNow;
            this.shipmentNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#DO";
            this.shipmentDate = DateTime.UtcNow;
            this.expeditionType = ExpeditionType.Internal;
            this.expeditionMode = ExpeditionMode.Land;
        }

        [StringLength(38)]
        [Display(Name = "Shipment Id")]
        public string shipmentId { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "SO No")]
        public string salesOrderId { get; set; }

        [Display(Name = " SO")]
        public SalesOrder salesOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "DO No")]
        public string shipmentNumber { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        public DateTime shipmentDate { get; set; }

        [StringLength(38)]
        [Display(Name = "Customer")]
        public string customerId { get; set; }

        [Display(Name = "Customer")]
        public Customer customer { get; set; }

        [StringLength(50)]
        [Display(Name = "customer PO")]
        public string customerPO { get; set; }

        [StringLength(50)]
        [Display(Name = "Invoice No")]
        public string invoice { get; set; }

        [StringLength(38)]
        [Display(Name = "Center")]
        public string branchId { get; set; }

        [Display(Name = "Center")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Halls")]
        public string warehouseId { get; set; }

        [Display(Name = "Halls")]
        public Warehouse warehouse { get; set; }

        [Display(Name = "expedition Type")]
        public ExpeditionType expeditionType { get; set; }

        [Display(Name = "expedition Type")]
        public ExpeditionMode expeditionMode { get; set; }

        [Display(Name = "Shipment Lines")]
        public List<ShipmentLine> shipmentLine { get; set; } = new List<ShipmentLine>();
    }
}
