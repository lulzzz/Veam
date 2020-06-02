using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class EmployeeLocation : BaseEntity
    {
        public int LocationId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime ChangeDate { get; set; }

        public Employee Employee { get; set; }
        //public MasterLocation Location { get; set; }
    }
}
