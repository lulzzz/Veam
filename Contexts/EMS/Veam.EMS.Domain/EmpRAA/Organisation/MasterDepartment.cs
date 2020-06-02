using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class MasterDepartment : BaseEntity
    {
        public MasterDepartment()
        {
            MasterSection = new HashSet<MasterSection>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentGroup { get; set; }

        public ICollection<MasterSection> MasterSection { get; set; }
    }
}
