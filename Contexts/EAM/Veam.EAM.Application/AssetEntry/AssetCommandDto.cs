using System;

namespace Veam.EAM.Application
{
    public class AssetCommandDto
    {
        public string assetName { get; private set; }
        public string assetTag { get; set; }
        public string serialNo { get; set; }
        //modal
        public string modalname { get; private set; }
        public string modalnumber { get; private set; }
        public string brand { get; private set; }
        public string product { get; private set; }
        //nav
        public int statusId { get; set; }
        public int assetPurchaseId { get; protected set; }
    }

    public class WarrantyUpdateDto
    {
        public long AssetId { get; set; } 
        public int periodinMonths { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string warrantyBy { get; protected set; }
        public string notes { get; protected set; }

        public string user { get; set; }
    }
}
