using System;

namespace Veam.EMS.Domain
{
    public class ResignInfo : BaseEntity
    {
        public ResignInfo(long employeeId, DateTime tDate, int tType, string tReason, string status,
             long Id, string user)
        {
            EmployeeId = employeeId;
            this.tDate = tDate;
            this.tType = tType;
            this.tReason = tReason ?? throw new ArgumentNullException(nameof(tReason));
            this.status = status ?? throw new ArgumentNullException(nameof(status));
            AuditInfo(Id, user);
        }
        protected ResignInfo()
        {

        }
        public long EmployeeId { get; protected set; }

        #region Termination Info
        public DateTime tDate { get; protected set; }
        public int tType { get; protected set; }
        public string tReason { get; protected set; }
        public string status { get; protected set; }
        #endregion
    }
}
