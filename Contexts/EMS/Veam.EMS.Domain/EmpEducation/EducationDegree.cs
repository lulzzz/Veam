using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class EducationDegree : BaseEntity
    {
        public EducationDegree()
        {
           // EmployeeEducation = new HashSet<EmployeeEducation>();
        }

        public string Education { get; set; }
        public string Course { get; set; }
        public string Specialisation { get; set; } 
        public string University { get; set; }
        public string PassingYear { get; set; }
        public string GradingSystem { get; set; }
        public string Grade { get; set; }
        public long EmployeeEducationId { get; set; }
        public EmployeeEducation EmployeeEducation { get; set; }
    }
}
