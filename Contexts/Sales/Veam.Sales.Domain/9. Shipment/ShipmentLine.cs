using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class ShipmentLine : INetcoreBasic
    {
        public ShipmentLine()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Shipment Line Id")]
        public string shipmentLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Shipment Id")]
        public string shipmentId { get; set; }

        [Display(Name = "Shipment")]
        public Shipment shipment { get; set; }

        [StringLength(38)]
        [Display(Name = "center")]
        public string branchId { get; set; }

        [Display(Name = "center")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Display(Name = "Halls")]
        public string warehouseId { get; set; }

        [Display(Name = "Halls")]
        public Warehouse warehouse { get; set; }

        [StringLength(38)]
        [Display(Name = "product")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Quantity")]
        public float qty { get; set; }

        [Display(Name = "Shipment Quantity")]
        public float qtyShipment { get; set; }

        [Display(Name = "Quantity in Stock")]
        public float qtyInventory { get; set; }
    }
}
