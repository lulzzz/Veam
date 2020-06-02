using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    /// <summary>
    /// Degree,Training and Certificates,Skills collections
    /// </summary>
    public partial class EmployeeEducation : BaseEntity
    {
        public bool? LastEducation { get; set; } 

        public Employee Employee { get; set; }
        public long EmployeeId { get; set; }

       // public int CertificationId { get; set; }
        public ICollection< CertificationTraining> trainings { get; set; }

       // public int DegreeId { get; set; }
        public ICollection<EducationDegree> Degree { get; set; }
        public ICollection<EmployeeSkills> EmployeSkills { get; set; }
    }
}
