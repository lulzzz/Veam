using System;
using Veam.EAM.Domain;

namespace Veam.EAM.Application
{
    public class CheckOutCommandDto
    {
        public long checkoutId { get; set; }
        //common for checkOut
     
        public DateTime checkedOutDate { get; protected set; }
        //asignmentinfo
        public string assetConditon { get; set; }
        public string conditionNote { get; private set; }
        //request info
        public DateTime approveDate { get; set; }
        public string approvedBy { get; private set; } 
        public DateTime requestedDate { get; private set; }
        public string requestedBy { get; private set; }
    }
}
