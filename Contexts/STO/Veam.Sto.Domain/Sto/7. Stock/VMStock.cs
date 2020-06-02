using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class VMStock
    {
        [Display(Name = "Product")]
        public string Product { get; set; }
        [Display(Name = "Warehouse")]
        public string Warehouse { get; set; }
        [Display(Name = "Qty PO")]
        public float QtyPO { get; set; }// Goods Ordered
        [Display(Name = "Qty Receiving")]
        public float QtyReceiving { get; set; }//Goods Receiver
        [Display(Name = "Qty SO")]
        public float QtySO { get; set; } //Goods sold
        [Display(Name = "Qty Shipment")]
        public float QtyShipment { get; set; }//In Shipment Goods
        [Display(Name = "Qty Transfer In")]
        public float QtyTransferIn { get; set; }//Goods Move in From other Center
        [Display(Name = "Qty Transfer Out")]
        public float QtyTransferOut { get; set; }//Goods Move out From other Center
        [Display(Name = "Qty On Hand")]
        public float QtyOnhand { get; set; }//In Hand Goods
    }
}
