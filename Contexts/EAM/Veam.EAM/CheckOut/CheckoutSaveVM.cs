using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Veam.EAM.ViewModels
{
    public class CheckoutSaveVM
    {
        public long checkoutId { get; set; }
        public DateTime checkedOutDate { get; set; }
        public string user { get; set; }
        //request info
        public DateTime approveDate { get; set; }
        public string approvedBy { get; set; }

        public DateTime requestedDate { get; set; }
        public string requestedBy { get; set; }
        public long assetId { get; set; }
        //AssignmentInfo
        public string assetConditon { get; set; }
        public string conditionNote { get; set; }
        //to Location
        public long subsideryId { get; set; }
        public long centerId { get; set; }
        public long hallId { get; set; }
        public long managerId { get; set; }
        //  ToEmpVM  
        public long empsubsideryId { get; set; }
        public long employeeId { get; set; }
        public long departmentId { get; set; }
        public long parentAssetId { get; set; }
        public IEnumerable<SelectListItem> subsideryList { get; set; }
        public IEnumerable<SelectListItem> EmpList { get; set; }
        public IEnumerable<SelectListItem> deptList { get; set; }
        public IEnumerable<SelectListItem> CenterList { get; set; }
        public IEnumerable<SelectListItem> HallList { get; set; }
        public IEnumerable<SelectListItem> pasrntAssetList { get; set; }
    }
 
}
