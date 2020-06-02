using System;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EMS.Domain
{
    public partial class EmployeeContact : BaseEntity
    {
      

        public Communication contact { get; protected set; }
        public long EmployeeId { get; protected set; }
        public Employee Employee { get; }

        //ctor and rules
        protected EmployeeContact() { }


        public EmployeeContact(long EmpContactId, Communication contact, long employeeId, string user)
        {
            this.contact = contact ?? throw new ArgumentNullException(nameof(contact));
            EmployeeId = employeeId  ;
            if (EmpContactId != 0)
            {
                this.Id = EmpContactId;
                UpdateAuditInfo(user);
            }
            else
            {
                CreateAuditInfo(user);
            }
        }
    }
}
