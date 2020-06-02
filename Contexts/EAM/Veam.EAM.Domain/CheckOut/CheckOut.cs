using System;
using Veam.Domain.Core.Entity;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EAM.Domain
{ 
    public class CheckOut : EntityBase
    {
        public DateTime checkedOutDate { get; protected set; }
        //Asset
        public long assetId { get; protected set; }
        public Asset asset { get; set; }
        //vo
        public RequestInfo requestInfo { get; set; }
        public AssignmentInfo assignmentInfo { get; set; }

        public CheckOutToLocation toLocation { get; set; }
        public CheckOutToEmployee toEmployee { get; set; }
        public CheckOutToParentAsset toParentAsset { get; set; } 

        // for Return retired

        public DateTime returnedDate { get; protected set; }
        public DateTime? retiredDate { get; protected set; }

        public CheckOut() { }

        /// <summary>
        /// for adding new checkout, for update command, implement checkout.Id= rq.checkoutid and then update the entity
        /// </summary> 
        /// <param name="checkoutdate"></param>
        /// <param name="AssetId"></param>
        /// <param name="toloc"></param>
        /// <param name="assignmentInfo"></param>
        /// <param name="requestinfo"></param>
        /// <param name="user"></param>
        public void CheckOutToLocation( DateTime checkoutdate, long AssetId, 
          CheckOutToLocation toloc, 
          AssignmentInfo assignmentInfo,
          RequestInfo requestinfo,
          string user)

        { 
            this.assetId = AssetId;
            this.checkedOutDate = checkoutdate;
           this.toLocation= new CheckOutToLocation(toloc.centerId, toloc.hallId, toloc.managerId, toloc.subsideryId);
            this.assignmentInfo = new AssignmentInfo(assignmentInfo.assetConditon, assignmentInfo.conditionNote);
            this.requestInfo = new RequestInfo(requestinfo.requestedBy, requestinfo.requestedDate,
                                                requestinfo.approvedBy, requestinfo.approveDate );
            UpdateAuditInfo(user);
        }
        /// <summary>
        /// for adding new checkout, for update command, implement checkout.Id= rq.checkoutid and then update the entity
        /// </summary>
        /// <param name="AssetId"></param>
        /// <param name="checkoutdate"></param>
        /// <param name="toEmp"></param>
        /// <param name="assignmentInfo"></param>
        /// <param name="requestinfo"></param>
        /// <param name="user"></param>
        public void CheckOutToEmployee( long AssetId, DateTime checkoutdate, CheckOutToEmployee toEmp,
              AssignmentInfo assignmentInfo,
          RequestInfo requestinfo,
            string user)

        {
           
            this.assetId = AssetId;
            this.checkedOutDate = checkoutdate;
            this.toEmployee = new CheckOutToEmployee(toEmp.subsideryId, toEmp.employeeId, toEmp.departmentId);
         
            this.assignmentInfo = new AssignmentInfo(assignmentInfo.assetConditon, assignmentInfo.conditionNote);
            this.requestInfo = new RequestInfo(requestinfo.requestedBy, requestinfo.requestedDate,
                requestinfo.approvedBy, requestinfo.approveDate );
            UpdateAuditInfo(user);
        }


        /// <summary>
        /// for adding new checkout, for update command, implement checkout.Id= rq.checkoutid and then update the entity
        /// </summary>
        /// <param name="CheckOutId"></param>
        /// <param name="checkoutdate"></param>
        /// <param name="ParentAssetId"></param>
        /// <param name="AssetId"></param>
        /// <param name="assignmentInfo"></param>
        /// <param name="requestinfo"></param>
        /// <param name="user"></param>
        public void CheckOutToParentAsset( DateTime checkoutdate, long ParentAssetId, long AssetId,
         AssignmentInfo assignmentInfo,
         RequestInfo requestinfo,
          string user)

        {
            
            this.checkedOutDate = checkoutdate;
            this.assetId = AssetId;
            this.toParentAsset = new CheckOutToParentAsset(ParentAssetId); 
            this.assignmentInfo = new AssignmentInfo(assignmentInfo.assetConditon, assignmentInfo.conditionNote);
            this.requestInfo = new RequestInfo(requestinfo.requestedBy, requestinfo.requestedDate,
                requestinfo.approvedBy, requestinfo.approveDate ) ;

            UpdateAuditInfo(user);
        }

    }



    public class RequestInfo : ValueObject<RequestInfo>
    { 
        public DateTime approveDate { get; set; }
        public string approvedBy { get; private set; }
     
        public DateTime requestedDate { get; private set; }
        public string requestedBy { get; private set; }

        public RequestInfo(string requestedBy, DateTime requestedDate, string approvedBy, DateTime approveDate)

        {
            this.requestedBy = requestedBy;
            this.requestedDate = requestedDate;
            this.approvedBy = approvedBy;
            this.approveDate = approveDate; 
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    public class AssignmentInfo : ValueObject<AssignmentInfo>
    {
        public string assetConditon { get; private set; }
        public string conditionNote { get; private set; }
        public AssignmentStatus assignmentStatus { get; protected set; }

        public AssignmentInfo(string assetConditon, string conditionNote)
        {
            this.assetConditon = assetConditon;
            this.conditionNote = conditionNote;
            this.assignmentStatus = AssignmentStatus.Accepted;
        }

     

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
    public enum AssignmentStatus
    {
        Requested = 1,
        Approved = 2,
        Accepted = 3,
        Rejected = 4,
        Returned = 5
    }

    public class CheckOutToLocation : ValueObject<CheckOutToLocation>
    {
      
        public long subsideryId { get; set; }
        public long centerId { get; protected set; }
        public long hallId { get; protected set; }
        public long managerId { get; protected set; }
       

        public   CheckOutToLocation(long centerId, long hallId, long managerId, long subsideryId)
        {
            this.centerId = centerId;
            this.hallId = hallId;
            this.managerId = managerId;
            this.subsideryId = subsideryId;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    public class CheckOutToEmployee : ValueObject<CheckOutToEmployee> 
    {
        public CheckOutToEmployee(long subsideryId, long employeeId, long departmentId)
        {
            this.subsideryId = subsideryId;
            this.employeeId = employeeId;
            this.departmentId = departmentId;
        }

        public long subsideryId { get; set; }
        public long employeeId { get; protected set; }
        public long departmentId { get; protected set; }

       

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    public class CheckOutToParentAsset : ValueObject<CheckOutToParentAsset>
    {
        public CheckOutToParentAsset(long parentAssetId)
        {
            this.parentAssetId = parentAssetId;
        }

        public long parentAssetId { get; set; }

      

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
