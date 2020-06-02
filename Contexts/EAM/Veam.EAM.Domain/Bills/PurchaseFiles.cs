using System;
using System.Collections.Generic;
using System.Text;

namespace Veam.EAM.Domain
{
    public class PurchaseFiles
    {
        public long AssetpurchaseId { get; set; }
        public long FileId { get; set; }

        //One to Many UserFiles Relationships
        public virtual AssetPurchase AssetPurchase { get; set; }
        public virtual FileDetails File { get; set; }
    }
}
