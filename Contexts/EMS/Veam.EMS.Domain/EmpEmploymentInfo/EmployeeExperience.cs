using System;

namespace Veam.EMS.Domain
{
    public partial class EmployeeExperience : BaseEntity
    {
        public EmployeeExperience() { }
        
        public EmployeeExperience(bool? lastJob, string designation, string organisation,
            DateTime startDate, DateTime wrokedTill,
            string jobProfile, long employeeId,
            long id,string user)
        {
            LastJob = lastJob;
            Designation = designation;
            Organisation = organisation;
            StartDate = startDate;
            WrokedTill = wrokedTill;
            Period = (StartDate - WrokedTill).ToString();
            JobProfile = jobProfile;
            EmployeeId = employeeId;
            AuditInfo(id,user);
        }

        public bool? LastJob { get; protected set; }
        public string Designation { get; protected set; }
        public string Organisation { get; protected set; }
       
        public DateTime StartDate { get; protected set; }
        public DateTime WrokedTill { get; protected set; }
        public string Period { get;   }
        public string JobProfile { get; protected set; }

        public Employee Employee { get; protected set; }
        public long EmployeeId { get; protected set; } 
    }
}
