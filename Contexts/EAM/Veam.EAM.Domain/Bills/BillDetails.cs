using System;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EAM.Domain
{
    public class BillDetails : ValueObject<BillDetails>
    {
        public BillDetails(string billNo, DateTime billedDate)
        {
            this.billNo = billNo ?? throw new ArgumentNullException(nameof(billNo));
            this.billedDate = billedDate;
           
        }

        public string billNo { get; protected set; }
        public DateTime billedDate { get; protected set; }
      


        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}