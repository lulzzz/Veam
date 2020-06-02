using System;
using System.Collections.Generic;

namespace Veam.EAM.ViewModels
{
    public class AssetPurchaseQueryVM
    {
        public int assetpurchaseId { get; set; }

        public string notes { get; set; }
        //bill
        public string billNo { get; set; }
        public DateTime billedDate { get; set; }
        public virtual IEnumerable<AttachBillVM> purchaseFiles { get; set; }
    }
}