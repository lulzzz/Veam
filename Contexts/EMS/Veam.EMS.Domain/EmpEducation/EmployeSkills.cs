using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class EmployeeSkills : BaseEntity
    {
        public long EmployeeId { get; set; }
        public string skills { get; set; }
        public string version { get; set; }
        public string Lastused { get; set; }

        public Employee Employee { get; set; }
      
    }
}
