using System;

namespace Veam.EMS.Domain
{
    public class HireInfo : BaseEntity
    {
        public long EmployeeId { get; protected set; }
        #region Hire Info

        public string CardId { get; protected set; }
        public string HireType { get; protected set; }
        public DateTime HireDate { get; protected set; }
        public int HireforSubsidery { get; protected set; }
        public string EmployeeType { get; protected set; }

        protected HireInfo()
        {

        }
        public HireInfo(long employeeId, string cardId, string hireType, DateTime hireDate,
            int hireforSubsidery, string employeeType,
            long Id, string user)
        {
            EmployeeId = employeeId;
            CardId = cardId ?? throw new ArgumentNullException(nameof(cardId));
            HireType = hireType ?? throw new ArgumentNullException(nameof(hireType));
            HireDate = hireDate;
            HireforSubsidery = hireforSubsidery;
            EmployeeType = employeeType ?? throw new ArgumentNullException(nameof(employeeType));
            AuditInfo(Id, user);
        }
        #endregion


    }
}
