using System;

namespace Veam.EMS.Domain
{
    public partial class Employee : BaseEntity
    {
        protected Employee() { }
        
        public Employee(string title, string firstName, string lastName, string gender, DateTime? birthDate,
           long EmployeeId, string user)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Gender = gender ?? throw new ArgumentNullException(nameof(gender));
            BirthDate = birthDate;
            AuditInfo(EmployeeId,user);
        }

        #region Basic Info
        //   public long EmployeeId { get; set; } 
        public string Title { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Gender { get; protected set; }
        public Nullable<DateTime> BirthDate { get; protected set; }
        #endregion

        public EmployeeBasicInfo BasicInfo { get; set; }
        public EmployeeEducation EmployeeEducation { get; set; }
        public HireInfo EmploymentInfo { get; set; }
        public EmployeeState EmployeeState { get; set; }       
      
    }
}
