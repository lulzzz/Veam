using System;

namespace Veam.EAM.ViewModels
{
    public class AssetWarrantyVM
    {
        public long assetId { get; set; }
        public string user { get; set; }


        public int periodinMonths { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string warrantyBy { get; set; }
        public string notes { get; set; }
    }
}
