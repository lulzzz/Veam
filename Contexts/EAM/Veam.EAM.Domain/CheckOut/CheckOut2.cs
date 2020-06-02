//using System;
//using Veam.Domain.Core.Entity;

//namespace Veam.EAM.Domain
//{
//    public class CheckOut2 : EntityBase
//    {
//        public AssignedType assignedType { get; protected set; }
//        public AssignmentStatus assignmentStatus { get; protected set; }

//        //common for checkOut
//        public long assetId { get; protected set; }
//        public DateTime checkedOutDate { get; protected set; }
//        public AssetConditons assetConditon { get; set; }
//        public string conditionNote { get; private set; }
//        public DateTime approveDate { get; set; }
//        public string approvedBy { get; private set; }
//        public string acceptedBy { get; protected set; }
//        public DateTime requestedDate { get; private set; }
//        public string requestedBy { get; private set; }

//        // for Return retired

//        public DateTime returnedDate { get; protected set; }
//        public DateTime? retiredDate { get; protected set; }

//        //checkedoutTo
//        public long parentAssetId { get; set; }
//        public long subsideryId { get; set; }
//        public long centerId { get; protected set; }
//        public long hallId { get; protected set; }
//        public long employeeId { get; protected set; }
//        public long managerId { get; protected set; }

//        //Nav
//        public Asset asset { get;  set; }
      
//        //public Employee employee { get; protected set; }

//        protected CheckOut2() { }

//        public void CheckOutToEmployee(long CheckOutId, long CheckedOutToEmpId, long subsideryId,
//            long AssetId, string ConditionNote, AssetConditons AssetConditon,
//           string Requestedby, DateTime RequestedDate, string ApprovedBy, DateTime approveDate, string AcceptedBy, DateTime CheckedoutDate,
//           string user)

//        {
//            this.Id = CheckOutId;
//            this.assetId = AssetId;
//            this.assignedType = AssignedType.Employee; // set assigment to Employee
//            this.employeeId = CheckedOutToEmpId;
//            this.subsideryId = subsideryId;
//            AssignmentInfo(AssetConditon, ConditionNote);
//            RequestInfo(Requestedby, RequestedDate, ApprovedBy, approveDate, AcceptedBy, CheckedoutDate);
//            UpdateAuditInfo(user);
//        }

//        public void CheckOutToLocation(long CheckOutId, long CenterId, long HallId, long CompanyId, long ManagerId,
//           long AssetId, AssetConditons AssetConditon, string ConditionNote,
//           string Requestedby, DateTime RequestedDate, string ApprovedBy, DateTime approveDate, string AcceptedBy, DateTime CheckedoutDate,
//          string user)

//        {
//            this.Id = CheckOutId;
//            this.assetId = AssetId;
//            this.assignedType = AssignedType.Center;// set assigment to Location
//            LocationInfo(CenterId, HallId, ManagerId, CompanyId);
//            AssignmentInfo(AssetConditon, ConditionNote);
//            RequestInfo(Requestedby, RequestedDate, ApprovedBy, approveDate, AcceptedBy, CheckedoutDate);
//            UpdateAuditInfo(user);
//        }

//        //
//        private void RequestInfo(string Requestedby, DateTime RequestedDate, string ApprovedBy, DateTime approveDate,
//            string AcceptedBy, DateTime CheckedoutDate)
//        {
//            this.requestedBy = requestedBy;
//            this.requestedDate = RequestedDate;
//            this.approvedBy = approvedBy;
//            this.approveDate = approveDate;
//            this.acceptedBy = acceptedBy;
//            this.checkedOutDate = CheckedoutDate;
//        }

//        private void LocationInfo(long BranchId, long LocationId, long ManagerId,long CompanyId)
//        {
//            this.centerId = BranchId;
//            this.hallId = LocationId;
//            this.managerId = ManagerId;
//            this.subsideryId = CompanyId;
//        }

//        private void AssignmentInfo(AssetConditons AssetConditon, string ConditionNote)
//        {
//            this.assetConditon = AssetConditon;
//            this.conditionNote = ConditionNote;
//            this.assignmentStatus = AssignmentStatus.Accepted;
//        }
//    }

//    public enum AssetConditons2
//    {
//        New = 1,
//        Excellent = 2,
//        VGood = 3,
//        Good = 4,
//        Scraped = 5
//    }
//    public enum AssignedType2
//    {
//        Center = 1,
//        Employee = 2,
//        Department = 3,
//        Group = 4
//    }

//    public enum AssignmentStatus2
//    {
//        Requested = 1,
//        Approved = 2,
//        Accepted = 3,
//        Rejected = 4,
//        Returned = 5
//    }

  
//}
