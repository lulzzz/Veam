using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Veam.EAM.ViewModels
{
    public enum AssetConditons
    {
        New = 1,
        Excellent = 2,
        VGood = 3,
        Good = 4,
        Scraped = 5
    }
    public class ToLocationVM
    {
        public long subsideryId { get; set; }
        public long centerId { get; set; }
        public long hallId { get; set; }
        public long managerId { get; set; } 
    }

    public class ToEmpVM  
    {

        public long subsideryId { get; set; }
        public long employeeId { get;   set; }
        public long departmentId { get;   set; }
        //commmon

    }

    public class ToParentAssetVM
    { 
        public long parentAssetId { get;   set; } 
    }

    public class AssignmentInfoVM
    {
        public string assetConditon { get; set; }
        public string conditionNote { get; set; }
    }

    public class RequestInfoVM
    {  
        //request info
        public DateTime approveDate { get; set; }
        public string approvedBy { get;   set; }

        public DateTime requestedDate { get;   set; }
        public string requestedBy { get;   set; } 
    }
     
    public class CheckoutVM
    {
        public long checkoutId { get; set; } 
        public DateTime checkedOutDate { get;   set; }
        public string user { get; set; }
        //
        public RequestInfoVM requestInfo { get; set; }
        public long assetId { get;   set; }
        public AssignmentInfoVM assignInfo { get; set; }
        public ToLocationVM toLocation { get; set; }
        public ToEmpVM toEmp { get; set; }
        public ToParentAssetVM ToParent { get; set; }

        public IEnumerable<SelectListItem> subsideryList { get; set; }
        public IEnumerable<SelectListItem> EmpList { get; set; }
        public IEnumerable<SelectListItem>deptList { get; set; }
        public IEnumerable<SelectListItem> CenterList { get; set; }
        public IEnumerable<SelectListItem> HallList { get; set; }
        public IEnumerable<SelectListItem> pasrntAssetList { get; set; }
    }

    public class BulkCheckoutVM
    {
        public long checkoutId { get; set; } 
        public DateTime checkedOutDate { get; set; }
        public string user { get; set; }
        //
        public RequestInfoVM requestInfo { get; set; }
        public List<long> assetIdList { get; set; }
        public AssignmentInfoVM assignInfo { get; set; }
      
        public ToLocationVM toLocation { get; set; }
        public ToEmpVM toEmp { get; set; }
        public ToParentAssetVM ToParent { get; set; }

        public IEnumerable<SelectListItem> subsideryList { get; set; }
        public IEnumerable<SelectListItem> EmpList { get; set; }
        public IEnumerable<SelectListItem> deptList { get; set; }
        public IEnumerable<SelectListItem> CenterList { get; set; }
        public IEnumerable<SelectListItem> HallList { get; set; }
        public IEnumerable<SelectListItem> pasrntAssetList { get; set; }
    }
 
}
