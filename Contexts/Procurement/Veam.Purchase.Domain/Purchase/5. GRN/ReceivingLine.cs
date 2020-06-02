using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class ReceivingLine : INetcoreBasic
    {
        public ReceivingLine()
        {
            this.createdAt = DateTime.UtcNow;
            this.LotNo = receiving.receivingNumber + receivingLineId;
        }

        [StringLength(38)]
        [Display(Name = "Receiving Line Id")]
        public string receivingLineId { get; set; }

        public string LotNo { get; set; }

        [StringLength(38)]
        [Display(Name = "Receiving Id")]
        public string receivingId { get; set; }

        [Display(Name = "Receiving")]
        public Receiving receiving { get; set; }

        [StringLength(38)]
        [Display(Name = "Branch Id")]
        public string branchId { get; set; }

        [Display(Name = "Branch")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Display(Name = "Warehouse Id")]
        public string warehouseId { get; set; }

        [Display(Name = "Warehouse")]
        public Warehouse warehouse { get; set; }

        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Qty Order")]
        public float qty { get; set; }

        [Display(Name = "Qty Receive")]
        public float qtyReceive { get; set; }

        [Display(Name = "Qty Inventory")]
        public float qtyInventory { get; set; }
    }
}
