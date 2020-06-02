//using System;
//using Veam.Domain.Core.Entity;
//using Veam.Domain.Core.ValueObjects;

//namespace Veam.EAM.Domain
//{

//    public class CheckOutToLocation3: CheckOut
//    {
//        public CheckOutToLocation3()
//        {

//        }
//        public long subsideryId { get; set; }
//        public long centerId { get; protected set; }
//        public long hallId { get; protected set; }
//        public long managerId { get; protected set; }
//        public CheckOutToLocation3(long CheckOutId, long CenterId, long HallId, long CompanyId, long ManagerId, long AssetId,
//           AssignmentInfo assignmentInfo,
//           RequestInfo requestinfo,
//           string user)

//        {
//            this.Id = CheckOutId;
//            this.assetId = AssetId;

//            LocationInfo3(CenterId, HallId, ManagerId, CompanyId);
//            this.assignmentInfo = new AssignmentInfo(assignmentInfo.assetConditon, assignmentInfo.conditionNote);
//            this.requestInfo = new RequestInfo(requestinfo.requestedBy, requestinfo.requestedDate,
//                                                requestinfo.approvedBy, requestinfo.approveDate, requestinfo.acceptedBy, requestinfo.checkedOutDate);
//            UpdateAuditInfo(user);
//        }

//        private void LocationInfo3(long BranchId, long LocationId, long ManagerId, long CompanyId)
//        {
//            this.centerId = BranchId;
//            this.hallId = LocationId;
//            this.managerId = ManagerId;
//            this.subsideryId = CompanyId;
//        }

//    }

//    public class CheckOutToEmployee3 : CheckOut
//    {
//        public CheckOutToEmployee3()
//        {

//        }
//        public long subsideryId { get; set; }
//        public long employeeId { get; protected set; }
//        public long managerId { get; protected set; }

//        public CheckOutToEmployee3(long CheckOutId, long CheckedOutToEmpId, long subsideryId, long AssetId,
//               AssignmentInfo assignmentInfo,
//           RequestInfo requestinfo,
//             string user)

//        {
//            this.Id = CheckOutId;
//            this.assetId = AssetId;
//            this.employeeId = CheckedOutToEmpId;
//            this.subsideryId = subsideryId;
//            this.assignmentInfo = new AssignmentInfo(assignmentInfo.assetConditon, assignmentInfo.conditionNote);
//            this.requestInfo = new RequestInfo(requestinfo.requestedBy, requestinfo.requestedDate,
//                requestinfo.approvedBy, requestinfo.approveDate, requestinfo.acceptedBy, requestinfo.checkedOutDate);
//            UpdateAuditInfo(user);
//        }

//    }

//    public class CheckOutToParentAsse3 : CheckOut
//    {
//        public CheckOutToParentAsse3()
//        {

//        }
//        public long parentAssetId { get; set; }

//        public CheckOutToParentAsse3(long CheckOutId, long ParentAssetId, long AssetId,
//           AssignmentInfo assignmentInfo,
//           RequestInfo requestinfo,
//            string user)

//        {
//            this.Id = CheckOutId;
//            this.parentAssetId = ParentAssetId;
//            this.assetId = AssetId;
//            this.assignmentInfo = new AssignmentInfo(assignmentInfo.assetConditon, assignmentInfo.conditionNote);
//            this.requestInfo = new RequestInfo(requestinfo.requestedBy, requestinfo.requestedDate,
//                requestinfo.approvedBy, requestinfo.approveDate, requestinfo.acceptedBy, requestinfo.checkedOutDate);

//            UpdateAuditInfo(user);
//        }
//    }

//    public class CheckOut3 : EntityBase
//    {
//        //Asset
//        public long assetId { get; protected set; }
//        public Asset asset { get; set; }
//        public AssignmentInfo assignmentInfo { get; set; }
//        //AssignmentInfo


//        //RequestProcess
//        public RequestInfo requestInfo { get; set; }

//        // for Return retired

//        public DateTime returnedDate { get; protected set; }
//        public DateTime? retiredDate { get; protected set; }

//        protected CheckOut3() { }

//        //


//    }

//    public class RequestInfo3 : ValueObject<AssetModel>
//    {
//        public RequestInfo3()
//        {

//        }
//        public DateTime checkedOutDate { get; protected set; }
//        public DateTime approveDate { get; set; }
//        public string approvedBy { get; private set; }
//        public string acceptedBy { get; protected set; }
//        public DateTime requestedDate { get; private set; }
//        public string requestedBy { get; private set; }

//        public RequestInfo3(string Requestedby, DateTime RequestedDate, string ApprovedBy, DateTime approveDate,
//              string AcceptedBy, DateTime CheckedoutDate)
//        {
//            this.requestedBy = requestedBy;
//            this.requestedDate = RequestedDate;
//            this.approvedBy = approvedBy;
//            this.approveDate = approveDate;
//            this.acceptedBy = acceptedBy;
//            this.checkedOutDate = CheckedoutDate;
//        }

//        public override string ToString()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class AssignmentInfo3 : ValueObject<AssetModel>
//    {
//        public string assetConditon { get; set; }
//        public string conditionNote { get; private set; }
//        public AssignmentStatus assignmentStatus { get; protected set; }

//        public AssignmentInfo3(string AssetConditon, string ConditionNote)
//        {
//            this.assetConditon = AssetConditon;
//            this.conditionNote = ConditionNote;
//            this.assignmentStatus = AssignmentStatus.Accepted;
//        }

//        public AssignmentInfo3()
//        {

//        }

//        public override string ToString()
//        {
//            throw new NotImplementedException();
//        }
//    }
//    public enum AssignmentStatus3
//    {
//        Requested = 1,
//        Approved = 2,
//        Accepted = 3,
//        Rejected = 4,
//        Returned = 5
//    }


//}
