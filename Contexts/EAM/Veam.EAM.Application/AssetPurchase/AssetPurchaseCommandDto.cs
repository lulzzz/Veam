using System;

namespace Veam.EAM.Application
{
    public class AssetPurchaseCommandDto
    {
        
        public string notes { get; set; }
        //bill
        public string billNo { get; set; }
        public DateTime billedDate { get; set; }
        //files
       
        // nav
        public long vendorId { get; set; }

    }
}
