using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class TransferOut : INetcoreMasterChild
    {
        public TransferOut()
        {
            this.createdAt = DateTime.UtcNow;
            this.transferOutNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#OUT";
            this.transferOutDate = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Transfer Out Id")]
        public string transferOutId { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Transfer Order Id")]
        public string transferOrderId { get; set; }

        [Display(Name = "Transfer order")]
        public TransferOrder transferOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Transfer Out (TO)")]
        public string transferOutNumber { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Transfer Out Date(TO)")]
        public DateTime transferOutDate { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        

        [StringLength(38)]
        [Display(Name = "Branch From ID")]
        public string branchIdFrom { get; set; }

        [Display(Name = "Branch From")]
        public Branch branchFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "Warehouse From ID")]
        public string warehouseIdFrom { get; set; }

        [Display(Name = "Warehouse From")]
        public Warehouse warehouseFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "Branch To Id")]
        public string branchIdTo { get; set; }

        [Display(Name = "Branch To")]
        public Branch branchTo { get; set; }

        [StringLength(38)]
        [Display(Name = "Warehouse Id")]
        public string warehouseIdTo { get; set; }

        [Display(Name = "Warehouse To")]
        public Warehouse warehouseTo { get; set; }

        [Display(Name = "Transfer Out Lines")]
        public List<TransferOutLine> transferOutLine { get; set; } = new List<TransferOutLine>();
    }
}
