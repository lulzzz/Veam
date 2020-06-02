using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class EmployeeState : BaseEntity
    {
        public EmployeeState()
        {
            EmployeeLocation = new HashSet<EmployeeLocation>();
        }
        public long EmployeeId { get; set; }
        public int PositionId { get; set; }
        public int JobFunctionId { get; set; }
        public byte ShiftId { get; set; }
        public int LevelId { get; set; }
     
        public DateTime JoinDate { get; set; }
        public DateTime ChangedDate { get; set; }

      

        public Employee Employee { get; set; }
        public MasterJobPosition Position { get; set; }
        public MasterJobFunction JobFunction { get; set; }
        public MasterLevel Level { get; set; }
       
        public MasterShift Shift { get; set; }
        public ICollection<EmployeeLocation> EmployeeLocation { get; set; }
    }
}
